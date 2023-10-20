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

public partial class FarmTree : Form
{
    TreeView tree;
    Button btn, btn1, btn2;
    TreeNode tn = new TreeNode("Elemendid");
    Label lbl;
    TextBox txt_box;
    RadioButton r1, r2;
    CheckBox c1, c2;
    PictureBox pb, star, cute;
    ListBox lb;
    DataGridView dgv;
    Kolmnurk kolmnurk;
     double i = 0;
    public FarmTree()
    {
        this.Height = 600;
        this.Width = 800;
        this.Text = "Vorm põhielementidega";
        tree = new TreeView();
        tree.Dock = DockStyle.Top;
        tree.BorderStyle = BorderStyle.Fixed3D;
        tree.AfterSelect += Tree_AfterSelect;



        tn.Nodes.Add(new TreeNode("Nupp-Button"));
        btn = new Button();
        btn.Height = 50;
        btn.Width = 100;
        btn.Text = "Valjuta mind!";
        btn.Location = new Point(400, 200);
        btn.Click += Btn_Click;
        btn.MouseHover += Btn_MouseHover;
        btn.MouseLeave += Btn_MouseLeave;




        tn.Nodes.Add("Silt-Label");
        lbl = new Label();
        lbl.Text = "Pealkiri";
        lbl.Location = new Point(0, tree.Bottom);
        lbl.Size = new Size(this.Width, btn.Top - tree.Bottom);
        lbl.BackColor = Color.LightGray;
        lbl.BorderStyle = BorderStyle.Fixed3D;
        lbl.Font = new Font("Tahoma", 24);
        tree.Nodes.Add(tn);




        tn.Nodes.Add(new TreeNode("Textbox"));
        txt_box = new TextBox();
        txt_box.Height = 50;
        txt_box.Width = 100;
        txt_box.Text = "...";
        txt_box.Location = new Point(btn.Left, btn.Top + btn.Height + 20);
        txt_box.KeyDown += new KeyEventHandler(Txt_box_KeyDown);



        tn.Nodes.Add(new TreeNode("Radiobutton"));
        r1 = new RadioButton();
        r1.Text = "2 variante";
        r1.Location = new Point(btn.Left - 120, btn.Top);
        r1.CheckedChanged += new EventHandler(RadioButtons_Changed);
        r2 = new RadioButton();
        r2.Text = "1 variante";
        r2.Location = new Point(r1.Left, r1.Top + r1.Height);
        r2.CheckedChanged += new EventHandler(RadioButtons_Changed);

        tn.Nodes.Add(new TreeNode("Valik-Checkbox"));
        c1 = new CheckBox();
        c1.Text = "0";
        c1.Location = new Point(r1.Left - 120, r1.Top);
        c1.CheckedChanged += C_CheckedChanged;
        c2 = new CheckBox();
        c2.Text = "0";
        c2.Location = new Point(c1.Left, c1.Top + c1.Height);
        c2.CheckedChanged += C_CheckedChanged;

        btn1 = new Button();
        btn1.Height = 50;
        btn1.Width = 100;
        btn1.Text = "info";
        btn1.Location = new Point(c2.Left - 20, c2.Bottom);
        btn1.Click += Btn1_Click;

        tn.Nodes.Add(new TreeNode("Pilt-Image"));
        pb = new PictureBox();
        pb.Location = new Point(btn.Right + 50, btn.Top);
        pb.Image = new Bitmap("../../../Cute.jpg");
        pb.Size = new Size(100, 100);
        pb.SizeMode = PictureBoxSizeMode.Zoom;
        pb.BorderStyle = BorderStyle.Fixed3D;

        cute = new PictureBox();
        cute.Location = new Point(pb.Location.X, pb.Location.Y);
        cute.Image = new Bitmap("../../../Cute.jpg");
        cute.Size = new Size(100, 100);
        cute.SizeMode = PictureBoxSizeMode.Zoom;

        star = new PictureBox();
        star.Location = new Point(pb.Location.X, pb.Location.Y);
        star.Image = new Bitmap("../../../Cute.jpg");
        star.Size = new Size(100, 100);
        star.SizeMode = PictureBoxSizeMode.Zoom;

        tn.Nodes.Add(new TreeNode("Listbox"));
        lb = new ListBox();
        lb.Height = 20;
        lb.Location = new Point(c1.Left - 150, c1.Top);

        btn2 = new Button();
        btn2.Height = 50;
        btn2.Width = lb.Width;
        btn2.Text = "Lisa";
        btn2.Location = new Point(lb.Left, lb.Bottom);
        btn2.Click += Btn2_Click;

        lb.KeyDown += Lb_KeyDown;

        tn.Nodes.Add(new TreeNode("Tabel"));
        DataSet ds = new DataSet("XML fail. Menüü");
        ds.ReadXml(@"..\..\..\food.xml");
        dgv = new DataGridView();
        dgv.Location = new Point(0, pb.Bottom + 70);
        dgv.AutoSize = true;
        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgv.DataSource = ds;
        dgv.AutoGenerateColumns = true;
        dgv.DataMember = "food";

        tn.Nodes.Add(new TreeNode("Kolmnurk"));


            ControlsAdd(new Control[] { tree },
        new Control[] { 
            btn, 
            lbl, 
            txt_box, 
            r1, 
            r2, 
            c1, 
            c2, 
            pb, 
            cute, 
            star, 
            btn1, 
            lb, 
            btn2, 
            dgv });
    }

