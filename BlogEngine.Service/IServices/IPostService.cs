using BlogEngine.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogEngine.Service.IServices
{
    public interface IPostService
    {
        IEnumerable<Post> GetAllPosts();
        Post GetPostById(int postId);
        IEnumerable<Post> GetPostsByCategory(int categoryId);
        IEnumerable<Post> GetPostsByCategory(string slug);
        IEnumerable<Post> GetPostsBySubcategory(int subcategoryId);
    }
}
