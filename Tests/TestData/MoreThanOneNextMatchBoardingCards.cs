using Domain.Entities;
using static Tests.TestData.BoardingCards;

namespace Tests.TestData
{
    public class MoreThanOneNextMatchBoardingCards : TheoryData<IEnumerable<BoardingCard>>
    {
        public MoreThanOneNextMatchBoardingCards()
        {
            Add(MoreThanOneNextMatchCards);
        }
    }
}
