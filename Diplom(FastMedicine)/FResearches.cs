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
    public partial class FResearches : Form
    {
        public FResearches()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            GlobalVar vr = new GlobalVar();
            vr.FreeFocus_From_Cells(dataGridView1, e);
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
                GlobalVar.pages_count = gl.PageCount(context.Researches.Count());
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
                GlobalVar.pages_count = gl.PageCount(context.Researches.Count());
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

        private void FResearches_Shown(object sender, EventArgs e)
        {
            List<Research> resList = new List<Research>();
            GlobalVar gl = new GlobalVar();
            MedicineContext context = new MedicineContext();
            if (GlobalVar.doc_filtred)
            {

                GlobalVar.pages_count = gl.PageCount(GlobalVar.filtred_doc_id.Count());

            }
            else
            {
                GlobalVar.pages_count = gl.PageCount(context.Researches.Count());
            }

            if (GlobalVar.doc_filtred)
            {

                GlobalVar.count_datarows = GlobalVar.filtred_doc_id.Count();

            }
            else
            {
                GlobalVar.count_datarows = context.Researches.Count();
            }



            Count_row_lbl.Text = GlobalVar.count_datarows.ToString();
            dataGridView1.Rows.Clear();

            if (GlobalVar.doc_filtred)
            {
                List<Research> resList1 = new List<Research>();
                foreach (var r in GlobalVar.filtred_doc_id)
                {
                    resList1.Add(context.Researches.Where(c => c.ins_id == r).FirstOrDefault());
                }

                resList = resList1.OrderBy(c => c.ins_id).Take(12).ToList();

                foreach (var r in resList)
                {
                    dataGridView1.Rows.Add(r.ins_id, r.ins_name, r.ins_countdays, r.ins_price);
                }

            }
            else
            {
                resList = context.Researches.OrderBy(c => c.ins_id).Take(12).ToList();

                foreach (var r in resList)
                {
                    dataGridView1.Rows.Add(r.ins_id, r.ins_name, r.ins_countdays, r.ins_price);
                }
            }


            gl.SetContextMenu_Collumns(dataGridView1, id_context);
            gl.SetContextMenu_Collumns(dataGridView1, contextMenuStrip);
        }

        private void page_label_TextChanged(object sender, EventArgs e)
        {
            List<Research> resList = new List<Research>();
            MedicineContext context = new MedicineContext();
            GlobalVar gl = new GlobalVar();
            dataGridView1.Rows.Clear();

            if (int.Parse(page_label.Text) == 1)
            {

                if (GlobalVar.doc_filtred)
                {
                    List<Research> resList1 = new List<Research>();
                    foreach (var r in GlobalVar.filtred_doc_id)
                    {
                        resList1.Add(context.Researches.Where(c => c.ins_id == r).FirstOrDefault());
                    }

                    resList = resList1.OrderBy(c => c.ins_id).Take(12).ToList();

                    foreach (var r in resList)
                    {
                        dataGridView1.Rows.Add(r.ins_id, r.ins_name, r.ins_countdays, r.ins_price);
                    }

                }
                else
                {
                    resList = context.Researches.OrderBy(c => c.ins_id).Take(12).ToList();

                    foreach (var r in resList)
                    {
                        dataGridView1.Rows.Add(r.ins_id, r.ins_name, r.ins_countdays, r.ins_price);
                    }
                }

            }
            else
            {
                if (GlobalVar.doc_filtred)
                {
                    List<Research> resList1 = new List<Research>();
                    foreach (var r in GlobalVar.filtred_doc_id)
                    {
                        resList1.Add(context.Researches.Where(c => c.ins_id == r).FirstOrDefault());
                    }

                    resList = resList1.OrderBy(c => c.ins_id).Skip(12 * int.Parse(page_label.Text) - 12).Take(12).ToList();

                    foreach (var r in resList)
                    {
                        dataGridView1.Rows.Add(r.ins_id, r.ins_name, r.ins_countdays, r.ins_price);
                    }

                }
                else
                {
                    resList = context.Researches.OrderBy(c => c.ins_id).Skip(12 * int.Parse(page_label.Text) - 12).Take(12).ToList();

                    foreach (var r in resList)
                    {
                        dataGridView1.Rows.Add(r.ins_id, r.ins_name, r.ins_countdays, r.ins_price);
                    }
                }

            }

            gl.SetContextMenu_Collumns(dataGridView1, id_context);
            gl.SetContextMenu_Collumns(dataGridView1, contextMenuStrip);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            List<Research> resList = new List<Research>();
            GlobalVar gl = new GlobalVar();
            MedicineContext context = new MedicineContext();
            if (GlobalVar.doc_filtred)
            {

                GlobalVar.pages_count = gl.PageCount(GlobalVar.filtred_doc_id.Count());

            }
            else
            {
                GlobalVar.pages_count = gl.PageCount(context.Researches.Count());
            }

            if (GlobalVar.doc_filtred)
            {

                GlobalVar.count_datarows = GlobalVar.filtred_doc_id.Count();

            }
            else
            {
                GlobalVar.count_datarows = context.Researches.Count();
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

            if ((int.Parse(Count_row_lbl.Text) != GlobalVar.count_datarows) || (GlobalVar.needToUpdate_FResearches == true))
            {
                GlobalVar.needToUpdate_FResearches = false;

                if (GlobalVar.doc_filtred)
                {

                    GlobalVar.pages_count = gl.PageCount(GlobalVar.filtred_doc_id.Count());

                }
                else
                {
                    GlobalVar.pages_count = gl.PageCount(context.Researches.Count());
                }

                if (GlobalVar.doc_filtred)
                {

                    GlobalVar.count_datarows = GlobalVar.filtred_doc_id.Count();

                }
                else
                {
                    GlobalVar.count_datarows = context.Researches.Count();
                }

                Count_row_lbl.Text = GlobalVar.count_datarows.ToString();
                dataGridView1.Rows.Clear();

                if (int.Parse(page_label.Text) == 1)
                {

                    if (GlobalVar.doc_filtred)
                    {
                        List<Research> resList1 = new List<Research>();
                        foreach (var r in GlobalVar.filtred_doc_id)
                        {
                            resList1.Add(context.Researches.Where(c => c.ins_id == r).FirstOrDefault());
                        }

                        resList = resList1.OrderBy(c => c.ins_id).Take(12).ToList();

                        foreach (var r in resList)
                        {
                            dataGridView1.Rows.Add(r.ins_id, r.ins_name, r.ins_countdays, r.ins_price);
                        }

                    }
                    else
                    {
                        resList = context.Researches.OrderBy(c => c.ins_id).Take(12).ToList();

                        foreach (var r in resList)
                        {
                            dataGridView1.Rows.Add(r.ins_id, r.ins_name, r.ins_countdays, r.ins_price);
                        }
                    }

                }
                else
                {
                    if (GlobalVar.doc_filtred)
                    {
                        List<Research> resList1 = new List<Research>();
                        foreach (var r in GlobalVar.filtred_doc_id)
                        {
                            resList1.Add(context.Researches.Where(c => c.ins_id == r).FirstOrDefault());
                        }

                        resList = resList1.OrderBy(c => c.ins_id).Skip(12 * int.Parse(page_label.Text) - 12).Take(12).ToList();

                        foreach (var r in resList)
                        {
                            dataGridView1.Rows.Add(r.ins_id, r.ins_name, r.ins_countdays, r.ins_price);
                        }

                    }
                    else
                    {
                        resList = context.Researches.OrderBy(c => c.ins_id).Skip(12 * int.Parse(page_label.Text) - 12).Take(12).ToList();

                        foreach (var r in resList)
                        {
                            dataGridView1.Rows.Add(r.ins_id, r.ins_name, r.ins_countdays, r.ins_price);
                        }
                    }

                }
                Count_row_lbl.Text = GlobalVar.count_datarows.ToString();
                gl.SetContextMenu_Collumns(dataGridView1, id_context);
                gl.SetContextMenu_Collumns(dataGridView1, contextMenuStrip);
            }
        }

        private void FResearches_Activated(object sender, EventArgs e)
        {
            filtr_lbl.Text = GlobalVar.doc_filtred.ToString();
            timer1.Enabled = true;
        }

        private void FResearches_Deactivate(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        private void checkbtn_CheckStateChanged(object sender, EventArgs e)
        {
            timer2.Enabled = true;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (checkbtn.CheckState == CheckState.Checked)
            {
                if (this.Height != 520)
                { this.Height = this.Height + 5; checkbtn.Enabled = false; groupBox1.Enabled = true; }
                else { checkbtn.Enabled = true; }
            }
            else if (checkbtn.CheckState == CheckState.Unchecked)
            {
                if (this.Height != 400)
                { this.Height = this.Height - 5; checkbtn.Enabled = false; groupBox1.Enabled = false; }
                else { checkbtn.Enabled = true; timer2.Enabled = false; }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Medicine_Data data = new Medicine_Data();
            if(textBox1.Text !="")
            {
                data.Create_Research_Record(textBox1.Text, Convert.ToInt32(numericUpDown1.Value), Convert.ToInt32(numericUpDown2.Value));
                MessageBox.Show("Запись успешно создана!", "База данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GlobalVar.needToUpdate_FResearches = true;

            }
            else { MessageBox.Show("Не указано наименование.", "Добавление данных", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void удалитьЗаписьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Medicine_Data data = new Medicine_Data();
            GlobalVar.selected_docID = Convert.ToInt32(dataGridView1.SelectedCells[0].Value);
            if (MessageBox.Show("Вы действительно хотите удалить эту запись?", "Предупреждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                data.Delete_Research_Record(GlobalVar.selected_docID);
                MessageBox.Show("Запись успешно удалена!", "База данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void изменитьЗаписьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GlobalVar.selected_MedRowIndex = dataGridView1.SelectedCells[0].ColumnIndex;
            GlobalVar.selectedOld_value = dataGridView1.SelectedCells[0].Value.ToString();
            GlobalVar.selected_docID = Convert.ToInt32(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[0].Value);
            FUpdateResearches res = new FUpdateResearches();
            res.ShowDialog();
        }

        private void отменитьФильтрToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GlobalVar.doc_filtred = false;
            filtr_lbl.Text = GlobalVar.doc_filtred.ToString();
        }

        private void простойФильтерToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FResSimpleFilter res = new FResSimpleFilter();
            res.ShowDialog();
        }

        private void checkbtn_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void FResearches_Load(object sender, EventArgs e)
        {

        }
    }
}
