using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IF.CoreBusiness
{
    public class Part
    {
        public int PartID { get; set; }
        public string PartNumber { get; set; } = string.Empty;

        public ICollection<Instruction> Instructions { get; set; } = new List<Instruction>();

        [NotMapped]
        public string? PickedDW { get; set; }

        [NotMapped]
        public string? SelectedPdfPath { get; set; }

        [NotMapped]
        public List<Instruction> InstructionsForPart { get; set; } = new();
    }

}
