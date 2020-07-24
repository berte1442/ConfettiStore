    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConfettiStore.Models
{
    [Table("CustomerOrders")]
    public class CustomerOrder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }

        public int CustomerId { get; set; }

        [Display(Name = "Set Up Date")]
        public DateTimeOffset? SetupDate { get; set; }

        [Display(Name = "Pick Up Date")]
        public DateTimeOffset? PickUpDate { get; set; }

        [MaxLength(500)]
        public string Note { get; set; }

        [Display(Name = "Rent Price")]
        public double RentPrice { get; set; }

        [Display(Name = "Event Type")]
        public int? EventTypeId { get; set; }

        public bool Personalized { get; set; }

        [Display(Name = "Personalized Text")]
        [MaxLength(50)]
        public string PersonalizedText { get; set; }

        public DateTimeOffset Created { get; set; }

        public DateTimeOffset Modified { get; set; }

        [Display(Name = "Rental Address")]
        public int? AddressId { get; set; }

        [ForeignKey("StatusId")]
        public int StatusId { get; set; }

        [Display(Name = "Order Status")]
        public virtual Status Status { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }

        [ForeignKey("EventTypeId")]
        public virtual EventType EventType { get; set; }

        [ForeignKey("AddressId")]
        public virtual Address RentalAddress { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }

        public ICollection<OrderAttachment> OrderAttachments { get; set; }

    }
}
