using Application.Features.ProgramingLanguages.Dtos;
using Application.Features.ProgramingLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgramingLanguages.Commands
{
    public class DeleteProgramingLanguageCommand : IRequest<DeletedProgramingLanguageDto>
    {
        public string Name { get; set; }

        public class DeleteProgramingLanguageCommandHandler : IRequestHandler<DeleteProgramingLanguageCommand, DeletedProgramingLanguageDto>
        {
            private readonly IProgramingLanguageRepository _programingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgramingLanguageBusinessRules _programingLanguageBusinessRules;

            public DeleteProgramingLanguageCommandHandler(IProgramingLanguageRepository programingLanguageRepository, IMapper mapper, ProgramingLanguageBusinessRules programingLanguageBusinessRules)
            {
                _programingLanguageRepository = programingLanguageRepository;
                _mapper = mapper;
                _programingLanguageBusinessRules = programingLanguageBusinessRules;
            }

            public async Task<DeletedProgramingLanguageDto> Handle(DeleteProgramingLanguageCommand request, CancellationToken cancellationToken)
            {
                await _programingLanguageBusinessRules.ProgramingLanguageNameShouldExistWhenDeleted(request.Name);

                ProgramingLanguage? programingLanguage = await _programingLanguageRepository.GetAsync(b => b.Name == request.Name);
                ProgramingLanguage DeletedProgramingLanguage = await _programingLanguageRepository.DeleteAsync(programingLanguage);
                DeletedProgramingLanguageDto DeletedProgramingLanguageDto = _mapper.Map<DeletedProgramingLanguageDto>(DeletedProgramingLanguage);

                return DeletedProgramingLanguageDto;
            }
        }
    }
}
