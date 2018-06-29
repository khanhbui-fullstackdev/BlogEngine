using BlogEngine.Model.Models;
using BlogEngine.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogEngine.Web.Infrastructure.Extensions
{
    /// <summary>
    /// Extention Method of class PostCategory 
    /// It must be static class and static method
    /// </summary>
    /// <param name="Post"></param>
    /// <param name="PostViewModel"></param>
    public static class EntityExtensions
    {
        public static void UpdatePost(this Post post, PostViewModel postViewModel)
        {
            post.ID = postViewModel.ID;
            post.Name = postViewModel.Name;
            post.Slug = postViewModel.Slug;
            post.Summary = postViewModel.Summary;
        }
    }
}