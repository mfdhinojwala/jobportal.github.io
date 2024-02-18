<%@ Page Title="" Language="C#" MasterPageFile="~/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="Post_Job.aspx.cs" Inherits="Job_Finder.User.Post_Job" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <main>

        <div class="container pt-50 pb-40">

            <div class="btn-toolbar justify-content-between mb-3">
                <div class="btn-group">
                    <asp:Label ID="lblMsg" runat="server"></asp:Label>
                </div>
                <div class="input-group h-25">
                    <asp:HyperLink ID="btnBack" runat="server" NavigateUrl="Posted_Jobs.aspx" CssClass="btn" Visible="false">< Back to...</asp:HyperLink>
                </div>
            </div>

            <div class="row">

                <div class="col-12 mb-50 section-tittle text-center">
                    <h3><%Response.Write(Session["title"]); %></h3>
                </div>

                <div class="col mx-auto">
                    <div class="form-contact contact_form border-top rounded-top pt-10">
                        <div class="row">
                            <div class="col">
                                <div class="col-12 border-bottom border-left rounded-bottom mb-5">
                                    <h5 class="text-center">Company/Organization Information</h5>
                                </div>
                                <div class="col-12">
                                    <div class="form-group">
                                        <label for="txtCompany">Company/Organization Name</label>
                                        <asp:TextBox ID="txtCompany" runat="server" CssClass="form-control text-success" placeholder="Enter Company/Organization Name" required="true"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-12">
                                    <div class="form-group">
                                        <label for="fuCompanyLogo">Company/Organization Logo</label>
                                        <asp:FileUpload ID="fuCompanyLogo" runat="server" CssClass="form-control" ToolTip=".jpg, .jpeg, .png extension only"></asp:FileUpload>
                                        <asp:Label ID="flb" runat="server"></asp:Label>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please Select file for company logo!"
                                            ControlToValidate="fuCompanyLogo"
                                            ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small"></asp:RequiredFieldValidator>
                                    </div>
                                </div>

                                <div class="col-12">
                                    <div class="form-group">
                                        <label for="txtWebsite">Website</label>
                                        <asp:TextBox ID="txtWebsite" runat="server" CssClass="form-control text-success" placeholder="Enter Website" TextMode="url"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-12">
                                    <div class="form-group">
                                        <label for="txtEmail">Email</label>
                                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control text-success" placeholder="Enter Email" TextMode="Email"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-12">
                                    <div class="form-group">
                                        <label for="txtAddress">Address</label>
                                        <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control text-success" placeholder="Enter Work Location" TextMode="MultiLine" required="true"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-12">
                                    <div class="form-group">
                                        <label for="ddlCountry">Country</label><br />
                                        <asp:DropDownList ID="ddlCountry" runat="server" CssClass="form-control text-success w-100" DataSourceID="SqlDataSource1" AppendDataBoundItems="true" DataTextField="Country" DataValueField="Country">
                                            <asp:ListItem Value="0">Select Country</asp:ListItem>
                                        </asp:DropDownList><br />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Country is Required" ControlToValidate="ddlCountry"
                                            ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small" InitialValue="0"></asp:RequiredFieldValidator>

                                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:cs %>" SelectCommand="SELECT Country FROM CountryTable"></asp:SqlDataSource>
                                    </div>
                                    <br />
                                </div>

                                <div class="col-12">
                                    <div class="form-group">
                                        <label for="txtState">State</label>
                                        <asp:TextBox ID="txtState" runat="server" CssClass="form-control text-success" placeholder="Enter State" required="true"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="vr border"></div>

                            <div class="col">
                                <div class="col-12 border-bottom border-right rounded-bottom mb-5">
                                    <h5 class="text-center">Job Information</h5>
                                </div>
                                <div class="col-12">
                                    <div class="form-group">
                                        <label for="txtJobTitle">Job Title</label>
                                        <asp:TextBox ID="txtJobTitle" runat="server" CssClass="form-control" placeholder="Ex. Web Developer,App Developer" required="true"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-12">
                                    <div class="form-group">
                                        <label for="txtNoOfPost">Number Of Post</label>
                                        <asp:TextBox ID="txtNoOfPost" runat="server" CssClass="form-control" placeholder="Enter Number Of Position" TextMode="Number" required="true"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-12">
                                    <div class="form-group">
                                        <label for="txtDescription">Description</label>
                                        <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" placeholder="Enter Job Description" TextMode="MultiLine" required="true"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-12">
                                    <div class="form-group">
                                        <label for="txtQualification">Qualification/Education required</label>
                                        <asp:TextBox ID="txtQualification" runat="server" CssClass="form-control" placeholder="Ex. MCA, BTech, MBA" required="true"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-12">
                                    <div class="form-group">
                                        <label for="txtExperience">Experience required</label>
                                        <asp:TextBox ID="txtExperience" runat="server" CssClass="form-control" placeholder="Ex. 2 Years, 1.5 Years" required="true"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-12">
                                    <div class="form-group">
                                        <label for="txtSpecialization">Specialization required</label>
                                        <asp:TextBox ID="txtSpecialization" runat="server" CssClass="form-control" placeholder="Enter Specialization" TextMode="MultiLine" required="true"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-12">
                                    <div class="form-group">
                                        <label for="txtLastDate">Last Date To Apply</label>
                                        <asp:TextBox ID="txtLastDate" runat="server" CssClass="form-control" placeholder="Enter Last Date To Apply" TextMode="Date" required="true"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-12">
                                    <div class="form-group">
                                        <label for="txtSalary">Salary</label>
                                        <asp:TextBox ID="txtSalary" runat="server" CssClass="form-control" placeholder="Ex. 25000/Month, 7L/Year" required="true"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-12">
                                    <div class="form-group">
                                        <label for="txtJobType">Job Type</label><br />
                                        <asp:DropDownList ID="ddlJobType" runat="server" CssClass="form-control w-100">
                                            <asp:ListItem Value="0">Select Job Type</asp:ListItem>
                                            <asp:ListItem>Full Time</asp:ListItem>
                                            <asp:ListItem>Part Time</asp:ListItem>
                                            <asp:ListItem>Remote</asp:ListItem>
                                            <asp:ListItem>Freelance</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Job Type is required"
                                            ForeColor="Red" ControlToValidate="ddlJobType" InitialValue="0" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>

                            </div>

                        </div>

                        <div class="form-group mt-5 text-center">
                            <asp:Button ID="jBtnAdd" runat="server" CssClass="button button-contactForm boxed-btn" Text="Add Job" OnClick="jBtnAdd_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </main>

</asp:Content>
