using IF.CoreBusiness;
namespace IF.UseCase.Interfaces
{
    public interface IFindInstructionUseCase
    {
        Task ExecuteAsync(Instruction instruction);
    }
}