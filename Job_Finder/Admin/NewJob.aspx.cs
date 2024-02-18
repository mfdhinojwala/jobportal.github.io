using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Job_Finder.Admin
{
    public partial class NewJob : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        string str = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Admin"] == null)
            {
                Response.Redirect("../User/Login.aspx");
            }
            Session["title"] = "Add Job";
            if (!IsPostBack)
            {
                fiilData();
            }
        }

        private void fiilData()
        {
            if (Request.QueryString["id"] != null)
            {
                con = new SqlConnection(str);
                String query = "Select * from JobsTable where JobID = '"+ Request.QueryString["id"] + "' ";
                cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                {
                    while(sdr.Read())
                    {
                        txtJobTitle.Text = sdr["JobTitle"].ToString();
                        txtNoOfPost.Text = sdr["NoOfPost"].ToString();
                        txtDescription.Text = sdr["Description"].ToString();
                        txtQualification.Text = sdr["Qualification"].ToString();
                        txtExperience.Text = sdr["Experience"].ToString();
                        txtSpecialization.Text = sdr["Specification"].ToString();
                        txtLastDate.Text = Convert.ToDateTime( sdr["LastDateToApply"]).ToString("yyyy-MM-dd");
                        txtSalary.Text = sdr["Salary"].ToString();
                        ddlJobType.SelectedValue = sdr["JobType"].ToString();
                        txtCompany.Text = sdr["CompanyName"].ToString();
                        //txtJobTitle.Text = sdr["Title"].ToString();
                        txtWebsite.Text = sdr["Website"].ToString();
                        txtEmail.Text = sdr["Email"].ToString();
                        txtAddress.Text = sdr["Address"].ToString();
                        ddlCountry.SelectedValue = sdr["Country"].ToString();
                        txtState.Text = sdr["State"].ToString();
                        jBtnAdd.Text = "Update";
                        btnBack.Visible = true;
                        Session["title"] = "Edit Job";

                        flb.Text = "Company logo is already uploaded!";
                        flb.CssClass = "text-success";
                        RequiredFieldValidator3.Enabled = false;
                    }
                }
                else
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Job not found...!";
                    lblMsg.CssClass = "alert alert-denger";
                }
                sdr.Close();
                con.Close();
            }
        }

        protected void jBtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string type, concatQuery, imagePath = string.Empty;
                bool isValidToExecutr = false;
                con = new SqlConnection(str);

                if (Request.QueryString["id"] != null)
                {
                    if (fuCompanyLogo.HasFile)
                    {
                        if (IsValidExtension(fuCompanyLogo.FileName))
                        {
                            concatQuery = "CompanyLogo = @CompanyLogo,";
                        }
                        else
                        {
                            concatQuery = String.Empty;
                        }
                    }
                    else
                    {
                        concatQuery = "";
                    }
                    string query = @"Update JobsTable set JobTitle=@JobTitle,NoOfPost=@NoOfPost,Description=@Description,Qualification=@Qualification,Experience=@Experience,Specification=@Specification,LastDateToApply=@LastDateToApply,Salary=@Salary,JobType=@JobType,CompanyName=@CompanyName," + concatQuery + "Website=@Website,Email=@Email,Address=@Address,Country=@Country,State=@State where JobID=@id";
                    type = "updated";
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@JobTitle", txtJobTitle.Text.Trim());
                    cmd.Parameters.AddWithValue("@NoOfPost", txtNoOfPost.Text.Trim());
                    cmd.Parameters.AddWithValue("@Description", txtDescription.Text.Trim());
                    cmd.Parameters.AddWithValue("@Qualification", txtQualification.Text.Trim());
                    cmd.Parameters.AddWithValue("@Experience", txtExperience.Text.Trim());
                    cmd.Parameters.AddWithValue("@Specification", txtSpecialization.Text.Trim());
                    cmd.Parameters.AddWithValue("@LastDateToApply", txtLastDate.Text.Trim());
                    cmd.Parameters.AddWithValue("@Salary", txtSalary.Text.Trim());
                    cmd.Parameters.AddWithValue("@JobType", ddlJobType.SelectedValue);
                    cmd.Parameters.AddWithValue("@CompanyName", txtCompany.Text.Trim());
                    //cmd.Parameters.AddWithValue("@CompanyLogo", fuCompanyLogo.Text.Trim());
                    cmd.Parameters.AddWithValue("@Website", txtWebsite.Text.Trim());
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                    cmd.Parameters.AddWithValue("@Country", ddlCountry.SelectedValue);
                    cmd.Parameters.AddWithValue("@State", txtState.Text.Trim());
                    cmd.Parameters.AddWithValue("@id", Request.QueryString["id"].ToString());

                    if (fuCompanyLogo.HasFile)
                    {
                        if (IsValidExtension(fuCompanyLogo.FileName))
                        {
                            Guid obj = Guid.NewGuid();
                            imagePath = "Images/" + obj.ToString() + fuCompanyLogo.FileName;
                            fuCompanyLogo.PostedFile.SaveAs(Server.MapPath("~/Images/") + obj.ToString() + fuCompanyLogo.FileName);

                            cmd.Parameters.AddWithValue("@CompanyLogo", imagePath);
                            isValidToExecutr = true;
                        }
                        else
                        {
                            lblMsg.Text = "Please select .jpg, .jpeg, .png file for logo";
                            lblMsg.CssClass = "alert alert-danger";
                        }
                    }
                    else
                    {
                        isValidToExecutr = true;
                    }
                }
                else
                {
                    string query = @"Insert into JobsTable values (@JobTitle,@NoOfPost,@Description,@Qualification,@Experience,@Specification,@LastDateToApply,@Salary,@JobType,@CompanyName,@CompanyLogo,@Website,@Email,@Address,@Country,@State,@CreateDate)";
                    type = "saved";
                    DateTime dt = DateTime.Now;
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@JobTitle", txtJobTitle.Text.Trim());
                    cmd.Parameters.AddWithValue("@NoOfPost", txtNoOfPost.Text.Trim());
                    cmd.Parameters.AddWithValue("@Description", txtDescription.Text.Trim());
                    cmd.Parameters.AddWithValue("@Qualification", txtQualification.Text.Trim());
                    cmd.Parameters.AddWithValue("@Experience", txtExperience.Text.Trim());
                    cmd.Parameters.AddWithValue("@Specification", txtSpecialization.Text.Trim());
                    cmd.Parameters.AddWithValue("@LastDateToApply", txtLastDate.Text.Trim());
                    cmd.Parameters.AddWithValue("@Salary", txtSalary.Text.Trim());
                    cmd.Parameters.AddWithValue("@JobType", ddlJobType.SelectedValue);
                    cmd.Parameters.AddWithValue("@CompanyName", txtCompany.Text.Trim());
                    //cmd.Parameters.AddWithValue("@CompanyLogo", fuCompanyLogo.Text.Trim());
                    cmd.Parameters.AddWithValue("@Website", txtWebsite.Text.Trim());
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                    cmd.Parameters.AddWithValue("@Country", ddlCountry.SelectedValue);
                    cmd.Parameters.AddWithValue("@State", txtState.Text.Trim());
                    cmd.Parameters.AddWithValue("@CreateDate", dt.ToString("yyyy-MM-dd HH:mm:ss"));

                    if (fuCompanyLogo.HasFile)
                    {
                        if (IsValidExtension(fuCompanyLogo.FileName))
                        {
                            Guid obj = Guid.NewGuid();
                            imagePath = "Images/" + obj.ToString() + fuCompanyLogo.FileName;
                            fuCompanyLogo.PostedFile.SaveAs(Server.MapPath("~/Images/") + obj.ToString() + fuCompanyLogo.FileName);

                            cmd.Parameters.AddWithValue("@CompanyLogo", imagePath);
                            isValidToExecutr = true;
                        }
                        else
                        {
                            lblMsg.Text = "Please select .jpg, .jpeg, .png file for logo";
                            lblMsg.CssClass = "alert alert-danger";
                        }
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@CompanyLogo", imagePath);
                        isValidToExecutr = true;
                    }
                }

                if (isValidToExecutr)
                {
                    con.Open();
                    int r = cmd.ExecuteNonQuery();

                    if (r > 0)
                    {
                        lblMsg.Visible = true;
                        lblMsg.Text = "Job " + type + " Successfull!";
                        lblMsg.CssClass = "alert alert-success";

                        txtJobTitle.Text = String.Empty;
                        txtNoOfPost.Text = String.Empty;
                        txtDescription.Text = String.Empty;
                        txtQualification.Text = String.Empty;
                        txtExperience.Text = String.Empty;
                        txtSpecialization.Text = String.Empty;
                        txtLastDate.Text = String.Empty;
                        txtSalary.Text = String.Empty;
                        ddlJobType.ClearSelection();
                        txtCompany.Text = String.Empty;
                        flb.Visible = false;
                        //fuCompanyLogo.Text = String.Empty;
                        txtWebsite.Text = String.Empty;
                        txtEmail.Text = String.Empty;
                        txtAddress.Text = String.Empty;
                        ddlCountry.ClearSelection();
                        txtState.Text = String.Empty;

                        ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "script", "window.setTimeout(function() { document.getElementById('" + lblMsg.ClientID + "').style.display = 'none' },3000);", true);

                    }
                    else
                    {
                        lblMsg.Visible = true;
                        lblMsg.Text = "Cannot " + type + " record right now, Plz try after sometime!";
                        lblMsg.CssClass = "alert alert-danger";

                        ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "script", "window.setTimeout(function() { document.getElementById('" + lblMsg.ClientID + "').style.display = 'none' },3000);", true);

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
            }
        }

        private bool IsValidExtension(string filename)
        {
            bool isValid = false;
            string[] fileExtention = {".jpg", ".png", ".jpeg"};

            for (int i = 0; i<=fileExtention.Length - 1; i++)
            {
                if (filename.Contains(fileExtention[i]))
                {
                    isValid = true;
                    break;
                }
            }
            return isValid;
        }
    }
}