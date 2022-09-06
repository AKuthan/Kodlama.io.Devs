using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgramingLanguages.Rules
{
    public class ProgramingLanguageBusinessRules
    {
        private readonly IProgramingLanguageRepository _programingLanguageRepository;

        public ProgramingLanguageBusinessRules(IProgramingLanguageRepository programingLanguageRepository)
        {
            _programingLanguageRepository = programingLanguageRepository;
        }

        public async Task ProgramingLanguageNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<ProgramingLanguage> result = await _programingLanguageRepository.GetListAsync(b => b.Name == name);
            if (result.Items.Any()) throw new BusinessException("Programing language name exists.");
        }
        public void ProgramingLanguageShouldExistWhenRequested(ProgramingLanguage programingLanguage)
        {
            if (programingLanguage == null) throw new BusinessException("Requested programing language does not exist");
        }
        public async Task ProgramingLanguageNameShouldExistWhenDeleted(string name)
        {
            IPaginate<ProgramingLanguage> result = await _programingLanguageRepository.GetListAsync(b => b.Name == name);
            if (!result.Items.Any()) throw new BusinessException("Programing language name does not exists.");
        }
    }
}
