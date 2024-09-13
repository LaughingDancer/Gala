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
    public partial class ГлавнаяМенеджер : Form
    {
        public ГлавнаяМенеджер()
        {
            InitializeComponent();
            UC_ДоговорМ uc = new UC_ДоговорМ();
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
        private void ГлавнаяМенеджер_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(70, 149, 151);
            panel2.BackColor = Color.FromArgb(70, 149, 151);
            this.BackColor = Color.FromArgb(229, 227, 228);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            UC_ДоговорМ uc = new UC_ДоговорМ();
            addUserControl(uc);
        }
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            UC_ЗаказМ uc = new UC_ЗаказМ();
            addUserControl(uc);
        }
        private void guna2Button4_Click(object sender, EventArgs e)
        {
            UC_КлиентМ uc = new UC_КлиентМ();
            addUserControl(uc);
        }
        private void guna2Button8_Click(object sender, EventArgs e)
        {
            UC_СотрудникиМ uc = new UC_СотрудникиМ();
            addUserControl(uc);
        }
        private void guna2Button7_Click(object sender, EventArgs e)
        {
            UC_СкладМ uc = new UC_СкладМ();
            addUserControl(uc);
        }
        private void guna2Button9_Click(object sender, EventArgs e)
        {
            UC_ТоварМ uc = new UC_ТоварМ();
            addUserControl(uc);
        }
        private void guna2Button6_Click(object sender, EventArgs e)
        {
            UC_ПоставщикМ uc = new UC_ПоставщикМ();
            addUserControl(uc);
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ГлавнаяМенеджер.ActiveForm.Hide();
            Авторизация toRegistration = new Авторизация();
            toRegistration.ShowDialog();
            Close();
        }
    }
}
