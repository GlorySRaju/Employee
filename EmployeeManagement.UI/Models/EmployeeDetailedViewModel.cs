using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.UI.Models
{
    public class EmployeeDetailedViewModel
    {
       
        public int Id { get; set; }

        [Required(ErrorMessage ="Name Must Required")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Department Must Required")]
        public string Department { get; set; }

        [Required(ErrorMessage ="Age Must Required")]
        public int Age { get; set; }

        [Required(ErrorMessage ="Address Must Required")]
        public string Address { get; set; }
    }
}
