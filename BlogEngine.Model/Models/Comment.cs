using BlogEngine.Common.Constants;
using BlogEngine.Model.Abstracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogEngine.Model.Models
{
    [Table("Comments")]
    public class Comment : Audit
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }

        [StringLength(255), Column(TypeName = "nvarchar"), Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        [StringLength(300), Column(TypeName = "varchar"), Required(AllowEmptyStrings = false)]
        public string UserName { get; set; }

        [
            Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessage.RequiredField),
            Column(TypeName = "nvarchar")
        ]
        public string Content { get; set; }

        [
            EmailAddress(ErrorMessage = ErrorMessage.InvalidEmail),
            Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessage.RequiredEmail),
            StringLength(50), Column(TypeName = "varchar")
        ]
        public string Email { get; set; }

        public int PostID { get; set; }

        [ForeignKey("PostID")]
        public virtual Post Post { get; set; }
    }
}
