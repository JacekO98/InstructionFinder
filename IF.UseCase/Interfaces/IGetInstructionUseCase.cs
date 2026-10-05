using IF.CoreBusiness;

namespace IF.UseCase.Interfaces
{
    public interface IGetInstructionUseCase
    {
        Instruction Execute(string PdfRelativePath);
    }
}