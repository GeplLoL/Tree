using System;
using System.Windows.Forms;

namespace Näiteks
{
    class TriangleForm : Form
    {
        Button btn1;

        public TriangleForm()
        {
            Height = 200;
            Width = 200;

            btn1 = new Button();
            btn1.Text = "Запуск";
            btn1.Click += Btn_Click;
            Controls.Add(btn1);
        }

        private void Btn_Click(object? sender, EventArgs e)
        {
            TriangleForm form1 = new TriangleForm();
            form1.ShowDialog();
        }
    }
}
