<%@ Page Title="Users" Language="C#" MasterPageFile="~/Admin/Admin.Master"
AutoEventWireup="true" CodeBehind="Users.aspx.cs"
Inherits="Online_Quiz_Application.Admin.Users" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="AdminContent" runat="server">

<div class="container ">

    <h2>Manage Users</h2>
    <p>Here, you can manage users and also delete them</p>

    <asp:GridView ID="usersGrid" runat="server"
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
            <asp:BoundField DataField="email" HeaderText="Email" />
            <asp:BoundField DataField="createdAt" HeaderText="Joined At"
                DataFormatString="{0:yyyy-MM-dd}" />

            <asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>
                        <asp:Button ID="btnDelete"
                            runat="server"
                            Text="Delete"
                            CssClass="btn btn-danger btn-sm"
                            CommandArgument='<%# Eval("userId") %>'
                            OnClick="btnDelete_Click"
                            OnClientClick="return confirm('Delete this user?');" />
                    </ItemTemplate>
            </asp:TemplateField>

        </Columns>

    </asp:GridView>

</div>

</asp:Content>