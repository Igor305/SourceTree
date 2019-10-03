using EducationApp.BusinessLogicLayer.Models.OrderItems;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationApp.BusinessLogicLayer.Services.Interfaces
{
    public interface IOrderItemService
    {
        object GetAll();
        void Create(CreateOrderItemModel createOrderItemModel, decimal count);
        void Update(UpdateOrderItemModel updateOrderItemModel, decimal count);
        void Delete(DeleteOrderItemModel deleteOrderItemModel);
    }
}
