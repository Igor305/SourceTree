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
    public class OrderItemRepository : GenericRepository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository (ApplicationContext applicationContext) : base(applicationContext)
        {

        }
        public List<OrderItem> GetAll()
        {
            var all = _applicationContext.OrderItems.ToList();
            return all;
        }
    }
}
