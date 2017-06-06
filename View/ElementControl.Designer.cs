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
            this._nodeIn = new System.Windows.Forms.TextBox();
            this.valueLabel = new System.Windows.Forms.Label();
            this._nodesDirectionLabel = new System.Windows.Forms.Label();
            this._nodeOut = new System.Windows.Forms.TextBox();
            this.nodeOutLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _elementKind
            // 
            this._elementKind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
            this._elementValue.MaxLength = 8;
            this._elementValue.Name = "_elementValue";
            this._elementValue.Size = new System.Drawing.Size(61, 20);
            this._elementValue.TabIndex = 1;
            this._elementValue.TextChanged += new System.EventHandler(this.DoubleTextChanged);
            this._elementValue.Validating += new System.ComponentModel.CancelEventHandler(this.TextBoxValidating);
            this._elementValue.Validated += new System.EventHandler(this.TextBoxValidated);
            // 
            // _nodeIn
            // 
            this._nodeIn.Location = new System.Drawing.Point(339, 3);
            this._nodeIn.MaxLength = 2;
            this._nodeIn.Name = "_nodeIn";
            this._nodeIn.Size = new System.Drawing.Size(18, 20);
            this._nodeIn.TabIndex = 2;
            this._nodeIn.TextChanged += new System.EventHandler(this.IntTextChanged);
            this._nodeIn.Validating += new System.ComponentModel.CancelEventHandler(this.TextBoxValidating);
            this._nodeIn.Validated += new System.EventHandler(this.TextBoxValidated);
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
            this._nodesDirectionLabel.Size = new System.Drawing.Size(102, 13);
            this._nodesDirectionLabel.TabIndex = 4;
            this._nodesDirectionLabel.Text = "Nodes direction, In -";
            // 
            // _nodeOut
            // 
            this._nodeOut.Location = new System.Drawing.Point(393, 3);
            this._nodeOut.MaxLength = 2;
            this._nodeOut.Name = "_nodeOut";
            this._nodeOut.Size = new System.Drawing.Size(18, 20);
            this._nodeOut.TabIndex = 5;
            this._nodeOut.TextChanged += new System.EventHandler(this.IntTextChanged);
            this._nodeOut.Validating += new System.ComponentModel.CancelEventHandler(this.TextBoxValidating);
            this._nodeOut.Validated += new System.EventHandler(this.TextBoxValidated);
            // 
            // nodeOutLabel
            // 
            this.nodeOutLabel.AutoSize = true;
            this.nodeOutLabel.Location = new System.Drawing.Point(363, 6);
            this.nodeOutLabel.Name = "nodeOutLabel";
            this.nodeOutLabel.Size = new System.Drawing.Size(30, 13);
            this.nodeOutLabel.TabIndex = 6;
            this.nodeOutLabel.Text = "Out -";
            // 
            // ElementControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.nodeOutLabel);
            this.Controls.Add(this._nodeOut);
            this.Controls.Add(this._nodesDirectionLabel);
            this.Controls.Add(this.valueLabel);
            this.Controls.Add(this._nodeIn);
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
        private System.Windows.Forms.TextBox _nodeIn;
        private System.Windows.Forms.Label valueLabel;
        private System.Windows.Forms.Label _nodesDirectionLabel;
        private System.Windows.Forms.TextBox _nodeOut;
        private System.Windows.Forms.Label nodeOutLabel;
    }
}
