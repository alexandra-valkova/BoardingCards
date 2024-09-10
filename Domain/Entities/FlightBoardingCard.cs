namespace Domain.Entities
{
    public class FlightBoardingCard : BoardingCard
    {
        public override string Transportation => "flight";

        /// <summary>
        /// The flight number.
        /// </summary>
        public required string Number { get; init; }

        /// <summary>
        /// The flight gate.
        /// </summary>
        public required string Gate { get; init; }

        /// <summary>
        /// The seat assignment.
        /// </summary>
        public required string Seat { get; init; }

        /// <summary>
        /// Additional information about baggage drop.
        /// </summary>
        public required string Baggage { get; init; }

        public override string GetDescription()
        {
            return $"Take the {Transportation} {Number} from {Origin} to {Destination}. Gate {Gate}. Seat {Seat}. Baggage {Baggage}.";
        }
    }
}
