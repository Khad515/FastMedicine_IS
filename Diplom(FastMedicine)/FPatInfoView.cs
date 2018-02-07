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
    public partial class FPatInfoView : Form
    {
        public FPatInfoView()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FPatInfoView_Shown(object sender, EventArgs e)
        {
            MedicineContext context = new MedicineContext();
            Medicine_Data data = new Medicine_Data();
            GlobalVar _var = new GlobalVar();
            dataGridView1.Rows.Add("Полное имя(ФИО):", context.Patients.Where(c => c.patient_id == GlobalVar.selected_docID).Select(c => c.patient_name).FirstOrDefault().ToString());
            dataGridView1.Rows.Add("Дата рождения:", context.Patients.Where(c => c.patient_id == GlobalVar.selected_docID).Select(c => c.birth_date).FirstOrDefault().ToString());
            dataGridView1.Rows.Add("Номер мед. карты:", context.Identifiers.Where(c => c.patient_id == GlobalVar.selected_docID).Select(c => c.medcard_number).FirstOrDefault().ToString());
            dataGridView1.Rows.Add("Место жительства:", context.Locations.Where(c => c.patient_id == GlobalVar.selected_docID).Select(c => c.home_adress).FirstOrDefault().ToString());
            dataGridView1.Rows.Add("Серия паспорта:", context.Passports.Where(c => c.patient_id == GlobalVar.selected_docID).Select(c => c.series).FirstOrDefault().ToString());
            dataGridView1.Rows.Add("Номер паспорта:", context.Passports.Where(c => c.patient_id == GlobalVar.selected_docID).Select(c => c.numbers).FirstOrDefault().ToString());
            dataGridView1.Rows.Add("Сотовый:", context.Communications.Where(c => c.patient_id == GlobalVar.selected_docID).Select(c => c.sms_value).FirstOrDefault().ToString());
            dataGridView1.Rows.Add("Email:", context.Communications.Where(c => c.patient_id == GlobalVar.selected_docID).Select(c => c.email_value).FirstOrDefault().ToString());
            dataGridView1.Rows.Add("Платежная карта:", context.Patients_Money.Where(c => c.patient_id == GlobalVar.selected_docID).Select(c => c.discount_card).FirstOrDefault().ToString());
            dataGridView1.Rows.Add("Разрешение на sms:", context.Agreements.Where(c => c.patient_id == GlobalVar.selected_docID).Select(c => c.sms_bool).FirstOrDefault().ToString());
            dataGridView1.Rows.Add("Разрешение на email:", context.Agreements.Where(c => c.patient_id == GlobalVar.selected_docID).Select(c => c.email_bool).FirstOrDefault().ToString());

            pictureBox1.Image = data.Base64ToImage(context.Patients.Where(c => c.patient_id == GlobalVar.selected_docID).Select(c => c.photo_path).FirstOrDefault());
            _var.SetContextMenu_Cells(dataGridView1, contextMenuStrip1);
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }

        private void FPatInfoView_Activated(object sender, EventArgs e)
        {
            
            if (GlobalVar.needToUpdate_FPatInfoView)
            {
                MedicineContext context = new MedicineContext();
                Medicine_Data data = new Medicine_Data();
                GlobalVar _var = new GlobalVar();
                dataGridView1.Rows.Clear();
                dataGridView1.Rows.Add("Полное имя(ФИО):", context.Patients.Where(c => c.patient_id == GlobalVar.selected_docID).Select(c => c.patient_name).FirstOrDefault().ToString());
                dataGridView1.Rows.Add("Дата рождения:", context.Patients.Where(c => c.patient_id == GlobalVar.selected_docID).Select(c => c.birth_date).FirstOrDefault().ToString());
                dataGridView1.Rows.Add("Номер мед. карты:", context.Identifiers.Where(c => c.patient_id == GlobalVar.selected_docID).Select(c => c.medcard_number).FirstOrDefault().ToString());
                dataGridView1.Rows.Add("Место жительства:", context.Locations.Where(c => c.patient_id == GlobalVar.selected_docID).Select(c => c.home_adress).FirstOrDefault().ToString());
                dataGridView1.Rows.Add("Серия паспорта:", context.Passports.Where(c => c.patient_id == GlobalVar.selected_docID).Select(c => c.series).FirstOrDefault().ToString());
                dataGridView1.Rows.Add("Номер паспорта:", context.Passports.Where(c => c.patient_id == GlobalVar.selected_docID).Select(c => c.numbers).FirstOrDefault().ToString());
                dataGridView1.Rows.Add("Сотовый:", context.Communications.Where(c => c.patient_id == GlobalVar.selected_docID).Select(c => c.sms_value).FirstOrDefault().ToString());
                dataGridView1.Rows.Add("Email:", context.Communications.Where(c => c.patient_id == GlobalVar.selected_docID).Select(c => c.email_value).FirstOrDefault().ToString());
                dataGridView1.Rows.Add("Платежная карта:", context.Patients_Money.Where(c => c.patient_id == GlobalVar.selected_docID).Select(c => c.discount_card).FirstOrDefault().ToString());
                dataGridView1.Rows.Add("Разрешение на sms:", context.Agreements.Where(c => c.patient_id == GlobalVar.selected_docID).Select(c => c.sms_bool).FirstOrDefault().ToString());
                dataGridView1.Rows.Add("Разрешение на email:", context.Agreements.Where(c => c.patient_id == GlobalVar.selected_docID).Select(c => c.email_bool).FirstOrDefault().ToString());

                pictureBox1.Image = data.Base64ToImage(context.Patients.Where(c => c.patient_id == GlobalVar.selected_docID).Select(c => c.photo_path).FirstOrDefault());
                _var.SetContextMenu_Cells(dataGridView1, contextMenuStrip1);
                GlobalVar.needToUpdate_FPatInfoView = false;
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GlobalVar.selected_RowIndex = dataGridView1.SelectedCells[0].RowIndex;
            GlobalVar.selectedOld_value = dataGridView1.SelectedCells[0].Value.ToString();
            FUpdatePatData docdata = new FUpdatePatData();
            docdata.ShowDialog();
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            GlobalVar vr = new GlobalVar();
            vr.FreeFocus_From_Cells(dataGridView1, e);
        }

        private void FPatInfoView_Load(object sender, EventArgs e)
        {

        }

        private void FPatInfoView_Deactivate(object sender, EventArgs e)
        {
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(GlobalVar.needToUpdate_FPatInfoView)
            {
                
                
            }
        }
    }
}
