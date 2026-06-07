using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Online_Quiz_Application.Admin
{
    public partial class AdminMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null)
            {
                Response.Redirect("~/Admin/Login.aspx");
                return;
            }

            usernameLabel.Text = Session["admin"].ToString();

            string page = System.IO.Path.GetFileNameWithoutExtension(Request.Path).ToLower();

            switch (page)
            {
                case "dashboard":
                    lnkDashboard.Attributes["class"] = "active";
                    break;

                case "exams":
                    lnkExams.Attributes["class"] = "active";
                    break;

                case "addexam":
                    lnkAddExam.Attributes["class"] = "active";
                    break;

                case "users":
                    lnkUsers.Attributes["class"] = "active";
                    break;

                case "results":
                    lnkResults.Attributes["class"] = "active";
                    break;
            }
        }
    }
}