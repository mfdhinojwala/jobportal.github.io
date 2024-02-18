<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AdminIndex.aspx.cs" Inherits="Job_Finder.Admin.AdminIndex" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
        .card {
            background-color: #fff;
            border: none;
            border-radius: 10px;
            position: relative;
            margin-bottom: 30px;
            box-shadow: 0 0.46875rem 2.1875rem rgba(90,97,105,0.1), 0 0.9375rem 1.40625rem rgba(90,97,105,0.1), 0 0.25rem 0.53125rem rgba(90,97,105,0.12), 0 0.125rem 0.1875rem rgba(90,97,105,0.1);
        }

        .l-bg-cherry {
            background: linear-gradient(to right, #493240, #f09) !important;
            color: #fff;
        }

        .l-bg-blue-dark {
            background: linear-gradient(to right, #373b44, #4286f4) !important;
            color: #fff;
        }

        .l-bg-green-dark {
            background: linear-gradient(to right, #0a504a, #38ef7d) !important;
            color: #fff;
        }

        .l-bg-orange-dark {
            background: linear-gradient(to right, #a86008, #ffba56) !important;
            color: #fff;
        }

        .l-bg-cyan {
            background: linear-gradient(to right, #008B8B, #16E2F5) !important;
            color: #fff;
        }

        .l-bg-taupe {
            background: linear-gradient(to right, #614051, #915F6D) !important;
            color: #fff;
        }

        .card .card-statistic-3 .card-icon-large .fas, .card .card-statistic-3 .card-icon-large .far, .card .card-statistic-3 .card-icon-large .fab, .card .card-statistic-3 .card-icon-large .fal {
            font-size: 110px;
        }

        .card .card-statistic-3 .card-icon {
            text-align: center;
            line-height: 50px;
            margin-left: 15px;
            color: #000;
            position: absolute;
            right: -5px;
            top: 20px;
            opacity: 0.1;
        }

        .l-bg-green {
            background: linear-gradient(135deg, #23bdb8 0%, #43e794 100%) !important;
            color: #fff;
        }

        .l-bg-orange {
            background: linear-gradient(to right, #f9900e, #ffba56) !important;
            color: #fff;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main>

        <div class="container pt-4">
            <div class="row">
                <div class="col-12 pb-3">
                    <h2 class="text-center">Dashboard</h2>
                </div>

                <div class="col-md-10 mx-auto">
                    <div class="row">

                        <div class="col-xl-3 col-lg-6">
                            <div class="card l-bg-cherry">
                                <div class="card-statistic-3 p-4">
                                    <div class="card-icon card-icon-large">
                                        <i class="fas fa-users pr-2"></i>
                                    </div>
                                    <div class="mb-4">
                                        <h6 class="card-title mb-0">Total Users</h6>
                                    </div>
                                    <div class="row align-items-center mb-2 d-flex">
                                        <div class="col-8">
                                            <h2 class="d-flex align-items-center mb-0">
                                                <% Response.Write(Session["Users"]); %>
                                            </h2>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="col-xl-3 col-lg-6">
                            <div class="card l-bg-green-dark">
                                <div class="card-statistic-3 p-4">
                                    <div class="card-icon card-icon-large">
                                        <i class="fas fa-check-square pr-2"></i>
                                    </div>
                                    <div class="mb-4">
                                        <h6 class="card-title mb-0">Total Applied Jobs</h6>
                                    </div>
                                    <div class="row align-items-center mb-2 d-flex">
                                        <div class="col-8">
                                            <h2 class="d-flex align-items-center mb-0">
                                                <% Response.Write(Session["AppliedJobs"]); %>
                                            </h2>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="col-xl-3 col-lg-6">
                            <div class="card l-bg-taupe">
                                <div class="card-statistic-3 p-4">
                                    <div class="card-icon card-icon-large">
                                        <i class="fas fa-building pr-2"></i>
                                    </div>
                                    <div class="mb-4">
                                        <h6 class="card-title mb-0">Total Company</h6>
                                    </div>
                                    <div class="row align-items-center mb-2 d-flex">
                                        <div class="col-8">
                                            <h2 class="d-flex align-items-center mb-0">
                                                <% Response.Write(Session["Company"]); %>
                                            </h2>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="col-xl-3 col-lg-6">
                            <div class="card l-bg-blue-dark">
                                <div class="card-statistic-3 p-4">
                                    <div class="card-icon card-icon-large">
                                        <i class="fas fa-briefcase pr-2"></i>
                                    </div>
                                    <div class="mb-4">
                                        <h6 class="card-title mb-0">Total Jobs</h6>
                                    </div>
                                    <div class="row align-items-center mb-2 d-flex">
                                        <div class="col-8">
                                            <h2 class="d-flex align-items-center mb-0">
                                                <% Response.Write(Session["Jobs"]); %>
                                            </h2>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="col-xl-3 col-lg-6">
                            <div class="card l-bg-orange-dark">
                                <div class="card-statistic-3 p-4">
                                    <div class="card-icon card-icon-large">
                                        <i class="fas fa-comments pr-2"></i>
                                    </div>
                                    <div class="mb-4">
                                        <h6 class="card-title mb-0">Contacted Users</h6>
                                    </div>
                                    <div class="row align-items-center mb-2 d-flex">
                                        <div class="col-8">
                                            <h2 class="d-flex align-items-center mb-0">
                                                <% Response.Write(Session["ContactCount"]); %>
                                            </h2>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="col-xl-3 col-lg-6">
                            <div class="card l-bg-cyan">
                                <div class="card-statistic-3 p-4">
                                    <div class="card-icon card-icon-large">
                                        <i class="fas fa-newspaper pr-2"></i>
                                    </div>
                                    <div class="mb-4">
                                        <h6 class="card-title mb-0">News Latter Emails</h6>
                                    </div>
                                    <div class="row align-items-center mb-2 d-flex">
                                        <div class="col-8">
                                            <h2 class="d-flex align-items-center mb-0">
                                                <% Response.Write(Session["NewslatterCount"]); %>
                                            </h2>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>

            </div>
        </div>

    </main>

</asp:Content>
