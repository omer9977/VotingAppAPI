using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Application.Dto.Request.Announcement;

namespace VotingAPI.Application.Validators
{
    public class AddAnnouncementValidator : AbstractValidator<AddAnnouncementRequest>
    {
        public AddAnnouncementValidator()
        {
            RuleFor(d => d.Name).NotEmpty().WithMessage("Name can not be empty");
            RuleFor(d => d.Description).NotEmpty().WithMessage("Description can not be empty");
        }
    }
}