    private void Lb_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Delete)
        {
            if (lb.SelectedItem != null)
            {
                lb.Items.Remove(lb.SelectedItem);
                if (lb.Items.Count < 9)
                {
                    lb.Height -= 20;
                    lb.Height += 20;
                    btn2.Location = new Point(lb.Left, lb.Bottom);
                }
            }
        }
    }

        private void Btn2_Click(object? sender, EventArgs e)
    {
        string tekst = Interaction.InputBox("Lisa uus väli", "Pealkiri muutmine", "Väli");
        if (tekst.Length > 0 && !lb.Items.Contains(tekst))
        {
            lb.Items.Add(tekst);
            if (lb.Height <= 150)
            {
                lb.Height += 20;
                btn2.Location = new Point(lb.Left, lb.Bottom);
            }
        }
    }

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

    private void Btn1_Click(object? sender, EventArgs e)
    {
        DialogResult result = MessageBox.Show("Kas kõik on korras", "Küsimus", MessageBoxButtons.OKCancel);
        if (result == DialogResult.OK)
        {
            if (c1.Checked == true && c2.Checked == true)
            {
                btn1.Text = "True";
                txt_box.Enabled = true;
            }
            else if (c2.Checked == true)
            {
                btn1.Text = "False";
                txt_box.Enabled = false;
            }
            else if (c1.Checked == true)
            {
                btn1.Text = "False";
                txt_box.Enabled = false;
            }
            else
            {
                btn1.Text = "False";
                txt_box.Enabled = false;
            }
        }
        else
        {
            btn1.Text = "nfo";
        }
    }

    private void Txt_box_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            DialogResult result = MessageBox.Show("Kas kõik on korras", "Küsimus", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (txt_box.Text.ToLower() == "cate")
                {
                    pb.Visible = false;
                    star.Visible = false;
                    cute.Visible = true;
                }
                else if (txt_box.Text.ToLower() == "home")
                {
                    pb.Visible = false;
                    cute.Visible = false;
                    star.Visible = true;
                }
                else
                {
                    cute.Visible = false;
                    star.Visible = false;
                }
            }
            else
            {
                string tekst = Interaction.InputBox("Sise", "muutmine", "Uus");
                if (tekst.Length > 0)
                {
                    this.Text = tekst;
                }
            }
        }
    }

    private void C_CheckedChanged(object? sender, EventArgs e)
    {
        if (c1.Checked == true && c2.Checked == true)
        {
            c1.Text = "1";
            c2.Text = "1";
        }
        else if (c2.Checked == true)
        {
            c1.Text = "0";
            c2.Text = "1";


        }
        else if (c1.Checked == true)
        {
            c1.Text = "1";
            c2.Text = "0";
        }
        else
        {
            c1.Text = "0";
            c2.Text = "0";
        }
    }

    private void RadioButtons_Changed(object? sender, EventArgs e)
    {
        if (r1.Checked == true)
        {
            r1.BackColor = Color.Red;
            r1.ForeColor = Color.Green;
            r2.BackColor = Color.Green;
            r2.ForeColor = Color.Red;
        }
        else
        {
            r2.BackColor = Color.Red;
            r2.ForeColor = Color.Green;
            r1.BackColor = Color.Green;
            r1.ForeColor = Color.Red;
        }
    }

    private void Btn_MouseWheel(object? sender, MouseEventArgs e)
    {
        i += 1;
        btn.Text = "Click!\n" + i;
    }

    private void Tree_AfterSelect(object? sender, TreeViewEventArgs e)
    {
        if (e.Node.Text == "Nupp-Button")
        {
            if (btn.Visible == false)
            {
                btn.Visible = true;
            }
            else
            {
                btn.Visible = false;
            }
        }
        else if (e.Node.Text == "Silt-Label")
        {
            if (lbl.Visible == false)
            {
                lbl.Visible = true;
            }
            else
            {
                lbl.Visible = false;
            }
        }
        else if (e.Node.Text == "Textbox")
        {
            if (txt_box.Visible == false)
            {
                txt_box.Visible = true;
            }
            else
            {
                txt_box.Visible = false;
            }
        }
        else if (e.Node.Text == "Radiobutton")
        {
            if (r1.Visible == false)
            {
                r1.Visible = true;
                r2.Visible = true;
            }
            else
            {
                r1.Visible = false;
                r2.Visible = false;
            }
        }
        else if (e.Node.Text == "Pilt-Image")
        {
            if (pb.Visible == false)
            {
                pb.Visible = true;
            }
            else
            {
                pb.Visible = false;
            }
        }
        else if (e.Node.Text == "Listbox")
        {
            if (lb.Visible == false)
            {
                lb.Visible = true;
                btn2.Visible = true;
            }
            else
            {
                lb.Visible = false;
                btn2.Visible = false;
            }
        }
        else if (e.Node.Text == "Tabel")
        {
            if (dgv.Visible == false)
            {
                dgv.Visible = true;
            }
            else
            {
                dgv.Visible = false;
            }
        }
        else if (e.Node.Text == "Valik-Checkbox")
        {
            if (c1.Visible == false)
            {
                c1.Visible = true;
                c2.Visible = true;
                btn1.Visible = true;
            }
            else
            {
                c1.Visible = false;
                c2.Visible = false;
                btn1.Visible = false;
            }
        }
        else if (e.Node.Text == "Kolmnurk")
        {
            kolmnurk = new Kolmnurk();
            kolmnurk.Show();
        }
        tree.SelectedNode = null;
        tree.SelectedNode = null;
    }
    private void Btn_Click(object? sender, EventArgs e)
    {
        if (btn.BackColor == Color.Aqua)
        {
            btn.BackColor = Color.Chocolate;
        }
        else
        {
            btn.BackColor = Color.Aqua;
        }
    }

    private void Btn_MouseHover(object? sender, EventArgs e)
    {
        btn.Text = "Your mouse on button";
        btn.BackColor = Color.Aqua;
        btn.Height = 60;
        btn.Width = 150;
    }

    private void Btn_MouseLeave(object? sender, EventArgs e)
    {
        btn.Text = "Valjuta mind!";
        btn.BackColor = Color.White;
        btn.Height = 40;
        btn.Width = 100;
    }

    }
}