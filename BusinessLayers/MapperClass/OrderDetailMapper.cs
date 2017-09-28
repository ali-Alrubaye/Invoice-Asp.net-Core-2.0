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
    public class OrderDetailMapper : IOrderDetailMapper
    {
        private IOrderDetail _OrderDetailRepository;
        public OrderDetailMapper(IOrderDetail orderDetailRepository)
        {
            _OrderDetailRepository = orderDetailRepository;
        }
        public async Task<IEnumerable<OrderDetailVm>> BlGetAll()
        {
            var getData = await _OrderDetailRepository.GetAll();
            var randomOrderDetail = Mapper.Map<IEnumerable<OrderDetail>, IEnumerable<OrderDetailVm>>(getData);

            return randomOrderDetail;
        }

        public async Task<IEnumerable<OrderDetailVm>> BlGetById(int? id)
        {
            var getRepo = await _OrderDetailRepository.GetByIdAsync(id);
            var randomOrderDetail = Mapper.Map<IEnumerable<OrderDetail>, IEnumerable<OrderDetailVm>>(getRepo);
            return randomOrderDetail;
        }

        public async Task BlInser(OrderDetailVm OrderDetail)
        {
            var addMap = Mapper.Map<OrderDetailVm, OrderDetail>(OrderDetail);
            await _OrderDetailRepository.InsertAsync(addMap);
        }

        public async Task BlUpdateAsync(OrderDetailVm OrderDetail)
        {
            var editMap = Mapper.Map<OrderDetailVm, OrderDetail>(OrderDetail);
            await _OrderDetailRepository.UpdateAsync(editMap);
        }

        public async Task BlDeleteAsync(int id)
        {
            //var getFromR =await _OrderDetailRepository.GetByIdAsync(id);
            await _OrderDetailRepository.DeleteAsync(id);
        }
        public bool OrderDetailExists(int id)
        {
            var r = _OrderDetailRepository.OrderDetailExists(id);
                return r;
            
        }
        public IEnumerable<OrderDetailVm> BlGetAllOrder()
        {
            var getData = _OrderDetailRepository.BlGetAllOrderDetail();
            var randomCustomer = Mapper.Map<IEnumerable<OrderDetail>, IEnumerable<OrderDetailVm>>(getData);

            return randomCustomer;
        }
    }
}
