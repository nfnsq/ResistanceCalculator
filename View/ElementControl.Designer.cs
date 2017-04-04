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
            this._elementValue.Location = new System.Drawing.Point(130, 3);
            this._elementValue.Name = "_elementValue";
            this._elementValue.Size = new System.Drawing.Size(100, 20);
            this._elementValue.TabIndex = 1;
            this._elementValue.TextChanged += new System.EventHandler(this._elementValue_TextChanged);
            this._elementValue.Validating += new System.ComponentModel.CancelEventHandler(this.DataValidating);
            // 
            // ElementControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._elementValue);
            this.Controls.Add(this._elementKind);
            this.Name = "ElementControl";
            this.Size = new System.Drawing.Size(235, 27);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox _elementKind;
        private System.Windows.Forms.TextBox _elementValue;
    }
}
