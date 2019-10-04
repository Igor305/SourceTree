using EducationApp.BusinessLogicLayer.Models.OrderItems;
using EducationApp.DataAccessLayer.Entities;
using System.Collections.Generic;

namespace EducationApp.BusinessLogicLayer.Services.Interfaces
{
    public interface IOrderItemService
    {
        List<OrderItem> GetAll();
        void Create(CreateOrderItemModel createOrderItemModel, decimal count);
        void Update(UpdateOrderItemModel updateOrderItemModel, decimal count);
        void Delete(DeleteOrderItemModel deleteOrderItemModel);
    }
}
