using BuisnessLogicLayer.IServices;
using DataAccessLayer.IRepository;
using EntityLayer;
using EntityLayer.Models;


namespace BuisnessLogicLayer.Services
{
    public class OrderLineItemsService: IOrderLineItemsService
    {
        private readonly IUnitOfWork unitOfWork;

        public OrderLineItemsService(IUnitOfWork unitOfWork) 
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<OrderLineItems> AddProductsInOrderLineAsync(AddProductInOrderLine addProductInOrderLine)
        {
            var orderLineItems = new OrderLineItems()
            {
                ProductId = addProductInOrderLine.ProductId,
                ProductPrice = addProductInOrderLine.ProductPrice,
                ProductQuantity = addProductInOrderLine.ProductQuantity
            };
            await unitOfWork.OrderLineRepository.AddAsync(orderLineItems);
            await unitOfWork.SaveAsync();
            return orderLineItems;
        }

        public async Task<OrderLineItems> DeleteProductFromOrderLineAsync(Guid productId)
        {
           var deletedItem=await unitOfWork.OrderLineRepository.DeleteAsync(productId);
           await unitOfWork.SaveAsync();
           return deletedItem;
        }

        public async Task<IEnumerable<OrderLineItems>> GetAllProductAsync()
        { 
           var listOfOrders= await unitOfWork.OrderLineRepository.GetAllAsync();
           //logger.LogInformation("GetAsync() execution time: {ExecutionTime}ms", listOfOrders);
           return listOfOrders;
        }

        public async Task<OrderLineItems> UpdateProductQuantityAsync(Guid productId, UpdatePrdouctQuantity updateProduct)
        {
            var cartItem = unitOfWork.OrderLineRepository.FindInList(c => c.ProductId == productId);
            if (cartItem == null)
            {
                return null;
            }
            cartItem.ProductQuantity=updateProduct.ProductQuantity;
            await unitOfWork.OrderLineRepository.AddAsync(cartItem);
            await unitOfWork.SaveAsync();
            return cartItem;
        }
    }
}
