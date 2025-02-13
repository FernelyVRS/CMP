using RentApi;

namespace Api;

public static class UnitMapper
{
    public static Unit MapToUnit(this CreateUnit.Request request)
    {
        return new Unit
        (
            suite: request.Suite,
            building: request.Building,
            bedrooms: request.Bedrooms,
            bathrooms: request.Bathrooms,
            kitchens: request.Kitchens,
            squareFootage: request.SquareFootage,
            isCondo: request.IsCondo
        );
    }
}
