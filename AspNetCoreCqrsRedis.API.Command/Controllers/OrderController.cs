using AspNetCoreCqrsRedis.API.Command.Command;
using AspNetCoreCqrsRedis.API.Command.Request;
using AutoMapper;
using CQRSlite.Commands;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreCqrsRedis.API.Command.Controllers
{
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICommandSender _commandSender;

        public OrderController(ICommandSender commandSender, IMapper mapper)
        {
            _commandSender = commandSender;
            _mapper = mapper;
        }
        
        [HttpPost("create")]
        public IActionResult GetByOrderId(CreateOrderRequest request)
        {
            var command = _mapper.Map<CreateOrderCommand>(request);
            _commandSender.Send(command);

            return Ok();
        }
    }
}