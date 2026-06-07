using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;

namespace Online_Quiz_Application.Admin
{
    public partial class Dashboard : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["QuizDB"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["admin"] == null)
            {
                HttpContext.Current.Response.Redirect("~/Admin/Login.aspx");
            }
            if (!IsPostBack)
            {
                LoadStats();
                LoadRecentExams();
                LoadRecentResults();
            }
        }

        private void LoadStats()
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                con.Open();

                // USERS
                SqlCommand cmd1 = new SqlCommand("SELECT COUNT(*) FROM users", con);
                lblUsers.Text = cmd1.ExecuteScalar().ToString();

                // EXAMS
                SqlCommand cmd2 = new SqlCommand("SELECT COUNT(*) FROM exams", con);
                lblExams.Text = cmd2.ExecuteScalar().ToString();

                // QUESTIONS
                SqlCommand cmd3 = new SqlCommand("SELECT COUNT(*) FROM questions", con);
                lblQuestions.Text = cmd3.ExecuteScalar().ToString();

                // RESULTS
                SqlCommand cmd4 = new SqlCommand("SELECT COUNT(*) FROM results", con);
                lblResults.Text = cmd4.ExecuteScalar().ToString();
            }
        }

        private void LoadRecentExams()
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                string query = @"SELECT TOP 5 * FROM exams ORDER BY examId DESC";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gvExams.DataSource = dt;
                gvExams.DataBind();
            }
        }

        private void LoadRecentResults()
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                string query = @"
                    SELECT TOP 5 r.resultId, u.fullName, e.name AS examName, r.score, r.examDate
                    FROM results r
                    INNER JOIN users u ON r.userId = u.userId
                    INNER JOIN exams e ON r.examId = e.examId
                    ORDER BY r.resultId DESC";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gvResults.DataSource = dt;
                gvResults.DataBind();
            }
        }
    }
}