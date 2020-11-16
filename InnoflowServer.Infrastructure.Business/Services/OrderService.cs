using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameStore.Domain.Core.DTO;
using VideoGameStore.Domain.Core.Entities;
using VideoGameStore.Domain.Interface;
using VideoGameStore.Services.Interfaces;

namespace InnoflowServer.Infrastructure.Business.Services
{
    public class OrderService : IService<OrderDTO>
    {
        private IUnitOfWork db { get; set; }
        private IMapper _mapper;

        public OrderService(IUnitOfWork uow, IMapper mapper)
        {
            _mapper = mapper;
            db = uow;
        }

        public IEnumerable<OrderDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<Order>, List<OrderDTO>>(db.Orders.GetAll());
        }

        public bool Create(OrderDTO orderDTO)
        {
            var order = db.Orders.Get(orderDTO.Id);

            if (order != null)
            {
                return false;
            }

            order = new Order
            {
                DateTime = orderDTO.DateTime,
                VideoGameId = orderDTO.VideoGameId
            };

            db.Orders.Create(order);
            db.Save();
            return true;
        }

        public OrderDTO Get(int id)
        {
            var order = db.Orders.Get(id);

            if (order == null)
            {
                return null;
            }

            return _mapper.Map<Order, OrderDTO>(db.Orders.Get(id));
        }

        public bool Update(OrderDTO orderDTO)
        {
            var order = db.Orders.Get(orderDTO.Id);

            if (order == null)
            {
                return false;
            }

            order = new Order
            {
                DateTime = orderDTO.DateTime
            };

            db.Orders.Update(order);
            db.Save();
            return true;
        }

        public bool Delete(int id)
        {
            Order order = db.Orders.Get(id);

            if (order == null)
            {
                return false;

            }
            db.Orders.Delete(id);
            db.Save();
            return true;
        }
    }
}
