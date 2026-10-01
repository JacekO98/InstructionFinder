using IF.CoreBusiness;

namespace IF.UseCase.PlugInInterfaces
{
    public interface IInstructionRepository
    {
        void AddInstruction(string newInstructionName, string newInstructionParts, string newInstructionMachineDW, string newInstructionPdfRelativePath);
        List<string> CheckIfInstructionExist(Part currentPart);
        Part CollectInstructionsUseCase(Part currentPart);
        Instruction GetInstruction(string pdfRelativePath);
        void UpdateInstruction(Instruction instruction);
    }
}