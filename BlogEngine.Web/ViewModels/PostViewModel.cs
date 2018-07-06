using BlogEngine.Model.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogEngine.Web.ViewModels
{
    public class PostViewModel : AuditViewModel
    {
        public int ID { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        public string Slug { get; set; }

        public string Image { get; set; }

        private string summary;
        public string Summary
        {
            get { return summary; }
            set
            {
                summary = value;
                if (summary.Length > 250)
                {
                    summary = value.Remove(251);
                }
            }
        }

        public string Content { get; set; }

        public string Quote { get; set; }

        public int CategoryID { get; set; }

        public virtual CategoryViewModel Category { get; set; }

        //public virtual IEnumerable<PostTagViewModel> PostTags { get; set; }
        public virtual IEnumerable<CommentViewModel> Comments { get; set; }
    }
}