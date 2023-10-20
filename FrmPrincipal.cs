namespace ProyectoYaya
{
    public partial class FrmPrincipal : Form
    {
        private int id = 0;
        private string archivo = @"C:\ProyectoFinalAlgoritmos\Empleados.txt";
        private string[] empleado;
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            string carpeta = @"C:\ProyectoFinalAlgoritmos";
            if (Directory.Exists(carpeta))
            {
                CargarEmpleados(DgvEmpleados);
            }
            else
            {
                Directory.CreateDirectory(carpeta);
            }
        }

        private void CargarEmpleados(DataGridView dgv)
        {
            try
            {
                dgv.Rows.Clear();
                dgv.Columns.Clear();
                string path = archivo;

                if (File.Exists(path))
                {
                    DataGridViewTextBoxColumn columna;
                    string[] lineas = File.ReadAllLines(path);
                    string[] titulos = new string[12];
                    double sueldo;
                    double isr;
                    double igss;
                    double irtra;
                    titulos[0] = "ID";
                    titulos[1] = "Primer nombre";
                    titulos[2] = "Segundo nombre";
                    titulos[3] = "Demás nombres";
                    titulos[4] = "Primer apellido";
                    titulos[5] = "Segundo apellido";
                    titulos[6] = "Sueldo";
                    titulos[7] = "ISR";
                    titulos[8] = "IGSS";
                    titulos[9] = "IRTRA";
                    titulos[10] = null;
                    titulos[11] = null;


                    foreach (string titulo in titulos)
                    {
                        columna = new();
                        columna.HeaderText = titulo;
                        dgv.Columns.Add(columna);
                    }

                    foreach (string linea in lineas)
                    {
                        if (!String.IsNullOrEmpty(linea))
                        {
                            string[] empleado = linea.Split(",");
                            sueldo = Math.Round(Double.Parse(empleado[6]), 2);

                            if (sueldo > 4000)
                            {
                                isr = sueldo * 0.12;
                            }
                            else
                            {
                                isr = 0;
                            }
                            igss = Math.Round(sueldo * 0.483, 2);
                            irtra = Math.Round(sueldo * 0.01, 2);

                            if (id < Int32.Parse(empleado[0]))
                            {
                                id = Int32.Parse(empleado[0]);
                            }

                            dgv.Rows.Add(empleado[0], empleado[1], empleado[2], empleado[3], empleado[4], empleado[5], "Q. " + sueldo, "Q. " + isr, "Q. " + igss, "Q. " + irtra, "Editar", "Eliminar");
                        }
                    }

                    foreach (DataGridViewColumn cl in dgv.Columns)
                    {
                        cl.SortMode = DataGridViewColumnSortMode.NotSortable;
                    }
                    dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    dgv.RowHeadersVisible = false;
                    dgv.AllowUserToAddRows = false;
                    dgv.ReadOnly = true;
                }
                else
                {
                    MessageBox.Show("No se encontraron empleados para cargar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void agregarEmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            id++;
            FrmControl frmControl = new(id, true, "Guardar", archivo, empleado);
            frmControl.ShowDialog(this);
            CargarEmpleados(DgvEmpleados);
            frmControl.Close();
        }

        private void DgvEmpleados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    DataGridView dgv = (DataGridView)sender;
                    int fila = e.RowIndex;
                    int columa = e.ColumnIndex;
                    string valor = dgv.Rows[fila].Cells[columa].Value.ToString();

                    if (valor == "Editar")
                    {
                        empleado = new string[7];
                        empleado[0] = dgv.Rows[fila].Cells[0].Value.ToString();
                        empleado[1] = dgv.Rows[fila].Cells[1].Value.ToString();
                        empleado[2] = dgv.Rows[fila].Cells[2].Value.ToString();
                        empleado[3] = dgv.Rows[fila].Cells[3].Value.ToString();
                        empleado[4] = dgv.Rows[fila].Cells[4].Value.ToString();
                        empleado[5] = dgv.Rows[fila].Cells[5].Value.ToString();
                        empleado[6] = dgv.Rows[fila].Cells[6].Value.ToString().Substring(3);

                        FrmControl frmControl = new(0, false, "Editar", archivo, empleado);
                        frmControl.ShowDialog();
                        CargarEmpleados(DgvEmpleados);
                        frmControl.Close();
                    }
                    else if (valor == "Eliminar")
                    {
                        string idEmpleado = dgv.Rows[fila].Cells[0].Value.ToString();
                        string nombre = dgv.Rows[fila].Cells[1].Value.ToString();
                        string apellido = dgv.Rows[fila].Cells[4].Value.ToString();

                        DialogResult resultado = MessageBox.Show("¿Desea eliminar al empleado [" + nombre + " " + apellido + "]?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if(resultado == DialogResult.Yes)
                        {
                            EliminarEmpleado(idEmpleado);
                            MessageBox.Show("Empleado eliminado correctamente", "Aviso",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                            CargarEmpleados(DgvEmpleados);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void EliminarEmpleado(string id)
        {
            string archivoTemporal = Path.GetTempFileName();

            using (var sr = new StreamReader(archivo))
            using (var sw = new StreamWriter(archivoTemporal))
            {
                string linea;

                while((linea = sr.ReadLine()) != null){
                    string[] empleado = linea.Split(",");
                    if (empleado[0] != id)
                    {
                        sw.WriteLine(linea);
                    }
                }
            }

            File.Delete(archivo);
            File.Move(archivoTemporal, archivo);
        }
    }
}