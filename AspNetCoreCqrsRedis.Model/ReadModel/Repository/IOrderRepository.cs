using System.Collections.Generic;

namespace AspNetCoreCqrsRedis.Model.ReadModel.Repository
{
    public interface IOrderRepository : IBaseRepository<OrderDto>
    {
        IEnumerable<OrderDto> GetAll();
    }
}