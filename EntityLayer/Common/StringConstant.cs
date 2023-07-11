using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EntityLayer.Common
{
    public static class StringConstant
    {
        public const string InvalidInputError = "Invalid input. Please provide valid data.";
        public const string ResourceNotFoundError = "The requested resource was not found.";
        public const string SuccessMessage = "Successful.";
        public const string EmptyMessage = "Empty.";
        public const string ExistMessage = "Already exist.";
        public const string ErrorMessage = "Error";
        public const string RequiredFieldMessage = "The field is required";
        public const string StringMessage = "The property must be a string.";
        public const string QueueName = "order-data";
        public const string QueueConnectionString = "Endpoint=sb://order-queue-service.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=eGzVejbuuKbdCiekSmrt6nzWxbTSwoeel+ASbMlTSt8=";
        public const string PositiveAllowed = "Only positive numbers from 0 to 9 are allowed.";
        public const string DatabaseMessage = "Nothing is saved to the database";
    }
}
