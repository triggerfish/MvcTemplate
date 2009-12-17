<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ArtistViewData>" %>

<asp:Content ID="Title" ContentPlaceHolderID="PageTitle" runat="server">
<%= Model.Artist.Name %>
</asp:Content>

<asp:Content ID="Content" ContentPlaceHolderID="PageContent" runat="server">
<h2><%= Model.Artist.Name %></h2>
<div class="table">
    <table>
        <tr>
            <td class="label">Formed:</td>
            <td><%= Model.Artist.Formed.ToString("D") %></td>
        </tr>
        <tr>
            <td class="label">Number Ones:</td>
            <td><%= Model.Artist.NumberOnes %></td>
        </tr>
    </table>
</div>
</asp:Content>
