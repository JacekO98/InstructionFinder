using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IF.UseCase.PlugInInterfaces;
using IF.CoreBusiness;
using IF.UseCase.Interfaces;

namespace IF.UseCase
{
    public class CheckIfInstructionExistUseCase : ICheckIfInstructionExistUseCase
    {
        private IInstructionRepository instructionRepository;

        public CheckIfInstructionExistUseCase(IInstructionRepository instructionRepository)
        {
            this.instructionRepository = instructionRepository;
        }

        public List<string> Execute(Part currentPart)
        {
            return this.instructionRepository.CheckIfInstructionExist(currentPart);
        }

    }
}
