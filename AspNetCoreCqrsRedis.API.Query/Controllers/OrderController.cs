using System;
using AspNetCoreCqrsRedis.Model.ReadModel.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreCqrsRedis.API.Query.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet]
        public IActionResult GetByOrderId(string orderId)
        {
            var order = _orderRepository.GetByID(Guid.Parse(orderId));
            if (order == null)
            {
                return BadRequest("No order with Id " + orderId.ToString());
            }

            return Ok();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var orders = _orderRepository.GetAll();
            return Ok(orders);
        }
    }
}