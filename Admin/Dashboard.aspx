<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/Admin/Admin.Master"
    AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs"
    Inherits="Online_Quiz_Application.Admin.Dashboard" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="AdminContent" runat="server">

    <div class="container ">

        <h2 >Admin Dashboard</h2>
        <p>Here is what happening in your OnlineQuiz Application</p>

        <!-- STATS CARDS -->
        <div class="row">

            <div class="col-md-3">
                <div class="card text-white bg-primary mb-3 shadow">
                    <div class="card-body">
                        <h5>Total Users</h5>
                        <h3>
                            <asp:Label ID="lblUsers" runat="server" /></h3>
                    </div>
                </div>
            </div>

            <div class="col-md-3">
                <div class="card text-white bg-success mb-3 shadow">
                    <div class="card-body">
                        <h5>Total Exams</h5>
                        <h3>
                            <asp:Label ID="lblExams" runat="server" /></h3>
                    </div>
                </div>
            </div>

            <div class="col-md-3">
                <div class="card text-white bg-warning mb-3 shadow">
                    <div class="card-body">
                        <h5>Total Questions</h5>
                        <h3>
                            <asp:Label ID="lblQuestions" runat="server" /></h3>
                    </div>
                </div>
            </div>

            <div class="col-md-3">
                <div class="card text-white bg-danger mb-3 shadow">
                    <div class="card-body">
                        <h5>Total Results</h5>
                        <h3>
                            <asp:Label ID="lblResults" runat="server" /></h3>
                    </div>
                </div>
            </div>

        </div>

        <!-- RECENT EXAMS -->
        <h4 class="mt-4">Recent Exams</h4>
        <asp:GridView ID="gvExams" runat="server" CssClass="table table-bordered"
            AutoGenerateColumns="False">
            <HeaderStyle CssClass="table-dark" />

            <Columns>

                <asp:TemplateField HeaderText="SN">
                    <ItemTemplate>
                        <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:BoundField DataField="name" HeaderText="Exam Name" />
                <asp:BoundField DataField="description" HeaderText="Description" />
                <asp:BoundField DataField="totalQuestions" HeaderText="Questions" />
                <asp:BoundField DataField="marksPerQuestion" HeaderText="Marks" />
                <asp:BoundField DataField="durationMinutes" HeaderText="Duration" />

            </Columns>

        </asp:GridView>

        <!-- RECENT RESULTS -->
        <h4 class="mt-4">Recent Results</h4>
        <asp:GridView ID="gvResults" runat="server" CssClass="table table-bordered"
            AutoGenerateColumns="False">
            <HeaderStyle CssClass="table-dark" />

            <Columns>

                <asp:TemplateField HeaderText="SN">
                    <ItemTemplate>
                        <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:BoundField DataField="fullName" HeaderText="User Name" />
                <asp:BoundField DataField="examName" HeaderText="Exam" />
                <asp:BoundField DataField="score" HeaderText="Score" />
                <asp:BoundField DataField="examDate" HeaderText="Date" DataFormatString="{0:yyyy-MM-dd}" />

            </Columns>

        </asp:GridView>

    </div>

</asp:Content>
