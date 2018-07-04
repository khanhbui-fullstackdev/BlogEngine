using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogEngine.Data.Repositories.IRepositories;
using BlogEngine.Model.Models;

namespace BlogEngine.Service.IServices
{
    public class SubCategoryService : ISubCategoryService
    {
        private ISubCategoryRepository _subCategoryRepository;

        public SubCategoryService(ISubCategoryRepository subCategoryRepository)
        {
            this._subCategoryRepository = subCategoryRepository;
        }

        public SubCategory GetSubCategoryById(int subcategoryId)
        {
            var subcategory = _subCategoryRepository.GetSingleByCondition(x => x.ID == subcategoryId && x.Status == true);
            return subcategory;
        }
    }
}
