using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaNegocio.Administrador
{
    public class CN_Stock
    {
        private CD_Stock cdStock = new CD_Stock();

        #region ATRIBUTOS
        private int idStock;
        private string fechaDeVencimiento;
        private int numeroDeLote;
        private int cantidad;
        private int idProveedor;
        private int idProducto;
        #endregion

        #region PROPERTIES
        public int IdStock
        {
            get => idStock;
            set { idStock = value; }
        }

        public string FechaDeVencimiento
        {
            get => fechaDeVencimiento;
            set { fechaDeVencimiento = value; }
        }

        public int NumeroDeLote
        {
            get => numeroDeLote;
            set { numeroDeLote = value; }
        }

        public int Cantidad
        {
            get => cantidad;
            set { cantidad = value; }
        }

        public int IdProveedor
        {
            get => idProveedor;
            set { idProveedor = value; }
        }

        public int IdProducto
        {
            get => idProducto;
            set { idProducto = value; }
        }
        #endregion

        #region METODOS
        public DataTable MostrarStock()
        {
            DataTable tabla = new DataTable();
            tabla = cdStock.MostrarStock();
            return tabla;
        }

        public void InsertarStock()
        {
            PasarDatos();
            cdStock.InsertarStock();
        }

        public void ModificarStock()
        {
            PasarDatos();
            cdStock.ModificarStock();
        }

        public void EliminarStock()
        {
            cdStock.IdStock = IdStock;
            cdStock.EliminarStock();
        }

        private void PasarDatos()
        {
            cdStock.IdStock = idStock;
            cdStock.FechaDeVencimiento = FechaDeVencimiento;
            cdStock.NumeroDeLote = NumeroDeLote;
            cdStock.Cantidad = Cantidad;
            cdStock.IdProveedor = IdProveedor;
            cdStock.IdProducto = IdProducto;
        }

        // Método para obtener los nombres de proveedores desde la capa de datos
        public List<string> ObtenerNombresProveedores()
        {
            return cdStock.ObtenerNombresProveedores();
        }

        // Método para obtener los nombres de productos desde la capa de datos
        public List<string> ObtenerNombresProductos()
        {
            return cdStock.ObtenerNombresProductos();
        }
        // Método para obtener el ID del proveedor a partir del nombre
        public int ObtenerIdProveedor(string nombreProveedor)
        {
            // Delega la consulta a la capa de datos
            return cdStock.ObtenerIdProveedor(nombreProveedor);
        }

        // Método para obtener el ID del producto a partir del nombre
        public int ObtenerIdProducto(string nombreProducto)
        {
            // Delega la consulta a la capa de datos
            return cdStock.ObtenerIdProducto(nombreProducto);
        }
        #endregion
    }

}
