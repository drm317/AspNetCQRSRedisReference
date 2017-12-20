using AspNetCoreCqrsRedis.API.Query.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreCqrsRedis.API.Query.Controllers
{
    [Route("order")]
    public class OrderController : Controller
    {
        private readonly IOrderRespository _orderRespository;

        public OrderController(IOrderRespository orderRespository)
        {
            _orderRespository = orderRespository;
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetByOrderId(int orderId)
        {
            var order = _orderRespository.GetByID(orderId);
            if (order == null)
            {
                return BadRequest("No order with Id " + orderId.ToString());
            }

            return Ok();
        }

        [HttpGet]
        [Route("all")]
        public IActionResult GetAll()
        {
            var orders = _orderRespository.GetAll();
            return Ok(orders);
        }
    }
}