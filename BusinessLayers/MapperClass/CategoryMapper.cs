using AutoMapper;
using BusinessLayers.Models;
using Repositories;
using Repositories.IRepositories;
using Repositories.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayers.MapperClass
{
    public class CategoryMapper : ICategoryMapper
    {

        private ICategory _categoryRepository;
        public CategoryMapper(ICategory categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<IEnumerable<CategoryVm>> BlGetAll()
        {
            var getData = await _categoryRepository.GetAll();
            var randomCategory = Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryVm>>(getData);
          
            return randomCategory;
        }

        public async Task<CategoryVm> BlGetById(int? id)
        {
            var getRepo = await _categoryRepository.GetByIdAsync(id);
            var randomCategory = Mapper.Map<Category, CategoryVm>(getRepo);
            return randomCategory;
        }

        public async Task BlInser(CategoryVm Category)
        {
            var addMap = Mapper.Map<CategoryVm, Category>(Category);
            await _categoryRepository.InsertAsync(addMap);
        }

        public async Task BlUpdateAsync(CategoryVm Category)
        {
            var editMap = Mapper.Map<CategoryVm, Category>(Category);
            await _categoryRepository.UpdateAsync(editMap);
        }

        public async Task BlDeleteAsync(int id)
        {
            //var getFromR =await _categoryRepository.GetByIdAsync(id);
            await _categoryRepository.DeleteAsync(id);
        }
        public bool CategoryExists(int id)
        {
            var getRepo = _categoryRepository.CategoryExists(id);
            return getRepo;
        }

        public  IEnumerable<CategoryVm> BlGetAllCategory()
        {
            var getData =  _categoryRepository.GetAllCategory();
            var randomCompany = Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryVm>>(getData);

            return  randomCompany;
        }
    }
}
