using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Job_Finder.User
{
    public partial class ResumeBuild : System.Web.UI.Page
    {
        bool isVFile, isVPhoto;
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader sdr;
        string str = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["JFUser"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    ShowUserInfo();
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }

        private void ShowUserInfo()
        {
            try
            {
                con = new SqlConnection(str);
                String query = "Select * from [JFinderTable] where UserID=@UserID";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@UserID", Request.QueryString["id"]);
                con.Open();
                sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                {
                    if (sdr.Read())
                    {
                        txtUsername.Text = sdr["Username"].ToString();
                        txtFullname.Text = sdr["Name"].ToString();
                        txtAddress.Text = sdr["Address"].ToString();
                        txtMNumber.Text = sdr["MNumber"].ToString();
                        txtEmail.Text = sdr["Email"].ToString();
                        ddlCountry.SelectedValue = sdr["Country"].ToString();
                        txtTenth.Text = sdr["TenthGrade"].ToString();
                        txtTwelfth.Text = sdr["TwelfthGrade"].ToString();
                        txtGraduation.Text = sdr["GraduationGrade"].ToString();
                        txtPostGraduation.Text = sdr["PostGraduationGrade"].ToString();
                        txtPHD.Text = sdr["PHD"].ToString();
                        txtWork.Text = sdr["WorksOn"].ToString();
                        txtExperience.Text = sdr["Experience"].ToString();

                        if (string.IsNullOrEmpty(sdr["resume"].ToString()))
                        {
                            flb.Text = "File is not uploaded!";
                            flb.CssClass = "text-danger";
                        }
                        else
                        {
                            flb.Text = "File is already uploaded!";
                            flb.CssClass = "text-success";
                            RequiredFieldValidator2.Enabled = false;
                        }

                        if (string.IsNullOrEmpty(sdr["UserImg"].ToString()))
                        {
                            flb1.Text = "Photo is not uploaded!";
                            flb1.CssClass = "text-danger";
                        }
                        else
                        {
                            flb1.Text = "Photo is already uploaded!";
                            flb1.CssClass = "text-success";
                            RequiredFieldValidator3.Enabled = false;
                        }
                    }
                    else
                    {
                        ulb.Visible = true;
                        ulb.Text = "User not found!";
                        ulb.CssClass = "alert alert-Denger";

                        ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "script", "window.setTimeout(function() { document.getElementById('" + ulb.ClientID + "').style.display = 'none' },3000);", true);
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

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["id"] != null)
                {
                    String concatQuery = string.Empty, filepath = string.Empty, photopath = string.Empty;
                    bool isValid = false;
                    con = new SqlConnection(str);
                    if (fuResume.HasFile && fuUserImg.HasFile)
                    {
                        if (IsValidExtension(fuResume.FileName,fuUserImg.FileName))
                        {
                            concatQuery = ",Resume=@Resume,UserImg=@UserImg";
                            isValid = true;
                        }
                        else
                        {
                            if (isVFile == false)
                            {
                                //concatQuery = String.Empty;
                                ulb.Visible = true;
                                ulb.Text = "Please Select .doc, .docx, .pdf file for resume!";
                                ulb.CssClass = "alert alert-Denger";
                            }
                            else if (isVPhoto == false)
                            {
                                //concatQuery = String.Empty;
                                ulb.Visible = true;
                                ulb.Text = "Please Select .jpg, .jpeg, .png file for Profile Pic!";
                                ulb.CssClass = "alert alert-Denger";
                            }
                            else
                            {
                                //concatQuery = String.Empty;
                                ulb.Visible = true;
                                ulb.Text = "Please Select valid extention file for resume and profile pic!";
                                ulb.CssClass = "alert alert-Denger";
                            }

                            ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "script", "window.setTimeout(function() { document.getElementById('" + ulb.ClientID + "').style.display = 'none' },3000);", true);
                        }
                    }
                    else
                    {
                        concatQuery = "";
                    }

                    string query = @"Update JFinderTable set Username=@Username,Name=@Name,Address=@Address,MNumber=@MNumber,Email=@Email,Country=@Country,
                                    TenthGrade=@TenthGrade,TwelfthGrade=@TwelfthGrade,GraduationGrade=@GraduationGrade,PostGraduationGrade=@PostGraduationGrade,PHD=@PHD,WorksOn=@WorksOn,Experience=@Experience" + concatQuery + " where UserID=@UserID";
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());
                    cmd.Parameters.AddWithValue("@Name", txtFullname.Text.Trim());
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                    cmd.Parameters.AddWithValue("@MNumber", txtMNumber.Text.Trim());
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@Country", ddlCountry.SelectedValue);
                    cmd.Parameters.AddWithValue("@TenthGrade", txtTenth.Text.Trim() == string.Empty ? (Object)DBNull.Value : txtTenth.Text.Trim());
                    cmd.Parameters.AddWithValue("@TwelfthGrade", txtTwelfth.Text.Trim() == string.Empty ? (Object)DBNull.Value : txtTwelfth.Text.Trim());
                    cmd.Parameters.AddWithValue("@GraduationGrade", txtGraduation.Text.Trim() == string.Empty ? (Object)DBNull.Value : txtGraduation.Text.Trim());
                    cmd.Parameters.AddWithValue("@PostGraduationGrade", txtPostGraduation.Text.Trim() == string.Empty ? (Object)DBNull.Value : txtPostGraduation.Text.Trim());
                    cmd.Parameters.AddWithValue("@PHD", txtPHD.Text.Trim() == string.Empty ? (Object)DBNull.Value : txtPHD.Text.Trim());
                    cmd.Parameters.AddWithValue("@WorksOn", txtWork.Text.Trim() == string.Empty ? (Object)DBNull.Value : txtWork.Text.Trim());
                    cmd.Parameters.AddWithValue("@Experience", txtExperience.Text.Trim() == string.Empty ? (Object)DBNull.Value : txtExperience.Text.Trim());
                    //cmd.Parameters.AddWithValue("@Resume", fuResume.Text.Trim());
                    cmd.Parameters.AddWithValue("@UserID", Request.QueryString["id"].ToString());

                    if (isValid)
                    {
                        Guid obj = Guid.NewGuid();
                        filepath = "Resumes/" + obj.ToString() + fuResume.FileName;
                        fuResume.PostedFile.SaveAs(Server.MapPath("~/Resumes/") + obj.ToString() + fuResume.FileName);

                        cmd.Parameters.AddWithValue("@Resume", filepath);

                        photopath = "Images/" + obj.ToString() + fuUserImg.FileName;
                        fuUserImg.PostedFile.SaveAs(Server.MapPath("~/Images/") + obj.ToString() + fuUserImg.FileName);

                        cmd.Parameters.AddWithValue("@UserImg", photopath);
                    }
                    else
                    {
                        isValid = true;
                        //cmd.Parameters.AddWithValue("@Resume", (Object)DBNull.Value);
                    }

                    if (isValid)
                    {
                        con.Open();
                        int r = cmd.ExecuteNonQuery();

                        if (r > 0)
                        {
                            ulb.Visible = true;
                            ulb.Text = "Resume details updated successfull!";
                            ulb.CssClass = "alert alert-success";
                            
                            Session["JFUser"] = txtUsername.Text.Trim();

                            ShowUserInfo();
                            //txtUsername.Text = String.Empty;
                            //txtFullname.Text = String.Empty;
                            //txtAddress.Text = String.Empty;
                            //txtMNumber.Text = String.Empty;
                            //txtEmail.Text = String.Empty;
                            //ddlCountry.ClearSelection();
                            //txtTenth.Text = String.Empty;
                            //txtTwelfth.Text = String.Empty;
                            //txtGraduation.Text = String.Empty;
                            //txtPostGraduation.Text = String.Empty;
                            //txtPHD.Text = String.Empty;
                            //txtWork.Text = String.Empty;
                            //txtExperience.Text = String.Empty;

                            ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "script", "window.setTimeout(function() { document.getElementById('" + ulb.ClientID + "').style.display = 'none' },3000);", true);

                        }
                        else
                        {
                            ulb.Visible = true;
                            ulb.Text = "Cannot update the records, Plz try after sometime!";
                            ulb.CssClass = "alert alert-danger";

                            ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "script", "window.setTimeout(function() { document.getElementById('" + ulb.ClientID + "').style.display = 'none' },3000);", true);

                        }
                    }
                }
                else
                {
                    ulb.Visible = true;
                    ulb.Text = "Cannot update the records, Plz try <b>Relogin</b>!";
                    ulb.CssClass = "alert alert-danger";

                    ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "script", "window.setTimeout(function() { document.getElementById('" + ulb.ClientID + "').style.display = 'none' },3000);", true);
                }
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("Violation of UNIQUE KEY constraint"))
                {
                    ulb.Visible = true;
                    ulb.Text = "<b>" + txtUsername.Text.Trim() + "</b> username already exist, try new one...!";
                    ulb.CssClass = "alert alert-danger";

                    ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "script", "window.setTimeout(function() { document.getElementById('" + ulb.ClientID + "').style.display = 'none' },3000);", true);
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
        private bool IsValidExtension(string filename,string photoname)
        {
            bool isValid = false;
            isVFile = false;
            isVPhoto = false;
            string[] fileExtention = { ".doc", ".docx", ".pdf" };
            string[] photoExtention = { ".jpg", ".jpeg", ".png" };

            for (int i = 0; i <= fileExtention.Length - 1; i++)
            {
                if (filename.Contains(fileExtention[i]))
                {
                    isVFile = true;
                    break;
                }
            }
            for (int i = 0; i <= photoExtention.Length - 1; i++)
            {
                if (photoname.Contains(photoExtention[i]))
                {
                    isVPhoto = true;
                    break;
                }
            }

            if (isVFile && isVPhoto)
            {
                isValid = true;
            }
            return isValid;
        }
    }
}