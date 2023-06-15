using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Application.Dto.Request.Department;
using VotingAPI.Application.Dto.Request.Election;

namespace VotingAPI.Application.Validators
{
    public class ElectionCreateValidator : AbstractValidator<CreateDepartmentElectionRequest>
    {
        public ElectionCreateValidator()
        {
            RuleFor(e => e.StartDate).GreaterThanOrEqualTo(DateTime.UtcNow)
                .WithMessage("Start date should be more than now.");
            RuleFor(e => e.EndDate).GreaterThan(e => e.StartDate)
                .WithMessage("End date should be more than start date.");
        }
    }

    public class ElectionUpdateValidator : AbstractValidator<UpdateDepartmentElectionRequest>
    {
        public ElectionUpdateValidator()
        {
            RuleFor(e => e.StartDate).GreaterThanOrEqualTo(DateTime.UtcNow)
                .WithMessage("Start date should be more than now.");
            RuleFor(e => e.EndDate).GreaterThan(e => e.StartDate)
                .WithMessage("End date should be more than start date.");
        }
    }
}
