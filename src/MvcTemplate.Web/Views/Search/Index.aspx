<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SearchViewData>" %>

<asp:Content ID="Title" ContentPlaceHolderID="MainTitle" runat="server">Search</asp:Content>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
<h2>Search</h2>
<% Html.RenderPartial("SearchForm"); %>
</asp:Content>
