using System;
using CQRSlite.Events;

namespace AspNetCoreCqrsRedis.Model.ReadModel.Events
{
    public class OrderCreatedEvent : IEvent
    {
        public readonly string Description;
        
        public OrderCreatedEvent(Guid id, string description)
        {
            Id = id;
            Description = description;
        }

        public Guid Id { get; set; }
        public int Version { get; set; }
        public DateTimeOffset TimeStamp { get; set; }
    }
}