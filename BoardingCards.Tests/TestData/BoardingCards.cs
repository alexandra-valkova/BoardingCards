using BoardingCards.Domain.Entities;

namespace BoardingCards.Tests.TestData
{
    public static class BoardingCards
    {
        public const string OrderedBoardingCardsSummary = @"Take the train 78A from Madrid to Barcelona. Seat 45B.
Take the airport bus from Barcelona to Gerona Airport. No seat assignment.
Take the flight SK455 from Gerona Airport to Stockholm. Gate 45B. Seat 3A. Baggage drop at ticket counter 344.
Take the flight SK22 from Stockholm to New York JFK. Gate 22. Seat 7B. Baggage will be automatically transferred from your last leg.
You have arrived at your final destination.";

        public static IEnumerable<BoardingCard> OneCard =>
        [
            new FlightBoardingCard()
            {
                Origin = "Gerona Airport",
                Destination = "Stockholm",
                Number = "SK455",
                Gate = "45B",
                Seat = "3A",
                Baggage = "drop at ticket counter 344"
            }
        ];

        public static IEnumerable<BoardingCard> OrderedCards =>
        [
            new TrainBoardingCard()
            {
                Origin = "Madrid",
                Destination = "Barcelona",
                Number = "78A",
                Seat = "45B"
            },
            new BusBoardingCard()
            {
                Origin = "Barcelona",
                Destination = "Gerona Airport"
            },
            new FlightBoardingCard()
            {
                Origin = "Gerona Airport",
                Destination = "Stockholm",
                Number = "SK455",
                Gate = "45B",
                Seat = "3A",
                Baggage = "drop at ticket counter 344"
            },
            new FlightBoardingCard()
            {
                Origin = "Stockholm",
                Destination = "New York JFK",
                Number = "SK22",
                Gate = "22",
                Seat = "7B",
                Baggage = "will be automatically transferred from your last leg"
            }
        ];

        public static IEnumerable<BoardingCard> UnorderedCards =>
        [
            new BusBoardingCard()
            {
                Origin = "Barcelona",
                Destination = "Gerona Airport"
            },
            new TrainBoardingCard()
            {
                Origin = "Madrid",
                Destination = "Barcelona",
                Number = "78A",
                Seat = "45B"
            },
            new FlightBoardingCard()
            {
                Origin = "Stockholm",
                Destination = "New York JFK",
                Number = "SK22",
                Gate = "22",
                Seat = "7B",
                Baggage = "will be automatically transferred from your last leg"
            },
            new FlightBoardingCard()
            {
                Origin = "Gerona Airport",
                Destination = "Stockholm",
                Number = "SK455",
                Gate = "45B",
                Seat = "3A",
                Baggage = "drop at ticket counter 344"
            }
        ];

        public static IEnumerable<BoardingCard> LoopCards =>
        [
            new BusBoardingCard()
            {
                Origin = "Barcelona",
                Destination = "Gerona Airport"
            },
            new TrainBoardingCard()
            {
                Origin = "Madrid",
                Destination = "Barcelona",
                Number = "78A",
                Seat = "45B"
            },
            new FlightBoardingCard()
            {
                Origin = "Stockholm",
                Destination = "Madrid",
                Number = "SK22",
                Gate = "22",
                Seat = "7B",
                Baggage = "will be automatically transferred from your last leg"
            },
            new FlightBoardingCard()
            {
                Origin = "Gerona Airport",
                Destination = "Stockholm",
                Number = "SK455",
                Gate = "45B",
                Seat = "3A",
                Baggage = "drop at ticket counter 344"
            }
        ];

        public static IEnumerable<BoardingCard> TwoStartsCards =>
        [
            new TrainBoardingCard()
            {
                Origin = "Madrid",
                Destination = "Barcelona",
                Number = "78A",
                Seat = "45B"
            },
            new BusBoardingCard()
            {
                Origin = "Madrid",
                Destination = "Gerona Airport"
            },
            new FlightBoardingCard()
            {
                Origin = "Stockholm",
                Destination = "New York JFK",
                Number = "SK22",
                Gate = "22",
                Seat = "7B",
                Baggage = "will be automatically transferred from your last leg"
            },

            new FlightBoardingCard()
            {
                Origin = "Gerona Airport",
                Destination = "Stockholm",
                Number = "SK455",
                Gate = "45B",
                Seat = "3A",
                Baggage = "drop at ticket counter 344"
            }
        ];

        public static IEnumerable<BoardingCard> TwoEndsCards =>
        [
            new FlightBoardingCard()
            {
                Origin = "Stockholm",
                Destination = "New York JFK",
                Number = "SK22",
                Gate = "22",
                Seat = "7B",
                Baggage = "will be automatically transferred from your last leg"
            },
            new FlightBoardingCard()
            {
                Origin = "Gerona Airport",
                Destination = "New York JFK",
                Number = "SK455",
                Gate = "45B",
                Seat = "3A",
                Baggage = "drop at ticket counter 344"
            },
            new BusBoardingCard()
            {
                Origin = "Barcelona",
                Destination = "Gerona Airport"
            },
            new TrainBoardingCard()
            {
                Origin = "Madrid",
                Destination = "Barcelona",
                Number = "78A",
                Seat = "45B"
            }
        ];

        public static IEnumerable<BoardingCard> MoreThanOneNextMatchCards =>
        [
            new BusBoardingCard()
            {
                Origin = "Barcelona",
                Destination = "Gerona Airport"
            },
            new TrainBoardingCard()
            {
                Origin = "Madrid",
                Destination = "Barcelona",
                Number = "78A",
                Seat = "45B"
            },
            new FlightBoardingCard()
            {
                Origin = "Barcelona",
                Destination = "New York JFK",
                Number = "SK22",
                Gate = "22",
                Seat = "7B",
                Baggage = "will be automatically transferred from your last leg"
            },
            new FlightBoardingCard()
            {
                Origin = "Gerona Airport",
                Destination = "Stockholm",
                Number = "SK455",
                Gate = "45B",
                Seat = "3A",
                Baggage = "drop at ticket counter 344"
            }
        ];

        public static IEnumerable<BoardingCard> InconsistentCards =>
        [
            new BusBoardingCard()
            {
                Origin = "Barcelona",
                Destination = "Gerona Airport"
            },
            new TrainBoardingCard()
            {
                Origin = "Madrid",
                Destination = "Barcelona",
                Number = "78A",
                Seat = "45B"
            },
            new FlightBoardingCard()
            {
                Origin = "Stockholm",
                Destination = "Barcelona",
                Number = "SK22",
                Gate = "22",
                Seat = "7B",
                Baggage = "will be automatically transferred from your last leg"
            },
            new FlightBoardingCard()
            {
                Origin = "Gerona Airport",
                Destination = "Stockholm",
                Number = "SK455",
                Gate = "45B",
                Seat = "3A",
                Baggage = "drop at ticket counter 344"
            }
        ];

        public static IEnumerable<BoardingCard> IdenticalOriginAndDestinationCards =>
        [
            new TrainBoardingCard()
            {
                Origin = "Madrid",
                Destination = "Madrid",
                Number = "78A",
                Seat = "45B"
            },
            new BusBoardingCard()
            {
                Origin = "Barcelona",
                Destination = "Gerona Airport"
            }
        ];
    }
}
