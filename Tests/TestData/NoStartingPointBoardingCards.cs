using Domain.Entities;
using static Tests.TestData.BoardingCards;

namespace Tests.TestData
{
    public class NoStartingPointBoardingCards : TheoryData<IEnumerable<BoardingCard>>
    {
        public NoStartingPointBoardingCards()
        {
            Add(LoopCards);
        }
    }
}
