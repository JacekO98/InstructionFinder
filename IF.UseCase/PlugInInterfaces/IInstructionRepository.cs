using IF.CoreBusiness;

namespace IF.UseCase.PlugInInterfaces
{
    public interface IInstructionRepository
    {
        Task FindInstructionAsync(Instruction instruction);
    }
}