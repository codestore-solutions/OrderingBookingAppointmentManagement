namespace Entitites.Dto
{

    // Dto to send data to order processing module through queue.
    public class SendOrderToQueueDto
    {
        public long orderId { get; set; }
        public long customerId { get; set; }
        public long vendorId { get; set; }
        public long shippingAddressId { get; set; }
    }
}
