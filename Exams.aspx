<%@ Page Title="Exams" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Exams.aspx.cs"
    Inherits="Online_Quiz_Application.Exams" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<div class="container vh-100 py-5 ">

    <h2 class="mb-4 fw-bold">Available Exams</h2>

    <div class="row">

        <asp:Repeater ID="rptExams" runat="server">

            <ItemTemplate>

                <div class="col-md-4 mb-4">

                    <div class="card shadow h-100 border-0 rounded-4">

                        <div class="card-body">

                            <h4 class="card-title fw-semibold text-primary">
                                <%# Eval("name") %>
                            </h4>

                            <hr />

                            <p class="card-text">
                                <strong>Questions:</strong>
                                <%# Eval("totalQuestions") %>
                            </p>

                            <p class="card-text">
                                <strong>Duration:</strong>
                                <%# Eval("durationMinutes") %> Minutes
                            </p>

                        </div>

                        <div class="card-footer bg-white border-0">

                            <asp:Button ID="btnStart"
                                runat="server"
                                Text="Start Exam"
                                CssClass="btn btn-primary w-100 rounded-3"
                                CommandName="StartExam"
                                CommandArgument='<%# Eval("examId") %>'
                                OnCommand="btnStart_Command" />

                        </div>

                    </div>

                </div>

            </ItemTemplate>

        </asp:Repeater>

    </div>

</div>

</asp:Content>