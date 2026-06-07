<%@ Page Title="UpdateQuestion" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="UpdateQuestion.aspx.cs" Inherits="Online_Quiz_Application.Admin.UpdateQuestion" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="AdminContent" runat="server">

    <div class="container">

        <h2>Update Question</h2>
        <p>Here you can update question by changing the values</p>

        <asp:Label ID="lblExam" runat="server"
            CssClass="fw-bold text-primary"></asp:Label>

        <div class="card p-4 mt-3">

            <div class="mb-3">
                <label>Question</label>
                <asp:TextBox ID="txtQuestion" runat="server"
                    CssClass="form-control"
                    TextMode="MultiLine" Rows="3" />
            </div>

            <div class="mb-3">
                <label>Option A</label>
                <asp:TextBox ID="txtA" runat="server"
                    CssClass="form-control" />
            </div>

            <div class="mb-3">
                <label>Option B</label>
                <asp:TextBox ID="txtB" runat="server"
                    CssClass="form-control" />
            </div>

            <div class="mb-3">
                <label>Option C</label>
                <asp:TextBox ID="txtC" runat="server"
                    CssClass="form-control" />
            </div>

            <div class="mb-3">
                <label>Option D</label>
                <asp:TextBox ID="txtD" runat="server"
                    CssClass="form-control" />
            </div>

            <div class="mb-3">
                <label>Correct Answer</label>

                <asp:DropDownList ID="ddlAnswer"
                    runat="server"
                    CssClass="form-select">

                    <asp:ListItem Text="A" Value="A" />
                    <asp:ListItem Text="B" Value="B" />
                    <asp:ListItem Text="C" Value="C" />
                    <asp:ListItem Text="D" Value="D" />

                </asp:DropDownList>
            </div>

            <asp:Button ID="btnAddQuestion"
                runat="server"
                Text="Update Question"
                CssClass="btn btn-primary"
                OnClick="btnUpdateQuestion_Click" />

            <asp:Label ID="lblMsg"
                runat="server"
                CssClass="d-block mt-3"></asp:Label>

        </div>

      
    </div>
</asp:Content>

