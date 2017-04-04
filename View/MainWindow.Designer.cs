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
            this._elementControl3 = new View.ElementControl();
            this._elementControl2 = new View.ElementControl();
            this._elementControl1 = new View.ElementControl();
            this._dataGridView = new System.Windows.Forms.DataGridView();
            this.Frequence = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Resistance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._choosingLabel = new System.Windows.Forms.Label();
            this._circuitKind = new System.Windows.Forms.ComboBox();
            this._groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // _groupBox
            // 
            this._groupBox.Controls.Add(this._elementControl3);
            this._groupBox.Controls.Add(this._elementControl2);
            this._groupBox.Controls.Add(this._elementControl1);
            this._groupBox.Controls.Add(this._dataGridView);
            this._groupBox.Controls.Add(this._choosingLabel);
            this._groupBox.Controls.Add(this._circuitKind);
            this._groupBox.Location = new System.Drawing.Point(12, 4);
            this._groupBox.Name = "_groupBox";
            this._groupBox.Size = new System.Drawing.Size(254, 376);
            this._groupBox.TabIndex = 0;
            this._groupBox.TabStop = false;
            // 
            // _elementControl3
            // 
            this._elementControl3.Location = new System.Drawing.Point(6, 123);
            this._elementControl3.Name = "_elementControl3";
            this._elementControl3.Object = null;
            this._elementControl3.Size = new System.Drawing.Size(235, 27);
            this._elementControl3.TabIndex = 6;
            this._elementControl3.Visible = false;
            // 
            // _elementControl2
            // 
            this._elementControl2.Location = new System.Drawing.Point(6, 90);
            this._elementControl2.Name = "_elementControl2";
            this._elementControl2.Object = null;
            this._elementControl2.Size = new System.Drawing.Size(235, 27);
            this._elementControl2.TabIndex = 5;
            this._elementControl2.Visible = false;
            // 
            // _elementControl1
            // 
            this._elementControl1.Location = new System.Drawing.Point(6, 57);
            this._elementControl1.Name = "_elementControl1";
            this._elementControl1.Object = null;
            this._elementControl1.Size = new System.Drawing.Size(235, 27);
            this._elementControl1.TabIndex = 4;
            this._elementControl1.Visible = false;
            // 
            // _dataGridView
            // 
            this._dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Frequence,
            this.Resistance});
            this._dataGridView.Location = new System.Drawing.Point(6, 207);
            this._dataGridView.Name = "_dataGridView";
            this._dataGridView.Size = new System.Drawing.Size(231, 155);
            this._dataGridView.TabIndex = 3;
            // 
            // Frequence
            // 
            this.Frequence.HeaderText = "Frequence";
            this.Frequence.MaxInputLength = 7;
            this.Frequence.Name = "Frequence";
            this.Frequence.Width = 90;
            // 
            // Resistance
            // 
            this.Resistance.HeaderText = "Common resistance";
            this.Resistance.Name = "Resistance";
            this.Resistance.ReadOnly = true;
            this.Resistance.Width = 95;
            // 
            // _choosingLabel
            // 
            this._choosingLabel.AutoSize = true;
            this._choosingLabel.Location = new System.Drawing.Point(6, 33);
            this._choosingLabel.Name = "_choosingLabel";
            this._choosingLabel.Size = new System.Drawing.Size(83, 13);
            this._choosingLabel.TabIndex = 1;
            this._choosingLabel.Text = "Choose a circuit";
            // 
            // _circuitKind
            // 
            this._circuitKind.FormattingEnabled = true;
            this._circuitKind.Items.AddRange(new object[] {
            "Circuit 1",
            "Circuit 2",
            "Circuit 3",
            "Circuit 4",
            "Circuit 5"});
            this._circuitKind.Location = new System.Drawing.Point(116, 30);
            this._circuitKind.Name = "_circuitKind";
            this._circuitKind.Size = new System.Drawing.Size(121, 21);
            this._circuitKind.TabIndex = 0;
            this._circuitKind.SelectedIndexChanged += new System.EventHandler(this._circuitKind_SelectedIndexChanged);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 390);
            this.Controls.Add(this._groupBox);
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this._groupBox.ResumeLayout(false);
            this._groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox _groupBox;
        private System.Windows.Forms.DataGridView _dataGridView;
        private System.Windows.Forms.Label _choosingLabel;
        private System.Windows.Forms.ComboBox _circuitKind;
        private System.Windows.Forms.DataGridViewTextBoxColumn Frequence;
        private System.Windows.Forms.DataGridViewTextBoxColumn Resistance;
        private ElementControl _elementControl3;
        private ElementControl _elementControl2;
        private ElementControl _elementControl1;
    }
}