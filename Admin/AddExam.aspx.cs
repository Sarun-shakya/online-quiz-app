using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Online_Quiz_Application.Admin
{
    public partial class AddExam : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["QuizDB"].ConnectionString;

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string examName = txtName.Text.Trim();
            string description = txtDescription.Text.Trim();

            int totalQuestions;
            int marksPerQuestion;
            int duration;

            if (string.IsNullOrWhiteSpace(examName))
            {
                lblMsg.Text = "Exam name is required.";
                lblMsg.CssClass = "text-danger";
                return;
            }

            if (string.IsNullOrWhiteSpace(description))
            {
                lblMsg.Text = "Description is required.";
                lblMsg.CssClass = "text-danger";
                return;
            }

            if (!int.TryParse(txtTotalQuestions.Text, out totalQuestions) || totalQuestions <= 0)
            {
                lblMsg.Text = "Total questions must be a positive number.";
                lblMsg.CssClass = "text-danger";
                return;
            }

            if (!int.TryParse(txtMarks.Text, out marksPerQuestion) || marksPerQuestion <= 0)
            {
                lblMsg.Text = "Marks per question must be a positive number.";
                lblMsg.CssClass = "text-danger";
                return;
            }

            if (!int.TryParse(txtDuration.Text, out duration) || duration <= 0)
            {
                lblMsg.Text = "Duration must be a positive number.";
                lblMsg.CssClass = "text-danger";
                return;
            }

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();

                string checkQuery = "SELECT COUNT(*) FROM exams WHERE name = @name";

                using (SqlCommand checkCmd = new SqlCommand(checkQuery, con))
                {
                    checkCmd.Parameters.AddWithValue("@name", examName);

                    int count = (int)checkCmd.ExecuteScalar();

                    if (count > 0)
                    {
                        lblMsg.Text = "An exam with this name already exists.";
                        lblMsg.CssClass = "text-danger";
                        return;
                    }
                }

                string query = @"INSERT INTO exams
                                (name, description, totalQuestions, marksPerQuestion, durationMinutes)
                                VALUES
                                (@name, @desc, @totalQ, @marks, @duration)";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@name", examName);
                    cmd.Parameters.AddWithValue("@desc", description);
                    cmd.Parameters.AddWithValue("@totalQ", totalQuestions);
                    cmd.Parameters.AddWithValue("@marks", marksPerQuestion);
                    cmd.Parameters.AddWithValue("@duration", duration);

                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        lblMsg.Text = "Exam added successfully!";
                        lblMsg.CssClass = "text-success";

                        txtName.Text = "";
                        txtDescription.Text = "";
                        txtTotalQuestions.Text = "";
                        txtMarks.Text = "";
                        txtDuration.Text = "";
                    }
                    else
                    {
                        lblMsg.Text = "Failed to add exam.";
                        lblMsg.CssClass = "text-danger";
                    }
                }
            }
        }
    }
}