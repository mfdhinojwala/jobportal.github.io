<%@ Page Title="" Language="C#" MasterPageFile="~/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Job_Finder.User.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <main>
        <div class="container pt-50 pb-40">
            <div class="row">
                <div class="col-12 section-tittle text-center">
                    <h2>Login</h2>
                </div>
                <div class="col-lg-4 mx-auto">
                    <div class="form-contact contact_form border-top rounded-top pt-10">
                        <div class="row">
                            <div class="col-12">
                                <div class="form-group">
                                    <label>User Name or Company/Organization name</label>
                                    <asp:TextBox ID="txtUsername" CssClass="form-control" runat="server" placeholder="Enter Username or Company/Organization name" required="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-sm-6">
                                <div class="form-group">
                                    <label>Password</label>
                                    <asp:TextBox ID="txtPassword" CssClass="form-control" runat="server" placeholder="Enter Password" TextMode="Password" required="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-12">
                                <div class="form-group">
                                    <label>Login Type</label>
                                    <asp:DropDownList ID="ddlLoginType" runat="server" CssClass="form-contact w-100">
                                        <asp:ListItem>Job Finder</asp:ListItem>
                                        <asp:ListItem>Job Provider</asp:ListItem>
                                        <asp:ListItem>Admin</asp:ListItem>
                                    </asp:DropDownList>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Country is Required" ControlToValidate="ddlLoginType"
                                        ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small" InitialValue="0"></asp:RequiredFieldValidator>--%>
                                </div>
                            </div>
                            <span class="clicklink mt-10"><a href="../User/Register_JFinder.aspx">New User? Click Here..</a></span>
                            <span class="clicklink mt-10"><a href="../User/Register_JProvider.aspx">New Company/Organization? Click Here..</a></span>
                            <br />
                            <br />
                            <asp:Label ID="llb" runat="server" Visible="false"></asp:Label>

                        </div>

                        <div class="form-group mt-3 text-center">
                            <asp:Button CssClass="button button-contactForm boxed-btn" ID="lBtnLogin" runat="server" Text="Login" OnClick="lBtnLogin_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </main>

</asp:Content>
