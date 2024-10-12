namespace BoardingCards.Blazor
{
    public record BoardingCard(BoardingCardType Type,
                               string Origin,
                               string Destination,
                               string? Number,
                               string? Seat,
                               string? Gate,
                               string? Baggage);

    public enum BoardingCardType
    {
        Bus = 0,
        Train = 1,
        Flight = 2
    }
}
