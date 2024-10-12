using BoardingCards.Domain.Entities;
using static BoardingCards.Tests.TestData.BoardingCards;

namespace BoardingCards.Tests.TestData
{
    public class MoreThanOneNextMatchBoardingCards : TheoryData<IEnumerable<BoardingCard>>
    {
        public MoreThanOneNextMatchBoardingCards()
        {
            Add(MoreThanOneNextMatchCards);
        }
    }
}
