using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudMVC.Models
{
    public class Students
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Required")]
        public string FatherName { get; set; }

        [Required(ErrorMessage = "Required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name="Department")]
        public int DepartmentID { get; set; }

        [NotMapped]
        public string Department { get; set; }
    }
}
