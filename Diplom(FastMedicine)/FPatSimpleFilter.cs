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
    public partial class FPatSimpleFilter : Form
    {
        public FPatSimpleFilter()
        {
            InitializeComponent();
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

                GlobalVar.filtred_doc_id = context.Patients.Where(c => c.patient_name.StartsWith(textBox1.Text)).Select(c => c.patient_id).ToList();
                GlobalVar.doc_filtred = true;
                GlobalVar.needToUpdate_FPatientDataView = true;
                Close();

            }
            else
            {
                if (radioButton2.Checked)
                {

                    GlobalVar.filtred_doc_id = context.Identifiers.Where(c => c.medcard_number == numericUpDown1.Value).Select(c => c.patient_id).ToList();
                    GlobalVar.doc_filtred = true;
                    GlobalVar.needToUpdate_FPatientDataView = true;
                    Close();
                }
                else
                {
                    if (radioButton3.Checked)
                    {
                        GlobalVar.filtred_doc_id = context.Passports.Where(c => c.series == textBox2.Text && c.numbers == textBox3.Text).Select(c => c.patient_id).ToList();
                        GlobalVar.doc_filtred = true;
                        GlobalVar.needToUpdate_FPatientDataView = true;
                        Close();

                    }
                }
            }
        }

        private void FPatSimpleFilter_Load(object sender, EventArgs e)
        {

        }
    }
}
