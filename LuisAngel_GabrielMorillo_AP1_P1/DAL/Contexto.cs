using LuisAngel_GabrielMorillo_AP1_P1.Models;
using Microsoft.EntityFrameworkCore;

namespace LuisAngel_GabrielMorillo_AP1_P1.DAL
{
    public class Contexto : DbContext 
    {

        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        public DbSet <Registro> Registros { get; set; }
    }
}
