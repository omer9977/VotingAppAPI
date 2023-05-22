using FluentValidation;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Application.Dto.Request.User;

namespace VotingAPI.Application.Validators
{
    public class CreateUserValidator : AbstractValidator<CreateUserRequest>
    {
        private readonly IConfiguration _configuration;
        public CreateUserValidator(IConfiguration configuration)
        {
            _configuration = configuration;

            RuleFor(s => s.UserName).Must(s => s.EndsWith(_configuration["SchoolDomain:General"])).WithMessage("Please enter your school domain!!!");
            RuleFor(s => s.Name).MaximumLength(100);
            RuleFor(s => s.LastName).MinimumLength(3);
        }
    }
}
