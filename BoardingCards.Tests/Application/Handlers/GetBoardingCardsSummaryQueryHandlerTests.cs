using BoardingCards.Application.Features.BoardingCards.DTOs;
using BoardingCards.Application.Features.BoardingCards.Queries.GetSummary;
using BoardingCards.Application.Services;
using BoardingCards.Domain.Exceptions;
using Xunit.Abstractions;
using static BoardingCards.Domain.Enums.BoardingCardType;
using static BoardingCards.Tests.TestData.BoardingCards;

namespace BoardingCards.Tests.Application.Handlers
{
    public class GetBoardingCardsSummaryQueryHandlerTests
    {
        private readonly ITestOutputHelper _output;
        private readonly BoardingCardService _boardingCardService;
        private readonly GetBoardingCardsSummaryQueryHandler _handler;

        public GetBoardingCardsSummaryQueryHandlerTests(ITestOutputHelper output)
        {
            _output = output;
            _boardingCardService = new();
            _handler = new(_boardingCardService);
        }

        private static IList<BoardingCardDTO> UnorderedBoardingCardDTOs =>
        [
            new()
            {
                Type = Bus,
                Origin = "Barcelona",
                Destination = "Gerona Airport",
                Number = null,
                Seat = null,
                Gate = null,
                Baggage = null
            },
            new ()
            {
                Type = Train,
                Origin = "Madrid",
                Destination = "Barcelona",
                Number = "78A",
                Seat = "45B",
                Gate = null,
                Baggage = null
            },
            new ()
            {
                Type = Flight,
                Origin = "Stockholm",
                Destination = "New York JFK",
                Number = "SK22",
                Gate = "22",
                Seat = "7B",
                Baggage = "will be automatically transferred from your last leg"
            },
            new ()
            {
                Type = Flight,
                Origin = "Gerona Airport",
                Destination = "Stockholm",
                Number = "SK455",
                Gate = "45B",
                Seat = "3A",
                Baggage = "drop at ticket counter 344"
            }
        ];

        private static IList<BoardingCardDTO> InconsistentBoardingCardDTOs =>
        [
            new()
            {
                Type = Bus,
                Origin = "Barcelona",
                Destination = "Gerona Airport",
                Number = null,
                Seat = null,
                Gate = null,
                Baggage = null
            },
            new ()
            {
                Type = Train,
                Origin = "Madrid",
                Destination = "Barcelona",
                Number = "78A",
                Seat = "45B",
                Gate = null,
                Baggage = null
            },
            new ()
            {
                Type = Flight,
                Origin = "Stockholm",
                Destination = "Barcelona",
                Number = "SK22",
                Gate = "22",
                Seat = "7B",
                Baggage = "will be automatically transferred from your last leg"
            },
            new ()
            {
                Type = Flight,
                Origin = "Gerona Airport",
                Destination = "Stockholm",
                Number = "SK455",
                Gate = "45B",
                Seat = "3A",
                Baggage = "drop at ticket counter 344"
            }
        ];

        [Fact]
        public async Task Handle_UnorderedBoardingCards_ReturnsSummary()
        {
            GetBoardingCardsSummaryQuery request = new(UnorderedBoardingCardDTOs);

            string summary = await _handler.Handle(request, default);

            summary.Should().Be(OrderedBoardingCardsSummary);
        }

        [Fact]
        public async Task Handle_InconsistentBoardingCards_ThrowsBoardingCardException()
        {
            GetBoardingCardsSummaryQuery request = new(InconsistentBoardingCardDTOs);

            _output.WriteLine((await Assert.ThrowsAsync<InconsistentBoardingCardException>(async () =>
            {
                await _handler.Handle(request, default);
            })).ToString());
        }
    }
}