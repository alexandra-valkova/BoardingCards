using Application.Services;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Extensions;
using Tests.TestData;
using Xunit.Abstractions;
using static Tests.TestData.BoardingCards;

namespace Tests.Application.Services
{
    public class BoardingCardServiceTests
    {
        private readonly ITestOutputHelper _output;
        private readonly BoardingCardService _boardingCardService;

        public BoardingCardServiceTests(ITestOutputHelper output)
        {
            _output = output;
            _boardingCardService = new();
        }

        [Fact]
        public void GetOrderedBoardingCards_EmptyList_ReturnsEmptyList()
        {
            IReadOnlyCollection<BoardingCard> oneCardList = _boardingCardService.GetOrderedBoardingCards([]);

            oneCardList.Should().BeEmpty();
        }

        [Fact]
        public void GetOrderedBoardingCards_OneCardList_ReturnsOneCardList()
        {
            IReadOnlyCollection<BoardingCard> oneCardList = _boardingCardService.GetOrderedBoardingCards(OneCard);

            oneCardList.Should().ContainSingle().And.BeEquivalentTo(OneCard);
        }

        [Fact]
        public void GetOrderedBoardingCards_OrderedList_ReturnsOrderedList()
        {
            IReadOnlyCollection<BoardingCard> orderedCards = _boardingCardService.GetOrderedBoardingCards(OrderedCards);

            orderedCards.Should().BeEquivalentTo(OrderedCards, options => options.WithStrictOrdering());
        }

        [Fact]
        public void GetOrderedBoardingCards_UnorderedList_ReturnsOrderedList()
        {
            IReadOnlyCollection<BoardingCard> orderedCards = _boardingCardService.GetOrderedBoardingCards(UnorderedCards);

            orderedCards.Should().BeEquivalentTo(OrderedCards, options => options.WithStrictOrdering());
        }

        [Fact]
        public void GetOrderedBoardingCards_RandomOrderList_ReturnsOrderedList()
        {
            BoardingCard[] cards = [.. OrderedCards];
            new Random().Shuffle(cards);

            _output.WriteLine("Initial boarding cards list with random order:");
            _output.WriteLine($"{cards.AsString()}");

            IReadOnlyCollection<BoardingCard> orderedCards = _boardingCardService.GetOrderedBoardingCards(cards);

            _output.WriteLine("Result:");
            _output.WriteLine($"{orderedCards.AsString()}");

            orderedCards.Should().BeEquivalentTo(OrderedCards, options => options.WithStrictOrdering());
        }

        [Fact]
        public void GetOrderedBoardingCards_RandomPropertiesList_ThrowsBoardingCardException()
        {
            string[] places = ["Madrid", "Barcelona", "Gerona Airport", "Stockholm", "New York JFK"];
            Random random = new();

            BoardingCard[] cards =
            [
                GetRandomizedCard(places, random),
                GetRandomizedCard(places, random),
                GetRandomizedCard(places, random),
                GetRandomizedCard(places, random)
            ];

            _output.WriteLine("Initial boarding cards list with random properties:");
            _output.WriteLine($"{cards.AsString()}");

            _output.WriteLine(Assert.ThrowsAny<BoardingCardException>(() => _boardingCardService.GetOrderedBoardingCards(cards)).ToString());

            static BusBoardingCard GetRandomizedCard(string[] places, Random random)
            {
                return new BusBoardingCard()
                {
                    Origin = places[random.Next(0, places.Length)],
                    Destination = places[random.Next(0, places.Length)]
                };
            }
        }

        [Theory]
        [ClassData(typeof(NoStartingPointBoardingCards))]
        public void GetOrderedBoardingCards_NoStartingPointList_ThrowsBoardingCardException(IEnumerable<BoardingCard> boardingCards)
        {
            _output.WriteLine(Assert.Throws<NoStartingPointBoardingCardException>(() => _boardingCardService.GetOrderedBoardingCards(boardingCards)).ToString());
        }

        [Theory]
        [ClassData(typeof(MoreThanOneStartingPointBoardingCards))]
        public void GetOrderedBoardingCards_MoreThanOneStartingPointList_ThrowsBoardingCardException(IEnumerable<BoardingCard> boardingCards)
        {
            _output.WriteLine(Assert.Throws<MoreThanOneStartingPointBoardingCardException>(() => _boardingCardService.GetOrderedBoardingCards(boardingCards)).ToString());
        }

        [Theory]
        [ClassData(typeof(MoreThanOneNextMatchBoardingCards))]
        public void GetOrderedBoardingCards_MoreThanOneNextMatchList_ThrowsBoardingCardException(IEnumerable<BoardingCard> boardingCards)
        {
            _output.WriteLine(Assert.Throws<MoreThanOneNextCardMatchBoardingCardException>(() => _boardingCardService.GetOrderedBoardingCards(boardingCards)).ToString());
        }

        [Theory]
        [ClassData(typeof(InconsistentBoardingCards))]
        public void GetOrderedBoardingCards_InconsistentList_ThrowsBoardingCardException(IEnumerable<BoardingCard> boardingCards)
        {
            _output.WriteLine(Assert.Throws<InconsistentBoardingCardException>(() => _boardingCardService.GetOrderedBoardingCards(boardingCards)).ToString());
        }

        [Fact]
        public void GetBoardingCardsSummary_EmptyList_ReturnsEmptyString()
        {
            string summary = _boardingCardService.GetBoardingCardsSummary([]);

            summary.Should().BeEmpty();
        }

        [Fact]
        public void GetBoardingCardsSummary_OneCardList_ReturnsOneCardSummary()
        {
            string summary = _boardingCardService.GetBoardingCardsSummary(OneCard);

            string expected = @"Take the flight SK455 from Gerona Airport to Stockholm. Gate 45B. Seat 3A. Baggage drop at ticket counter 344.
You have arrived at your final destination.";

            summary.Should().Be(expected);
        }

        [Fact]
        public void GetBoardingCardsSummary_OrderedList_ReturnsOrderedSummary()
        {
            string summary = _boardingCardService.GetBoardingCardsSummary(OrderedCards);

            summary.Should().Be(OrderedBoardingCardsSummary);
        }
    }
}