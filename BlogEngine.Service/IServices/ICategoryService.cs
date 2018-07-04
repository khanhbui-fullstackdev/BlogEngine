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
        IEnumerable<Category> GetAllCategories();
        IEnumerable<Category> GetAllCategoriesWithSubCategories();
        IEnumerable<Category> GetCategoriesBySubCategory(int subcategoryId);
    }
}
