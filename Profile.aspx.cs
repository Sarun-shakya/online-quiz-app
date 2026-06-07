using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Online_Quiz_Application
{
    public partial class Profile : System.Web.UI.Page
    {
        string connStr =
            ConfigurationManager.ConnectionStrings["QuizDB"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userId"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                LoadUserDetails();
                LoadExamHistory();
            }
        }

        private void LoadUserDetails()
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                string query = @"SELECT fullName,
                                        email,
                                        createdAt
                                 FROM users
                                 WHERE userId=@userId";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue(
                    "@userId",
                    Session["userId"]);

                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    lblName.Text = dr["fullName"].ToString();
                    lblEmail.Text = dr["email"].ToString();

                    lblCreatedAt.Text =
                        Convert.ToDateTime(dr["createdAt"])
                        .ToString("dd MMM yyyy");
                }
            }
        }

        private void LoadExamHistory()
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                string query = @"
                        SELECT
                            e.name AS ExamName,
                            r.score AS ObtainedMarks,
                            (e.totalQuestions * e.marksPerQuestion) AS FullMarks,
                            r.examDate
                        FROM results r
                        INNER JOIN exams e
                            ON r.examId = e.examId
                        WHERE r.userId = @userId
                        ORDER BY r.examDate DESC";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue(
                    "@userId",
                    Session["userId"]);

                SqlDataAdapter da =
                    new SqlDataAdapter(cmd);

                DataTable dt =
                    new DataTable();

                da.Fill(dt);

                gvResults.DataSource = dt;
                gvResults.DataBind();
            }
        }
    }
}