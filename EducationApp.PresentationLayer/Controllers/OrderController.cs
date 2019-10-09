using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EducationApp.BusinessLogicLayer.Models.Orders;
using EducationApp.BusinessLogicLayer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EducationApp.PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public object GetAll()
        {
            var all =_orderService.GetAll();
            return all;
        }
        [HttpPost("Create")]
        public void Create([FromBody]CreateOrderModel createOrderModel)
        {
            _orderService.Create(createOrderModel);
        }
        [HttpPut]
        public void Update([FromBody]UpdateOrderModel updateOrderModel)
        {
            _orderService.Update(updateOrderModel);
        }
        [HttpDelete]
        public void Delete([FromBody]DeleteOderModel deleteOderModel)
        {
            _orderService.Delete(deleteOderModel);
        }
    }
}
