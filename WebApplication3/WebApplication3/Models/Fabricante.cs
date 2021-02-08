using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class Fabricante
    {
        public int Codigo { get; set; }
        public string nombre { get; set; }
        public ICollection<Articulo> articulos { get; set; }
    }
}
