using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConfettiStore.Models
{
    [Table("Addresses")]
    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AddressId { get; set; }

        [Display(Name = "Address Name")]
        [MaxLength(50)]
        public string AddressName { get; set; }

        [Display(Name = "Address 1")]
        [MaxLength(50)]
        public string Address1 { get; set; }

        [Display(Name = "Address 2")]
        [MaxLength(50)]
        public string Address2 { get; set; }

        [MaxLength(50)]
        public string City { get; set; }

        [Display(Name = "State")]
        [MaxLength(50)]
        public string StateName { get; set; }

        [Display(Name = "Zip Code")]
        [MaxLength(20)]
        public string ZipCode { get; set; }

        [MaxLength(500)]
        public string Note { get; set; }

        [Display(Name = "Distance in Miles")]
        public double DistanceMiles { get; set; }

        public int CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }

        public ICollection<CustomerOrder> CustomerOrders { get; set; }
    }
}
