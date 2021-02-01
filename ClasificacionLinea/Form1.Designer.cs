namespace ClasificacionLinea
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtBoxDoc = new System.Windows.Forms.TextBox();
            this.bttnImportarDoc = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button1 = new System.Windows.Forms.Button();
            this.txtBoxW1 = new System.Windows.Forms.TextBox();
            this.txtBoxW2 = new System.Windows.Forms.TextBox();
            this.txtBoxb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.bttnBarrido = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBoxPaso = new System.Windows.Forms.TextBox();
            this.labelPendienteMax = new System.Windows.Forms.Label();
            this.labelPendienteMin = new System.Windows.Forms.Label();
            this.labelNumeroErrores = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.bttnGraficaError = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(29, 113);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1149, 203);
            this.dataGridView1.TabIndex = 0;
            // 
            // txtBoxDoc
            // 
            this.txtBoxDoc.Location = new System.Drawing.Point(29, 38);
            this.txtBoxDoc.Name = "txtBoxDoc";
            this.txtBoxDoc.Size = new System.Drawing.Size(201, 20);
            this.txtBoxDoc.TabIndex = 1;
            // 
            // bttnImportarDoc
            // 
            this.bttnImportarDoc.Location = new System.Drawing.Point(261, 26);
            this.bttnImportarDoc.Name = "bttnImportarDoc";
            this.bttnImportarDoc.Size = new System.Drawing.Size(98, 43);
            this.bttnImportarDoc.TabIndex = 2;
            this.bttnImportarDoc.Text = "Importar Documento";
            this.bttnImportarDoc.UseVisualStyleBackColor = true;
            this.bttnImportarDoc.Click += new System.EventHandler(this.bttnImportarDoc_Click);
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(29, 357);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(795, 247);
            this.chart1.TabIndex = 3;
            this.chart1.Text = "chart1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(582, 69);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Establecer";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtBoxW1
            // 
            this.txtBoxW1.Location = new System.Drawing.Point(460, 25);
            this.txtBoxW1.Name = "txtBoxW1";
            this.txtBoxW1.Size = new System.Drawing.Size(100, 20);
            this.txtBoxW1.TabIndex = 6;
            // 
            // txtBoxW2
            // 
            this.txtBoxW2.Location = new System.Drawing.Point(460, 71);
            this.txtBoxW2.Name = "txtBoxW2";
            this.txtBoxW2.Size = new System.Drawing.Size(100, 20);
            this.txtBoxW2.TabIndex = 7;
            // 
            // txtBoxb
            // 
            this.txtBoxb.Location = new System.Drawing.Point(582, 25);
            this.txtBoxb.Name = "txtBoxb";
            this.txtBoxb.Size = new System.Drawing.Size(100, 20);
            this.txtBoxb.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(457, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Constante W1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(457, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Constante W2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(579, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Ordenada al origen b";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(579, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(169, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Usar una coma para los decimales";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(773, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "w1x1 + w2x2 + b = 0";
            // 
            // bttnBarrido
            // 
            this.bttnBarrido.Location = new System.Drawing.Point(894, 72);
            this.bttnBarrido.Name = "bttnBarrido";
            this.bttnBarrido.Size = new System.Drawing.Size(75, 23);
            this.bttnBarrido.TabIndex = 11;
            this.bttnBarrido.Text = "Barrido";
            this.bttnBarrido.UseVisualStyleBackColor = true;
            this.bttnBarrido.Click += new System.EventHandler(this.bttnBarrido_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(773, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Paso";
            // 
            // txtBoxPaso
            // 
            this.txtBoxPaso.Location = new System.Drawing.Point(776, 74);
            this.txtBoxPaso.Name = "txtBoxPaso";
            this.txtBoxPaso.Size = new System.Drawing.Size(100, 20);
            this.txtBoxPaso.TabIndex = 13;
            // 
            // labelPendienteMax
            // 
            this.labelPendienteMax.AutoSize = true;
            this.labelPendienteMax.Location = new System.Drawing.Point(985, 38);
            this.labelPendienteMax.Name = "labelPendienteMax";
            this.labelPendienteMax.Size = new System.Drawing.Size(93, 13);
            this.labelPendienteMax.TabIndex = 10;
            this.labelPendienteMax.Text = "Pendiente maxima";
            // 
            // labelPendienteMin
            // 
            this.labelPendienteMin.AutoSize = true;
            this.labelPendienteMin.Location = new System.Drawing.Point(985, 9);
            this.labelPendienteMin.Name = "labelPendienteMin";
            this.labelPendienteMin.Size = new System.Drawing.Size(90, 13);
            this.labelPendienteMin.TabIndex = 10;
            this.labelPendienteMin.Text = "Pendiente minima";
            // 
            // labelNumeroErrores
            // 
            this.labelNumeroErrores.AutoSize = true;
            this.labelNumeroErrores.Location = new System.Drawing.Point(985, 69);
            this.labelNumeroErrores.Name = "labelNumeroErrores";
            this.labelNumeroErrores.Size = new System.Drawing.Size(92, 13);
            this.labelNumeroErrores.TabIndex = 10;
            this.labelNumeroErrores.Text = "numero de errores";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            // 
            // bttnGraficaError
            // 
            this.bttnGraficaError.Location = new System.Drawing.Point(1103, 38);
            this.bttnGraficaError.Name = "bttnGraficaError";
            this.bttnGraficaError.Size = new System.Drawing.Size(99, 44);
            this.bttnGraficaError.TabIndex = 14;
            this.bttnGraficaError.Text = "Ver Gráfica de Error";
            this.bttnGraficaError.UseVisualStyleBackColor = true;
            this.bttnGraficaError.Click += new System.EventHandler(this.bttnGraficaError_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1214, 749);
            this.Controls.Add(this.bttnGraficaError);
            this.Controls.Add(this.txtBoxPaso);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.bttnBarrido);
            this.Controls.Add(this.labelPendienteMin);
            this.Controls.Add(this.labelNumeroErrores);
            this.Controls.Add(this.labelPendienteMax);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBoxb);
            this.Controls.Add(this.txtBoxW2);
            this.Controls.Add(this.txtBoxW1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.bttnImportarDoc);
            this.Controls.Add(this.txtBoxDoc);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtBoxDoc;
        private System.Windows.Forms.Button bttnImportarDoc;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtBoxW1;
        private System.Windows.Forms.TextBox txtBoxW2;
        private System.Windows.Forms.TextBox txtBoxb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button bttnBarrido;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBoxPaso;
        private System.Windows.Forms.Label labelPendienteMax;
        private System.Windows.Forms.Label labelPendienteMin;
        private System.Windows.Forms.Label labelNumeroErrores;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button bttnGraficaError;
    }
}

