using System.ComponentModel;

namespace Yoyyin.Model.Users.Enumerations
{
    public enum UserTypes
    {
        [Description("Jag söker efter en person som kan starta upp och driva företag.")]
        Entrepreneur,
        [Description("Jag söker efter folk med idéer som de vill förverkliga.")]
        Innovator,
        [Description("Jag söker efter spännande idéer och företag att investera i.")]
        Investor,
        [Description("Jag söker efter personer med kunskap och kapital att investera i min idé eller företag.")]
        Financing,
        [Description("Jag söker efter personer med kunskap och kapital att investera i min idé eller företag.")]
        Retiring,
        [Description("Jag söker kompetenser och delägare till min verksamhet.")]
        Businessman
    }
}