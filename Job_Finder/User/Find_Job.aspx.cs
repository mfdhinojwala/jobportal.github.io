using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Job_Finder.User
{
    public partial class Find_Job : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        DataTable dt;
        SqlDataAdapter sda;
        string str = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        public int jobCount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowJob();
            }
        }

        private void ShowJob()
        {
            if (dt == null)
            {
                con = new SqlConnection(str);
                String query = "Select JobID,JobTitle,Salary,JobType,CompanyName,CompanyLogo,Country,State,CreateDate from JobsTable";
                cmd = new SqlCommand(query, con);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);
            }

            DataList1.DataSource = dt;
            DataList1.DataBind();
            lbljobCount.Text = JobCount(dt.Rows.Count);
        }

        private string JobCount(int count)
        {
            if (count > 1)
            {
                return "<b>" + count + "</b> jobs found.";
            }
            else if (count == 1)
            {
                return "<b>" + count + "</b> job found.";
            }
            else
            {
                return "No job found.";
            }
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
            
            foreach(long threshold in thresholds.Keys)
            {
                if(since < threshold)
                {
                    TimeSpan t = new TimeSpan((DateTime.Now.Ticks - theDate.Ticks));
                    //return string.Format(thresholds[threshold], (t.Days > 365 ? t.Days / 365 : (t.Days > 0 ? t.Days : (t.Hours > 0 ? t.Hours : (t.Minutes > 0 ? t.Minutes : (t.Seconds > 0 ? t.Seconds : 0))))).ToString());
                    return string.Format(thresholds[threshold], (t.Days > 365 ? t.Days / 365 : (t.Days > 30 ? t.Days / 30 : (t.Days > 0 ? t.Days : (t.Hours > 0 ? t.Hours : (t.Minutes > 0 ? t.Minutes : (t.Seconds > 0 ? t.Seconds : 0)))))).ToString());
                }
            }
            return "";
        }

        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (ddlCountry.SelectedValue != "0")
            {
                con = new SqlConnection(str);
                String query = "Select JobID,JobTitle,Salary,JobType,CompanyName,CompanyLogo,Country,State,CreateDate from JobsTable where Country ='" + ddlCountry.SelectedValue + "'";
                cmd = new SqlCommand(query, con);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);
                ShowJob();
            }
            else
            {
                ShowJob();
            }
        }

        protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string jobType = string.Empty;
            jobType = selectedCheckBox1();

            if (jobType != "")
            {
                con = new SqlConnection(str);
                String query = "Select JobID,JobTitle,Salary,JobType,CompanyName,CompanyLogo,Country,State,CreateDate from JobsTable where JobType IN (" + jobType + ")";
                cmd = new SqlCommand(query, con);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);
                ShowJob();
            }
            else
            {
                ShowJob();
            }
        }

        string selectedCheckBox1()
        {
            string jobType = string.Empty;
            for (int i=0; i<CheckBoxList1.Items.Count; i++)
            {
                if (CheckBoxList1.Items[i].Selected)
                {
                    jobType += "'" + CheckBoxList1.Items[i].Text + "',";
                }
            }
            return jobType = jobType.TrimEnd(',');
        }

        protected void CheckBoxList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CheckBoxList2.SelectedIndex == -1)
            {
                CheckBoxList2.Items[0].Selected = true;
            }
            if (CheckBoxList2.SelectedValue != "0")
            {
                string postedDate = string.Empty;
                postedDate = selectedCheckBox2();

                con = new SqlConnection(str);
                String query = "Select JobID,JobTitle,Salary,JobType,CompanyName,CompanyLogo,Country,State,CreateDate from JobsTable where Convert(Date,CreateDate) " + postedDate + " ";
                cmd = new SqlCommand(query, con);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);
                ShowJob();
            }
            else
            {
                ShowJob();
            }
        }

        string selectedCheckBox2()
        {

            string postedDate = string.Empty;
            DateTime date = DateTime.Today;

            if (CheckBoxList2.SelectedValue == "1")
            {
                postedDate = "= Convert(DATE,'" + date.ToString("yyyy/MM/dd") + "')";
            }
            else if(CheckBoxList2.SelectedValue == "2")
            {
                postedDate = " between Convert(DATE,'" + DateTime.Now.AddDays(-2).ToString("yyyy/MM/dd") + "') and Convert(DATE,'" + date.ToString("yyyy/MM/dd") + "')";
            }
            else if (CheckBoxList2.SelectedValue == "3")
            {
                postedDate = " between Convert(DATE,'" + DateTime.Now.AddDays(-3).ToString("yyyy/MM/dd") + "') and Convert(DATE,'" + date.ToString("yyyy/MM/dd") + "')";
            }
            else if (CheckBoxList2.SelectedValue == "4")
            {
                postedDate = " between Convert(DATE,'" + DateTime.Now.AddDays(-5).ToString("yyyy/MM/dd") + "') and Convert(DATE,'" + date.ToString("yyyy/MM/dd") + "')";
            }
            else
            {
                postedDate = " between Convert(DATE,'" + DateTime.Now.AddDays(-10).ToString("yyyy/MM/dd") + "') and Convert(DATE,'" + date.ToString("yyyy/MM/dd") + "')";
            }
            return postedDate;
        }

        protected void btnAFilter_Click(object sender, EventArgs e)
        {
            try
            {
                bool isCandition = false;
                string subQuery = string.Empty;
                string jobType = string.Empty;
                string postedDate = string.Empty;
                string addAnd = string.Empty;
                string query = string.Empty;
                List<string> queryList = new List<string>();
                con = new SqlConnection(str);

                if (ddlCountry.SelectedValue != "0")
                {
                    queryList.Add(" Country = '" + ddlCountry.SelectedValue + "' ");
                    isCandition = true;
                }

                jobType = selectedCheckBox1();
                if (jobType != "")
                {
                    queryList.Add(" JobType IN (" + jobType + ") ");
                    isCandition = true;
                }

                if (CheckBoxList2.SelectedValue != "0")
                {
                    postedDate = selectedCheckBox2();
                    queryList.Add(" Convert(Date,CreateDate) " + postedDate);
                    isCandition = true;
                }

                if (isCandition)
                {
                    foreach(string s in queryList)
                    {
                        subQuery += s + " and ";
                    }
                    subQuery = subQuery.Remove(subQuery.LastIndexOf("and"), 3);
                    query = @"Select JobID,JobTitle,Salary,JobType,CompanyName,CompanyLogo,Country,State,CreateDate from JobsTable where " + subQuery + " ";
                }
                else
                {
                    query = @"Select JobID,JobTitle,Salary,JobType,CompanyName,CompanyLogo,Country,State,CreateDate from JobsTable";
                }
                sda = new SqlDataAdapter(query, con);
                dt = new DataTable();
                sda.Fill(dt);
                ShowJob();
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

        protected void btnReset_Click(object sender, EventArgs e)
        {
            ddlCountry.ClearSelection();
            CheckBoxList1.ClearSelection();
            CheckBoxList2.ClearSelection();
            CheckBoxList2.Items[0].Selected = true;
            ShowJob();
        }
    }
}