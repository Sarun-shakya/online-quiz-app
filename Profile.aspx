<%@ Page Title="Profile" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Profile.aspx.cs"
    Inherits="Online_Quiz_Application.Profile" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container py-5">

        <h2 class="mb-4 fw-bold">My Profile</h2>

        <!-- User Details -->
        <div class="card shadow border-0 mb-4">
            <div class="card-header bg-primary text-white">
                <h5 class="mb-0">Personal Information</h5>
            </div>

            <div class="card-body">

                <div class="row mb-3">
                    <div class="col-md-3 fw-bold">Full Name</div>
                    <div class="col-md-9">
                        <asp:Label ID="lblName" runat="server" />
                    </div>
                </div>

                <div class="row mb-3">
                    <div class="col-md-3 fw-bold">Email</div>
                    <div class="col-md-9">
                        <asp:Label ID="lblEmail" runat="server" />
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-3 fw-bold">Member Since</div>
                    <div class="col-md-9">
                        <asp:Label ID="lblCreatedAt" runat="server" />
                    </div>
                </div>

            </div>
        </div>

        <!-- Exam History -->
        <div class="card shadow border-0">

            <div class="card-header bg-success text-white">
                <h5 class="mb-0">Exam History</h5>
            </div>

            <div class="card-body">

                <asp:GridView ID="gvResults"
                    runat="server"
                    CssClass="table table-striped table-hover"
                    AutoGenerateColumns="False">

                    <Columns>

                        <asp:BoundField DataField="ExamName"
                            HeaderText="Exam Name" />

                        <asp:BoundField DataField="ObtainedMarks"
                            HeaderText="Obtained Marks" />

                        <asp:BoundField DataField="FullMarks"
                            HeaderText="Full Marks" />

                        <asp:BoundField DataField="ExamDate"
                            HeaderText="Date Taken"
                            DataFormatString="{0:dd MMM yyyy HH:mm}" />

                    </Columns>

                </asp:GridView>

            </div>

        </div>

    </div>

</asp:Content>
