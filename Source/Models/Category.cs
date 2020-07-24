using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConfettiStore.Models
{
    [Table("Categories")]
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }

        [Display(Name = "Category")]
        [MaxLength(50)]
        public string CategoryName { get; set; }

        public ICollection<ConfettiCategory> ConfettiCategories { get; set; }
    }
}
