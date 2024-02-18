<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="ViewResume.aspx.cs" Inherits="Job_Finder.Admin.ViewResume" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:UpdatePanel ID="ContactPanel" runat="server">
        <contenttemplate>

            <main>
                <div style="background-image: url('..Images/bg.jpg'); width: 100%; height: 720px; background-repeat: no-repeat; background-size: cover; background-attachment: fixed;">
                    <div class="container-fluid pt-4 pb-4">

                        <h3 class="text-center">View Applied Jobs</h3>

                        <div class="row mb-3 pt-sm-3">
                            <div class="col-md-12">
                                <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered table-hover"
                                    AutoGenerateColumns="False" AllowPaging="True" PageSize="5" HeaderStyle-HorizontalAlign="Center"
                                    OnPageIndexChanging="GridView1_PageIndexChanging" DataKeyNames="AppliedJobID" OnRowDeleting="GridView1_RowDeleting"
                                    OnRowDataBound="GridView1_RowDataBound" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">

                                    <columns>
                                        <asp:BoundField DataField="Sr.No" HeaderText="Sr.No">
                                            <itemstyle horizontalalign="Center"></itemstyle>
                                        </asp:BoundField>

                                        <asp:BoundField DataField="CompanyName" HeaderText="CompanyName">
                                            <itemstyle horizontalalign="Center"></itemstyle>
                                        </asp:BoundField>

                                        <asp:BoundField DataField="JobTitle" HeaderText="Job Title">
                                            <itemstyle horizontalalign="Center"></itemstyle>
                                        </asp:BoundField>

                                        <asp:BoundField DataField="Name" HeaderText="Name">
                                            <itemstyle horizontalalign="Center"></itemstyle>
                                        </asp:BoundField>

                                        <asp:BoundField DataField="Email" HeaderText="User Email">
                                            <itemstyle horizontalalign="Center"></itemstyle>
                                        </asp:BoundField>

                                        <asp:BoundField DataField="MNumber" HeaderText="Mobile No.">
                                            <itemstyle horizontalalign="Center"></itemstyle>
                                        </asp:BoundField>

                                        <asp:TemplateField HeaderText="Resume">
                                            <itemtemplate>
                                                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# DataBinder.Eval(Container,"DataItem.Resume","../{0}") %>'><i class="fas fa-download"></i>Download</asp:HyperLink>
                                                <asp:HiddenField ID="hdnJobId" runat="server" Value='<%# Eval("JobID") %>' Visible="false" />
                                            </itemtemplate>
                                            <itemstyle horizontalalign="Center" />
                                        </asp:TemplateField>

                                        <asp:CommandField CausesValidation="false" HeaderText="Delete" ShowDeleteButton="true"
                                            DeleteImageUrl="../assets/img/icon/trashIcon.png" ButtonType="Image">
                                            <controlstyle height="25px" width="25px" />
                                            <itemstyle horizontalalign="Center" />
                                        </asp:CommandField>

                                    </columns>
                                    <headerstyle backcolor="#7200cf" forecolor="White" />

                                    <emptydatatemplate>
                                        <center>
                                            <h5 class="text-danger">No record to display...!</h5>
                                        </center>
                                    </emptydatatemplate>
                                </asp:GridView>
                            </div>

                        </div>
                        <center>
                            <asp:Label Id="lblMsg" runat="server"></asp:Label>
                        </center>
                    </div>
                </div>
            </main>

        </contenttemplate>
    </asp:UpdatePanel>

</asp:Content>
