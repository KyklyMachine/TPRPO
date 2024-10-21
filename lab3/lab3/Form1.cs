using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace lab3
{
   
    public partial class Form1 : Form
    {
        MiniList<CheckBox> v;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) { }


        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            v = new MiniList<CheckBox>();
            toolStripStatusLabel1.Text = "Список создан.";
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (v != null)
            {
                CheckBox vcb = new CheckBox();
                vcb.Appearance = Appearance.Button;
                vcb.FlatStyle = FlatStyle.Standard;
                vcb.Top = 50;
                vcb.Width = 30;
                vcb.Left = 40 * v.Append(vcb);
                vcb.Text = Convert.ToString(vcb.Left);
                this.panel1.Controls.Add(vcb);
                toolStripStatusLabel1.Text = "";
            }
            else toolStripStatusLabel1.Text = "Список не создан.";

        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            {
                if (v == null)
                {
                    toolStripStatusLabel1.Text = "Список пуст.";
                    return;
                }

                foreach (CheckBox checkBox in v)
                {
                    if (checkBox.Checked)
                    {
                        MessageBox.Show($"Флажок '{checkBox.Text}' установлен.");
                    }
                    else
                    {
                        MessageBox.Show($"Флажок '{checkBox.Text}' не установлен.");
                    }
                }

                toolStripStatusLabel1.Text = "Перебор кнопок завершен.";
            }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e){ }
    }

    

    
}
