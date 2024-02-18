﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Job_Finder.Admin
{
    public partial class CompanyList : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        DataTable dt;
        string str = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Admin"] == null)
            {
                Response.Redirect("../User/Login.aspx");
            }

            if (!IsPostBack)
            {
                ShowPUsers();
            }
        }

        private void ShowPUsers()
        {
            String query = String.Empty;
            con = new SqlConnection(str);
            query = @"Select Row_Number() over(Order by (Select 1)) as [Sr.No], * from [JProviderTable]";
            cmd = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            con.Close();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            ShowPUsers();
            lblMsg.Visible = false;
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                GridViewRow row = GridView1.Rows[e.RowIndex];
                int companyId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
                con = new SqlConnection(str);
                cmd = new SqlCommand("Delete from JProviderTable where CompanyID = @id", con);
                cmd.Parameters.AddWithValue("@id", companyId);
                con.Open();
                int r = cmd.ExecuteNonQuery();

                if (r > 0)
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "User delete successfully!";
                    lblMsg.CssClass = "alert alert-success";

                    ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "script", "window.setTimeout(function() { document.getElementById('" + lblMsg.ClientID + "').style.display = 'none' },3000);", true);

                }
                else
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Cannot delete this record!";
                    lblMsg.CssClass = "alert alert-denger";

                    ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "script", "window.setTimeout(function() { document.getElementById('" + lblMsg.ClientID + "').style.display = 'none' },3000);", true);

                }
                GridView1.EditIndex = -1;
                ShowPUsers();
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