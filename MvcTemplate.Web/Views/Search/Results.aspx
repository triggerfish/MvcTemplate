<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SearchViewData>" %>

<asp:Content ID="Title" ContentPlaceHolderID="PageTitle" runat="server">Search Results</asp:Content>

<asp:Content ID="Content" ContentPlaceHolderID="PageContent" runat="server">
<h2>Search Results</h2>
<% Html.RenderPartial("SearchForm"); %>
<br />
<% 
    bool bHaveArtists = (Model.Results.Artists.Any());
    bool bHaveGenres = (Model.Results.Genres.Any());
%>
<% if (!bHaveArtists && !bHaveGenres) { %>
    <p>No search results</p>   
<% } else { %>
<% if (bHaveArtists) { %>
    <h2>Artists</h2>
    <div class="list">
        <ul>
        <% foreach (MvcTemplate.Model.IArtist a in Model.Results.Artists) { %> 
            <li><%= Html.ActionLink(a)%></li>
        <% } %>
        </ul>
    </div>
<% } %>
<% if (bHaveGenres) { %>
    <h2>Genres</h2>
    <div class="list">
        <ul>
        <% foreach (MvcTemplate.Model.IGenre g in Model.Results.Genres) { %>
            <li><%= Html.ActionLink(g)%></li>
        <% } %>
        </ul>
    </div>
<% }
} %>
</asp:Content>
