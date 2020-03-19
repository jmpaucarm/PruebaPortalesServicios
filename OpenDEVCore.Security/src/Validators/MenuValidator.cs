using FluentValidation;
using OpenDEVCore.Security.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenDEVCore.Security.Validators
{
    public class MenuValidator : AbstractValidator<MenuDto>
    {
        public MenuValidator()
        {
            RuleFor(x => x.Module)
           .NotNull().NotEmpty()
           .WithMessage("Module is required");

            RuleFor(x => x.Name)
           .NotNull().NotEmpty()
           .WithMessage("Name is required");

            RuleFor(x => x.Description)
            .NotNull().NotEmpty()
            .WithMessage("Description is required");

        }
    }
}