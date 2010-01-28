<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<MvcTemplate.Model.IGenre>>" %>
<div class="list">
    <ul>
    <% foreach (MvcTemplate.Model.IGenre g in Model.Results.Genres) { %>
        <li><%= Html.ActionLink(g)%></li>
    <% } %>
    </ul>
</div>