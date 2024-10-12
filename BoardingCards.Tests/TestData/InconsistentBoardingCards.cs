using BoardingCards.Domain.Entities;
using static BoardingCards.Tests.TestData.BoardingCards;

namespace BoardingCards.Tests.TestData
{
    public class InconsistentBoardingCards : TheoryData<IEnumerable<BoardingCard>>
    {
        public InconsistentBoardingCards()
        {
            AddRange(InconsistentCards, IdenticalOriginAndDestinationCards);
        }
    }
}
