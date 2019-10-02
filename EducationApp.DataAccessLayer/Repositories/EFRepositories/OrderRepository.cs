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
        public void CreateOrder(string Description, TypeStatus Status)
        {
            Order order = new Order();
            order.Description = Description;
            order.Status = Status;
            order.CreateDateTime = DateTime.Now;
            order.UpdateDateTime = DateTime.Now;
            Create(order);
        }
        public void UpdateOrder(Guid Id, string Descriptioin, TypeStatus Status)
        {
            var findOrder = _applicationContext.Orders.Find(Id);
            findOrder.Description = Descriptioin;
            findOrder.Status = Status;
            findOrder.UpdateDateTime = DateTime.Now;
            Update(findOrder);
        }
        public void DeleteOrder(Guid Id)
        {
            var findOrder = _applicationContext.Orders.Find(Id);
            findOrder.IsDeleted = true;
            Update(findOrder);
        }
    }
}
