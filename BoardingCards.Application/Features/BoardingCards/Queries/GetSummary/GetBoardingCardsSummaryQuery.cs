using BoardingCards.Application.Features.BoardingCards.DTOs;
using MediatR;

namespace BoardingCards.Application.Features.BoardingCards.Queries.GetSummary
{
    public sealed record GetBoardingCardsSummaryQuery(IList<BoardingCardDTO> BoardingCards) : IRequest<string>;
}
