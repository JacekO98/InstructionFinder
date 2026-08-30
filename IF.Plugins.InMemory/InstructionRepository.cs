
using IF.CoreBusiness;
using IF.UseCase.PlugInInterfaces;

namespace IF.Plugins.InMemory
{
    public class InstructionRepository : IInstructionRepository
    {
        private readonly List<Instruction> instructions = new()
        {
            new Instruction
            {
                InstructionID = 1,
                InstructionNumber = "OMR-D-90-DW0485-IK-5533",
                InstructionName = "Frezowanie wielowypustu",
                PdfRelativePath = "PDF/matematyka-2024-egzamin-osmoklasisty.pdf",
                Parts = new List<Part> { new() { PartNumber = "151F1861" }, new() { PartNumber = "4310460" } },
                Machines = new List<Machine> { new() { MachineDW = "DW1204" } }
            },
            new Instruction
            {
                InstructionID = 2,
                InstructionNumber = "OMR-D-90-DW0485-IK-5534",
                InstructionName = "Frezowanie wałka",
                PdfRelativePath = "PDF/matematyka-2024-egzamin-osmoklasisty.pdf",
                Parts = new List<Part> { new() { PartNumber = "151F1861" }, new() { PartNumber = "4310460" }, new() { PartNumber = "4313909" } },
                Machines = new List<Machine> { new() { MachineDW = "DW1204" } }
            },
            new Instruction
            {
                InstructionID = 3,
                InstructionNumber = "OMR-D-90-DW0485-IK-5535",
                InstructionName = "Frezowanie korpusu",
                PdfRelativePath = "PDF/matematyka-2024-egzamin-osmoklasisty.pdf",
                Parts = new List<Part> { new() { PartNumber = "151F1861" }, new() { PartNumber = "4310460" }, new() { PartNumber = "4313909" } },
                Machines = new List<Machine> { new() { MachineDW = "DW1205" } }
            },
            new Instruction
            {
                InstructionID = 4,
                InstructionNumber = "OMR-D-90-DW0485-IK-5536",
                InstructionName = "Frezowanie płyty",
                PdfRelativePath = "PDF/matematyka-2024-egzamin-osmoklasisty.pdf",
                Parts = new List<Part> { new() { PartNumber = "151F1861" }, new() { PartNumber = "4310460" }, new() { PartNumber = "4313909" } },
                Machines = new List<Machine> { new() { MachineDW = "DW1204" }, new() { MachineDW = "DW1205" } }
            },
            new Instruction
            {
                InstructionID = 5,
                InstructionNumber = "OMR-D-90-DW0485-IK-5537",
                InstructionName = "Frezowanie wieńca",
                PdfRelativePath = "PDF/matematyka-2024-egzamin-osmoklasisty.pdf",
                Parts = new List<Part> { new() { PartNumber = "4310460" } },
                Machines = new List<Machine> { new() { MachineDW = "DW1204" }, new() { MachineDW = "DW1206" } }
            }
        };

        public List<string> CheckIfInstructionExist(Part currentPart)
        {
            return instructions
                .Where(instruction => instruction.Parts.Any(part => part.PartNumber == currentPart.PartNumber))
                .SelectMany(instruction => instruction.Machines)
                .Select(machine => machine.MachineDW)
                .Distinct()
                .ToList();
        }

        public Part CollectInstructionsUseCase(Part currentPart)
        {
            currentPart.InstructionsForPart = instructions
                .Where(instruction => instruction.Parts.Any(part => part.PartNumber == currentPart.PartNumber))
                .Where(instruction => instruction.Machines.Any(machine => machine.MachineDW == currentPart.PickedDW))
                .ToList();
            return currentPart;
        }

        
    }
}

