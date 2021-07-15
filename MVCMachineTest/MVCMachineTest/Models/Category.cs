using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCMachineTest.Models
{
    public class Category
    {
        [Key,Display(Name ="ID")]
        public string CategoryID { get; set; }
        [Required(ErrorMessage = "Enter category name"), Display(Name = "Name"), MaxLength(30), MinLength(4)]
        public string CategoryName { get; set; }
        [Display(Name = "Created On"), DataType(DataType.DateTime)]
        public DateTime CreationTime { get; set; }
    }
}
