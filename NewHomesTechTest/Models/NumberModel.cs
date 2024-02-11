using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NewHomesTechTest.Models
{
    public class NumberModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("First number")]
        public decimal NumberOne { get; set; }
        [Required]
        [DisplayName("Second number")]
        public decimal NumberTwo { get; set; }
        [Required]
        public decimal Sum { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
    }
}