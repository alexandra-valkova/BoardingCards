using BoardingCards.Domain.Entities;
using BoardingCards.Domain.Extensions;
using BoardingCards.Domain.Interfaces;

namespace BoardingCards.Application.Services
{
    public class BoardingCardService : IBoardingCardService
    {
        public IReadOnlyCollection<BoardingCard> GetOrderedBoardingCards(IEnumerable<BoardingCard> boardingCards)
        {
            return boardingCards.GetBoardingCardsInOrder();
        }

        public string GetBoardingCardsSummary(IEnumerable<BoardingCard> boardingCards)
        {
            return boardingCards.GetSummary();
        }
    }
}
