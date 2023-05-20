using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Application.Dto.Request.Department;

namespace VotingAPI.Application.Validators
{
    public class AddDepartmentValidator : AbstractValidator<AddDepartmentRequest>
    {
        public AddDepartmentValidator()
        {
            RuleFor(d => d.Name).NotEmpty().WithMessage("Name should not empty value")
                .NotNull().WithMessage("Please enter a department name")
                .MaximumLength(100).MinimumLength(5).WithMessage("Please enter a valid department name");
        }
    }
    public class UpdateDepartmentValidator : AbstractValidator<UpdateDepartmentRequest>
    {
        public UpdateDepartmentValidator()
        {
            RuleFor(d => d.Name).NotEmpty().WithMessage("Name should not empty value")
                .NotNull().WithMessage("Please enter a department name")
                .MaximumLength(100).MinimumLength(5).WithMessage("Please enter a valid department name");
        }
    }
}
