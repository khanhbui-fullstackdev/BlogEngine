using BlogEngine.Model.Models;
using BlogEngine.Web.ViewModels;
using System;

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

        public static void UpdateContact(this Contact contact,ContactViewModel contactViewModel)
        {
            contact.ContactId = contactViewModel.ContactId;
            contact.ContactName = contactViewModel.ContactName;
            contact.ContactEmail = contactViewModel.ContactEmail;
            contact.Content = contactViewModel.Content;
            contact.CreatedDate = DateTime.Now;
        }
    }
}