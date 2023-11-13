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
        }
        #endregion
    }

}
