using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IF.CoreBusiness;
using IF.UseCase.Interfaces;
using IF.UseCase.PlugInInterfaces;

namespace IF.UseCase
{
    public class CollectInstructionsUseCase : ICollectInstructionsUseCase
    {
        internal IInstructionRepository instructionRepository;

        public CollectInstructionsUseCase(IInstructionRepository instructionRepository)
        {
            this.instructionRepository = instructionRepository;
        }

        public Part Execute(Part currentPart)
        {
            return this.instructionRepository.CollectInstructionsUseCase(currentPart);
        }
    }
}
