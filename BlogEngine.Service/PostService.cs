using BlogEngine.Data.Infrastrutures;
using BlogEngine.Data.Repositories.IRepositories;
using BlogEngine.Model.Models;
using BlogEngine.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogEngine.Service
{
    public class PostService : IPostService
    {
        IPostRepository _postRepository;
        IUnitOfWork _unitOfWork;

        public PostService(IPostRepository postRepository, IUnitOfWork unitOfWork)
        {
            this._postRepository = postRepository;
            this._unitOfWork = unitOfWork;
        }

        public IEnumerable<Post> GetAllPosts()
        {
            return _postRepository.GetAll();
        }
    }
}
