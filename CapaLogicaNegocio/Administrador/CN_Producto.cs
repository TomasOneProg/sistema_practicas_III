using CapaAccesoDatos.Administrador;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaNegocio.Administrador
{
    public class CN_Producto
    {
        private CD_Producto cdProducto = new CD_Producto();

        #region ATRIBUTOS
        private int idProducto;
        private string nombre;
        private string categoria;
        private string marca;
        private string tipoDeCantidad;
        #endregion

        #region PROPERTIES

        public int IdProducto
        {
            get => idProducto;
            set { idProducto = value; }
        }

        public string Nombre
        {
            get => nombre;
            set { nombre = value; }
        }

        public string Categoria
        {
            get => categoria;
            set { categoria = value; }
        }

        public string Marca
        {
            get => marca;
            set { marca = value; }
        }

        public string TipoDeCantidad
        {
            get => tipoDeCantidad;
            set { tipoDeCantidad = value; }
        }

        #endregion

        #region METODOS

        public DataTable MostrarProductos()
        {
            DataTable tabla = new DataTable();
            tabla = cdProducto.MostrarProductos();
            return tabla;
        }

        public void InsertarProducto()
        {
            PasarDatos();
            cdProducto.InsertarProducto();
        }

        public void ModificarProducto()
        {
            PasarDatos();
            cdProducto.ModificarProducto();
        }

        public void EliminarProducto()
        {
            cdProducto.IdProducto = IdProducto;
            cdProducto.EliminarProducto();
        }

        private void PasarDatos()
        {
            cdProducto.IdProducto = IdProducto;
            cdProducto.Nombre = Nombre;
            cdProducto.Categoria = Categoria;
            cdProducto.Marca = Marca;
            cdProducto.TipoDeCantidad = TipoDeCantidad;
        }

        #endregion
    }

}
