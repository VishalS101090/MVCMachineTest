using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVCMachineTest.Models
{
    public class Product
    {
        [Key]
        public string ProductID { get; set; }
        [Required(ErrorMessage = "Enter product name"), Display(Name = "Product Name"), MaxLength(30), MinLength(4), StringLength(30)]
        public string ProductName { get; set; }

        [ForeignKey("Category")]
        public string CategoryID { get; set; }

        public Category Category { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreationTime { get; set; }
    }
}
