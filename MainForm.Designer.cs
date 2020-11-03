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
            this.withColumnNamesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.withoutColumnNamesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zamianaDanychTekstowychNaNumeryczneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.normalizacjaZmiennychRzeczywistychToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wykres3DToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zaznaczenieCzęściZmiennychToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.najmniejszychToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.największychToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dyskretyzacjaZmiennychRzeczywistychToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zmianaPrzedziałuWartościToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wykres2DToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.histogramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zmienneDyskretneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zmienneRzeczywisteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kNNToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.klasyfikujToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ocenaWartościKlasyfikacjiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
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
            this.openToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.withColumnNamesToolStripMenuItem,
            this.withoutColumnNamesToolStripMenuItem});
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.openToolStripMenuItem.Text = "Open file...";
            // 
            // withColumnNamesToolStripMenuItem
            // 
            this.withColumnNamesToolStripMenuItem.Name = "withColumnNamesToolStripMenuItem";
            this.withColumnNamesToolStripMenuItem.Size = new System.Drawing.Size(245, 26);
            this.withColumnNamesToolStripMenuItem.Text = "With column names";
            this.withColumnNamesToolStripMenuItem.Click += new System.EventHandler(this.withColumnNamesToolStripMenuItem_Click);
            // 
            // withoutColumnNamesToolStripMenuItem
            // 
            this.withoutColumnNamesToolStripMenuItem.Name = "withoutColumnNamesToolStripMenuItem";
            this.withoutColumnNamesToolStripMenuItem.Size = new System.Drawing.Size(245, 26);
            this.withoutColumnNamesToolStripMenuItem.Text = "Without column names";
            this.withoutColumnNamesToolStripMenuItem.Click += new System.EventHandler(this.withoutColumnNamesToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zamianaDanychTekstowychNaNumeryczneToolStripMenuItem,
            this.normalizacjaZmiennychRzeczywistychToolStripMenuItem,
            this.wykres3DToolStripMenuItem,
            this.zaznaczenieCzęściZmiennychToolStripMenuItem,
            this.dyskretyzacjaZmiennychRzeczywistychToolStripMenuItem,
            this.zmianaPrzedziałuWartościToolStripMenuItem,
            this.wykres2DToolStripMenuItem,
            this.histogramToolStripMenuItem,
            this.kNNToolStripMenuItem});
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
            // zaznaczenieCzęściZmiennychToolStripMenuItem
            // 
            this.zaznaczenieCzęściZmiennychToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.najmniejszychToolStripMenuItem,
            this.największychToolStripMenuItem});
            this.zaznaczenieCzęściZmiennychToolStripMenuItem.Name = "zaznaczenieCzęściZmiennychToolStripMenuItem";
            this.zaznaczenieCzęściZmiennychToolStripMenuItem.Size = new System.Drawing.Size(381, 26);
            this.zaznaczenieCzęściZmiennychToolStripMenuItem.Text = "Zaznaczenie części zmiennych";
            // 
            // najmniejszychToolStripMenuItem
            // 
            this.najmniejszychToolStripMenuItem.Name = "najmniejszychToolStripMenuItem";
            this.najmniejszychToolStripMenuItem.Size = new System.Drawing.Size(187, 26);
            this.najmniejszychToolStripMenuItem.Text = "Najmniejszych";
            this.najmniejszychToolStripMenuItem.Click += new System.EventHandler(this.najmniejszychToolStripMenuItem_Click);
            // 
            // największychToolStripMenuItem
            // 
            this.największychToolStripMenuItem.Name = "największychToolStripMenuItem";
            this.największychToolStripMenuItem.Size = new System.Drawing.Size(187, 26);
            this.największychToolStripMenuItem.Text = "Największych";
            this.największychToolStripMenuItem.Click += new System.EventHandler(this.największychToolStripMenuItem_Click);
            // 
            // dyskretyzacjaZmiennychRzeczywistychToolStripMenuItem
            // 
            this.dyskretyzacjaZmiennychRzeczywistychToolStripMenuItem.Name = "dyskretyzacjaZmiennychRzeczywistychToolStripMenuItem";
            this.dyskretyzacjaZmiennychRzeczywistychToolStripMenuItem.Size = new System.Drawing.Size(381, 26);
            this.dyskretyzacjaZmiennychRzeczywistychToolStripMenuItem.Text = "Dyskretyzacja zmiennych rzeczywistych";
            this.dyskretyzacjaZmiennychRzeczywistychToolStripMenuItem.Click += new System.EventHandler(this.dyskretyzacjaZmiennychRzeczywistychToolStripMenuItem_Click);
            // 
            // zmianaPrzedziałuWartościToolStripMenuItem
            // 
            this.zmianaPrzedziałuWartościToolStripMenuItem.Name = "zmianaPrzedziałuWartościToolStripMenuItem";
            this.zmianaPrzedziałuWartościToolStripMenuItem.Size = new System.Drawing.Size(381, 26);
            this.zmianaPrzedziałuWartościToolStripMenuItem.Text = "Zmiana przedziału wartości";
            this.zmianaPrzedziałuWartościToolStripMenuItem.Click += new System.EventHandler(this.zmianaPrzedziałuWartościToolStripMenuItem_Click);
            // 
            // wykres2DToolStripMenuItem
            // 
            this.wykres2DToolStripMenuItem.Name = "wykres2DToolStripMenuItem";
            this.wykres2DToolStripMenuItem.Size = new System.Drawing.Size(381, 26);
            this.wykres2DToolStripMenuItem.Text = "Wykres 2D";
            this.wykres2DToolStripMenuItem.Click += new System.EventHandler(this.wykres2DToolStripMenuItem_Click);
            // 
            // histogramToolStripMenuItem
            // 
            this.histogramToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zmienneDyskretneToolStripMenuItem,
            this.zmienneRzeczywisteToolStripMenuItem});
            this.histogramToolStripMenuItem.Name = "histogramToolStripMenuItem";
            this.histogramToolStripMenuItem.Size = new System.Drawing.Size(381, 26);
            this.histogramToolStripMenuItem.Text = "Histogram";
            // 
            // zmienneDyskretneToolStripMenuItem
            // 
            this.zmienneDyskretneToolStripMenuItem.Name = "zmienneDyskretneToolStripMenuItem";
            this.zmienneDyskretneToolStripMenuItem.Size = new System.Drawing.Size(229, 26);
            this.zmienneDyskretneToolStripMenuItem.Text = "Zmienne dyskretne";
            this.zmienneDyskretneToolStripMenuItem.Click += new System.EventHandler(this.zmienneDyskretneToolStripMenuItem_Click);
            // 
            // zmienneRzeczywisteToolStripMenuItem
            // 
            this.zmienneRzeczywisteToolStripMenuItem.Name = "zmienneRzeczywisteToolStripMenuItem";
            this.zmienneRzeczywisteToolStripMenuItem.Size = new System.Drawing.Size(229, 26);
            this.zmienneRzeczywisteToolStripMenuItem.Text = "Zmienne rzeczywiste";
            this.zmienneRzeczywisteToolStripMenuItem.Click += new System.EventHandler(this.zmienneRzeczywisteToolStripMenuItem_Click);
            // 
            // kNNToolStripMenuItem
            // 
            this.kNNToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.klasyfikujToolStripMenuItem,
            this.ocenaWartościKlasyfikacjiToolStripMenuItem});
            this.kNNToolStripMenuItem.Name = "kNNToolStripMenuItem";
            this.kNNToolStripMenuItem.Size = new System.Drawing.Size(381, 26);
            this.kNNToolStripMenuItem.Text = "Klasyfikacja KNN";
            // 
            // klasyfikujToolStripMenuItem
            // 
            this.klasyfikujToolStripMenuItem.Name = "klasyfikujToolStripMenuItem";
            this.klasyfikujToolStripMenuItem.Size = new System.Drawing.Size(268, 26);
            this.klasyfikujToolStripMenuItem.Text = "Klasyfikuj";
            this.klasyfikujToolStripMenuItem.Click += new System.EventHandler(this.klasyfikujToolStripMenuItem_Click);
            // 
            // ocenaWartościKlasyfikacjiToolStripMenuItem
            // 
            this.ocenaWartościKlasyfikacjiToolStripMenuItem.Name = "ocenaWartościKlasyfikacjiToolStripMenuItem";
            this.ocenaWartościKlasyfikacjiToolStripMenuItem.Size = new System.Drawing.Size(268, 26);
            this.ocenaWartościKlasyfikacjiToolStripMenuItem.Text = "Ocena wartości klasyfikacji";
            this.ocenaWartościKlasyfikacjiToolStripMenuItem.Click += new System.EventHandler(this.ocenaWartościKlasyfikacjiToolStripMenuItem_Click);
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
        private System.Windows.Forms.ToolStripMenuItem zaznaczenieCzęściZmiennychToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem najmniejszychToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem największychToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dyskretyzacjaZmiennychRzeczywistychToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zmianaPrzedziałuWartościToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wykres2DToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem histogramToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zmienneDyskretneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zmienneRzeczywisteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kNNToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem klasyfikujToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ocenaWartościKlasyfikacjiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem withColumnNamesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem withoutColumnNamesToolStripMenuItem;
    }
}

