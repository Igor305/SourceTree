using EducationApp.DataAccessLayer.AppContext;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Entities.Enum;
using EducationApp.DataAccessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EducationApp.DataAccessLayer.Repositories.EFRepositories
{
    public class OrderItemRepository : GenericRepository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository (ApplicationContext applicationContext) : base(applicationContext)
        {

        }
        public List<OrderItem> GetAll()
        {
            var all = _applicationContext.OrderItems.ToList();
            return all;
        }
        public void CreateOrderItem(int Amount, TypeCurrency Currency, decimal UnitPrice)
        {
            OrderItem orderItem = new OrderItem();
            orderItem.Amount = Amount;
            orderItem.UnitPrice = UnitPrice;
            orderItem.Currency = Currency;
            orderItem.CreateDateTime = DateTime.Now;
            orderItem.UpdateDateTime = DateTime.Now;
            Create(orderItem);
        }
        public void UpdateOrderItem(Guid Id, int Amount, TypeCurrency Currency, decimal UnitPrice)
        {
            var findOrderItem = _applicationContext.OrderItems.Find(Id);
            findOrderItem.Amount = Amount;
            findOrderItem.UnitPrice = UnitPrice;
            findOrderItem.Currency = Currency;
            findOrderItem.UpdateDateTime = DateTime.Now;
            Update(findOrderItem);
        }
        public void DeleteOrderItem(Guid Id)
        {
            var findOrderItem = _applicationContext.OrderItems.Find(Id);
            findOrderItem.IsDeleted = true;
            Update(findOrderItem);
        }
    }
}
