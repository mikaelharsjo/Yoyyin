using System;
using System.Collections.Generic;
using System.Web.Routing;
using Yoyyin.Domain;
using Yoyyin.Domain.Services;

namespace Yoyyin.Web.Helpers
{
    public class RouteHelper
    {
        private readonly CachedItemProvider<IEnumerable<IUser>> _cachedItemProvider;
        private readonly IUserService _userService;
        private const string CacheKey = "AllUsersKey";

        public RouteHelper(CachedItemProvider<IEnumerable<IUser>> cachedUsers, IUserService userService)
        {
            _cachedItemProvider = cachedUsers;
            _userService = userService;
        }

        public void AddRoutes()
        {
            AddStaticRoutes();
            var users = _cachedItemProvider.GetItem(CacheKey, new Func<IEnumerable<IUser>>(_userService.GetAllUsers));
            foreach (var user in users)
            {
                if (string.IsNullOrEmpty(user.GetDisplayName())) continue;

                try
                {
                    RouteTable.Routes.MapPageRoute(user.Name, user.Name, "~/Member.aspx", false,
                                                   new RouteValueDictionary {{"UserID", user.UserId.ToString()}});
                }
                catch
                {
                }
            }
        }

        private static void AddStaticRoutes()
        {
            RouteTable.Routes.MapPageRoute("Hitta_en_affärspartner", "Hitta_en_affärspartner", "~/About.aspx");
            RouteTable.Routes.MapPageRoute("Dokument_och_mallar", "Dokument_och_mallar", "~/Tools.aspx");
            RouteTable.Routes.MapPageRoute("Forum", "Forum", "~/Questions.aspx");
            RouteTable.Routes.MapPageRoute("Kalender", "Kalender", "~/Calendar.aspx");
            RouteTable.Routes.MapPageRoute("Mötesplatsen_för_affärspartners_Yoyyin", "Mötesplatsen_för_affärspartners_Yoyyin", "~/Default.aspx");
            RouteTable.Routes.MapPageRoute("links_foretagare_entreprenorer", "links_foretagare_entreprenorer", "~/Links.aspx");
            RouteTable.Routes.MapPageRoute("partners_branscher", "partners_branscher", "~/Members.aspx");
        }
    }
}