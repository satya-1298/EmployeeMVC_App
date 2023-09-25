using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.Model
{
    public class ReviewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="{0} is required")]
        public string Name { get; set; }
        [Required(ErrorMessage ="{0} is Required")]
        public string Comment { get; set; }
    }
}
