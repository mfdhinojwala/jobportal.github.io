using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace Job_Finder.Admin
{
    public partial class AdminIndex : System.Web.UI.Page
    {
        SqlConnection con;
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
                Users();
                AppliedJobs();
                Company();
                Jobs();
                ContactCount();
                NewslatterCount();
            }
        }

        private void NewslatterCount()
        {
            con = new SqlConnection(str);
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from [NLTable]", con);
            dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Session["NewslatterCount"] = dt.Rows[0][0];
            }
            else
            {
                Session["NewslatterCount"] = 0;
            }
        }

        private void ContactCount()
        {
            con = new SqlConnection(str);
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from [ContactTable]", con);
            dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Session["ContactCount"] = dt.Rows[0][0];
            }
            else
            {
                Session["ContactCount"] = 0;
            }
        }

        private void AppliedJobs()
        {
            con = new SqlConnection(str);
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from [AppliedJobsTable]", con);
            dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Session["AppliedJobs"] = dt.Rows[0][0];
            }
            else
            {
                Session["AppliedJobs"] = 0;
            }
        }
        private void Company()
        {
            con = new SqlConnection(str);
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from [JProviderTable]", con);
            dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Session["Company"] = dt.Rows[0][0];
            }
            else
            {
                Session["Company"] = 0;
            }
        }
        private void Jobs()
        {
            con = new SqlConnection(str);
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from [JobsTable]", con);
            dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Session["Jobs"] = dt.Rows[0][0];
            }
            else
            {
                Session["Jobs"] = 0;
            }
        }

        private void Users()
        {
            con = new SqlConnection(str);
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from [JFinderTable]", con);
            dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Session["Users"] = dt.Rows[0][0];
            }
            else
            {
                Session["Users"] = 0;
            }
        }
    }
}