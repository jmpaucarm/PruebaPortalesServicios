using FluentValidation;
using OpenDEVCore.Configuration.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenDEVCore.Configuration.Validators
{
    public class InstitutionValidator : AbstractValidator<InstitutionDto>
    {
        public InstitutionValidator()
        {
            RuleFor(x => x.CompanyCode)
           .NotNull().NotEmpty()
           .WithMessage("CompanyCode is required");

            RuleFor(x => x.Name)
           .NotNull().NotEmpty()
           .WithMessage("Name is required");

            RuleFor(x => x.RepresentativeDni)
            .NotNull().NotEmpty()
            .WithMessage("RepresentativeDni is required");

        }
    }
}