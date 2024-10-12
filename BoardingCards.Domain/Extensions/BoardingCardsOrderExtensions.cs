using BoardingCards.Domain.Entities;
using BoardingCards.Domain.Exceptions;

namespace BoardingCards.Domain.Extensions
{
    /// <summary>
    /// Extension methods for ordering a collection of <see cref="BoardingCard"/>.
    /// </summary>
    public static class BoardingCardsOrderExtensions
    {
        /// <summary>
        /// Gets a collection of ordered boarding cards from unordered ones.
        /// </summary>
        /// <param name="boardingCards">The collection of unordered boarding cards.</param>
        /// <returns>A collection of ordered boarding cards.</returns>
        public static IReadOnlyCollection<BoardingCard> GetBoardingCardsInOrder(this IEnumerable<BoardingCard> boardingCards)
        {
            ArgumentNullException.ThrowIfNull(boardingCards);

            if (!boardingCards.Any()) return [];

            ICollection<BoardingCard> cardsInOrder = [];

            cardsInOrder.AddBoardingCardsInOrder(boardingCards.ToArray());

            return [.. cardsInOrder];
        }

        private static void AddBoardingCardsInOrder(this ICollection<BoardingCard> orderedCards,
                                                    ICollection<BoardingCard> unorderedCards)
        {
            ArgumentNullException.ThrowIfNull(orderedCards);
            ArgumentNullException.ThrowIfNull(unorderedCards);

            if (unorderedCards.Count == 0) return;

            BoardingCard currentCard;

            if (orderedCards.Count == 0)
            {
                BoardingCard? firstCard;

                try
                {
                    firstCard = unorderedCards.SingleOrDefault(b => !unorderedCards.Any(c => c.Destination == b.Origin));
                }
                catch (Exception)
                {
                    throw new MoreThanOneStartingPointBoardingCardException();
                }

                switch (firstCard)
                {
                    case not null:
                        orderedCards.Add(firstCard);
                        currentCard = firstCard;
                        break;
                    default:
                        throw new NoStartingPointBoardingCardException();
                }
            }

            else
            {
                currentCard = orderedCards.Last();
            }

            BoardingCard? nextCard;

            try
            {
                nextCard = unorderedCards.SingleOrDefault(card => card.Origin == currentCard.Destination);
            }
            catch (Exception)
            {
                throw new MoreThanOneNextCardMatchBoardingCardException();
            }

            switch (nextCard)
            {
                case not null when orderedCards.Count < unorderedCards.Count:
                    orderedCards.Add(nextCard);
                    orderedCards.AddBoardingCardsInOrder(unorderedCards);
                    break;
                case null when orderedCards.Count == unorderedCards.Count:
                    return;
                default:
                    throw new InconsistentBoardingCardException();
            }
        }
    }
}
