using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Libreria para el chart
using System.Windows.Forms.DataVisualization.Charting;

namespace ClasificacionLinea
{
    public partial class FormGraficaError : Form
    {
        //Atributos
        double[] pendientes;
        double[] errores;
        double paso;

        public FormGraficaError(double[] pendientes, double[] errores, double paso)
        {
            InitializeComponent();
            this.pendientes = pendientes;
            this.errores = errores;
            this.paso = paso;
        }

        #region Gráfica
        //Construcción de la gráfica
        public void Grafica(double[] datosEjeX, double[] datosEjeY, string nombreSerie, string tipo, string color)
        {
            //El área de los rectángulos es cero
            var chart = chart1.ChartAreas[0];
            chart.AxisX.IntervalType = DateTimeIntervalType.Number;
            //Se pone nulo para que el numeros aparézcan en los ejes
            chart.AxisX.LabelStyle.Format = "";
            chart.AxisY.LabelStyle.Format = "";

            chart.AxisY.LabelStyle.IsEndLabelVisible = true;

            //Medidas del gráfico
            chart.AxisX.Minimum = datosEjeX[0];
            chart.AxisX.Maximum = datosEjeX[datosEjeX.Length-1];
            chart.AxisX.Interval = paso*5;

            chart.AxisY.Minimum = datosEjeY[0];
            chart.AxisY.Maximum = datosEjeY[datosEjeY.Length-1];
            chart.AxisY.Interval = 1;

            //Diseño de la gráfica
            chart1.Series.Add(nombreSerie);
            if (tipo == "punto")
            {
                if (color == "azul")
                {
                    chart1.Series[nombreSerie].ChartType = SeriesChartType.Point;
                    chart1.Series[nombreSerie].Color = Color.Blue;
                }
                if (color == "naranja")
                {
                    chart1.Series[nombreSerie].ChartType = SeriesChartType.Point;
                    chart1.Series[nombreSerie].Color = Color.OrangeRed;
                }
            }
            else
            {
                chart1.Series[nombreSerie].ChartType = SeriesChartType.Line;
                chart1.Series[nombreSerie].Color = Color.Red;
            }
            chart1.Series[nombreSerie].IsVisibleInLegend = false;

            //Imprimiendo los puntos de la gráfica
            for (int i = 0; i <= datosEjeX.Length - 1; i++)
            {
                chart1.Series[nombreSerie].Points.AddXY(datosEjeX[i], datosEjeY[i]);
            }
        }
        #endregion

        private void FormGraficaError_Load(object sender, EventArgs e)
        {
            Grafica(pendientes, errores, "Errores", "linea", "rojo");
        }
    }
}
