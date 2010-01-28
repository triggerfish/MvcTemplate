<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<NavBarWidget>" %>
<% IEnumerable<Hyperlink> links = Model.GenerateHyperlinks(); %>
<% if (null != links) { %>
<ul>
<% foreach (Hyperlink l in links) { %>
    <% if (l.IsSelected) { %>
        <li><strong><%= l.Text %></strong></li>
    <% } else { %>
        <li><%= Html.RouteLink(l)%></li>
    <% } %>
<% } %>
</ul>
<% } %>