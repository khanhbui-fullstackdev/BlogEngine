using BlogEngine.Model.Abstracts;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogEngine.Model.Models
{
    [Table("Posts")]
    public class Post : Audit
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [StringLength(255), Column(TypeName = "nvarchar"), Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        [StringLength(255)]
        [Column(TypeName = "varchar")]
        public string Slug { get; set; }

        [Column(TypeName = "varchar"), StringLength(255)]
        public string Image { get; set; }

        [StringLength(500), Column(TypeName = "nvarchar")]
        public string Summary { get; set; }

        public string Content { get; set; }

        public int CategoryID { get; set; }

        [ForeignKey("CategoryID")]
        public virtual Category Category { get; set; }
        
        public virtual IEnumerable<PostTag> PostTags { get; set; }
        public virtual IEnumerable<Comment> Comments { get; set; }
    }
}
