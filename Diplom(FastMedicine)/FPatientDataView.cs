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
    public partial class FPatientDataView : Form
    {
        public FPatientDataView()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FPatientCreate pat = new FPatientCreate();
            pat.ShowDialog();
        }

        private void toolStripStatusLabel4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            GlobalVar vr = new GlobalVar();
            vr.FreeFocus_From_Cells(dataGridView1, e);

            
            vr.SetContextMenu_Collumns(dataGridView1, id_context);

        }

        private void next_btn_Click(object sender, EventArgs e)
        {
            filtr_lbl.Text = GlobalVar.doc_filtred.ToString();
            MedicineContext context = new MedicineContext();
            GlobalVar gl = new GlobalVar();
            if (GlobalVar.doc_filtred)
            {

                GlobalVar.pages_count = gl.PageCount(GlobalVar.filtred_doc_id.Count());

            }
            else
            {
                GlobalVar.pages_count = gl.PageCount(context.Patients.Count());
            }


            if (Convert.ToUInt32(page_label.Text) == GlobalVar.pages_count)
            {
                next_btn.Enabled = false;
                back_btn.Enabled = true;
            }
            else
            {
                next_btn.Enabled = true;
                page_label.Text = (int.Parse(page_label.Text) + 1).ToString();
            }
        }

        private void back_btn_Click(object sender, EventArgs e)
        {
            filtr_lbl.Text = GlobalVar.doc_filtred.ToString();
            MedicineContext context = new MedicineContext();
            GlobalVar gl = new GlobalVar();

            if (GlobalVar.doc_filtred)
            {
                GlobalVar.pages_count = gl.PageCount(GlobalVar.filtred_doc_id.Count());
            }
            else
            {
                GlobalVar.pages_count = gl.PageCount(context.Patients.Count());
            }

            if (int.Parse(page_label.Text) == 1)
            {
                back_btn.Enabled = false;
                next_btn.Enabled = true;
            }
            else
            {
                page_label.Text = (int.Parse(page_label.Text) - 1).ToString();
                next_btn.Enabled = true;
                if (int.Parse(page_label.Text) == 1) { back_btn.Enabled = false; }
            }
        }

        private void page_label_TextChanged(object sender, EventArgs e)
        {
            List<Patient> patList = new List<Patient>();
            MedicineContext context = new MedicineContext();
            GlobalVar gl = new GlobalVar();
            dataGridView1.Rows.Clear();

            if (int.Parse(page_label.Text) == 1)
            {

                if (GlobalVar.doc_filtred)
                {
                    List<Patient> patList1 = new List<Patient>();
                    foreach (var r in GlobalVar.filtred_doc_id)
                    {
                        patList1.Add(context.Patients.Where(c => c.patient_id == r).FirstOrDefault());
                    }

                    patList = patList1.OrderBy(c => c.patient_id).Take(12).ToList();

                    foreach (var r in patList)
                    {
                        string _pat_medcard = context.Identifiers.Where(c => c.patient_id == r.patient_id).Select(c => c.medcard_number).FirstOrDefault().ToString();
                        string _pat_phone = context.Communications.Where(c => c.patient_id == r.patient_id).Select(c => c.sms_value).FirstOrDefault().ToString();
                        dataGridView1.Rows.Add(r.patient_id, r.patient_name, _pat_medcard, _pat_phone);
                    }

                }
                else
                {
                    patList = context.Patients.OrderBy(c => c.patient_id).Take(12).ToList();

                    foreach (var r in patList)
                    {
                        string _pat_medcard = context.Identifiers.Where(c => c.patient_id == r.patient_id).Select(c => c.medcard_number).FirstOrDefault().ToString();
                        string _pat_phone = context.Communications.Where(c => c.patient_id == r.patient_id).Select(c => c.sms_value).FirstOrDefault().ToString();
                        dataGridView1.Rows.Add(r.patient_id, r.patient_name, _pat_medcard, _pat_phone);
                    }
                }

            }
            else
            {
                if (GlobalVar.doc_filtred)
                {
                    List<Patient> patList1 = new List<Patient>();
                    foreach (var r in GlobalVar.filtred_doc_id)
                    {
                        patList1.Add(context.Patients.Where(c => c.patient_id == r).FirstOrDefault());
                    }

                    patList = patList1.OrderBy(c => c.patient_id).Skip(12 * int.Parse(page_label.Text) - 12).Take(12).ToList();

                    foreach (var r in patList)
                    {
                        string _pat_medcard = context.Identifiers.Where(c => c.patient_id == r.patient_id).Select(c => c.medcard_number).FirstOrDefault().ToString();
                        string _pat_phone = context.Communications.Where(c => c.patient_id == r.patient_id).Select(c => c.sms_value).FirstOrDefault().ToString();
                        dataGridView1.Rows.Add(r.patient_id, r.patient_name, _pat_medcard, _pat_phone);
                    }

                }
                else
                {
                    patList = context.Patients.OrderBy(c => c.patient_id).Skip(12 * int.Parse(page_label.Text) - 12).Take(12).ToList();

                    foreach (var r in patList)
                    {
                        string _pat_medcard = context.Identifiers.Where(c => c.patient_id == r.patient_id).Select(c => c.medcard_number).FirstOrDefault().ToString();
                        string _pat_phone = context.Communications.Where(c => c.patient_id == r.patient_id).Select(c => c.sms_value).FirstOrDefault().ToString();
                        dataGridView1.Rows.Add(r.patient_id, r.patient_name, _pat_medcard, _pat_phone);
                    }
                }

            }

            gl.SetContextMenu_Collumns(dataGridView1, id_context);
        }

        private void FPatientDataView_Shown(object sender, EventArgs e)
        {
            List<Patient> patList = new List<Patient>();
            GlobalVar gl = new GlobalVar();
            MedicineContext context = new MedicineContext();
            if (GlobalVar.doc_filtred)
            {

                GlobalVar.pages_count = gl.PageCount(GlobalVar.filtred_doc_id.Count());

            }
            else
            {
                GlobalVar.pages_count = gl.PageCount(context.Patients.Count());
            }

            if (GlobalVar.doc_filtred)
            {

                GlobalVar.count_datarows = GlobalVar.filtred_doc_id.Count();

            }
            else
            {
                GlobalVar.count_datarows = context.Patients.Count();
            }



            Count_row_lbl.Text = GlobalVar.count_datarows.ToString();
            dataGridView1.Rows.Clear();

            if (GlobalVar.doc_filtred)
            {
                List<Patient> patList1 = new List<Patient>();
                foreach (var r in GlobalVar.filtred_doc_id)
                {
                    patList1.Add(context.Patients.Where(c => c.patient_id == r).FirstOrDefault());
                }

                patList = patList1.OrderBy(c => c.patient_id).Take(12).ToList();

                foreach (var r in patList)
                {
                    if (patList.Count > 0)
                    {
                        string _pat_medcard = context.Identifiers.Where(c => c.patient_id == r.patient_id).Select(c => c.medcard_number).FirstOrDefault().ToString();
                        string _pat_phone = context.Communications.Where(c => c.patient_id == r.patient_id).Select(c => c.sms_value).FirstOrDefault().ToString();
                        dataGridView1.Rows.Add(r.patient_id, r.patient_name, _pat_medcard, _pat_phone);
                    }
                }

            }
            else
            {
                patList = context.Patients.OrderBy(c => c.patient_id).Take(12).ToList();

                foreach (var r in patList)
                {
                    
                    if (patList.Count > 0)
                    {
                        string _pat_medcard = context.Identifiers.Where(c => c.patient_id == r.patient_id).Select(c => c.medcard_number).FirstOrDefault().ToString();
                        string _pat_phone = context.Communications.Where(c => c.patient_id == r.patient_id).Select(c => c.sms_value).FirstOrDefault().ToString();
                        dataGridView1.Rows.Add(r.patient_id, r.patient_name, _pat_medcard, _pat_phone);
                    }
                    
                    
                }
            }


            gl.SetContextMenu_Collumns(dataGridView1, id_context);
            GlobalVar.needToUpdate_FPatientDataView = true;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            List<Patient> patList = new List<Patient>();
            GlobalVar gl = new GlobalVar();
            MedicineContext context = new MedicineContext();
            if (GlobalVar.doc_filtred)
            {

                GlobalVar.pages_count = gl.PageCount(GlobalVar.filtred_doc_id.Count());

            }
            else
            {
                GlobalVar.pages_count = gl.PageCount(context.Patients.Count());
            }

            if (GlobalVar.doc_filtred)
            {

                GlobalVar.count_datarows = GlobalVar.filtred_doc_id.Count();

            }
            else
            {
                GlobalVar.count_datarows = context.Patients.Count();
            }

            if (int.Parse(page_label.Text) == GlobalVar.pages_count)
            {
                next_btn.Enabled = false;
                if (GlobalVar.pages_count == 1) { back_btn.Enabled = false; } else { back_btn.Enabled = true; }

            }
            else
            {
                next_btn.Enabled = true;
            }

            if ((int.Parse(Count_row_lbl.Text) != GlobalVar.count_datarows) || (GlobalVar.needToUpdate_FPatientDataView == true))
            {
                GlobalVar.needToUpdate_FPatientDataView = false;

                if (GlobalVar.doc_filtred)
                {

                    GlobalVar.pages_count = gl.PageCount(GlobalVar.filtred_doc_id.Count());

                }
                else
                {
                    GlobalVar.pages_count = gl.PageCount(context.Patients.Count());
                }

                if (GlobalVar.doc_filtred)
                {

                    GlobalVar.count_datarows = GlobalVar.filtred_doc_id.Count();

                }
                else
                {
                    GlobalVar.count_datarows = context.Patients.Count();
                }

                Count_row_lbl.Text = GlobalVar.count_datarows.ToString();
                dataGridView1.Rows.Clear();

                if (int.Parse(page_label.Text) == 1)
                {

                    if (GlobalVar.doc_filtred)
                    {
                        List<Patient> patList1 = new List<Patient>();
                        foreach (var r in GlobalVar.filtred_doc_id)
                        {
                            patList1.Add(context.Patients.Where(c => c.patient_id == r).FirstOrDefault());
                        }

                        patList = patList1.OrderBy(c => c.patient_id).Take(12).ToList();

                        foreach (var r in patList)
                        {
                            string _pat_medcard = context.Identifiers.Where(c => c.patient_id == r.patient_id).Select(c => c.medcard_number).FirstOrDefault().ToString();
                            string _pat_phone = context.Communications.Where(c => c.patient_id == r.patient_id).Select(c => c.sms_value).FirstOrDefault().ToString();
                            dataGridView1.Rows.Add(r.patient_id, r.patient_name, _pat_medcard, _pat_phone);
                        }

                    }
                    else
                    {
                        patList = context.Patients.OrderBy(c => c.patient_id).Take(12).ToList();

                        foreach (var r in patList)
                        {
                            string _pat_medcard = context.Identifiers.Where(c => c.patient_id == r.patient_id).Select(c => c.medcard_number).FirstOrDefault().ToString();
                            string _pat_phone = context.Communications.Where(c => c.patient_id == r.patient_id).Select(c => c.sms_value).FirstOrDefault().ToString();
                            dataGridView1.Rows.Add(r.patient_id, r.patient_name, _pat_medcard, _pat_phone);
                        }
                    }

                }
                else
                {
                    if (GlobalVar.doc_filtred)
                    {
                        List<Patient> patList1 = new List<Patient>();
                        foreach (var r in GlobalVar.filtred_doc_id)
                        {
                            patList1.Add(context.Patients.Where(c => c.patient_id == r).FirstOrDefault());
                        }

                        patList = patList1.OrderBy(c => c.patient_id).Skip(12 * int.Parse(page_label.Text) - 12).Take(12).ToList();

                        foreach (var r in patList)
                        {
                            string _pat_medcard = context.Identifiers.Where(c => c.patient_id == r.patient_id).Select(c => c.medcard_number).FirstOrDefault().ToString();
                            string _pat_phone = context.Communications.Where(c => c.patient_id == r.patient_id).Select(c => c.sms_value).FirstOrDefault().ToString();
                            dataGridView1.Rows.Add(r.patient_id, r.patient_name, _pat_medcard, _pat_phone);
                        }

                    }
                    else
                    {
                        patList = context.Patients.OrderBy(c => c.patient_id).Skip(12 * int.Parse(page_label.Text) - 12).Take(12).ToList();

                        foreach (var r in patList)
                        {
                            string _pat_medcard = context.Identifiers.Where(c => c.patient_id == r.patient_id).Select(c => c.medcard_number).FirstOrDefault().ToString();
                            string _pat_phone = context.Communications.Where(c => c.patient_id == r.patient_id).Select(c => c.sms_value).FirstOrDefault().ToString();
                            dataGridView1.Rows.Add(r.patient_id, r.patient_name, _pat_medcard, _pat_phone);
                        }
                    }

                }
                Count_row_lbl.Text = GlobalVar.count_datarows.ToString();
                gl.SetContextMenu_Collumns(dataGridView1, id_context);
            }
            
        }

        private void FPatientDataView_Activated(object sender, EventArgs e)
        {
            GlobalVar gl = new GlobalVar();
            filtr_lbl.Text = GlobalVar.doc_filtred.ToString();
            timer1.Enabled = true;
            if(dataGridView1.Rows.Count > 0)
            {
                gl.SetContextMenu_Collumns(dataGridView1, id_context);
            }
        }

        private void FPatientDataView_Deactivate(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        private void удалитьЗаписьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Medicine_Data data = new Medicine_Data();
            GlobalVar.selected_docID = Convert.ToInt32(dataGridView1.SelectedCells[0].Value);
            if (MessageBox.Show("Вы действительно хотите удалить эту запись?", "Предупреждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                data.Delete_Patient_Record(GlobalVar.selected_docID);
                MessageBox.Show("Запись успешно удалена!", "База данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GlobalVar.needToUpdate_FPatientDataView = true;
            }
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Cells[0].ContextMenuStrip = id_context;
            }
        }

        private void полнаяИнформацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GlobalVar.selected_docID = Convert.ToInt32(dataGridView1.SelectedCells[0].Value);
            FPatInfoView view = new FPatInfoView();
            view.ShowDialog();
        }

        private void простойФильтрToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FPatSimpleFilter fil = new FPatSimpleFilter();
            fil.ShowDialog();
        }

        private void отменитьФильтрToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GlobalVar.doc_filtred = false;
            filtr_lbl.Text = GlobalVar.doc_filtred.ToString();
        }

        private void выбратьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GlobalVar.selected_patientID_reception = Convert.ToInt32(dataGridView1.SelectedCells[0].Value);
            Close();
        }

        private void id_context_Opening(object sender, CancelEventArgs e)
        {
            if(!GlobalVar.set_patient_need)
            {
                SetToolStripMenuItem.Enabled = false;
            }else
            {
                SetToolStripMenuItem.Enabled = true;
            }
        }

        private void FPatientDataView_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void FPatientDataView_MouseMove(object sender, MouseEventArgs e)
        {
            
        }
    }
}
