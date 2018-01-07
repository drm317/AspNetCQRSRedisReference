using System;
using AspNetCoreCqrsRedis.Model.ReadModel.Events;
using CQRSlite.Domain;

namespace AspNetCoreCqrsRedis.Model.WriteModel.Domain
{
    public class Order : AggregateRoot
    {
        private string _description;
        
        private Order(){}

        public Order(Guid id, string description)
        {
            Id = id;
            _description = description;
            
            ApplyChange(new OrderCreatedEvent(id, description));
        }
    }
}