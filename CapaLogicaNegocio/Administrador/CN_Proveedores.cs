using System;
using System.Data;
using CapaAccesoDatos.Administrador;

namespace CapaLogicaNegocio.Administrador
{
    public class CN_Proveedores
    {
        private CD_Proveedores cdProveedor = new CD_Proveedores();

        #region ATRIBUTOS
        private int idProveedor;
        private string nombre;
        private string razonSocial;
        private string cuit;
        private string direccionDeEmail;
        private string telefono;
        private string certificadoAfip;
        private string categoria;
        private string producto;
        #endregion

        #region PROPERTIES
        public int IdProveedor
        {
            get => idProveedor;
            set { idProveedor = value; }
        }

        public string Nombre
        {
            get => nombre;
            set { nombre = value; }
        }

        public string RazonSocial
        {
            get => razonSocial;
            set { razonSocial = value; }
        }

        public string Cuit
        {
            get => cuit;
            set { cuit = value; }
        }

        public string DireccionDeEmail
        {
            get => direccionDeEmail;
            set { direccionDeEmail = value; }
        }

        public string Telefono
        {
            get => telefono;
            set { telefono = value; }
        }

        public string CertificadoAfip
        {
            get => certificadoAfip;
            set { certificadoAfip = value; }
        }

        public string Categoria
        {
            get => categoria;
            set { categoria = value; }
        }

        public string Producto
        {
            get => producto;
            set { producto = value; }
        }
        #endregion

        #region METODOS
        public DataTable MostrarProveedores()
        {
            DataTable tabla = new DataTable();
            tabla = cdProveedor.MostrarProveedores();
            return tabla;
        }

        public void InsertarProveedor()
        {
            PasarDatos();
            cdProveedor.InsertarProveedor();
        }

        public void ModificarProveedor()
        {
            PasarDatos();
            cdProveedor.ModificarProveedor();
        }

        public void EliminarProveedor()
        {
            cdProveedor.IdProveedor = idProveedor;
            cdProveedor.EliminarProveedor();
        }

        private void PasarDatos()
        {
            cdProveedor.IdProveedor = idProveedor;
            cdProveedor.Nombre = nombre;
            cdProveedor.RazonSocial = razonSocial;
            cdProveedor.Cuit = cuit;
            cdProveedor.DireccionDeEmail = direccionDeEmail;
            cdProveedor.Telefono = telefono;
            cdProveedor.CertificadoAfip = certificadoAfip;
            cdProveedor.Categoria = categoria;
            cdProveedor.Producto = producto;
        }
        #endregion
    }
}
