using Microsoft.EntityFrameworkCore;

namespace AquaTrack.Models
{
    public class BancoDeDados : DbContext
    {
        public DbSet<Leitura> Leituras { get; set; }
     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(connectionString : "Host=localhost;Port=5432;Database=AquaTrack;User Id=postgres;Password=admin;");
            

}
}
}
