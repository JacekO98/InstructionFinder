namespace IF.CoreBusiness
{
    public class Instruction
    {
        public int InstructionID { get; set; }
        public string InstructionNumber { get; set; }
        public string InstructionName { get; set; }
        public List<string> MachineDW { get; set; }
        public List<string> PartsInInstruction { get; set; }
        public string PdfPath { get; set; }
    }
}
