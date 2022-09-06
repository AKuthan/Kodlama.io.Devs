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

namespace Application.Features.ProgramingLanguages.Commands.DeleteProgramingLangugae
{
    public class DeleteProgramingLanguageCommand : IRequest<DeletedProgramingLanguageDto>
    {
        public string Name { get; set; }

        public class DeleteProgramingLanguageCommandHandler : IRequestHandler<DeleteProgramingLanguageCommand, DeletedProgramingLanguageDto>
        {
            private readonly IProgramingLanguageRepository _programingLanguageRepository;
            private readonly IMapper _mapper;

            public DeleteProgramingLanguageCommandHandler(IProgramingLanguageRepository programingLanguageRepository, IMapper mapper)
            {
                _programingLanguageRepository = programingLanguageRepository;
                _mapper = mapper;
            }

            public async Task<DeletedProgramingLanguageDto> Handle(DeleteProgramingLanguageCommand request, CancellationToken cancellationToken)
            {

                ProgramingLanguage? programingLanguage = await _programingLanguageRepository.GetAsync(b => b.Name == request.Name);
                ProgramingLanguage DeletedProgramingLanguage = await _programingLanguageRepository.DeleteAsync(programingLanguage);
                DeletedProgramingLanguageDto DeletedProgramingLanguageDto = _mapper.Map<DeletedProgramingLanguageDto>(DeletedProgramingLanguage);

                return DeletedProgramingLanguageDto;
            }
        }
    }
}
