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
    public class GetInstructionUseCase : IGetInstructionUseCase
    {
        private IInstructionRepository instructionRepository;

        public GetInstructionUseCase(IInstructionRepository instructionRepository)
        {
            this.instructionRepository = instructionRepository;
        }
        public Instruction? Execute(string PdfRelativePath)
        {
            return instructionRepository.GetInstruction(PdfRelativePath);
        }

    }
}
