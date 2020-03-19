using FluentValidation;
using OpenDEVCore.Security.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenDEVCore.Security.Validators
{
    public class UserValidator : AbstractValidator<UserDto>
    {
        public UserValidator()
        {
            RuleFor(x => x.UserCode)
           .NotNull().NotEmpty()
           .WithMessage("UserCode is required");

            RuleFor(x => x.IdentificationType)
           .NotNull().NotEmpty()
           .WithMessage("IdentificationType is required");

            RuleFor(x => x.Dni)
            .NotNull().NotEmpty()
            .WithMessage("Dni is required");

        }
    }
}