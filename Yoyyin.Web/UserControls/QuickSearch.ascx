<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="QuickSearch.ascx.cs"
    Inherits="Yoyyin.Web.UserControls.QuickSearch" %>
<%@ Register Src="~/UserControls/UserImage.ascx" TagPrefix="yoyyin" TagName="UserImage" %>
<%@ Register Src="~/UserControls/Users.ascx" TagPrefix="yoyyin" TagName="Users" %>

<div style="text-align: right;">
    <a id="lnkShowMap" runat="server" clientidmode="Static">
        <img src="../Styles/Images/world.png" />&nbsp;&nbsp;<span id="mapSpan">Dölj kartan</span></a></div>
<div id="map_canvas" runat="server" clientidmode="Static" class="span-24 last marginBottomLarge border"
    style="height: 400px; display: block;">
</div>
<asp:Literal ID="litNoHits" runat="server" />
<div class="extra">
    &nbsp;</div>
<div class="span-24 last marginBottom">
    <yoyyin:Users ID="usersControl" runat="server" />
        
    <script type="text/javascript">
        $(document).ready(function () {            

            <%= MapCoords %>

            var searchCount = document.getElementById('searchCount');
            if (searchCount != null)            
                searchCount.innerHTML = $("#hiddenCount").val();                        

            $("#lnkShowMap").click(function () {
                $("#map_canvas").slideToggle();
                if ($("#mapSpan").html() == "Dölj kartan")
                    $("#mapSpan").html("Visa kartan");
                 
                else 
                    $("#mapSpan").html("Dölj kartan");             
            });

            $(".secretLink").click(function () {
                return false;
            });

            var config = {
                over: ShowSecret, // function = onMouseOver callback (REQUIRED)    
                timeout: 4000, // number = milliseconds delay before onMouseOut    
                out: HideSecret // function = onMouseOut callback (REQUIRED)    
            };

            $(".secretLink").hoverIntent(config);

            function ShowSecret(e) {
                PopSecret(e);
            }
            function HideSecret() {
                $("#dialog").hide();
                $("#dialogArrow").hide();
            }            
        });
    </script>
    <input type="hidden" id="hiddenCount" runat="server" clientidmode="Static" />
    <div class="extra">
        &nbsp;</div>
</div>
