using EducationApp.BusinessLogicLayer.Models.OrderItems;
using EducationApp.BusinessLogicLayer.Services.Interfaces;
using EducationApp.DataAccessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationApp.BusinessLogicLayer.Services
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IOrderItemRepository _orderItemRepository;
        public OrderItemService(IOrderItemRepository orderItemRepository)
        {
            _orderItemRepository = orderItemRepository; 
        }
        public object GetAll()
        {
            var all = _orderItemRepository.GetAll();
            return all;
        }
        public void Create(CreateOrderItemModel createOrderItemModel, decimal count)
        {
            count = createOrderItemModel.Amount * createOrderItemModel.UnitPrice;
           _orderItemRepository.CreateOrderItem(createOrderItemModel.Amount, createOrderItemModel.Currency, createOrderItemModel.UnitPrice, count);
                       
        }
        public void Update(UpdateOrderItemModel updateOrderItemModel, decimal count)
        {
            count = updateOrderItemModel.Amount * updateOrderItemModel.UnitPrice;
            _orderItemRepository.UpdateOrderItem(updateOrderItemModel.Id, updateOrderItemModel.Amount, updateOrderItemModel.Currency, updateOrderItemModel.UnitPrice, count);
        }
        public void Delete(DeleteOrderItemModel deleteOrderItemModel)
        {
            _orderItemRepository.DeleteOrderItem(deleteOrderItemModel.Id);
        }
    }
}
