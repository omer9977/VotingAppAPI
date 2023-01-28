using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Application.Dto.Request.Student;

namespace VotingAPI.Application.Validators.Students
{
    public class AddStudentValidator : AbstractValidator<AddStudentRequest>
    {
        public AddStudentValidator() 
        {
            RuleFor(s => s.StudentNumber).NotNull().NotEmpty().Must(s => s > 0);
        }
    }
}
