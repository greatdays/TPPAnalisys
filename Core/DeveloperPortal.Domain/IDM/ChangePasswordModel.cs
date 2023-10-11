using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DeveloperPortal.Models.IDM
{
    public class ChangePasswordModel
    {
        [Display(Name = "Current Password")]
        [Required(ErrorMessage = "Current Password is Required.")]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }


        [Display(Name = "New Password")]
        [Required(ErrorMessage = "New Password is Required.")]
        [DataType(DataType.Password)]
        [StringLength(20, ErrorMessage = "Maximum 20 characters are allowed.")]
        [RegularExpression(@"^.{6,}$", ErrorMessage = "Password not long enough.")]
        public string NewPassword { get; set; }


        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "Confirm Password is Required.")]
        [DataType(DataType.Password)]
        [StringLength(20, ErrorMessage = "Maximum 20 characters are allowed.")]
        [RegularExpression(@"^.{6,}$", ErrorMessage = "Password not long enough.")]
        [System.ComponentModel.DataAnnotations.CompareAttribute("NewPassword", ErrorMessage = "Password does not match.")]
        public string ConfirmNewPassword { get; set; }

        public string UserName { get; set; }

        public string OriginalCurrentPassword { get; set; }

        public string OriginalNewPassword { get; set; }

        public string OriginalConfirmNewPassword { get; set; }
    }
}
