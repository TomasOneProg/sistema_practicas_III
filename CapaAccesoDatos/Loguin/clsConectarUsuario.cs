﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using CapaComun;

namespace CapaAccesoDatos
{
    public class clsConectarUsuario : CD_Conexion
    {
        public bool Login(string user, string pass)
        {
            string sSql = "SELECT * FROM Usuarios " +
               "WHERE Usuarios.usuario = '" + user + "' AND Usuarios.password = '" + pass + "'";
            // and Usuarios.UsuarioDesactivado=false
            DataTable DT = new DataTable();
            clsEjecutarComando Ejecutar = new clsEjecutarComando();
            DT = Ejecutar.Ejecutar(sSql);

            if (DT.Rows.Count > 0)
            {
                foreach (DataRow row in DT.Rows)
                {
                    Console.WriteLine(row.ToString());
                    UserCache.IdUsuario = Convert.ToInt32(row[0].ToString());
                    UserCache.Usuario = row[1].ToString();
                    UserCache.Password = row[2].ToString();
                    UserCache.IdPersona = Convert.ToInt32(row[3].ToString());
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        // --------------------------------------------------------------------
        public bool UserVerific(string user)
        {
            //Verifica si el usuario existe extrayendo 
            string sSql = "SELECT * FROM Usuarios " +
                "WHERE Usuarios.usuario= '" + user +"'";
            DataTable DT2 = new DataTable();
            clsEjecutarComando Ejecutar = new clsEjecutarComando();
            DT2 = Ejecutar.Ejecutar(sSql);
            if (DT2.Rows.Count > 0)
            {
                foreach (DataRow row2 in DT2.Rows)
                {
                    VerificCache.IdUsuario = Convert.ToInt32(row2[0].ToString());
                    VerificCache.Usuario = row2[1].ToString();
                    VerificCache.Apellido = row2[3].ToString();
                    VerificCache.Nombres = row2[4].ToString();
                }
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
