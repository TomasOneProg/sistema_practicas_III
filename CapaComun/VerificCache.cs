using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CapaComun
{
    public static class clsVerificCache
    {
        public static List<ElementVerificCache> ListVerifCache = new List<ElementVerificCache>();
    }


    #region ATRUBUTOS - ElementVerificCache
    public class ElementVerificCache
    {
        public int IdUsuario { get; set; }
        public string Usuario { get; set; }
        public int intentos { get; set; }
    }

    #endregion

    #region ATRUBUTOS - VerificCache
    public static class VerificCache
    {
        public static int IdUsuario { get; set; }
        public static string Usuario { get; set; }
        public static string Apellido { get; set; }
        public static string Nombres { get; set; }
    }
    #endregion
}
