using System.Threading.Tasks;
using AspNetCoreCqrsRedis.Model.WriteModel.Commands;
using AspNetCoreCqrsRedis.Model.WriteModel.Domain;
using CQRSlite.Commands;
using CQRSlite.Domain;

namespace AspNetCoreCqrsRedis.Model.WriteModel.Handler
{
    public class OrderCommandHandler : ICommandHandler<CreateOrder>
    {
        private readonly ISession _session;

        public OrderCommandHandler(ISession session)
        {
            _session = session;
        }

        public async Task Handle(CreateOrder message)
        {
            var order = new Order(message.Id, message.Description);
            await _session.Add(order);
            await _session.Commit();
        }
    }
}