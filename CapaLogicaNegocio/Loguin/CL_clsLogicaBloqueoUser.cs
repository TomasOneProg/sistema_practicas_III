using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaComun;
using CapaAccesoDatos;
using CapaAccesoDatos.Loguin;

namespace CapaLogicaNegocio.Loguin
{
    public class CL_clsLogicaBloqueoUser
    {
        CD_BloqueoUser bloqueo = new CD_BloqueoUser();

        public string BlokUser(string User)
        {
            // ----------------------------------
  
            bool encontrado = false;
            int lista = clsVerificCache.ListVerifCache.Count;
            string result = "";
            
            for (int i = 0; i < lista; i++)
                {
                    if (clsVerificCache.ListVerifCache[i].Usuario.Contains(User))
                    {
                        encontrado = true;
                        clsVerificCache.ListVerifCache[i].intentos++; //suma 1
                        result = "Contraseña Erronea";

                        if(clsVerificCache.ListVerifCache[i].intentos == 3)
                        {
                            //Bloquear usuario [Usuario.UsuarioDesactivado = true]
                            bloqueo.BloquearUser(User);
                            //Registra Bloqueo en Bitacora
                            CL_clsBitacora Guardar = new CL_clsBitacora("Ingreso al Sistema", "Usuario Bloqueado", "frmLoguin");
                            // Mensaje de Usuario bloqueado
                            result = "Intentos excedido, El usuario se encuentra bloqueado";
                        }
                    
                    
                    }
                }
                
                if (encontrado == false)
                {
                    clsVerificCache.ListVerifCache.Add(new ElementVerificCache()
                    {
                        Usuario = User,
                        intentos = 1
                    });
                result = "Contraseña Erronea";
                // Mensaje de Inicio erroneo


                
            }
            return result;
            // --------------------------------------
        }



    }


    public class clsUser
    {
        public string User { get; set; }
    }

    
}
        
        