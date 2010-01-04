<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<MvcTemplate.Model.IArtist>>" %>
<div class="list">
    <ul>
    <% foreach (MvcTemplate.Model.IArtist a in Model) { %>
	    <li><%= Html.ActionLink(a) %></li>
    <% } %>
    </ul>
</div>