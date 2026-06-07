<%@ Page Title="Exams" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Exams.aspx.cs" Inherits="Online_Quiz_Application.Admin.Exams" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="AdminContent" runat="server">

    <h2>Manage Exams</h2>
    <p>Here, you can manage exams add questions and publish the exam</p>

    <asp:GridView ID="GridView1" runat="server"
        AutoGenerateColumns="False"
        CssClass="table table-bordered"
        OnRowCommand="GridView1_RowCommand">
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
            <asp:BoundField DataField="marksPerQuestion" HeaderText="Markes per question" />
            <asp:BoundField DataField="durationMinutes" HeaderText="Duration" />

            <asp:TemplateField HeaderText="Published">
                <ItemTemplate>
                    <%# Convert.ToBoolean(Eval("published")) ? "Yes" : "No" %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Actions">
                <ItemTemplate>

                    <asp:Button ID="btnUpdate"
                        runat="server"
                        Text="Update"
                        CssClass="btn btn-warning btn-sm"
                        CommandName="UpdateExam"
                        CommandArgument='<%# Eval("examId") %>' />

                    <asp:Button ID="btnDelete"
                        runat="server"
                        Text="Delete"
                        CssClass="btn btn-danger btn-sm"
                        CommandName="DeleteExam"
                        CommandArgument='<%# Eval("examId") %>'
                        OnClientClick="return confirm('Delete this exam?');" />

                    <asp:Button ID="btnPublish"
                        runat="server"
                        Text='<%# Convert.ToBoolean(Eval("published")) ? "Unpublish" : "Publish" %>'
                        CssClass='<%# Convert.ToBoolean(Eval("published")) ? "btn btn-secondary btn-sm" : "btn btn-success btn-sm" %>'
                        CommandName="TogglePublish"
                        CommandArgument='<%# Eval("examId") %>' />

                    <asp:Button ID="btnQuestions"
                        runat="server"
                        Text="Questions"
                        CommandName="Questions"
                        CommandArgument='<%# Eval("examId") %>'
                        CssClass="btn btn-info btn-sm" />

                </ItemTemplate>
            </asp:TemplateField>

        </Columns>

    </asp:GridView>
</asp:Content>
