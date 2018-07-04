using BlogEngine.Data.Infrastrutures;
using BlogEngine.Model.Models;
using System.Collections.Generic;

namespace BlogEngine.Data.Repositories.IRepositories
{
    public interface IPostRepository : IRepositoryBase<Post>
    {
        IEnumerable<Post> GetPostsBySubCategory(int subcategoryId);
    }
}
