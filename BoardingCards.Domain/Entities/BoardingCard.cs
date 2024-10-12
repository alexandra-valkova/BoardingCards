using BoardingCards.Domain.Enums;

namespace BoardingCards.Domain.Entities
{
    public abstract class BoardingCard
    {
        /// <summary>
        /// The point of departure.
        /// </summary>
        public required string Origin { get; init; }

        /// <summary>
        /// The point of arrival.
        /// </summary>
        public required string Destination { get; init; }

        /// <summary>
        /// The mean of transportation (<see cref="BoardingCardType"/>).
        /// </summary>
        public abstract string Transportation { get; }

        /// <summary>
        /// Returns a description of the boarding card.
        /// </summary>
        /// <returns>Boarding card description.</returns>
        public abstract string GetDescription();

        public override string ToString()
        {
            return @$"{Transportation} from ""{Origin}"" to ""{Destination}"".";
        }
    }
}
