using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

//Libreria FuncionesEstadistica
namespace FuncionesEstadistica
{
    //Clase Matlab
    public class Matlab
    {
        #region Variables Globales 
        double media, varianza, destd, max, min;
        double pendiente, ordenada;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor vacío que creara un objeto sin atributos
        /// </summary>

        public Matlab()
        {
            this.media = 0;
            this.varianza = 4;
            this.destd = 2;
            this.pendiente = 0;
            this.ordenada = 0;
        }

        #endregion

        #region Métodos Públicos

        #endregion

        #region Métodos Privados

        #endregion

        #region Accesos

        #endregion

        #region SUMA
        //Método que calcula la suma de todos los elementos de un arreglo
        public static double Sum(double[] arreglo)
        {
            //El arreglo tiene que tener 2 o más elementos para hacer la suma
            if (arreglo.Length > 2)
            {
                double sum = arreglo[0];

                for (int i = 1; i <= arreglo.Length - 1; i++)
                {
                    sum = sum + arreglo[i];
                }

                return sum;
            }
            else
            {
                return 0;
            }
        }
        #endregion

        #region PROMEDIO
        //Método que calcula el promedio de los elementos de un arreglo
        public static double Mean(double[] arreglo)
        {
            //El promedio solo se calcula si el arreglo tiene más de 2 elementos
            if (arreglo.Length > 2)
            {
                double media = Convert.ToDouble(Sum(arreglo)) / arreglo.Length;

                return media;
            }
            else
            {
                return 0;
            }
        }
        #endregion

        #region MINIMO
        //Método que calcula el mínimo valor 
        public static double Min (double[] arreglo)
        {
            if (arreglo.Length > 2)
            {
                double min = arreglo[0];

                for(int i = 0; i<arreglo.Length; i++)
                {
                    if(min > arreglo[i])
                    {
                        min = arreglo[i];
                    }
                }

                return min;

            }
            else
            {
                return 0;
            }
        }
        #endregion

        #region MAXIMO
        //Método que calcula el mínimo valor 
        public static double Max(double[] arreglo)
        {
            if (arreglo.Length > 2)
            {
                double max = arreglo[0];

                for (int i = 0; i < arreglo.Length ; i++)
                {
                    if (max < arreglo[i])
                    {
                        max = arreglo[i];
                    }
                }

                return max;

            }
            else
            {
                return 0;
            }
        }
        #endregion

        #region Varianza Poblacion
        //Método que calcula la varianza en función de toda la población
        public static double VarP(double[] arreglo)
        {
            if (arreglo.Length > 2)
            {
                double varp;
                double promedio = Matlab.Mean(arreglo);
                double suma = 0;
                double desviacion;
                for (int i = 0; i <= arreglo.Length - 1; i++)
                {
                    desviacion = Math.Pow(arreglo[i] - promedio, 2);
                    suma = suma + desviacion;
                }

                varp = suma / arreglo.Length;

                return varp;
            }
            else
            {
                return 0;
            }
        }
        #endregion

        #region Desviación Estandar Población
        //Metodo que calcula la desviación estandar de una población
        public static double StdP(double[] arreglo)
        {
            if (arreglo.Length > 2)
            {
                double stdp = Math.Sqrt(VarP(arreglo));
                return stdp;
            }
            else
            {
                return 0;
            }
        }
        #endregion

        #region Varianza Muestra
        //Método que calcula la varianza en función de una muestra
        public static double VarM(double[] arreglo)
        {
            if (arreglo.Length > 2)
            {
                double varm;
                double promedio = Matlab.Mean(arreglo);
                double suma = 0;
                double desviacion;
                for (int i = 0; i <= arreglo.Length - 1; i++)
                {
                    desviacion = Math.Pow(arreglo[i] - promedio, 2);
                    suma = suma + desviacion;
                }

                varm = suma / (arreglo.Length - 1);

                return varm;
            }
            else
            {
                return 0;
            }
        }
        #endregion

        #region Desviación Estandar Muestra
        //Metodo que calcula la desviación estandar de una población
        public static double StdM(double[] arreglo)
        {
            if (arreglo.Length > 2)
            {
                double stdm = Math.Sqrt(VarM(arreglo));
                return stdm;
            }
            else
            {
                return 0;
            }
        }
        #endregion

        #region Linspace
        //Método que obtiene la lista del eje X para la función de densidad
        public static List<double> Linspace(double min, double max, double paso)
        {
            List<double> lstLinspace = new List<double>();
            double punto = 0;
            int posicion = 0;
            while (punto <= max-paso)
            {
                punto = min + (paso * posicion);
                posicion++;
                lstLinspace.Add(punto);
            }
            //La lista lstLinspace se regresa
            //En el código del programa la lista se tiene que convertir en un arreglo
            return lstLinspace;
        }
        #endregion

