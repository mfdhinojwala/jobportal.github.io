using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Job_Finder.User
{
    public partial class Posted_Jobs : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        DataTable dt;
        string str = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (Session["JPUser"] == null)
            {
                Response.Redirect("../User/Login.aspx");
            }

            if (!IsPostBack)
            {
                ShowJob();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ShowJob();
        }

        private void ShowJob()
        {
            String query = String.Empty;
            con = new SqlConnection(str);
            query = @"Select Row_Number() over(Order by (Select 1)) as [Sr.No], 
                    JobID, JobTitle, NoOfPost, Qualification, Experience, Specification, LastDateToApply, Salary, JobType, CreateDate from JobsTable where CompanyName = '" + Session["JPUser"] + "'";
            cmd = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            ShowJob();
            lblMsg.Visible = false;
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                GridViewRow row = GridView1.Rows[e.RowIndex];
                int jobid = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
                con = new SqlConnection(str);
                cmd = new SqlCommand("Delete from JobsTable where JobID = @id", con);
                //cmd = new SqlCommand("Delete job from JobsTable job Inner Join AppliedJobsTable jbid On jbid.JobID = job.JobID where job.JobID = @id", con);
                cmd.Parameters.AddWithValue("@id", jobid);
                con.Open();
                int r = cmd.ExecuteNonQuery();

                if (r > 0)
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Job delete successfully!";
                    lblMsg.CssClass = "alert alert-success";

                    ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "script", "window.setTimeout(function() { document.getElementById('" + lblMsg.ClientID + "').style.display = 'none' },3000);", true);

                }
                else
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Cannot delete this record!";
                    lblMsg.CssClass = "alert alert-danger";

                    ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "script", "window.setTimeout(function() { document.getElementById('" + lblMsg.ClientID + "').style.display = 'none' },3000);", true);

                }
                GridView1.EditIndex = -1;
                ShowJob();
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

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditJob")
            {
                Response.Redirect("Post_Job.aspx?id=" + e.CommandArgument.ToString());
            }
        }

        //protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        e.Row.ID = e.Row.RowIndex.ToString();
        //        if (Request.QueryString["id"] != null)
        //        {
        //            int JobId = Convert.ToInt32(GridView1.DataKeys[e.Row.RowIndex].Values[0]);
        //            if (JobId == Convert.ToInt32(Request.QueryString["id"]))
        //            {
        //                e.Row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
        //                btnBack.Visible = true;
        //            }
        //        }
        //    }
        //}
    }
}