namespace SWD.Dialogs
{
    partial class CompareKNN
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.K = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Euklides = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Manhattan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Czebyszew = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mahalanobis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chart1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1142, 601);
            this.panel1.TabIndex = 0;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(717, 0);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(425, 601);
            this.chart1.TabIndex = 1;
            this.chart1.Text = "chart1";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(717, 601);
            this.panel2.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.K,
            this.Euklides,
            this.Manhattan,
            this.Czebyszew,
            this.Mahalanobis});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(717, 601);
            this.dataGridView1.TabIndex = 0;
            // 
            // K
            // 
            this.K.HeaderText = "K";
            this.K.MinimumWidth = 6;
            this.K.Name = "K";
            // 
            // Euklides
            // 
            this.Euklides.HeaderText = "Euklides";
            this.Euklides.MinimumWidth = 6;
            this.Euklides.Name = "Euklides";
            // 
            // Manhattan
            // 
            this.Manhattan.HeaderText = "Manhattan";
            this.Manhattan.MinimumWidth = 6;
            this.Manhattan.Name = "Manhattan";
            // 
            // Czebyszew
            // 
            this.Czebyszew.HeaderText = "Czebyszew";
            this.Czebyszew.MinimumWidth = 6;
            this.Czebyszew.Name = "Czebyszew";
            // 
            // Mahalanobis
            // 
            this.Mahalanobis.HeaderText = "Mahalanobis";
            this.Mahalanobis.MinimumWidth = 6;
            this.Mahalanobis.Name = "Mahalanobis";
            // 
            // CompareKNN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1142, 601);
            this.Controls.Add(this.panel1);
            this.Name = "CompareKNN";
            this.Text = "CompareKNN";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataGridViewTextBoxColumn K;
        private System.Windows.Forms.DataGridViewTextBoxColumn Euklides;
        private System.Windows.Forms.DataGridViewTextBoxColumn Manhattan;
        private System.Windows.Forms.DataGridViewTextBoxColumn Czebyszew;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mahalanobis;
    }
}