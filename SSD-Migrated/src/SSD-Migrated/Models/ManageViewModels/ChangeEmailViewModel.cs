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
        [Display(Name = "New Email Address")]
        public string EmailAddress { get; set; }

        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Display(Name = "Confirm new Email Address ")]
        [Compare("New Email Address", ErrorMessage = "The new Email Address and confirmed Email Address do not match.")]
        public string ConfirmedEmailAddress { get; set; }
    }
}
