<%@ Page Title="AddExam" Language="C#" MasterPageFile="~/Admin/Admin.Master"
    AutoEventWireup="true" CodeBehind="AddExam.aspx.cs"
    Inherits="Online_Quiz_Application.Admin.AddExam" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="AdminContent" runat="server">

    <div class="container">
        <h2>Add Exam</h2>
        <p>Here, you can add exam by filling the required details</p>
        <div class="card p-4 shadow-sm">

            <div class="mb-3">
                <label>Exam Name</label>
                <asp:TextBox ID="txtName" runat="server"
                    CssClass="form-control"
                    Placeholder="Enter exam name" />
            </div>

            <div class="mb-3">
                <label>Description</label>
                <asp:TextBox ID="txtDescription" runat="server"
                    CssClass="form-control"
                    TextMode="MultiLine"
                    Placeholder="Enter exam description" />
            </div>

            <div class="row">

                <div class="col-md-4 mb-3">
                    <label>Total Questions</label>
                    <asp:TextBox ID="txtTotalQuestions" runat="server"
                        CssClass="form-control"
                        TextMode="Number"
                        Placeholder="e.g. 20" />
                </div>

                <div class="col-md-4 mb-3">
                    <label>Marks Per Question</label>
                    <asp:TextBox ID="txtMarks" runat="server"
                        CssClass="form-control"
                        TextMode="Number"
                        Placeholder="e.g. 5" />
                </div>

                <div class="col-md-4 mb-3">
                    <label>Duration (Minutes)</label>
                    <asp:TextBox ID="txtDuration" runat="server"
                        CssClass="form-control"
                        TextMode="Number"
                        Placeholder="e.g. 30" />
                </div>

            </div>
            <asp:Button ID="btnSave" runat="server" Text="Create Exam"
                CssClass="btn btn-primary"
                OnClick="btnSave_Click" />

            <asp:Label ID="lblMsg" runat="server" CssClass="d-block mt-3 text-success text-center" />

        </div>
    </div>

</asp:Content>
