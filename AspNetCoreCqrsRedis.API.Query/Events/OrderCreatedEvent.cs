using System;

namespace AspNetCoreCqrsRedis.API.Query.Events
{
    public class OrderCreatedEvent : BaseEvent
    {
        public string OrderId { get; set; }
        
        public string Description { get; set; }

        public OrderCreatedEvent(Guid id, string orderId, string description)
        {
            Id = id;
            OrderId = orderId;
            Description = description;
        }
    }
}