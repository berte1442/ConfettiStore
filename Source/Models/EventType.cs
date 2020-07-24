using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConfettiStore.Models
{
    [Table("EventTypes")]
    public class EventType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EventTypeId { get; set; }

        [Display(Name = "Event Name")]
        [MaxLength(50)]
        public string EventName { get; set; }

        public ICollection<CustomerOrder> CustomerOrders { get; set; }
    }
}
