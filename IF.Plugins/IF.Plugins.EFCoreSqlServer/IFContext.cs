using System.Collections.Generic;
using System.Reflection.Emit;
using IF.CoreBusiness;
using Microsoft.EntityFrameworkCore;

namespace IF.Plugins.EFCoreSqlServer;

public class IFContext : DbContext
{
    public IFContext(DbContextOptions<IFContext> options) : base(options) { }

    public DbSet<Instruction> Instructions => Set<Instruction>();
    public DbSet<Part> Parts => Set<Part>();
    public DbSet<Machine> Machines => Set<Machine>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Instruction>()
            .HasMany(i => i.Parts)
            .WithMany(p => p.Instructions)
            .UsingEntity(j => j.ToTable("InstructionPart"));

        modelBuilder.Entity<Instruction>()
            .HasMany(i => i.Machines)
            .WithMany(m => m.Instructions)
            .UsingEntity(j => j.ToTable("InstructionMachine"));

        modelBuilder.Entity<Instruction>()
            .Property(i => i.InstructionNumber)
            .IsRequired();

        modelBuilder.Entity<Instruction>()
            .Property(i => i.InstructionName)
            .IsRequired();

        modelBuilder.Entity<Part>()
            .Property(p => p.PartNumber)
            .IsRequired();

        modelBuilder.Entity<Machine>()
            .Property(m => m.MachineDW)
            .IsRequired();
    }
}
