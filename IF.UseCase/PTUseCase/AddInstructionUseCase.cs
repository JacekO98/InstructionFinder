using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IF.UseCase.PlugInInterfaces;
using IF.CoreBusiness;
using IF.UseCase.Interfaces;

namespace IF.UseCase.PTUseCase
{
    public class AddInstructionUseCase : IAddInstructionUseCase
    {
        private IInstructionRepository instructionRepository;
        public AddInstructionUseCase(IInstructionRepository instructionRepository)
        {
            this.instructionRepository = instructionRepository;
        }
        public void Execute(string newInstructionName, string newInstructionParts, string newInstructionMachineDW, string newInstructionPdfRelativePath)
        {
            instructionRepository.AddInstruction(newInstructionName, newInstructionParts, newInstructionMachineDW, newInstructionPdfRelativePath);
        }
    }
}
