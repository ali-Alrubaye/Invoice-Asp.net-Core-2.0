using AutoMapper;
using BusinessLayers.Models;
using Repositories;
using Repositories.IRepositories;
using Repositories.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLayers.MapperClass
{
    public class OrderMapper : IOrderMapper
    {
        private IOrder _OrderRepository;
        public OrderMapper(IOrder orderRepository)
        {
            _OrderRepository = orderRepository;
        }
        public async Task<IEnumerable<OrderVm>> BlGetAll()
        {
            var getData = await _OrderRepository.GetAll();
            var randomOrder = Mapper.Map<IEnumerable<Order>, IEnumerable<OrderVm>>(getData);

            return randomOrder;
        }

        public async Task<OrderVm> BlGetById(int? id)
        {
            var getRepo = await _OrderRepository.GetByIdAsync(id);
            var randomOrder = Mapper.Map<Order, OrderVm>(getRepo);
            return randomOrder;
        }
        public async Task<List<OrderVm>> GetOrderById(int? id)
        {
            var getRepo = await _OrderRepository.GetOrderById(id);
            var randomOrder = Mapper.Map<List<Order>, List<OrderVm>>(getRepo);
            return randomOrder;
        }
        public async Task BlInser(OrderVm Order)
        {
            var addMap = Mapper.Map<OrderVm, Order>(Order);
            await _OrderRepository.InsertAsync(addMap);
        }

        public async Task BlUpdateAsync(OrderVm Order)
        {
            var editMap = Mapper.Map<OrderVm, Order>(Order);
            await _OrderRepository.UpdateAsync(editMap);
        }

        public async Task BlDeleteAsync(int id)
        {
            //var getFromR =await _OrderRepository.GetByIdAsync(id);
            await _OrderRepository.DeleteAsync(id);
        }
        public bool OrderExists(int id)
        {
            var r = _OrderRepository.OrderExists(id);
            return r;
        }
        public IEnumerable<OrderVm> BlGetAllOrder()
        {
            var getData = _OrderRepository.BlGetAllOrder();
            var r = Mapper.Map<IEnumerable<Order>, IEnumerable<OrderVm>>(getData);

            return r;
        }
    }
}
