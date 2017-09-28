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
    public class ProductMapper : IProductMapper
    {
        private IProduct _ProductRepository;
        public ProductMapper(IProduct productRepository)
        {
            _ProductRepository = productRepository;
        }
        public async Task<IEnumerable<ProductVm>> BlGetAll()
        {
            var getData = await _ProductRepository.GetAll();
            var randomProduct = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductVm>>(getData);

            return randomProduct;
        }

        public async Task<ProductVm> BlGetById(int? id)
        {
            var getRepo = await _ProductRepository.GetByIdAsync(id);
            var randomProduct = Mapper.Map<Product, ProductVm>(getRepo);
            return randomProduct;
        }

        public async Task BlInser(ProductVm Product)
        {
            var addMap = Mapper.Map<ProductVm, Product>(Product);
            await _ProductRepository.InsertAsync(addMap);
        }

        public async Task BlUpdateAsync(ProductVm Product)
        {
            var editMap = Mapper.Map<ProductVm, Product>(Product);
            await _ProductRepository.UpdateAsync(editMap);
        }

        public async Task BlDeleteAsync(int id)
        {
            //var getFromR =await _ProductRepository.GetByIdAsync(id);
            await _ProductRepository.DeleteAsync(id);
        }
        public bool ProductExists(int id)
        {
            var r = _ProductRepository.ProductExists(id);
                return r;
            
        }

        public IEnumerable<ProductVm> BlGetAllProduct()
        {
            var getData = _ProductRepository.GetAllProduct();
            var randomCustomer = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductVm>>(getData);

            return randomCustomer;
        }
        //public IEnumerable<CategoryVM> BlGetCategoryIProducts()
        //{
        //    var getData = _ProductRepository.GetCategoryIProduct();
        //    var catPro = Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryVM>>(getData);

        //    return catPro;
        //}
    }
}
