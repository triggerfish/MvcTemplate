<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ViewData>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainTitle" runat="server">Register</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Register</h2>
    <% using (Html.BeginForm()) { %>
    <fieldset>
        <label for="Forename">Forename:</label><%= Html.TextBox("Forename")%>&nbsp;<%= Html.ValidationMessage("Forename") %><br />
        <label for="Surname">Surname:</label><%= Html.TextBox("Surname")%>&nbsp;<%= Html.ValidationMessage("Surname")%><br />
        <label for="Email">Email:</label><%= Html.TextBox("Email")%>&nbsp;<%= Html.ValidationMessage("Email")%><br />
        <label for="Password">Password:</label><%= Html.Password("Password")%>&nbsp;<%= Html.ValidationMessage("Password")%><br />
        <input type="submit" value="Register" />
    </fieldset>
    <% } %>
</asp:Content>
