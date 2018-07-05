using BlogEngine.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogEngine.Service.IServices
{
    public interface ICategoryService
    {
        Category GetCategoryById(int categoryId);
        IEnumerable<Category> GetAllCategories();
        IEnumerable<Category> GetAllCategoriesWithSubCategories();
        IEnumerable<Category> GetCategoriesBySubCategory(int subcategoryId);
        IEnumerable<Category> GetCategoriesByKeyword(string keyword);
    }
}
