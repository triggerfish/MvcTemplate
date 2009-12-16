<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<% using (Html.BeginForm()) { %>
    <%= Html.TextBox("keyword") %><input type="submit" value="Search" /><br />
<% } %>
