using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Online_Quiz_Application.Admin
{
    public partial class Exams : System.Web.UI.Page
    {
    string cs = ConfigurationManager.ConnectionStrings["QuizDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["admin"] == null)
            {
                HttpContext.Current.Response.Redirect("~/Admin/Login.aspx");
            }
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        protected void LoadData()
        {
            try
            {
                SqlConnection conn = new SqlConnection(cs);
                conn.Open();
                string query = "SELECT * FROM exams";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                GridView1.DataSource = dt;
                GridView1.DataBind();

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int examId = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "UpdateExam")
            {
                Response.Redirect("~/Admin/UpdateExam.aspx?examId=" + examId);
            }

            else if (e.CommandName == "DeleteExam")
            {
                DeleteExam(examId);
                LoadData();
            }

            else if (e.CommandName == "Questions")
            {
                Response.Redirect(
                    "~/Admin/Questions.aspx?examId=" + e.CommandArgument);
            }

            else if (e.CommandName == "TogglePublish")
            {
                TogglePublish(Convert.ToInt32(e.CommandArgument));
                LoadData();
            }
        }
        private void TogglePublish(int examId)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();

                string statusQuery = "SELECT published FROM exams WHERE examId=@id";
                SqlCommand statusCmd = new SqlCommand(statusQuery, con);
                statusCmd.Parameters.AddWithValue("@id", examId);

                object statusResult = statusCmd.ExecuteScalar();
                if (statusResult == null)
                    return;

                bool isPublished = Convert.ToBoolean(statusResult);

                string examQuery = "SELECT totalQuestions FROM exams WHERE examId=@id";
                SqlCommand examCmd = new SqlCommand(examQuery, con);
                examCmd.Parameters.AddWithValue("@id", examId);

                object reqResult = examCmd.ExecuteScalar();
                int requiredQuestions = Convert.ToInt32(reqResult ?? 0);

                string countQuery = "SELECT COUNT(*) FROM questions WHERE examId=@id";
                SqlCommand countCmd = new SqlCommand(countQuery, con);
                countCmd.Parameters.AddWithValue("@id", examId);

                int actualQuestions = Convert.ToInt32(countCmd.ExecuteScalar() ?? 0);

                if (!isPublished)
                {
                    if (actualQuestions < requiredQuestions)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(),
                            "alert",
                            $"alert('Cannot publish exam. Required: {requiredQuestions}, Added: {actualQuestions}');",
                            true);
                        return;
                    }

                    string publishQuery = "UPDATE exams SET published = 1 WHERE examId=@id";
                    SqlCommand cmd = new SqlCommand(publishQuery, con);
                    cmd.Parameters.AddWithValue("@id", examId);
                    cmd.ExecuteNonQuery();

                }
                else
                {
                    string unpublishQuery = "UPDATE exams SET published = 0 WHERE examId=@id";
                    SqlCommand cmd = new SqlCommand(unpublishQuery, con);
                    cmd.Parameters.AddWithValue("@id", examId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        private void DeleteExam(int examId)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = "DELETE FROM exams WHERE examId=@id";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", examId);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}