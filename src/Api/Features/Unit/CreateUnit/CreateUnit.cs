
using Carter;
using RentApi.Data.Configurations;
using RentApi.Entities;

namespace RentApi;

public class CreateUnit
{
    public record Request(
        string Suite,
        string Building,
        int Bedrooms,
        int Bathrooms,
        int Kitchens,
        decimal SquareFootage,
        bool IsCondo
    );
    public record Response(Ulid Id);

    public class Endpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("units", async (Request request, CancellationToken cancellationToken, RentDbContext context) =>
            {
                return await Handler(request, cancellationToken, context);
            })
            .WithName(nameof(CreateUnit))
            .WithTags(nameof(Unit))
            .Produces(StatusCodes.Status201Created);
        }
        public static async Task<IResult> Handler(Request request, CancellationToken cancellationToken, RentDbContext context)
        {
            var unit = new Unit
            (
                suite: request.Suite,
                building: request.Building,
                bedrooms: request.Bedrooms,
                bathrooms: request.Bathrooms,
                kitchens: request.Kitchens,
                squareFootage: request.SquareFootage,
                isCondo: request.IsCondo
            );

            // var status1 = new Status { Id = 1, Name = "Active", Description = "Active state" };
            // context.Status.Add(status1);
            context.Units.Add(unit);
            await context.SaveChangesAsync(cancellationToken);

            return Results.Created("", unit);
        }
    }


}
