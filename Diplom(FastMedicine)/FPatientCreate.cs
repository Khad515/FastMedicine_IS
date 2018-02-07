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
    public partial class FPatientCreate : Form
    {
        public FPatientCreate()
        {
            InitializeComponent();
        }

        private void FPatientCreate_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                pictureBox1.Load(openFileDialog1.FileName);
                GlobalVar.patient_photo_path = pictureBox1.Image;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Medicine_Data data = new Medicine_Data();

            if(checkBox1.CheckState == CheckState.Checked)
            {
                GlobalVar.agree_email = "Да";
            }else { GlobalVar.agree_email = "Нет"; }
            if (checkBox2.CheckState == CheckState.Checked)
            {
                GlobalVar.agree_sms = "Да";
            }
            else { GlobalVar.agree_sms = "Нет"; }

            if (patient_name_box.Text !="")
            {
                if(patient_series_box.Text != "")
                {
                    if(patient_number_box.Text != "")
                    {
                        if(GlobalVar.patient_photo_path != null)
                        {
                            if(patient_adress_box.Text != "")
                            {
                                if(patient_card_box.Text != "")
                                {
                                    if(!data.Check_Data_Medcard(patient_medcard_numberbox.Value.ToString()))
                                    {
                                        if(patient_phone_maskedbox.Text != "")
                                        {
                                            data.Create_Patient_Record(patient_name_box.Text, dateTimePicker1.Text.ToString(), data.ImageToBase64(GlobalVar.patient_photo_path, GlobalVar.patient_photo_path.RawFormat),
                                                patient_adress_box.Text,Convert.ToInt32(patient_medcard_numberbox.Value),patient_card_box.Text,GlobalVar.agree_sms,GlobalVar.agree_email,patient_phone_maskedbox.Text,
                                                patient_email_box.Text,patient_series_box.Text, patient_number_box.Text);
                                            MessageBox.Show("Запись успешно создана!", "База данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            Close();
                                        }
                                        else { MessageBox.Show("Не задано поле сотового.", "База данных", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                                    }else { MessageBox.Show("Номер мед. карты должен быть уникальным.", "База данных", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                                }else { MessageBox.Show("Поле платежной карты не задано", "База данных", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                            }else { MessageBox.Show("Поле места жительства не задано.", "База данных", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        }else { MessageBox.Show("Не задана фотография.", "База данных", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }else { MessageBox.Show("Не задан номер паспорта.", "База данных", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }else { MessageBox.Show("Серия паспорта не задана.", "База данных", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }else { MessageBox.Show("Не задано имя(ФИО).", "База данных", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void FPatientCreate_FormClosing(object sender, FormClosingEventArgs e)
        {
            GlobalVar.patient_photo_path = null;
            GlobalVar.needToUpdate_FPatientDataView = true;
        }
    }
}
