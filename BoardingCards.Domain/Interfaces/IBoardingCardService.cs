using BoardingCards.Domain.Entities;

namespace BoardingCards.Domain.Interfaces
{
    public interface IBoardingCardService
    {
        IReadOnlyCollection<BoardingCard> GetOrderedBoardingCards(IEnumerable<BoardingCard> boardingCards);

        string GetBoardingCardsSummary(IEnumerable<BoardingCard> boardingCards);
    }
}