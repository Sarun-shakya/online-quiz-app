using System;
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
    public partial class Results : System.Web.UI.Page
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
            SqlConnection conn = new SqlConnection(connStr);

            string query = @"
            SELECT u.fullName, e.name, r.score, r.examDate
            FROM results r
            INNER JOIN exams e ON e.examId = r.examId
            INNER JOIN users u ON u.userId = r.userId";

            conn.Open();

            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            resultsGrid.DataSource = dt;
            resultsGrid.DataBind();
        }
    }
}