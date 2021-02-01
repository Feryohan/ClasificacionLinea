using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasificacionLinea
{
    class DatosPropiedades
    {
        #region Variables
        public string rutaArchivo { get; set; }
        public string nombreDatos { get; set; }
        public double[] datos1EjeX1 { get; set; }
        public double[] datos1EjeX2 { get; set; }
        public double[] datos2EjeX1 { get; set; }
        public double[] datos2EjeX2 { get; set; }

        public double[] datos1pendiente { get; set; }
        public double[] datos2pendiente { get; set; }

        public double minDatos1Pendiente { get; set; }
        public double minDatos2Pendiente { get; set; }
        public double maxDatos1Pendiente { get; set; }
        public double maxDatos2Pendiente { get; set; }
        public double minPendienteGlobal { get; set; }
        public double maxPendienteGlobal { get; set; }
        public double paso { get; set; }
        public double numeroErrores { get; set; }

        public double [] pendientes { get; set; }
        public double [] errores { get; set; }


        public double minGlobalX1 { get; set; }
        public double maxGlobalX1 { get; set; }
        public double minGlobalX2 { get; set; }
        public double maxGlobalX2 { get; set; }
        public double constanteW1 { get; set; }
        public double constanteW2 { get; set; }
        public double ordenada { get; set; }


        #endregion

        #region Constructor
        //Constructor
        public DatosPropiedades()
        {
            rutaArchivo = "";
            constanteW1 = 0;
            constanteW2 = 0;
            ordenada = 0;
            numeroErrores = 0;
        }
        #endregion
    }
}
