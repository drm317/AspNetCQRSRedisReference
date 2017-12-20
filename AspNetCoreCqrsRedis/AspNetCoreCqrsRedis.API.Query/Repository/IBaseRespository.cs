using System.Collections.Generic;

namespace AspNetCoreCqrsRedis.API.Query.Repository
{
    public interface IBaseRespository<T>
    {
        T GetByID(int OrderId);
        List<T> GetOrders(List<int> orderIds);
        bool Exists(int orderId);
        void Save(T item);
    }
}