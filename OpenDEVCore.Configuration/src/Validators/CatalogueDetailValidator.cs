using FluentValidation;
using OpenDEVCore.Configuration.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenDEVCore.Configuration.Validators
{
    public class CatalogueDetailValidator : AbstractValidator<CatalogueDetailDto>
    {
        public CatalogueDetailValidator()
        {
            RuleFor(x => x.Code)
           .NotNull().NotEmpty()
           .WithMessage("Code is required");

            RuleFor(x => x.IdCatalogue)
           .NotNull().NotEmpty()
           .WithMessage("IdCatalogue is required");

            RuleFor(x => x.Description)
            .NotNull().NotEmpty()
            .WithMessage("Description is required");

        }
    }
}
