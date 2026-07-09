using IF.CoreBusiness;
using IF.UseCase.PlugInInterfaces;

namespace IF.Plugins.InMemory
{
    public class InstructionRepository : IInstructionRepository
    {
        List<Instruction> _Instructions = new List<Instruction>()
        {
            new Instruction { InstructionID = 1, InstructionNumber = "OMR-D-90-DW0485-IK-5533", InstructionName = "Frezowanie wielowypustu", MachineDW = new List<string> {"DW1204"}, PartsInInstruction = new List<string> {"151F1861", "4310460"}, PdfPath = "ABCD"},
            new Instruction { InstructionID = 2, InstructionNumber = "OMR-D-90-DW0485-IK-5534", InstructionName = "Frezowanie wałka", MachineDW = new List<string> {"DW1204"}, PartsInInstruction = new List<string> {"151F1861", "4310460", "4313909"}, PdfPath = "ABCE"},
            new Instruction { InstructionID = 3, InstructionNumber = "OMR-D-90-DW0485-IK-5535", InstructionName = "Frezowanie korpusu", MachineDW = new List<string> {"DW1205"}, PartsInInstruction = new List<string> {"151F1861", "4310460", "4313909"}, PdfPath = "ABCF"},
            new Instruction { InstructionID = 4, InstructionNumber = "OMR-D-90-DW0485-IK-5536", InstructionName = "Frezowanie płyty", MachineDW = new List<string> {"DW1204", "DW1205"}, PartsInInstruction = new List<string> {"151F1861", "4310460", "4313909"}, PdfPath = "ABCG"},
            new Instruction { InstructionID = 5, InstructionNumber = "OMR-D-90-DW0485-IK-5537", InstructionName = "Frezowanie wieńca", MachineDW = new List<string> {"DW1204", "DW1205"}, PartsInInstruction = new List<string> { "4310460", "4313909"}, PdfPath = "ABCH"},
        };

        List<Part> _parts = new List<Part>()
        {
            new Part { PartID = 1, PartNumber = "151F1861" },
            new Part { PartID = 2, PartNumber = "4310460" },
            new Part { PartID = 3, PartNumber = "4313909"}
        };


        public  Part GetMachinesDWForCode(Part currentPart)
        {
            if (_Instructions.Any(x => x.PartsInInstruction.Any(x => x == currentPart.PartNumber)))
            {
                currentPart.InstructionsForPart = _Instructions.Where(x => x.PartsInInstruction.Contains(currentPart.PartNumber) && x.MachineDW.Contains(pickedDW)).ToList();
                return currentPart;
            }
            else
            {
                Console.WriteLine($"Nie znaleziono instrukcji dla kodu {currentPart.PartNumber}");
            }

        }
        public Task FindInstructionAsync(Instruction instruction)
        {
            Part currentPart = new Part();
            currentPart.InstructionsForPart = new List<Instruction>();
            Console.WriteLine("Podaj numer obrabianego kodu:");
            string currentPartNumber = Console.ReadLine();
            currentPart.PartNumber = currentPartNumber.Trim();
            /// Trzeba dodać sprawdzenie czy kod w ogóle istnieje

            ///Tutaj trzeba będzie dopisać wylistowanie DWmaszyn. zastanowić się czy zrobić to z palca czy poprzez przeiterowanie po dostępnych instrukcjach i wylistowanie DW jakie w nich występują}. Na razie robie to z palca
            Console.WriteLine("Wybierz DW maszyny której mają dotyczyć instrukcje: DW1204, DW1205");
            string pickedDW = Console.ReadLine();

            if (_Instructions.Any(x => x.PartsInInstruction.Any(x => x == currentPart.PartNumber)))
            {
                currentPart.InstructionsForPart = _Instructions.Where(x => x.PartsInInstruction.Contains(currentPart.PartNumber) && x.MachineDW.Contains(pickedDW)).ToList();
            }
            else
            {
                Console.WriteLine($"Nie znaleziono instrukcji dla kodu {currentPart.PartNumber}");
            }

            /* foreach (var instruction in currentPart.InstructionsForPart)
            {
                Console.WriteLine(instruction.InstructionName);
            } */
            return Task.CompletedTask;
        }
    }
}
