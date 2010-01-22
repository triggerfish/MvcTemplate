<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcTemplate.Web.ViewData>" %>

<asp:Content ID="Title" ContentPlaceHolderID="MainTitle" runat="server">Top Secret!</asp:Content>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Top Secret</h2>
    <p>This page can only be viewed by registered members</p>
</asp:Content>
