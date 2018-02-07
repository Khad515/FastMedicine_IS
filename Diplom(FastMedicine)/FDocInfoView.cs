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
    public partial class FDocInfoView : Form
    {
        public FDocInfoView()
        {
            InitializeComponent();
        }

        private void FDocInfoView_Shown(object sender, EventArgs e)
        {
            MedicineContext context = new MedicineContext();
            Medicine_Data data = new Medicine_Data();
            GlobalVar _var = new GlobalVar();
            dataGridView1.Rows.Add("Полное имя(ФИО):", context.Doctors.Where(c => c.doctor_id == GlobalVar.selected_docID).Select(c => c.doctor_name).FirstOrDefault().ToString());
            dataGridView1.Rows.Add("Специализация:", context.Doctors.Where(c => c.doctor_id == GlobalVar.selected_docID).Select(c => c.job_name).FirstOrDefault().ToString());
            dataGridView1.Rows.Add("Номер кабинета:", context.Doctors.Where(c => c.doctor_id == GlobalVar.selected_docID).Select(c => c.room_number).FirstOrDefault().ToString());
            dataGridView1.Rows.Add("Стаж работы:", context.Doctors.Where(c => c.doctor_id == GlobalVar.selected_docID).Select(c => c.doc_experience).FirstOrDefault().ToString());
            dataGridView1.Rows.Add("Моб. номер телефона:", context.Doctors.Where(c => c.doctor_id == GlobalVar.selected_docID).Select(c => c.phone_number).FirstOrDefault().ToString());
            dataGridView1.Rows.Add("Пол:", context.Doctors.Where(c => c.doctor_id == GlobalVar.selected_docID).Select(c => c.doc_sex).FirstOrDefault().ToString());
            dataGridView1.Rows.Add("Возраст:", context.Doctors.Where(c => c.doctor_id == GlobalVar.selected_docID).Select(c => c.doc_birthdate).FirstOrDefault().ToString());
            dataGridView1.Rows.Add("Серия паспорта:", context.Doctors.Where(c => c.doctor_id == GlobalVar.selected_docID).Select(c => c.passport_series).FirstOrDefault().ToString());
            dataGridView1.Rows.Add("Номер паспорта:", context.Doctors.Where(c => c.doctor_id == GlobalVar.selected_docID).Select(c => c.passport_number).FirstOrDefault().ToString());
            dataGridView1.Rows.Add("Обслуживает адресс:", context.Regions.Where(c => c.doctor_id == GlobalVar.selected_docID).Select(c => c.region_name).FirstOrDefault().ToString());
            dataGridView1.Rows.Add("Номер карты:", context.Doctors.Where(c => c.doctor_id == GlobalVar.selected_docID).Select(c => c.doc_card).FirstOrDefault().ToString());
            dataGridView1.Rows.Add("Архивный номер:", context.Doctors.Where(c => c.doctor_id == GlobalVar.selected_docID).Select(c => c.archive_number).FirstOrDefault().ToString());
            dataGridView1.Rows.Add("Статус:", context.Doctors.Where(c => c.doctor_id == GlobalVar.selected_docID).Select(c => c.doc_status).FirstOrDefault().ToString());
            dataGridView1.Rows.Add("Смена:", context.Doctors.Where(c => c.doctor_id == GlobalVar.selected_docID).Select(c => c.time_working).FirstOrDefault().ToString());

            pictureBox1.Image = data.Base64ToImage(context.Doctors.Where(c => c.doctor_id == GlobalVar.selected_docID).Select(c => c.doc_photo).FirstOrDefault());
            _var.SetContextMenu_Cells(dataGridView1,contextMenuStrip1);
        }

        private void FDocInfoView_Load(object sender, EventArgs e)
        {

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

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GlobalVar.selected_RowIndex = dataGridView1.SelectedCells[0].RowIndex;
            GlobalVar.selectedOld_value = dataGridView1.SelectedCells[0].Value.ToString();
            FUpdateDocData docdata = new FUpdateDocData();
            docdata.ShowDialog();
        }

        private void FDocInfoView_Activated(object sender, EventArgs e)
        {

            if(GlobalVar.needToUpdate_FDocInfoView)
            {
                MedicineContext context = new MedicineContext();
                Medicine_Data data = new Medicine_Data();
                GlobalVar _var = new GlobalVar();
                dataGridView1.Rows.Clear();
                dataGridView1.Rows.Add("Полное имя(ФИО):", context.Doctors.Where(c => c.doctor_id == GlobalVar.selected_docID).Select(c => c.doctor_name).FirstOrDefault().ToString());
                dataGridView1.Rows.Add("Специализация:", context.Doctors.Where(c => c.doctor_id == GlobalVar.selected_docID).Select(c => c.job_name).FirstOrDefault().ToString());
                dataGridView1.Rows.Add("Номер кабинета:", context.Doctors.Where(c => c.doctor_id == GlobalVar.selected_docID).Select(c => c.room_number).FirstOrDefault().ToString());
                dataGridView1.Rows.Add("Стаж работы:", context.Doctors.Where(c => c.doctor_id == GlobalVar.selected_docID).Select(c => c.doc_experience).FirstOrDefault().ToString());
                dataGridView1.Rows.Add("Моб. номер телефона:", context.Doctors.Where(c => c.doctor_id == GlobalVar.selected_docID).Select(c => c.phone_number).FirstOrDefault().ToString());
                dataGridView1.Rows.Add("Пол:", context.Doctors.Where(c => c.doctor_id == GlobalVar.selected_docID).Select(c => c.doc_sex).FirstOrDefault().ToString());
                dataGridView1.Rows.Add("Возраст:", context.Doctors.Where(c => c.doctor_id == GlobalVar.selected_docID).Select(c => c.doc_birthdate).FirstOrDefault().ToString());
                dataGridView1.Rows.Add("Серия паспорта:", context.Doctors.Where(c => c.doctor_id == GlobalVar.selected_docID).Select(c => c.passport_series).FirstOrDefault().ToString());
                dataGridView1.Rows.Add("Номер паспорта:", context.Doctors.Where(c => c.doctor_id == GlobalVar.selected_docID).Select(c => c.passport_number).FirstOrDefault().ToString());
                dataGridView1.Rows.Add("Обслуживает адресс:", context.Regions.Where(c => c.doctor_id == GlobalVar.selected_docID).Select(c => c.region_name).FirstOrDefault().ToString());
                dataGridView1.Rows.Add("Номер карты:", context.Doctors.Where(c => c.doctor_id == GlobalVar.selected_docID).Select(c => c.doc_card).FirstOrDefault().ToString());
                dataGridView1.Rows.Add("Архивный номер:", context.Doctors.Where(c => c.doctor_id == GlobalVar.selected_docID).Select(c => c.archive_number).FirstOrDefault().ToString());
                dataGridView1.Rows.Add("Статус:", context.Doctors.Where(c => c.doctor_id == GlobalVar.selected_docID).Select(c => c.doc_status).FirstOrDefault().ToString());
                dataGridView1.Rows.Add("Смена:", context.Doctors.Where(c => c.doctor_id == GlobalVar.selected_docID).Select(c => c.time_working).FirstOrDefault().ToString());

                pictureBox1.Image = data.Base64ToImage(context.Doctors.Where(c => c.doctor_id == GlobalVar.selected_docID).Select(c => c.doc_photo).FirstOrDefault());
                _var.SetContextMenu_Cells(dataGridView1, contextMenuStrip1);
                GlobalVar.needToUpdate_FDocInfoView = false;
            }
        }
    }
}
