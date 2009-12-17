<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Hyperlink>>" %>
<ul>
<% foreach (Hyperlink l in Model) { %>
    <% if (l.IsSelected) { %>
        <li><strong><%= l.Text %></strong></li>
    <% } else { %>
        <li><%= Html.RouteLink(l)%></li>
    <% } %>
<% } %>
</ul>