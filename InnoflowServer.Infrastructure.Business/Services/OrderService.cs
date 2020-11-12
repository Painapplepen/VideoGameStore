using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameStore.Domain.Core.Models;
using VideoGameStore.Domain.Interface;
using VideoGameStore.Services.Interfaces;

namespace InnoflowServer.Infrastructure.Business.Services
{
    public class OrderService : IService<Order>
    {
        private readonly IRepository<Order> orders;
        public OrderService(IRepository<Order> orderRepository)
        {
            orders = orderRepository;
        }
        public IEnumerable<Order> GetAll()
        {
            return orders.GetAll();
        }
        public bool Create(Order order)
        {
            orders.Create(order);
            return true;
        }
        public Order Get(int id)
        {
            return orders.Get(id);
        }
        public bool Update(Order order)
        {
            orders.Update(order);
            return true;
        }
        public bool Delete(int id)
        {
            orders.Delete(id);
            return true;
        }
    }
}
