using BuildingBlocks.CQRS;
using Catalog.api.Models;
using MediatR;

namespace Catalog.api.Products.CreateProduct
{
    public record CreateProudectCommand(string Name,List<string> Category,string Description,string ImageFile, decimal Price)
        :ICommand<CreateProudectResult>;
    public record CreateProudectResult(Guid Id);
    internal class CreateProductCommandHandler : ICommandHandler<CreateProudectCommand, CreateProudectResult>
    {
        public async Task<CreateProudectResult> Handle(CreateProudectCommand command, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Name = command.Name,
                Category = command.Category,
                Description = command.Description,
                ImageFile = command.ImageFile,
                Price= command.Price
            };
            return new CreateProudectResult(Guid.NewGuid());
            //throw new NotImplementedException();
        }
    }
}
