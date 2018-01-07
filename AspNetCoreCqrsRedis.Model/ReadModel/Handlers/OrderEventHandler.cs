using System.Threading.Tasks;
using AspNetCoreCqrsRedis.Model.ReadModel.Events;
using AspNetCoreCqrsRedis.Model.ReadModel.Repository;
using CQRSlite.Events;

namespace AspNetCoreCqrsRedis.Model.ReadModel.Handlers
{
    public class OrderEventHandler : IEventHandler<OrderCreatedEvent>
    {
        private readonly IOrderRepository _orderRepository;
        
        public OrderEventHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        
        public Task Handle(OrderCreatedEvent message)
        {
            var order = new OrderDto(message.Id, message.Description, 0, message.Version);
            _orderRepository.Save(order);
            return Task.CompletedTask;
        }
    }
}