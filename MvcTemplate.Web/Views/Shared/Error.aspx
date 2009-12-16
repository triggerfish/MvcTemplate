<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ErrorViewData>" %>

<asp:Content ID="Title" ContentPlaceHolderID="PageTitle" runat="server">
Error
</asp:Content>

<asp:Content ID="Content" ContentPlaceHolderID="PageContent" runat="server">
<h2>Error</h2>
<%= Model.Exception.Message %>
</asp:Content>
