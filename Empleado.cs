using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_clase_5
{
    class Empleado
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int DNI { get; set; }
        public string Email { get; set; }

        public Empleado(string nombre, string apellido, int dni, string email)
        {
            Nombre = nombre;
            Apellido = apellido;
            DNI = dni;
            Email = email;
        }
    }
}
