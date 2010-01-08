<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcTemplate.Web.ViewData>" %>

<asp:Content ID="Title" ContentPlaceHolderID="MainTitle" runat="server">Login</asp:Content>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Login</h2>
    <p><%= Html.ValidationSummary() %></p>
    <% using (Html.BeginForm()) { %>
    <fieldset>
        <label for="Email">Email:</label><%= Html.TextBox("Email")%><br />
        <label for="Password">Password:</label><%= Html.Password("Password")%><br />
        <input type="submit" value="Login" />
    </fieldset>
    <% } %>    
</asp:Content>
