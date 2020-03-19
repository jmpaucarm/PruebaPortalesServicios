using FluentValidation;
using OpenDEVCore.Security.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenDEVCore.Security.Validators
{
    public class ProfileValidator : AbstractValidator<ProfileDto>
    {
        public ProfileValidator()
        {
            RuleFor(x => x.ProfileCode)
           .NotNull().NotEmpty()
           .WithMessage("ProfileCode is required");

            RuleFor(x => x.Name)
           .NotNull().NotEmpty()
           .WithMessage("Name is required");

            RuleFor(x => x.DateValidity)
            .NotNull().NotEmpty()
            .WithMessage("DateValidity is required");

        }
    }
}