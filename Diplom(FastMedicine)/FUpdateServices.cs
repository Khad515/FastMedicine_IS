﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diplom_FastMedicine_
{
    public partial class FUpdateServices : Form
    {
        public FUpdateServices()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FUpdateServices_Shown(object sender, EventArgs e)
        {
            switch (GlobalVar.selected_MedRowIndex)
            {
                case 1:
                    {
                        this.Text += "- наименование";
                        label2.Text = GlobalVar.selectedOld_value;
                        break;
                    }
                case 2:
                    {
                        this.Text += "- цены";
                        textBox1.Size = new Size(20, 21);
                        textBox1.Location = new Point(15, 169);
                        textBox1.Enabled = false;
                        textBox1.Visible = false;
                        numericUpDown1.Size = new Size(170, 20);
                        numericUpDown1.Location = new Point(110, 52);
                        numericUpDown1.Visible = true;
                        numericUpDown1.Enabled = true;
                        label2.Text = GlobalVar.selectedOld_value;
                        break;
                    }
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Medicine_Data data = new Medicine_Data();
            switch (GlobalVar.selected_MedRowIndex)
            {
                case 1:
                    {
                        data.UpdateServices_Name(GlobalVar.selected_docID, textBox1.Text);
                        MessageBox.Show("Запись успешно обновлена!", "База данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        GlobalVar.needToUpdate_FServices = true;
                        Close();
                        break;
                    }
                case 2:
                    {
                        data.UpdateServices_Price(GlobalVar.selected_docID, Convert.ToInt32(numericUpDown1.Value));
                        MessageBox.Show("Запись успешно обновлена!", "База данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        GlobalVar.needToUpdate_FServices = true;
                        Close();
                        break;
                    }
            };
        }

        private void FUpdateServices_Load(object sender, EventArgs e)
        {

        }
    }
}
