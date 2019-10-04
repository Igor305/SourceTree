using EducationApp.BusinessLogicLayer.Models.Orders;
using EducationApp.DataAccessLayer.Entities;
using System.Collections.Generic;

namespace EducationApp.BusinessLogicLayer.Services.Interfaces
{
    public interface IOrderService
    {
        List<Order> GetAll();
        void Create(CreateOrderModel createOrderModel);
        void Update(UpdateOrderModel updateOrderModel);
        void Delete(DeleteOderModel deleteOderModel);
    }
}
