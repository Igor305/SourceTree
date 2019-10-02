using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationApp.DataAccessLayer.Repositories.Interfaces
{
    interface IOrderItemRepository
    {
        List<OrderItem> GetAll();
        void CreateOrderItem(int Amount, TypeCurrency Currency, decimal UnitPrice);
        void UpdateOrderItem(Guid Id, int Amount, TypeCurrency Currency, decimal UnitPrice);
        void DeleteOrderItem(Guid Id);
    }
}
