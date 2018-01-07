using System;
using AspNetCoreCqrsRedis.API.Command.Request;
using AspNetCoreCqrsRedis.Model.WriteModel.Commands;
using CQRSlite.Commands;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreCqrsRedis.API.Command.Controllers
{
    public class OrderController : Controller
    {
        private readonly ICommandSender _commandSender;

        public OrderController(ICommandSender commandSender)
        {
            _commandSender = commandSender;
        }
        
        [HttpPost]
        public IActionResult Create([FromBody] CreateOrderRequest request)
        {
            var createOrderCommand = new CreateOrder(Guid.NewGuid(), request.Description);
            _commandSender.Send(createOrderCommand);

            return Ok();
        }
    }
}