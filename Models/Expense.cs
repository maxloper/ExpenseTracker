using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseTracker.Models
{
    public class Expense
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public string ExpenseName { get; set; }

        [Required]
        [Range(1,int.MaxValue , ErrorMessage = " must be greater than 0! ")] 
        public int Amount { get; set; }

        [DisplayName("Expense Type")]

        [ForeignKey("ExpenseTypeId")]
        public int ExpenseTypeId { get; set; }
       

        public virtual ExpenseType ExpenseType { get; set; }

    }
}
