using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaComun;
using CapaVistaUsuario.Administrador;

namespace CapaVistaUsuario
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            lblSesion.Text = "Sesion de: " + UserCache.Usuario; 
        }

        private void cambioDePasswordToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Loguin.frmCambioPassword fAux = new Loguin.frmCambioPassword();
            fAux.MdiParent = this;
            fAux.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult resultado = MessageBox.Show("Esta seguro de CERRAR el sistema?",
                                "FINALIZAR SISTEMA",
                                MessageBoxButtons.OKCancel,
                                MessageBoxIcon.Asterisk,
                                MessageBoxDefaultButton.Button2);

            if (resultado == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        private void proveedoresToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmProveedores fAux = new frmProveedores();
            fAux.MdiParent = this;
            fAux.Show();
        }

        private void stockToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmStock fAux = new frmStock();
            fAux.MdiParent = this;
            fAux.Show();
        }

        private void personalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPersonal fAux = new frmPersonal();
            fAux.MdiParent = this;
            fAux.Show();
        }

        private void facturaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFacturacion fAux = new frmFacturacion();
            fAux.MdiParent = this;
            fAux.Show();
        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMenu fAux = new frmMenu();
            fAux.MdiParent = this;
            fAux.Show();
        }

        private void productoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProducto fAux = new frmProducto();
            fAux.MdiParent = this;
            fAux.Show();
        }
    }
}
