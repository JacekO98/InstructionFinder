

using System.ComponentModel.DataAnnotations.Schema;

namespace IF.CoreBusiness
{

    public class Instruction
    {
        public int InstructionID { get; set; }
        [NotMapped]
        public string InstructionNumber { get; set; } = string.Empty;
        public string InstructionName { get; set; } = string.Empty;
        public string PdfRelativePath { get; set; } = string.Empty;

        public ICollection<Part> Parts { get; set; } = new List<Part>();
        public ICollection<Machine> Machines { get; set; } = new List<Machine>();
    }


}
