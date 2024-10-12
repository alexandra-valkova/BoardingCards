using System.ComponentModel.DataAnnotations;
using BoardingCards.Domain.Enums;

namespace BoardingCards.Application.Features.BoardingCards.DTOs
{
    public record BoardingCardDTO
    {
        [Required]
        public BoardingCardType? Type { get; init; }

        [Required]
        public string? Origin { get; init; }

        [Required]
        public string? Destination { get; init; }

        public string? Number { get; init; }

        public string? Seat { get; init; }

        public string? Gate { get; init; }

        public string? Baggage { get; init; }
    }
}
