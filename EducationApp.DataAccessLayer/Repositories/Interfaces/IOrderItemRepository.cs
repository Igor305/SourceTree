using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationApp.DataAccessLayer.Repositories.Interfaces
{
    public interface IOrderItemRepository
    {
        List<OrderItem> GetAll();
        void CreateOrderItem(int Amount, TypeCurrency Currency, decimal UnitPrice, decimal Count);
        void UpdateOrderItem(Guid Id, int Amount, TypeCurrency Currency, decimal UnitPrice, decimal Count);
        void DeleteOrderItem(Guid Id);
    }
}
