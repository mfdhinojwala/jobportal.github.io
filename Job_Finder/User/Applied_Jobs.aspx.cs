using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;
using System.Windows.Forms;

namespace Job_Finder.User
{
    public partial class Applied_Jobs : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        DataTable dt;
        string str = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["JFUser"] == null && Session["JPUser"] == null)
            {
                Response.Redirect("../User/Login.aspx");
            }

            if (Session["JPUser"] != null)
            {
                GridView1.Columns[1].Visible = false;
                GridView1.Columns[5].Visible = true;
                GridView1.Columns[10].Visible = true;
                GridView1.Columns[6].HeaderText = "Name";
                GridView1.Columns[7].HeaderText = "Email";
                GridView1.Columns[8].HeaderText = "Mobile No.";
                GridView1.Columns[9].HeaderText = "Resume";
                uaj.Visible = false;
                caj.Visible = true;
            }
            else if (Session["JFUser"] != null)
            {
                GridView1.Columns[1].Visible = true;
                GridView1.Columns[5].Visible = false;
                GridView1.Columns[10].Visible = false;
                GridView1.Columns[6].HeaderText = "Your Name";
                GridView1.Columns[7].HeaderText = "Your Email";
                GridView1.Columns[8].HeaderText = "Your Mobile No.";
                GridView1.Columns[9].HeaderText = "Your Resume";
                uaj.Visible = true;
                caj.Visible = false;
            }
            else
            {
                GridView1.Columns[9].Visible = false;
                uaj.Visible = true;
                caj.Visible = false;
            }

            if (!IsPostBack)
            {
                ShowAppliedJob();
            }
        }

        private void ShowAppliedJob()
        {
            String query = String.Empty;
            con = new SqlConnection(str);
            if (Session["JFUser"] != null)
            {
                query = @"Select Row_Number() over(Order by (Select 1)) as [Sr.No],
                        aj.AppliedJobID,j.CompanyName,j.JobTitle,j.Salary,j.JobType,jf.MNumber,jf.Name,jf.Email,jf.Resume 
                        from AppliedJobsTable aj
                        inner join JFinderTable jf on aj.UserID = jf.UserID
                        inner join JobsTable j on aj.JobID = j.JobID where aj.UserID = " + Session["JFUserID"];
            }
            else if (Session["JPUser"] != null)
            {
                query = @"Select Row_Number() over(Order by (Select 1)) as [Sr.No],
                        aj.AppliedJobID,j.JobTitle,j.Salary,j.JobType,j.NoOfPost,jf.MNumber,jf.Name,jf.Email,jf.Resume 
                        from AppliedJobsTable aj
                        inner join JFinderTable jf on aj.UserID = jf.UserID
                        inner join JobsTable j on aj.JobID = j.JobID where j.CompanyName = '" + Session["JPUser"] + "'";
            }
            
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
            ShowAppliedJob();
            lblMsg.Visible = false;
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you reject the applied job?", "Alert", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    GridViewRow row = GridView1.Rows[e.RowIndex];
                    int appliedJobID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
                    con = new SqlConnection(str);
                    cmd = new SqlCommand("Delete from AppliedJobsTable where AppliedJobID = @id", con);
                    cmd.Parameters.AddWithValue("@id", appliedJobID);
                    con.Open();
                    int r = cmd.ExecuteNonQuery();


                    if (r > 0)
                    {
                        lblMsg.Visible = true;
                        lblMsg.Text = "Applied job reject successfully!";
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
                    ShowAppliedJob();
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
            else if (dialogResult == DialogResult.No)
            {
                lblMsg.Visible = true;
                lblMsg.Text = "You cannot take any action!";
                lblMsg.CssClass = "alert alert-danger";

                ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "script", "window.setTimeout(function() { document.getElementById('" + lblMsg.ClientID + "').style.display = 'none' },3000);", true);

            }

        }
        
    }
}