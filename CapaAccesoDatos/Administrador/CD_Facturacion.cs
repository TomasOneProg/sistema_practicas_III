using System;
using System.Data;
using CapaAccesoDatos;

namespace CapaAccesoDatos.Administrador
{
    public class CD_Facturacion
    {
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
            string sSql = "SELECT * FROM Facturacion";
            clsEjecutarComando Ejecutar = new clsEjecutarComando();
            return Ejecutar.Ejecutar(sSql);
        }

        public void InsertarFacturacion()
        {
            string sSql = "INSERT INTO Facturacion (idMenu, nombreDelCliente, cantidades, formaDePago, precioTotal) " +
                "VALUES (" + IdMenu + ",'" + NombreDelCliente + "'," + Cantidades + ",'" + FormaDePago + "'," + PrecioTotal + ")";
            Console.WriteLine(sSql);
            clsEjecutarComando Ejecutar = new clsEjecutarComando();
            Ejecutar.Ejecutar(sSql);
        }

        public void ModificarFacturacion()
        {
            string sSql = "UPDATE Facturacion SET " +
                "idMenu = " + IdMenu + ", nombreDelCliente = '" + NombreDelCliente + "', cantidades = " + Cantidades +
                ", formaDePago = '" + FormaDePago + "', precioTotal = " + PrecioTotal +
                " WHERE idFacturacion = " + IdFacturacion;
            Console.WriteLine(sSql);
            clsEjecutarComando Ejecutar = new clsEjecutarComando();
            Ejecutar.Ejecutar(sSql);
        }

        public void EliminarFacturacion()
        {
            string sSql = "DELETE FROM Facturacion WHERE idFacturacion = " + IdFacturacion;
            clsEjecutarComando Ejecutar = new clsEjecutarComando();
            Ejecutar.Ejecutar(sSql);
        }
        #endregion
    }
}
