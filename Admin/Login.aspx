<%@ Page Title="Exams" Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Online_Quiz_Application.Admin.Login" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Admin Login</title>

    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>

<body class="bg-light">

    <form id="form1" runat="server">

        <div class="container d-flex justify-content-center align-items-center" style="height: 100vh;">

            <div class="card p-4 shadow" style="width: 350px;">
                <h2 class="text-center mb-3">OnlineQuiz</h2>

                <h5 class="text-center mb-3">Admin Login</h5>

                <asp:Label ID="lblMsg" runat="server" CssClass="text-danger"></asp:Label>

                <!-- Email -->
                <div class="mb-3">
                    <asp:Label runat="server" class="form-label fw-semibold">Username</asp:Label>
                    <asp:TextBox ID="txtUsername" runat="server"
                        CssClass="form-control"
                        placeholder="Enter username"></asp:TextBox>
                </div>

                <!-- Password -->
                <div class="mb-3">
                    <asp:Label runat="server" class="form-label fw-semibold">Password</asp:Label>
                    <asp:TextBox ID="txtPassword" runat="server"
                        TextMode="Password"
                        CssClass="form-control"
                        placeholder="Enter password"></asp:TextBox>
                </div>

                <div class="mb-3 form-check">
                    <asp:CheckBox ID="chkRemember" runat="server"
                        CssClass="form-check-input" />
                    <asp:label runat="server" class="form-check-label small">Remember me</asp:label>
                </div>

                <asp:Button ID="btnLogin" runat="server" Text="Login"
                    CssClass="btn btn-primary w-100"
                    OnClick="btnLogin_Click" />

            </div>

        </div>

    </form>

</body>
</html>
