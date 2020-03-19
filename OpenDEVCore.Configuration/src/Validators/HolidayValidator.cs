using FluentValidation;
using OpenDEVCore.Configuration.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenDEVCore.Configuration.Validators
{
    public class HolidayValidator : AbstractValidator<HolidayDto>
    {
        public HolidayValidator()
        {
            RuleFor(x => x.DateHoliday)
           .NotNull().NotEmpty()
           .WithMessage("DateHoliday is required");

            RuleFor(x => x.Year)
           .NotNull().NotEmpty()
           .WithMessage("Year is required");

            RuleFor(x => x.Description)
            .NotNull().NotEmpty()
            .WithMessage("Description is required");

        }
    }
}
