using BlogEngine.Model.Models;
using System.Collections.Generic;

namespace BlogEngine.Web.ViewModels
{
    public class SearchResultViewModel
    {
        public IEnumerable<PostViewModel> Posts { get; set; }
        public IEnumerable<CategoryViewModel> Categories { get; set; }
    }
}