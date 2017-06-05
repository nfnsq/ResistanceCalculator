namespace View
{
    partial class AC_Analysis
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
            this.components = new System.ComponentModel.Container();
            this.settingsGB = new System.Windows.Forms.GroupBox();
            this.plotNodesTB = new System.Windows.Forms.TextBox();
            this.plotLB = new System.Windows.Forms.Label();
            this.analysisGB = new System.Windows.Forms.GroupBox();
            this.variationCB = new System.Windows.Forms.ComboBox();
            this.numberOfPointsTB = new System.Windows.Forms.TextBox();
            this.numberOfPointsLB = new System.Windows.Forms.Label();
            this.fstopLB = new System.Windows.Forms.Label();
            this.variationLB = new System.Windows.Forms.Label();
            this.fstopTB = new System.Windows.Forms.TextBox();
            this.fstartLB = new System.Windows.Forms.Label();
            this.fstartTB = new System.Windows.Forms.TextBox();
            this.sourceGB = new System.Windows.Forms.GroupBox();
            this.nodeInTB = new System.Windows.Forms.TextBox();
            this.magnitudeTB = new System.Windows.Forms.TextBox();
            this.nodeOutTB = new System.Windows.Forms.TextBox();
            this.phaseTB = new System.Windows.Forms.TextBox();
            this.nodeInLB = new System.Windows.Forms.Label();
            this.magnitudeLB = new System.Windows.Forms.Label();
            this.nodeOutLB = new System.Windows.Forms.Label();
            this.phaseLB = new System.Windows.Forms.Label();
            this.cancelBT = new System.Windows.Forms.Button();
            this.btDraw = new System.Windows.Forms.Button();
            this.zedGraphControl = new ZedGraph.ZedGraphControl();
            this.settingsGB.SuspendLayout();
            this.analysisGB.SuspendLayout();
            this.sourceGB.SuspendLayout();
            this.SuspendLayout();
            // 
            // settingsGB
            // 
            this.settingsGB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.settingsGB.Controls.Add(this.plotNodesTB);
            this.settingsGB.Controls.Add(this.plotLB);
            this.settingsGB.Controls.Add(this.analysisGB);
            this.settingsGB.Controls.Add(this.sourceGB);
            this.settingsGB.Controls.Add(this.cancelBT);
            this.settingsGB.Controls.Add(this.btDraw);
            this.settingsGB.Location = new System.Drawing.Point(12, 13);
            this.settingsGB.Name = "settingsGB";
            this.settingsGB.Size = new System.Drawing.Size(357, 281);
            this.settingsGB.TabIndex = 0;
            this.settingsGB.TabStop = false;
            // 
            // plotNodesTB
            // 
            this.plotNodesTB.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.plotNodesTB.Location = new System.Drawing.Point(105, 184);
            this.plotNodesTB.Name = "plotNodesTB";
            this.plotNodesTB.Size = new System.Drawing.Size(237, 20);
            this.plotNodesTB.TabIndex = 24;
            this.plotNodesTB.Text = "v(1), vdb(2), v(1, 2)";
            this.plotNodesTB.Enter += new System.EventHandler(this.TB_Enter);
            // 
            // plotLB
            // 
            this.plotLB.AutoSize = true;
            this.plotLB.Location = new System.Drawing.Point(8, 187);
            this.plotLB.Name = "plotLB";
            this.plotLB.Size = new System.Drawing.Size(25, 13);
            this.plotLB.TabIndex = 23;
            this.plotLB.Text = "Plot";
            // 
            // analysisGB
            // 
            this.analysisGB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.analysisGB.Controls.Add(this.variationCB);
            this.analysisGB.Controls.Add(this.numberOfPointsTB);
            this.analysisGB.Controls.Add(this.numberOfPointsLB);
            this.analysisGB.Controls.Add(this.fstopLB);
            this.analysisGB.Controls.Add(this.variationLB);
            this.analysisGB.Controls.Add(this.fstopTB);
            this.analysisGB.Controls.Add(this.fstartLB);
            this.analysisGB.Controls.Add(this.fstartTB);
            this.analysisGB.Location = new System.Drawing.Point(6, 97);
            this.analysisGB.Name = "analysisGB";
            this.analysisGB.Size = new System.Drawing.Size(343, 75);
            this.analysisGB.TabIndex = 22;
            this.analysisGB.TabStop = false;
            this.analysisGB.Text = "Analysis";
            // 
            // variationCB
            // 
            this.variationCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.variationCB.FormattingEnabled = true;
            this.variationCB.Items.AddRange(new object[] {
            "dec",
            "lin",
            "oct"});
            this.variationCB.Location = new System.Drawing.Point(99, 20);
            this.variationCB.Name = "variationCB";
            this.variationCB.Size = new System.Drawing.Size(50, 21);
            this.variationCB.TabIndex = 17;
            // 
            // numberOfPointsTB
            // 
            this.numberOfPointsTB.Location = new System.Drawing.Point(99, 46);
            this.numberOfPointsTB.Name = "numberOfPointsTB";
            this.numberOfPointsTB.Size = new System.Drawing.Size(50, 20);
            this.numberOfPointsTB.TabIndex = 18;
            this.numberOfPointsTB.Text = "10";
            this.numberOfPointsTB.Enter += new System.EventHandler(this.TB_Enter);
            // 
            // numberOfPointsLB
            // 
            this.numberOfPointsLB.AutoSize = true;
            this.numberOfPointsLB.Location = new System.Drawing.Point(6, 49);
            this.numberOfPointsLB.Name = "numberOfPointsLB";
            this.numberOfPointsLB.Size = new System.Drawing.Size(87, 13);
            this.numberOfPointsLB.TabIndex = 14;
            this.numberOfPointsLB.Text = "Number of points";
            // 
            // fstopLB
            // 
            this.fstopLB.AutoSize = true;
            this.fstopLB.Location = new System.Drawing.Point(173, 49);
            this.fstopLB.Name = "fstopLB";
            this.fstopLB.Size = new System.Drawing.Size(79, 13);
            this.fstopLB.TabIndex = 16;
            this.fstopLB.Text = "Final frequency";
            // 
            // variationLB
            // 
            this.variationLB.AutoSize = true;
            this.variationLB.Location = new System.Drawing.Point(6, 22);
            this.variationLB.Name = "variationLB";
            this.variationLB.Size = new System.Drawing.Size(48, 13);
            this.variationLB.TabIndex = 13;
            this.variationLB.Text = "Variation";
            // 
            // fstopTB
            // 
            this.fstopTB.Location = new System.Drawing.Point(258, 46);
            this.fstopTB.Name = "fstopTB";
            this.fstopTB.Size = new System.Drawing.Size(78, 20);
            this.fstopTB.TabIndex = 20;
            this.fstopTB.Text = "100";
            this.fstopTB.Enter += new System.EventHandler(this.TB_Enter);
            // 
            // fstartLB
            // 
            this.fstartLB.AutoSize = true;
            this.fstartLB.Location = new System.Drawing.Point(173, 23);
            this.fstartLB.Name = "fstartLB";
            this.fstartLB.Size = new System.Drawing.Size(79, 13);
            this.fstartLB.TabIndex = 15;
            this.fstartLB.Text = "Start frequency";
            // 
            // fstartTB
            // 
            this.fstartTB.Location = new System.Drawing.Point(258, 20);
            this.fstartTB.Name = "fstartTB";
            this.fstartTB.Size = new System.Drawing.Size(78, 20);
            this.fstartTB.TabIndex = 19;
            this.fstartTB.Text = "0.01";
            this.fstartTB.Enter += new System.EventHandler(this.TB_Enter);
            // 
            // sourceGB
            // 
            this.sourceGB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sourceGB.Controls.Add(this.nodeInTB);
            this.sourceGB.Controls.Add(this.magnitudeTB);
            this.sourceGB.Controls.Add(this.nodeOutTB);
            this.sourceGB.Controls.Add(this.phaseTB);
            this.sourceGB.Controls.Add(this.nodeInLB);
            this.sourceGB.Controls.Add(this.magnitudeLB);
            this.sourceGB.Controls.Add(this.nodeOutLB);
            this.sourceGB.Controls.Add(this.phaseLB);
            this.sourceGB.Location = new System.Drawing.Point(6, 19);
            this.sourceGB.Name = "sourceGB";
            this.sourceGB.Size = new System.Drawing.Size(343, 72);
            this.sourceGB.TabIndex = 21;
            this.sourceGB.TabStop = false;
            this.sourceGB.Text = "Source";
            // 
            // nodeInTB
            // 
            this.nodeInTB.Location = new System.Drawing.Point(99, 19);
            this.nodeInTB.MaxLength = 2;
            this.nodeInTB.Name = "nodeInTB";
            this.nodeInTB.Size = new System.Drawing.Size(31, 20);
            this.nodeInTB.TabIndex = 5;
            this.nodeInTB.Text = "1";
            this.nodeInTB.Enter += new System.EventHandler(this.TB_Enter);
            // 
            // magnitudeTB
            // 
            this.magnitudeTB.Location = new System.Drawing.Point(258, 19);
            this.magnitudeTB.Name = "magnitudeTB";
            this.magnitudeTB.Size = new System.Drawing.Size(78, 20);
            this.magnitudeTB.TabIndex = 7;
            this.magnitudeTB.Text = "1";
            this.magnitudeTB.Enter += new System.EventHandler(this.TB_Enter);
            // 
            // nodeOutTB
            // 
            this.nodeOutTB.Location = new System.Drawing.Point(99, 45);
            this.nodeOutTB.MaxLength = 2;
            this.nodeOutTB.Name = "nodeOutTB";
            this.nodeOutTB.Size = new System.Drawing.Size(31, 20);
            this.nodeOutTB.TabIndex = 6;
            this.nodeOutTB.Text = "0";
            this.nodeOutTB.Enter += new System.EventHandler(this.TB_Enter);
            // 
            // phaseTB
            // 
            this.phaseTB.Location = new System.Drawing.Point(258, 45);
            this.phaseTB.Name = "phaseTB";
            this.phaseTB.Size = new System.Drawing.Size(78, 20);
            this.phaseTB.TabIndex = 8;
            this.phaseTB.Text = "0";
            this.phaseTB.Enter += new System.EventHandler(this.TB_Enter);
            // 
            // nodeInLB
            // 
            this.nodeInLB.AutoSize = true;
            this.nodeInLB.Location = new System.Drawing.Point(2, 22);
            this.nodeInLB.Name = "nodeInLB";
            this.nodeInLB.Size = new System.Drawing.Size(47, 13);
            this.nodeInLB.TabIndex = 9;
            this.nodeInLB.Text = "Node IN";
            // 
            // magnitudeLB
            // 
            this.magnitudeLB.AutoSize = true;
            this.magnitudeLB.Location = new System.Drawing.Point(173, 22);
            this.magnitudeLB.Name = "magnitudeLB";
            this.magnitudeLB.Size = new System.Drawing.Size(57, 13);
            this.magnitudeLB.TabIndex = 3;
            this.magnitudeLB.Text = "Magnitude";
            // 
            // nodeOutLB
            // 
            this.nodeOutLB.AutoSize = true;
            this.nodeOutLB.Location = new System.Drawing.Point(2, 48);
            this.nodeOutLB.Name = "nodeOutLB";
            this.nodeOutLB.Size = new System.Drawing.Size(59, 13);
            this.nodeOutLB.TabIndex = 10;
            this.nodeOutLB.Text = "Node OUT";
            // 
            // phaseLB
            // 
            this.phaseLB.AutoSize = true;
            this.phaseLB.Location = new System.Drawing.Point(173, 48);
            this.phaseLB.Name = "phaseLB";
            this.phaseLB.Size = new System.Drawing.Size(37, 13);
            this.phaseLB.TabIndex = 4;
            this.phaseLB.Text = "Phase";
            // 
            // cancelBT
            // 
            this.cancelBT.Location = new System.Drawing.Point(276, 251);
            this.cancelBT.Name = "cancelBT";
            this.cancelBT.Size = new System.Drawing.Size(75, 23);
            this.cancelBT.TabIndex = 11;
            this.cancelBT.Text = "Cancel";
            this.cancelBT.UseVisualStyleBackColor = true;
            this.cancelBT.Click += new System.EventHandler(this.cancelBT_Click);
            // 
            // btDraw
            // 
            this.btDraw.Location = new System.Drawing.Point(195, 251);
            this.btDraw.Name = "btDraw";
            this.btDraw.Size = new System.Drawing.Size(75, 23);
            this.btDraw.TabIndex = 1;
            this.btDraw.Text = "Draw Graph";
            this.btDraw.UseVisualStyleBackColor = true;
            this.btDraw.Click += new System.EventHandler(this.btDraw_Click);
            // 
            // zedGraphControl
            // 
            this.zedGraphControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.zedGraphControl.IsAutoScrollRange = true;
            this.zedGraphControl.IsShowCursorValues = true;
            this.zedGraphControl.IsShowPointValues = true;
            this.zedGraphControl.Location = new System.Drawing.Point(375, 24);
            this.zedGraphControl.Name = "zedGraphControl";
            this.zedGraphControl.ScrollGrace = 0D;
            this.zedGraphControl.ScrollMaxX = 0D;
            this.zedGraphControl.ScrollMaxY = 0D;
            this.zedGraphControl.ScrollMaxY2 = 0D;
            this.zedGraphControl.ScrollMinX = 0D;
            this.zedGraphControl.ScrollMinY = 0D;
            this.zedGraphControl.ScrollMinY2 = 0D;
            this.zedGraphControl.Size = new System.Drawing.Size(408, 270);
            this.zedGraphControl.TabIndex = 0;
            // 
            // AC_Analysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 299);
            this.Controls.Add(this.settingsGB);
            this.Controls.Add(this.zedGraphControl);
            this.Name = "AC_Analysis";
            this.Text = "AC Analysis";
            this.settingsGB.ResumeLayout(false);
            this.settingsGB.PerformLayout();
            this.analysisGB.ResumeLayout(false);
            this.analysisGB.PerformLayout();
            this.sourceGB.ResumeLayout(false);
            this.sourceGB.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox settingsGB;
        private ZedGraph.ZedGraphControl zedGraphControl;
        private System.Windows.Forms.Button btDraw;
        private System.Windows.Forms.Label nodeOutLB;
        private System.Windows.Forms.Label nodeInLB;
        private System.Windows.Forms.TextBox phaseTB;
        private System.Windows.Forms.TextBox magnitudeTB;
        private System.Windows.Forms.TextBox nodeOutTB;
        private System.Windows.Forms.TextBox nodeInTB;
        private System.Windows.Forms.Label phaseLB;
        private System.Windows.Forms.Label magnitudeLB;
        private System.Windows.Forms.GroupBox analysisGB;
        private System.Windows.Forms.GroupBox sourceGB;
        private System.Windows.Forms.TextBox fstopTB;
        private System.Windows.Forms.TextBox fstartTB;
        private System.Windows.Forms.TextBox numberOfPointsTB;
        private System.Windows.Forms.ComboBox variationCB;
        private System.Windows.Forms.Label fstopLB;
        private System.Windows.Forms.Label fstartLB;
        private System.Windows.Forms.Label numberOfPointsLB;
        private System.Windows.Forms.Label variationLB;
        private System.Windows.Forms.Button cancelBT;
        private System.Windows.Forms.TextBox plotNodesTB;
        private System.Windows.Forms.Label plotLB;
    }
}