using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IF.CoreBusiness
{
    public class InstructionsPart
    {
        public int InstructionID { get; set; }
        public int PartID { get; set; }
        public Part Part { get; set; }
        public Instruction Instruction { get; set; }
    }
}
