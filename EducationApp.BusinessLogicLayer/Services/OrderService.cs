using EducationApp.BusinessLogicLayer.Models.Orders;
using EducationApp.BusinessLogicLayer.Services.Interfaces;
using EducationApp.DataAccessLayer.Repositories.Interfaces;

namespace EducationApp.BusinessLogicLayer.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public object GetAll()
        {
            var all =_orderRepository.GetAll();
            return all;
        }
        public void Create(CreateOrderModel createOrderModel)
        {
            _orderRepository.CreateOrder(createOrderModel.Description);
        }
        public void Update(UpdateOrderModel updateOrderModel)
        {
            _orderRepository.UpdateOrder(updateOrderModel.Id, updateOrderModel.Description);
        }
        public void Delete(DeleteOderModel deleteOderModel)
        {
            _orderRepository.DeleteOrder(deleteOderModel.Id);
        }
    }
}
