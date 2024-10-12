using System.Net.Mime;
using System.Text;
using BoardingCards.Application.Features.BoardingCards.DTOs;
using BoardingCards.Application.Features.BoardingCards.Queries.GetSummary;
using Carter;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BoardingCards.API.Endpoints
{
    public class BoardingCardsEndpoints : CarterModule
    {
        public BoardingCardsEndpoints() : base(basePath: "/boarding-cards")
        {
            WithTags("Boarding Cards");
            WithGroupName("boardingCards");
            IncludeInOpenApi();
        }

        public override void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/summary", GetBoardingCardsSummary)
               .WithName(nameof(GetBoardingCardsSummary))
               .WithSummary("Gets a summary of the journey given the list of boarding cards.")
               .Produces<string>(StatusCodes.Status200OK, MediaTypeNames.Text.Plain)
               .ProducesValidationProblem()
               .ProducesProblem(StatusCodes.Status400BadRequest)
               .ProducesProblem(StatusCodes.Status500InternalServerError);
        }

        private static async Task<ContentHttpResult> GetBoardingCardsSummary(ISender mediator, [FromBody] IList<BoardingCardDTO> boardingCards)
        {
            string summary = await mediator.Send(new GetBoardingCardsSummaryQuery(boardingCards));

            return TypedResults.Text(summary, MediaTypeNames.Text.Plain, Encoding.UTF8, StatusCodes.Status200OK);
        }
    }
}
