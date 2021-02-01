using SpreadsheetLight;
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
    public partial class Form1 : Form
    {
        #region Apuntadores
        //Apuntador
        DatosPropiedades Archivo1 = new DatosPropiedades();
        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        #region ListGridView
        //Método que muestra una tabla con los datos importados de Excel
        public void ListGridView(string rutaArchivo)
        {
            //Creando nuevo objeto SLDocument que recibe el path donde se encuentra el Excel
            SLDocument sl = new SLDocument(rutaArchivo);

            //Los arreglos comienzan en cero
            //Las filas comienzan en uno

            //El indice, para la fila, empieza en el dos
            int iRow = 3;

            //Creación de la lista para mostrar la tabla de datos Excel
            List<ExcelViewModel> lstExcelDatos = new List<ExcelViewModel>();

            //El ciclo while se aplica hasta que no se encuentre un registro vacío
            //fila/columna
            while (!string.IsNullOrEmpty(sl.GetCellValueAsString(iRow, 1)))
            {
                //Creación del apuntador
                ExcelViewModel apuntadorExcel = new ExcelViewModel();
                apuntadorExcel.puntos1EjeX1 = sl.GetCellValueAsDouble(iRow, 1);
                apuntadorExcel.puntos1EjeX2 = sl.GetCellValueAsDouble(iRow, 2);

                //Obtiene el valor para x1w1 + x2w2 + b 
                apuntadorExcel.puntos1ValorY = (Archivo1.constanteW1 * apuntadorExcel.puntos1EjeX1) + (Archivo1.constanteW2 * apuntadorExcel.puntos1EjeX2) + Archivo1.ordenada;
                
                //Determina si el punto de VALORES 1 se encuentra por arriba o por debajo de la recta
                if(Archivo1.constanteW1 != 0)
                {
                    if(Math.Round(apuntadorExcel.puntos1ValorY,2) < 0)
                    {
                        apuntadorExcel.puntos1Posicion = "Arriba";
                    }
                    if(Math.Round(apuntadorExcel.puntos1ValorY,2) > 0)
                    {
                        apuntadorExcel.puntos1Posicion = "Abajo";
                        Archivo1.numeroErrores = Archivo1.numeroErrores + 1;
                    }
                    if (Math.Round(apuntadorExcel.puntos1ValorY, 2) == 0)
                    {
                        apuntadorExcel.puntos1Posicion = "En línea";
                    }
                }

                apuntadorExcel.puntos2EjeX1 = sl.GetCellValueAsDouble(iRow, 3);
                apuntadorExcel.puntos2EjeX2 = sl.GetCellValueAsDouble(iRow, 4);
                
                apuntadorExcel.puntos2ValorY = (Archivo1.constanteW1 * apuntadorExcel.puntos2EjeX1) + (Archivo1.constanteW2 * apuntadorExcel.puntos2EjeX2) + Archivo1.ordenada;

                //Determina si el punto de VALORES 2 se encuentra por arriba o por debajo de la recta
                if (Archivo1.constanteW1 != 0)
                {
                    if (Math.Round(apuntadorExcel.puntos2ValorY, 2) < 0)
                    {
                        apuntadorExcel.puntos2Posicion = "Arriba";
                        Archivo1.numeroErrores = Archivo1.numeroErrores + 1;
                    }
                    if (Math.Round(apuntadorExcel.puntos2ValorY, 2) > 0)
                    {
                        apuntadorExcel.puntos2Posicion = "Abajo";
                    }
                    if (Math.Round(apuntadorExcel.puntos2ValorY, 2) == 0)
                    {
                        apuntadorExcel.puntos2Posicion = "En línea";
                    }
                }

                //Se añaden a la lista los datos del Excel
                lstExcelDatos.Add(apuntadorExcel);

                iRow++;
            }
            //Haciendo que la lista aparezca en la pantalla
            dataGridView1.DataSource = lstExcelDatos;
        }
        #endregion

        #region LecturaExcel
        //Método que lee los datos del archivo de Excel y los guarda en una lista
        public static List<double> LecturaExcel(string rutaArchivo, int columna)
        {
            //Creando nuevo objeto SLDocument que recibe el path donde se encuentra el Excel
            SLDocument sl = new SLDocument(rutaArchivo);

            //Los arreglos comienzan en cero
            //Las filas comienzan en uno

            //El indice, para la fila, empieza en el dos
            int iRow = 3;

            //Creación de la lista para leer los datos
            List<double> lstLecturaExcel = new List<double>();

            //El ciclo while se aplica hasta que no se encuentre un registro vacío
            //fila/columna
            while (!string.IsNullOrEmpty(sl.GetCellValueAsString(iRow, columna)))
            {
                lstLecturaExcel.Add(sl.GetCellValueAsDouble(iRow, columna));

                iRow++;
            }

            return lstLecturaExcel;

        }
        #endregion

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
            chart.AxisX.Minimum = 0;
            chart.AxisX.Maximum = Archivo1.maxGlobalX1; ; 
            chart.AxisX.Interval = 0.5;

            chart.AxisY.Minimum = 0; 
            chart.AxisY.Maximum = Archivo1.maxGlobalX2; 
            chart.AxisY.Interval = 0.5;

            //Diseño de la gráfica
            chart1.Series.Add(nombreSerie);
            if (tipo == "punto")
            {
                if(color == "azul"){
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

        #region Botón: Importar Documento
        private void bttnImportarDoc_Click(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            Archivo1.rutaArchivo = string.Empty;
            Archivo1.nombreDatos = "Datos Dispersos";

            //OpenFileDialog permite abrir el buscador de archivos
            OpenFileDialog openFileDialog = new OpenFileDialog();

            //Si el usuario sí abre un archivo, el if se ejecuta
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Archivo1.rutaArchivo = openFileDialog.FileName;
                ListGridView(Archivo1.rutaArchivo);

                //Método para obtener el nombre del archivo
                string[] nombre = Archivo1.rutaArchivo.Split('\\', '.');
                Archivo1.nombreDatos = nombre[nombre.Length - 2];

                //Obtiendo los valores de X1 y X2 
                Archivo1.datos1EjeX1 = LecturaExcel(Archivo1.rutaArchivo, 1).ToArray();
                Archivo1.datos1EjeX2 = LecturaExcel(Archivo1.rutaArchivo, 2).ToArray();
                Archivo1.datos2EjeX1 = LecturaExcel(Archivo1.rutaArchivo, 3).ToArray();
                Archivo1.datos2EjeX2 = LecturaExcel(Archivo1.rutaArchivo, 4).ToArray();

                #region Valores mínimos y máximos de x1 y x2
                //Determinando el mínimo valor de x1
                if (FuncionesEstadistica.Matlab.Min(Archivo1.datos1EjeX1) < FuncionesEstadistica.Matlab.Min(Archivo1.datos2EjeX1)){
                    Archivo1.minGlobalX1 = FuncionesEstadistica.Matlab.Min(Archivo1.datos1EjeX1);
                }
                else
                {
                    Archivo1.minGlobalX1 = FuncionesEstadistica.Matlab.Min(Archivo1.datos2EjeX1);
                }
                //Determinando el máximo valor de x1
                if (FuncionesEstadistica.Matlab.Max(Archivo1.datos1EjeX1) > FuncionesEstadistica.Matlab.Max(Archivo1.datos2EjeX1))
                {
                    Archivo1.maxGlobalX1 = FuncionesEstadistica.Matlab.Max(Archivo1.datos1EjeX1);
                }
                else
                {
                    Archivo1.maxGlobalX1 = FuncionesEstadistica.Matlab.Max(Archivo1.datos2EjeX1);
                }
                //Determinando el mínimo valor de x2
                if (FuncionesEstadistica.Matlab.Min(Archivo1.datos1EjeX2) < FuncionesEstadistica.Matlab.Min(Archivo1.datos2EjeX2))
                {
                    Archivo1.minGlobalX2 = FuncionesEstadistica.Matlab.Min(Archivo1.datos1EjeX2);
                }
                else
                {
                    Archivo1.minGlobalX2 = FuncionesEstadistica.Matlab.Min(Archivo1.datos2EjeX2);
                }
                //Determinando el máximo valor de x2
                if (FuncionesEstadistica.Matlab.Max(Archivo1.datos1EjeX2) > FuncionesEstadistica.Matlab.Max(Archivo1.datos2EjeX2))
                {
                    Archivo1.maxGlobalX2 = FuncionesEstadistica.Matlab.Max(Archivo1.datos1EjeX2);
                }
                else
                {
                    Archivo1.maxGlobalX2 = FuncionesEstadistica.Matlab.Max(Archivo1.datos2EjeX2);
                }
                #endregion

                //Graficando datos1
                Grafica(Archivo1.datos1EjeX1, Archivo1.datos1EjeX2, "Datos1", "punto", "azul");
                //Graficando datos2
                Grafica(Archivo1.datos2EjeX1, Archivo1.datos2EjeX2, "Datos2", "punto", "naranja");
            }
            txtBoxDoc.Text = Archivo1.nombreDatos;
        }
        #endregion

        #region Botón: Establecer
        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            Archivo1.constanteW1 = Convert.ToDouble(txtBoxW1.Text);
            Archivo1.constanteW2 = Convert.ToDouble(txtBoxW2.Text);
            Archivo1.ordenada = Convert.ToDouble(txtBoxb.Text);

            double[] datosEjeX = new double[8];
            double[] datosEjeY = new double[8];

            datosEjeX[0] = 0;
            datosEjeY[0] = 0;
            for (int i = 1; i<datosEjeX.Length; i++)
            {
                datosEjeX[i] = 0.1 * i;
                datosEjeY[i] = ((Archivo1.constanteW1 * datosEjeX[i]) + Archivo1.ordenada) / (-1*Archivo1.constanteW2);
            }

            //Graficando datos1
            Grafica(Archivo1.datos1EjeX1, Archivo1.datos1EjeX2, "Datos1", "punto", "azul");
            //Graficando datos2
            Grafica(Archivo1.datos2EjeX1, Archivo1.datos2EjeX2, "Datos2", "punto", "naranja");
            //Graficando recta
            Grafica(datosEjeX, datosEjeY, "Linea", "linea", "rojo");
            ListGridView(Archivo1.rutaArchivo);
        }

        #endregion

        #region Botón: Barrido
        private void bttnBarrido_Click(object sender, EventArgs e)
        {
            Archivo1.paso = Convert.ToDouble(txtBoxPaso.Text);

            #region Determinando el rango de la pendiente
            Archivo1.datos1pendiente = new double[Archivo1.datos1EjeX1.Length];
            Archivo1.datos2pendiente = new double[Archivo1.datos2EjeX1.Length];
            //Obteniendo las pendientes de cada punto de datos1
            for (int i = 0; i < Archivo1.datos1pendiente.Length - 1; i++)
            {
                Archivo1.datos1pendiente[i] = (Archivo1.datos1EjeX2[i] - Archivo1.ordenada) / Archivo1.datos1EjeX1[i];
            }
            //Obteniendo las pendientes de cada punto de datos2
            for (int i = 0; i < Archivo1.datos2pendiente.Length - 1; i++)
            {
                Archivo1.datos2pendiente[i] = (Archivo1.datos2EjeX2[i] - Archivo1.ordenada) / Archivo1.datos2EjeX1[i];
            }

            Archivo1.minDatos1Pendiente = FuncionesEstadistica.Matlab.Min(Archivo1.datos1pendiente);
            Archivo1.minDatos2Pendiente = FuncionesEstadistica.Matlab.Min(Archivo1.datos2pendiente);
            Archivo1.maxDatos1Pendiente = FuncionesEstadistica.Matlab.Max(Archivo1.datos1pendiente);
            Archivo1.maxDatos2Pendiente = FuncionesEstadistica.Matlab.Max(Archivo1.datos2pendiente);

            double punto = FuncionesEstadistica.Matlab.Max(Archivo1.datos2pendiente);

            if (Archivo1.minDatos1Pendiente < Archivo1.minDatos2Pendiente)
            {
                Archivo1.minPendienteGlobal = Math.Round(Archivo1.minDatos1Pendiente,2);
            }
            else
            {
                Archivo1.minPendienteGlobal = Math.Round(Archivo1.minDatos2Pendiente,2);
            }

            if (Archivo1.maxDatos1Pendiente > Archivo1.maxDatos2Pendiente)
            {
                Archivo1.maxPendienteGlobal = Math.Round(Archivo1.maxDatos1Pendiente,2);
            }
            else
            {
                Archivo1.maxPendienteGlobal = Math.Round(Archivo1.maxDatos2Pendiente,2);
            }
            #endregion

            labelPendienteMin.Text = Convert.ToString(Archivo1.minPendienteGlobal);
            labelPendienteMax.Text = Convert.ToString(Archivo1.maxPendienteGlobal);

            Archivo1.constanteW1 = Archivo1.minPendienteGlobal;

            List<double> pendientes = new List<double>();
            List<double> errores = new List<double>();

            while (Archivo1.constanteW1 < Archivo1.maxPendienteGlobal+Archivo1.paso)
            {
                chart1.Series.Clear();
                Archivo1.numeroErrores = 0;

                double[] datosEjeX = new double[8];
                double[] datosEjeY = new double[8];

                datosEjeX[0] = 0;
                datosEjeY[0] = 0;
                for (int i = 1; i < datosEjeX.Length; i++)
                {
                    datosEjeX[i] = 0.1 * i;
                    datosEjeY[i] = ((Archivo1.constanteW1 * datosEjeX[i]) + Archivo1.ordenada) / (-1 * Archivo1.constanteW2);
                }

                //Graficando datos1
                Grafica(Archivo1.datos1EjeX1, Archivo1.datos1EjeX2, "Datos1", "punto", "azul");
                //Graficando datos2
                Grafica(Archivo1.datos2EjeX1, Archivo1.datos2EjeX2, "Datos2", "punto", "naranja");
                //Graficando recta
                Grafica(datosEjeX, datosEjeY, "Linea", "linea", "rojo");
                ListGridView(Archivo1.rutaArchivo);

                pendientes.Add(Archivo1.constanteW1);
                errores.Add(Archivo1.numeroErrores);
                labelNumeroErrores.Text = Convert.ToString(Archivo1.numeroErrores);

                Archivo1.constanteW1 = Archivo1.constanteW1 + Archivo1.paso;
                
            }

            Archivo1.pendientes = pendientes.ToArray();
            Archivo1.errores = errores.ToArray();
        }
        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void bttnGraficaError_Click(object sender, EventArgs e)
        {
            FormGraficaError formGraficaError = new FormGraficaError(Archivo1.pendientes, Archivo1.errores, Archivo1.paso);
            formGraficaError.Show();
        }
    }
}
