using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ReadingBookList.Models
{
    /// <summary>
    /// This class is used for External Login Confirmation
    /// Used for external login confirmation
    /// </summary>
    public class ExternalLoginConfirmationViewModel
    {
        /// <summary>
        /// The Email Property represents the email of the user
        /// </summary>
        /// <value>The Email property gets/sets the value of the string field</value>
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    /// <summary>
    /// This class is used for creating the ExternalLoginListViewModel object
    /// Used for external login
    /// </summary>
    public class ExternalLoginListViewModel
    {
        /// <summary>
        /// The ReturnUrl Property represents the login Url 
        /// </summary>
        /// <value>The ReturnUrl property gets/sets the value of the string field</value>
        public string ReturnUrl { get; set; }
    }

    /// <summary>
    /// This class is used for Sending code when user forgot passwword
    /// </summary>
    public class SendCodeViewModel
    {
        /// <summary>
        /// The SelectedProvider Property
        /// </summary>
        /// <value>The SelectedProvider property gets/sets the value of the string field</value>
        public string SelectedProvider { get; set; }

        /// <summary>
        /// The Providers Property 
        /// </summary>
        /// <value>The Providers property gets/sets the value of the ICollection<System.Web.Mvc.SelectListItem> field</value>
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }

        /// <summary>
        /// The ReturnUrl Property represents the SendCode Url 
        /// </summary>
        /// <value>The ReturnUrl property gets/sets the value of the string field</value>
        public string ReturnUrl { get; set; }

        /// <summary>
        /// The RememberMe Property 
        /// </summary>
        /// <value>The RememberMe property gets/sets the value of the boolean field</value>
        public bool RememberMe { get; set; }
    }

    /// <summary>
    /// This class is used for verifying the code when user use a forget password function
    /// </summary>
    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    /// <summary>
    /// This class the ViewModel for User's Forgot password
    /// </summary>
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
    
    /// <summary>
    /// This class is the ViewModel for  User Login
    /// </summary>
    public class LoginViewModel
    {
        /// <summary>
        /// The Email Property represents the email of the user
        /// </summary>
        /// <value>The Email property gets/sets the value of the string field</value>
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// The Password Property represents the password of the user
        /// </summary>
        /// <value>The Password property gets/sets the value of the password field</value>
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        /// <summary>
        /// The RememberMe Property is used when user wants to remember his/her login credentials
        /// </summary>
        /// <value>The RememberMe property gets/sets the value of the boolean field</value>
        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    /// <summary>
    /// This class is the ViewModel for User Registration
    /// </summary>
    public class RegisterViewModel
    {
        /// <summary>
        /// The Email Property represents the email of the user
        /// </summary>
        /// <value>The Email property gets/sets the value of the string field</value>
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }


        /// <summary>
        /// The Password Property represents the password of the user
        /// </summary>
        /// <value>The Password property gets/sets the value of the password field</value>
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        /// <summary>
        /// The ConfirmPassword Property used for user password confirmation
        /// </summary>
        /// <value>The ConfirmPassword property gets/sets the value of the password field</value>
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    /// <summary>
    /// This class is the View Model for User's Resetting Password
    /// </summary>
    public class ResetPasswordViewModel
    {

        /// <summary>
        /// The Email Property represents the email of the user
        /// </summary>
        /// <value>The Email property gets/sets the value of the string field</value>
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        /// <summary>
        /// The Password Property represents the password of the user
        /// </summary>
        /// <value>The Password property gets/sets the value of the password field</value>
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        /// <summary>
        /// The ConfirmPassword Property used for user password confirmation
        /// </summary>
        /// <value>The ConfirmPassword property gets/sets the value of the password field</value>
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        /// <summary>
        /// The Code Property
        /// </summary>
        /// <value>The Code property gets/sets the value of the string field</value>
        public string Code { get; set; }
    }

    /// <summary>
    /// This class is the View Model for User's forgot password
    /// </summary>
    public class ForgotPasswordViewModel
    {
        /// <summary>
        /// The Email Property represents the email of the user
        /// </summary>
        /// <value>The Email property gets/sets the value of the string field</value>
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
