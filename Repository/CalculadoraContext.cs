using Domain;
using Microsoft.EntityFrameworkCore;

public class CalculadoraContext : DbContext
{
    public DbSet<OperacaoHistorico> OperacoesHistorico { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=calculadora_frwk;Trusted_Connection=True;MultipleActiveResultSets=true");
    }
}
