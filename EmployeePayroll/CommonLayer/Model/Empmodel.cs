using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.Model
{
    public class Empmodel
    {
      
        public int Emp_Id {  get; set; }

        [Required(ErrorMessage ="{0} Should be given")]
        [RegularExpression(@"^[A-Z]{1}[a-z]{4,}", ErrorMessage = "Please enter valid Name")]
        public string Employee_Name { get; set; }

        [Required(ErrorMessage = "{0} Should be given")]
        public string Profile_Image { get; set; }

        [Required(ErrorMessage = "{0} Should be given")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "{0} Should be given")]
        [RegularExpression(@"^[A-Z]{1}[a-z]{4,}", ErrorMessage = "Please enter valid Department")]
        public string Department {  get; set; }

        [Required(ErrorMessage = "{0} Should be given")]
        [RegularExpression(@"^[0-9]", ErrorMessage = "Please enter valid information ")]
        public long Salary {  get; set; }

        [Required(ErrorMessage = "{0} Should be given")]
        public DateTime StartDate {  get; set; }

        [Required(ErrorMessage = "{0} Should be given")]
        public string Notes {  get; set; }
    }
}
