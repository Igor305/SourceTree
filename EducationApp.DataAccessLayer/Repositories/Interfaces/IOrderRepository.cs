using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationApp.DataAccessLayer.Repositories.Interfaces
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        List<Order> GetAll();
    }
}
