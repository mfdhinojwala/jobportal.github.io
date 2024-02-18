<%@ Page Title="" Language="C#" MasterPageFile="~/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="Profile_JFinder.aspx.cs" Inherits="Job_Finder.User.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <main>

        <div class="container pt-5 pb-5">
            <div class="main-body">
                
                <%--For User--%>
                <asp:DataList ID="DataList1" runat="server" Width="100%" OnItemCommand="DataList1_ItemCommand">
                    <ItemTemplate>
                        <div class="row gutters-sm">
                            <div class="col-md-4 mb-3 ">
                                <div class="card">
                                    <div class="card-body">
                                        <div class="d-flex flex-column align-items-center text-center">
                                            <%--<img src="https://bootdey.com/img/Content/avatar/avatar7.png" alt="UserPic" class="rounded-circle" width="150" />--%>
                                            <img src="<%# Eval("UserImg") != DBNull.Value ? DataBinder.Eval(Container,"DataItem.UserImg","../{0}") : "https://bootdey.com/img/Content/avatar/avatar7.png" %>" alt="logoPic" class="rounded-circle" width="150" />
                                            <div class="mt-3">
                                                <%--eval = evaluate both statements and expressions are allowed--%>
                                                <h4 class="text-capitalize"><%# Eval("Name") %></h4>
                                                <p class="text-secondary mb-1"><%# Eval("Username") %></p>
                                                <p class="text-muted font-size-sm text-capitalize">
                                                    <i class="fas fa-map-marker-alt"></i> <%# Eval("Country") %>
                                                </p>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-8">
                                <div class="card mb-3">
                                    <div class="card-body">
                                        <div class="row">
                                            <div class="col-sm-3">
                                                <h6 class="mb-0">Fullname</h6>
                                            </div>
                                            <div class="col-sm-9 text-secondary text-capitalize">
                                                <%# Eval("Name") %>
                                            </div>
                                        </div>
                                        <hr />
                                        <div class="row">
                                            <div class="col-sm-3">
                                                <h6 class="mb-0">Email</h6>
                                            </div>
                                            <div class="col-sm-9 text-secondary">
                                                <%# Eval("Email") %>
                                            </div>
                                        </div>
                                        <hr />
                                        <div class="row">
                                            <div class="col-sm-3">
                                                <h6 class="mb-0">Mobile</h6>
                                            </div>
                                            <div class="col-sm-9 text-secondary text-capitalize">
                                                <%# Eval("MNumber") %>
                                            </div>
                                        </div>
                                        <hr />
                                        <div class="row">
                                            <div class="col-sm-3">
                                                <h6 class="mb-0">Address</h6>
                                            </div>
                                            <div class="col-sm-9 text-secondary text-capitalize">
                                                <%# Eval("Address") %>
                                            </div>
                                        </div>
                                        <hr />
                                        <div class="row">
                                            <div class="col-sm-3">
                                                <h6 class="mb-0">Resume</h6>
                                            </div>
                                            <div class="col-sm-9 text-secondary text-capitalize">
                                                    <%# Eval("Resume") == DBNull.Value ? "Not Uploaded" : "Uploaded" %>
                                            </div>
                                        </div>
                                        <hr />
                                        <div class="row">
                                            <div class="col-sm-12">
                                                <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="button button-contactForm boxed-btn" CommandName="EditUserProfile" CommandArgument='<%# Eval("UserID") %>' />
                                            </div>
                                        </div>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:DataList>

            </div>
        </div>

    </main>

</asp:Content>
