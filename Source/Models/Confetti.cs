using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConfettiStore.Models
{
    public class Confetti
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ConfettiId { get; set; }

        [Display(Name = "Confetti")]
        [MaxLength(50)]
        public string ConfettiName { get; set; }

        public bool Active { get; set; }

        [MaxLength(50)]
        public string Image { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }

        public ICollection<ConfettiCategory> ConfettiCategories { get; set; }
    }
}
