<%@ Page Title="Take Exam" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="TakeExam.aspx.cs"
    Inherits="Online_Quiz_Application.TakeExam" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container mt-5 pt-3 mb-4">

        <div class="card shadow-lg border-0">

            <div class="card-header bg-primary text-white">
                <h2 class="mb-0">Take Exam</h2>
            </div>

            <div class="card-body">

                <asp:Label ID="lblExamName"
                    runat="server"
                    CssClass="h4 text-primary fw-bold d-block mb-4">
                </asp:Label>

                <div class="mb-3 text-end">
                    <h5 class="text-danger fw-bold">
                        Time Left: <span id="timer">00:00</span>
                    </h5>
                </div>

                <asp:Repeater ID="rptQuestions" runat="server">

                    <ItemTemplate>

                        <div class="card mb-4 shadow-sm border">

                            <div class="card-body">

                                <h5 class="fw-bold mb-3">
                                    <%# Container.ItemIndex + 1 %>.
                                    <%# Eval("questionText") %>
                                </h5>

                                <div class="d-grid gap-2">

                                    <!-- Option A -->
                                    <input type="radio"
                                        class="btn-check"
                                        name='q<%# Eval("questionId") %>'
                                        id='q<%# Eval("questionId") %>A'
                                        value="A" />

                                    <label class='btn <%# GetOptionClass(
                                        Eval("questionId").ToString(),
                                        "A",
                                        Eval("correctAnswer").ToString()) %> text-start'
                                        for='q<%# Eval("questionId") %>A'>
                                        A. <%# Eval("optionA") %>
                                    </label>

                                    <!-- Option B -->
                                    <input type="radio"
                                        class="btn-check"
                                        name='q<%# Eval("questionId") %>'
                                        id='q<%# Eval("questionId") %>B'
                                        value="B" />

                                    <label class='btn <%# GetOptionClass(
                                        Eval("questionId").ToString(),
                                        "B",
                                        Eval("correctAnswer").ToString()) %> text-start'
                                        for='q<%# Eval("questionId") %>B'>
                                        B. <%# Eval("optionB") %>
                                    </label>

                                    <!-- Option C -->
                                    <input type="radio"
                                        class="btn-check"
                                        name='q<%# Eval("questionId") %>'
                                        id='q<%# Eval("questionId") %>C'
                                        value="C" />

                                    <label class='btn <%# GetOptionClass(
                                        Eval("questionId").ToString(),
                                        "C",
                                        Eval("correctAnswer").ToString()) %> text-start'
                                        for='q<%# Eval("questionId") %>C'>
                                        C. <%# Eval("optionC") %>
                                    </label>

                                    <!-- Option D -->
                                    <input type="radio"
                                        class="btn-check"
                                        name='q<%# Eval("questionId") %>'
                                        id='q<%# Eval("questionId") %>D'
                                        value="D" />

                                    <label class='btn <%# GetOptionClass(
                                        Eval("questionId").ToString(),
                                        "D",
                                        Eval("correctAnswer").ToString()) %> text-start'
                                        for='q<%# Eval("questionId") %>D'>
                                        D. <%# Eval("optionD") %>
                                    </label>

                                </div>

                            </div>

                        </div>

                    </ItemTemplate>

                </asp:Repeater>

                <div class="text-center mt-4">

                    <asp:Button ID="btnSubmit"
                        runat="server"
                        Text="Submit Exam"
                        CssClass="btn btn-success btn-lg px-5"
                        OnClick="btnSubmit_Click"
                        onClientClick="stopTimer();"
                        Visible="true" />

                    <asp:Button ID="btnExplore"
                        runat="server"
                        Text="Explore Exams"
                        CssClass="btn btn-success btn-lg px-5"
                        OnClick="btnExplore_Click"
                        Visible="false" />

                </div>

                <div class="text-center mt-3">

                    <asp:Label ID="lblResult"
                        runat="server"
                        CssClass="fw-bold fs-5 text-success">
                    </asp:Label>

                </div>

            </div>

        </div>

    </div>

    <script type="text/javascript">

        let totalSeconds = 60 * <%= ViewState["Duration"] %>;
        let interval;

        function startTimer() {

            let timer = document.getElementById("timer");

            interval = setInterval(function () {

                let minutes = Math.floor(totalSeconds / 60);
                let seconds = totalSeconds % 60;

                timer.innerHTML =
                    (minutes < 10 ? "0" + minutes : minutes) + ":" +
                    (seconds < 10 ? "0" + seconds : seconds);

                totalSeconds--;

                if (totalSeconds < 0) {

                    clearInterval(interval);

                    alert("Time is up! Submitting exam...");

                    document.getElementById("<%= btnSubmit.ClientID %>").click();
            }

        }, 1000);
    }

    function stopTimer() {
        clearInterval(interval);
    }

    window.onload = function () {

        var submitted = '<%= ViewState["ExamSubmitted"] ?? false %>';

            if (submitted !== 'True') {
                startTimer();
            }
        };

    </script>

</asp:Content>
