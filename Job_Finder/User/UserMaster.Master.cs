using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Job_Finder.User
{
    public partial class UserMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["JFUser"] != null)
            {
                rpBtnRegisterOrProfile.Text = "Profile";
                llBtnLoginOrLogout.Text = "Logout";
                fpBtnFindOrProvide.Text = "Find a Job";
                pagesLink.Visible = true;
                pj.Visible = false;
            }
            else if (Session["JPUser"] != null)
            {
                rpBtnRegisterOrProfile.Text = "Profile";
                llBtnLoginOrLogout.Text = "Logout";
                fpBtnFindOrProvide.Text = "Post a Job";
                pagesLink.Visible = true;
                pj.Visible = true;
            }
            else
            {
                rpBtnRegisterOrProfile.Text = "Register";
                llBtnLoginOrLogout.Text = "Login";
                fpBtnFindOrProvide.Text = "Find a Job";
                pagesLink.Visible = false;
            }
        }
        protected void rpBtnRegisterOrProfile_Click(object sender, EventArgs e)
        {
            if (rpBtnRegisterOrProfile.Text == "Profile")
            {
                if (Session["JFUser"] != null)
                {
                    Response.Redirect("Profile_JFinder.aspx");
                }
                else if (Session["JPUser"] != null)
                {
                    Response.Redirect("Profile_JProvider.aspx");
                }
            }
            else
            {
                Response.Redirect("Register_JFinder.aspx");
            }
        }

        protected void llBtnLoginOrLogout_Click(object sender, EventArgs e)
        {
            if (llBtnLoginOrLogout.Text == "Logout")
            {
                Session.Abandon();
                Response.Redirect("Login.aspx");
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void fpBtnFindOrProvide_Click(object sender, EventArgs e)
        {
            if (fpBtnFindOrProvide.Text == "Find a Job")
            {
                Response.Redirect("Find_job.aspx");
            }
            else
            {
                Response.Redirect("Post_job.aspx");
            }
        }

        SqlConnection con;
        SqlCommand cmd;
        string str = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        protected void nlBtnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(str);
                string query = @"Insert into NLTable values (@NLEmail)";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@NLEmail", txtNLEmail.Value.Trim());
                con.Open();
                int r = cmd.ExecuteNonQuery();

                if (r > 0)
                {
                    nllb.Visible = true;
                    nllb.Text = "Subscribe Successfull!";
                    nllb.CssClass = "alert alert-success";

                    txtNLEmail.Value = String.Empty;

                    ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "script", "window.setTimeout(function() { document.getElementById('" + nllb.ClientID + "').style.display = 'none' },3000);", true);
                }
                else
                {
                    nllb.Visible = true;
                    nllb.Text = "Cannot save record right not, Plz try after sometime!";
                    nllb.CssClass = "alert alert-danger";

                    ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "script", "window.setTimeout(function() { document.getElementById('" + nllb.ClientID + "').style.display = 'none' },3000);", true);
                }
                
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
            finally
            {
                con.Close();
            }
        }
    }
}