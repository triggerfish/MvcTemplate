<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<GenreViewData>" %>

<asp:Content ID="Title" ContentPlaceHolderID="PageTitle" runat="server">
Genre: <%= Html.Encode(Model.SelectedGenre) %>
</asp:Content>

<asp:Content ID="Content" ContentPlaceHolderID="PageContent" runat="server">
<h2>Genre: <%= Html.Encode(Model.SelectedGenre) %></h2>
<% Html.RenderPartial("ArtistList", Model.Artists); %>
</asp:Content>
