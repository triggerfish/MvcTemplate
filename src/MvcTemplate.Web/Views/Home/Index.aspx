﻿<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ViewData>" %>

<asp:Content ID="Title" ContentPlaceHolderID="MainTitle" runat="server">
<%= System.Web.Configuration.WebConfigurationManager.AppSettings["WebSiteName"] %>
</asp:Content>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
<h2>Home Page</h2>
<p>Welcome!</p>
</asp:Content>
