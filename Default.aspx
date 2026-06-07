<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Default.aspx.cs"
    Inherits="Online_Quiz_Application._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container-fluid vh-100 d-flex align-items-center">

        <div class="container">
            <div class="row align-items-center">

                <!-- LEFT SIDE TEXT -->
                <div class="col-md-6 text-center text-md-start">

                    <h1 class="fw-bold display-5 text-primary">
                        Online Quiz Application
                    </h1>

                    <p class="lead mt-3 text-secondary">
                        Test your knowledge, improve your skills, and challenge yourself with our interactive online quiz system.
                        Built for students and learning enthusiasts.
                    </p>

                    <div class="mt-4">
                        <a href="Exams.aspx" class="btn btn-primary btn-lg me-2 px-4">
                            Start Quiz
                        </a>

                        <a href="Signup.aspx" class="btn btn-outline-dark btn-lg px-4">
                            Create Account
                        </a>
                    </div>

                </div>

                <!-- RIGHT SIDE IMAGE -->
                <div class="col-md-6 text-center mt-4 mt-md-0">

                    <img src="https://cdn-icons-png.flaticon.com/512/4727/4727496.png"
                         class="img-fluid"
                         style="max-height:400px;"
                         alt="Quiz Image">
                </div>
            </div>
        </div>

    </div>

</asp:Content>