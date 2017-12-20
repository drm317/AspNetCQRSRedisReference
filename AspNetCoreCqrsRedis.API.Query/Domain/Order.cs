using System.Data.Common;

namespace AspNetCoreCqrsRedis.API.Query.Domain
{
    public class Order
    {
        public string OrderId { get; set; }

        public string Description { get; set; }
    }
}