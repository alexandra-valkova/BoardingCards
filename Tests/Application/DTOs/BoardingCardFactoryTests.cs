using Application.Features.BoardingCards.DTOs;
using Domain.Entities;
using Xunit.Abstractions;
using static Domain.Enums.BoardingCardType;

namespace Tests.Application.DTOs
{
    public class BoardingCardFactoryTests
    {
        private readonly ITestOutputHelper _output;

        public BoardingCardFactoryTests(ITestOutputHelper output)
        {
            _output = output;
        }

        public static TheoryData<BoardingCardDTO, BoardingCard> ValidBoardingCards =>
        new()
        {
            {
                new BoardingCardDTO
                {
                    Type = Bus,
                    Origin = "Barcelona",
                    Destination = "Gerona Airport",
                    Number = null,
                    Seat = null,
                    Gate = null,
                    Baggage = null
                },
                new BusBoardingCard
                {
                    Origin = "Barcelona",
                    Destination = "Gerona Airport"
                }
            },
            {
                new BoardingCardDTO
                {
                    Type = Train,
                    Origin = "Madrid",
                    Destination = "Barcelona",
                    Number = "78A",
                    Seat = "45B",
                    Gate = null,
                    Baggage = null
                },
                new TrainBoardingCard
                {
                    Origin = "Madrid",
                    Destination = "Barcelona",
                    Number = "78A",
                    Seat = "45B"
                }
            },
            {
                new BoardingCardDTO
                {
                    Type = Flight,
                    Origin = "Gerona Airport",
                    Destination = "Stockholm",
                    Number = "SK455",
                    Seat = "3A",
                    Gate = "45B",
                    Baggage = "drop at ticket counter 344"
                },
                new FlightBoardingCard
                {
                    Origin = "Gerona Airport",
                    Destination = "Stockholm",
                    Number = "78A",
                    Seat = "45B",
                    Gate = "45B",
                    Baggage = "drop at ticket counter 344"
                }
            }
        };

        public static TheoryData<BoardingCardDTO> InvalidBoardingCards =>
        new()
        {
            new BoardingCardDTO
            {
                Type = Flight,
                Origin = "Gerona Airport",
                Destination = "Stockholm",
                Number = null,
                Seat = null,
                Gate = null,
                Baggage = null
            },
            new BoardingCardDTO
            {
                Type = Bus,
                Origin = "Barcelona",
                Destination = "Gerona Airport",
                Number = "78A",
                Seat = "45B",
                Gate = "45B",
                Baggage = "drop at ticket counter 344"
            }
        };

        [Theory]
        [MemberData(nameof(ValidBoardingCards))]
        public void GetBoardingCard_ValidBoardingCard_ReturnsBoardingCardOfGivenType(BoardingCardDTO dto, BoardingCard expectedCard)
        {
            BoardingCard card = BoardingCardFactory.GetBoardingCard(dto);

            card.Should().BeEquivalentTo(expectedCard);
        }

        [Theory]
        [MemberData(nameof(InvalidBoardingCards))]
        public void GetBoardingCard_InvalidBoardingCard_ThrowsArgumentException(BoardingCardDTO dto)
        {
            _output.WriteLine(Assert.Throws<ArgumentException>(() => BoardingCardFactory.GetBoardingCard(dto)).ToString());
        }

        [Fact]
        public void GetBoardingCard_BoardingCardTypeMissing_ThrowsArgumentNullException()
        {
            BoardingCardDTO dto = new()
            {
                Type = null,
                Origin = "Madrid",
                Destination = "Barcelona",
                Number = "78A",
                Seat = "45B",
                Gate = null,
                Baggage = null
            };

            _output.WriteLine(Assert.Throws<ArgumentNullException>(() => BoardingCardFactory.GetBoardingCard(dto)).ToString());
        }
    }
}