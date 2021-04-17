﻿using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.Models
{
    public class ExpenseType
    {


        [Key]
        public int Id  { get; set; }
     
        [Required]
        public string Name { get; set; }


    }
}
