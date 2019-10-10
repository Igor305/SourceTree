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
        public List<OrderItem> GetAllIsDeleted()
        {
            var allIsDeleted = _orderItemRepository.GetAllIsDeleted();
            return allIsDeleted;
        }
        public List<OrderItem> GetAll()
        {
            var all = _orderItemRepository.GetAll();
            return all;
        }
        public string Create(CreateOrderItemModel createOrderItemModel)
        {
            OrderItem orderItem = new OrderItem();
            orderItem.Amount = createOrderItemModel.Amount;
            orderItem.UnitPrice = createOrderItemModel.UnitPrice;
            decimal count = createOrderItemModel.Amount * createOrderItemModel.UnitPrice;
            orderItem.Count = count;
            orderItem.Currency = createOrderItemModel.Currency;
            orderItem.CreateDateTime = DateTime.Now;
            orderItem.UpdateDateTime = DateTime.Now;
            _orderItemRepository.Create(orderItem);
            string create = "Добавлена новая запись";
            return create;
                       
        }
        public string Update(UpdateOrderItemModel updateOrderItemModel)
        {
            var all = _orderItemRepository.GetAll();
            var findOrderItem = all.Find(x => x.Id == updateOrderItemModel.Id);
            findOrderItem.Amount = updateOrderItemModel.Amount;
            findOrderItem.UnitPrice = updateOrderItemModel.UnitPrice;
            decimal count = updateOrderItemModel.Amount * updateOrderItemModel.UnitPrice;
            findOrderItem.Count = count;
            findOrderItem.Currency = updateOrderItemModel.Currency;
            findOrderItem.UpdateDateTime = DateTime.Now;
            _orderItemRepository.Update(findOrderItem);
            string update = "Запись обновлена";
            return update;
        }
        public string Delete(DeleteOrderItemModel deleteOrderItemModel)
        {
            var all = _orderItemRepository.GetAll();
            var findOrderItem = all.Find(x => x.Id == deleteOrderItemModel.Id);
            findOrderItem.IsDeleted = true;
            _orderItemRepository.Update(findOrderItem);
            string delete = "Запись удалена";
            return delete;
        }
    }
}
