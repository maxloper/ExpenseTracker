using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.Models
{
    public class Item : IEnumerable
    {

        [Key]
        public int Id { get; set; }

        public string Borrower { get; set; }

        public string Lender{ get; set; }

        [DisplayName ("Item Name")]
        public string ItemName{ get; set; }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
