using Carter;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using RentApi.Data.Configurations;

namespace RentApi;

public class GetUnit
{
    public record Response(Ulid Id,
    int UnitType,
    string Suite,
    string Building,
    int Bedrooms,
    int Bathrooms,
    int Kitchens,
    decimal SquareFootage,
    bool IsCondo,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    int StatusId
    );
    public class Endpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("units", async (RentDbContext dbContext, CancellationToken cancellationToken) =>
                await Handler(dbContext, cancellationToken)
            )
            .Produces<Response>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithName(nameof(GetUnit))
            .WithTags(nameof(Unit));
        }
    }

    public static async Task<IResult> Handler(RentDbContext dbContext, CancellationToken cancellationToken)
    {
        var units = await dbContext.Units
        .AsNoTracking()
        .Select(u => new Response(
            u.Id,
            u.UnitType,
            u.Suite,
            u.Building,
            u.Bedrooms,
            u.Bathrooms,
            u.Kitchens,
            u.SquareFootage,
            u.IsCondo,
            u.CreatedAt,
            u.UpdatedAt,
            u.StatusId
        ))
        .ToListAsync(cancellationToken);

        return Results.Ok(units);
    }
}
