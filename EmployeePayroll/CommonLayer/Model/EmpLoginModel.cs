using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.Model
{
    public class EmpLoginModel
    {
        [Required(ErrorMessage = "{0} is required")]
        [Range(1,double.PositiveInfinity,ErrorMessage ="{0} must be greater than {1}")]
        public int EmployeeId { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        [ RegularExpression(@"^[A-Z]{1}[a-z]{4,}", ErrorMessage = "Please enter valid Name")]
        public string Employee_Name { get; set; }

    }
}
