using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IF.CoreBusiness
{
    public class Machine
    {
        public int MachineID { get; set; }
        public string MachineDW { get; set; } = string.Empty;

        public ICollection<Instruction> Instructions { get; set; } = new List<Instruction>();
    }


}
