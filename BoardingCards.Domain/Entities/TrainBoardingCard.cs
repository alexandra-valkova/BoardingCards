namespace BoardingCards.Domain.Entities
{
    public class TrainBoardingCard : BoardingCard
    {
        public override string Transportation => "train";

        /// <summary>
        /// The train number.
        /// </summary>
        public required string Number { get; init; }

        /// <summary>
        /// The seat assignment.
        /// </summary>
        public required string Seat { get; init; }

        public override string GetDescription()
        {
            return $"Take the {Transportation} {Number} from {Origin} to {Destination}. Seat {Seat}.";
        }
    }
}
