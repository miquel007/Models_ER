using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class Caja
    {
        public string num_referencia { get; set; }
        public string contenido { get; set; }
        public int valor { get; set; }
        public int id_almacen { get; set; }
        public Almacen almacen { get; set; }
    }
}
