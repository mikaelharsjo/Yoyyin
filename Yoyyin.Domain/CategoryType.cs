using System.ComponentModel;

namespace Yoyyin.Domain
{
    public enum CategoryType
    {
        [Description("Duger din affärsidé? Vill du läsa om andras? Kom in och dela med dig av dina idéer, och få feedback på dom från andra medlemmar.")]
        BusinessIdeas,
        [Description("Här behöver inte affärsidéen vara hundra genomtänkt. Feedbacken ska vara positiv. Försök gärna förbättra affärsidéerna men säg inte att dom är dåliga.")]
        Friendly,
        [Description("Här kan du ställa valfria frågor kring t ex företagande, uppstart, affärsplan, partnerskap mm.")]
        Misc
    };
}