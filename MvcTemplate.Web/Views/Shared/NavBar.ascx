<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Hyperlink>>" %>
<ul>
<% 
foreach (Hyperlink l in Model) 
{ %>
    <%= Html.RouteLink(l) %>
<%
} %>
</ul>