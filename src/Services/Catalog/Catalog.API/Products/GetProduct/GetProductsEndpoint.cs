
namespace Catalog.API.Products.GetProduct
{
    public record GetProductRequest(IEnumerable<Product> Products);

    public class GetProductsEndPoint
        : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products", async (ISender sender) =>
            {
                var result = await sender.Send(new GetProductQuery());
                
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
