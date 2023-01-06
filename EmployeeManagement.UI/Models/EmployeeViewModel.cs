using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.UI.Models
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Name must Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Department Must Required")]
        public string Department { get; set; }

    }
}
