using FluentValidation;
using OpenDEVCore.Configuration.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenDEVCore.Configuration.Validators
{
    public class CatalogueValidator : AbstractValidator<CatalogueDto>
    {
        public CatalogueValidator()
        {
            RuleFor(x => x.Code)
           .NotNull().NotEmpty()
           .WithMessage("Code is required");

            RuleFor(x => x.Module)
           .NotNull().NotEmpty()
           .WithMessage("Module is required");

            RuleFor(x => x.Description)
            .NotNull().NotEmpty()
            .WithMessage("Description is required");

        }
    }
}
