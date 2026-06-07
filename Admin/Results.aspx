<%@ Page Title="Results" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Results.aspx.cs" Inherits="Online_Quiz_Application.Admin.Results" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="AdminContent" runat="server">

    <h2>Manage Results</h2>
    <p>Here, you can manage results of exmas given by users</p>
    <asp:GridView ID="resultsGrid" runat="server"
    CssClass="table table-bordered "
    AutoGenerateColumns="False">
    <HeaderStyle CssClass="table-dark" />

    <Columns>

   
        <asp:TemplateField HeaderText="SN">
            <ItemTemplate>
                <%# Container.DataItemIndex + 1 %>
            </ItemTemplate>
        </asp:TemplateField>

   
        <asp:BoundField DataField="fullName" HeaderText="Full Name" />
        <asp:BoundField DataField="name" HeaderText="Exam" />
        <asp:BoundField DataField="score" HeaderText="Score" />
        <asp:BoundField DataField="examDate" HeaderText="Exam Date"
            DataFormatString="{0:yyyy-MM-dd}" />

    </Columns>

</asp:GridView>

</asp:Content>
