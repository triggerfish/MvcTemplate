<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<% using (Html.BeginForm("Index", "Search")) { %>
    <fieldset>
    <%= Html.TextBox("keyword") %><input type="submit" value="Search" />
    </fieldset>
<% } %>
