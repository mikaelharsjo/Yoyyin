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
            return (PartnerToMyIdea ? "letar efter en partner til min id�" : "") + (JoinOrBeJoined ? "har en id� men �r �ppen f�r att delta i andras ocks�" : "") + (IdeasToJoin ? "letar efter id�er att delta i" : "") + (Investements ? "har pengar att investera i bra aff�rsid�er" : "");
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