using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IF.CoreBusiness;
using IF.UseCase.Interfaces;
using IF.UseCase.PlugInInterfaces;

namespace IF.UseCase.PTUseCase
{
    public class UpdateInstructionUseCase : IUpdateInstructionUseCase
    {
        private IInstructionRepository instructionRepository;
        public UpdateInstructionUseCase(IInstructionRepository instructionRepository)
        {
            this.instructionRepository = instructionRepository;
        }
        public void Execute(string editedInstructionParts, string editedInstructionMachineDW, string pdfRelativePath)
        {
            instructionRepository.UpdateInstruction(editedInstructionParts, editedInstructionMachineDW, pdfRelativePath);
        }
    }
}
