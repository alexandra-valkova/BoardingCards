using BoardingCards.Domain.Entities;
using static BoardingCards.Domain.Enums.BoardingCardType;

namespace BoardingCards.Application.Features.BoardingCards.DTOs
{
    public static class BoardingCardFactory
    {
        public static BoardingCard GetBoardingCard(BoardingCardDTO boardingCard)
        {
            ArgumentNullException.ThrowIfNull(boardingCard);
            ArgumentNullException.ThrowIfNull(boardingCard.Type);
            ArgumentNullException.ThrowIfNull(boardingCard.Origin);
            ArgumentNullException.ThrowIfNull(boardingCard.Destination);

            return boardingCard switch
            {
                {
                    Type: Bus,
                    Number: null,
                    Seat: null,
                    Gate: null,
                    Baggage: null
                }
                => new BusBoardingCard
                {
                    Origin = boardingCard.Origin,
                    Destination = boardingCard.Destination
                },
                {
                    Type: Train,
                    Number: not null,
                    Seat: not null,
                    Gate: null,
                    Baggage: null
                }
                => new TrainBoardingCard
                {
                    Origin = boardingCard.Origin,
                    Destination = boardingCard.Destination,
                    Number = boardingCard.Number,
                    Seat = boardingCard.Seat
                },
                {
                    Type: Flight,
                    Number: not null,
                    Seat: not null,
                    Gate: not null,
                    Baggage: not null
                }
                => new FlightBoardingCard
                {
                    Origin = boardingCard.Origin,
                    Destination = boardingCard.Destination,
                    Number = boardingCard.Number,
                    Seat = boardingCard.Seat,
                    Gate = boardingCard.Gate,
                    Baggage = boardingCard.Baggage
                },
                _ => throw new ArgumentException($"Boarding card's properties do not match its given type '{boardingCard.Type}'!")
            };
        }
    }
}
