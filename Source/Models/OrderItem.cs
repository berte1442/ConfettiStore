using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConfettiStore.Models
{
    [Table("OrderItems")]
    public class OrderItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderItemId { get; set; }

        public int OrderId { get; set; }

        public int ConfettiId { get; set; }

        [ForeignKey("OrderId")]
        [Display(Name="Customer Order #")]
        public virtual CustomerOrder CustomerOrder { get; set; }

        [ForeignKey("ConfettiId")]
        public virtual Confetti Confetti { get; set; }
    }
}
