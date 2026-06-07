using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Online_Quiz_Application
{
    public partial class Login : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["QuizDB"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(email))
            {
                lblMessage.Text = "Email is required.";
                lblMessage.Visible = true;
                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                lblMessage.Text = "Password is required.";
                lblMessage.Visible = true;
                return;
            }

            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                lblMessage.Text = "Please enter a valid email address.";
                lblMessage.Visible = true;
                return;
            }

            string hashedPassword = PasswordHelper.HashPassword(password);

            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = "SELECT UserId, fullName FROM Users WHERE Email=@Email AND Password=@Password";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", hashedPassword);

                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            Session["UserId"] = dr["UserId"].ToString();
                            Session["fullName"] = dr["fullName"].ToString();

                            Response.Redirect("~/Default.aspx");
                        }
                        else
                        {
                            lblMessage.Text = "Invalid email or password.";
                            lblMessage.Visible = true;
                        }
                    }
                }
            }
        }
    }
}