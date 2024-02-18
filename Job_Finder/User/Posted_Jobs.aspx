<%@ Page Title="" Language="C#" MasterPageFile="~/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="Posted_Jobs.aspx.cs" Inherits="Job_Finder.User.Posted_Jobs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../assets/css/styles.css">
    <style>
        .pager A {
            color: #242b5e;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:UpdatePanel ID="ContactPanel" runat="server">
        <ContentTemplate>

            <main>

                <!-- Hero Area Start-->
                <div class="slider-area ">
                    <div class="single-slider section-overly slider-height2 d-flex align-items-center" style="background-image: url('../assets/img/hero/about.jpg')">
                        <div class="container">
                            <div class="row">
                                <div class="col-xl-12">
                                    <div class="hero-cap text-center">
                                        <h2>Job List/Detail</h2>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- Hero Area End -->

                <div class="container-fluid pt-4 pb-4">

                    <%--<h3 class="text-center">Job List/Detail</h3>--%>

                    <div class="row mb-3 pt-sm-3">
                        <div class="col-md-12">
                            <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered table-hover"
                                AutoGenerateColumns="False" AllowPaging="True" PageSize="5" HeaderStyle-HorizontalAlign="Center"
                                OnPageIndexChanging="GridView1_PageIndexChanging" DataKeyNames="JobID"
                                OnRowDeleting="GridView1_RowDeleting" OnRowCommand="GridView1_RowCommand">

                                <Columns>
                                    <asp:BoundField DataField="Sr.No" HeaderText="Sr.No">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>

                                    <asp:BoundField DataField="JobTitle" HeaderText="Job Title">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>

                                    <asp:BoundField DataField="NoOfPost" HeaderText="No. Of Post">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>

                                    <asp:BoundField DataField="Qualification" HeaderText="Qualification">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>

                                    <asp:BoundField DataField="Experience" HeaderText="Experience">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>

                                    <asp:BoundField DataField="Specification" HeaderText="Specification">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>

                                    <asp:BoundField DataField="Salary" HeaderText="Salary">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>

                                    <asp:BoundField DataField="JobType" HeaderText="JobType">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>

                                    <asp:BoundField DataField="CreateDate" HeaderText="Posted Date" DataFormatString="{0:dd MMMM yyyy}">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>

                                    <asp:BoundField DataField="LastDateToApply" HeaderText="Valide Till" DataFormatString="{0:dd MMMM yyyy}">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>

                                    <asp:TemplateField HeaderText="Edit">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnEditJob" runat="server" CommandName="EditJob" CommandArgument='<%# Eval("JobID") %>'>
                                                <asp:Image ID="imgSet" runat="server" ImageUrl="../assets/img/icon/editIcon.png" Height="25px" Width="25px" />
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="50px" />
                                    </asp:TemplateField>

                                    <asp:CommandField CausesValidation="false" HeaderText="Delete" ShowDeleteButton="true"
                                        DeleteImageUrl="../assets/img/icon/trashIcon.png" ButtonType="Image">
                                        <ControlStyle Height="25px" Width="25px" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:CommandField>

                                </Columns>
                                <HeaderStyle BackColor="#242b5e" ForeColor="White" />
                                <PagerStyle CssClass="pager" />

                                <EmptyDataTemplate>
                                    <center>
                                        <h5 class="text-danger">Not any job posted yet!</h5>
                                    </center>
                                </EmptyDataTemplate>

                            </asp:GridView>
                        </div>

                    </div>

                    <center class="my-5">
                        <asp:Label ID="lblMsg" runat="server"></asp:Label>
                    </center>

                    <%--<asp:HyperLink ID="btnBack" runat="server" NavigateUrl="~/Admin/ViewResume.aspx" CssClass="btn btn-secondary" Visible="False">< Back</asp:HyperLink>--%>
                </div>

            </main>

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
