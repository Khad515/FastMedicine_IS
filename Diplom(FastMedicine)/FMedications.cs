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
    public partial class FMedications : Form
    {
        public FMedications()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
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
                GlobalVar.pages_count = gl.PageCount(context.Preparations.Count());           
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
                GlobalVar.pages_count = gl.PageCount(context.Preparations.Count());
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

        private void FMedications_Shown(object sender, EventArgs e)
        {
            List<Preparation> medList = new List<Preparation>();
            GlobalVar gl = new GlobalVar();
            MedicineContext context = new MedicineContext();
            if (GlobalVar.doc_filtred)
            {

                GlobalVar.pages_count = gl.PageCount(GlobalVar.filtred_doc_id.Count());

            }
            else
            {
                GlobalVar.pages_count = gl.PageCount(context.Preparations.Count());
            }

            if (GlobalVar.doc_filtred)
            {

                GlobalVar.count_datarows = GlobalVar.filtred_doc_id.Count();

            }
            else
            {
                GlobalVar.count_datarows = context.Preparations.Count();
            }



            Count_row_lbl.Text = GlobalVar.count_datarows.ToString();
            dataGridView1.Rows.Clear();

            if (GlobalVar.doc_filtred)
            {
                List<Preparation> medList1 = new List<Preparation>();
                foreach (var r in GlobalVar.filtred_doc_id)
                {
                    medList1.Add(context.Preparations.Where(c => c.med_id == r).FirstOrDefault());
                }

                medList = medList1.OrderBy(c => c.med_id).Take(12).ToList();

                foreach (var r in medList)
                {
                    dataGridView1.Rows.Add(r.med_id, r.med_name, r.med_code, r.med_count);
                }

            }
            else
            {
                medList = context.Preparations.OrderBy(c => c.med_id).Take(12).ToList();

                foreach (var r in medList)
                {
                    dataGridView1.Rows.Add(r.med_id, r.med_name, r.med_code, r.med_count);
                }
            }


            gl.SetContextMenu_Collumns(dataGridView1, id_context);
            gl.SetContextMenu_Collumns(dataGridView1, contextMenuStrip);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            GlobalVar vr = new GlobalVar();
            vr.FreeFocus_From_Cells(dataGridView1, e);
        }

        private void page_label_TextChanged(object sender, EventArgs e)
        {
            List<Preparation> medList = new List<Preparation>();
            MedicineContext context = new MedicineContext();
            GlobalVar gl = new GlobalVar();
            dataGridView1.Rows.Clear();

            if (int.Parse(page_label.Text) == 1)
            {

                if (GlobalVar.doc_filtred)
                {
                    List<Preparation> medList1 = new List<Preparation>();
                    foreach (var r in GlobalVar.filtred_doc_id)
                    {
                        medList1.Add(context.Preparations.Where(c => c.med_id == r).FirstOrDefault());
                    }

                    medList = medList1.OrderBy(c => c.med_id).Take(12).ToList();

                    foreach (var r in medList)
                    {
                        dataGridView1.Rows.Add(r.med_id, r.med_name, r.med_code, r.med_count);
                    }

                }
                else
                {
                    medList = context.Preparations.OrderBy(c => c.med_id).Take(12).ToList();

                    foreach (var r in medList)
                    {
                        dataGridView1.Rows.Add(r.med_id, r.med_name, r.med_code, r.med_count);
                    }
                }

            }
            else
            {
                if (GlobalVar.doc_filtred)
                {
                    List<Preparation> medList1 = new List<Preparation>();
                    foreach (var r in GlobalVar.filtred_doc_id)
                    {
                        medList1.Add(context.Preparations.Where(c => c.med_id == r).FirstOrDefault());
                    }

                    medList = medList1.OrderBy(c => c.med_id).Skip(12 * int.Parse(page_label.Text) - 12).Take(12).ToList();

                    foreach (var r in medList)
                    {
                        dataGridView1.Rows.Add(r.med_id, r.med_name, r.med_code, r.med_count);
                    }

                }
                else
                {
                    medList = context.Preparations.OrderBy(c => c.med_id).Skip(12 * int.Parse(page_label.Text) - 12).Take(12).ToList();

                    foreach (var r in medList)
                    {
                        dataGridView1.Rows.Add(r.med_id, r.med_name, r.med_code, r.med_count);
                    }
                }

            }

            gl.SetContextMenu_Collumns(dataGridView1, id_context);
            gl.SetContextMenu_Collumns(dataGridView1, contextMenuStrip);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            List<Preparation> medList = new List<Preparation>();
            GlobalVar gl = new GlobalVar();
            MedicineContext context = new MedicineContext();
            if (GlobalVar.doc_filtred)
            {

                GlobalVar.pages_count = gl.PageCount(GlobalVar.filtred_doc_id.Count());

            }
            else
            {
                GlobalVar.pages_count = gl.PageCount(context.Preparations.Count());
            }

            if (GlobalVar.doc_filtred)
            {

                GlobalVar.count_datarows = GlobalVar.filtred_doc_id.Count();

            }
            else
            {
                GlobalVar.count_datarows = context.Preparations.Count();
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

            if ((int.Parse(Count_row_lbl.Text) != GlobalVar.count_datarows) || (GlobalVar.needToUpdate_FMedications == true))
            {
                GlobalVar.needToUpdate_FMedications = false;

                if (GlobalVar.doc_filtred)
                {

                    GlobalVar.pages_count = gl.PageCount(GlobalVar.filtred_doc_id.Count());

                }
                else
                {
                    GlobalVar.pages_count = gl.PageCount(context.Preparations.Count());
                }

                if (GlobalVar.doc_filtred)
                {

                    GlobalVar.count_datarows = GlobalVar.filtred_doc_id.Count();

                }
                else
                {
                    GlobalVar.count_datarows = context.Preparations.Count();
                }

                Count_row_lbl.Text = GlobalVar.count_datarows.ToString();
                dataGridView1.Rows.Clear();

                if (int.Parse(page_label.Text) == 1)
                {

                    if (GlobalVar.doc_filtred)
                    {
                        List<Preparation> medList1 = new List<Preparation>();
                        foreach (var r in GlobalVar.filtred_doc_id)
                        {
                            medList1.Add(context.Preparations.Where(c => c.med_id == r).FirstOrDefault());
                        }

                        medList = medList1.OrderBy(c => c.med_id).Take(12).ToList();

                        foreach (var r in medList)
                        {
                            dataGridView1.Rows.Add(r.med_id, r.med_name, r.med_code, r.med_count);
                        }

                    }
                    else
                    {
                        medList = context.Preparations.OrderBy(c => c.med_id).Take(12).ToList();

                        foreach (var r in medList)
                        {
                            dataGridView1.Rows.Add(r.med_id, r.med_name, r.med_code, r.med_count);
                        }
                    }

                }
                else
                {
                    if (GlobalVar.doc_filtred)
                    {
                        List<Preparation> medList1 = new List<Preparation>();
                        foreach (var r in GlobalVar.filtred_doc_id)
                        {
                            medList1.Add(context.Preparations.Where(c => c.med_id == r).FirstOrDefault());
                        }

                        medList = medList1.OrderBy(c => c.med_id).Skip(12 * int.Parse(page_label.Text) - 12).Take(12).ToList();

                        foreach (var r in medList)
                        {
                            dataGridView1.Rows.Add(r.med_id, r.med_name, r.med_code, r.med_count);
                        }

                    }
                    else
                    {
                        medList = context.Preparations.OrderBy(c => c.med_id).Skip(12 * int.Parse(page_label.Text) - 12).Take(12).ToList();

                        foreach (var r in medList)
                        {
                            dataGridView1.Rows.Add(r.med_id, r.med_name, r.med_code, r.med_count);
                        }
                    }

                }
                Count_row_lbl.Text = GlobalVar.count_datarows.ToString();
                gl.SetContextMenu_Collumns(dataGridView1, id_context);
                gl.SetContextMenu_Collumns(dataGridView1, contextMenuStrip);
            }
        }

        private void FMedications_Activated(object sender, EventArgs e)
        {
            label2.Text = GlobalVar.doc_filtred.ToString();
            timer1.Enabled = true;
        }

        private void FMedications_Deactivate(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        private void FMedications_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            timer2.Enabled = true;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (chekbutton.CheckState == CheckState.Checked)
            {
                if (this.Height != 520)
                { this.Height = this.Height + 5; chekbutton.Enabled = false; groupBox1.Enabled = true; }
                else { chekbutton.Enabled = true; }
            }
            else if (chekbutton.CheckState == CheckState.Unchecked)
            {
                if (this.Height != 400)
                { this.Height = this.Height - 5; chekbutton.Enabled = false; groupBox1.Enabled = false; }
                else { chekbutton.Enabled = true; timer2.Enabled = false; }
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Medicine_Data data = new Medicine_Data();
            if(textBox1.Text != "")
            {
                if(textBox2.Text != "")
                {
                    data.Create_Preparation_Record(textBox1.Text, textBox2.Text, Convert.ToInt32(numericUpDown1.Value));
                    MessageBox.Show("Запись успешно создана!", "База данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GlobalVar.needToUpdate_FMedications = true;

                }
                else { MessageBox.Show("Не указан штрих-код.", "Добавление данных", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }else { MessageBox.Show("Не указано наименование.", "Добавление данных", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Medicine_Data data = new Medicine_Data();
            GlobalVar.selected_docID = Convert.ToInt32(dataGridView1.SelectedCells[0].Value);
            if (MessageBox.Show("Вы действительно хотите удалить эту запись?", "Предупреждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                data.Delete_Preparation_Record(GlobalVar.selected_docID);
                MessageBox.Show("Запись успешно удалена!", "База данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            GlobalVar.selected_MedRowIndex = dataGridView1.SelectedCells[0].ColumnIndex;
            GlobalVar.selectedOld_value = dataGridView1.SelectedCells[0].Value.ToString();
            GlobalVar.selected_docID = Convert.ToInt32(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[0].Value);
            FUpdateMedications med = new FUpdateMedications();
            med.ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FMedSimpleFilter filter = new FMedSimpleFilter();
            filter.ShowDialog();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            GlobalVar.doc_filtred = false;
            label2.Text = GlobalVar.doc_filtred.ToString();
        }

        private void фильтрыToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
