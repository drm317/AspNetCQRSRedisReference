using System.Collections.Generic;
using AspNetCoreCqrsRedis.API.Query.Domain;

namespace AspNetCoreCqrsRedis.API.Query.Repository
{
    public interface IOrderRespository : IBaseRespository<Order>
    {
        IEnumerable<Order> GetAll();
    }
}