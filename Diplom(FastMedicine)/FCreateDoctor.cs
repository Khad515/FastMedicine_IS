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
    public partial class FCreateDoctor : Form
    {
        public FCreateDoctor()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK )
            {
                
                pictureBox1.Load(openFileDialog1.FileName);
                GlobalVar.doctor_photo_path = pictureBox1.Image;
            }
        }

        private void FCreateDoctor_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // убираем символы маски.
          //  phone_number_masked.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            Medicine_Data data = new Medicine_Data();
           

            if(doc_name_box.Text != "")
            {

                if(doc_proff_comboBox.Text != "")
                {

                    if(passport_series_box.Text != "")
                    {

                        if(passport_number_box.Text != "")
                        {

                            if(!data.Check_Data_Card(card_number_box.Text.ToString()))
                            {

                                if(phone_number_masked.Text != "")
                                {

                                    if(address_box.Text != "")
                                    {

                                        if(GlobalVar.doctor_photo_path != null)
                                        {

                                            if(!data.Check_Data_Room(room_numberbox.Value.ToString()))
                                            {
                                                if (!data.Check_Data_Archive(numericUpDown1.Value.ToString()))
                                                {
                                                    if (radioButton1.Checked == true)
                                                    {
                                                        data.Create_Doctor_Record(doc_name_box.Text, doc_proff_comboBox.Text, Convert.ToInt32(room_numberbox.Value), passport_series_box.Text, passport_number_box.Text,
                                                        Convert.ToInt32(exp_numberbox.Value), "Мужской", card_number_box.Text, phone_number_masked.Text, address_box.Text, data.ImageToBase64(GlobalVar.doctor_photo_path, GlobalVar.doctor_photo_path.RawFormat), dateTimePicker1.Text, Convert.ToInt32(numericUpDown1.Value),comboBox1.Text);
                                                        MessageBox.Show("Запись успешно создана!", "База данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                        Close();
                                                    }
                                                    else
                                                    {
                                                        data.Create_Doctor_Record(doc_name_box.Text, doc_proff_comboBox.Text, Convert.ToInt32(room_numberbox.Value), passport_series_box.Text, passport_number_box.Text,
                                                        Convert.ToInt32(exp_numberbox.Value), "Женский", card_number_box.Text, phone_number_masked.Text, address_box.Text, data.ImageToBase64(GlobalVar.doctor_photo_path, GlobalVar.doctor_photo_path.RawFormat), dateTimePicker1.Text, Convert.ToInt32(numericUpDown1.Value), comboBox1.Text);
                                                        MessageBox.Show("Запись успешно создана!", "База данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                        Close();
                                                    }

                                                }else { MessageBox.Show("Архивный номер занят.", "База данных", MessageBoxButtons.OK, MessageBoxIcon.Error); }

                                            }
                                            else { MessageBox.Show("Кабинет под указанным номером занят.", "База данных", MessageBoxButtons.OK, MessageBoxIcon.Error); }


                                        }else { MessageBox.Show("Не указано фото.", "Добавление данных", MessageBoxButtons.OK, MessageBoxIcon.Error); }

                                    }else { MessageBox.Show("Полe *Обслуживает адрес* не заданно.", "Добавление данных", MessageBoxButtons.OK, MessageBoxIcon.Error); }

                                }else { MessageBox.Show("Полe *Контактный телефон* не заданно.", "Добавление данных", MessageBoxButtons.OK, MessageBoxIcon.Error); }

                            }else { MessageBox.Show("Полe *Номер карты* должно быть уникальным.", "Добавление данных", MessageBoxButtons.OK, MessageBoxIcon.Error); }

                        }else { MessageBox.Show("Полe *Номер* не заданно.", "Добавление данных", MessageBoxButtons.OK, MessageBoxIcon.Error); }

                    }else { MessageBox.Show("Полe *Серия* не заданно.", "Добавление данных", MessageBoxButtons.OK, MessageBoxIcon.Error); }

                }else { MessageBox.Show("Полe *Профессия* не заданно.", "Добавление данных", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            }else { MessageBox.Show("Полe *ФИО* не заданно.", "Добавление данных", MessageBoxButtons.OK, MessageBoxIcon.Error); }
           
        }

        private void FCreateDoctor_FormClosing(object sender, FormClosingEventArgs e)
        {
            GlobalVar.doctor_photo_path = null;
        }

        private void FCreateDoctor_Shown(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }
    }
}
