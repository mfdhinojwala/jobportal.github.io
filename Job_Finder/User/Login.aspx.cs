using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Job_Finder.User
{
    public partial class Login : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader sdr;
        string str = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        String Username, Password = String.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void lBtnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlLoginType.SelectedValue == "Admin")
                {
                   Username = ConfigurationManager.AppSettings["Username"];
                   Password = ConfigurationManager.AppSettings["Password"];

                    if (Username == txtUsername.Text.Trim() && Password == txtPassword.Text.Trim())
                    {
                        Session["Admin"] = Username;
                        Response.Redirect("../Admin/AdminIndex.aspx", false);
                    }
                    else
                    {
                        llb.Visible = true;
                        llb.Text = "<b>" + txtUsername.Text.Trim() + "</b> credentials are incorrect...!";
                        llb.CssClass = "alert alert-danger";

                        ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "script", "window.setTimeout(function() { document.getElementById('" + llb.ClientID + "').style.display = 'none' },2700);", true);
                    }
                }
                else if (ddlLoginType.SelectedValue == "Job Finder")
                {
                    con = new SqlConnection(str);
                    string query = @"Select UserId,Username,Password from JFinderTable where Username = @Username and Password = @Password";
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());
                    cmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());
                    con.Open();
                    sdr = cmd.ExecuteReader();

                    if (sdr.Read())
                    {
                        Session["JFUser"] = sdr["Username"].ToString();
                        Session["JFUserID"] = sdr["UserID"].ToString();
                        Response.Redirect("UserIndex.aspx", false);
                    }
                    else
                    {
                        llb.Visible = true;
                        llb.Text = "<b>" + txtUsername.Text.Trim() + "</b> credentials are incorrect...!";
                        llb.CssClass = "alert alert-danger";

                        ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "script", "window.setTimeout(function() { document.getElementById('" + llb.ClientID + "').style.display = 'none' },3000);", true);
                    }
                    con.Close();
                }
                else if (ddlLoginType.SelectedValue == "Job Provider")
                {
                    con = new SqlConnection(str);
                    string query = @"Select CompanyID,CompanyName,Password from JProviderTable where CompanyName = @CompanyName and Password = @Password";
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@CompanyName", txtUsername.Text.Trim());
                    cmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());
                    con.Open();
                    sdr = cmd.ExecuteReader();

                    if (sdr.Read())
                    {
                        Session["JPUser"] = sdr["CompanyName"].ToString();
                        Session["JPUserID"] = sdr["CompanyID"].ToString();
                        Response.Redirect("UserIndex.aspx", false);
                    }
                    else
                    {
                        llb.Visible = true;
                        llb.Text = "<b>" + txtUsername.Text.Trim() + "</b> credentials are incorrect...!";
                        llb.CssClass = "alert alert-danger";

                        ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "script", "window.setTimeout(function() { document.getElementById('" + llb.ClientID + "').style.display = 'none' },3000);", true);
                    }
                    con.Close();
                }
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                con.Close();
            }
        }
    }
}