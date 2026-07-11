using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IF.CoreBusiness
{
    public class Part
    {
        public int PartID;
        public string PartNumber;
        public string PickedDW;
        public List<Instruction> InstructionsForPart = new();
    }
}
