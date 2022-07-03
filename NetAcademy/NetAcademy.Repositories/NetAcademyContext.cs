using Microsoft.EntityFrameworkCore;

namespace NetAcademy.Repositories;

public class NetAcademyContext: DbContext
{
    private readonly string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=NetAcademy;Trusted_Connection=True;";//connection string di default se non viene passaa da altrove
    
    //tabella di esempio:
    //internal DbSet<GenerationUnit> GenerationUnits { get; set; }

    public NetAcademyContext()
    {
        
    }

    public NetAcademyContext(string connStr): this()
    {
        connectionString = connStr;
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Any additional entities' options should be declared here
        
        //view declaration example:
        //modelBuilder.Entity<ViewModel>().ToView("ViewName", "ViewSchema");
    }
}