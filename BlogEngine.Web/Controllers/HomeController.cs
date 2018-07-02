using AutoMapper;
using BlogEngine.Model.Models;
using BlogEngine.Service.IServices;
using BlogEngine.Web.ViewModels;
using Newtonsoft.Json;
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
                var result = JsonConvert.SerializeObject
                (
                    categoriesViewModel, 
                    Formatting.Indented,
                    new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    }
                );

                return Json(new
                {
                    status = true,
                    data = result
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

        [ChildActionOnly]
        public PartialViewResult LastestComment()
        {
            return PartialView();
        }
    }
}