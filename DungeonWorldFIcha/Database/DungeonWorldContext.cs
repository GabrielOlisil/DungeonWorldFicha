using DungeonWorldFIcha.Models;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;

namespace DungeonWorldFIcha.Database;

public class DungeonWorldContext(IConfiguration configuration) : DbContext
{
    public DbSet<Personagem> Personages { get; set; }
    public DbSet<Habilidade> Habilidades { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql(configuration["MariaDB:ConnString"], new MariaDbServerVersion(configuration["MariaDB:ServerVersion"]));
    }
}