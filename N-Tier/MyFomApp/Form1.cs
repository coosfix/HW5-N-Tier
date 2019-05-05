using CircularButton;
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

        public Form1()
        {
            InitializeComponent();
        }

        private void Newbutton_Click(object sender, EventArgs e)
        {
            int id = (int)((MyButton)sender).Tag;
            dataGridView1.DataSource = DataControlCls.GetdataBy(id);
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            string name = ((TextBox)sender).Text;
            dataGridView1.DataSource = DataControlCls.GetdataBy(name);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (decimal.TryParse(this.minTextbox.Text, out decimal minresult) && decimal.TryParse(this.maxTextbox.Text, out decimal maxresult))
            {
                decimal max = maxresult;
                decimal min = minresult;
                dataGridView1.DataSource = DataControlCls.GetdataBy(min, max);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataControlCls data = new DataControlCls();
            for (int i = 0; i < data.Getresult().Count; i++)
            {
                MyButton newbutton;

                this.flowLayoutPanel1.Controls.Add(
                    newbutton = new MyButton
                    {
                        Tag = data.Getresult()[i].CategoriesID,
                        Text = data.Getresult()[i].CategoriesName,
                        顏色 = Color.Red,
                        點擊顏色 = Color.Purple,
                        形狀 = MyButton.Fillstyle.Ellipse
                    });
                newbutton.Click += Newbutton_Click;
            }
        }
    }
}
