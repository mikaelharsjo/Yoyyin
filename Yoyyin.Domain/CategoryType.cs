using System.ComponentModel;

namespace Yoyyin.Domain
{
    public enum CategoryType
    {
        [Description("Duger din aff�rsid�? Vill du l�sa om andras? Kom in och dela med dig av dina id�er, och f� feedback p� dom fr�n andra medlemmar.")]
        BusinessIdeas,
        [Description("H�r beh�ver inte aff�rsid�en vara hundra genomt�nkt. Feedbacken ska vara positiv. F�rs�k g�rna f�rb�ttra aff�rsid�erna men s�g inte att dom �r d�liga.")]
        Friendly,
        [Description("H�r kan du st�lla valfria fr�gor kring t ex f�retagande, uppstart, aff�rsplan, partnerskap mm.")]
        Misc
    };
}