using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Application.Dto.Request.Candidate;

namespace VotingAPI.Application.Validators
{
    public class AddCandidateValidator : AbstractValidator<AddCandidateRequest>
    {
        public AddCandidateValidator()
        {
            RuleFor(d => d.Description).NotEmpty().WithMessage("Description can not be empty");
        }
    }
}
