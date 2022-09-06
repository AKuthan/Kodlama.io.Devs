using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgramingLanguages.Commands.DeleteProgramingLangugae
{
    public class DeleteProgramingLanguageCommandValidator: AbstractValidator<DeleteProgramingLanguageCommand>
    {
        public DeleteProgramingLanguageCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
        }
    }
}
