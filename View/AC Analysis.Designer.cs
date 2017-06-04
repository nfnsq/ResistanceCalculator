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
            this.analysisGB = new System.Windows.Forms.GroupBox();
            this.zedGraphControl = new ZedGraph.ZedGraphControl();
            this.btDraw = new System.Windows.Forms.Button();
            this.analysisGB.SuspendLayout();
            this.SuspendLayout();
            // 
            // analysisGB
            // 
            this.analysisGB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.analysisGB.Controls.Add(this.btDraw);
            this.analysisGB.Controls.Add(this.zedGraphControl);
            this.analysisGB.Location = new System.Drawing.Point(12, 12);
            this.analysisGB.Name = "analysisGB";
            this.analysisGB.Size = new System.Drawing.Size(935, 419);
            this.analysisGB.TabIndex = 0;
            this.analysisGB.TabStop = false;
            // 
            // zedGraphControl
            // 
            this.zedGraphControl.Location = new System.Drawing.Point(455, 19);
            this.zedGraphControl.Name = "zedGraphControl";
            this.zedGraphControl.ScrollGrace = 0D;
            this.zedGraphControl.ScrollMaxX = 0D;
            this.zedGraphControl.ScrollMaxY = 0D;
            this.zedGraphControl.ScrollMaxY2 = 0D;
            this.zedGraphControl.ScrollMinX = 0D;
            this.zedGraphControl.ScrollMinY = 0D;
            this.zedGraphControl.ScrollMinY2 = 0D;
            this.zedGraphControl.Size = new System.Drawing.Size(474, 394);
            this.zedGraphControl.TabIndex = 0;
            // 
            // btDraw
            // 
            this.btDraw.Location = new System.Drawing.Point(121, 365);
            this.btDraw.Name = "btDraw";
            this.btDraw.Size = new System.Drawing.Size(148, 30);
            this.btDraw.TabIndex = 1;
            this.btDraw.Text = "Draw Graph";
            this.btDraw.UseVisualStyleBackColor = true;
            this.btDraw.Click += new System.EventHandler(this.btDraw_Click);
            // 
            // AC_Analysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 443);
            this.Controls.Add(this.analysisGB);
            this.Name = "AC_Analysis";
            this.Text = "AC Analysis";
            this.analysisGB.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox analysisGB;
        private ZedGraph.ZedGraphControl zedGraphControl;
        private System.Windows.Forms.Button btDraw;
    }
}