using BlogEngine.Model.Abstracts;
using System.Collections.Generic;

namespace BlogEngine.Web.ViewModels
{
    public class CategoryViewModel : AuditViewModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Slug { get; set; }
       
        public string Image { get; set; }

        public string Summary { get; set; }

        public virtual IEnumerable<PostViewModel> Posts { get; set; }

        public virtual ICollection<SubCategoryViewModel> SubCategories { get; set; }
    }
}