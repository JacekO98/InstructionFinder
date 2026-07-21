using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IF.CoreBusiness
{
    public class Part
    {
        public int PartID { get; set; }
        public string PartNumber { get; set; }
        public string PickedDW { get; set; }
        public string SelectedPdfPath { get; set; }
        public List<Instruction> InstructionsForPart = new();
    }
}
