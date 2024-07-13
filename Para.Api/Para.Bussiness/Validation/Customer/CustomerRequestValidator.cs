using FluentValidation;
using Para.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Para.Bussiness.Validation.Customer
{
    public class CustomerRequestValidator : AbstractValidator<CustomerRequest>
    {

        public CustomerRequestValidator()
        {
  
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("FirstName is required!")    
                .NotNull().WithMessage("FirstName is required!")
                .MinimumLength(2).WithMessage("FirstName must be at least 2 characters!");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("LastName is required!")
                .NotNull().WithMessage("LastName is required!")
                .MinimumLength(2).WithMessage("LastName must be at least 2 characters!");

            RuleFor(x => x.IdentityNumber)
                .NotEmpty().WithMessage("IdentityNumber is required!")
                .NotNull().WithMessage("IdentityNumber is required!")
                .MinimumLength(11).WithMessage("IdentityNumber must be at least 11 characters!");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required!")
                .NotNull().WithMessage("Email is required!")
                .EmailAddress().WithMessage("Email is not valid!");

            RuleFor(x => x.DateOfBirth)
                .NotEmpty().WithMessage("DateOfBirth is required!")
                .NotNull().WithMessage("DateOfBirth is required!")
                .LessThan(DateTime.Now).WithMessage("DateOfBirth must be less than current date!");
        }

    }
}
