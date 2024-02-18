<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="JobList.aspx.cs" Inherits="Job_Finder.Admin.JobList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:UpdatePanel ID="ContactPanel" runat="server">
        <ContentTemplate>

            <main>

                <div class="container-fluid pt-4 pb-4">

                    <h3 class="text-center">Job List/Detail</h3>

                    <div class="row mb-3 pt-sm-3">
                        <div class="col-md-12">
                            <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered table-hover"
                                AutoGenerateColumns="False" AllowPaging="True" PageSize="5" HeaderStyle-HorizontalAlign="Center"
                                OnPageIndexChanging="GridView1_PageIndexChanging" DataKeyNames="JobID"
                                OnRowDeleting="GridView1_RowDeleting" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound">

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

                                    <asp:BoundField DataField="LastDateToApply" HeaderText="Valide Till" DataFormatString="{0:dd MMMM yyyy}">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>

                                    <asp:BoundField DataField="CompanyName" HeaderText="Company">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>

                                    <asp:BoundField DataField="Country" HeaderText="Country">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>

                                    <asp:BoundField DataField="State" HeaderText="State">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>

                                    <asp:BoundField DataField="CreateDate" HeaderText="Posted Date" DataFormatString="{0:dd MMMM yyyy}">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>

                                    <%--<asp:TemplateField HeaderText="Edit">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnEditJob" runat="server" CommandName="EditJob" CommandArgument='<%# Eval("JobID") %>'>
                                                    <asp:Image ID="imgSet" runat="server" ImageUrl="../assets/img/icon/editIcon.png" Height="25px" Width="25px" />
                                                </asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                                        </asp:TemplateField>--%>

                                    <asp:CommandField CausesValidation="false" HeaderText="Delete" ShowDeleteButton="true"
                                        DeleteImageUrl="../assets/img/icon/trashIcon.png" ButtonType="Image">
                                        <ControlStyle Height="25px" Width="25px" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:CommandField>

                                </Columns>
                                <HeaderStyle BackColor="#7200cf" ForeColor="White" />

                                <EmptyDataTemplate>
                                    <center>
                                        <h5 class="text-danger">No record to display...!</h5>
                                    </center>
                                </EmptyDataTemplate>

                            </asp:GridView>
                        </div>

                    </div>
                    <center>
                        <asp:Label Id="lblMsg" runat="server"></asp:Label>
                    </center>
                    <asp:HyperLink ID="btnBack" runat="server" NavigateUrl="~/Admin/ViewResume.aspx" CssClass="btn btn-secondary" Visible="False">< Back</asp:HyperLink>
                </div>

            </main>

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
