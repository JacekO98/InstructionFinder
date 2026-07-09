using IF.CoreBusiness;

namespace IF.UseCase.Interfaces
{
    public interface ICollectInstructionsUseCase
    {
        Part Execute(Part currentPart);
    }
}