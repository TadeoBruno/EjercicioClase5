using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Ejercicio_clase_5
{
    public partial class Form1 : Form
    {
        List<Empleado> Empleados = Empresa.getEmpresa().getEmpleados();
        private int IndexRow;
        bool check;
        public Form1()
        {
            InitializeComponent();
            label5.Text = "";
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrWhiteSpace(txtNombre.Text) &&!String.IsNullOrWhiteSpace(txtApellido.Text) &&!String.IsNullOrWhiteSpace(txtDni.Text) &&!String.IsNullOrWhiteSpace(txtEmail.Text) &&(EmailCheck() == true))
           {
                Empleados.Add(new Empleado(txtNombre.Text, txtApellido.Text, Convert.ToInt32(txtDni.Text),txtEmail.Text));
                FillGrid();
                txtNombre.Clear();
                txtApellido.Clear();
                txtDni.Clear();
                txtEmail.Clear();
            }
            else
            {
                MessageBox.Show("Datos mal ingresados");
            }
            
        }

        private bool EmailCheck()
        {
            Regex validateEmailRegex = new Regex("^\\S+@\\S+\\.\\S+$");
            check = validateEmailRegex.IsMatch(txtEmail.Text);
            return check;
        }

        private void txtDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar); //Permite ingresar solo numeros
        }
        private void FillGrid()
        {
            if (tablaEmpleados.RowCount > 1)
            {
                for (int j = 0; j < tablaEmpleados.RowCount; j++)
                {
                    tablaEmpleados.Rows.RemoveAt(0);
                }
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
            if (Empleados.Count() > 0)
            {
                Empleados.RemoveAt(IndexRow);
                FillGrid();
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void tablaEmpleados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            IndexRow = e.RowIndex;
            label5.Text = (IndexRow + 1).ToString();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtNombre.Text) && !String.IsNullOrWhiteSpace(txtApellido.Text) && !String.IsNullOrWhiteSpace(txtDni.Text) && !String.IsNullOrWhiteSpace(txtEmail.Text) && (EmailCheck() == true))
            {
                Empleados[IndexRow].Nombre = txtNombre.Text;
                Empleados[IndexRow].Apellido = txtApellido.Text;
                Empleados[IndexRow].DNI = Convert.ToInt32(txtDni.Text);
                Empleados[IndexRow].Email = txtEmail.Text;
                FillGrid();
            }

        }
    }
}
