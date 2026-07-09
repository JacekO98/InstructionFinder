using IF.CoreBusiness;

namespace IF.UseCase.PlugInInterfaces
{
    public interface IInstructionRepository
    {
        List<string> CheckIfInstructionExist(Part currentPart);
        Part CollectInstructionsUseCase(Part currentPart);
        Task FindInstructionAsync(Instruction instruction);
    }
}