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
    public partial class Profile_JProvider : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
        string str = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["JPUser"] == null)
            {
                Response.Redirect("../User/Login.aspx");
            }

            if (!IsPostBack)
            {
                ShowPUserProfile();
            }
        }

        private void ShowPUserProfile()
        {
            con = new SqlConnection(str);
            String query = "Select CompanyID,CompanyName,Website,Email,Address,State,Country,CompanyLogo from [JProviderTable] where CompanyName=@ComapnyName";
            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@ComapnyName", Session["JPUser"]);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            DataList1.DataSource = dt;
            DataList1.DataBind();
            con.Close();
        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "EditUserProfile")
            {
                Response.Redirect("Register_JProvider.aspx?id=" + e.CommandArgument.ToString());
            }
        }
    }
}