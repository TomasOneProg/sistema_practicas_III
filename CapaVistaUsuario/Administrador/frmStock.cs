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
        private int idProveedorSeleccionado;
        private int idProductoSeleccionado;

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

            // Cargar los nombres de proveedores y productos en los ComboBox
            CargarProveedores();
            CargarProductos();

            MostrarStock();
            dgvStock.Select();
            CV_Utiles.BloquearControles(this);
            CV_Botonera.btnFormularios(this, btnCancelar);
        }

        private void CargarProveedores()
        {
            List<string> nombresProveedores = stock.ObtenerNombresProveedores();

            cmbProveedor.DataSource = nombresProveedores;
        }

        private void CargarProductos()
        {
            List<string> nombresProductos = stock.ObtenerNombresProductos();

            cmbProducto.DataSource = nombresProductos;
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
                // Obtener el nombre seleccionado en el ComboBox de proveedores
                string nombreProveedor = cmbProveedor.SelectedItem.ToString();
                // Obtener el ID del proveedor desde la capa de datos
                int idProveedor = ObtenerIdProveedor(nombreProveedor); // Método a implementar

                // Obtener el nombre seleccionado en el ComboBox de productos
                string nombreProducto = cmbProducto.SelectedItem.ToString();
                // Obtener el ID del producto desde la capa de datos
                int idProducto = ObtenerIdProducto(nombreProducto); // Método a implementar

                // Asignar los IDs de proveedor y producto a la instancia de CN_Stock
                stock.IdProveedor = idProveedor;
                stock.IdProducto = idProducto;

                // Pasar los demás datos y guardar en la base de datos
                PasarDatos(false);
                stock.InsertarStock();
                MostrarStock();

                CV_Botonera.btnFormularios(this, btnGuardaCambios);
                CV_Utiles.BloquearControles(this);
                dgvStock.Select();

                MessageBox.Show("Se han guardado los datos con éxito");
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

        private int ObtenerIdProveedor(string nombreProveedor)
        {
            CN_Stock negocioStock = new CN_Stock();
            return negocioStock.ObtenerIdProveedor(nombreProveedor);
        }

        private int ObtenerIdProducto(string nombreProducto)
        {
            CN_Stock negocioStock = new CN_Stock();
            return negocioStock.ObtenerIdProducto(nombreProducto);
        }
    }

}
