using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Online_Quiz_Application.Admin
{
    public partial class Users : System.Web.UI.Page
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
                LoadData();
            }
        }

        protected void LoadData()
        {
            try
            {
                SqlConnection conn = new SqlConnection(connStr);
                conn.Open();
                string query = "SELECT * FROM users";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                usersGrid.DataSource = dt;
                usersGrid.DataBind();

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

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int userId = Convert.ToInt32(btn.CommandArgument);

            string cs = ConfigurationManager.ConnectionStrings["QuizDB"].ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = "DELETE FROM Users WHERE userId=@userId";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@userId", userId);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            LoadData(); 
        }
    }
}