using BoardingCards.Domain.Entities;
using static BoardingCards.Tests.TestData.BoardingCards;

namespace BoardingCards.Tests.TestData
{
    public class NoStartingPointBoardingCards : TheoryData<IEnumerable<BoardingCard>>
    {
        public NoStartingPointBoardingCards()
        {
            Add(LoopCards);
        }
    }
}
