using IF.CoreBusiness;
using IF.UseCase.Interfaces;

using IF.UseCase.PlugInInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IF.UseCase
{
    public class FindInstructionUseCase : IFindInstructionUseCase
    {
        private readonly IInstructionRepository instructionRepository;

        public FindInstructionUseCase(IInstructionRepository instructionRepository)
        {
            this.instructionRepository = instructionRepository;
        }

        public async Task ExecuteAsync(Instruction instruction)
        {
            await this.instructionRepository.FindInstructionAsync(instruction);
        }


    }
}
