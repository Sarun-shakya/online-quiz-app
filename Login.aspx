<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Login.aspx.cs"
    Inherits="Online_Quiz_Application.Login" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container-fluid vh-100 d-flex justify-content-center align-items-center">
        <div class="col-md-5 col-lg-4">

            <div class="card shadow-lg border-0 rounded-4 signup-card p-5">

                <div class="text-center mb-4">
                    <h2 class="mb-1 fw-bold text-success pt-4">Login</h2>
                    <small>Login to start your exam on Online Quiz System</small>
                </div>

                <div class="card-body p-4">

                    <asp:Label ID="lblMessage"
                        runat="server"
                        CssClass="text-danger d-block mb-3"
                        Visible="false">
                    </asp:Label>

                    <div class="mb-3">
                        <label class="form-label fw-bold">
                            Email
                        </label>

                        <asp:TextBox ID="txtEmail"
                            runat="server"
                            CssClass="form-control"
                            placeholder="Enter email">
                        </asp:TextBox>
                    </div>

                    <div class="mb-3">
                        <label class="form-label fw-bold">
                            Password
                        </label>

                        <asp:TextBox ID="txtPassword"
                            runat="server"
                            TextMode="Password"
                            CssClass="form-control"
                            placeholder="Enter password">
                        </asp:TextBox>
                    </div>

                    <div class="form-check mb-3">
                        <asp:CheckBox ID="chkRemember"
                            runat="server"
                            CssClass="form-check-input" />
                        <label class="form-check-label">
                            Remember me
                        </label>
                    </div>

                    <asp:Button ID="btnLogin"
                        runat="server"
                        Text="Login"
                        CssClass="btn btn-success w-100"
                        OnClick="btnLogin_Click" />

                    <div class="text-center mt-4">
    <span class="text-muted">Don't have an account?</span>
    <a href="Signup.aspx" class="text-success fw-semibold text-decoration-none">
        Signup
    </a>
</div>

                </div>
            </div>

        </div>
    </div>

</asp:Content>
