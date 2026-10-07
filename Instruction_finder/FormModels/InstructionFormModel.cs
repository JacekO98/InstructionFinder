using System.ComponentModel.DataAnnotations;


namespace Instruction_finder.FormModels
{
    public class InstructionFormModel
    {
        [Required(ErrorMessage = "Podaj nazwę instrukcji.")]
        public string InstructionName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Podaj numer instrukcji.")]
        public string PdfRelativePath { get; set; } = string.Empty;
        [Required(ErrorMessage = "Podaj maszyny z instrukcji.")]
        public string InstructionMachines { get; set; } = string.Empty;
        [Required(ErrorMessage = "Podaj kody detali z instrukcji.")]
        public string InstructionParts { get; set; } = string.Empty;


    }
}
