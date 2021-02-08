using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class Sala
    {
        public string Codigo { get; set; }
        public string nombre { get; set; }
        public int id_pelicula { get; set; }
        public Pelicula pelicula { get; set; }
    }
}
