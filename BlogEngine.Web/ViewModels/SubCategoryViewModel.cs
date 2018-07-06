using BlogEngine.Model.Abstracts;

namespace BlogEngine.Web.ViewModels
{
    public class SubCategoryViewModel : Audit
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Slug { get; set; }

        public string Summary { get; set; }

        public int CategoryID { get; set; }

        public virtual CategoryViewModel Category { get; set; }
    }
}