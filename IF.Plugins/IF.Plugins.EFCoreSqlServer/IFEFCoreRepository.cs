using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using IF.CoreBusiness;
using IF.UseCase.PlugInInterfaces;

namespace IF.Plugins.EFCoreSqlServer;

public class EfInstructionRepository : IInstructionRepository
{
    private readonly IFContext _context;

    public EfInstructionRepository(IFContext context)
    {
        _context = context;
    }

    public List<string> CheckIfInstructionExist(Part currentPart)
    {
        return _context.Instructions
            .Where(i => i.Parts.Any(p => p.PartNumber == currentPart.PartNumber))
            .SelectMany(i => i.Machines)
            .Select(m => m.MachineDW)
            .Distinct()
            .ToList();
    }

    public Part CollectInstructionsUseCase(Part currentPart)
    {
        var instructions = _context.Instructions
            .Where(i => i.Parts.Any(p => p.PartNumber == currentPart.PartNumber))
            .Where(i => i.Machines.Any(m => m.MachineDW == currentPart.PickedDW))
            .Include(i => i.Parts)
            .Include(i => i.Machines)
            .ToList();

        currentPart.InstructionsForPart = instructions;
        return currentPart;
    }

    
}

