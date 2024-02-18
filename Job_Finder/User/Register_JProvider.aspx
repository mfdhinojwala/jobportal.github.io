<%@ Page Title="" Language="C#" MasterPageFile="~/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="Register_JProvider.aspx.cs" Inherits="Job_Finder.User.Register_JProvider" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <main>
        <div class="container pt-50 pb-40">
            <div class="row">
                <div class="col-12 section-tittle text-center">
                    <h2><%Response.Write(Session["titleru"]); %></h2>
                </div>
                <div class="col mx-auto">
                    <div class="form-contact contact_form border-top rounded-top pt-10">
                        <div class="row">
                            <div class="col">
                                <div class="col-12 border-bottom border-left rounded-bottom mb-5">
                                    <h5 class="text-center">Login Information</h5>
                                </div>
                                <div class="col-12">
                                    <div class="form-group">
                                        <label>Company/Organization</label>
                                        <asp:TextBox ID="txtCompany" CssClass="form-control" runat="server" placeholder="Enter Company/Organization Name" required="true"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <label>Password</label>
                                        <asp:TextBox ID="txtPassword" CssClass="form-control" runat="server" placeholder="Enter Password" TextMode="Password" required="true"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <label>Comfirm Password</label>
                                        <asp:TextBox ID="txtCPassword" CssClass="form-control" runat="server" placeholder="Enter Comfirm Password" TextMode="Password" required="true"></asp:TextBox>
                                        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Password & Comfirm Password should be same."
                                            ControlToCompare="txtPassword" ControlToValidate="txtCPassword"
                                            ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small"></asp:CompareValidator>
                                    </div>
                                </div>
                                <span class="clicklink" id="arch" runat="server"><a href="../User/Login.aspx">Already Register? Click Here..</a></span>
                                <br />
                                <span class="clicklink" id="nuch" runat="server"><a href="../User/Register_JFinder.aspx">New User? Click Here..</a></span>
                                <br />
                                <br />
                                <asp:Label ID="rlb" CssClass="text-center" runat="server" Visible="false"></asp:Label>
                            </div>

                            <div class="vr border"></div>

                            <div class="col">
                                <div class="col-12 border-bottom border-right rounded-bottom mb-5">
                                    <h5 class="text-center">Company/Organization Information</h5>
                                </div>
                                <div class="col-12">
                                    <div class="form-group">
                                        <label>Website</label>
                                        <asp:TextBox ID="txtWebsite" CssClass="form-control" runat="server" placeholder="Enter Website" TextMode="url" required="true"></asp:TextBox>
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
                                        <label>Company/Organization Logo</label>
                                        <asp:FileUpload ID="fuCompanyLogo" runat="server" CssClass="form-control" ToolTip=".jpg, .jpeg, .png extension only"></asp:FileUpload>
                                        <asp:Label ID="flb" runat="server"></asp:Label>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Select file for company logo!"
                                            ControlToValidate="fuCompanyLogo"
                                            ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small"></asp:RequiredFieldValidator>
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
                                        <label>State</label>
                                        <asp:TextBox ID="txtState" CssClass="form-control" runat="server" placeholder="Enter State" required="true"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-12">
                                    <div class="form-group">
                                        <label>Select Country</label>
                                        <asp:DropDownList ID="ddlCountry" runat="server" CssClass="form-control w-100" DataSourceID="SqlDataSource1" AppendDataBoundItems="true" DataTextField="Country" DataValueField="Country">
                                            <asp:ListItem Value="0">Select Country</asp:ListItem>
                                        </asp:DropDownList><br />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Country is Required" ControlToValidate="ddlCountry"
                                            ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small" InitialValue="0"></asp:RequiredFieldValidator>

                                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:cs %>" SelectCommand="SELECT Country FROM CountryTable"></asp:SqlDataSource>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="form-group mt-5 text-center">
                            <asp:Button CssClass="button button-contactForm boxed-btn" ID="rBtnRegister" runat="server" Text="Register" OnClick="rBtnRegister_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </main>

</asp:Content>
