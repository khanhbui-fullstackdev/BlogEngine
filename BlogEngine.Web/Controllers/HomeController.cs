using AutoMapper;
using BlogEngine.Common.Helpers;
using BlogEngine.Model.Models;
using BlogEngine.Service.IServices;
using BlogEngine.Web.ViewModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogEngine.Web.Controllers
{
    public class HomeController : Controller
    {
        IPostService _postService;
        ICategoryService _categoryService;

        public HomeController(
            IPostService postService,
            ICategoryService categoryService)
        {
            this._postService = postService;
            this._categoryService = categoryService;
        }

        // GET: Home
        public ActionResult Index()
        {
            var postsModel = _postService.GetAllPosts();
            // https://stackoverflow.com/questions/6062192/there-is-already-an-open-datareader-associated-with-this-command-which-must-be-c
            /*
                This can happen if you execute a query while iterating over the results from another query. 
                It is not clear from your example where this happens because the example is not complete.
                One thing that can cause this is lazy loading triggered when iterating over the results of some query.
                This can be easily solved by allowing MARS in your connection string. 
                Add MultipleActiveResultSets=true to the provider part of your connection string 
                (where Data Source, Initial Catalog, etc. are specified).
             */
            var postsViewModel = Mapper.Map<IEnumerable<Post>, IEnumerable<PostViewModel>>(postsModel).ToList();
            return View(postsViewModel);
        }

        [ChildActionOnly]
        public ActionResult Header()
        {
            return PartialView();
        }

        [ChildActionOnly]
        public ActionResult Footer()
        {
            return PartialView();
        }

        [ChildActionOnly]
        public ActionResult Category()
        {
            return PartialView();
        }

        [HttpGet]
        public JsonResult GetCategories()
        {
            try
            {
                var categoriesModel = _categoryService.GetAllCategoriesWithSubCategories();
                var categoriesViewModel = Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryViewModel>>(categoriesModel);
                // https://stackoverflow.com/questions/16949520/circular-reference-detected-exception-while-serializing-object-to-json
                // https://stackoverflow.com/questions/31008219/a-circular-reference-was-detected-while-serializing-an-object-of-type-system-r

                TreeViewModel treeViewModel = new TreeViewModel();
                List<TreeViewModel> treeViewModels = treeViewModel.TreeViewMappingCategory(categoriesViewModel);

                var jsonData = JsonConvert.SerializeObject
                (
                    treeViewModels,
                    Formatting.Indented,
                    new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                        //https://forums.asp.net/t/2127952.aspx?How+to+get+the+JSON+fields+in+all+lowercase
                        //convert C# properties convent to JSON properties' convention. Ex: FirstName --> firstName
                        ContractResolver = new CamelCasePropertyNamesContractResolver()
                    }
                );

                jsonData = jsonData.Replace("_", "data-");

                return Json(new
                {
                    status = true,
                    data = jsonData
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    status = false,
                    errorMessage = ex.InnerException.Message
                }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult GetPostsByKeyword(string keyword)
        {
            try
            {
                var postsModel = _postService.GetPostsByKeyword(keyword).Take(5);
                var postsViewModel = Mapper.Map<IEnumerable<Post>, IEnumerable<PostViewModel>>(postsModel);

                var categoriesModel = _categoryService.GetCategoriesByKeyword(keyword).Take(2);
                var categoriesViewModel = Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryViewModel>>(categoriesModel);

                SearchResultViewModel searchResultViewModel = new SearchResultViewModel();
                searchResultViewModel.Posts = postsViewModel;
                searchResultViewModel.Categories = categoriesViewModel;

                AutocompleteWidgetViewModel autocompleteWidgetViewModel = new AutocompleteWidgetViewModel();
                List<AutocompleteWidgetViewModel> items = autocompleteWidgetViewModel.AutocompleteWidgetMappingSearchResult(searchResultViewModel);

                var jsonData = JsonConvert.SerializeObject
                (
                    items,
                    Formatting.Indented,
                    new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                        ContractResolver = new CamelCasePropertyNamesContractResolver()
                    }
                );

                return Json(new
                {
                    status = true,
                    data = jsonData
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    status = false,
                    error = ex.InnerException.Message
                });
            }
        }

        [ChildActionOnly]
        public PartialViewResult LastestComment()
        {
            return PartialView();
        }
    }
}