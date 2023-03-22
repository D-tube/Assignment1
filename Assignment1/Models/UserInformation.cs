using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Assignment1.Models
{
    public class UserInformation
    {
        [Required(ErrorMessage = "first name can not be empty")]
        public string FName { get; set; }

        [Required(ErrorMessage = "last name can not be empty")]
        public string LName { get; set; }

        [Required(ErrorMessage = "Please Enter your Email")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Please Enter a valid Email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter your Phone Number")]
        [DisplayFormat(DataFormatString = "{0:###-###-####}" , ApplyFormatInEditMode = true)]
        public long Phone { get; set; }


        [Required(ErrorMessage = "Password can not be empty")]
        public string Pass { get; set; }
        [Required(ErrorMessage = "Please confirm password")]
        public string CPass { get; set; }

        public bool status { get; set; }
    }
}
