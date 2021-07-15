using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCMachineTest.Models.ViewModels
{
    public class AddProductViewModel
    {
        public Product Product { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public string Message { get; set; }
    }
}
