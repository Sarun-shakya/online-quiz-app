using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Online_Quiz_Application.Admin
{
    public partial class UpdateQuestion : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["QuizDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["admin"] == null)
            {
                HttpContext.Current.Response.Redirect("~/Admin/Login.aspx");
            }
            if (Request.QueryString["questionId"] == null)
            {
                Response.Redirect("Questions.aspx");
            }

            if (!IsPostBack)
            {
                LoadExam();
            }
        }

        protected void LoadExam()
        {
            int questionId = Convert.ToInt32(Request.QueryString["questionId"]);

            using (SqlConnection con = new SqlConnection(connStr))
            {
                string query = "SELECT * FROM questions WHERE questionId=@questionId";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@questionId", questionId);

                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {

                    txtQuestion.Text = dr["questionText"].ToString();
                    txtA.Text = dr["optionA"].ToString();
                    txtB.Text = dr["optionB"].ToString();
                    txtC.Text = dr["optionC"].ToString();
                    txtD.Text = dr["optionD"].ToString();
                    ddlAnswer.Items.FindByValue(dr["correctAnswer"].ToString()).Selected = true;
                }
                else
                {
                    Response.Redirect("Question.aspx");
                }
            }
        }

        protected void btnUpdateQuestion_Click(object sender, EventArgs e)
        {
            try
            {
                int questionId = Convert.ToInt32(Request.QueryString["questionId"]);

                using (SqlConnection con = new SqlConnection(connStr))
                {
                    string query = @"UPDATE questions
                             SET questionText=@questionText,
                                 optionA=@optionA,
                                 optionB=@optionB,
                                 optionC=@optionC,
                                 optionD=@optionD,
                                 correctAnswer = @correctAnswer
                             WHERE questionId=@questionId";

                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@questionText", txtQuestion.Text.Trim());
                    cmd.Parameters.AddWithValue("@optionA", txtA.Text.Trim());
                    cmd.Parameters.AddWithValue("@optionB", txtB.Text.Trim());
                    cmd.Parameters.AddWithValue("@optionC", txtC.Text.Trim());
                    cmd.Parameters.AddWithValue("@optionD", txtD.Text.Trim());
                    cmd.Parameters.AddWithValue("@correctAnswer", ddlAnswer.SelectedValue);
                    cmd.Parameters.AddWithValue("@questionId", questionId);

                    con.Open();

                    int rows = cmd.ExecuteNonQuery();

                    lblMsg.Text = rows > 0
                        ? "Question updated successfully."
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