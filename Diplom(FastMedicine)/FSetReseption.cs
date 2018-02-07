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
    public partial class FSetReseption : Form
    {
        public FSetReseption()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FSetReseption_Shown(object sender, EventArgs e)
        {
            MedicineContext context = new MedicineContext();
            GlobalVar.set_patient_need = true;
            doc_name_lbl.Text = context.Doctors.Where(c => c.doctor_id == GlobalVar.FMain_selected_docid).Select(c => c.doctor_name).FirstOrDefault().ToString();
            date_lbl.Text = GlobalVar.selected_date_reception;
            time_lbl.Text = GlobalVar.selected_time_reception;
            comboBox1.SelectedIndex = 0;
            foreach(var r in context.Services.ToList())
            {
                comboBox2.Items.Add(r.service_name);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GlobalVar gl = new GlobalVar();
            MedicineContext context = new MedicineContext();
            int _ser_id;
            string _name;
            string _price;
            if (comboBox2.Text != "")
            {
                _ser_id = Convert.ToInt32(context.Services.Where(c => c.service_name == comboBox2.Text).Select(c => c.service_id).FirstOrDefault());
                 _name = context.Services.Where(c => c.service_id == _ser_id).Select(c => c.service_name).FirstOrDefault().ToString();
                 _price = context.Services.Where(c => c.service_id == _ser_id).Select(c => c.service_price).FirstOrDefault().ToString();
                if(gl.CheckDistinct_ValueGrid(dataGridView1,_name))
                {
                    dataGridView1.Rows.Add(_ser_id, _name, _price);
                }else { MessageBox.Show("Такая услуга уже была добавлена в список.", "Добавление данных", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                
            }else { MessageBox.Show("Не указана услуга для добавления в список.", "Добавление данных", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            gl.SetContextMenu_Collumns(dataGridView1, id_context);
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            GlobalVar vr = new GlobalVar();
            vr.FreeFocus_From_Cells(dataGridView1, e);
        }

        private void FSetReseption_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void удалитьИзСпискаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GlobalVar gl = new GlobalVar();
            GlobalVar.selected_ListRowIndex = dataGridView1.SelectedCells[0].RowIndex;
            dataGridView1.Rows.RemoveAt(GlobalVar.selected_ListRowIndex);
            gl.SetContextMenu_Collumns(dataGridView1, id_context);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            FPatientDataView pat = new FPatientDataView();
            pat.ShowDialog();
        }

        private void FSetReseption_Activated(object sender, EventArgs e)
        {
            MedicineContext context = new MedicineContext();
            if(GlobalVar.selected_patientID_reception > 0)
            {

                textBox1.Text = context.Patients.Where(c => c.patient_id == GlobalVar.selected_patientID_reception).Select(c => c.patient_name).FirstOrDefault().ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<int> serv = new List<int>();
            Medicine_Data data = new Medicine_Data();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                serv.Add(Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value));
            }

            if (textBox1.Text != "")
            {
                if(dataGridView1.RowCount > 0)
                {
                    
                    data.Create_Reception_Record(GlobalVar.FMain_selected_docid, GlobalVar.selected_patientID_reception, date_lbl.Text, time_lbl.Text, comboBox1.Text);
                    data.Create_Attendances_Record(GlobalVar.FMain_selected_docid, time_lbl.Text, date_lbl.Text, serv);
                    MessageBox.Show("Запись успешно создана", "База данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();

                }
                else { MessageBox.Show("Не выбраны услуги.", "База данных", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else { MessageBox.Show("Выберите пациента.", "База данных", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
