<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="CompanyList.aspx.cs" Inherits="Job_Finder.Admin.CompanyList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:UpdatePanel ID="ContactPanel" runat="server">
        <ContentTemplate>

            <main>

                <div class="container-fluid pt-4 pb-4">

                    <h3 class="text-center">Company List/Detail</h3>

                    <div class="row mb-3 pt-sm-3">
                        <div class="col-md-12">
                            <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered table-hover"
                                AutoGenerateColumns="False" AllowPaging="True" PageSize="5" HeaderStyle-HorizontalAlign="Center"
                                OnPageIndexChanging="GridView1_PageIndexChanging" DataKeyNames="CompanyID" OnRowDeleting="GridView1_RowDeleting">

                                <Columns>
                                    <asp:BoundField DataField="Sr.No" HeaderText="Sr.No">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>

                                    <asp:BoundField DataField="CompanyName" HeaderText="Company Name">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>

                                    <asp:BoundField DataField="Website" HeaderText="Website">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>

                                    <asp:BoundField DataField="Email" HeaderText="Email">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>

                                    <asp:TemplateField HeaderText="Logo">
                                            <itemtemplate>
                                                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# DataBinder.Eval(Container,"DataItem.CompanyLogo","../{0}") %>'><i class="fas fa-download"></i>Download</asp:HyperLink>
                                            </itemtemplate>
                                            <itemstyle horizontalalign="Center" />
                                        </asp:TemplateField>

                                    <asp:BoundField DataField="Address" HeaderText="Address">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>

                                    <asp:BoundField DataField="State" HeaderText="State">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>

                                    <asp:BoundField DataField="Country" HeaderText="Country">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>

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
                </div>

            </main>

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
