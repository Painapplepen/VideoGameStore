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

        public async Task<IEnumerable<OrderDTO>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<Order>, List<OrderDTO>>(await db.Orders.GetAllAsync());
        }

        public async Task<bool> CreateAsync(OrderDTO orderDTO)
        {
            var order = await db.Orders.GetAsync(orderDTO.Id);

            if (order != null)
            {
                return false;
            }

            order = new Order
            {
                DateTime = orderDTO.DateTime
            };

            await db.Orders.CreateAsync(order);

            return true;
        }

        public async Task<OrderDTO> GetAsync(int id)
        {
            var order = await db.Orders.GetAsync(id);

            if (order == null)
            {
                return null;
            }

            return _mapper.Map<Order, OrderDTO>(await db.Orders.GetAsync(id));
        }

        public async Task<bool> UpdateAsync(OrderDTO orderDTO)
        {
            var order = await db.Orders.GetAsync(orderDTO.Id);

            if (order == null)
            {
                return false;
            }

            order = new Order
            {
                DateTime = orderDTO.DateTime
            };

            await db.Orders.UpdateAsync(order);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var comment = await db.Orders.GetAsync(id);

            if (comment == null)
            {
                return false;

            }

            return await db.Orders.DeleteAsync(id);
        }
    }
}