        #region Normpdf
        //Método que obtiene el arreglo de la función de densidad, a partir de los valores de Linspace obtenidos
        public static double[] Normpdf(double[] arregloEjeX, double media, double desviacionE)
        {
            //Ambos arreglos tienen la misma longitud
            double[] normpdf = new double[arregloEjeX.Length];
            double exponente;
            double varianza = Math.Pow(desviacionE, 2);
            for (int i = 0; i <= arregloEjeX.Length - 1; i++)
            {
                //Formula de función de densidad
                exponente = (-1) * (Math.Pow((arregloEjeX[i] - media), 2) / (2 * varianza));
                normpdf[i] = (Math.Pow(Math.E, exponente)) / (desviacionE * Math.Sqrt(2 * Math.PI));
            }
            return normpdf;
        }
        #endregion

        #region RectanZ
        //Calcula el área bajo la curva dividiendola en rectangulos
        public static double RectanZ(double[] arregloEjeX, double[] funcionDensidad, double valorA, double valorB, double paso)
        {
            //Buscando la posición de A y B
            double valor = 0;
            int posicionA = 0;
            int posicionB = 0;

            for(int i = 0; i<=arregloEjeX.Length-1; i++)
            { 
                valor = arregloEjeX[i];
                if(valor == valorA)
                {
                    posicionA = i;
                }
                if(valor == valorB)
                {
                    posicionB = i;
                }
            }
             //Obteniendo las áreas de los rectangulos
            double suma = 0;
            for(int i=posicionA; i<= posicionB; i++)
            {
                suma = suma + funcionDensidad[i];
            }

            double probabilidadRectanZ = suma*paso;

            return probabilidadRectanZ;
        }
        #endregion

        #region TrapZ
        //Calcula el área bajo la curva diviendola en trapecios
        public static double Trapz(double[] arregloEjeX, double[] funcionDensidad, double valorA, double valorB, double paso)
        {
            //Buscando la posición de A y B
            double valor = 0;
            int posicionA = 0;
            int posicionB = 0;

            for (int i = 0; i <= arregloEjeX.Length - 1; i++)
            {
                valor = arregloEjeX[i];
                if (valor == valorA)
                {
                    posicionA = i;
                }
                if (valor == valorB)
                {
                    posicionB = i;
                }
            }

            //Utilizando la formula TrapZ de Matlab

            //Suma de f(x1) + 2f(x2) + ... + 2f(xN) + f(xN+1)
            double suma = funcionDensidad[posicionA] + funcionDensidad[posicionB];
            for(int i = 1; i < posicionB; i++)
            {
                suma = suma + (2 * funcionDensidad[posicionA + i]);
            }
            
            //Probabilidad: Multiplicando (b-a/2N) por la suma
            double probabilidadTrapZ = (paso/2) * (suma);

            return probabilidadTrapZ;
        }
        #endregion

        #region Regresión lineal
        public static double Pendiente(double [] ejeX, double [] ejeY)
        {
            double pendiente;
            int n = ejeX.Length;
            double[] XporY = new double[n];
            double[] Xcuadrada = new double[n];
            double sumaXporY = 0;
            double sumaX = 0;
            double sumaY = 0;
            double sumaXcuadrada = 0;
            for(int i = 0; i<n; i++)
            {
                //Arreglos
                XporY[i] = ejeX[i] * ejeY[i];
                Xcuadrada[i] = Math.Pow(ejeX[i], 2);
                //Sumas
                sumaXporY = sumaXporY + XporY[i];
                sumaX = sumaX + ejeX[i];
                sumaY = sumaY + ejeY[i];
                sumaXcuadrada = sumaXcuadrada + Xcuadrada[i];
            }

            pendiente = ((n * sumaXporY) - (sumaX * sumaY)) / ((n * sumaXcuadrada) - Math.Pow(Math.Abs(sumaX), 2));

            return pendiente;
        }

        public static double Ordenada(double[] ejeX, double[] ejeY)
        {
            double ordenada;
            int n = ejeX.Length;
            double[] XporY = new double[n];
            double[] Xcuadrada = new double[n];
            double sumaXporY = 0;
            double sumaX = 0;
            double sumaY = 0;
            double sumaXcuadrada = 0;
            for (int i = 0; i < n; i++)
            {
                //Arreglos
                XporY[i] = ejeX[i] * ejeY[i];
                Xcuadrada[i] = Math.Pow(ejeX[i], 2);
                //Sumas
                sumaXporY = sumaXporY + XporY[i];
                sumaX = sumaX + ejeX[i];
                sumaY = sumaY + ejeY[i];
                sumaXcuadrada = sumaXcuadrada + Xcuadrada[i];
            }

            ordenada = ((sumaY*sumaXcuadrada)-(sumaX*sumaXporY)) / ((n*sumaXcuadrada)-(Math.Pow(Math.Abs(sumaX),2)));

            return ordenada;
        }

        public static double[] RegresionLineal(double[] ejeX, double pendiente, double ordenada)
        {
            double[] regresionLineal = new double[ejeX.Length];
            for(int i=0; i<ejeX.Length; i++)
            {
                regresionLineal[i] = (pendiente * ejeX[i]) + ordenada;
            }
            return regresionLineal;
        }
        #endregion

    }
}
