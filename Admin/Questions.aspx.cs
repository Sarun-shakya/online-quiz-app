using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Online_Quiz_Application.Admin
{
    public partial class Questions : System.Web.UI.Page
    {
        string cs = ConfigurationManager
                    .ConnectionStrings["QuizDB"]
                    .ConnectionString;

        int examId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["admin"] == null)
            {
                HttpContext.Current.Response.Redirect("~/Admin/Login.aspx");
            }
            if (Request.QueryString["examId"] == null)
            {
                Response.Redirect("Exams.aspx");
            }

            examId = Convert.ToInt32(Request.QueryString["examId"]);

            if (!IsPostBack)
            {
                LoadExam();
                LoadQuestions();
            }
        }

        private void LoadExam()
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                string query =
                    "SELECT name FROM exams WHERE examId=@id";

                SqlCommand cmd =
                    new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@id", examId);

                con.Open();

                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    lblExam.Text =
                        "Exam : " + result.ToString();
                }
            }
        }

        protected void btnAddQuestion_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();

                int maxQuestions = 0;

                string maxQuery = "SELECT totalQuestions FROM exams WHERE examId=@examId";
                SqlCommand maxCmd = new SqlCommand(maxQuery, con);
                maxCmd.Parameters.AddWithValue("@examId", examId);

                object result = maxCmd.ExecuteScalar();

                if (result != null)
                {
                    maxQuestions = Convert.ToInt32(result);
                }

                int currentCount = 0;

                string countQuery = "SELECT COUNT(*) FROM questions WHERE examId=@examId";
                SqlCommand countCmd = new SqlCommand(countQuery, con);
                countCmd.Parameters.AddWithValue("@examId", examId);

                currentCount = (int)countCmd.ExecuteScalar();

                if (currentCount >= maxQuestions)
                {
                    lblMsg.Text = "Cannot add more questions. Limit reached!";
                    lblMsg.CssClass = "text-danger";
                    return;
                }

                string query =
                @"INSERT INTO questions
                (examId,questionText,optionA,optionB,optionC,optionD,correctAnswer)
                VALUES
                (@examId,@question,@A,@B,@C,@D,@answer)";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@examId", examId);
                cmd.Parameters.AddWithValue("@question", txtQuestion.Text);
                cmd.Parameters.AddWithValue("@A", txtA.Text);
                cmd.Parameters.AddWithValue("@B", txtB.Text);
                cmd.Parameters.AddWithValue("@C", txtC.Text);
                cmd.Parameters.AddWithValue("@D", txtD.Text);
                cmd.Parameters.AddWithValue("@answer", ddlAnswer.SelectedValue);

                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    lblMsg.Text = "Question Added Successfully!";
                    lblMsg.CssClass = "text-success";

                    txtQuestion.Text = "";
                    txtA.Text = "";
                    txtB.Text = "";
                    txtC.Text = "";
                    txtD.Text = "";
                }
                else
                {
                    lblMsg.Text = "Failed to add question.";
                    lblMsg.CssClass = "text-danger";
                }

                LoadQuestions();
            }
        }

        private void LoadQuestions()
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                string query =
                @"SELECT questionId,
                         questionText,
                         optionA,
                         optionB,
                         optionC,
                         optionD,
                         correctAnswer
                  FROM questions
                  WHERE examId=@examId";

                SqlDataAdapter da =
                    new SqlDataAdapter(query, con);

                da.SelectCommand.Parameters
                    .AddWithValue("@examId", examId);

                DataTable dt = new DataTable();

                da.Fill(dt);

                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int questionId = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "DeleteQuestion")
            {
                DeleteQuestion(questionId);
                LoadQuestions();
            }

            else if (e.CommandName == "UpdateQuestion")
            {
                Response.Redirect("UpdateQuestion.aspx?questionId=" + questionId);
            }
        }

        private void DeleteQuestion(int questionId)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = "DELETE FROM questions WHERE questionId=@id";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", questionId);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}