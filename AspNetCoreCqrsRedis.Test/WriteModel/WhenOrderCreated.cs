using System;
using System.Collections.Generic;
using System.Linq;
using AspNetCoreCqrsRedis.Model.ReadModel.Events;
using AspNetCoreCqrsRedis.Model.WriteModel.Commands;
using AspNetCoreCqrsRedis.Model.WriteModel.Domain;
using AspNetCoreCqrsRedis.Model.WriteModel.Handler;
using CQRSlite.Events;
using Xunit;

namespace AspNetCoreCqrsRedis.Test.WriteModel
{
    public class WhenOrderCreated : Specification<Order, OrderCommandHandler, CreateOrder>
    {
        private Guid _id;
        protected override OrderCommandHandler BuildHandler()
        {
            return new OrderCommandHandler(Session);
        }

        protected override IEnumerable<IEvent> Given()
        {
            _id = Guid.NewGuid();
            return new List<IEvent>();
        }

        protected override CreateOrder When()
        {
            return new CreateOrder(_id, "an_order_description");
        }
        
        [Then]
        public void Should_create_one_event()
        {
            Assert.Equal(1, PublishedEvents.Count);
        }
        
        [Then]
        public void Should_create_correct_event()
        {
            Assert.IsType<OrderCreatedEvent>(PublishedEvents.First());
        }

        [Then]
        public void Should_save_order_description()
        {
            Assert.Equal("an_order_description", ((OrderCreatedEvent)PublishedEvents.First()).Description);
        }
    }
}