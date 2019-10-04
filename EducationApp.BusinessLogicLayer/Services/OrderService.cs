using EducationApp.BusinessLogicLayer.Models.Orders;
using EducationApp.BusinessLogicLayer.Services.Interfaces;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;

namespace EducationApp.BusinessLogicLayer.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public List<Order> GetAll()
        {
            var all =_orderRepository.GetAll();
            return all;
        }
        public void Create(CreateOrderModel createOrderModel)
        {
            Order order = new Order();
            order.Description = createOrderModel.Description;
            order.CreateDateTime = DateTime.Now;
            order.UpdateDateTime = DateTime.Now;
            _orderRepository.Create(order);
        }
        public void Update(UpdateOrderModel updateOrderModel)
        {
            var all = _orderRepository.GetAll();
            var findOrder = all.Find(x => x.Id == updateOrderModel.Id);
            findOrder.Description = updateOrderModel.Description;
            findOrder.UpdateDateTime = DateTime.Now;
            _orderRepository.Update(findOrder);
        }
        public void Delete(DeleteOderModel deleteOderModel)
        {
            var all = _orderRepository.GetAll();
            var findOrder = all.Find(x => x.Id == deleteOderModel.Id);
            findOrder.IsDeleted = true;
            _orderRepository.Update(findOrder);
        }
    }
}
