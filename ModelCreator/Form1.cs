using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ModelCreator.Environment;
using System.Threading;
namespace ModelCreator
{
    public partial class Form1 : Form
    {

        private Graphics offGraph;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            Model.frm1 = this;
            Model.panel1 = this.panel1;
            Model.IsOn = true;
            string model = Model.createModel(int.Parse(numericUpDown1.Value.ToString()), int.Parse(numericUpDown2.Value.ToString()));
            Model.model = model;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Model.model = Model.getModel();
            ModelForm mf = new ModelForm();
            mf.Show();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            button1_Click(null, null);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Model.IsOn = false;
        }

        private void panel1_Click(object sender, EventArgs e)
        {
        }

        private void label3_MouseUp(object sender, MouseEventArgs e)
        {
            
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            label3.Text = e.X + ":" + e.Y;
            Model.HandleClick(e.X, e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            label3.Text = e.X + ":" + e.Y;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Model.zoomout = Model.zoomout ? false : true;
            linkLabel1.Text = Model.zoomout ? "Reinzoomen" : "Rauszoomen";
            Model.drawImage();
            Model.resize();
        }

    }
}
