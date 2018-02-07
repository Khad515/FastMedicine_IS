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
    public partial class FAdvancedFilter : Form
    {
        public FAdvancedFilter()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FAdvancedFilter_Shown(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MedicineContext context = new MedicineContext();
            GlobalVar.filtred_doc_id.Clear();
            DateTime d1 = Convert.ToDateTime(dateTimePicker1.Text);
            DateTime d2 = Convert.ToDateTime(dateTimePicker2.Text);
            GlobalVar gl = new GlobalVar();
            
            
            if(comboBox1.SelectedIndex == 0 && comboBox2.SelectedIndex == 0)
            {
                GlobalVar.filtred_doc_id.Clear();
               
                if (radioButton1.Checked)
                {
                    
                    foreach(var r in context.Doctors.ToList())
                    {
                        if(r.doctor_name.StartsWith(textBox1.Text) && gl.CheckNumberIn(numericUpDown1,numericUpDown2,Convert.ToInt32(r.room_number))
                            && r.doc_sex == "Мужской" && (d1.CompareTo(Convert.ToDateTime(r.doc_birthdate)) <= 0 && d2.CompareTo(Convert.ToDateTime(r.doc_birthdate)) >= 0)
                            && gl.CheckNumberIn(numericUpDown3, numericUpDown4, Convert.ToInt32(r.doc_experience)))
                        {
                            GlobalVar.filtred_doc_id.Add(r.doctor_id);
                        }
                    }
                    GlobalVar.doc_filtred = true;
                    GlobalVar.needToUpdate_FDocDataView = true;
                    Close();
                }
                else
                {
                    foreach (var r in context.Doctors.ToList())
                    {
                        if (r.doctor_name.StartsWith(textBox1.Text) && gl.CheckNumberIn(numericUpDown1, numericUpDown2, Convert.ToInt32(r.room_number))
                            && r.doc_sex == "Женский" && (d1.CompareTo(Convert.ToDateTime(r.doc_birthdate)) <= 0 && d2.CompareTo(Convert.ToDateTime(r.doc_birthdate)) >= 0)
                            && gl.CheckNumberIn(numericUpDown3, numericUpDown4, Convert.ToInt32(r.doc_experience)))
                        {
                            GlobalVar.filtred_doc_id.Add(r.doctor_id);
                        }
                    }
                    GlobalVar.doc_filtred = true;
                    GlobalVar.needToUpdate_FDocDataView = true;
                    Close();
                }


            }else
            {
                if(comboBox1.SelectedIndex == 0 && comboBox2.SelectedIndex > 0)
                {
                    
                    GlobalVar.filtred_doc_id.Clear();
                    if(radioButton1.Checked)
                    {
                        foreach (var r in context.Doctors.Where(c => c.doc_status == comboBox2.Text).ToList())
                        {
                            if (r.doctor_name.StartsWith(textBox1.Text) && gl.CheckNumberIn(numericUpDown1, numericUpDown2, Convert.ToInt32(r.room_number))
                                && r.doc_sex == "Мужской" && (d1.CompareTo(Convert.ToDateTime(r.doc_birthdate)) <= 0 && d2.CompareTo(Convert.ToDateTime(r.doc_birthdate)) >= 0)
                                && gl.CheckNumberIn(numericUpDown3, numericUpDown4, Convert.ToInt32(r.doc_experience)))
                            {
                                GlobalVar.filtred_doc_id.Add(r.doctor_id);
                            }
                        }

                        GlobalVar.doc_filtred = true;
                        GlobalVar.needToUpdate_FDocDataView = true;
                        Close();
                    }
                    else
                    {
                        foreach (var r in context.Doctors.Where(c => c.doc_status == comboBox2.Text).ToList())
                        {
                            if (r.doctor_name.StartsWith(textBox1.Text) && gl.CheckNumberIn(numericUpDown1, numericUpDown2, Convert.ToInt32(r.room_number))
                                && r.doc_sex == "Женский" && (d1.CompareTo(Convert.ToDateTime(r.doc_birthdate)) <= 0 && d2.CompareTo(Convert.ToDateTime(r.doc_birthdate)) >= 0)
                                && gl.CheckNumberIn(numericUpDown3, numericUpDown4, Convert.ToInt32(r.doc_experience)))
                            {
                                GlobalVar.filtred_doc_id.Add(r.doctor_id);
                            }
                        }

                        GlobalVar.doc_filtred = true;
                        GlobalVar.needToUpdate_FDocDataView = true;
                        Close();
                    }
                    

                }
                else
                {
                    if (comboBox1.SelectedIndex > 0 && comboBox2.SelectedIndex == 0)
                    {
                        
                        GlobalVar.filtred_doc_id.Clear();
                        if (radioButton1.Checked)
                        {
                            foreach (var r in context.Doctors.Where(c => c.job_name == comboBox1.Text).ToList())
                            {
                                if (r.doctor_name.StartsWith(textBox1.Text) && gl.CheckNumberIn(numericUpDown1, numericUpDown2, Convert.ToInt32(r.room_number))
                                    && r.doc_sex == "Мужской" && (d1.CompareTo(Convert.ToDateTime(r.doc_birthdate)) <= 0 && d2.CompareTo(Convert.ToDateTime(r.doc_birthdate)) >= 0)
                                    && gl.CheckNumberIn(numericUpDown3, numericUpDown4, Convert.ToInt32(r.doc_experience)))
                                {
                                    GlobalVar.filtred_doc_id.Add(r.doctor_id);
                                }
                            }

                            GlobalVar.doc_filtred = true;
                            GlobalVar.needToUpdate_FDocDataView = true;
                            Close();
                        }
                        else
                        {
                            foreach (var r in context.Doctors.Where(c => c.job_name == comboBox1.Text).ToList())
                            {
                                if (r.doctor_name.StartsWith(textBox1.Text) && gl.CheckNumberIn(numericUpDown1, numericUpDown2, Convert.ToInt32(r.room_number))
                                    && r.doc_sex == "Женский" && (d1.CompareTo(Convert.ToDateTime(r.doc_birthdate)) <= 0 && d2.CompareTo(Convert.ToDateTime(r.doc_birthdate)) >= 0)
                                    && gl.CheckNumberIn(numericUpDown3, numericUpDown4, Convert.ToInt32(r.doc_experience)))
                                {
                                    GlobalVar.filtred_doc_id.Add(r.doctor_id);
                                }
                            }

                            GlobalVar.doc_filtred = true;
                            GlobalVar.needToUpdate_FDocDataView = true;
                            Close();
                        }
                        

                    }
                    else
                    {
                        if(comboBox1.SelectedIndex > 0 && comboBox2.SelectedIndex > 0)
                        {
                           
                            GlobalVar.filtred_doc_id.Clear();
                            if (radioButton1.Checked)
                            {
                                foreach (var r in context.Doctors.Where(c => c.job_name == comboBox1.Text && c.doc_status == comboBox2.Text).ToList())
                                {
                                    if (r.doctor_name.StartsWith(textBox1.Text) && gl.CheckNumberIn(numericUpDown1, numericUpDown2, Convert.ToInt32(r.room_number))
                                        && r.doc_sex == "Мужской" && (d1.CompareTo(Convert.ToDateTime(r.doc_birthdate)) <= 0 && d2.CompareTo(Convert.ToDateTime(r.doc_birthdate)) >= 0)
                                        && gl.CheckNumberIn(numericUpDown3, numericUpDown4, Convert.ToInt32(r.doc_experience)))
                                    {
                                        GlobalVar.filtred_doc_id.Add(r.doctor_id);
                                    }
                                }

                                GlobalVar.doc_filtred = true;
                                GlobalVar.needToUpdate_FDocDataView = true;
                                Close();
                            }
                            else
                            {
                                foreach (var r in context.Doctors.Where(c => c.job_name == comboBox1.Text && c.doc_status == comboBox2.Text).ToList())
                                {
                                    if (r.doctor_name.StartsWith(textBox1.Text) && gl.CheckNumberIn(numericUpDown1, numericUpDown2, Convert.ToInt32(r.room_number))
                                        && r.doc_sex == "Мужской" && (d1.CompareTo(Convert.ToDateTime(r.doc_birthdate)) <= 0 && d2.CompareTo(Convert.ToDateTime(r.doc_birthdate)) >= 0)
                                        && gl.CheckNumberIn(numericUpDown3, numericUpDown4, Convert.ToInt32(r.doc_experience)))
                                    {
                                        GlobalVar.filtred_doc_id.Add(r.doctor_id);
                                    }
                                }

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
