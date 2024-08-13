using System.ComponentModel.DataAnnotations;

namespace CampusEventMS.ViewModels
{
    public class LoginWith2faViewModel
    {
        [Required(ErrorMessage = "Two-factor code is required.")]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "The two-factor code must be 6 digits.")]
        public string TwoFactorCode { get; set; }

        [Display(Name = "Remember this machine?")]
        public bool RememberMachine { get; set; }

        public bool RememberMe { get; set; }
    }
}
