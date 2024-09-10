using Domain.Entities;
using static Tests.TestData.BoardingCards;

namespace Tests.TestData
{
    public class MoreThanOneStartingPointBoardingCards : TheoryData<IEnumerable<BoardingCard>>
    {
        public MoreThanOneStartingPointBoardingCards()
        {
            AddRange(TwoStartsCards, TwoEndsCards);
        }
    }
}
