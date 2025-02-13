
using System.Data;
using Api;
using Carter;
using FluentValidation;
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

    public class Validator : AbstractValidator<Request>
    {
        public Validator()
        {
            RuleFor(x => x.Suite)
                .NotEmpty()
                .MaximumLength(10);
            RuleFor(x => x.Building).NotEmpty();
            RuleFor(x => x.Bedrooms).GreaterThan(0);
            RuleFor(x => x.Bathrooms).GreaterThan(0);
            RuleFor(x => x.Kitchens).GreaterThan(0);
            RuleFor(x => x.SquareFootage).GreaterThan(0);
            RuleFor(x => x.IsCondo).NotNull();
        }
    }

    public class Endpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("units", async (Request request, CancellationToken cancellationToken, RentDbContext context, IValidator<Request> validator) =>
            {
                return await Handler(request, cancellationToken, context, validator);
            })
            .WithName(nameof(CreateUnit))
            .WithTags(nameof(Unit))
            .Produces(StatusCodes.Status201Created);
        }
    }
    public static async Task<IResult> Handler(Request request, CancellationToken cancellationToken, RentDbContext context, IValidator<Request> validator)
    {
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            return Results.BadRequest(validationResult);
        }

        var unit = request.MapToUnit();

        context.Units.Add(unit);
        await context.SaveChangesAsync(cancellationToken);

        return Results.Created("", unit);
    }

}
