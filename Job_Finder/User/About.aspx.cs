using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Job_Finder.User
{
    public partial class About : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["JFUser"] != null)
            {
                uycv.Visible = true;
                btnPaj.Visible = false;
            }
            else if (Session["JPUser"] != null)
            {
                uycv.Visible = false;
                btnPaj.Visible = true;
            }
            else
            {
                uycv.Visible = true;
                btnPaj.Visible = true;
            }
        }

        protected void btnPaj_Click(object sender, EventArgs e)
        {
            if (Session["JPUser"] != null)
            {
                Response.Redirect("Post_Job.aspx");
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}