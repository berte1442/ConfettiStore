using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConfettiStore.Models
{
    [Table("Statuses")]
    public class Status
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int StatusId { get; set; }

        [Display(Name = "Status Name")]
        [MaxLength(50)]
        public string StatusName { get; set; }

        public ICollection<CustomerOrder> CustomerOrders { get; set; }
    }
}
