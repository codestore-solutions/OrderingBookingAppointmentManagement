namespace Entitites.Common
{
    public class EnumConstants
    {
        public enum AddressesType
        {
            ShippingAddress = 1,
            BillingAddress = 2
        }
        public enum OrderStatus
        {
            NewCreated = 1,
            Processing,
            Delivered,
            Returned,
            Replaced,
            Cancelled
        }

        public enum PaymentStatus
        {
            Failed = 0,
            Successful = 1,
            Pending = 2
        }

        public enum PaymentMode
        {
            Online = 1,
            COD = 2
        }
    }

}
