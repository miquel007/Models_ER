using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class Pelicula
    {
        public int Codigo { get; set; }
        public string nombre { get; set; }
        public int calificacion_edad { get; set; }
        public ICollection<Sala> salas { get; set; }
    }
}
