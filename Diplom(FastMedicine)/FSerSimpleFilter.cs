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
    public partial class FSerSimpleFilter : Form
    {
        public FSerSimpleFilter()
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
                groupBox2.Enabled = false;


            }
            else
            {
                if (radioButton2.Checked)
                {
                    groupBox1.Enabled = false;
                    groupBox2.Enabled = true;

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

                GlobalVar.filtred_doc_id = context.Services.Where(c => c.service_name.StartsWith(textBox1.Text)).Select(c => c.service_id).ToList();
                GlobalVar.doc_filtred = true;
                GlobalVar.needToUpdate_FServices = true;
                Close();

            }
            else
            {
                if (radioButton2.Checked)
                {

                    GlobalVar.filtred_doc_id = context.Services.Where(c => c.service_price >= numericUpDown1.Value && c.service_price <= numericUpDown2.Value).Select(c => c.service_id).ToList();
                    GlobalVar.doc_filtred = true;
                    GlobalVar.needToUpdate_FServices = true;
                    Close();
                }
            }
        }
    }
}
