using Application.Features.ProgramingLanguages.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgramingLanguages.Commands.UpdateProgramingLanguage
{
    public class UpdateProgramingLanguageCommand : IRequest<UpdatedProgramingLanguageDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public class UpdateProgramingLanguageCommandHandler : IRequestHandler<UpdateProgramingLanguageCommand, UpdatedProgramingLanguageDto>
        {
            private readonly IProgramingLanguageRepository _programingLanguageRepository;
            private readonly IMapper _mapper;
            public UpdateProgramingLanguageCommandHandler(IProgramingLanguageRepository programingLanguageRepository, IMapper mapper)
            {
                _programingLanguageRepository = programingLanguageRepository;
                _mapper = mapper;

            }
            public async Task<UpdatedProgramingLanguageDto> Handle(UpdateProgramingLanguageCommand request, CancellationToken cancellationToken)
            {
                ProgramingLanguage mappedProgramingLanguage = _mapper.Map<ProgramingLanguage>(request);
                ProgramingLanguage updatedProgramingLanguage = await _programingLanguageRepository.UpdateAsync(mappedProgramingLanguage);
                UpdatedProgramingLanguageDto updatedProgramingLanguageDto = _mapper.Map<UpdatedProgramingLanguageDto>(updatedProgramingLanguage);
                return updatedProgramingLanguageDto;
            }
        }
    }
}
