using System;

namespace AspNetCoreCqrsRedis.API.Command.Command
{
    public class CreateOrderCommand : BaseCommand
    {
        public readonly string OrderId;
        public readonly string Description;

        public CreateOrderCommand(Guid id, string orderId, string description)
        {
            Id = id;
            OrderId = orderId;
            Description = description;
        }
    }
}