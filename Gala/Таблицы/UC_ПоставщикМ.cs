using Gala.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gala.Таблицы
{
    public partial class UC_ПоставщикМ : UserControl
    {
        private bool firstDropDown = true;
        private WordExporter wordExporter;
        private ExcelExporter excelExporter;
        public UC_ПоставщикМ()
        {
            InitializeComponent();
            guna2ComboBox1.DropDown += guna2ComboBox1_DropDown;
            wordExporter = new WordExporter();
            excelExporter = new ExcelExporter();
        }
        private void UC_ПоставщикМ_Load(object sender, EventArgs e)
        {
            this.поставщикTableAdapter.Fill(this.нестеровКурсоваяDataSet.Поставщик);
        }
        private void guna2ComboBox1_DropDown(object sender, EventArgs e)
        {
            if (firstDropDown && guna2ComboBox1.Items.Count > 0)
            {
                guna2ComboBox1.Items.RemoveAt(0);
                firstDropDown = false;
            }
        }
        private void guna2TextBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (string.IsNullOrEmpty(guna2TextBoxSearch.Text))
                {
                    поставщикBindingSource.Filter = string.Empty;
                }
                else
                {
                    поставщикBindingSource.Filter = string.Format("{0}='{1}'",
                        guna2ComboBox1.Text, guna2TextBoxSearch.Text);
                }
            }
        }
        private void guna2Button18_Click(object sender, EventArgs e)
        {
            wordExporter.WordExport(guna2DataGridView1);
        }
        private void guna2Button6_Click(object sender, EventArgs e)
        {
            excelExporter.ExportExcel(guna2DataGridView1);
        }
    }
}
