namespace Domain.Entities
{
    public class BusBoardingCard : BoardingCard
    {
        public override string Transportation => "airport bus";

        public override string GetDescription()
        {
            return $"Take the {Transportation} from {Origin} to {Destination}. No seat assignment.";
        }
    }
}
