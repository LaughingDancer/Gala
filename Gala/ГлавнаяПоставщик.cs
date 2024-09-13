using Gala.Клиент;
using Gala.Поставщик;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gala
{
    public partial class ГлавнаяПоставщик : Form
    {
        public ГлавнаяПоставщик()
        {
            InitializeComponent();
            UC_ЗаказыПоставщик uc = new UC_ЗаказыПоставщик();
            addUserControl(uc);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void ГлавнаяПоставщик_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(70, 149, 151);
            panel2.BackColor = Color.FromArgb(70, 149, 151);
            panelContainer.BackColor = Color.FromArgb(255, 255, 255);
            this.BackColor = Color.FromArgb(229, 227, 228);
        }
        private void addUserControl(UserControl userControl)
        {
            panelContainer.Dock = DockStyle.Fill;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(userControl);
            userControl.BringToFront();
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            UC_ЗаказыПоставщик uc = new UC_ЗаказыПоставщик();
            addUserControl(uc);
        }
        private void guna2Button4_Click(object sender, EventArgs e)
        {
            UC_ТоварПоставщик uc = new UC_ТоварПоставщик();
            addUserControl(uc);
        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            UC_СкладПоставщик uc = new UC_СкладПоставщик();
            addUserControl(uc);
        }
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            ГлавнаяПоставщик.ActiveForm.Hide();
            Авторизация toRegistration = new Авторизация();
            toRegistration.ShowDialog();
            Close();
        }
    }
}
