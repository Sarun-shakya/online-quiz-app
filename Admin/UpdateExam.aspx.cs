using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Online_Quiz_Application.Admin
{
    public partial class UpdateExam : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["QuizDB"].ConnectionString;
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

            if (!IsPostBack)
            {
                LoadExam();
            }
        }

        private void LoadExam()
        {
            int examId = Convert.ToInt32(Request.QueryString["examId"]);

            using (SqlConnection con = new SqlConnection(connStr))
            {
                string query = "SELECT * FROM exams WHERE examId=@examId";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@examId", examId);

                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    txtName.Text = dr["name"].ToString();
                    txtDescription.Text = dr["description"].ToString();
                    txtTotalQuestions.Text = dr["totalQuestions"].ToString();
                    txtMarks.Text = dr["marksPerQuestion"].ToString();
                    txtDuration.Text = dr["durationMinutes"].ToString();
                }
                else
                {
                    Response.Redirect("ManageExams.aspx");
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int examId = Convert.ToInt32(Request.QueryString["examId"]);

                using (SqlConnection con = new SqlConnection(connStr))
                {
                    string query = @"UPDATE exams
                             SET name=@name,
                                 description=@description,
                                 totalQuestions=@totalQuestions,
                                 marksPerQuestion=@marks,
                                 durationMinutes=@duration
                             WHERE examId=@examId";

                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@name", txtName.Text.Trim());
                    cmd.Parameters.AddWithValue("@description", txtDescription.Text.Trim());
                    cmd.Parameters.AddWithValue("@totalQuestions", Convert.ToInt32(txtTotalQuestions.Text));
                    cmd.Parameters.AddWithValue("@marks", Convert.ToInt32(txtMarks.Text));
                    cmd.Parameters.AddWithValue("@duration", Convert.ToInt32(txtDuration.Text));
                    cmd.Parameters.AddWithValue("@examId", examId);

                    con.Open();

                    int rows = cmd.ExecuteNonQuery();

                    lblMsg.Text = rows > 0
                        ? "Exam updated successfully."
                        : "No record was updated.";
                }
            }
            catch (FormatException)
            {
                lblMsg.Text = "Please enter valid numeric values.";
            }
            catch (Exception ex)
            {
                lblMsg.Text = "Error: " + ex.Message;
            }
        }
    }

}