namespace View
{
    partial class MainWindow
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
            this._groupBox = new System.Windows.Forms.GroupBox();
            this._elementsPanel = new System.Windows.Forms.Panel();
            this._countOfElementView = new System.Windows.Forms.NumericUpDown();
            this._dataGridView = new System.Windows.Forms.DataGridView();
            this.Frequence = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Resistance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._elementCountLabel = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this._mainWindowStatusStrip = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.circuitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._circuit1 = new System.Windows.Forms.ToolStripMenuItem();
            this._circuit2 = new System.Windows.Forms.ToolStripMenuItem();
            this._circuit3 = new System.Windows.Forms.ToolStripMenuItem();
            this._circuit4 = new System.Windows.Forms.ToolStripMenuItem();
            this._circuit5 = new System.Windows.Forms.ToolStripMenuItem();
            this.createToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.analysisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._countOfElementView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _groupBox
            // 
            this._groupBox.Controls.Add(this._elementsPanel);
            this._groupBox.Controls.Add(this._countOfElementView);
            this._groupBox.Controls.Add(this._dataGridView);
            this._groupBox.Controls.Add(this._elementCountLabel);
            this._groupBox.Location = new System.Drawing.Point(12, 27);
            this._groupBox.Name = "_groupBox";
            this._groupBox.Size = new System.Drawing.Size(482, 351);
            this._groupBox.TabIndex = 0;
            this._groupBox.TabStop = false;
            // 
            // _elementsPanel
            // 
            this._elementsPanel.AutoScroll = true;
            this._elementsPanel.Location = new System.Drawing.Point(6, 45);
            this._elementsPanel.Name = "_elementsPanel";
            this._elementsPanel.Size = new System.Drawing.Size(470, 120);
            this._elementsPanel.TabIndex = 5;
            // 
            // _countOfElementView
            // 
            this._countOfElementView.AutoSize = true;
            this._countOfElementView.Enabled = false;
            this._countOfElementView.Location = new System.Drawing.Point(173, 19);
            this._countOfElementView.Name = "_countOfElementView";
            this._countOfElementView.ReadOnly = true;
            this._countOfElementView.Size = new System.Drawing.Size(45, 20);
            this._countOfElementView.TabIndex = 4;
            this._countOfElementView.ValueChanged += new System.EventHandler(this.CountOfElementView_ValueChanged);
            // 
            // _dataGridView
            // 
            this._dataGridView.AllowUserToAddRows = false;
            this._dataGridView.AllowUserToResizeColumns = false;
            this._dataGridView.AllowUserToResizeRows = false;
            this._dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Frequence,
            this.Resistance});
            this._dataGridView.Enabled = false;
            this._dataGridView.Location = new System.Drawing.Point(6, 171);
            this._dataGridView.Name = "_dataGridView";
            this._dataGridView.Size = new System.Drawing.Size(470, 174);
            this._dataGridView.TabIndex = 3;
            this._dataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_CellEndEdit);
            this._dataGridView.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.DataGridView_CellValidating);
            this._dataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_CellValueChanged);
            // 
            // Frequence
            // 
            this.Frequence.HeaderText = "Frequence";
            this.Frequence.Name = "Frequence";
            // 
            // Resistance
            // 
            this.Resistance.HeaderText = "Resistance";
            this.Resistance.Name = "Resistance";
            this.Resistance.ReadOnly = true;
            this.Resistance.Width = 300;
            // 
            // _elementCountLabel
            // 
            this._elementCountLabel.AutoSize = true;
            this._elementCountLabel.Location = new System.Drawing.Point(6, 21);
            this._elementCountLabel.Name = "_elementCountLabel";
            this._elementCountLabel.Size = new System.Drawing.Size(147, 13);
            this._elementCountLabel.TabIndex = 1;
            this._elementCountLabel.Text = "Count of element in the circuit";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._mainWindowStatusStrip});
            this.statusStrip1.Location = new System.Drawing.Point(0, 383);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(500, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // _mainWindowStatusStrip
            // 
            this._mainWindowStatusStrip.Name = "_mainWindowStatusStrip";
            this._mainWindowStatusStrip.Size = new System.Drawing.Size(92, 17);
            this._mainWindowStatusStrip.Text = "Choose a circuit";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.circuitToolStripMenuItem,
            this.analysisToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(500, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // circuitToolStripMenuItem
            // 
            this.circuitToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.createToolStripMenuItem});
            this.circuitToolStripMenuItem.Name = "circuitToolStripMenuItem";
            this.circuitToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.circuitToolStripMenuItem.Text = "Circuit";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._circuit1,
            this._circuit2,
            this._circuit3,
            this._circuit4,
            this._circuit5});
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.loadToolStripMenuItem.Text = "Load";
            // 
            // _circuit1
            // 
            this._circuit1.Name = "_circuit1";
            this._circuit1.Size = new System.Drawing.Size(80, 22);
            this._circuit1.Text = "1";
            this._circuit1.Click += new System.EventHandler(this.LoadCircuit);
            // 
            // _circuit2
            // 
            this._circuit2.Name = "_circuit2";
            this._circuit2.Size = new System.Drawing.Size(80, 22);
            this._circuit2.Text = "2";
            this._circuit2.Click += new System.EventHandler(this.LoadCircuit);
            // 
            // _circuit3
            // 
            this._circuit3.Name = "_circuit3";
            this._circuit3.Size = new System.Drawing.Size(80, 22);
            this._circuit3.Text = "3";
            this._circuit3.Click += new System.EventHandler(this.LoadCircuit);
            // 
            // _circuit4
            // 
            this._circuit4.Name = "_circuit4";
            this._circuit4.Size = new System.Drawing.Size(80, 22);
            this._circuit4.Text = "4";
            this._circuit4.Click += new System.EventHandler(this.LoadCircuit);
            // 
            // _circuit5
            // 
            this._circuit5.Name = "_circuit5";
            this._circuit5.Size = new System.Drawing.Size(80, 22);
            this._circuit5.Text = "5";
            this._circuit5.Click += new System.EventHandler(this.LoadCircuit);
            // 
            // createToolStripMenuItem
            // 
            this.createToolStripMenuItem.Name = "createToolStripMenuItem";
            this.createToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.createToolStripMenuItem.Text = "Create";
            this.createToolStripMenuItem.Click += new System.EventHandler(this.CreateCircuit);
            // 
            // analysisToolStripMenuItem
            // 
            this.analysisToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aCToolStripMenuItem});
            this.analysisToolStripMenuItem.Name = "analysisToolStripMenuItem";
            this.analysisToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.analysisToolStripMenuItem.Text = "Analysis";
            // 
            // aCToolStripMenuItem
            // 
            this.aCToolStripMenuItem.Name = "aCToolStripMenuItem";
            this.aCToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aCToolStripMenuItem.Text = "AC";
            this.aCToolStripMenuItem.Click += new System.EventHandler(this.aCToolStripMenuItem_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 405);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this._groupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this._groupBox.ResumeLayout(false);
            this._groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._countOfElementView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox _groupBox;
        private System.Windows.Forms.DataGridView _dataGridView;
        private System.Windows.Forms.Label _elementCountLabel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel _mainWindowStatusStrip;
        private System.Windows.Forms.DataGridViewTextBoxColumn Frequence;
        private System.Windows.Forms.DataGridViewTextBoxColumn Resistance;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem circuitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _circuit1;
        private System.Windows.Forms.ToolStripMenuItem _circuit2;
        private System.Windows.Forms.ToolStripMenuItem _circuit3;
        private System.Windows.Forms.ToolStripMenuItem _circuit4;
        private System.Windows.Forms.ToolStripMenuItem _circuit5;
        private System.Windows.Forms.ToolStripMenuItem createToolStripMenuItem;
        private System.Windows.Forms.NumericUpDown _countOfElementView;
        private System.Windows.Forms.Panel _elementsPanel;
        private System.Windows.Forms.ToolStripMenuItem analysisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aCToolStripMenuItem;
    }
}