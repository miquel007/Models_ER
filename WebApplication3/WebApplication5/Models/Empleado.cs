using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class Empleado
    {
        public string DNI { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public int id_departamento { get; set; }
        public Departamento departamento { get; set; }
    }
}
