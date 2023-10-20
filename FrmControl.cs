using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoYaya
{
    public partial class FrmControl : Form
    {
        private int id;
        private bool guardar;
        private string descripcion;
        private string archivo;
        private string[] empleado;

        public FrmControl(int _id, bool _guardar, string _descripcion, string _archivo, string[] _empleado)
        {
            InitializeComponent();
            this.id = _id;
            this.guardar = _guardar;
            this.descripcion = _descripcion;
            this.archivo = _archivo;
            this.empleado = _empleado;
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmControl_Load(object sender, EventArgs e)
        {
            this.Text = descripcion + " empleado";
            BtnControl.Text = descripcion;
            LblTitulo.Text = descripcion + " empleado";

            if (!guardar)
            {
                id = Int32.Parse(empleado[0]);
                TxtPrimerNombre.Text = empleado[1];
                TxtSegundoNombre.Text = empleado[2];
                TxtDemasNombres.Text = empleado[3];
                TxtPrimerApellido.Text = empleado[4];
                TxtSegundoApellido.Text = empleado[5];
                TxtSueldo.Text = empleado[6];
            }
        }

        private void BtnControl_Click(object sender, EventArgs e)
        {
            try
            {
                bool completado = false;
                string mensaje = "";
                string[] datosEmpleado = new string[7];
                //if (guardar)
                //{
                if (ValidarControles())
                {
                    if (VerificarSueldo(TxtSueldo.Text))
                    {
                        string[] empleado = new string[7];
                        string registro;

                        empleado[0] = id.ToString();
                        empleado[1] = TxtPrimerNombre.Text;
                        empleado[2] = TxtSegundoNombre.Text;
                        empleado[3] = TxtDemasNombres.Text;
                        empleado[4] = TxtPrimerApellido.Text;
                        empleado[5] = TxtSegundoApellido.Text;
                        empleado[6] = TxtSueldo.Text;

                        registro = String.Join(",", empleado);

                        if (guardar)
                        {
                            using (StreamWriter sw = File.AppendText(archivo))
                            {
                                sw.WriteLine(registro);
                            }
                            completado = true;
                            mensaje = "Empleado guardado con éxito";
                        }
                        else
                        {
                            string archivoTemporal = Path.GetTempFileName();

                            using (var sr = new StreamReader(archivo))
                            using (var sw = new StreamWriter(archivoTemporal))
                            {
                                string linea;

                                while ((linea = sr.ReadLine()) != null)
                                {
                                    string[] empleadoArchivo = linea.Split(",");
                                    if (empleado[0] != empleadoArchivo[0])
                                    {
                                        sw.WriteLine(linea);
                                    }
                                    else
                                    {
                                        sw.WriteLine(registro);
                                    }
                                }
                            }

                            File.Delete(archivo);
                            File.Move(archivoTemporal, archivo);
                            completado = true;
                            mensaje = "Empleado actualizado correctamente";
                        }
                    }
                    else
                    {
                        MessageBox.Show("El sueldo no tiene el formato correcto (XXXX.XX)", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("Debe llenar los campos requeridos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                if (completado)
                {
                    MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool ValidarControles()
        {
            bool exito = false;
            if (TxtPrimerNombre.Text.Length > 0 &&
                TxtSegundoNombre.Text.Length > 0 &&
                TxtPrimerApellido.Text.Length > 0 &&
                TxtSegundoApellido.Text.Length > 0 &&
                TxtSueldo.Text.Length > 0)
            {
                exito = true;
            }
            return exito;
        }

        private bool VerificarSueldo(string texto)
        {
            double sueldo;
            return Double.TryParse(texto, out sueldo);
        }
    }
}
