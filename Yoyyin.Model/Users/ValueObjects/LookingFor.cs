namespace Yoyyin.Model.Users.ValueObjects
{
    public class LookingFor
    {
        public LookingFor()
        {
            JoinOrBeJoined = true;
        }

        public bool PartnerToMyIdea { get; set; }
        public bool IdeasToJoin { get; set; }
        public bool JoinOrBeJoined { get; set; }
        public bool Investements { get; set; }
        public bool Financing { get; set; }

        public new string Description()
        {
            return (PartnerToMyIdea ? "letar efter en partner til min idé" : "") + (JoinOrBeJoined ? "har en idé men är öppen för att delta i andras också" : "") + (IdeasToJoin ? "letar efter idéer att delta i" : "") + (Investements ? "har pengar att investera i bra affärsidéer" : "");
        }

        public bool MatchWith(LookingFor lookingFor)
        {
            bool match = false;
            if (PartnerToMyIdea)
            {
                match = lookingFor.IdeasToJoin || lookingFor.JoinOrBeJoined;
            }
 
            if (IdeasToJoin)
            {
                match = match || lookingFor.PartnerToMyIdea;
            }

            if (JoinOrBeJoined)
            {
                match = match || lookingFor.PartnerToMyIdea || IdeasToJoin || JoinOrBeJoined;
            }

            if (Investements)
            {
                match = match || lookingFor.Financing;
            }

            if (Financing)
            {
                match = match || lookingFor.Investements;
            }

            return match;
        }
    }
}