using BlogEngine.Model.Abstracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogEngine.Model.Models
{
    [Table("Tags")]
    public class Tag : Audit
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }

        [MaxLength(50)]
        [Required]
        public string Name { set; get; }

        [MaxLength(50)]
        [Required]
        public string Type { set; get; }
    }
}
