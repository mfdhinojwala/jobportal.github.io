using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Job_Finder.User
{
    public partial class Job_Details : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        DataTable dt, dt1;
        SqlDataAdapter sda;
        SqlDataReader sdr;
        string str = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        public string jobTitle = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                ShowJob();
                DataBind();
            }
            else
            {
                Response.Redirect("Find_Job.aspx");
            }
        }

        private void ShowJob()
        {
            con = new SqlConnection(str);
            String query = @"Select * from JobsTable where JobID = @id";
            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", Request.QueryString["id"]);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            DataList1.DataSource = dt;
            DataList1.DataBind();
            jobTitle = dt.Rows[0]["JobTitle"].ToString();
        }

        protected string getImageUrl(object url)
        {
            string urlTemp = "";
            if (string.IsNullOrEmpty(url.ToString()) || url == DBNull.Value)
            {
                urlTemp = "~/Images/No-Logo.png";
            }
            else
            {
                urlTemp = string.Format("~/{0}", url);
            }
            return ResolveUrl(urlTemp);
        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "ApplyJob")
            {
                if (Session["JFUser"] != null)
                {

                    if (resumeCheck())
                    {
                        lblmsg.Visible = true;
                        lblmsg.Text = "Plz, first upload your resume!";
                        lblmsg.CssClass = "alert alert-danger";

                        ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "script", "window.setTimeout(function() { document.getElementById('" + lblmsg.ClientID + "').style.display = 'none' },3000);", true);
                    }
                    else
                    {
                        try
                        {
                            con = new SqlConnection(str);
                            String query = @"Insert into AppliedJobsTable values (@JobID, @UserID)";
                            cmd = new SqlCommand(query, con);
                            cmd.Parameters.AddWithValue("@JobID", Request.QueryString["id"]);
                            cmd.Parameters.AddWithValue("@UserID", Session["JFUserID"]);
                            con.Open();
                            int r = cmd.ExecuteNonQuery();

                            if (r > 0)
                            {
                                lblmsg.Visible = true;
                                lblmsg.Text = "Job applied successfull!";
                                lblmsg.CssClass = "alert alert-success";
                                ShowJob();

                                ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "script", "window.setTimeout(function() { document.getElementById('" + lblmsg.ClientID + "').style.display = 'none' },3000);", true);
                            }
                            else
                            {
                                lblmsg.Visible = true;
                                lblmsg.Text = "Cannot apply the job, Plz try after sometime...!";
                                lblmsg.CssClass = "alert alert-danger";

                                ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "script", "window.setTimeout(function() { document.getElementById('" + lblmsg.ClientID + "').style.display = 'none' },3000);", true);
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
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }

        public bool resumeCheck()
        {
            bool resumecheck = true;
            con = new SqlConnection(str);
            String query = "Select Resume from [JFinderTable] where UserID=@UserID";
            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@UserID", Session["JFUserID"]);
            con.Open();
            sdr = cmd.ExecuteReader();

            if (sdr.HasRows)
            {
                if (sdr.Read())
                {
                    if (string.IsNullOrEmpty(sdr["resume"].ToString()))
                    {
                        resumecheck = true;
                    }
                    else
                    {
                        resumecheck = false;
                    }
                }
            }
            else
            {
                resumecheck = true;
            }
            con.Close();
            return resumecheck;
        }

        protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (Session["JFUser"] != null)
            {
                LinkButton btnApplyJob = e.Item.FindControl("btnApplyJob") as LinkButton;
                if (isApplied())
                {
                    btnApplyJob.Enabled = false;
                    btnApplyJob.Text = "Applied";
                }
                else
                {
                    btnApplyJob.Enabled = true;
                    btnApplyJob.Text = "Apply Now";
                }
            }
            else if (Session["JPUser"] != null)
            {
                LinkButton btnApplyJob = e.Item.FindControl("btnApplyJob") as LinkButton;
                btnApplyJob.Visible = false;
            }
            else
            {
                LinkButton btnApplyJob = e.Item.FindControl("btnApplyJob") as LinkButton;
                btnApplyJob.Visible = true;
            }
        }
        bool isApplied()
        {
            con = new SqlConnection(str);
            String query = @"Select * from AppliedJobsTable where JobID = @jobID and UserID = @userID";
            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@jobID", Request.QueryString["id"]);
            cmd.Parameters.AddWithValue("@userID", Session["JFUserID"]);
            sda = new SqlDataAdapter(cmd);
            dt1 = new DataTable();
            sda.Fill(dt1);

            if (dt1.Rows.Count == 1)
            {
                con.Close();
                return true;
            }
            else
            {
                con.Close();
                return false;
            }
        }
    }
}