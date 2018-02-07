using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace Diplom_FastMedicine_
{
    public partial class FReceptionHistory : Form
    {
        public FReceptionHistory()
        {
            InitializeComponent();
        }

        private void FReceptionHistory_Shown(object sender, EventArgs e)
        {
            MedicineContext context = new MedicineContext();
            GlobalVar gl = new GlobalVar();
            GlobalVar.TabIndex = tabControl1.SelectedIndex;
            label2.Text = context.Patients.Where(c => c.patient_id == GlobalVar.selected_patientID_reception).Select(c => c.patient_name).FirstOrDefault().ToString();
            label4.Text = context.Patients.Where(c => c.patient_id == GlobalVar.selected_patientID_reception).Select(c => c.birth_date).FirstOrDefault().ToString();
            label6.Text = context.Identifiers.Where(c => c.patient_id == GlobalVar.selected_patientID_reception).Select(c => c.medcard_number).FirstOrDefault().ToString();

            switch (GlobalVar.TabIndex)
            {
                case 0:
                    {
                        foreach(var r in context.Services.ToList())
                        {
                            comboBox1.Items.Add(r.service_name);
                        }
                        if(context.Attendances.Where(c => c.reception_id == GlobalVar.selected_reception_ID).Count() > 0)
                        {
                            foreach(var r in context.Attendances.Where(c => c.reception_id == GlobalVar.selected_reception_ID).ToList())
                            {
                                string _ser_name = context.Services.Where(c => c.service_id == r.service_id).Select(c => c.service_name).FirstOrDefault().ToString();
                                string _ser_price = context.Services.Where(c => c.service_id == r.service_id).Select(c => c.service_price).FirstOrDefault().ToString();
                                dataGridView1.Rows.Add(r.service_id, _ser_name, _ser_price);
                            }
                            gl.SetContextMenu_Collumns(dataGridView1, id_context);
                        }
                        break;
                    }
                case 1:
                    {
                        if (context.Complaints.Where(c => c.reception_id == GlobalVar.selected_reception_ID).Count() > 0)
                        {
                            foreach (var r in context.Complaints.Where(c => c.reception_id == GlobalVar.selected_reception_ID).ToList())
                            {
                                string _compl_name = context.Complaints.Where(c => c.reception_id == r.reception_id).Select(c => c.complaint_value).FirstOrDefault().ToString();
                                
                                dataGridView2.Rows.Add(r.complaint_id, _compl_name);
                            }
                            gl.SetContextMenu_Collumns(dataGridView2, id_context);
                        }
                        break;
                    }
                case 2:
                    {
                        break;
                    }
                case 3:
                    {
                        break;
                    }
                case 4:
                    {
                        break;
                    }
                case 5:
                    {
                        break;
                    }
                case 6:
                    {
                        break;
                    }
                case 7:
                    {
                        break;
                    }
                case 8:
                    {
                        break;
                    }
            };
        }

        private void FReceptionHistory_SystemColorsChanged(object sender, EventArgs e)
        {

        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            GlobalVar.TabIndex = e.TabPageIndex;
            MedicineContext context = new MedicineContext();
            GlobalVar gl = new GlobalVar();
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            dataGridView3.Rows.Clear();
            dataGridView4.Rows.Clear();
            dataGridView5.Rows.Clear();
            dataGridView6.Rows.Clear();
            dataGridView7.Rows.Clear();
            switch (GlobalVar.TabIndex)
            {
                case 0:
                    {
                        comboBox1.Items.Clear();
                        dataGridView1.Rows.Clear();
                        foreach (var r in context.Services.ToList())
                        {
                            comboBox1.Items.Add(r.service_name);
                        }
                        if (context.Attendances.Where(c => c.reception_id == GlobalVar.selected_reception_ID).Count() > 0)
                        {
                            foreach (var r in context.Attendances.Where(c => c.reception_id == GlobalVar.selected_reception_ID).ToList())
                            {
                                string _ser_name = context.Services.Where(c => c.service_id == r.service_id).Select(c => c.service_name).FirstOrDefault().ToString();
                                string _ser_price = context.Services.Where(c => c.service_id == r.service_id).Select(c => c.service_price).FirstOrDefault().ToString();
                                dataGridView1.Rows.Add(r.service_id, _ser_name, _ser_price);
                            }
                            gl.SetContextMenu_Collumns(dataGridView1, id_context);
                        }
                        break;
                    }
                case 1:
                    {
                        dataGridView2.Rows.Clear();
                        if (context.Complaints.Where(c => c.reception_id == GlobalVar.selected_reception_ID).Count() > 0)
                        {
                            foreach (var r in context.Complaints.Where(c => c.reception_id == GlobalVar.selected_reception_ID).ToList())
                            {
                                string _compl_name = context.Complaints.Where(c => c.complaint_id == r.complaint_id).Select(c => c.complaint_value).FirstOrDefault().ToString();

                                dataGridView2.Rows.Add(r.complaint_id, _compl_name);
                            }
                            gl.SetContextMenu_Collumns(dataGridView2, id_context);
                        }
                        break;
                    }
                case 2:
                    {
                        richTextBox1.Clear();
                        if(context.AnMorbis.Where(c => c.reception_id == GlobalVar.selected_reception_ID).Count() > 0)
                        {
                            richTextBox1.Text = "Болеет " + context.AnMorbis.Where(c => c.reception_id == GlobalVar.selected_reception_ID).Select(c => c.count_days).FirstOrDefault().ToString() + " дней";
                        }
                        break;
                    }
                case 3:
                    {
                        dataGridView3.Rows.Clear();
                        if (context.AnVitaes.Where(c => c.reception_id == GlobalVar.selected_reception_ID).Count() > 0)
                        {
                            foreach (var r in context.AnVitaes.Where(c => c.reception_id == GlobalVar.selected_reception_ID).ToList())
                            {
                                string _vit_name = context.AnVitaes.Where(c => c.vitae_id == r.vitae_id).Select(c => c.vitae_value).FirstOrDefault().ToString();

                                dataGridView3.Rows.Add(r.vitae_id, _vit_name);
                            }
                            gl.SetContextMenu_Collumns(dataGridView3, id_context);
                        }
                        break;
                    }
                case 4:
                    {
                        dataGridView4.Rows.Clear();
                        if (context.Diseases.Where(c => c.reception_id == GlobalVar.selected_reception_ID).Count() > 0)
                        {
                            foreach (var r in context.Diseases.Where(c => c.reception_id == GlobalVar.selected_reception_ID).ToList())
                            {
                                string _dis_name = context.Diseases.Where(c => c.dis_id == r.dis_id).Select(c => c.disease_value).FirstOrDefault().ToString();
                                dataGridView4.Rows.Add(r.dis_id, _dis_name);
                            }
                            gl.SetContextMenu_Collumns(dataGridView4, id_context);
                        }
                        break;
                    }
                case 5:
                    {
                        richTextBox3.Clear();
                        richTextBox5.Clear();
                        if (context.Current_Status.Where(c => c.reception_id == GlobalVar.selected_reception_ID).Count() > 0)
                        {
                            richTextBox3.Text = context.Current_Status.Where(c => c.reception_id == GlobalVar.selected_reception_ID).Select(c => c.general_state).FirstOrDefault().ToString();
                            richTextBox5.Text = context.Current_Status.Where(c => c.reception_id == GlobalVar.selected_reception_ID).Select(c => c.physique_value).FirstOrDefault().ToString();
                        }
                        break;
                    }
                case 6:
                    {
                        comboBox4.SelectedIndex = 0;
                        dataGridView5.Rows.Clear();
                        if (context.Diagnosis.Where(c => c.reception_id == GlobalVar.selected_reception_ID).Count() > 0)
                        {
                            foreach (var r in context.Diagnosis.Where(c => c.reception_id == GlobalVar.selected_reception_ID).ToList())
                            {
                                string _diag_name = context.Diagnosis.Where(c => c.diag_id == r.diag_id).Select(c => c.diag_value).FirstOrDefault().ToString();
                                string _diag_type = context.Diagnosis.Where(c => c.diag_id == r.diag_id).Select(c => c.diag_type).FirstOrDefault().ToString();
                                dataGridView5.Rows.Add(r.diag_id, _diag_name,_diag_type);
                            }
                            gl.SetContextMenu_Collumns(dataGridView5, id_context);
                        }
                        break;
                    }
                case 7:
                    {
                        foreach (var r in context.Researches.ToList())
                        {
                            comboBox2.Items.Add(r.ins_name);
                        }
                        comboBox5.SelectedIndex = 0;
                        dataGridView6.Rows.Clear();

                        if (context.Inspections.Where(c => c.reception_id == GlobalVar.selected_reception_ID).Count() > 0)
                        {
                            foreach (var r in context.Inspections.Where(c => c.reception_id == GlobalVar.selected_reception_ID).ToList())
                            {
                                string _ins_name = context.Researches.Where(c => c.ins_id == r.ins_id).Select(c => c.ins_name).FirstOrDefault().ToString();
                                string _ins_status = context.Inspections.Where(c => c.ins_id == r.ins_id).Select(c => c.inspection_status).FirstOrDefault().ToString();
                                dataGridView6.Rows.Add(r.selected_ins_id, _ins_name, _ins_status);
                            }
                            gl.SetContextMenu_Collumns(dataGridView6, id_context);
                        }
                        break;
                    }
                case 8:
                    {
                        foreach (var r in context.Preparations.ToList())
                        {
                            comboBox3.Items.Add(r.med_name);
                        }
                        
                        dataGridView7.Rows.Clear();

                        if (context.Medications.Where(c => c.reception_id == GlobalVar.selected_reception_ID).Count() > 0)
                        {
                            foreach (var r in context.Medications.Where(c => c.reception_id == GlobalVar.selected_reception_ID).ToList())
                            {
                                string _med_name = context.Preparations.Where(c => c.med_id == r.med_id).Select(c => c.med_name).FirstOrDefault().ToString();
                                string _med_days = context.Medications.Where(c => c.med_id == r.med_id).Select(c => c.med_days).FirstOrDefault().ToString();
                                dataGridView7.Rows.Add(r.selected_med_id, _med_name, _med_days);
                            }
                            gl.SetContextMenu_Collumns(dataGridView7, id_context);
                        }
                        break;
                    }
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GlobalVar gl = new GlobalVar();
            Medicine_Data data = new Medicine_Data();
            MedicineContext context = new MedicineContext();
            if (comboBox1.Text != "")
            {
                if(gl.CheckDistinct_ValueGrid(dataGridView1, comboBox1.Text))
                {
                    int _ser_id = Convert.ToInt32(context.Services.Where(c => c.service_name == comboBox1.Text).Select(c => c.service_id).FirstOrDefault());
                    data.CreateONE_Attendances_Record(GlobalVar.selected_reception_ID, _ser_id);
                    dataGridView1.Rows.Clear();
                    foreach (var r in context.Attendances.Where(c => c.reception_id == GlobalVar.selected_reception_ID).ToList())
                    {
                        string _ser_name = context.Services.Where(c => c.service_id == r.service_id).Select(c => c.service_name).FirstOrDefault().ToString();
                        string _ser_price = context.Services.Where(c => c.service_id == r.service_id).Select(c => c.service_price).FirstOrDefault().ToString();
                        dataGridView1.Rows.Add(r.service_id, _ser_name, _ser_price);
                    }
                    gl.SetContextMenu_Collumns(dataGridView1, id_context);
                }
            }
        }

        private void удалитьЗаписьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Medicine_Data data = new Medicine_Data();
            MedicineContext context = new MedicineContext();
            GlobalVar gl = new GlobalVar();
            switch (GlobalVar.TabIndex)
            {
                case 0:
                    {
                        GlobalVar.selected_ListRowIndex = Convert.ToInt32(dataGridView1.SelectedCells[0].Value);
                        data.DeleteONE_Attendaces_Record(GlobalVar.selected_reception_ID, GlobalVar.selected_ListRowIndex);
                        dataGridView1.Rows.Clear();
                        foreach (var r in context.Attendances.Where(c => c.reception_id == GlobalVar.selected_reception_ID).ToList())
                        {
                            string _ser_name = context.Services.Where(c => c.service_id == r.service_id).Select(c => c.service_name).FirstOrDefault().ToString();
                            string _ser_price = context.Services.Where(c => c.service_id == r.service_id).Select(c => c.service_price).FirstOrDefault().ToString();
                            dataGridView1.Rows.Add(r.service_id, _ser_name, _ser_price);
                        }
                        gl.SetContextMenu_Collumns(dataGridView1, id_context);
                        break;
                    }
                case 1:
                    {
                        GlobalVar.selected_ListRowIndex = Convert.ToInt32(dataGridView2.SelectedCells[0].Value);
                        data.Delete_Complaint_Record(GlobalVar.selected_ListRowIndex);
                        dataGridView2.Rows.Clear();
                        foreach (var r in context.Complaints.Where(c => c.reception_id == GlobalVar.selected_reception_ID).ToList())
                        {
                            string _compl_name = context.Complaints.Where(c => c.reception_id == r.reception_id).Select(c => c.complaint_value).FirstOrDefault().ToString();

                            dataGridView2.Rows.Add(r.complaint_id, _compl_name);
                        }
                        gl.SetContextMenu_Collumns(dataGridView2, id_context);

                        break;
                    }
                case 2:
                    {
                        break;
                    }
                case 3:
                    {
                        GlobalVar.selected_ListRowIndex = Convert.ToInt32(dataGridView3.SelectedCells[0].Value);
                        data.Delete_AnVitae_Record(GlobalVar.selected_ListRowIndex);
                        dataGridView3.Rows.Clear();
                        if (context.AnVitaes.Where(c => c.reception_id == GlobalVar.selected_reception_ID).Count() > 0)
                        {
                            foreach (var r in context.AnVitaes.Where(c => c.reception_id == GlobalVar.selected_reception_ID).ToList())
                            {
                                string _vit_name = context.AnVitaes.Where(c => c.vitae_id == r.vitae_id).Select(c => c.vitae_value).FirstOrDefault().ToString();

                                dataGridView3.Rows.Add(r.vitae_id, _vit_name);
                            }
                            gl.SetContextMenu_Collumns(dataGridView3, id_context);
                        }
                        break;
                    }
                case 4:
                    {
                        GlobalVar.selected_ListRowIndex = Convert.ToInt32(dataGridView4.SelectedCells[0].Value);
                        data.Delete_Diseas_Record(GlobalVar.selected_ListRowIndex);
                        dataGridView4.Rows.Clear();
                        if (context.Diseases.Where(c => c.reception_id == GlobalVar.selected_reception_ID).Count() > 0)
                        {
                            foreach (var r in context.Diseases.Where(c => c.reception_id == GlobalVar.selected_reception_ID).ToList())
                            {
                                string _dis_name = context.Diseases.Where(c => c.dis_id == r.dis_id).Select(c => c.disease_value).FirstOrDefault().ToString();

                                dataGridView4.Rows.Add(r.dis_id, _dis_name);
                            }
                            gl.SetContextMenu_Collumns(dataGridView4, id_context);
                        }
                        break;
                    }
                case 5:
                    {
                        break;
                    }
                case 6:
                    {
                        GlobalVar.selected_ListRowIndex = Convert.ToInt32(dataGridView5.SelectedCells[0].Value);
                        data.Delete_Diagnosis_Recird(GlobalVar.selected_ListRowIndex);
                        dataGridView5.Rows.Clear();
                        if (context.Diagnosis.Where(c => c.reception_id == GlobalVar.selected_reception_ID).Count() > 0)
                        {
                            foreach (var r in context.Diagnosis.Where(c => c.reception_id == GlobalVar.selected_reception_ID).ToList())
                            {
                                string _diag_name = context.Diagnosis.Where(c => c.diag_id == r.diag_id).Select(c => c.diag_value).FirstOrDefault().ToString();
                                string _diag_type = context.Diagnosis.Where(c => c.diag_id == r.diag_id).Select(c => c.diag_type).FirstOrDefault().ToString();
                                dataGridView5.Rows.Add(r.diag_id, _diag_name, _diag_type);
                            }
                            gl.SetContextMenu_Collumns(dataGridView5, id_context);
                        }
                        break;
                    }
                case 7:
                    {
                        GlobalVar.selected_ListRowIndex = Convert.ToInt32(dataGridView6.SelectedCells[0].Value);
                        data.Delete_Inspection_Record(GlobalVar.selected_ListRowIndex);
                        dataGridView6.Rows.Clear();

                        if (context.Inspections.Where(c => c.reception_id == GlobalVar.selected_reception_ID).Count() > 0)
                        {
                            foreach (var r in context.Inspections.Where(c => c.reception_id == GlobalVar.selected_reception_ID).ToList())
                            {
                                string _ins_name = context.Researches.Where(c => c.ins_id == r.ins_id).Select(c => c.ins_name).FirstOrDefault().ToString();
                                string _ins_status = context.Inspections.Where(c => c.ins_id == r.ins_id).Select(c => c.inspection_status).FirstOrDefault().ToString();
                                dataGridView6.Rows.Add(r.selected_ins_id, _ins_name, _ins_status);
                            }
                            gl.SetContextMenu_Collumns(dataGridView6, id_context);
                        }
                        break;
                    }
                case 8:
                    {
                        GlobalVar.selected_ListRowIndex = Convert.ToInt32(dataGridView7.SelectedCells[0].Value);
                        data.Delete_Medication_Record(GlobalVar.selected_ListRowIndex);
                        dataGridView7.Rows.Clear();
                        if (context.Medications.Where(c => c.reception_id == GlobalVar.selected_reception_ID).Count() > 0)
                        {
                            foreach (var r in context.Medications.Where(c => c.reception_id == GlobalVar.selected_reception_ID).ToList())
                            {
                                string _med_name = context.Preparations.Where(c => c.med_id == r.med_id).Select(c => c.med_name).FirstOrDefault().ToString();
                                string _med_days = context.Medications.Where(c => c.med_id == r.med_id).Select(c => c.med_days).FirstOrDefault().ToString();
                                dataGridView7.Rows.Add(r.selected_med_id, _med_name, _med_days);
                            }
                            gl.SetContextMenu_Collumns(dataGridView7, id_context);
                        }
                        break;
                    }
            };
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            GlobalVar vr = new GlobalVar();
            vr.FreeFocus_From_Cells(dataGridView1, e);
        }

        private void dataGridView2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void dataGridView2_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            GlobalVar vr = new GlobalVar();
            vr.FreeFocus_From_Cells(dataGridView2, e);
        }

        private void dataGridView3_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            GlobalVar vr = new GlobalVar();
            vr.FreeFocus_From_Cells(dataGridView3, e);
        }

        private void dataGridView4_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            GlobalVar vr = new GlobalVar();
            vr.FreeFocus_From_Cells(dataGridView4, e);
        }

        private void dataGridView5_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            GlobalVar vr = new GlobalVar();
            vr.FreeFocus_From_Cells(dataGridView5, e);
        }

        private void dataGridView6_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            GlobalVar vr = new GlobalVar();
            vr.FreeFocus_From_Cells(dataGridView6, e);
        }

        private void dataGridView7_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            GlobalVar vr = new GlobalVar();
            vr.FreeFocus_From_Cells(dataGridView7, e);
        }

        private void FReceptionHistory_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MedicineContext context = new MedicineContext();
            Medicine_Data data = new Medicine_Data();
            GlobalVar gl = new GlobalVar();
            if(textBox1.Text != "")
            {
                data.Create_Complaint_Record(GlobalVar.selected_reception_ID, textBox1.Text);

                dataGridView2.Rows.Clear();
                foreach (var r in context.Complaints.Where(c => c.reception_id == GlobalVar.selected_reception_ID).ToList())
                {
                    string _compl_name = context.Complaints.Where(c => c.complaint_id == r.complaint_id).Select(c => c.complaint_value).FirstOrDefault().ToString();

                    dataGridView2.Rows.Add(r.complaint_id, _compl_name);
                }
                gl.SetContextMenu_Collumns(dataGridView2, id_context);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Medicine_Data data = new Medicine_Data();
            MedicineContext context = new MedicineContext();
            if(richTextBox1.TextLength == 0)
            {
                data.Create_AnMorbi_Record(GlobalVar.selected_reception_ID, Convert.ToInt32(numericUpDown1.Value));
                richTextBox1.Text = "Болеет " + context.AnMorbis.Where(c => c.reception_id == GlobalVar.selected_reception_ID).Select(c => c.count_days).FirstOrDefault().ToString() + " дней";
            }else
            {
                data.UpdateAnMorbi_CountDays(GlobalVar.selected_reception_ID, Convert.ToInt32(numericUpDown1.Value));
                richTextBox1.Text = "Болеет " + context.AnMorbis.Where(c => c.reception_id == GlobalVar.selected_reception_ID).Select(c => c.count_days).FirstOrDefault().ToString() + " дней";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Medicine_Data data = new Medicine_Data();
            MedicineContext context = new MedicineContext();
            GlobalVar gl = new GlobalVar();
            if(textBox2.Text != "")
            {
                data.Create_AnVitae_Record(GlobalVar.selected_reception_ID, textBox2.Text);
                dataGridView3.Rows.Clear();
                if (context.AnVitaes.Where(c => c.reception_id == GlobalVar.selected_reception_ID).Count() > 0)
                {
                    foreach (var r in context.AnVitaes.Where(c => c.reception_id == GlobalVar.selected_reception_ID).ToList())
                    {
                        string _vit_name = context.AnVitaes.Where(c => c.vitae_id == r.vitae_id).Select(c => c.vitae_value).FirstOrDefault().ToString();

                        dataGridView3.Rows.Add(r.vitae_id, _vit_name);
                    }
                    gl.SetContextMenu_Collumns(dataGridView3, id_context);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Medicine_Data data = new Medicine_Data();
            MedicineContext context = new MedicineContext();
            GlobalVar gl = new GlobalVar();
            if (textBox3.Text != "")
            {
                data.Create_Diseas_Record(GlobalVar.selected_reception_ID, textBox3.Text);
                dataGridView4.Rows.Clear();
                if (context.Diseases.Where(c => c.reception_id == GlobalVar.selected_reception_ID).Count() > 0)
                {
                    foreach (var r in context.Diseases.Where(c => c.reception_id == GlobalVar.selected_reception_ID).ToList())
                    {
                        string _dis_name = context.Diseases.Where(c => c.dis_id == r.dis_id).Select(c => c.disease_value).FirstOrDefault().ToString();

                        dataGridView4.Rows.Add(r.dis_id, _dis_name);
                    }
                    gl.SetContextMenu_Collumns(dataGridView4, id_context);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Medicine_Data data = new Medicine_Data();
            MedicineContext context = new MedicineContext();
            if (richTextBox3.TextLength == 0 && richTextBox5.TextLength == 0)
            {
                data.Create_CurStatus_Record(GlobalVar.selected_reception_ID, richTextBox4.Text, richTextBox6.Text);
                richTextBox3.Text = context.Current_Status.Where(c => c.reception_id == GlobalVar.selected_reception_ID).Select(c => c.general_state).FirstOrDefault().ToString();
                richTextBox5.Text = context.Current_Status.Where(c => c.reception_id == GlobalVar.selected_reception_ID).Select(c => c.physique_value).FirstOrDefault().ToString();
            }
            else
            {
                data.UpdateCurStatus_Status(GlobalVar.selected_reception_ID,richTextBox4.Text,richTextBox6.Text);
                richTextBox3.Text = context.Current_Status.Where(c => c.reception_id == GlobalVar.selected_reception_ID).Select(c => c.general_state).FirstOrDefault().ToString();
                richTextBox5.Text = context.Current_Status.Where(c => c.reception_id == GlobalVar.selected_reception_ID).Select(c => c.physique_value).FirstOrDefault().ToString();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Medicine_Data data = new Medicine_Data();
            MedicineContext context = new MedicineContext();
            GlobalVar gl = new GlobalVar();
            if (textBox4.Text != "")
            {
                data.Create_Diagnosis_Record(GlobalVar.selected_reception_ID, textBox4.Text,comboBox4.Text);
                dataGridView5.Rows.Clear();
                if (context.Diagnosis.Where(c => c.reception_id == GlobalVar.selected_reception_ID).Count() > 0)
                {
                    foreach (var r in context.Diagnosis.Where(c => c.reception_id == GlobalVar.selected_reception_ID).ToList())
                    {
                        string _diag_name = context.Diagnosis.Where(c => c.diag_id == r.diag_id).Select(c => c.diag_value).FirstOrDefault().ToString();
                        string _diag_type = context.Diagnosis.Where(c => c.diag_id == r.diag_id).Select(c => c.diag_type).FirstOrDefault().ToString();
                        dataGridView5.Rows.Add(r.diag_id, _diag_name, _diag_type);
                    }
                    gl.SetContextMenu_Collumns(dataGridView5, id_context);
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Medicine_Data data = new Medicine_Data();
            MedicineContext context = new MedicineContext();
            GlobalVar gl = new GlobalVar();
            if (comboBox2.Text != "")
            {
                int _ins_id = Convert.ToInt32(context.Researches.Where(c => c.ins_name == comboBox2.Text).Select(c => c.ins_id).FirstOrDefault());
                data.Create_Inspection_Record(GlobalVar.selected_reception_ID, _ins_id, comboBox5.Text);
                
            }
            dataGridView6.Rows.Clear();

            if (context.Inspections.Where(c => c.reception_id == GlobalVar.selected_reception_ID).Count() > 0)
            {
                foreach (var r in context.Inspections.Where(c => c.reception_id == GlobalVar.selected_reception_ID).ToList())
                {
                    string _ins_name = context.Researches.Where(c => c.ins_id == r.ins_id).Select(c => c.ins_name).FirstOrDefault().ToString();
                    string _ins_status = context.Inspections.Where(c => c.ins_id == r.ins_id).Select(c => c.inspection_status).FirstOrDefault().ToString();
                    dataGridView6.Rows.Add(r.selected_ins_id, _ins_name, _ins_status);
                }
                gl.SetContextMenu_Collumns(dataGridView6, id_context);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Medicine_Data data = new Medicine_Data();
            MedicineContext context = new MedicineContext();
            GlobalVar gl = new GlobalVar();
            if (comboBox3.Text != "")
            {
                int _med_id = Convert.ToInt32(context.Preparations.Where(c => c.med_name == comboBox3.Text).Select(c => c.med_id).FirstOrDefault());
                data.Create_Medication_Record(GlobalVar.selected_reception_ID, _med_id, Convert.ToInt32(numericUpDown2.Value));
            }
            dataGridView7.Rows.Clear();
            if (context.Medications.Where(c => c.reception_id == GlobalVar.selected_reception_ID).Count() > 0)
            {
                foreach (var r in context.Medications.Where(c => c.reception_id == GlobalVar.selected_reception_ID).ToList())
                {
                    string _med_name = context.Preparations.Where(c => c.med_id == r.med_id).Select(c => c.med_name).FirstOrDefault().ToString();
                    string _med_days = context.Medications.Where(c => c.med_id == r.med_id).Select(c => c.med_days).FirstOrDefault().ToString();
                    dataGridView7.Rows.Add(r.selected_med_id, _med_name, _med_days);
                }
                gl.SetContextMenu_Collumns(dataGridView7, id_context);
            }

        }

        private void id_context_Opening(object sender, CancelEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {

                

                MedicineContext context = new MedicineContext();
                Word.Application app = new Word.Application();
                object fileName = Application.StartupPath + "\\Reports_Template\\Current_History2.dotx";
                Word.Document doc = app.Documents.Open(fileName);
                string anMorbi = ""; //--
                string anVitae = ""; //--
                string complaint = ""; //--
                string currStatus = ""; //--
                string diag = ""; //--
                string dises = ""; //--
                string doc_v = ""; //--
                string ins = ""; //--
                string med = ""; //--

                int _doc_id = Convert.ToInt32(context.Receptions.Where(c => c.reception_id == GlobalVar.selected_reception_ID).Select(c => c.doctor_id).FirstOrDefault());
                tabControl1.Enabled = false;
                tabControl1.SelectedIndex = 1; 
                for(int i = 0; i < dataGridView2.Rows.Count;i++)
                {
                    string complaint_buf = dataGridView2.Rows[i].Cells[1].Value.ToString();
                    if (i == dataGridView2.Rows.Count - 1)
                    {
                        complaint += complaint_buf;
                    }
                    else { complaint += complaint_buf + ", "; }
                }

                tabControl1.SelectedIndex = 2;
                anMorbi = richTextBox1.Text;

                tabControl1.SelectedIndex = 3;
                for (int i = 0; i < dataGridView3.Rows.Count;i++)
                {
                    anVitae += (i+1).ToString() + ") " + dataGridView3.Rows[i].Cells[1].Value.ToString() + Convert.ToChar(11);
                }

                tabControl1.SelectedIndex = 4;
                for (int i = 0; i < dataGridView4.Rows.Count; i++)
                {
                    dises += (i+1).ToString() + ") " + dataGridView4.Rows[i].Cells[1].Value.ToString() + Convert.ToChar(11);
                }

                tabControl1.SelectedIndex = 5;
                currStatus = "Общее состояние: " + richTextBox3.Text + Convert.ToChar(11) + "Телосложение: " + richTextBox5.Text;

                tabControl1.SelectedIndex = 6;
                for (int i = 0; i < dataGridView5.Rows.Count; i++)
                {
                    diag += (i + 1).ToString() + ") " + dataGridView5.Rows[i].Cells[1].Value.ToString() + Convert.ToChar(11);
                }

                
                doc_v = context.Doctors.Where(c => c.doctor_id == _doc_id).Select(c => c.doctor_name).FirstOrDefault().ToString();
                tabControl1.SelectedIndex = 7;
                for (int i = 0; i < dataGridView6.Rows.Count; i++)
                {
                    ins += (i + 1).ToString() + ") " + dataGridView6.Rows[i].Cells[1].Value.ToString() + Convert.ToChar(11);
                }

                tabControl1.SelectedIndex = 8;
                for (int i = 0; i < dataGridView7.Rows.Count; i++)
                {
                    med += (i + 1).ToString() + ") " + dataGridView7.Rows[i].Cells[1].Value.ToString() + ". Дней: " + dataGridView7.Rows[i].Cells[2].Value.ToString() + Convert.ToChar(11);
                }
                tabControl1.SelectedIndex = 0;
                tabControl1.Enabled = true;
                doc.Bookmarks["anMorbi_value"].Range.Text = anMorbi;
                doc.Bookmarks["anVitae_value"].Range.Text = anVitae;
                doc.Bookmarks["complaint_value"].Range.Text = complaint;
                doc.Bookmarks["currStatus_value"].Range.Text = currStatus;
                doc.Bookmarks["diag_value"].Range.Text = diag;
                doc.Bookmarks["diseas_value"].Range.Text = dises;
                doc.Bookmarks["doc_value"].Range.Text = doc_v;
                doc.Bookmarks["ins_value"].Range.Text = ins;
                doc.Bookmarks["med_value"].Range.Text = med;

                doc.Application.Visible = true;
            }
            catch { MessageBox.Show("Закройте ворд перед нажатием!", "База данных", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
