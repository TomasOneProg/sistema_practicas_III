using CapaLogicaNegocio.Administrador;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaVistaUsuario
{
    public partial class frmStock : Form
    {
        CN_Stock stock = new CN_Stock();

        public frmStock()
        {
            InitializeComponent();
        }

        private void frmStock_Load(object sender, EventArgs e)
        {
            dgvStock.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStock.ReadOnly = true;
            dgvStock.MultiSelect = false;
            dgvStock.AllowUserToAddRows = false;

            MostrarStock();
            dgvStock.Select();
            CV_Utiles.BloquearControles(this);
            CV_Botonera.btnFormularios(this, btnCancelar);
        }

        private void dgvStock_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvStock.SelectedRows.Count > 0)
            {
                string fechaString = dgvStock.Rows[dgvStock.SelectedRows[0].Index].Cells["fechaDeVencimiento"].Value.ToString();
                // Convierte la cadena a un objeto DateTime
                DateTime fechaVencimiento;
                if (DateTime.TryParse(fechaString, out fechaVencimiento))
                {
                    // Asigna el valor al DateTimePicker
                    dtpFechaVencimiento.Value = fechaVencimiento;
                }
                else
                {
                    // Manejo de error si la conversión no es exitosa
                    MessageBox.Show("No se pudo convertir la fecha correctamente.");
                }
                txtNumeroLote.Text = dgvStock.Rows[dgvStock.SelectedRows[0].Index].Cells["numeroDeLote"].Value.ToString();
                txtCantidad.Text = dgvStock.Rows[dgvStock.SelectedRows[0].Index].Cells["cantidad"].Value.ToString();
            }
        }

        #region BOTONES

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                PasarDatos(false);

                stock.InsertarStock();
                MostrarStock();

                CV_Botonera.btnFormularios(this, btnGuardaCambios);
                CV_Utiles.BloquearControles(this);
                dgvStock.Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se guardaron los datos por: \n" + ex);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            CV_Utiles.DesbloquearControles(this);
            CV_Utiles.LimpiarControles(this);
            CV_Botonera.btnFormularios(this, btnAgregar);
            // Asegúrate de ajustar el nombre del control según tu formulario
            txtNumeroLote.Select();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            CV_Botonera.btnFormularios(this, btnCancelar);
            CV_Utiles.BloquearControles(this);
            CV_Utiles.LimpiarControles(this);
            dgvStock.Select();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            CV_Botonera.btnFormularios(this, btnModificar);
            CV_Utiles.DesbloquearControles(this);
            // Asegúrate de ajustar el nombre del control según tu formulario
            txtNumeroLote.Select();
        }

        private void btnGuardaCambios_Click(object sender, EventArgs e)
        {
            try
            {
                PasarDatos(true);

                stock.ModificarStock();

                MostrarStock();
                CV_Botonera.btnFormularios(this, btnGuardaCambios);
                CV_Utiles.BloquearControles(this);
                dgvStock.Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se guardaron los datos por: \n" + ex);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show("¿Está seguro de ELIMINAR definitivamente el stock?",
                                            "ELIMINAR STOCK",
                                            MessageBoxButtons.OKCancel,
                                            MessageBoxIcon.Question);
            if (resultado == DialogResult.OK)
            {
                stock.IdStock = Convert.ToInt32(dgvStock.Rows[dgvStock.SelectedRows[0].Index].Cells["idStock"].Value.ToString());
                stock.EliminarStock();
                MostrarStock();
                dgvStock.Select();
            }
        }

        #endregion

        private void MostrarStock()
        {
            dgvStock.DataSource = stock.MostrarStock();
        }

        private void PasarDatos(bool origen)
        {
            if (origen == true)
            {
                stock.IdStock = Convert.ToInt32(dgvStock.Rows[dgvStock.SelectedRows[0].Index].Cells["idStock"].Value.ToString());
            }
            else
            {
                stock.IdStock = 0;
            }

            stock.FechaDeVencimiento = dtpFechaVencimiento.Value.ToString();
            stock.NumeroDeLote = Convert.ToInt32(txtNumeroLote.Text);
            stock.Cantidad = Convert.ToInt32(txtCantidad.Text);
        }
    }

}
