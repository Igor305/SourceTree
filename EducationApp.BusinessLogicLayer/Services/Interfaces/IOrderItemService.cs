using EducationApp.BusinessLogicLayer.Models.OrderItems;
using EducationApp.DataAccessLayer.Entities;
using System.Collections.Generic;

namespace EducationApp.BusinessLogicLayer.Services.Interfaces
{
    public interface IOrderItemService
    {
        List<OrderItem> GetAllIsDeleted();
        List<OrderItem> GetAll();
        string Create(CreateOrderItemModel createOrderItemModel);
        string Update(UpdateOrderItemModel updateOrderItemModel);
        string Delete(DeleteOrderItemModel deleteOrderItemModel);
    }
}
