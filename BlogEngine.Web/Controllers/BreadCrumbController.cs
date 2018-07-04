using BlogEngine.Service.IServices;
using BlogEngine.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogEngine.Web.Controllers
{
    public class BreadCrumbController : Controller
    {
        private ICategoryService _categoryService;
        private ISubCategoryService _subCategoryService;

        public BreadCrumbController(
            ICategoryService categoryService,
            ISubCategoryService subCategoryService)
        {
            this._categoryService = categoryService;
            this._subCategoryService = subCategoryService;
        }

        [ChildActionOnly]
        public ActionResult BreadCrumb(int? categoryId, int? subcategoryId)
        {
            if (categoryId.HasValue)
            {
                var category = _categoryService.GetCategoryById(categoryId.Value);
                BreadCrumbViewModel breadCrumbViewModel = new BreadCrumbViewModel();
                breadCrumbViewModel.CategoryId = category.ID;
                breadCrumbViewModel.Name = category.Name;
                return PartialView(breadCrumbViewModel);
            }
            else if (subcategoryId.HasValue)
            {
                var subcategory = _subCategoryService.GetSubCategoryById(subcategoryId.Value);
                BreadCrumbViewModel breadCrumbViewModel = new BreadCrumbViewModel()
                {
                    CategoryId = subcategory.Category.ID,
                    SubCategoryId = subcategory.ID,
                    Name = subcategory.Category.Name + "/" + subcategory.Name
                };
                return PartialView(breadCrumbViewModel);
            }
            return PartialView();
        }       
    }
}
