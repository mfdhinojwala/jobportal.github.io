using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Job_Finder.User
{
    public partial class Register_JProvider : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        string str = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["titleru"] = "Register as a Company/Organization";

            arch.Visible = true;
            nuch.Visible = true;

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
                String query = "Select * from JProviderTable where CompanyID = '" + Request.QueryString["id"] + "' ";
                cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        txtCompany.Text = sdr["CompanyName"].ToString();
                        txtPassword.Attributes["value"] = sdr["Password"].ToString();
                        txtCPassword.Attributes["value"] = sdr["Password"].ToString();
                        txtWebsite.Text = sdr["Website"].ToString();
                        txtEmail.Text = sdr["Email"].ToString();
                        txtAddress.Text = sdr["Address"].ToString();
                        txtState.Text = sdr["State"].ToString();
                        ddlCountry.SelectedValue = sdr["Country"].ToString();

                        rBtnRegister.Text = "Update";
                        Session["titleru"] = "Update profile of company";

                        arch.Visible = false;
                        nuch.Visible = false;

                        flb.Visible = true;
                        flb.Text = sdr["CompanyLogo"].ToString();
                        flb.CssClass = "text-success";
                        RequiredFieldValidator1.Enabled = false;
                    }
                }
                else
                {
                    rlb.Visible = true;
                    rlb.Text = "Job not found...!";
                    rlb.CssClass = "alert alert-denger";
                }
                sdr.Close();
                con.Close();
            }
        }

        protected void rBtnRegister_Click(object sender, EventArgs e)
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

                    string query = @"Update JProviderTable set CompanyName=@CompanyName,Password=@Password,Website=@Website,Email=@Email," + concatQuery + "Address=@Address,State=@State,Country=@Country where CompanyID=@id;" 
                        + "Update JobsTable set CompanyName=@CompanyName,Website=@Website,Email=@Email," + concatQuery + "Address=@Address,State=@State,Country=@Country where CompanyName= '" + Session["JPUser"] + "'";
                    type = "Update record";
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@CompanyName", txtCompany.Text.Trim());
                    cmd.Parameters.AddWithValue("@Password", txtCPassword.Text.Trim());
                    cmd.Parameters.AddWithValue("@Website", txtWebsite.Text.Trim());
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                    cmd.Parameters.AddWithValue("@State", txtState.Text.Trim());
                    cmd.Parameters.AddWithValue("@Country", ddlCountry.SelectedValue);
                    cmd.Parameters.AddWithValue("@id", Request.QueryString["id"].ToString());
                    Session["JPUser"] = txtCompany.Text.Trim();

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
                            rlb.Text = "Please select .jpg, .jpeg, .png file for logo";
                            rlb.CssClass = "alert alert-danger";
                        }
                    }
                    else
                    {
                        isValidToExecutr = true;
                    }
                }
                else
                {
                    string query = @"Insert into [JProviderTable] (CompanyName,Password,Website,Email,CompanyLogo,Address,State,Country) values (@CompanyName,@Password,@Website,@Email,@CompanyLogo,@Address,@State,@Country)";
                    type = "Register";
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@CompanyName", txtCompany.Text.Trim());
                    cmd.Parameters.AddWithValue("@Password", txtCPassword.Text.Trim());
                    cmd.Parameters.AddWithValue("@Website", txtWebsite.Text.Trim());
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                    cmd.Parameters.AddWithValue("@State", txtState.Text.Trim());
                    cmd.Parameters.AddWithValue("@Country", ddlCountry.SelectedValue);

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
                            rlb.Text = "Please select .jpg, .jpeg, .png file for logo";
                            rlb.CssClass = "alert alert-danger";
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
                        rlb.Visible = true;
                        rlb.Text = type + " successfull!";
                        rlb.CssClass = "alert alert-success";

                        txtCompany.Text = String.Empty;
                        txtPassword.Attributes["value"] = String.Empty;
                        txtCPassword.Attributes["value"] = String.Empty;
                        txtWebsite.Text = String.Empty;
                        txtEmail.Text = String.Empty;
                        txtAddress.Text = String.Empty;
                        txtState.Text = String.Empty;
                        ddlCountry.ClearSelection();

                        flb.Visible = false;

                        ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "script", "window.setTimeout(function() { document.getElementById('" + rlb.ClientID + "').style.display = 'none' },3000);", true);
                    }
                    else
                    {
                        rlb.Visible = true;
                        rlb.Text = "Cannot " + type + " right now, Plz try after sometime!";
                        rlb.CssClass = "alert alert-danger";

                        ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "script", "window.setTimeout(function() { document.getElementById('" + rlb.ClientID + "').style.display = 'none' },3000);", true);
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("Violation of UNIQUE KEY constraint"))
                {
                    rlb.Visible = true;
                    rlb.Text = "<b>" + txtCompany.Text.Trim() + "</b> Company/Organization already exist, try new one...!";
                    rlb.CssClass = "alert alert-danger";

                    ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "script", "window.setTimeout(function() { document.getElementById('" + rlb.ClientID + "').style.display = 'none' },3000);", true);
                }
                else
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
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
            string[] fileExtention = { ".jpg", ".png", ".jpeg" };

            for (int i = 0; i <= fileExtention.Length - 1; i++)
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