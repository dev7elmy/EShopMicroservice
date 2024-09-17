

namespace Catalog.api.Products.CreateProduct
{
    public record CreateProudectCommand(string Name,List<string> Category,string Description,string ImageFile, decimal Price)
        :ICommand<CreateProudectResult>;
    public record CreateProudectResult(Guid Id);
    internal class CreateProductCommandHandler(IDocumentSession session ) : ICommandHandler<CreateProudectCommand, CreateProudectResult>
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
            // TODO
            //save to DB
            session.Store(product);
            await session.SaveChangesAsync();

            //return Result
            return new CreateProudectResult(product.Id );
            //throw new NotImplementedException();
        }
    }
}
