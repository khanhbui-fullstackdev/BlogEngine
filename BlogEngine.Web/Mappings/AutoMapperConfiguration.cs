using AutoMapper;
using BlogEngine.Model.Models;
using BlogEngine.Web.ViewModels;

namespace BlogEngine.Web.Mappings
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Post, PostViewModel>();                
            });
        }
    }
}