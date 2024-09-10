using Domain.Entities;
using static Tests.TestData.BoardingCards;

namespace Tests.TestData
{
    public class InconsistentBoardingCards : TheoryData<IEnumerable<BoardingCard>>
    {
        public InconsistentBoardingCards()
        {
            AddRange(InconsistentCards, IdenticalOriginAndDestinationCards);
        }
    }
}
