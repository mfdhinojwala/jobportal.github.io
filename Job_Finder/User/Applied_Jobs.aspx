<%@ Page Title="" Language="C#" MasterPageFile="~/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="Applied_Jobs.aspx.cs" Inherits="Job_Finder.User.Applied_Jobs" %>

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
                                        <h2>View Applied Jobs</h2>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- Hero Area End -->

                <div class="container-fluid pt-4 pb-4">

                    <%--<h3 class="text-center mb-35">View Applied Jobs</h3>--%>

                    <div class="row mb-2 pt-sm-3" style="height: 403px;">
                        <div class="col-md-12">
                            <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered table-hover"
                                AutoGenerateColumns="False" AllowPaging="True" PageSize="5" HeaderStyle-HorizontalAlign="Center"
                                OnPageIndexChanging="GridView1_PageIndexChanging" DataKeyNames="AppliedJobID" OnRowDeleting="GridView1_RowDeleting">

                                <Columns>
                                    <asp:BoundField DataField="Sr.No" HeaderText="Sr.No">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>

                                    <asp:BoundField DataField="CompanyName" HeaderText="CompanyName">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>

                                    <asp:BoundField DataField="JobTitle" HeaderText="Job Title">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>

                                    <asp:BoundField DataField="Salary" HeaderText="Salary">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>

                                    <asp:BoundField DataField="JobType" HeaderText="Job Type">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>

                                    <asp:BoundField DataField="NoOfPost" HeaderText="No. Of Vacancy">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>

                                    <asp:BoundField DataField="Name" HeaderText="Your Name">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>

                                    <asp:BoundField DataField="Email" HeaderText="Your Email">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>

                                    <asp:BoundField DataField="MNumber" HeaderText="Your Mobile No.">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>

                                    <asp:TemplateField HeaderText="Your Resume">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="HyperLink1" Style="color: #da2461;" runat="server" NavigateUrl='<%# DataBinder.Eval(Container,"DataItem.Resume","../{0}") %>'><i class="fas fa-download"></i> Download</asp:HyperLink>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>

                                    <asp:BoundField DataField="MNumber" HeaderText="Your Mobile No.">
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundField>

                                    <asp:CommandField CausesValidation="false" HeaderText="Delete" ShowDeleteButton="true"
                                            DeleteImageUrl="../assets/img/icon/trashIcon.png" ButtonType="Image">
                                        <controlstyle height="25px" width="25px" />
                                        <itemstyle horizontalalign="Center" />
                                    </asp:CommandField>

                                </Columns>

                                <EmptyDataTemplate>
                                    <center>
                                        <h5 class="text-danger">Not any job applied yet!</h5>
                                    </center>
                                </EmptyDataTemplate>

                                <HeaderStyle BackColor="#242b5e" ForeColor="White" />
                                <PagerStyle CssClass="pager" />
                            </asp:GridView>
                        </div>

                    </div>

                    <center class="mt-5">
                        <asp:Label ID="lblMsg" runat="server"></asp:Label>
                    </center>

                    <div class="mx-1 mt-40 p-2 border border-danger">
                        <h5 class="text-danger">*Noticeable Points</h5>
                        <ul id="uaj" runat="server" class="ml-4">
                            <li style="list-style-type: disc; font-weight: bold;">If your reasume selected then company will contact to you for interview or further process.</li>
                            <li style="list-style-type: disc;">If the job is removed for any resone then the job you applied for will also be removed.</li>
                            <li style="list-style-type: disc;">If your resume is not selected then the job you applied for will be removed.</li>
                            <li style="list-style-type: disc;">for any complaints about the company <button style="background-color:deeppink; "><a href="Contact.aspx">click here.</a></button></li>
                             
                            
                        </ul>

                        <ul id="caj" runat="server" class="ml-4">
                            <li style="list-style-type: disc; font-weight: bold;">If company select applied user resume then you will have to contact the applied user for interview or further process.</li>
                            <li style="list-style-type: disc;">If the posted job gets deleted by the company then the applied user's job will be automatically rejected.</li>
                            <li style="list-style-type: disc;">If compant doesn't want to assign a job then comapny can remove the applied user's job by deleting it.</li>
                        </ul>
                    </div>
                </div>

            </main>

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
