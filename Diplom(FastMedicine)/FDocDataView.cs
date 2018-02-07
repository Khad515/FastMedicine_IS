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
    public partial class FDocDataView : Form
    {
        public FDocDataView()
        {
            InitializeComponent();
        }

        private void next_btn_Click(object sender, EventArgs e)
        {
            label2.Text = GlobalVar.doc_filtred.ToString();
            MedicineContext context = new MedicineContext();
            GlobalVar gl = new GlobalVar();
            if (GlobalVar.doc_filtred)
            {
                
                    GlobalVar.pages_count = gl.PageCount(GlobalVar.filtred_doc_id.Count());
                
            }
            else
            {
                if (comboBox1.Text == "Работает")
                {
                    GlobalVar.pages_count = gl.PageCount(context.Doctors.Where(c => c.doc_status == "Работает").Count());
                }
                else { GlobalVar.pages_count = gl.PageCount(context.Doctors.Where(c => c.doc_status == "Уволен").Count()); }
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
            label2.Text = GlobalVar.doc_filtred.ToString();
            MedicineContext context = new MedicineContext();
            GlobalVar gl = new GlobalVar();

            if (GlobalVar.doc_filtred)
            {

                GlobalVar.pages_count = gl.PageCount(GlobalVar.filtred_doc_id.Count());

            }
            else
            {
                if (comboBox1.Text == "Работает")
                {
                    GlobalVar.pages_count = gl.PageCount(context.Doctors.Where(c => c.doc_status == "Работает").Count());
                }
                else { GlobalVar.pages_count = gl.PageCount(context.Doctors.Where(c => c.doc_status == "Уволен").Count()); }
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

        private void FDocDataView_Shown(object sender, EventArgs e)
        {
            List<Doctor> personList = new List<Doctor>();
            GlobalVar gl = new GlobalVar();
            MedicineContext context = new MedicineContext();
            comboBox1.SelectedIndex = 0;
            if (GlobalVar.doc_filtred)
            {

                GlobalVar.pages_count = gl.PageCount(GlobalVar.filtred_doc_id.Count());

            }
            else
            {
                if (comboBox1.Text == "Работает")
                {
                    GlobalVar.pages_count = gl.PageCount(context.Doctors.Where(c => c.doc_status == "Работает").Count());
                }
                else { GlobalVar.pages_count = gl.PageCount(context.Doctors.Where(c => c.doc_status == "Уволен").Count()); }
            }

            if (GlobalVar.doc_filtred)
            {

                GlobalVar.count_datarows = GlobalVar.filtred_doc_id.Count();

            }
            else
            {
                if (comboBox1.Text == "Работает")
                {
                    GlobalVar.count_datarows = context.Doctors.Where(c => c.doc_status == "Работает").Count();
                }
                else { GlobalVar.count_datarows = context.Doctors.Where(c => c.doc_status == "Уволен").Count(); }
            }
            
            

            Count_row_lbl.Text = GlobalVar.count_datarows.ToString();
            dataGridView1.Rows.Clear();

            if (GlobalVar.doc_filtred)
            {
                List<Doctor> personList1 = new List<Doctor>();
                foreach (var r in GlobalVar.filtred_doc_id)
                {
                    personList1.Add(context.Doctors.Where(c => c.doctor_id == r).FirstOrDefault());
                }

                personList = personList1.OrderBy(c => c.doctor_id).Take(12).ToList();

                foreach (var r in personList)
                {
                    dataGridView1.Rows.Add(r.doctor_id, r.doctor_name, r.room_number, r.job_name, r.phone_number);
                }

            }
            else
            {
                if (comboBox1.Text == "Работает")
                {
                    personList = context.Doctors.Where(c => c.doc_status == "Работает").OrderBy(c => c.doctor_id).Take(12).ToList();
                }
                else { personList = context.Doctors.Where(c => c.doc_status == "Уволен").OrderBy(c => c.doctor_id).Take(12).ToList(); }

                foreach (var r in personList)
                {
                    dataGridView1.Rows.Add(r.doctor_id, r.doctor_name, r.room_number, r.job_name, r.phone_number);
                }
            }


            gl.SetContextMenu_Collumns(dataGridView1, id_context);
            

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            List<Doctor> personList = new List<Doctor>();
            GlobalVar gl = new GlobalVar();
            MedicineContext context = new MedicineContext();
            if (GlobalVar.doc_filtred)
            {

                GlobalVar.pages_count = gl.PageCount(GlobalVar.filtred_doc_id.Count());

            }
            else
            {
                if (comboBox1.Text == "Работает")
                {
                    GlobalVar.pages_count = gl.PageCount(context.Doctors.Where(c => c.doc_status == "Работает").Count());
                }
                else { GlobalVar.pages_count = gl.PageCount(context.Doctors.Where(c => c.doc_status == "Уволен").Count()); }
            }

            if (GlobalVar.doc_filtred)
            {

                GlobalVar.count_datarows = GlobalVar.filtred_doc_id.Count();

            }
            else
            {
                if (comboBox1.Text == "Работает")
                {
                    GlobalVar.count_datarows = context.Doctors.Where(c => c.doc_status == "Работает").Count();
                }
                else { GlobalVar.count_datarows = context.Doctors.Where(c => c.doc_status == "Уволен").Count(); }
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

            if ((int.Parse(Count_row_lbl.Text) != GlobalVar.count_datarows) || (GlobalVar.needToUpdate_FDocDataView == true))
            {
                GlobalVar.needToUpdate_FDocDataView = false;

                if (GlobalVar.doc_filtred)
                {

                    GlobalVar.pages_count = gl.PageCount(GlobalVar.filtred_doc_id.Count());

                }
                else
                {
                    if (comboBox1.Text == "Работает")
                    {
                        GlobalVar.pages_count = gl.PageCount(context.Doctors.Where(c => c.doc_status == "Работает").Count());
                    }
                    else { GlobalVar.pages_count = gl.PageCount(context.Doctors.Where(c => c.doc_status == "Уволен").Count()); }
                }

                if (GlobalVar.doc_filtred)
                {

                    GlobalVar.count_datarows = GlobalVar.filtred_doc_id.Count();

                }
                else
                {
                    if (comboBox1.Text == "Работает")
                    {
                        GlobalVar.count_datarows = context.Doctors.Where(c => c.doc_status == "Работает").Count();
                    }
                    else { GlobalVar.count_datarows = context.Doctors.Where(c => c.doc_status == "Уволен").Count(); }
                }

                Count_row_lbl.Text = GlobalVar.count_datarows.ToString();
                dataGridView1.Rows.Clear();

                if (int.Parse(page_label.Text) == 1)
                {

                    if (GlobalVar.doc_filtred)
                    {
                        List<Doctor> personList1 = new List<Doctor>();
                        foreach (var r in GlobalVar.filtred_doc_id)
                        {
                            personList1.Add(context.Doctors.Where(c => c.doctor_id == r).FirstOrDefault());
                        }

                        personList = personList1.OrderBy(c => c.doctor_id).Take(12).ToList();

                        foreach (var r in personList)
                        {
                            dataGridView1.Rows.Add(r.doctor_id, r.doctor_name, r.room_number, r.job_name, r.phone_number);
                        }

                    }
                    else
                    {
                        if (comboBox1.Text == "Работает")
                        {
                            personList = context.Doctors.Where(c => c.doc_status == "Работает").OrderBy(c => c.doctor_id).Take(12).ToList();
                        }
                        else { personList = context.Doctors.Where(c => c.doc_status == "Уволен").OrderBy(c => c.doctor_id).Take(12).ToList(); }

                        foreach (var r in personList)
                        {
                            dataGridView1.Rows.Add(r.doctor_id, r.doctor_name, r.room_number, r.job_name, r.phone_number);
                        }
                    }

                }
                else
                {
                    if (GlobalVar.doc_filtred)
                    {
                        List<Doctor> personList1 = new List<Doctor>();
                        foreach (var r in GlobalVar.filtred_doc_id)
                        {
                            personList1.Add(context.Doctors.Where(c => c.doctor_id == r).FirstOrDefault());
                        }

                        personList = personList1.OrderBy(c => c.doctor_id).Skip(12 * int.Parse(page_label.Text) - 12).Take(12).ToList();

                        foreach (var r in personList)
                        {
                            dataGridView1.Rows.Add(r.doctor_id, r.doctor_name, r.room_number, r.job_name, r.phone_number);
                        }

                    }
                    else
                    {
                        if (comboBox1.Text == "Работает")
                        {
                            personList = context.Doctors.Where(c => c.doc_status == "Работает").OrderBy(c => c.doctor_id).Skip(12 * int.Parse(page_label.Text) - 12).Take(12).ToList();
                        }
                        else { personList = context.Doctors.Where(c => c.doc_status == "Уволен").OrderBy(c => c.doctor_id).Skip(12 * int.Parse(page_label.Text) - 12).Take(12).ToList(); }

                        foreach (var r in personList)
                        {
                            dataGridView1.Rows.Add(r.doctor_id, r.doctor_name, r.room_number, r.job_name, r.phone_number);
                        }
                    }

                }
                Count_row_lbl.Text = GlobalVar.count_datarows.ToString();
                gl.SetContextMenu_Collumns(dataGridView1, id_context);
            }


            }

        private void FDocDataView_Activated(object sender, EventArgs e)
        {
            label2.Text = GlobalVar.doc_filtred.ToString();
            GlobalVar gl = new GlobalVar();
            timer1.Enabled = true;
            if(dataGridView1.Rows.Count > 0)
            {
               
                gl.SetContextMenu_Collumns(dataGridView1, id_context);
            }
        }

        private void FDocDataView_Deactivate(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        private void FDocDataView_Load(object sender, EventArgs e)
        {

        }

        private void page_label_TextChanged(object sender, EventArgs e)
        {
            List<Doctor> personList = new List<Doctor>();
            MedicineContext context = new MedicineContext();
            GlobalVar gl = new GlobalVar();
            dataGridView1.Rows.Clear();

            if (int.Parse(page_label.Text) == 1)
            {

                if (GlobalVar.doc_filtred)
                {
                    List<Doctor> personList1 = new List<Doctor>();
                    foreach (var r in GlobalVar.filtred_doc_id)
                    {
                        personList1.Add(context.Doctors.Where(c => c.doctor_id == r).FirstOrDefault());
                    }

                    personList = personList1.OrderBy(c => c.doctor_id).Take(12).ToList();

                    foreach (var r in personList)
                    {
                        dataGridView1.Rows.Add(r.doctor_id, r.doctor_name, r.room_number, r.job_name, r.phone_number);
                    }

                }
                else
                {
                    if (comboBox1.Text == "Работает")
                    {
                        personList = context.Doctors.Where(c => c.doc_status == "Работает").OrderBy(c => c.doctor_id).Take(12).ToList();
                    }
                    else { personList = context.Doctors.Where(c => c.doc_status == "Уволен").OrderBy(c => c.doctor_id).Take(12).ToList(); }

                    foreach (var r in personList)
                    {
                        dataGridView1.Rows.Add(r.doctor_id, r.doctor_name, r.room_number, r.job_name, r.phone_number);
                    }
                }

            }
            else
            {
                if (GlobalVar.doc_filtred)
                {
                    List<Doctor> personList1 = new List<Doctor>();
                    foreach (var r in GlobalVar.filtred_doc_id)
                    {
                        personList1.Add(context.Doctors.Where(c => c.doctor_id == r).FirstOrDefault());
                    }

                    personList = personList1.OrderBy(c => c.doctor_id).Skip(12 * int.Parse(page_label.Text) - 12).Take(12).ToList();

                    foreach (var r in personList)
                    {
                        dataGridView1.Rows.Add(r.doctor_id, r.doctor_name, r.room_number, r.job_name, r.phone_number);
                    }

                }
                else
                {
                    if (comboBox1.Text == "Работает")
                    {
                        personList = context.Doctors.Where(c => c.doc_status == "Работает").OrderBy(c => c.doctor_id).Skip(12 * int.Parse(page_label.Text) - 12).Take(12).ToList();
                    }
                    else { personList = context.Doctors.Where(c => c.doc_status == "Уволен").OrderBy(c => c.doctor_id).Skip(12 * int.Parse(page_label.Text) - 12).Take(12).ToList(); }

                    foreach (var r in personList)
                    {
                        dataGridView1.Rows.Add(r.doctor_id, r.doctor_name, r.room_number, r.job_name, r.phone_number);
                    }
                }

            }

            gl.SetContextMenu_Collumns(dataGridView1, id_context);
            

        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            GlobalVar vr = new GlobalVar();
            vr.FreeFocus_From_Cells(dataGridView1, e);
        }

        private void id_toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GlobalVar.selected_docID = Convert.ToInt32(dataGridView1.SelectedCells[0].Value);
            FDocInfoView view = new FDocInfoView();
            view.ShowDialog();
        }

        private void id_toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Medicine_Data data = new Medicine_Data();
            GlobalVar.selected_docID = Convert.ToInt32(dataGridView1.SelectedCells[0].Value);
            if(MessageBox.Show("Вы действительно хотите удалить эту запись?", "Предупреждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                data.Delete_Doctor_Record(GlobalVar.selected_docID);
                MessageBox.Show("Запись успешно удалена!", "База данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            GlobalVar.needToUpdate_FDocDataView = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GlobalVar.needToUpdate_FDocDataView = true;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FSimple_Filter filter = new FSimple_Filter();
            filter.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            GlobalVar.doc_filtred = false;
            label2.Text = GlobalVar.doc_filtred.ToString();
            GlobalVar.needToUpdate_FDocDataView = true;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FAdvancedFilter filter = new FAdvancedFilter();
            filter.ShowDialog();
        }

        private void FDocDataView_FormClosing(object sender, FormClosingEventArgs e)
        {
            GlobalVar.doc_filtred = false;
        }

        private void id_context_Opening(object sender, CancelEventArgs e)
        {

        }

        private void создатьАккаунтToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MedicineContext context = new MedicineContext();
            GlobalVar.selected_docID = Convert.ToInt32(dataGridView1.SelectedCells[0].Value);
            if (context.Doc_Accounts.Any(c => c.doctor_id == GlobalVar.selected_docID))
            {
                MessageBox.Show("У этого врача уже есть учетная запись!", "База данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }else
            {
                FDocAccCreate acc = new FDocAccCreate();
                acc.ShowDialog();
            }
            
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
