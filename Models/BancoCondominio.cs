using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AquaTrack.Models
{
    public class BancoCondominio :DbContext
    {
    public DbSet<Condominio> Condominios { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
     optionsBuilder.UseNpgsql(connectionString: "Host=localhost;Port=5432;Database=AquaTrack;User Id=postgres;Password=admin;");

    }
    }
}


