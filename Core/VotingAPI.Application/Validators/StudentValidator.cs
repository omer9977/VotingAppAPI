using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Application.Dto.Request.Student;

namespace VotingAPI.Application.Validators
{//todo 5 burada şöyle birşey yapabilirim command modelleri bir base entity de birleştirsem ve bu base model üzerinden rule yapsam daha mantıklı olmaz mı?
    //not şöyle bir durum var: command modeller birbirinden farklı olan property'e sahip olma ihtimali var
    public class AddStudentValidator : AbstractValidator<AddStudentRequest>
    {
        public AddStudentValidator()
        {
        }
    }
    public class UpdateStudentValidator : AbstractValidator<UpdateStudentRequest>
    {
        public UpdateStudentValidator()
        {
            //RuleFor(s => s.StudentNumber).NotNull().NotEmpty().Must(s => s > 0).WithMessage("Please enter a valid student number!");
            //RuleFor(s => s.Name).NotNull().NotEmpty().WithMessage("Please enter a valid student name!");
        }
    }
}
