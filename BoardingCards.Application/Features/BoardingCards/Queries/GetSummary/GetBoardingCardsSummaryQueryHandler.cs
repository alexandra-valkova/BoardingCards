using BoardingCards.Application.Features.BoardingCards.DTOs;
using BoardingCards.Domain.Entities;
using BoardingCards.Domain.Interfaces;
using MediatR;

namespace BoardingCards.Application.Features.BoardingCards.Queries.GetSummary
{
    public sealed class GetBoardingCardsSummaryQueryHandler : IRequestHandler<GetBoardingCardsSummaryQuery, string>
    {
        private readonly IBoardingCardService _boardingCardService;

        public GetBoardingCardsSummaryQueryHandler(IBoardingCardService boardingCardService)
        {
            _boardingCardService = boardingCardService;
        }

        public Task<string> Handle(GetBoardingCardsSummaryQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<BoardingCard> boardingCards = request.BoardingCards
                                                             .Select(BoardingCardFactory.GetBoardingCard);

            IReadOnlyCollection<BoardingCard> orderedBoardingCards = _boardingCardService.GetOrderedBoardingCards(boardingCards);

            return Task.FromResult(_boardingCardService.GetBoardingCardsSummary(orderedBoardingCards));
        }
    }
}
