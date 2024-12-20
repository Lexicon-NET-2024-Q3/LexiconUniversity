﻿using System.ComponentModel.DataAnnotations;

namespace LexiconUniversity.Web.Validations
{
    public class CheckLastName : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            //var context = validationContext.GetRequiredService<LexiconUniversityContext>();

            const string errorMessage = "First name and last name can't be the same!";

            if(value is string input)
            {
                if(validationContext.ObjectInstance is StudentCreateViewModel model)
                {
                    return model.NameFirstName != input ?
                        ValidationResult.Success :
                        new ValidationResult(errorMessage);
                }
            }
            return new ValidationResult("Something went wrong!");             
            
        }
    }
}
