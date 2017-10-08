using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ReadingBookList.Common
{
    /// <summary>
    /// Custom data annotation validation attribute for ISBN
    /// </summary>
    public class ValidateISBN : ValidationAttribute
    {
        protected override ValidationResult
        IsValid(object value, ValidationContext validationContext)
        {
            if(value is null)
            {
                return new ValidationResult("ISBN is required.");
            }

            if (ISBN.ValidateISBN(value.ToString()))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Invalid ISBN Format.");
            }
        }
    }
}