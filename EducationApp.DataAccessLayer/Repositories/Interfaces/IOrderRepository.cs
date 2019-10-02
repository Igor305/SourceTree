using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationApp.DataAccessLayer.Repositories.Interfaces
{
    interface IOrderRepository
    {
        List<Order> GetAll();
        void CreateOrder(string Description, TypeStatus Status);
        void UpdateOrder(Guid Id, string Descriptioin, TypeStatus Status);
        void DeleteOrder(Guid Id);
    }
}
