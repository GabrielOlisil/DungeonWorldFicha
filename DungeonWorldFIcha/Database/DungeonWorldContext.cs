using DungeonWorldFIcha.Models;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;

namespace DungeonWorldFIcha.Database;

public class DungeonWorldContext(IConfiguration configuration) : DbContext
{
    public DbSet<Personagem> Personagens { get; set; }
    public DbSet<Habilidade> Habilidades { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql(configuration["MariaDB:ConnString"],
            new MariaDbServerVersion(configuration["MariaDB:ServerVersion"]));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Personagem>(e => { e.Property(p => p.PersonagemId).ValueGeneratedOnAdd(); });

        modelBuilder.Entity<Habilidade>(e => { e.Property(p => p.Id).ValueGeneratedOnAdd(); });
    }
}