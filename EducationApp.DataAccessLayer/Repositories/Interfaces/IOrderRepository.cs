using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationApp.DataAccessLayer.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        List<Order> GetAll();
        void CreateOrder(string Description);
        void UpdateOrder(Guid Id, string Descriptioin);
        void DeleteOrder(Guid Id);
    }
}
