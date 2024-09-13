using Gala.Таблицы;
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
    public partial class ГлавнаяАдмин : Form
    {
        public ГлавнаяАдмин()
        {
            InitializeComponent();
            UC_ДоговорА uc = new UC_ДоговорА();
            addUserControl(uc);
        }
        private void addUserControl(UserControl userControl)
        {
            panelContainer.Dock = DockStyle.Fill;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(userControl);
            userControl.BringToFront();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void ГлавнаяАдмин_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(70, 149, 151);
            panel2.BackColor = Color.FromArgb(70, 149, 151);
            this.BackColor = Color.FromArgb(229, 227, 228);
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            UC_ДоговорА uc = new UC_ДоговорА();
            addUserControl(uc);
        }
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            UC_ЗаказА uc = new UC_ЗаказА();
            addUserControl(uc);
        }
        private void guna2Button4_Click(object sender, EventArgs e)
        {
            UC_КлиентА uc = new UC_КлиентА();
            addUserControl(uc);
        }
        private void guna2Button5_Click(object sender, EventArgs e)
        {
            UC_ПользователиА uc = new UC_ПользователиА();
            addUserControl(uc);
        }
        private void guna2Button6_Click(object sender, EventArgs e)
        {
            UC_ПоставщикА uc = new UC_ПоставщикА();
            addUserControl(uc);
        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            UC_РолиА uc = new UC_РолиА();
            addUserControl(uc);
        }
        private void guna2Button7_Click(object sender, EventArgs e)
        {
            UC_СкладА uc = new UC_СкладА();
            addUserControl(uc);
        }
        private void guna2Button8_Click(object sender, EventArgs e)
        {
            UC_СотрудникиА uc = new UC_СотрудникиА();
            addUserControl(uc);
        }
        private void guna2Button9_Click(object sender, EventArgs e)
        {
            UC_ТоварА uc = new UC_ТоварА();
            addUserControl(uc);
        }
        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            UC_ЖурналИзменений uc = new UC_ЖурналИзменений();
            addUserControl(uc);
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ГлавнаяАдмин.ActiveForm.Hide();
            Авторизация toRegistration = new Авторизация();
            toRegistration.ShowDialog();
            Close();
        }
    }
}
