using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConfettiStore.Models
{
    [Table("Customers")]
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Customer ID")]
        public int CustomerId { get; set; }

        [Display(Name = "First Name")]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(150)]
        public string Email { get; set; }

        [Display(Name = "Phone Number")]
        [MaxLength(50)]
        public string Phone { get; set; }

        [Display(Name = "Contact Method")]
        [MaxLength(50)]
        public string ContactMethod { get; set; }

        [Display(Name = "Order Received Via")]
        [MaxLength(50)]
        public string OderReceivedVia { get; set; }

        [Display(Name = "Referred By")]
        [MaxLength(50)]
        public string ReferredBy { get; set; }

        //[Display(Name = "Primary Rental Address")]
        //public int PrimaryAddressId { get; set; }

        //[ForeignKey("PrimaryAddressId")]
        //public virtual Address PrimaryRentalAddress { get; set; }

        public DateTimeOffset Created { get; set; }

        public ICollection<CustomerOrder> CustomerOrders { get; set; }

        //public ICollection<Address> Addresses { get; set; }
    }
}
