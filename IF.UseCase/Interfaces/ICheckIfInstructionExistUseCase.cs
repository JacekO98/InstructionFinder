using IF.CoreBusiness;

namespace IF.UseCase.Interfaces
{
    public interface ICheckIfInstructionExistUseCase
    {
        List<string> Execute(Part currentPart);
    }
}