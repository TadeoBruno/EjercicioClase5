using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_clase_5
{
    class Empresa
    {
        private List<Empleado> Empleados = new List<Empleado>();
        //singleton.
        private static Empresa instance;
        private Empresa() { }
        public static Empresa getEmpresa()
        {
            if (instance == null)
            {
                instance = new Empresa();
            }
            return instance;
        }
        public List<Empleado> getEmpleados()
        {
            return Empleados;
        }
    }
}
