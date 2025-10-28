
namespace Catalog.API.Products.GetProduct
{
    public record GetProductsRequest(int? PageNumber = 1, int? PageSize = 10);

    public record GetProductRequest(IEnumerable<Product> Products);

    public class GetProductsEndPoint
        : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products", async ([AsParameters] GetProductsRequest request, ISender sender) =>
            {
                var query = request.Adapt<GetProductQuery>();

                var result = await sender.Send(query);
                
                var respone = result.Adapt<GetProductRequest>();

                return Results.Ok(respone);
            })
            .WithName("GetProducts")
            .Produces<IEnumerable<Product>>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Products")
            .WithDescription("Get Products");
        }
    }
}
