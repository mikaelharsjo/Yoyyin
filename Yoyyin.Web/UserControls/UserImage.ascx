<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserImage.ascx.cs" Inherits="Yoyyin.Web.UserControls.UserImage" EnableViewState="false" %>
<%@ Import Namespace="Yoyyin.Web.Helpers" %>

<%@ Register Assembly="Microsoft.Web.GeneratedImage" Namespace="Microsoft.Web" TagPrefix="cc1" %>

<a runat="server" id="lnkUser">
    <cc1:GeneratedImage ID="generatedImage" runat="server" CssClass="imageBorder"
        ImageHandlerUrl="~/Handlers/ImageHandler.ashx" GenerateEmptyAlternateText="true">
    </cc1:GeneratedImage>

    <%= FacebookImageMarkupProvider.GetMarkup() %>
</a>



