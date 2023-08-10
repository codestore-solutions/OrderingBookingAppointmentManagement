using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            NewCreated,
            Processing,
            Delivered,
            Returned,
            Replaced,
            Cancelled
        }
        public enum DeliverySlots
        {
            Default10Am = 0,
            E6AmTo10Am = 1,
            E10AmTo2Pm = 2,
            E2PmTo6Pm = 3,
            E6PmTo10Pm = 4,
        }
    }

}
