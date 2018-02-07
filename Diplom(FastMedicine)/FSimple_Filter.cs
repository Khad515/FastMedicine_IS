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
    public partial class FSimple_Filter : Form
    {
        public FSimple_Filter()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FSimple_Filter_Shown(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            comboBox2.SelectedIndex = 0;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            comboBox2.SelectedIndex = 0;
            if (radioButton1.Checked)
            {
                groupBox1.Enabled = true;
                groupBox2.Enabled = false;
                groupBox3.Enabled = false;
                groupBox4.Enabled = false;
                groupBox5.Enabled = false;
                groupBox6.Enabled = false;
                groupBox7.Enabled = false;
                groupBox8.Enabled = false;

            }
            else
            {
                if (radioButton2.Checked)
                {
                    groupBox2.Enabled = true;
                    groupBox1.Enabled = false;
                    groupBox3.Enabled = false;
                    groupBox4.Enabled = false;
                    groupBox5.Enabled = false;
                    groupBox6.Enabled = false;
                    groupBox7.Enabled = false;
                    groupBox8.Enabled = false;
                }
                else
                {
                    if (radioButton3.Checked)
                    {
                        groupBox3.Enabled = true;
                        groupBox2.Enabled = false;
                        groupBox1.Enabled = false;
                        groupBox4.Enabled = false;
                        groupBox5.Enabled = false;
                        groupBox6.Enabled = false;
                        groupBox7.Enabled = false;
                        groupBox8.Enabled = false;

                    }
                    else
                    {
                        if (radioButton4.Checked)
                        {
                            groupBox4.Enabled = true;
                            groupBox2.Enabled = false;
                            groupBox3.Enabled = false;
                            groupBox1.Enabled = false;
                            groupBox5.Enabled = false;
                            groupBox6.Enabled = false;
                            groupBox7.Enabled = false;
                            groupBox8.Enabled = false;
                        }
                        else
                        {
                            if (radioButton5.Checked)
                            {
                                groupBox5.Enabled = true;
                                groupBox2.Enabled = false;
                                groupBox3.Enabled = false;
                                groupBox4.Enabled = false;
                                groupBox1.Enabled = false;
                                groupBox6.Enabled = false;
                                groupBox7.Enabled = false;
                                groupBox8.Enabled = false;
                            }
                            else
                            {
                                if (radioButton6.Checked)
                                {
                                    groupBox6.Enabled = true;
                                    groupBox2.Enabled = false;
                                    groupBox3.Enabled = false;
                                    groupBox4.Enabled = false;
                                    groupBox5.Enabled = false;
                                    groupBox1.Enabled = false;
                                    groupBox7.Enabled = false;
                                    groupBox8.Enabled = false;
                                }
                                else
                                {
                                    if (radioButton7.Checked)
                                    {
                                        groupBox7.Enabled = true;
                                        groupBox2.Enabled = false;
                                        groupBox3.Enabled = false;
                                        groupBox4.Enabled = false;
                                        groupBox5.Enabled = false;
                                        groupBox6.Enabled = false;
                                        groupBox1.Enabled = false;
                                        groupBox8.Enabled = false;

                                       
                                    }
                                    else
                                    {
                                        if (radioButton8.Checked)
                                        {
                                            groupBox8.Enabled = true;
                                            groupBox2.Enabled = false;
                                            groupBox3.Enabled = false;
                                            groupBox4.Enabled = false;
                                            groupBox5.Enabled = false;
                                            groupBox6.Enabled = false;
                                            groupBox7.Enabled = false;
                                            groupBox1.Enabled = false;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void FSimple_Filter_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MedicineContext context = new MedicineContext();
            GlobalVar gl = new GlobalVar();
            GlobalVar.filtred_doc_id.Clear();
            if (radioButton1.Checked)
            {
                var list_id = context.Regions.Where(c => c.region_name.StartsWith(textBox1.Text)).Select(c => c.doctor_id).ToList();
                foreach(decimal r in list_id)
                {
                    if(context.Doctors.Where(c => c.doctor_id == r).Select(c => c.doc_status).FirstOrDefault().ToString() == comboBox2.Text)
                    {
                        GlobalVar.filtred_doc_id.Add(r);
                    }
                }

                GlobalVar.doc_filtred = true;
                GlobalVar.needToUpdate_FDocDataView = true;
                Close();

            }
            else
            {
                if (radioButton2.Checked)
                {
                    GlobalVar.filtred_doc_id = context.Doctors.Where(c => c.doctor_name.StartsWith(textBox2.Text) && c.doc_status == comboBox2.Text).Select(c => c.doctor_id).ToList();
                    GlobalVar.doc_filtred = true;
                    GlobalVar.needToUpdate_FDocDataView = true;
                    Close();
                }
                else
                {
                    if (radioButton3.Checked)
                    {
                        GlobalVar.filtred_doc_id = context.Doctors.Where(c => c.job_name == comboBox1.Text && c.doc_status == comboBox2.Text).Select(c => c.doctor_id).ToList();
                        GlobalVar.doc_filtred = true;
                        GlobalVar.needToUpdate_FDocDataView = true;
                        Close();

                    }
                    else
                    {
                        if (radioButton4.Checked)
                        {
                            GlobalVar.filtred_doc_id = context.Doctors.Where(c => c.room_number == numericUpDown1.Value).Select(c => c.doctor_id).ToList();
                            GlobalVar.doc_filtred = true;
                            GlobalVar.needToUpdate_FDocDataView = true;
                            Close();
                        }
                        else
                        {
                            if (radioButton5.Checked)
                            {
                                GlobalVar.filtred_doc_id = context.Doctors.Where(c => c.passport_series == textBox3.Text && c.passport_number == textBox4.Text).Select(c => c.doctor_id).ToList();
                                GlobalVar.doc_filtred = true;
                                GlobalVar.needToUpdate_FDocDataView = true;
                                Close();
                            }
                            else
                            {
                                if (radioButton6.Checked)
                                {
                                    if(radioButton9.Checked)
                                    {
                                        GlobalVar.filtred_doc_id = context.Doctors.Where(c => c.doc_sex == "Мужской" && c.doc_status == comboBox2.Text).Select(c => c.doctor_id).ToList();
                                        GlobalVar.doc_filtred = true;
                                        GlobalVar.needToUpdate_FDocDataView = true;
                                        Close();
                                    }
                                    else
                                    {
                                        if(radioButton10.Checked)
                                        {
                                            GlobalVar.filtred_doc_id = context.Doctors.Where(c => c.doc_sex == "Женский" && c.doc_status == comboBox2.Text).Select(c => c.doctor_id).ToList();
                                            GlobalVar.doc_filtred = true;
                                            GlobalVar.needToUpdate_FDocDataView = true;
                                            Close();
                                        }
                                    }

                                }
                                else
                                {
                                    if (radioButton7.Checked)
                                    {
                                        GlobalVar.filtred_doc_id = gl.FilterBirthDoctors(Convert.ToDateTime(dateTimePicker1.Text), Convert.ToDateTime(dateTimePicker2.Text), comboBox2.Text);
                                        

                                        GlobalVar.doc_filtred = true;
                                        GlobalVar.needToUpdate_FDocDataView = true;
                                        Close();
                                    }
                                    else
                                    {
                                        if (radioButton8.Checked)
                                        {
                                            GlobalVar.filtred_doc_id = context.Doctors.Where(c => c.archive_number == numericUpDown2.Value).Select(c => c.doctor_id).ToList();
                                            GlobalVar.doc_filtred = true;
                                            GlobalVar.needToUpdate_FDocDataView = true;
                                            Close();
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void FSimple_Filter_Scroll(object sender, ScrollEventArgs e)
        {

        }
    }
}
