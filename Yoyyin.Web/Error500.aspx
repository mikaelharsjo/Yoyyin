﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Error500.aspx.cs" Inherits="Yoyyin.Web.Error500" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="span-11 textAlignRight">
        <img src="Styles/Images/error.png" alt="Desperation" />
    </div>
    <div class="span-1">&nbsp;</div>
    <div class="span-12 last">
        <div class="gigantic marginTop">500</div>
        <div class="marginTop"><h1>Hoppsan! Sidan kunde inte laddas</h1></div>
        <p>Ett fel har uppstått. Vi ber om ursäkt för detta. Supportpersonal har automatiskt blivit underrättade om detta. Om du vil kan du beskriva vad du gjorde för att få felet nedan:</p>
        <p><a href="Default.aspx">Tillbaka till startsidan</a></p>
        <asp:Literal ID="litError" runat="server" />       
    </div>
</asp:Content>
