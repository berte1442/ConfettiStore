using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConfettiStore.Models
{
    [Table("ConfettiCategories")]
    public class ConfettiCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ConfettiCategoryId { get; set; }

        public int ConfettiId { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        [ForeignKey("ConfettiId")]
        public Confetti Confetti { get; set; }

    }
}
