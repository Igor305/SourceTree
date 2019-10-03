using EducationApp.BusinessLogicLayer.Models.Enums;
using EducationApp.BusinessLogicLayer.Models.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationApp.BusinessLogicLayer.Services.Interfaces
{
    public interface IOrderService
    {
        object GetAll();
        void Create(CreateOrderModel createOrderModel);
        void Update(UpdateOrderModel updateOrderModel);
        void Delete(DeleteOderModel deleteOderModel);
    }
}
