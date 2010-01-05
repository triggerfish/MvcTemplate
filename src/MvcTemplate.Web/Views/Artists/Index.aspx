<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ArtistsViewData>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainTitle" runat="server">All Artists</asp:Content>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
<h2>All Artists</h2>
<% Html.RenderPartial("ArtistList", Model.Artists); %>
</asp:Content>