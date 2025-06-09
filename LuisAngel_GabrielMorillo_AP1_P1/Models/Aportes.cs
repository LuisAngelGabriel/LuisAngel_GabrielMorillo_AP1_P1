using System.ComponentModel.DataAnnotations;

namespace LuisAngel_GabrielMorillo_AP1_P1.Models
{
    public class Aportes
    {
        [Key]
        public int AportesId { get; set; }
        
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public string Nombres { get; set; } = string.Empty;
        public DateOnly Fecha { get; set; } = DateOnly.FromDateTime(DateTime.Now);

       [Range(1, double.MaxValue, ErrorMessage = "El monto tiene que ser mayor de 1")]
       public double monto { get; set; }

    }
}
