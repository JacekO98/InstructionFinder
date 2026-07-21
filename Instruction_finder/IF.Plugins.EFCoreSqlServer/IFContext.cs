using IF.CoreBusiness;
using Microsoft.EntityFrameworkCore;

namespace IF.Plugins.EFCoreSqlServer
{
    public class IFContext : DbContext
    {
        public DbSet<Part>? Parts { get; set; }
        public DbSet<Instruction>? Instructions { get; set; }
        public DbSet<Machine>? Machines { get; set; }
        public DbSet<InstructionsPart> InstructionsParts  { get; set; }
        public DbSet<InstructionsMachine> InstructionsMachines { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InstructionsPart>()
                .HasKey(ip => new { ip.InstructionID, ip.PartID });

            modelBuilder.Entity<InstructionsPart>()
                .HasOne(ip => ip.Instruction)
                .WithMany(i => i.InstructionsParts)
                .HasForeignKey(IParameterPolicy => ip.PartID);

        }




    }
}
