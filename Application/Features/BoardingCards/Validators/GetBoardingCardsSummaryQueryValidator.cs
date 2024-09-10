using Application.Features.BoardingCards.Queries.GetSummary;
using FluentValidation;

namespace Application.Features.BoardingCards.Validators
{
    public class GetBoardingCardsSummaryQueryValidator : AbstractValidator<GetBoardingCardsSummaryQuery>
    {
        public GetBoardingCardsSummaryQueryValidator()
        {
            RuleForEach(request => request.BoardingCards).SetValidator(new BoardingCardDTOValidator());
        }
    }
}
