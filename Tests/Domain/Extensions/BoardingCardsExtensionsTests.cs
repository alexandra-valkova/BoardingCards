using Domain.Extensions;
using static Tests.TestData.BoardingCards;

namespace Tests.Domain.Extensions
{
    public class BoardingCardsExtensionsTests
    {
        [Fact]
        public void AsString_BoardingCards_ReturnsDescriptionOfBoardingCards()
        {
            string description = OrderedCards.AsString();

            string expected = @"train from ""Madrid"" to ""Barcelona"".
airport bus from ""Barcelona"" to ""Gerona Airport"".
flight from ""Gerona Airport"" to ""Stockholm"".
flight from ""Stockholm"" to ""New York JFK"".
";

            description.Should().Be(expected);
        }
    }
}