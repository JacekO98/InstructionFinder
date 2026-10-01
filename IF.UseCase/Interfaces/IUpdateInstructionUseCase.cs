using IF.CoreBusiness;

namespace IF.UseCase.Interfaces
{
    public interface IUpdateInstructionUseCase
    {
        void Execute(Instruction instruction);
    }
}