<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<AccountViewData>" %>

<asp:Content ID="Title" ContentPlaceHolderID="MainTitle" runat="server">Login</asp:Content>

<asp:Content ID="Scripts" ContentPlaceHolderID="Scripts" runat="server">
	<script src="<%= Url.Script("jquery-1.3.2.min.js") %>" type="text/javascript"></script>
	<script src="<%= Url.Script("jquery.validate-1.5.5.min.js") %>" type="text/javascript"></script>
	<script src="<%= Url.Script("xVal.jquery.validate-1.0.js") %>" type="text/javascript"></script>
</asp:Content>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Login</h2>
    <p><%= Html.ValidationSummary("Unable to login:") %></p>
    <% using (Html.BeginForm()) { %>
    <fieldset>
        <div class="row"><label for="Email">Email:</label><%= Html.TextBox("Email")%></div>
        <div class="row"><label for="Password">Password:</label><%= Html.Password("Password")%></div>
    </fieldset>
    <fieldset>
        <%= Html.AntiForgeryToken() %>
        <div class="align-inputs"><input type="submit" value="Login" /><a href="<%= Model.CancelUrl%>">Cancel</a></div>
        <div class="align-inputs"><span>Not registered? </span><%= Html.RouteLink("Register", RouteHelpers.RegisterRoute(Model.ReturnUrl)) %></div>
    </fieldset>
    <% } %>    
    <%--<%= Html.ClientSideValidation<MvcTemplate.Model.IUserCredentials>(null) %>--%>
</asp:Content>
