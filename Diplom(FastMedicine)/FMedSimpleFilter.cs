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
    public partial class FMedSimpleFilter : Form
    {
        public FMedSimpleFilter()
        {
            InitializeComponent();
        }

        private void FMedSimpleFilter_Shown(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                groupBox1.Enabled = true;
                groupBox2.Enabled = false;
                groupBox3.Enabled = false;
                

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

                GlobalVar.filtred_doc_id = context.Preparations.Where(c => c.med_name.StartsWith(textBox1.Text)).Select(c => c.med_id).ToList();
                GlobalVar.doc_filtred = true;
                GlobalVar.needToUpdate_FMedications = true;
                Close();

            }
            else
            {
                if (radioButton2.Checked)
                {

                    GlobalVar.filtred_doc_id = context.Preparations.Where(c => c.med_code.StartsWith(textBox2.Text)).Select(c => c.med_id).ToList();
                    GlobalVar.doc_filtred = true;
                    GlobalVar.needToUpdate_FMedications = true;
                    Close();
                }
                else
                {
                    if (radioButton3.Checked)
                    {
                        GlobalVar.filtred_doc_id = context.Preparations.Where(c => c.med_count >= numericUpDown1.Value && c.med_count <= numericUpDown2.Value).Select(c => c.med_id).ToList();
                        GlobalVar.doc_filtred = true;
                        GlobalVar.needToUpdate_FMedications = true;
                        Close();

                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
