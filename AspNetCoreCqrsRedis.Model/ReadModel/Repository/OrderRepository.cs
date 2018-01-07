using System;
using System.Collections.Generic;
using System.Linq;
using StackExchange.Redis;

namespace AspNetCoreCqrsRedis.Model.ReadModel.Repository
{
    public class OrderRepository : BaseRepository, IOrderRepository
    {
        public OrderDto GetByID(Guid orderId)
        {
            return Get<OrderDto>(orderId);
        }

        public List<OrderDto> GetMultiple(List<Guid> ids)
        {
            throw new NotImplementedException();
        }

        public void Save(OrderDto order)
        {
            Save(order.Id, order);
            MergeIntoAllCollection(order);
        }

        private void MergeIntoAllCollection(OrderDto order)
        {
            List<OrderDto> allOrders = new List<OrderDto>();
            if (Exists("all"))
            {
                allOrders = Get<List<OrderDto>>("all");
            }

            //If the district already exists in the ALL collection, remove that entry
            if (allOrders.Any(x => x.Id == order.Id))
            {
                allOrders.Remove(allOrders.First(x => x.Id == order.Id));
            }

            //Add the modified district to the ALL collection
            allOrders.Add(order);

            Save("all", allOrders);
        }


        public IEnumerable<OrderDto> GetAll()
        {
            return Get<List<OrderDto>>("all");
        }

    }
}