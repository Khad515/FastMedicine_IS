using System;
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
    public partial class FResSimpleFilter : Form
    {
        public FResSimpleFilter()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                groupBox1.Enabled = true;
                groupBox3.Enabled = false;
                groupBox2.Enabled = false;


            }
            else
            {
                if (radioButton2.Checked)
                {
                    groupBox2.Enabled = true;
                    groupBox1.Enabled = false;
                    groupBox3.Enabled = false;

                }
                else
                {
                    if (radioButton3.Checked)
                    {
                        groupBox3.Enabled = true;
                        groupBox2.Enabled = false;
                        groupBox1.Enabled = false;

                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MedicineContext context = new MedicineContext();
            GlobalVar gl = new GlobalVar();
            GlobalVar.filtred_doc_id.Clear();
            if (radioButton1.Checked)
            {

                GlobalVar.filtred_doc_id = context.Researches.Where(c => c.ins_name.StartsWith(textBox1.Text)).Select(c => c.ins_id).ToList();
                GlobalVar.doc_filtred = true;
                GlobalVar.needToUpdate_FResearches = true;
                Close();

            }
            else
            {
                if (radioButton2.Checked)
                {

                    GlobalVar.filtred_doc_id = context.Researches.Where(c => c.ins_countdays >= numericUpDown1.Value && c.ins_countdays <= numericUpDown2.Value).Select(c => c.ins_id).ToList();
                    GlobalVar.doc_filtred = true;
                    GlobalVar.needToUpdate_FResearches = true;
                    Close();
                }
                else
                {
                    if (radioButton3.Checked)
                    {
                        GlobalVar.filtred_doc_id = context.Researches.Where(c => c.ins_price >= numericUpDown3.Value && c.ins_price <= numericUpDown4.Value).Select(c => c.ins_id).ToList();
                        GlobalVar.doc_filtred = true;
                        GlobalVar.needToUpdate_FResearches = true;
                        Close();

                    }
                }
            }
        }
    }
}
