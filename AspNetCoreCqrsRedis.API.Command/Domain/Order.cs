using System;
using AspNetCoreCqrsRedis.API.Command.Events;
using CQRSlite.Domain;

namespace AspNetCoreCqrsRedis.API.Command.Domain
{
    public class Order : AggregateRoot
    {
        private string _orderId;
        private string _description;
        
        private Order(){}

        public Order(Guid id, string orderId, string description)
        {
            Id = id;
            _orderId = orderId;
            _description = description;
            
            ApplyChange(new OrderCreatedEvent(id, orderId, description));
        }
    }
}