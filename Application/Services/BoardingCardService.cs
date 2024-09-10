using Domain.Entities;
using Domain.Extensions;
using Domain.Interfaces;

namespace Application.Services
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
