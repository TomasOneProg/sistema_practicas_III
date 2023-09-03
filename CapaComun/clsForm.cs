using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace CapaComun
{
    /* 
     Declaracion de cierre de formulario por método y parámeto
    */
    public class clsForm 
    {
        public void clsFormClose(string lugar, string form)
        {

            // ------------------------------------
            //pregunto si desea cerrar, dando la opción de cancelar la operación
            /*
            form.DialogResult resultado = MessageBox.Show("Esta seguro de SALIR de "+ lugar +"?",
                                "FINALIZAR SISTEMA",
                                MessageBoxButtons.OKCancel,
                                MessageBoxIcon.Asterisk,
                                MessageBoxDefaultButton.Button2);

            if (resultado != DialogResult.Cancel)
                {
                    //Application.Exit(); //Cierre del formulario
                    //e.Cancel = true; //Cancela el cierre del formulario
                    form.Close();
                }
            */




            // ------------------------------------
        }

    }
}
