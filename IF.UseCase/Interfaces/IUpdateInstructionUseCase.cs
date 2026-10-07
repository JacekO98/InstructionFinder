using IF.CoreBusiness;

namespace IF.UseCase.Interfaces
{
    public interface IUpdateInstructionUseCase
    {
        void Execute(string editedInstructionParts, string editedInstructionMachineDW, string pdfRelativePath);
    }
}