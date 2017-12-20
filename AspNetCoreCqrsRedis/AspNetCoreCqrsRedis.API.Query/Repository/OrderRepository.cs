using System.Collections.Generic;
using System.Linq;
using StackExchange.Redis;
using Order = AspNetCoreCqrsRedis.API.Query.Domain.Order;

namespace AspNetCoreCqrsRedis.API.Query.Repository
{
    public class OrderRepository : BaseRepository, IOrderRespository
    {
        public OrderRepository(IConnectionMultiplexer redisConnection) : base(redisConnection, "order")
        {
        }

        public Order GetByID(int orderId)
        {
            return Get<Order>(orderId);
        }

        public List<Order> GetOrders(List<int> orderIds)
        {
            return GetMultiple<Order>(orderIds);
        }

        public void Save(Order order)
        {
            Save(order.OrderId, order);
            StoreInQueryCache(order);
        }

        private void StoreInQueryCache(Order order)
        {
            var allOrders = new List<Order>();
            if (Exists("all"))
            {
                allOrders = Get<List<Order>>("all");
            }


            if (allOrders.Any(x => x.OrderId == order.OrderId))
            {
                allOrders.Remove(allOrders.First(x => x.OrderId == order.OrderId));
            }

            allOrders.Add(order);

            Save("all", allOrders);
        }

        public IEnumerable<Order> GetAll()
        {
            return Get<List<Order>>("all");
        }
    }
}