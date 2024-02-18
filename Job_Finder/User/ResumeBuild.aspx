<%@ Page Title="" Language="C#" MasterPageFile="~/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="ResumeBuild.aspx.cs" Inherits="Job_Finder.User.ResumeBuild" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <main>
        <div class="container pt-50 pb-40">
            <div class="row">
                <div class="col-12 section-tittle text-center">
                    <h2>Build Resume</h2>
                </div>
                <div class="col mx-auto">
                    <div class="form-contact contact_form border-top rounded-top pt-10">
                        <div class="row">
                            <div class="col">
                                <div class="col-12 border-bottom border-left rounded-bottom mb-5">
                                    <h5 class="text-center">Personal Information</h5>
                                </div>

                                <div class="col-12">
                                    <div class="form-group">
                                        <label>Your Img</label>
                                        <asp:FileUpload ID="fuUserImg" runat="server" CssClass="form-control" ToolTip=".jpg, .jpeg, .png extension only"></asp:FileUpload>
                                        <asp:Label ID="flb1" runat="server"></asp:Label>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please Select img for profile!"
                                            ControlToValidate="fuUserImg"
                                            ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small"></asp:RequiredFieldValidator>
                                    </div>
                                </div>

                                <div class="col-12">
                                    <div class="form-group">
                                        <label>User Name</label>
                                        <asp:TextBox ID="txtUsername" CssClass="form-control" runat="server" placeholder="Enter Unique Username" required="true"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-12">
                                    <div class="form-group">
                                        <label>Full Name</label>
                                        <asp:TextBox ID="txtFullname" CssClass="form-control" runat="server" placeholder="Enter Full Name" required="true"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Name must be in characters"
                                            ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small" ValidationExpression="^[a-zA-Z\s]+$" ControlToValidate="txtFullname"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                <div class="col-12">
                                    <div class="form-group">
                                        <label>Address</label>
                                        <asp:TextBox ID="txtAddress" CssClass="form-control" runat="server" placeholder="Enter Address" TextMode="MultiLine" required="true"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-12">
                                    <div class="form-group">
                                        <label>Mobile Number</label>
                                        <asp:TextBox ID="txtMNumber" CssClass="form-control" runat="server" placeholder="Enter Mobile Number" required="true"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Mobile No. must have 10 digits"
                                            ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small" ValidationExpression="^[0-9]{10}$" ControlToValidate="txtMNumber"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                <div class="col-12">
                                    <div class="form-group">
                                        <label>Email</label>
                                        <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" placeholder="Enter Email" TextMode="Email" required="true"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-12">
                                    <div class="form-group">
                                        <label>Select Country</label>
                                        <asp:DropDownList ID="ddlCountry" runat="server" CssClass="form-contact w-100" DataSourceID="SqlDataSource1" AppendDataBoundItems="true" DataTextField="Country" DataValueField="Country">
                                            <asp:ListItem Value="0">Select Country</asp:ListItem>
                                        </asp:DropDownList><br />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Country is Required" ControlToValidate="ddlCountry"
                                            ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small" InitialValue="0"></asp:RequiredFieldValidator>

                                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:cs %>" SelectCommand="SELECT Country FROM CountryTable"></asp:SqlDataSource>
                                    </div>
                                </div>

                                <br />
                                <br />
                                <asp:Label ID="ulb" CssClass="text-center" runat="server" Visible="false"></asp:Label>
                            </div>

                            <div class="vr border"></div>

                            <div class="col">
                                <div class="col-12 border-bottom border-right rounded-bottom mb-5">
                                    <h5 class="text-center">Resume Information</h5>
                                </div>
                                <div class="col-12">
                                    <div class="form-group">
                                        <label>10th Percentage/Grade</label>
                                        <asp:TextBox ID="txtTenth" CssClass="form-control" runat="server" placeholder="Ex. 90%"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-12">
                                    <div class="form-group">
                                        <label>12th Percentage/Grade</label>
                                        <asp:TextBox ID="txtTwelfth" CssClass="form-control" runat="server" placeholder="Ex. 88%"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-12">
                                    <div class="form-group">
                                        <label>Graduation with pointer/Grade</label>
                                        <asp:TextBox ID="txtGraduation" CssClass="form-control" runat="server" placeholder="Ex. BTech with 9.2 pointer"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-12">
                                    <div class="form-group">
                                        <label>Post Graduation with pointer/Grade</label>
                                        <asp:TextBox ID="txtPostGraduation" CssClass="form-control" runat="server" placeholder="Ex. MTech with 9.0 pointer"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-12">
                                    <div class="form-group">
                                        <label>PHD with pointer/Grade</label>
                                        <asp:TextBox ID="txtPHD" CssClass="form-control" runat="server" placeholder="PHD with Grade"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-12">
                                    <div class="form-group">
                                        <label>Job Profile/Works On</label>
                                        <asp:TextBox ID="txtWork" CssClass="form-control" runat="server" placeholder="Job Profile"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-12">
                                    <div class="form-group">
                                        <label>Work Experience</label>
                                        <asp:TextBox ID="txtExperience" CssClass="form-control" runat="server" placeholder="Work Experience"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-12">
                                    <div class="form-group">
                                        <label>Resume</label><br />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Select file for resume!"
                                            ControlToValidate="fuResume"
                                            ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small"></asp:RequiredFieldValidator>
                                        <asp:FileUpload ID="fuResume" runat="server" CssClass="form-control pt-2" ToolTip=".doc, .docx, .pdf extension only" />
                                        <asp:Label ID="flb" runat="server"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="form-group mt-5 text-center">
                            <asp:Button CssClass="button button-contactForm boxed-btn" ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </main>

</asp:Content>
