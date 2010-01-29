<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ViewData>" %>
<% if (Model.DisplayAuthLinks) { %>
    <% if (HttpContext.Current.User.Identity.IsAuthenticated) { %>
    <% using (Html.BeginForm(RouteHelpers.LogoutRoute(Request.Url.PathAndQuery))) { %>
    <fieldset>
    <input type="submit" value="Logout" /><%= Html.AntiForgeryToken() %>
    </fieldset>
    <% } %>
    <% } else { %>
    <%= Html.RouteLink("Login", RouteHelpers.LoginRoute(Request.Url.PathAndQuery))%>&nbsp;|&nbsp;<%= Html.RouteLink("Register", RouteHelpers.RegisterRoute(Request.Url.PathAndQuery))%>
    <% } %>
<% } %>
