using EducationApp.BusinessLogicLayer.Models.OrderItems;
using EducationApp.BusinessLogicLayer.Services.Interfaces;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;

namespace EducationApp.BusinessLogicLayer.Services
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IOrderItemRepository _orderItemRepository;
        public OrderItemService(IOrderItemRepository orderItemRepository)
        {
            _orderItemRepository = orderItemRepository; 
        }
        public List<OrderItem> GetAll()
        {
            var all = _orderItemRepository.GetAll();
            return all;
        }
        public void Create(CreateOrderItemModel createOrderItemModel, decimal count)
        {
            OrderItem orderItem = new OrderItem();
            orderItem.Amount = createOrderItemModel.Amount;
            orderItem.UnitPrice = createOrderItemModel.UnitPrice;
            count = createOrderItemModel.Amount * createOrderItemModel.UnitPrice;
            orderItem.Count = count;
            orderItem.Currency = createOrderItemModel.Currency;
            orderItem.CreateDateTime = DateTime.Now;
            orderItem.UpdateDateTime = DateTime.Now;
            _orderItemRepository.Create(orderItem);
                       
        }
        public void Update(UpdateOrderItemModel updateOrderItemModel, decimal count)
        {
            var all = _orderItemRepository.GetAll();
            var findOrderItem = all.Find(x => x.Id == updateOrderItemModel.Id);
            findOrderItem.Amount = updateOrderItemModel.Amount;
            findOrderItem.UnitPrice = updateOrderItemModel.UnitPrice;
            count = updateOrderItemModel.Amount * updateOrderItemModel.UnitPrice;
            findOrderItem.Count = count;
            findOrderItem.Currency = updateOrderItemModel.Currency;
            findOrderItem.UpdateDateTime = DateTime.Now;
            _orderItemRepository.Update(findOrderItem);
        }
        public void Delete(DeleteOrderItemModel deleteOrderItemModel)
        {
            var all = _orderItemRepository.GetAll();
            var findOrderItem = all.Find(x => x.Id == deleteOrderItemModel.Id);
            findOrderItem.IsDeleted = true;
            _orderItemRepository.Update(findOrderItem);
        }
    }
}
