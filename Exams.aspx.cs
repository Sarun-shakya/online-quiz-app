using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI.WebControls;

namespace Online_Quiz_Application
{
    public partial class Exams : System.Web.UI.Page
    {
        string cs = ConfigurationManager
                    .ConnectionStrings["QuizDB"]
                    .ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["fullName"] == null)
            {
                HttpContext.Current.Response.Redirect("~/Login.aspx");
            }
            if (!IsPostBack)
            {
                LoadExams();
            }
        }

        private void LoadExams()
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = @"
                    SELECT examId,
                           name,
                           totalQuestions,
                           durationMinutes
                    FROM exams
                    WHERE published = 1";

                SqlDataAdapter da = new SqlDataAdapter(query, con);

                DataTable dt = new DataTable();
                da.Fill(dt);

                rptExams.DataSource = dt;
                rptExams.DataBind();
            }
        }

        protected void btnStart_Command(object sender, CommandEventArgs e)
        {
            int examId = Convert.ToInt32(e.CommandArgument);

            Response.Redirect("~/TakeExam.aspx?examId=" + examId);
        }
    }
}