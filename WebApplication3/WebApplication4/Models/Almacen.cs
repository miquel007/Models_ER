using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class Almacen
    {
        public int Codigo { get; set; }
        public string lugar { get; set; }
        public int capacidad { get; set; }
        public ICollection<Caja> cajas { get; set; }
    }
}
