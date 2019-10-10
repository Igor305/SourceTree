using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EducationApp.BusinessLogicLayer.Models.OrderItems;
using EducationApp.BusinessLogicLayer.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EducationApp.PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItemService _orderItemService;
        public OrderItemController(IOrderItemService orderItemService)
        {
            _orderItemService = orderItemService;
        }
        /// <summary>
        /// Get all OrderItem (IsDeleted = true)
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     Get/GetAllIsDeleted
        ///
        /// </remarks>
        [HttpGet("GetAllIsDeleted")]
        public object GetAllIsDeleted()
        {
            var allIsDeleted = _orderItemService.GetAllIsDeleted();
            return allIsDeleted;
        }
        /// <summary>
        /// Get all OrderItem
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     Get/GetAll
        ///
        /// </remarks>
        [HttpGet("GetAll")]
        public object GetAll()
        {
            var all = _orderItemService.GetAll();
            return all;
        }
        /// <summary>
        /// Create new OrderItem
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST/Create
        ///     {
        ///         "Description": "Выгодный товар"
        ///     }
        ///
        /// </remarks>
        [HttpPost("Create")]
        public string Create([FromBody]CreateOrderItemModel createOrderModel)
        {
            string create = _orderItemService.Create(createOrderModel);
            return create;
        }
        /// <summary>
        /// Update OrderItem for Id
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT/Update
        ///     {
        ///         "Id": "",
        ///         "Description": "Выгодный товар"
        ///     }
        ///
        /// </remarks>
        [HttpPut("Update")]
        public string Update([FromBody]UpdateOrderItemModel updateOrderModel)
        {
            string update = _orderItemService.Update(updateOrderModel);
            return update;
        }
        /// <summary>
        /// Delete OrderItem for Id
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     DELETE/Delete
        ///     {
        ///         "Id": ""
        ///     }
        ///
        /// </remarks>
        [HttpDelete("Delete")]
        public string Delete([FromBody]DeleteOrderItemModel deleteOderModel)
        {
            string delete = _orderItemService.Delete(deleteOderModel);
            return delete;
        }
    }
}