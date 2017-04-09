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
            this._dataGridView = new System.Windows.Forms.DataGridView();
            this._choosingLabel = new System.Windows.Forms.Label();
            this._circuitKind = new System.Windows.Forms.ComboBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this._mainWindowStatusStrip = new System.Windows.Forms.ToolStripStatusLabel();
            this._groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _groupBox
            // 
            this._groupBox.Controls.Add(this._dataGridView);
            this._groupBox.Controls.Add(this._choosingLabel);
            this._groupBox.Controls.Add(this._circuitKind);
            this._groupBox.Location = new System.Drawing.Point(12, 12);
            this._groupBox.Name = "_groupBox";
            this._groupBox.Size = new System.Drawing.Size(254, 366);
            this._groupBox.TabIndex = 0;
            this._groupBox.TabStop = false;
            // 
            // _dataGridView
            // 
            this._dataGridView.AllowUserToAddRows = false;
            this._dataGridView.AllowUserToResizeColumns = false;
            this._dataGridView.AllowUserToResizeRows = false;
            this._dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGridView.Enabled = false;
            this._dataGridView.Location = new System.Drawing.Point(6, 171);
            this._dataGridView.Name = "_dataGridView";
            this._dataGridView.Size = new System.Drawing.Size(242, 189);
            this._dataGridView.TabIndex = 3;
            this._dataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this._dataGridView_CellEndEdit);
            this._dataGridView.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this._dataGridView_CellValidating);
            // 
            // _choosingLabel
            // 
            this._choosingLabel.AutoSize = true;
            this._choosingLabel.Location = new System.Drawing.Point(6, 16);
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
            this._circuitKind.Location = new System.Drawing.Point(120, 13);
            this._circuitKind.Name = "_circuitKind";
            this._circuitKind.Size = new System.Drawing.Size(121, 21);
            this._circuitKind.TabIndex = 0;
            this._circuitKind.SelectedIndexChanged += new System.EventHandler(this._circuitKind_SelectedIndexChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._mainWindowStatusStrip});
            this.statusStrip1.Location = new System.Drawing.Point(0, 384);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(271, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // _mainWindowStatusStrip
            // 
            this._mainWindowStatusStrip.Name = "_mainWindowStatusStrip";
            this._mainWindowStatusStrip.Size = new System.Drawing.Size(92, 17);
            this._mainWindowStatusStrip.Text = "Choose a circuit";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 406);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this._groupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this._groupBox.ResumeLayout(false);
            this._groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox _groupBox;
        private System.Windows.Forms.DataGridView _dataGridView;
        private System.Windows.Forms.Label _choosingLabel;
        private System.Windows.Forms.ComboBox _circuitKind;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel _mainWindowStatusStrip;
    }
}