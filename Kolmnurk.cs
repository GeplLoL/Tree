using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.Design.AxImporter;

namespace Näiteks
{
    public partial class Kolmnurk : Form
    {
        Label lbl, lbl1, lbl2, lbl3, lbl4;
        PictureBox pb;
        Button btn, btn1;
        ListBox lb, lb1, lb21, lb22;
        TextBox tb1, tb2, tb3, tb4;
        RadioButton rb1, rb2, rb3;
        int j, j1 = 0;

        public Kolmnurk()
        {
            this.Height = 600;
            this.Width = 800;
            this.Text = "Kolmnurk";

            lbl = new Label();
            lbl.Text = "Kolmnurk";
            lbl.Location = new Point(0, 0);
            lbl.Size = new Size(this.Width, 50);
            lbl.BackColor = Color.LightGray;
            lbl.BorderStyle = BorderStyle.Fixed3D;
            lbl.Font = new Font("Tahoma", 24);
            lbl.TextAlign = ContentAlignment.MiddleCenter;



        private void ControlsAdd([Optional] Control[] arrayVisibleTrue, Control[] arrayVisibleFalse)
        {
            if (arrayVisibleTrue != null)
            {
                foreach (Control item in arrayVisibleTrue)
                {
                    this.Controls.Add(item);
                }
            }
            foreach (Control item in arrayVisibleFalse)
            {
                this.Controls.Add(item);
                item.Visible = false;
            }
        }
        }
    }
}
