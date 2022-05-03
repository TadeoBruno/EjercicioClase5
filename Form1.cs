using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio_clase_5
{
    public partial class Form1 : Form
    {
        List<Empleado> Empleados = Empresa.getEmpresa().getEmpleados();
        private int rowIndex = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void tablaEmpleados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if
                (
                    !String.IsNullOrWhiteSpace(txtNombre.Text) &&
                    !String.IsNullOrWhiteSpace(txtApellido.Text) &&
                    !String.IsNullOrWhiteSpace(txtDni.Text) &&
                    !String.IsNullOrWhiteSpace(txtEmail.Text)
                )   
            {
                Empleados.Add(new Empleado(txtNombre.Text, txtApellido.Text, Convert.ToInt32(txtDni.Text),txtEmail.Text));
                FillGrid();
                txtNombre.Clear();
                txtApellido.Clear();
                txtDni.Clear();
                txtEmail.Clear();
                return;

            }
        }

        private void txtDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }
        private void FillGrid()
        {
            if (tablaEmpleados.RowCount > 1)
            {
                tablaEmpleados.Rows.Clear();
            }
            int i = 0; foreach (Empleado emp in Empleados)
            {
                //agregamos una row
                tablaEmpleados.Rows.Add();
                tablaEmpleados.Rows[i].Cells[0].Value = emp.Nombre;
                tablaEmpleados.Rows[i].Cells[1].Value = emp.Apellido;
                tablaEmpleados.Rows[i].Cells[2].Value = emp.DNI;
                tablaEmpleados.Rows[i].Cells[3].Value = emp.Email;
                i++;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Empleados.Count() > 0 && rowIndex < Empleados.Count())
            {
                Empleados.RemoveAt(rowIndex);
                FillGrid();
            }
        }

        private void tablaEmpleados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rowIndex = e.RowIndex;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}
