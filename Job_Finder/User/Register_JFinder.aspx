<%@ Page Title="" Language="C#" MasterPageFile="~/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="Register_JFinder.aspx.cs" Inherits="Job_Finder.User.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%--<asp:ScriptManager ID="CScriptManager" runat="server" />--%>
    <asp:UpdatePanel ID="RegisterPanel" runat="server">
        <ContentTemplate>

            <main>
                <div class="container pt-50 pb-40">
                    <div class="row">
                        <div class="col-12 section-tittle text-center">
                            <h2>Register as a User</h2>
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
                                                <label>User Name</label>
                                                <asp:TextBox ID="txtUsername" CssClass="form-control" runat="server" placeholder="Enter Unique Username" required="true"></asp:TextBox>
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
                                        <span class="clicklink"><a href="../User/Login.aspx">Already Register? Click Here..</a></span>
                                        <br />
                                        <span class="clicklink"><a href="../User/Register_JProvider.aspx">New Company/Organisation? Click Here..</a></span>
                                        <br /><br />
                                        <asp:Label ID="rlb" CssClass="text-center" runat="server" Visible="false"></asp:Label>
                                    </div>

                                    <div class="vr border"></div>

                                    <div class="col">
                                        <div class="col-12 border-bottom border-right rounded-bottom mb-5">
                                            <h5 class="text-center">Personal Information</h5>
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
                                                <asp:DropDownList ID="ddlCountry" runat="server" CssClass="form-control w-100" DataSourceID="SqlDataSource1" AppendDataBoundItems="true" DataTextField="Country" DataValueField="Country">
                                                    <asp:ListItem Value="0">Select Country</asp:ListItem>
                                                </asp:DropDownList><br />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Country is Required" ControlToValidate="ddlCountry"
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

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
