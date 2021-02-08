using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class Departamento
    {
        public int Codigo { get; set; }
        public string nombre { get; set; }
        public int presupuesto { get; set; }
        public ICollection<Empleado> empleados { get; set; }
    }
}
