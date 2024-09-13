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
using System.Windows.Forms.DataVisualization.Charting;

namespace Gala.Таблицы
{
    public partial class UC_ЗаказМ : UserControl
    {
        private bool firstDropDown = true;
        private WordExporter wordExporter;
        private ExcelExporter excelExporter;
        public UC_ЗаказМ()
        {
            InitializeComponent();
            guna2ComboBox1.DropDown += guna2ComboBox1_DropDown;
            wordExporter = new WordExporter();
            excelExporter = new ExcelExporter();
            guna2RadioButton1.Enabled = false;
            guna2RadioButton2.Enabled = false;
            guna2RadioButton3.Enabled = false;
        }
        private void UC_ЗаказМ_Load(object sender, EventArgs e)
        {
            this.заказTableAdapter.Fill(this.нестеровКурсоваяDataSet.Заказ);
            chart.Series.Clear();
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
                    заказBindingSource.Filter = string.Empty;
                }
                else
                {
                    заказBindingSource.Filter = string.Format("{0}='{1}'",
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
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            CreateChart2(guna2DataGridView1, "Количество купленных товаров", " ");
            guna2RadioButton1.Enabled = true;
            guna2RadioButton2.Enabled = true;
            guna2RadioButton3.Enabled = true;
        }
        private void guna2RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            chart.Series[0].ChartType = SeriesChartType.Column;
        }
        private void guna2RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            chart.Series[0].ChartType = SeriesChartType.Pie;
        }
        private void guna2RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            chart.Series[0].ChartType = SeriesChartType.Bar;
        }
        private void CreateChart2(DataGridView grid, string nameTitle, string seriesName)
        {
            try
            {
                chart.Series.Clear();
                chart.Series.Add(seriesName);
                for (int i = 0; i < grid.RowCount; i++)
                {
                    var name = grid.Rows[i].Cells[2].Value?.ToString() ?? "";
                    var value = grid.Rows[i].Cells[3].Value?.ToString() ?? "";
                    chart.Series[seriesName].Points.AddXY(name, value);
                }
                chart.Titles.Clear();
                chart.Titles.Add(nameTitle);
                chart.ChartAreas[0].AxisX.Title = grid.Columns[2].HeaderText;
                chart.ChartAreas[0].AxisY.Title = grid.Columns[3].HeaderText;
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Ошибка: Недостаточно столбцов в DataGridView", "Ошибка");
            }
            catch (FormatException)
            {
                MessageBox.Show("Ошибка: недопустимые данные в DataGridView", "Ошибка");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message, "Ошибка");
            }
        }
    }
}
