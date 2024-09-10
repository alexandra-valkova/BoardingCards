using System.Text;
using Domain.Entities;

namespace Domain.Extensions
{
    /// <summary>
    /// Extension methods for representing a collection of <see cref="BoardingCard"/> as string.
    /// </summary>
    public static class BoardingCardsStringExtensions
    {
        /// <summary>
        /// Returns a string representation of the boarding cards collection.
        /// </summary>
        /// <param name="boardingCards">The boarding cards that need to be represented as a string.</param>
        /// <returns>A string representation.</returns>
        public static string AsString(this IEnumerable<BoardingCard> boardingCards)
        {
            return boardingCards.GetString((BoardingCard card) => card.ToString());
        }

        /// <summary>
        /// Returns a summary of the boarding cards collection.
        /// </summary>
        /// <param name="boardingCards">The boarding cards that need to be represented as a summary.</param>
        /// <returns>A boarding cards summary.</returns>
        public static string GetSummary(this IEnumerable<BoardingCard> boardingCards)
        {
            string summary = boardingCards.GetString((BoardingCard card) => card.GetDescription());

            if (!string.IsNullOrEmpty(summary)) summary += "You have arrived at your final destination.";

            return summary;
        }

        private static string GetString(this IEnumerable<BoardingCard> boardingCards, Func<BoardingCard, string> stringFormatter)
        {
            ArgumentNullException.ThrowIfNull(boardingCards);

            if (!boardingCards.Any()) return string.Empty;

            StringBuilder summary = new();

            foreach (BoardingCard card in boardingCards)
            {
                summary.AppendLine(stringFormatter(card));
            }

            return summary.ToString();
        }
    }
}
