using BlogEngine.Model.Models;
using System.Collections.Generic;

namespace BlogEngine.Service.IServices
{
    public interface IPostService
    {
        IEnumerable<Post> GetAllPosts();
        Post GetPostById(int postId);
        IEnumerable<Post> GetPostsByCategory(int categoryId);
        IEnumerable<Post> GetPostsByCategory(string slug);
        IEnumerable<Post> GetPostsBySubcategory(int subcategoryId);
        IEnumerable<Post> GetPostsByKeyword(string keyword);
    }
}
