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



        public new string ToString()
        {
            return (PartnerToMyIdea ? "PartnerToMyIdea" : "") + (JoinOrBeJoined ? "JoinOrBeJoined" : "");
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