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
    }
}
