<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ViewData>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainTitle" runat="server">Register</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Register</h2>
    <% using (Html.BeginForm()) { %>
    <fieldset>
        <legend>Required Details</legend>
        <div class="row"><label for="Email">Email:</label><%= Html.TextBox("Email")%><%= Html.ValidationMessage("Email") %></div>
        <div class="row"><label for="Forename">Forename:</label><%= Html.TextBox("Forename")%><%= Html.ValidationMessage("Forename") %></div>
        <div class="row"><label for="Password">Password:</label><%= Html.Password("Password")%><%= Html.ValidationMessage("Password") %></div>
    </fieldset>
    <fieldset>
        <legend>Optional Details</legend>
        <div class="row"><label for="Surname">Surname:</label><%= Html.TextBox("Surname")%><%= Html.ValidationMessage("Surname") %></div>
    </fieldset>
    <fieldset>
        <div id="submit-row"><input type="submit" value="Register" /><a href="<%= ViewData["returnUrl"]%>">Cancel</a></div>
    </fieldset>
    <% } %>
    <%= Html.ClientSideValidation<MvcTemplate.Model.IUser>(null) %>
</asp:Content>
