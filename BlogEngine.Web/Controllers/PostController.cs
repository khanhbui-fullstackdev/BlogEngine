using AutoMapper;
using BlogEngine.Model.Models;
using BlogEngine.Service.IServices;
using BlogEngine.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogEngine.Web.Controllers
{
    public class PostController : Controller
    {
        private IPostService _postService;


        public PostController(IPostService postService)
        {
            this._postService = postService;
        }

        // GET: Post
        public ActionResult Index(int id)
        {
            var postModel = _postService.GetPostById(id);
            var postViewModel = Mapper.Map<Post, PostViewModel>(postModel);
            return View(postViewModel);
        }

        public ActionResult PostsByCategory(int id)
        {
            var postsModel = _postService.GetPostsByCategory(id);
            var postsViewModel = Mapper.Map<IEnumerable<Post>, IEnumerable<PostViewModel>>(postsModel);
            return View(postsViewModel);
        }

        public ActionResult PostsBySubCategory(int subcategoryId)
        {
            return View();
        }
    }
}