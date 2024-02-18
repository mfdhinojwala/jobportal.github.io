using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace Job_Finder.User
{
    public partial class UserIndex : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        DataTable dt;
        SqlDataAdapter sda;
        string str = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            Control fdiv = this.Master.FindControl("mc_embed_signup");
            fdiv.Visible = true;

            if (!IsPostBack)
            {
                try
                {
                    con = new SqlConnection(str);
                    String query = "Select LastDateToApply from JobsTable";
                    cmd = new SqlCommand(query, con);
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            if ((DateTime)sdr["LastDateToApply"] < DateTime.Today)
                            {
                                deleteLDTA(sdr["LastDateToApply"]);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
                finally
                {
                    con.Close();
                    ShowLatestJob();
                }
            }

            if (Session["JFUser"] != null)
            {
                uycv.Visible = true;
                btnPaj.Visible = false;
            }
            else if (Session["JPUser"] != null)
            {
                uycv.Visible = false;
                btnPaj.Visible = true;
                btnPaj.Attributes["href"] = "Post_Job.aspx";
            }
            else
            {
                uycv.Visible = true;
                btnPaj.Visible = true;
                btnPaj.Attributes["href"] = "Login.aspx";
            }

                
        }
        private void deleteLDTA(Object ldta)
        {
            con = new SqlConnection(str);
            cmd = new SqlCommand("Delete from JobsTable where LastDateToApply = @ldta", con);
            //cmd = new SqlCommand("Delete job from JobsTable job Inner Join AppliedJobsTable jbid On jbid.JobID = job.JobID where job.LastDateToApply = @ldta", con);
            cmd.Parameters.AddWithValue("@ldta", ldta);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void ShowLatestJob()
        {
            
            con = new SqlConnection(str);
            String query = string.Empty;
            if (Session["JPUser"] != null)
            {
                query = "Select TOP (2) JobID,JobTitle,Salary,JobType,CompanyName,CompanyLogo,Country,State,CreateDate from JobsTable where CompanyName = '" + Session["JPUser"] + "' order by JobID DESC";
            }
            else
            {
                query = "Select TOP (2) JobID,JobTitle,Salary,JobType,CompanyName,CompanyLogo,Country,State,CreateDate from JobsTable order by JobID DESC";
            }
            
            cmd = new SqlCommand(query, con);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);

            DataList1.DataSource = dt;
            DataList1.DataBind();
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

        public static string relativeDate(DateTime theDate)
        {
            Dictionary<long, string> thresholds = new Dictionary<long, string>();
            int min = 60;
            int hour = 60 * min;
            int day = 24 * hour;
            thresholds.Add(60, "{0} seconds ago");
            thresholds.Add(min * 2, "1 minute ago");
            thresholds.Add(min * 45, "{0} minutes ago");
            thresholds.Add(min * 120, "1 hour ago");
            thresholds.Add(day, "{0} hours ago");
            thresholds.Add(day * 2, "yesterday");
            thresholds.Add(day * 30, "{0} days ago");
            thresholds.Add(day * 365, "{0} months ago");
            thresholds.Add(long.MaxValue, "{0} years ago");
            long since = (DateTime.Now.Ticks - theDate.Ticks) / 10000000;

            foreach (long threshold in thresholds.Keys)
            {
                if (since < threshold)
                {
                    TimeSpan t = new TimeSpan((DateTime.Now.Ticks - theDate.Ticks));
                    //return string.Format(thresholds[threshold], (t.Days > 365 ? t.Days / 365 : (t.Days > 0 ? t.Days : (t.Hours > 0 ? t.Hours : (t.Minutes > 0 ? t.Minutes : (t.Seconds > 0 ? t.Seconds : 0))))).ToString());
                    return string.Format(thresholds[threshold], (t.Days > 365 ? t.Days / 365 : (t.Days > 30 ? t.Days / 30 : (t.Days > 0 ? t.Days : (t.Hours > 0 ? t.Hours : (t.Minutes > 0 ? t.Minutes : (t.Seconds > 0 ? t.Seconds : 0)))))).ToString());
                }
            }
            return "";
        }

        //protected void btnPaj_Click(object sender, EventArgs e)
        //{
        //    if (Session["JPUser"] != null)
        //    {
        //        Response.Redirect("Post_Job.aspx");
        //    }
        //    else
        //    {
        //        Response.Redirect("Login.aspx");
        //    }
        //}
    }
}