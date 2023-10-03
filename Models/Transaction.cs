using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBudget.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [Range(1,1000000)]
        public double Amount { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [ValidateNever]
        public Category Category { get; set; }
        public string? Description { get; set; }
        [MaxLength(50)]
        public string? ShortDescription { get; set; }
        public DateTime? DateTime { get; set; }
    }
}
