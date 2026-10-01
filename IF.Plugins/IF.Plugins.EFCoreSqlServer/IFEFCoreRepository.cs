using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using IF.CoreBusiness;
using IF.UseCase.PlugInInterfaces;
using System.IO;

namespace IF.Plugins.EFCoreSqlServer;

public class EfInstructionRepository : IInstructionRepository
{
    private readonly IFContext _context;

    public EfInstructionRepository(IFContext context)
    {
        _context = context;
    }

    public void AddInstruction(string newInstructionName, string newInstructionParts, string newInstructionMachineDW, string newInstructionPdfRelativePath)
    {
        ///Parts
        ///
        List<string> normalizednewInstructionParts = newInstructionParts
                .Replace(";", ",")
                .Replace(".", ",")
                .ToUpper()
                .Split(',')
                .Select(x => x.Trim())
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Distinct()
                .ToList();

        foreach (var p in normalizednewInstructionParts)
        {
            if (!_context.Parts.Any(part => part.PartNumber == p))
            {
                _context.Parts.Add(new Part
                {
                    PartNumber = p
                });
            }
        }
        

        ///Machines
        ///
        List<string> normalizedNewInstructionMachineDW = newInstructionMachineDW
            .Replace(";", ",")
            .Replace(".", ",")
            .ToUpper()
            .Split(',')
            .Select(x => x.Trim())
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .Distinct()
            .ToList();

        foreach (var m in normalizedNewInstructionMachineDW)
        {
            if (!_context.Machines.Any(machine => machine.MachineDW == m))
            {
                _context.Machines.Add(new Machine
                {
                    MachineDW = m
                });
            }
        }
        _context.SaveChanges();
        var selectedParts = _context.Parts.Where(part => normalizednewInstructionParts.Contains(part.PartNumber)).ToList();
        var selectedMachines = _context.Machines.Where(machine => normalizedNewInstructionMachineDW.Contains(machine.MachineDW)).ToList();

        ///Instructions
        ///
        Instruction newInstruction = new Instruction
        {
            InstructionName = newInstructionName,
            PdfRelativePath = newInstructionPdfRelativePath,
            Parts = selectedParts,
            Machines = selectedMachines
        };
        _context.Instructions.Add(newInstruction);
        _context.SaveChanges();

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

    public Instruction? GetInstruction(string pdfRelativePath)
    {
        return _context.Instructions
            .Include(i => i.Parts)
            .Include(i => i.Machines)
            .FirstOrDefault(i => i.PdfRelativePath == pdfRelativePath);
    }

    public void UpdateInstruction(Instruction instruction)
    {
        throw new NotImplementedException();
    }
}

