using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgramingLanguages.Commands.UpdateProgramingLanguage
{
    public class UpdateProgramingLanguageCommandValidator : AbstractValidator<UpdateProgramingLanguageCommand>
    {
        public UpdateProgramingLanguageCommandValidator()
        {
            RuleFor(c => c.Id).NotEmpty();
            RuleFor(c => c.Name).NotEmpty();
        }
    }
}
