<%@ Page Title="Signup" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Signup.aspx.cs"
    Inherits="Online_Quiz_Application.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<div class="container-fluid vh-100 d-flex justify-content-center align-items-center bg-light">

    <div class="card shadow-lg border-0 rounded-4 signup-card p-4">

        <div class="card-body p-5">

            <div class="text-center mb-4">
                <h2 class="fw-bold text-success">Create Account</h2>
                <p class="text-muted mb-0">
                    Sign up to start using the Online Quiz System
                </p>
            </div>

            <asp:Label ID="errorLabel" runat="server"
                CssClass="text-danger d-block text-center mb-3 fw-semibold">
            </asp:Label>

            <div class="mb-3">
                <label class="form-label fw-semibold">Full Name</label>
                <asp:TextBox ID="txtFullName" runat="server"
                    CssClass="form-control "
                    placeholder="Enter your full name" />
            </div>

            <div class="mb-3">
                <label class="form-label fw-semibold">Email Address</label>
                <asp:TextBox ID="txtEmail" runat="server"
                    CssClass="form-control"
                    TextMode="Email"
                    placeholder="example@gmail.com" />
            </div>

            <div class="mb-3">
                <label class="form-label fw-semibold">Password</label>
                <asp:TextBox ID="txtPassword" runat="server"
                    TextMode="Password"
                    CssClass="form-control "
                    placeholder="Enter password" />
            </div>

            <div class="mb-4">
                <label class="form-label fw-semibold">Confirm Password</label>
                <asp:TextBox ID="txtConfirmPassword" runat="server"
                    TextMode="Password"
                    CssClass="form-control "
                    placeholder="Confirm password" />
            </div>

            <div class="d-grid">
                <asp:Button ID="btnSignup" runat="server"
                    Text="Create Account"
                    CssClass="btn btn-success rounded-3"
                    OnClick="btnSignup_Click" />
            </div>

            <div class="text-center mt-4">
                <span class="text-muted">Already have an account?</span>
                <a href="Login.aspx" class="text-success fw-semibold text-decoration-none">
                    Login
                </a>
            </div>

        </div>
    </div>

</div>

</asp:Content>