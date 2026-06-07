using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Online_Quiz_Application.Admin
{
    public partial class Login : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["QuizDB"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            // Username validation
            if (string.IsNullOrWhiteSpace(username))
            {
                lblMsg.Text = "Username is required.";
                lblMsg.CssClass = "text-danger";
                return;
            }

            // Password validation
            if (string.IsNullOrWhiteSpace(password))
            {
                lblMsg.Text = "Password is required.";
                lblMsg.CssClass = "text-danger";
                return;
            }

            string hashedPassword = PasswordHelper.HashPassword(password);

            string query = @"SELECT COUNT(*) 
                             FROM admins 
                             WHERE username=@username 
                             AND password=@password";

            using (SqlConnection con = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", hashedPassword);

                    con.Open();

                    int count = (int)cmd.ExecuteScalar();

                    if (count == 1)
                    {
                        Session["admin"] = username;
                        Response.Redirect("Dashboard.aspx");
                    }
                    else
                    {
                        lblMsg.Text = "Invalid username or password.";
                        lblMsg.CssClass = "text-danger";
                    }
                }
            }
        }
    }
}