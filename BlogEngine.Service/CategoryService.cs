using BlogEngine.Data.Infrastrutures;
using BlogEngine.Data.Repositories.IRepositories;
using BlogEngine.Model.Models;
using BlogEngine.Service.IServices;
using System;
using System.Collections.Generic;

namespace BlogEngine.Service
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepository;
        private IUnitOfWork _unitOfWork;

        public CategoryService(
            ICategoryRepository categoryRepository,
            IUnitOfWork unitOfWork)
        {
            this._categoryRepository = categoryRepository;
            this._unitOfWork = unitOfWork;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _categoryRepository.GetAll();
        }

        public IEnumerable<Category> GetAllCategoriesWithSubCategories()
        {
            var categories = _categoryRepository.GetAllCategoriesWithSubCategories();
            return categories;
        }

        public IEnumerable<Category> GetCategoriesByKeyword(string keyword)
        {
            var categories = _categoryRepository.GetMulti(x => x.Name.Contains(keyword) && x.Status == true);
            return categories;
        }

        public IEnumerable<Category> GetCategoriesBySubCategory(int subcategoryId)
        {

            throw new NotImplementedException();
        }

        public Category GetCategoryById(int categoryId)
        {
            var category = _categoryRepository.GetSingleByCondition(x => x.ID == categoryId && x.Status == true);
            return category;
        }
    }
}
