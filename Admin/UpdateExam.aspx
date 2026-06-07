<%@ Page Title="UpdateExam" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="UpdateExam.aspx.cs" Inherits="Online_Quiz_Application.Admin.UpdateExam" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="AdminContent" runat="server">

    <div class="container">
    <h2>Update Exam</h2>
        <p>Here you can update exam by changing values</p>

    <div class="card p-4 shadow-sm">

        <div class="mb-3">
            <label>Exam Name</label>
            <asp:TextBox ID="txtName" runat="server" CssClass="form-control" />
        </div>

        <div class="mb-3">
            <label>Description</label>
            <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" TextMode="MultiLine" />
        </div>

        <div class="row">

            <div class="col-md-4 mb-3">
                <label>Total Questions</label>
                <asp:TextBox ID="txtTotalQuestions" runat="server" CssClass="form-control" TextMode="Number" />
            </div>

            <div class="col-md-4 mb-3">
                <label>Marks Per Question</label>
                <asp:TextBox ID="txtMarks" runat="server" CssClass="form-control" TextMode="Number" />
            </div>

            <div class="col-md-4 mb-3">
                <label>Duration (Minutes)</label>
                <asp:TextBox ID="txtDuration" runat="server" CssClass="form-control" TextMode="Number" />
            </div>

        </div>

        <asp:Button ID="btnSave" runat="server" Text="Update Exam"
            CssClass="btn btn-primary"
            OnClick="btnUpdate_Click" />

        <asp:Label ID="lblMsg" runat="server" CssClass="d-block mt-3 text-success text-center" />

    </div>
</div>

</asp:Content>
