﻿using FluentValidation.Results;
using System.Security.Cryptography.X509Certificates;

namespace HR.LeaveManagement.Application.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public List<string> Errors { get; set; } = new List<string>();

        public ValidationException(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors) 
            {  
                Errors.Add(error.ErrorMessage);
            }
        }
    }
}
