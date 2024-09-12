
using System.Net;

namespace Catalog.api.Products.CreateProduct
{
    public record CreateProductRequest(string Name, List<string> Category, string Description, string ImageFile, decimal Price);
    public record CreateProductResponse(Guid Id);
    public class CreateProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/Products", async (CreateProductRequest request, ISender sender) =>
            {
                var command = request.Adapt<CreateProudectCommand>();
                var result = await sender.Send(command);
                var response = result.Adapt<CreateProductResponse>();
                return Results.Created($"/Products/{response.Id}", response);
            })
              .WithName("CreateProduct")
              .Produces<CreateProductResponse>(StatusCodes.Status201Created)
              .ProducesProblem(StatusCodes.Status400BadRequest)
              .WithSummary("Create Proudect")
              .WithDescription("Create Proudect");
        }
    }
}
