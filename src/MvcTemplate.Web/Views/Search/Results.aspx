<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SearchViewData>" %>

<asp:Content ID="Title" ContentPlaceHolderID="MainTitle" runat="server">Search Results</asp:Content>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
<h2>Search Results</h2>
<% Html.RenderPartial("SearchForm"); %>
<br />
<% 
    bool bHaveArtists = (Model.HasArtists);
    bool bHaveGenres = (Model.HasGenres);
%>
<% if (!bHaveArtists && !bHaveGenres) { %>
    <p>No search results</p>   
<% } else { %>
<% if (bHaveArtists) { %>
    <h2>Artists</h2>
    <% Html.RenderPartial("ArtistList", Model.Results.Artists); %>
<% } %>
<% if (bHaveGenres) { %>
    <h2>Genres</h2>
    <% Html.RenderPartial("GenreList", Model.Results.Genres); %>
<% }
} %>
</asp:Content>
