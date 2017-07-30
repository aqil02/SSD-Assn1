using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SSD_Migrated.Models.ManageViewModels
{
    public class ChangeEmailViewModel
    {
        [Required(ErrorMessage =" The email address is required")]
        [EmailAddress(ErrorMessage ="Invalid Email Address")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Old Email Address")]
        //[Compare("Old Email Address", ErrorMessage = "The old email do not match.")]
        public string OldEmailAddress { get; set; }

        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Display(Name = "Confirm new Email Address ")]
        
        public string ConfirmedEmailAddress { get; set; }
        
    }
}
