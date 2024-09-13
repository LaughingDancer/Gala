namespace Gala.Клиент
{
    partial class UC_Главная
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
            this.textBoxQuantity = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.comboBoxProducts = new Guna.UI2.WinForms.Guna2ComboBox();
            this.comboBoxSuppliers = new Guna.UI2.WinForms.Guna2ComboBox();
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxStockQuantity = new Guna.UI2.WinForms.Guna2TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxPrice = new Guna.UI2.WinForms.Guna2TextBox();
            this.textBoxDescription = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxQuantity
            // 
            this.textBoxQuantity.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(161)))), ((int)(((byte)(153)))));
            this.textBoxQuantity.BorderRadius = 5;
            this.textBoxQuantity.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxQuantity.DefaultText = "";
            this.textBoxQuantity.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.textBoxQuantity.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.textBoxQuantity.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textBoxQuantity.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textBoxQuantity.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(190)))), ((int)(((byte)(170)))));
            this.textBoxQuantity.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.textBoxQuantity.ForeColor = System.Drawing.Color.Black;
            this.textBoxQuantity.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(190)))), ((int)(((byte)(170)))));
            this.textBoxQuantity.Location = new System.Drawing.Point(51, 173);
            this.textBoxQuantity.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxQuantity.Name = "textBoxQuantity";
            this.textBoxQuantity.PasswordChar = '\0';
            this.textBoxQuantity.PlaceholderText = "";
            this.textBoxQuantity.SelectedText = "";
            this.textBoxQuantity.Size = new System.Drawing.Size(292, 40);
            this.textBoxQuantity.TabIndex = 42;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(508, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 20);
            this.label1.TabIndex = 43;
            this.label1.Text = "Выберите продукцию:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(47, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(200, 20);
            this.label2.TabIndex = 44;
            this.label2.Text = "Выберите поставщика";
            // 
            // guna2Button1
            // 
            this.guna2Button1.BorderRadius = 5;
            this.guna2Button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(161)))), ((int)(((byte)(153)))));
            this.guna2Button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Location = new System.Drawing.Point(512, 173);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(266, 40);
            this.guna2Button1.TabIndex = 61;
            this.guna2Button1.Text = "Заказать";
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // comboBoxProducts
            // 
            this.comboBoxProducts.BackColor = System.Drawing.Color.Transparent;
            this.comboBoxProducts.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(161)))), ((int)(((byte)(153)))));
            this.comboBoxProducts.BorderRadius = 5;
            this.comboBoxProducts.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxProducts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxProducts.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(190)))), ((int)(((byte)(170)))));
            this.comboBoxProducts.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(190)))), ((int)(((byte)(170)))));
            this.comboBoxProducts.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.comboBoxProducts.ForeColor = System.Drawing.Color.Black;
            this.comboBoxProducts.ItemHeight = 25;
            this.comboBoxProducts.Location = new System.Drawing.Point(512, 93);
            this.comboBoxProducts.Name = "comboBoxProducts";
            this.comboBoxProducts.Size = new System.Drawing.Size(266, 31);
            this.comboBoxProducts.TabIndex = 62;
            this.comboBoxProducts.SelectedIndexChanged += new System.EventHandler(this.comboBoxProducts_SelectedIndexChanged);
            // 
            // comboBoxSuppliers
            // 
            this.comboBoxSuppliers.BackColor = System.Drawing.Color.Transparent;
            this.comboBoxSuppliers.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(161)))), ((int)(((byte)(153)))));
            this.comboBoxSuppliers.BorderRadius = 5;
            this.comboBoxSuppliers.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxSuppliers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSuppliers.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(190)))), ((int)(((byte)(170)))));
            this.comboBoxSuppliers.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(190)))), ((int)(((byte)(170)))));
            this.comboBoxSuppliers.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.comboBoxSuppliers.ForeColor = System.Drawing.Color.Black;
            this.comboBoxSuppliers.ItemHeight = 25;
            this.comboBoxSuppliers.Location = new System.Drawing.Point(51, 93);
            this.comboBoxSuppliers.Name = "comboBoxSuppliers";
            this.comboBoxSuppliers.Size = new System.Drawing.Size(292, 31);
            this.comboBoxSuppliers.TabIndex = 63;
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(190)))), ((int)(((byte)(170)))));
            this.guna2GroupBox1.BorderRadius = 10;
            this.guna2GroupBox1.BorderThickness = 2;
            this.guna2GroupBox1.Controls.Add(this.label6);
            this.guna2GroupBox1.Controls.Add(this.textBoxStockQuantity);
            this.guna2GroupBox1.Controls.Add(this.label5);
            this.guna2GroupBox1.Controls.Add(this.label4);
            this.guna2GroupBox1.Controls.Add(this.label3);
            this.guna2GroupBox1.Controls.Add(this.textBoxPrice);
            this.guna2GroupBox1.Controls.Add(this.textBoxDescription);
            this.guna2GroupBox1.Controls.Add(this.label1);
            this.guna2GroupBox1.Controls.Add(this.guna2Button1);
            this.guna2GroupBox1.Controls.Add(this.comboBoxProducts);
            this.guna2GroupBox1.Controls.Add(this.comboBoxSuppliers);
            this.guna2GroupBox1.Controls.Add(this.textBoxQuantity);
            this.guna2GroupBox1.Controls.Add(this.label2);
            this.guna2GroupBox1.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(190)))), ((int)(((byte)(170)))));
            this.guna2GroupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.guna2GroupBox1.ForeColor = System.Drawing.Color.Black;
            this.guna2GroupBox1.Location = new System.Drawing.Point(3, 3);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.Size = new System.Drawing.Size(825, 434);
            this.guna2GroupBox1.TabIndex = 64;
            this.guna2GroupBox1.Text = "Оформление заказа";
            this.guna2GroupBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(47, 326);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 20);
            this.label6.TabIndex = 70;
            this.label6.Text = "В наличии";
            // 
            // textBoxStockQuantity
            // 
            this.textBoxStockQuantity.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(161)))), ((int)(((byte)(153)))));
            this.textBoxStockQuantity.BorderRadius = 5;
            this.textBoxStockQuantity.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxStockQuantity.DefaultText = "";
            this.textBoxStockQuantity.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(161)))), ((int)(((byte)(153)))));
            this.textBoxStockQuantity.DisabledState.FillColor = System.Drawing.Color.White;
            this.textBoxStockQuantity.DisabledState.ForeColor = System.Drawing.Color.Black;
            this.textBoxStockQuantity.DisabledState.PlaceholderForeColor = System.Drawing.Color.Black;
            this.textBoxStockQuantity.Enabled = false;
            this.textBoxStockQuantity.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(190)))), ((int)(((byte)(170)))));
            this.textBoxStockQuantity.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.textBoxStockQuantity.ForeColor = System.Drawing.Color.Black;
            this.textBoxStockQuantity.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(190)))), ((int)(((byte)(170)))));
            this.textBoxStockQuantity.Location = new System.Drawing.Point(51, 350);
            this.textBoxStockQuantity.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxStockQuantity.Name = "textBoxStockQuantity";
            this.textBoxStockQuantity.PasswordChar = '\0';
            this.textBoxStockQuantity.PlaceholderText = "";
            this.textBoxStockQuantity.SelectedText = "";
            this.textBoxStockQuantity.Size = new System.Drawing.Size(292, 40);
            this.textBoxStockQuantity.TabIndex = 69;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(508, 248);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 20);
            this.label5.TabIndex = 68;
            this.label5.Text = "Цена";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(47, 248);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 20);
            this.label4.TabIndex = 67;
            this.label4.Text = "Описание";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(47, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(197, 20);
            this.label3.TabIndex = 66;
            this.label3.Text = "Выберите количество";
            // 
            // textBoxPrice
            // 
            this.textBoxPrice.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(161)))), ((int)(((byte)(153)))));
            this.textBoxPrice.BorderRadius = 5;
            this.textBoxPrice.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxPrice.DefaultText = "";
            this.textBoxPrice.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(161)))), ((int)(((byte)(153)))));
            this.textBoxPrice.DisabledState.FillColor = System.Drawing.Color.White;
            this.textBoxPrice.DisabledState.ForeColor = System.Drawing.Color.Black;
            this.textBoxPrice.DisabledState.PlaceholderForeColor = System.Drawing.Color.Black;
            this.textBoxPrice.Enabled = false;
            this.textBoxPrice.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(190)))), ((int)(((byte)(170)))));
            this.textBoxPrice.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.textBoxPrice.ForeColor = System.Drawing.Color.Black;
            this.textBoxPrice.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(190)))), ((int)(((byte)(170)))));
            this.textBoxPrice.Location = new System.Drawing.Point(512, 272);
            this.textBoxPrice.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxPrice.Name = "textBoxPrice";
            this.textBoxPrice.PasswordChar = '\0';
            this.textBoxPrice.PlaceholderText = "";
            this.textBoxPrice.SelectedText = "";
            this.textBoxPrice.Size = new System.Drawing.Size(266, 40);
            this.textBoxPrice.TabIndex = 65;
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(161)))), ((int)(((byte)(153)))));
            this.textBoxDescription.BorderRadius = 5;
            this.textBoxDescription.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxDescription.DefaultText = "";
            this.textBoxDescription.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(161)))), ((int)(((byte)(153)))));
            this.textBoxDescription.DisabledState.FillColor = System.Drawing.Color.White;
            this.textBoxDescription.DisabledState.ForeColor = System.Drawing.Color.Black;
            this.textBoxDescription.DisabledState.PlaceholderForeColor = System.Drawing.Color.Black;
            this.textBoxDescription.Enabled = false;
            this.textBoxDescription.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(190)))), ((int)(((byte)(170)))));
            this.textBoxDescription.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.textBoxDescription.ForeColor = System.Drawing.Color.Black;
            this.textBoxDescription.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(190)))), ((int)(((byte)(170)))));
            this.textBoxDescription.Location = new System.Drawing.Point(51, 272);
            this.textBoxDescription.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.PasswordChar = '\0';
            this.textBoxDescription.PlaceholderText = "";
            this.textBoxDescription.SelectedText = "";
            this.textBoxDescription.Size = new System.Drawing.Size(292, 40);
            this.textBoxDescription.TabIndex = 64;
            // 
            // UC_Главная
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.guna2GroupBox1);
            this.Name = "UC_Главная";
            this.Size = new System.Drawing.Size(831, 440);
            this.Load += new System.EventHandler(this.UC_Главная_Load);
            this.guna2GroupBox1.ResumeLayout(false);
            this.guna2GroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox textBoxQuantity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2ComboBox comboBoxProducts;
        private Guna.UI2.WinForms.Guna2ComboBox comboBoxSuppliers;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private Guna.UI2.WinForms.Guna2TextBox textBoxPrice;
        private Guna.UI2.WinForms.Guna2TextBox textBoxDescription;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2TextBox textBoxStockQuantity;
        private System.Windows.Forms.Label label6;
    }
}
