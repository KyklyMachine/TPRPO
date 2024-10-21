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

    public class Node<T>
    {
        public T content;
        public Node<T> Next = null;
    }

    class MiniList<T>: IEnumerable<T>
    {

        static int num = 0;
        public Node<T> Top;
        public int Append(T s)
        {
            Node<T> p = new Node<T>();
            p.content = s;
            if (Top != null) p.Next = Top;
            Top = p;
            return num++;
        }
        public IEnumerator<T> GetEnumerator() => new MiniListEnum<T>(Top);
        IEnumerator IEnumerable.GetEnumerator() => new MiniListEnum<T>(Top);
    }


    class MiniListEnum<T> : IEnumerator<T>
    {
        public Node<T> Top;
        public Node<T> ENode;
        

        public MiniListEnum(Node<T> top)
        {
            Top = top;
            ENode = top;
        }

        public T Current
        {
            get
            {
                return ENode.content;
            }
        }

        object IEnumerator.Current => ENode.content;

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public bool MoveNext()
        {
            ENode = ENode.Next;   
            return ENode != null;
        }

        public void Reset()
        {
            ENode = Top;
        }
    }
}
