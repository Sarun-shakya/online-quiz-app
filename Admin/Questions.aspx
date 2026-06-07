<%@ Page Title="Questions" Language="C#" MasterPageFile="~/Admin/Admin.Master"
    AutoEventWireup="true" CodeBehind="Questions.aspx.cs"
    Inherits="Online_Quiz_Application.Admin.Questions" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="AdminContent" runat="server">

    <div class="container mt-4">

        <h2 class="mb-2">Add Question</h2>

        <asp:Label ID="lblExam"
            runat="server"
            CssClass="fw-bold text-primary d-block mb-3">
        </asp:Label>

        <!-- Form -->
        <div class="card shadow-sm p-4 mb-4">

            <!-- Question -->
            <div class="mb-3">
                <label class="form-label">Question</label>
                <asp:TextBox ID="txtQuestion"
                    runat="server"
                    CssClass="form-control"
                    TextMode="MultiLine"
                    Rows="3"
                    Placeholder="Enter question">
                </asp:TextBox>
            </div>

            <!-- Option A -->
            <div class="mb-3">
                <label class="form-label">Option A</label>
                <asp:TextBox ID="txtA" runat="server"
                    CssClass="form-control" />
            </div>

            <!-- Option B -->
            <div class="mb-3">
                <label class="form-label">Option B</label>
                <asp:TextBox ID="txtB" runat="server"
                    CssClass="form-control" />
            </div>

            <!-- Option C -->
            <div class="mb-3">
                <label class="form-label">Option C</label>
                <asp:TextBox ID="txtC" runat="server"
                    CssClass="form-control" />
            </div>

            <!-- Option D -->
            <div class="mb-3">
                <label class="form-label">Option D</label>
                <asp:TextBox ID="txtD" runat="server"
                    CssClass="form-control" />
            </div>

            <!-- Correct Answer (IMPORTANT FIX) -->
            <div class="mb-3">
                <label class="form-label">Correct Answer</label>

                <asp:DropDownList ID="ddlAnswer"
                    runat="server"
                    CssClass="form-select">

                    <asp:ListItem Text="Select Answer" Value="" />
                    <asp:ListItem Text="A" Value="A" />
                    <asp:ListItem Text="B" Value="B" />
                    <asp:ListItem Text="C" Value="C" />
                    <asp:ListItem Text="D" Value="D" />

                </asp:DropDownList>

            </div>

            <!-- Button -->
            <asp:Button ID="btnAddQuestion"
                runat="server"
                Text="Add Question"
                CssClass="btn btn-primary"
                OnClick="btnAddQuestion_Click" />

            <asp:Label ID="lblMsg"
                runat="server"
                CssClass="d-block mt-3 text-success fw-bold">
            </asp:Label>

        </div>

        <!-- EXISTING QUESTIONS -->
        <h3 class="mb-3">Existing Questions</h3>

        <asp:GridView ID="GridView1"
            runat="server"
            CssClass="table table-bordered table-hover"
            AutoGenerateColumns="False"
            OnRowCommand="GridView1_RowCommand">

            <HeaderStyle CssClass="table-dark text-white" />

            <Columns>

                <asp:TemplateField HeaderText="SN">
                    <ItemTemplate>
                        <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:BoundField DataField="questionText"
                    HeaderText="Question" />

                <asp:BoundField DataField="optionA" HeaderText="A" />
                <asp:BoundField DataField="optionB" HeaderText="B" />
                <asp:BoundField DataField="optionC" HeaderText="C" />
                <asp:BoundField DataField="optionD" HeaderText="D" />

                <asp:BoundField DataField="correctAnswer"
                    HeaderText="Answer" />

                <asp:TemplateField HeaderText="Actions">

                    <ItemTemplate>

                        <asp:Button ID="btnEdit"
                            runat="server"
                            Text="Edit"
                            CssClass="btn btn-warning btn-sm"
                            CommandName="UpdateQuestion"
                            CommandArgument='<%# Eval("questionId") %>' />

                        <asp:Button ID="btnDelete"
                            runat="server"
                            Text="Delete"
                            CssClass="btn btn-danger btn-sm"
                            CommandName="DeleteQuestion"
                            CommandArgument='<%# Eval("questionId") %>'
                            OnClientClick="return confirm('Delete this question?');" />

                    </ItemTemplate>

                </asp:TemplateField>

            </Columns>

        </asp:GridView>

    </div>

</asp:Content>