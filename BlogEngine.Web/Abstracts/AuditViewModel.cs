using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogEngine.Model.Abstracts
{
    public abstract class AuditViewModel
    {
        public DateTime? CreatedDate { get; set; }

        [StringLength(255), Column(TypeName = "varchar")]
        public string CreatedBy { get; set; }

        [StringLength(255), Column(TypeName = "varchar")]
        public string UpdatedBy { get; set; }
    }
}
