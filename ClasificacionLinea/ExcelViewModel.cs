using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasificacionLinea
{
    public class ExcelViewModel
    {
        public double puntos1EjeX1 { get; set; }
        public double puntos1EjeX2 { get; set; }
        public double puntos1ValorY { get; set; }
        public string puntos1Posicion { get; set; }
        public double puntos2EjeX1 { get; set; }
        public double puntos2EjeX2 { get; set; }
        public double puntos2ValorY { get; set; }
        public string puntos2Posicion { get; set; }
        public ExcelViewModel()
        {
            puntos1EjeX1 = 0;
            puntos1EjeX2 = 0;

            puntos1ValorY = 0;
            puntos1Posicion = "Desconocida";
            
            puntos2EjeX1 = 0;
            puntos2EjeX2 = 0;

            puntos2ValorY = 0;
            puntos2Posicion = "Desconocida";
        }
    }
}
