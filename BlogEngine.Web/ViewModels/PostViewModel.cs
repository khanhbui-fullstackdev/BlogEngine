using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogEngine.Web.ViewModels
{
    public class PostViewModel
    {
        public int ID { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        public string Slug { get; set; }

        public string Image { get; set; }

        public string Summary { get; set; }

        public string Content { get; set; }

        public int CategoryID { get; set; }

        //public virtual Category Category { get; set; }

        public int SubCategoryID { get; set; }

        //public virtual SubCategory SubCategory { get; set; }

        //public virtual IEnumerable<PostTag> PostTags { get; set; }
        //public virtual IEnumerable<Comment> Comments { get; set; }
    }
}