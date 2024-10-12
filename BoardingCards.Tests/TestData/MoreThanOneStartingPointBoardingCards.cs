using BoardingCards.Domain.Entities;
using static BoardingCards.Tests.TestData.BoardingCards;

namespace BoardingCards.Tests.TestData
{
    public class MoreThanOneStartingPointBoardingCards : TheoryData<IEnumerable<BoardingCard>>
    {
        public MoreThanOneStartingPointBoardingCards()
        {
            AddRange(TwoStartsCards, TwoEndsCards);
        }
    }
}
