<%@ Page Title="" Language="C#" MasterPageFile="~/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="Job_Details.aspx.cs" Inherits="Job_Finder.User.Job_Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <main>

        <!-- Hero Area Start-->
        <div class="slider-area ">
            <div class="single-slider section-overly slider-height2 d-flex align-items-center" data-background="../assets/img/hero/about.jpg">
                <div class="container">
                    <div class="row">
                        <div class="col-xl-12">
                            <div class="hero-cap text-center">
                                <h2><%# jobTitle %></h2>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- Hero Area End -->

        <div Class="d-flex justify-content-center mt-50">
            <asp:Label ID="lblmsg" runat="server" Visible="false"></asp:Label>
        </div>

        <!-- job post company Start -->
        <div class="job-post-company pt-70 pb-120">
            <%--<div class="container">--%>
                <asp:DataList ID="DataList1" runat="server" OnItemCommand="DataList1_ItemCommand" OnItemDataBound="DataList1_ItemDataBound" CssClass="container">
                    <ItemTemplate>
                        <div class="row justify-content-between">
                            <!-- Left Content -->
                            <div class="col-xl-7 col-lg-8">
                                <!-- job single -->
                                <div class="single-job-items mb-50"">
                                    <div class="job-items">
                                        <div class="company-img company-img-details">
                                            <a href="#">
                                                <img src="<%# getImageUrl( Eval("CompanyLogo")) %>" alt="Company_Logo">
                                            </a>
                                        </div>
                                        <div class="job-tittle">
                                            <a href="#">
                                                <h4><%# Eval("JobTitle") %></h4>
                                            </a>
                                            <ul>
                                                <li><%# Eval("CompanyName") %></li>
                                                <li><i class="fas fa-map-marker-alt"></i><%# Eval("State") %>, <%# Eval("Country") %></li>
                                                <li><%# Eval("Salary") %></li>
                                            </ul>
                                        </div>
                                    </div>
                                </div>
                                <!-- job single End -->

                                <div class="job-post-details">
                                    <div class="post-details1 mb-50">
                                        <!-- Small Section Tittle -->
                                        <div class="small-section-tittle">
                                            <h4>Job Description</h4>
                                        </div>
                                        <p><%# Eval("Description") %></p>
                                    </div>
                                    <div class="post-details2  mb-50">
                                        <!-- Small Section Tittle -->
                                        <div class="small-section-tittle">
                                            <h4>Required Knowledge, Skills, and Abilities</h4>
                                        </div>
                                        <ul>
                                            <li><%# Eval("Specification") %></li>
                                            <%--<li>Mobile Applicationin iOS/Android/Tizen or other platform</li>
                                            <li>Research and code , libraries, APIs and frameworks</li>
                                            <li>Strong knowledge on software development life cycle</li>
                                            <li>Strong problem solving and debugging skills</li>--%>
                                        </ul>
                                    </div>
                                    <div class="post-details2  mb-50">
                                        <!-- Small Section Tittle -->
                                        <div class="small-section-tittle">
                                            <h4>Education + Experience</h4>
                                        </div>
                                        <ul>
                                            <li><%# Eval("Qualification") %></li>
                                            <li><%# Eval("Experience") %></li>
                                            <%--<li>Ecommerce website design experience</li>
                                            <li>Familiarity with mobile and web apps preferred</li>
                                            <li>Experience using Invision a plus</li>--%>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                            <!-- Right Content -->
                            <div class="col-xl-4 col-lg-4">
                                <div class="post-details3  mb-50">
                                    <!-- Small Section Tittle -->
                                    <div class="small-section-tittle">
                                        <h4>Job Overview</h4>
                                    </div>
                                    <ul>
                                        <li>Posted date : <span><%# DataBinder.Eval(Container.DataItem,"CreateDate","{0:dd/MM/yyyy}") %></span></li>
                                        <li>Location : <span><%# Eval("Address") %></span></li>
                                        <li>Vacancy : <span><%# Eval("NoOfPost") %></span></li>
                                        <li>Job nature : <span><%# Eval("JobType") %></span></li>
                                        <li>Salary :  <span><%# Eval("Salary") %></span></li>
                                        <li>Last date : <span><%# DataBinder.Eval(Container.DataItem,"LastDateToApply","{0:dd/MM/yyyy}") %></span></li>
                                    </ul>
                                    <div class="apply-btn2">
                                        <%--<a href="#" class="btn">Apply Now</a>--%>
                                        <asp:LinkButton ID="btnApplyJob" runat="server" CssClass="btn" Text="Apply Now" CommandName="ApplyJob"></asp:LinkButton>
                                    </div>

                                   <div class="apply-btn2">
                                    <button style="background-color:lightgreen; padding:12px 24.5px; "><a href="http://wa.me/+919327687677"></a></button>
                                  </div>

                                     <div class="apply-btn2">
                                    <button style="background-color:deeppink; padding:12px 24.5px;"><a href="Contact.aspx">Register complain </a></button>
</div>
                                <div class="post-details4  mb-50">
                                    <!-- Small Section Tittle -->
                                    <div class="small-section-tittle">
                                        <h4>Company Information</h4>
                                    </div>
                                    <span><%# Eval("CompanyName") %></span>
                                    <p><%# Eval("Address") %>,<br />
                                        <%# Eval("State") %>, <%# Eval("Country") %></p>
                                    <ul>
                                        <li>Name: <span><%# Eval("CompanyName") %></span></li>
                                        <li>Web : <span><%# Eval("Website") %></span></li>
                                        <li>Email: <span><%# Eval("Email") %></span></li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:DataList>
            <%--</div>--%>
        </div>
        <!-- job post company End -->

    </main>

</asp:Content>
