using EducationApp.BusinessLogicLayer.Models.Orders;
using EducationApp.DataAccessLayer.Entities;
using System.Collections.Generic;

namespace EducationApp.BusinessLogicLayer.Services.Interfaces
{
    public interface IOrderService
    {
        List<Order> GetAllIsDeleted();
        List<Order> GetAll();
        string Create(CreateOrderModel createOrderModel);
        string Update(UpdateOrderModel updateOrderModel);
        string Delete(DeleteOderModel deleteOderModel);
    }
}
