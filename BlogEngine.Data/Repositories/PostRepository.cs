using System.Collections.Generic;
using System.Linq;
using BlogEngine.Data.Infrastrutures;
using BlogEngine.Data.Repositories.IRepositories;
using BlogEngine.Model.Models;

namespace BlogEngine.Data.Repositories
{
    public class PostRepository : RepositoryBase<Post>, IPostRepository
    {
        public PostRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }

        public IEnumerable<Post> GetPostsBySubCategory(int subcategoryId)
        {
            var posts = from subcategory in DbContext.SubCategories
                        join category in DbContext.Categories on
                        subcategory.CategoryID equals category.ID
                        join post in DbContext.Posts on
                        category.ID equals post.CategoryID
                        where subcategory.ID == subcategoryId && post.Status == true
                        select post;
            return posts;
        }
    }
}
