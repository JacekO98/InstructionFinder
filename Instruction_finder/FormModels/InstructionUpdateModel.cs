using System.ComponentModel.DataAnnotations;

namespace Instruction_finder.FormModels
{
    public class InstructionUpdateModel
    {
        
        public string InstructionName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Podaj numer instrukcji.")]
        public string PdfRelativePath { get; set; } = string.Empty;
        
        public string InstructionMachines { get; set; } = string.Empty;
        
        public string InstructionParts { get; set; } = string.Empty;


    }
}
