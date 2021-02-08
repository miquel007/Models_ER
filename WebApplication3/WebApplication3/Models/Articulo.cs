using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class Articulo
    {
        public int Codigo { get; set; }
        public string nombre { get; set; }
        public int precio { get; set; }
        public int id_fabricante { get; set; }
        public Fabricante fabricante { get; set; }
    }
}
