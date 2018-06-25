using BlogEngine.Common.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogEngine.Model.Models
{
    [Table("Contacts")]
    public class Contact
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ContactId { get; set; }

        [
            Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessage.RequiredField),
            MinLength(2, ErrorMessage = ErrorMessage.MinLengthField),
            MaxLength(255, ErrorMessage = ErrorMessage.MaxLengthField),
            StringLength(255),
            Column(TypeName = "nvarchar")
        ]
        public string ContactName { get; set; }

        [
            EmailAddress(ErrorMessage = ErrorMessage.InvalidEmail),
            Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessage.RequiredEmail),
            StringLength(50), Column(TypeName = "varchar")
        ]
        public string ContactEmail { get; set; }

        [
            Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessage.RequiredField),
            StringLength(500),
            Column(TypeName = "nvarchar")
        ]
        public string Content { get; set; }
    }
}
