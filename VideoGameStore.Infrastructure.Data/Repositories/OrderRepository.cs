using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameStore.Domain.Core.Models;
using VideoGameStore.Domain.Interface;

namespace VideoGameStore.Infrastructure.Data.Repositories
{
    public class OrderRepository : IRepository<Order>
    {
        private readonly ApplicationDbContext db;
        public OrderRepository(ApplicationDbContext context)
        {
            db = context;
        }
        public IEnumerable<Order> GetAll()
        {
            return db.Orders;
        }
        public Order Get(int id)
        {
            return db.Orders.Find(id);
        }
        public void Create(Order order)
        {
            db.Orders.Add(order);
        }
        public void Update(Order order)
        {
            db.Orders.Update(order);
        }
        public void Delete(int id)
        {
            Order order = db.Orders.Find(id);
            if (order != null)
                db.Orders.Remove(order);
        }
    }
}
