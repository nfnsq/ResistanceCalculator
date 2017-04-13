namespace View
{
    partial class ElementControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this._elementKind = new System.Windows.Forms.ComboBox();
            this._elementValue = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.valueLabel = new System.Windows.Forms.Label();
            this._nodesDirectionLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _elementKind
            // 
            this._elementKind.FormattingEnabled = true;
            this._elementKind.Items.AddRange(new object[] {
            "Resistor",
            "Capacitor",
            "Inductor"});
            this._elementKind.Location = new System.Drawing.Point(3, 3);
            this._elementKind.Name = "_elementKind";
            this._elementKind.Size = new System.Drawing.Size(121, 21);
            this._elementKind.TabIndex = 0;
            this._elementKind.SelectedIndexChanged += new System.EventHandler(this._elementKind_SelectedIndexChanged);
            // 
            // _elementValue
            // 
            this._elementValue.Location = new System.Drawing.Point(170, 3);
            this._elementValue.Name = "_elementValue";
            this._elementValue.Size = new System.Drawing.Size(61, 20);
            this._elementValue.TabIndex = 1;
            this._elementValue.Validating += new System.ComponentModel.CancelEventHandler(this._elementValue_Validating);
            this._elementValue.Validated += new System.EventHandler(this._elementValue_Validated);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(351, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(56, 20);
            this.textBox1.TabIndex = 2;
            // 
            // valueLabel
            // 
            this.valueLabel.AutoSize = true;
            this.valueLabel.Location = new System.Drawing.Point(130, 6);
            this.valueLabel.Name = "valueLabel";
            this.valueLabel.Size = new System.Drawing.Size(34, 13);
            this.valueLabel.TabIndex = 3;
            this.valueLabel.Text = "Value";
            // 
            // _nodesDirectionLabel
            // 
            this._nodesDirectionLabel.AutoSize = true;
            this._nodesDirectionLabel.Location = new System.Drawing.Point(237, 6);
            this._nodesDirectionLabel.Name = "_nodesDirectionLabel";
            this._nodesDirectionLabel.Size = new System.Drawing.Size(108, 13);
            this._nodesDirectionLabel.TabIndex = 4;
            this._nodesDirectionLabel.Text = "Nodes direction (a, b)";
            // 
            // ElementControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._nodesDirectionLabel);
            this.Controls.Add(this.valueLabel);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this._elementValue);
            this.Controls.Add(this._elementKind);
            this.Name = "ElementControl";
            this.Size = new System.Drawing.Size(416, 27);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox _elementKind;
        private System.Windows.Forms.TextBox _elementValue;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label valueLabel;
        private System.Windows.Forms.Label _nodesDirectionLabel;
    }
}
