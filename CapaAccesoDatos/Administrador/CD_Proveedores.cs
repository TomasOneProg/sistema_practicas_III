using System;
using System.Data;
using CapaAccesoDatos;

namespace CapaAccesoDatos.Administrador
{
    public class CD_Proveedores
    {
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
            string sSql = "SELECT * FROM Proveedores";
            clsEjecutarComando Ejecutar = new clsEjecutarComando();
            return Ejecutar.Ejecutar(sSql);
        }

        public void InsertarProveedor()
        {
            string sSql = "INSERT INTO Proveedores (nombre, razonSocial, cuit, direccionDeEmail, telefono, certificadoAfip, categoria, producto) " +
                "VALUES ('" + Nombre + "','" + RazonSocial + "','" + Cuit + "','" + DireccionDeEmail + "','" + Telefono + "','" + CertificadoAfip + "','" + Categoria + "','" + Producto + "')";
            Console.WriteLine(sSql);
            clsEjecutarComando Ejecutar = new clsEjecutarComando();
            Ejecutar.Ejecutar(sSql);
        }

        public void ModificarProveedor()
        {
            string sSql = "UPDATE Proveedores SET " +
                "nombre = '" + Nombre + "', razonSocial = '" + RazonSocial + "', cuit = '" + Cuit +
                "', direccionDeEmail = '" + DireccionDeEmail + "', telefono = '" + Telefono + "', certificadoAfip = '" + CertificadoAfip +
                "', categoria = '" + Categoria + "', producto = '" + Producto + "'" +
                " WHERE idProveedor = " + IdProveedor;
            Console.WriteLine(sSql);
            clsEjecutarComando Ejecutar = new clsEjecutarComando();
            Ejecutar.Ejecutar(sSql);
        }

        public void EliminarProveedor()
        {
            string sSql = "DELETE FROM Proveedores WHERE idProveedor = " + IdProveedor;
            clsEjecutarComando Ejecutar = new clsEjecutarComando();
            Ejecutar.Ejecutar(sSql);
        }
        #endregion
    }
}
