using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaAccesoDatos.Administrador
{
    public class CD_Personal
    {
        #region ATRIBUTOS
        private int idPersonal;
        private string apellido;
        private string nombre;
        private string nroDoc;
        private string cuil;
        private string calle;
        private int nro;
        #endregion

        #region PROPERTIES
        public int IdPersonal
        {
            get => idPersonal;
            set { idPersonal = value; }
        }

        public string Apellido
        {
            get => apellido;
            set { apellido = value; }
        }

        public string Nombre
        {
            get => nombre;
            set { nombre = value; }
        }

        public string NroDoc
        {
            get => nroDoc;
            set { nroDoc = value; }
        }

        public string Cuil
        {
            get => cuil;
            set { cuil = value; }
        }

        public string Calle
        {
            get => calle;
            set { calle = value; }
        }

        public int Nro
        {
            get => nro;
            set { nro = value; }
        }
        #endregion

        #region METODOS
        public DataTable MostrarPersonal()
        {
            string sSql = "SELECT * FROM Personal";
            clsEjecutarComando Ejecutar = new clsEjecutarComando();
            return Ejecutar.Ejecutar(sSql);
        }

        public void InsertarPersonal()
        {
            string sSql = $"INSERT INTO Personal (apellido, nombre, nroDoc, cuil, calle, nro) " +
                          $"VALUES ('{Apellido}', '{Nombre}', '{NroDoc}', '{Cuil}', '{Calle}', {Nro})";
            Console.WriteLine(sSql);
            clsEjecutarComando Ejecutar = new clsEjecutarComando();
            Ejecutar.Ejecutar(sSql);
        }

        public void ModificarPersonal()
        {
            string sSql = $"UPDATE Personal SET " +
                          $"apellido = '{Apellido}', nombre = '{Nombre}', nroDoc = '{NroDoc}', cuil = '{Cuil}', " +
                          $"calle = '{Calle}', nro = {Nro} WHERE idPersonal = {IdPersonal}";
            Console.WriteLine(sSql);
            clsEjecutarComando Ejecutar = new clsEjecutarComando();
            Ejecutar.Ejecutar(sSql);
        }

        public void EliminarPersonal()
        {
            string sSql = $"DELETE FROM Personal WHERE idPersonal = {IdPersonal}";
            clsEjecutarComando Ejecutar = new clsEjecutarComando();
            Ejecutar.Ejecutar(sSql);
        }
        #endregion

    }
}
