using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Min18YearsForMembership  : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer) validationContext.ObjectInstance;

            if (customer.MemberShipTypeID == MemberShipType.Free)
                return ValidationResult.Success;
            if (customer.BirthDate == null)
            return new ValidationResult("BirthDate is required");

            var age = DateTime.Now.Year - customer.BirthDate.Value.Year;

            return (age > 18) ? ValidationResult.Success : new ValidationResult("customer should be 18");
        }  
    }
}