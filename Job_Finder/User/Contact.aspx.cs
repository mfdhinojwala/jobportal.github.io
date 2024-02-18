using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Job_Finder.User
{
    public partial class Contact : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        string str = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void cBtnSend_Click(object sender, EventArgs e)
        {
            try
            {
                con= new SqlConnection(str);
                string query = @"Insert into ContactTable values (@Message,@Name,@Email,@Subject)";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Message", message.Value.Trim());
                cmd.Parameters.AddWithValue("@Name", name.Value.Trim());
                cmd.Parameters.AddWithValue("@Email", email.Value.Trim());
                cmd.Parameters.AddWithValue("@Subject", subject.Value.Trim());
                con.Open();
                int r = cmd.ExecuteNonQuery();

                if (r > 0)
                {
                    rlb.Visible= true;
                    rlb.Text = "Thanks for reaching out will look into your query!";
                    rlb.CssClass = "alert alert-success";

                    message.Value = String.Empty;
                    name.Value = String.Empty;
                    email.Value = String.Empty;
                    subject.Value = String.Empty;

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
            catch(Exception ex) 
            {
                Response.Write("<script>alert('"+ex.Message+"');</script>");
            }
            finally 
            {
                con.Close();
            }
        }
    }
}