using IF.CoreBusiness;

namespace IF.UseCase.Interfaces
{
    public interface IAddInstructionUseCase
    {
        void Execute(string newInstructionName, string newInstructionParts, string newInstructionMachineDW, string newInstructionPdfRelativePath);
    }
}