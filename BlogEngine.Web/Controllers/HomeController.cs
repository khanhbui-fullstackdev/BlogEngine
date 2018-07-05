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
            var postModel = _postService.GetAllPosts();
            var postViewModel = Mapper.Map<IEnumerable<Post>, IEnumerable<PostViewModel>>(postModel);
            return View(postViewModel);
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
        public ActionResult GetPostsByKeyword(string keyword)
        {
            var postsModel = _postService.GetPostsByKeyword(keyword).Take(5);
            var categoriesModel = _categoryService.GetCategoriesByKeyword(keyword).Take(2);
            return View();
        }

        [ChildActionOnly]
        public PartialViewResult LastestComment()
        {
            return PartialView();
        }
    }
}