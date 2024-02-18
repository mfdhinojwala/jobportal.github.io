using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Job_Finder.User
{
    public partial class Register : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        string str = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void rBtnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(str);
                string query = @"Insert into [JFinderTable] (Username,Password,Name,Address,MNumber,Email,Country) values (@Username,@Password,@Name,@Address,@MNumber,@Email,@Country)";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());
                cmd.Parameters.AddWithValue("@Password", txtCPassword.Text.Trim());
                cmd.Parameters.AddWithValue("@Name", txtFullname.Text.Trim());
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                cmd.Parameters.AddWithValue("@MNumber", txtMNumber.Text.Trim());
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@Country", ddlCountry.SelectedValue);
                con.Open();
                int r = cmd.ExecuteNonQuery();

                if (r > 0)
                {
                    rlb.Visible = true;
                    rlb.Text = "Register Successfull!";
                    rlb.CssClass = "alert alert-success";

                    txtUsername.Text = String.Empty;
                    txtPassword.Text = String.Empty;
                    txtCPassword.Text = String.Empty;
                    txtFullname.Text = String.Empty;
                    txtAddress.Text = String.Empty;
                    txtMNumber.Text = String.Empty;
                    txtEmail.Text = String.Empty;
                    ddlCountry.ClearSelection();

                    ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "script", "window.setTimeout(function() { document.getElementById('" + rlb.ClientID + "').style.display = 'none' },3000);", true);
                }
                else
                {
                    rlb.Visible = true;
                    rlb.Text = "Cannot save record right not, Plz try after sometime!";
                    rlb.CssClass = "alert alert-danger";

                    ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "script", "window.setTimeout(function() { document.getElementById('" + rlb.ClientID + "').style.display = 'none' },3000);", true);
                }
            }
            catch(SqlException ex)
            {
                if (ex.Message.Contains("Violation of UNIQUE KEY constraint"))
                {
                    rlb.Visible = true;
                    rlb.Text = "<b>" + txtUsername.Text.Trim() + "</b> username already exist, try new one...!";
                    rlb.CssClass = "alert alert-danger";

                    ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "script", "window.setTimeout(function() { document.getElementById('" + rlb.ClientID + "').style.display = 'none' },3000);", true);
                }
                else
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
            catch(Exception ex)
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