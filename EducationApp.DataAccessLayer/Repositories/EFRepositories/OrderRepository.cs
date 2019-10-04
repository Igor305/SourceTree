using EducationApp.DataAccessLayer.AppContext;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Entities.Enum;
using EducationApp.DataAccessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EducationApp.DataAccessLayer.Repositories.EFRepositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationContext aplicationContext) : base(aplicationContext)
        {
        }
        public List<Order> GetAll()
        {
            var all = _applicationContext.Orders.ToList();
            return all;

        }
    }
}
