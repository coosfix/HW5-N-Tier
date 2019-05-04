using DataModel;
using MyClsLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyFomApp
{
    public partial class Form1 : Form
    {
        DataControlCls aa = new DataControlCls();

        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < aa.Getresult().Count; i++)
            {
                Button newbutton;

                this.flowLayoutPanel1.Controls.Add(
                    newbutton = new Button
                    {
                        Tag = aa.Getresult()[i].CategoriesID,
                        Text = aa.Getresult()[i].CategoriesName
                    });
                newbutton.Click += Newbutton_Click;
            }
        }

        private void Newbutton_Click(object sender, EventArgs e)
        {
            int id = (int)((Button)sender).Tag;
            dataGridView1.DataSource = aa.GetdataBy(id);
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            string name = ((TextBox)sender).Text;
            dataGridView1.DataSource = aa.GetdataBy(name);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (decimal.TryParse(this.minTextbox.Text, out decimal minresult) && decimal.TryParse(this.maxTextbox.Text, out decimal maxresult))
            {
                decimal max = maxresult;
                decimal min = minresult;
                dataGridView1.DataSource = aa.GetdataBy(min, max);
            }

        }
    }
}
