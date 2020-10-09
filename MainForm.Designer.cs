namespace SWD
{
    partial class MainForm
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zamianaDanychTekstowychNaNumeryczneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.normalizacjaZmiennychRzeczywistychToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wykres3DToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(162, 26);
            this.openToolStripMenuItem.Text = "Open file...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "txt files (*.txt)|*.txt";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 28);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(800, 422);
            this.dataGridView1.TabIndex = 1;
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zamianaDanychTekstowychNaNumeryczneToolStripMenuItem,
            this.normalizacjaZmiennychRzeczywistychToolStripMenuItem,
            this.wykres3DToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // zamianaDanychTekstowychNaNumeryczneToolStripMenuItem
            // 
            this.zamianaDanychTekstowychNaNumeryczneToolStripMenuItem.Name = "zamianaDanychTekstowychNaNumeryczneToolStripMenuItem";
            this.zamianaDanychTekstowychNaNumeryczneToolStripMenuItem.Size = new System.Drawing.Size(381, 26);
            this.zamianaDanychTekstowychNaNumeryczneToolStripMenuItem.Text = "Zamiana danych tekstowych na numeryczne";
            this.zamianaDanychTekstowychNaNumeryczneToolStripMenuItem.Click += new System.EventHandler(this.zamianaDanychTekstowychNaNumeryczneToolStripMenuItem_Click);
            // 
            // normalizacjaZmiennychRzeczywistychToolStripMenuItem
            // 
            this.normalizacjaZmiennychRzeczywistychToolStripMenuItem.Name = "normalizacjaZmiennychRzeczywistychToolStripMenuItem";
            this.normalizacjaZmiennychRzeczywistychToolStripMenuItem.Size = new System.Drawing.Size(381, 26);
            this.normalizacjaZmiennychRzeczywistychToolStripMenuItem.Text = "Normalizacja zmiennych rzeczywistych";
            this.normalizacjaZmiennychRzeczywistychToolStripMenuItem.Click += new System.EventHandler(this.normalizacjaZmiennychRzeczywistychToolStripMenuItem_Click);
            // 
            // wykres3DToolStripMenuItem
            // 
            this.wykres3DToolStripMenuItem.Name = "wykres3DToolStripMenuItem";
            this.wykres3DToolStripMenuItem.Size = new System.Drawing.Size(381, 26);
            this.wykres3DToolStripMenuItem.Text = "Wykres 3D";
            this.wykres3DToolStripMenuItem.Click += new System.EventHandler(this.wykres3DToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zamianaDanychTekstowychNaNumeryczneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem normalizacjaZmiennychRzeczywistychToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wykres3DToolStripMenuItem;
    }
}

