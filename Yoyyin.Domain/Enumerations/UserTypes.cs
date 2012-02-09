using System.ComponentModel;

namespace Yoyyin.Domain.Enumerations
{
    public enum UserTypes
    {
        [Description("Jag s�ker efter en person som kan starta upp och driva f�retag.")]
        Entrepreneur,
        [Description("Jag s�ker efter folk med id�er som de vill f�rverkliga.")]
        Innovator,
        [Description("Jag s�ker efter sp�nnande id�er och f�retag att investera i.")]
        Investor,
        [Description("Jag s�ker efter personer med kunskap och kapital att investera i min id� eller f�retag.")]
        Financing,
        [Description("Jag s�ker efter personer som kan ta �ver mitt f�retag d� jag g�r i pension snart.")]
        Retiring,
        [Description("Jag s�ker kompetenser och del�gare till min verksamhet.")]
        Businessman
    }
}