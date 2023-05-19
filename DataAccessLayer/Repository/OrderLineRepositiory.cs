using DataAccessLayer.Data;
using EntityLayer.Models;
using DataAccessLayer.IRepository;

namespace DataAccessLayer.Repository
{
    public class OrderLineRepository : GenericRepository<OrderLineItems>,IOrderLineRepository
    {
        private readonly OrderDbContext dbContext;
        public OrderLineRepository(OrderDbContext dbContext): base(dbContext)
        {
            this.dbContext = dbContext;
        }
     /*   public async Task<List<OrderLineItems>> GetAllProductAsync()
        {
            var productsInOrderLine = await dbContext.OrderLines.ToListAsync();
            return productsInOrderLine;
        }
        public async Task<OrderLineItems> AddProductsInOrderLineAsync(AddProductInOrderLine addProductInOrderLine)
        {
            var newProduct = new OrderLineItems
            {
                ProductId = addProductInOrderLine.ProductId,
                ProductPrice = addProductInOrderLine.ProductPrice,
                ProductQuantity = 1
            };
            await dbContext.OrderLines.AddAsync(newProduct);
            await dbContext.SaveChangesAsync();
            return newProduct;
        }
        public async Task<OrderLineItems> DeleteProductFromOrderLineAsync(Guid ProductId)
        {
            var findProductAgainstProductId = await dbContext.OrderLines.FirstOrDefaultAsync(x => x.ProductId == ProductId);

            if (findProductAgainstProductId != null)
            {
                dbContext.OrderLines.Remove(findProductAgainstProductId);
                await dbContext.SaveChangesAsync();
            }
            return findProductAgainstProductId;
        }
        public async Task<OrderLineItems> UpdateProductQuantityAsync(Guid ProductId, UpdatePrdouctQuantity updateProduct)
        {
            var productAgainstProdId = await dbContext.OrderLines.FirstOrDefaultAsync(x => x.ProductId == ProductId);
            if (productAgainstProdId != null)
            {
                productAgainstProdId.ProductQuantity = updateProduct.ProductQuantity;
                await dbContext.SaveChangesAsync();
            }
            return productAgainstProdId;
        }*/

    }
}
