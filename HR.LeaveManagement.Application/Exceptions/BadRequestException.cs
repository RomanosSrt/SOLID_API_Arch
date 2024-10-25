using System.ComponentModel.DataAnnotations;
using FluentValidation.Results;
namespace HR.LeaveManagement.Application.Exceptions;

public class BadRequestException : Exception
{
    public BadRequestException(string message) : base(message)
    {

    }

    public BadRequestException(string message, FluentValidation.Results.ValidationResult validationResult) : base(message)
    {
        validationErrors = validationResult.ToDictionary();
    }

    public IDictionary<string, string[]> validationErrors { get; set; }
}