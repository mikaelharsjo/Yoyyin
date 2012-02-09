<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Users.ascx.cs" Inherits="Yoyyin.Web.UserControls.Users" %>
<%@ Register TagPrefix="yoyyin" TagName="UserImage" Src="~/UserControls/UserImage.ascx" %>
<asp:ListView ID="lstMembers" runat="server" ItemPlaceholderID="divContent">
    <LayoutTemplate>
        <div id="divContent" runat="server" class="marginTop" />
    </LayoutTemplate>
    <ItemTemplate>
        <div class="users">
            <div class="usersLeft">
                <yoyyin:UserImage ID="UserImage1" User='<%# Eval("User") %>' runat="server" Width="80" />
                <br />
                <a href='<%# Eval("ProfileUrl") %>'>
                    <%# Eval("DisplayName") %></a>
            </div>
            <div class="usersRight blueBox left" style="width: 770px;">
                <div>
                    <h2>
                        <%# Eval("Title") %></h2>
                    <p>
                        <%# Eval("Description") %></p>
                    <a href='<%# Eval("ProfileUrl") %>'>Läs mer/kontakta</a><br />
                    <a class="matchLink" data-id-userid='<%# Eval("UserID") %>'>Matcha</a>
                </div>
            </div>
        </div>
        <br class="clear" />
        <br />
    </ItemTemplate>
</asp:ListView>
