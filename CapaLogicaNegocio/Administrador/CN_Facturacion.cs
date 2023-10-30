using System;
using System.Data;
using CapaAccesoDatos.Administrador;

namespace CapaLogicaNegocio.Administrador
{
    public class CN_Facturacion
    {
        private CD_Facturacion cdFacturacion = new CD_Facturacion();

        #region ATRIBUTOS
        private int idFacturacion;
        private int idMenu;
        private string nombreDelCliente;
        private int cantidades;
        private string formaDePago;
        private float precioTotal;
        #endregion

        #region PROPERTIES

        public int IdFacturacion
        {
            get => idFacturacion;
            set { idFacturacion = value; }
        }

        public int IdMenu
        {
            get => idMenu;
            set { idMenu = value; }
        }

        public string NombreDelCliente
        {
            get => nombreDelCliente;
            set { nombreDelCliente = value; }
        }

        public int Cantidades
        {
            get => cantidades;
            set { cantidades = value; }
        }

        public string FormaDePago
        {
            get => formaDePago;
            set { formaDePago = value; }
        }

        public float PrecioTotal
        {
            get => precioTotal;
            set { precioTotal = value; }
        }
        #endregion

        #region METODOS

        public DataTable MostrarFacturacion()
        {
            DataTable tabla = new DataTable();
            tabla = cdFacturacion.MostrarFacturacion();
            return tabla;
        }

        public void InsertarFacturacion()
        {
            PasarDatos();
            cdFacturacion.InsertarFacturacion();
        }

        public void ModificarFacturacion()
        {
            PasarDatos();
            cdFacturacion.ModificarFacturacion();
        }

        public void EliminarFacturacion()
        {
            cdFacturacion.IdFacturacion = IdFacturacion;
            cdFacturacion.EliminarFacturacion();
        }

        private void PasarDatos()
        {
            cdFacturacion.IdFacturacion = idFacturacion;
            cdFacturacion.IdMenu = IdMenu;
            cdFacturacion.NombreDelCliente = NombreDelCliente;
            cdFacturacion.Cantidades = Cantidades;
            cdFacturacion.FormaDePago = FormaDePago;
            cdFacturacion.PrecioTotal = PrecioTotal;
        }

        #endregion
    }
}
