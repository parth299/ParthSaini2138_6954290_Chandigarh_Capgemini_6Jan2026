using AutoMapper;
using OrderApi.DTOs;
using OrderApi.Models;
using OrderApi.Repositories;
using log4net;

namespace OrderApi.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repo;

        private readonly IMapper _mapper;

        private static readonly ILog log =
            LogManager.GetLogger(
                typeof(OrderService));

        public OrderService(
            IOrderRepository repo,
            IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<string> CreateOrder(
            OrderDto dto)
        {
            log.Info("Order service started");

            if (dto.Quantity <= 0)
            {
                log.Warn("Invalid quantity");

                return "Invalid quantity";
            }

            var order =
                _mapper.Map<Order>(dto);

            await _repo.AddOrder(order);

            log.Info("Order saved to database");

            return "Order Created";
        }
    }
}