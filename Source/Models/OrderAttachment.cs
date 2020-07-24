using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConfettiStore.Models
{
    [Table("OrderAttachments")]
    public class OrderAttachment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderAttachmentId { get; set; }

        public int OrderId { get; set; }

        public DateTimeOffset Created { get; set; }

        [ForeignKey("OrderId")]
        public virtual CustomerOrder Order { get; set; }
    }
}
