using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCMachineTest.Models
{
    public class Category
    {
        [Key]
        public string CategoryID { get; set; }
        [Required(ErrorMessage = "Enter category name"), Display(Name = "Category Name"), MaxLength(30), MinLength(4), StringLength(30)]
        public string CategoryName { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime CreationTime { get; set; }
    }
}
