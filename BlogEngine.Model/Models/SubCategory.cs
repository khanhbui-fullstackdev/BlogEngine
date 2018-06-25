using BlogEngine.Common.Constants;
using BlogEngine.Model.Abstracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogEngine.Model.Models
{
    [Table("SubCategories")]
    public class SubCategory : Audit
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [
            Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessage.RequiredField),
            MinLength(2, ErrorMessage = ErrorMessage.MinLengthField),
            MaxLength(255, ErrorMessage = ErrorMessage.MaxLengthField),
            StringLength(255),
            Column(TypeName = "nvarchar")
        ]
        public string Name { get; set; }

        [StringLength(255)]
        [Column(TypeName = "varchar")]
        public string Slug { get; set; }

        [StringLength(500), Column(TypeName = "nvarchar")]
        public string Summary { get; set; }

        public int CategoryID { get; set; }

        [ForeignKey("CategoryID")]
        public virtual Category Category { get; set; }
    }
}
