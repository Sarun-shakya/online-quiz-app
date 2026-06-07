using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI.WebControls;

namespace Online_Quiz_Application
{
    public partial class TakeExam : System.Web.UI.Page
    {
        string cs = ConfigurationManager
            .ConnectionStrings["QuizDB"]
            .ConnectionString;

        int examId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["fullName"] == null)
            {
                HttpContext.Current.Response.Redirect("~/Login.aspx");
            }
            if (Request.QueryString["examId"] == null)
            {
                Response.Redirect("Exams.aspx");
            }

            examId = Convert.ToInt32(Request.QueryString["examId"]);

            if (!IsPostBack)
            {
                LoadQuestions();
                LoadExamName();
                ViewState["Duration"] = GetExamDuration();
            }

            if (Session["Submitted"] != null)
            {
                btnSubmit.Visible = false;
            }
        }

        public void LoadExamName()
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = "SELECT name FROM exams WHERE examId=@id";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", examId);

                con.Open();

                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    lblExamName.Text = result.ToString(); 
                }
            }
        }

        private void LoadQuestions()
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = @"
                SELECT *
                FROM questions
                WHERE examId=@examId";

                SqlDataAdapter da =
                    new SqlDataAdapter(query, con);

                da.SelectCommand.Parameters
                    .AddWithValue("@examId", examId);

                DataTable dt = new DataTable();

                da.Fill(dt);

                rptQuestions.DataSource = dt;
                rptQuestions.DataBind();
            }
        }

        public int GetExamDuration()
        {
            int duration = 10; // fallback default

            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = "SELECT durationMinutes FROM Exams WHERE examId=@id";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", examId);

                con.Open();

                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    duration = Convert.ToInt32(result);
                }
            }

            return duration;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int score = 0;
            int total = 0;
            int marksPerQuestion = 1;

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();

                // find marks per question

                string markQuery =
                    "SELECT marksPerQuestion FROM exams WHERE examId=@examId";

                SqlCommand markCmd = new SqlCommand(markQuery, con);
                markCmd.Parameters.AddWithValue("@examId", examId);

                marksPerQuestion = Convert.ToInt32(markCmd.ExecuteScalar());

                // find correct answer
                string query =
                    "SELECT questionId, correctAnswer FROM questions WHERE examId=@examId";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@examId", examId);

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    total++;

                    int qid = Convert.ToInt32(dr["questionId"]);
                    string correct = dr["correctAnswer"].ToString();

                    string selected =
                        Request.Form["q" + qid];

                    ViewState["q" + qid] = selected;
                    ViewState["correct" + qid] = correct;

                    if (selected == correct)
                    {
                        score += marksPerQuestion;
                    }
                }

                dr.Close();

                int userId =
                    Convert.ToInt32(Session["UserId"]);

                string insertQuery =
                    @"INSERT INTO results(userId,examId,score)
              VALUES(@userId,@examId,@score)";

                SqlCommand insertCmd =
                    new SqlCommand(insertQuery, con);

                insertCmd.Parameters.AddWithValue("@userId", userId);
                insertCmd.Parameters.AddWithValue("@examId", examId);
                insertCmd.Parameters.AddWithValue("@score", score);

                insertCmd.ExecuteNonQuery();
            }
            int totalMarks = total * marksPerQuestion;

            Session["Submitted"] = true;


            lblResult.Text = "Score: " + score + " / " + totalMarks;

            btnSubmit.Visible = false;
            btnExplore.Visible = true;

            LoadQuestions();

            ViewState["ExamSubmitted"] = true;
        }

        public string GetOptionClass(string qid, string option, string correct)
        {
            if (Session["Submitted"] == null)
            {
                return "btn-outline-primary";
            }

            string selected = ViewState["q" + qid]?.ToString();

            if (option == correct)
                return "btn-success";

            if (selected == option && selected != correct)
                return "btn-danger";

            return "btn-outline-primary";
        }

        protected void btnExplore_Click(object sender, EventArgs e)
        {
            Session["Submitted"] = null;

            Response.Redirect("~/Exams.aspx");
        }
    }
}