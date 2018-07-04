using BlogEngine.Model.Models;

namespace BlogEngine.Service.IServices
{
    public interface ISubCategoryService
    {
        SubCategory GetSubCategoryById(int subcategoryId);
    }
}
