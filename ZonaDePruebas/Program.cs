using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ZonaDePruebas
{
    class Program
    {
        static void Main(string[] args)
        {
            //Dirección del documento de Excel
            string path;
            path = @"C:\Users\SERGIO ROMO\Documents\Semestre 2021-1\Temas Selectos de Programación\ClasificacionLinea\Documetos de Excel\Linea1.xlsx";

            //Libreria SpreadsheetLight version 3.4.9 instalada desde el NuGet
            //DocumentFormat.OpenXml version 2.5.0 instalada desde el NuGet
            SLDocument sl = new SLDocument(path);

            //Los arreglos comienzan en cero
            //Las filas comienzan en uno

            //El indice, para la fila, empieza en el dos
            int iRow = 3;

            //Creación del arreglo 
            double[] datos1EjeX1 = new double[50];
            double[] datos1EjeX2 = new double[50];
            double[] datos2EjeX1 = new double[50];
            double[] datos2EjeX2 = new double[50];

            //El ciclo while se aplica hasta que no se encuentre un registro vacío
            //fila/columna
            while (!string.IsNullOrEmpty(sl.GetCellValueAsString(iRow, 2)))
            {
                //Se añade al arreglo
                datos1EjeX1[iRow - 3] = sl.GetCellValueAsDouble(iRow, 1);
                datos1EjeX2[iRow - 3] = sl.GetCellValueAsDouble(iRow, 2);
                datos2EjeX1[iRow - 3] = sl.GetCellValueAsDouble(iRow, 3);
                datos2EjeX2[iRow - 3] = sl.GetCellValueAsDouble(iRow, 4);

                //Se muestra en pantalla
                Console.WriteLine("Datos eje X: " + datos1EjeX1[iRow - 3]);
                Console.WriteLine("Datos eje Y: " + datos1EjeX2[iRow - 3]);

                iRow++;
            }

            Console.ReadLine();
        }
    }
}
