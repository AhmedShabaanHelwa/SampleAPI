using Microsoft.AspNetCore.Mvc;
using SampleAPI.Models;
using SampleAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private IOrderRepository _orderRepository { set; get; }
        /* Inject the repository */
        public OrderController(IOrderRepository repository)
        {
            _orderRepository = repository;
        }

        [HttpGet(Name = "GetAllOrders")]
        public IActionResult Get()
        {
            return Ok(_orderRepository.Get());
        }
        [HttpGet("{id:guid}", Name = "GetOrderById")]
        public IActionResult GetById(Guid id)
        {
            return Ok(_orderRepository.Get(id));
        }

        [HttpPost]
        public IActionResult Post(Order request)
        {
            var order = new Order()
            { 
                Id = request.Id,
                ItemsIds = request.ItemsIds
            };
            _orderRepository.Add(order);
            return Ok();
        }
        //Lets chcek whether it needs to match the "orderId" or not.
        [HttpPut("{id:guid}")]
        public IActionResult Put(Guid orderId, Order request)
        {
            var order = new Order() 
            { 
                Id = request.Id,
                ItemsIds = request.ItemsIds
            };
            _orderRepository.Update(orderId, request);
            return Ok();
        }
        [HttpDelete("{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            return Ok(_orderRepository.Delete(id));
        }
    }
}
