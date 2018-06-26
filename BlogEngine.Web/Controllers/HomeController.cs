using BlogEngine.Service.IServices;
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

        public HomeController(IPostService postService)
        {
            this._postService = postService;
        }

        // GET: Home
        public ActionResult Index()
        {
            var posts = _postService.GetAllPosts();
            return View(posts);
        }
    }
}