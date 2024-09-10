using Application.Features.BoardingCards.DTOs;
using FluentValidation;
using static Domain.Enums.BoardingCardType;

namespace Application.Features.BoardingCards.Validators
{
    public class BoardingCardDTOValidator : AbstractValidator<BoardingCardDTO>
    {
        public BoardingCardDTOValidator()
        {
            RuleFor(card => card.Type).NotEmpty().IsInEnum();

            RuleFor(card => card.Origin).NotEmpty();
            RuleFor(card => card.Destination).NotEmpty();

            When(card => card.Type is Bus, () =>
            {
                RuleFor(card => card.Number).Empty();
                RuleFor(card => card.Seat).Empty();
                RuleFor(card => card.Gate).Empty();
                RuleFor(card => card.Baggage).Empty();
            });

            When(card => card.Type is Train, () =>
            {
                RuleFor(card => card.Number).NotEmpty();
                RuleFor(card => card.Seat).NotEmpty();
                RuleFor(card => card.Gate).Empty();
                RuleFor(card => card.Baggage).Empty();
            });

            When(card => card.Type is Flight, () =>
            {
                RuleFor(card => card.Number).NotEmpty();
                RuleFor(card => card.Seat).NotEmpty();
                RuleFor(card => card.Gate).NotEmpty();
                RuleFor(card => card.Baggage).NotEmpty();
            });
        }
    }
}
