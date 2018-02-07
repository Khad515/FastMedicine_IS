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
    public partial class FUpdateDocData : Form
    {
        public FUpdateDocData()
        {
            InitializeComponent();
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FUpdateDocData_Shown(object sender, EventArgs e)
        {
            switch(GlobalVar.selected_RowIndex)
            {
                case 0:
                    {
                        this.Text += "- имени";
                        maskedTextBox1.Mask = "";
                        label3.Text = GlobalVar.selectedOld_value;
                        break;
                    }
                case 1:
                    {
                        this.Text += "- специализации";
                        maskedTextBox1.Size = new Size(20, 21);
                        maskedTextBox1.Location = new Point(12,155);
                        maskedTextBox1.Enabled = false;
                        maskedTextBox1.Visible = false;
                        comboBox1.Size = new Size(170, 20);
                        comboBox1.Location = new Point(107,53);
                        comboBox1.Visible = true;
                        comboBox1.Enabled = true;
                        label3.Text = GlobalVar.selectedOld_value;
                        break;
                    }
                case 2:
                    {
                        this.Text += "- номера кабинета";
                        maskedTextBox1.Size = new Size(20, 21);
                        maskedTextBox1.Location = new Point(58, 155);
                        maskedTextBox1.Enabled = false;
                        maskedTextBox1.Visible = false;
                        numericUpDown1.Size = new Size(170, 20);
                        numericUpDown1.Location = new Point(107, 53);
                        numericUpDown1.Visible = true;
                        numericUpDown1.Enabled = true;
                        label3.Text = GlobalVar.selectedOld_value;
                        break;
                    }
                case 3:
                    {
                        this.Text += "- стажа работы";
                        maskedTextBox1.Size = new Size(20, 21);
                        maskedTextBox1.Location = new Point(58, 155);
                        maskedTextBox1.Enabled = false;
                        maskedTextBox1.Visible = false;
                        numericUpDown1.Size = new Size(170, 20);
                        numericUpDown1.Location = new Point(107, 53);
                        numericUpDown1.Visible = true;
                        numericUpDown1.Enabled = true;
                        label3.Text = GlobalVar.selectedOld_value;
                        break;
                    }
                case 4:
                    {
                        this.Text += "- моб. телефона";
                        maskedTextBox1.Mask = "(999) 00-000-0000";
                        label3.Text = GlobalVar.selectedOld_value;
                        break;
                    }
                case 5:
                    {
                        this.Text += "- пола";
                        maskedTextBox1.Mask = "";
                        label3.Text = GlobalVar.selectedOld_value;
                        break;
                    }
                case 6:
                    {
                        this.Text += "- возраста";
                        maskedTextBox1.Mask = "00/00/0000";
                        label3.Text = GlobalVar.selectedOld_value;
                        break;
                    }
                case 7:
                    {
                        this.Text += "- серии паспорта";
                        maskedTextBox1.Mask = "";
                        label3.Text = GlobalVar.selectedOld_value;
                        break;
                    }
                case 8:
                    {
                        this.Text += "- номера паспорта";
                        maskedTextBox1.Mask = "";
                        label3.Text = GlobalVar.selectedOld_value;
                        break;
                    }
                case 9:
                    {
                        this.Text += "- адресс";
                        maskedTextBox1.Mask = "";
                        label3.Text = GlobalVar.selectedOld_value;
                        break;
                    }
                case 10:
                    {
                        this.Text += "- номера карты";
                        maskedTextBox1.Mask = "";
                        label3.Text = GlobalVar.selectedOld_value;
                        break;
                    }
                case 11:
                    {
                        this.Text += "- архивного номера";
                        maskedTextBox1.Size = new Size(20, 21);
                        maskedTextBox1.Location = new Point(58, 155);
                        maskedTextBox1.Enabled = false;
                        maskedTextBox1.Visible = false;
                        numericUpDown1.Size = new Size(170, 20);
                        numericUpDown1.Location = new Point(107, 53);
                        numericUpDown1.Visible = true;
                        numericUpDown1.Enabled = true;
                        label3.Text = GlobalVar.selectedOld_value;
                        label3.Text = GlobalVar.selectedOld_value;
                        break;
                    }
                case 12:
                    {
                        this.Text += "- статуса";
                        maskedTextBox1.Mask = "";
                        label3.Text = GlobalVar.selectedOld_value;
                        break;
                    }
                case 13:
                    {
                        this.Text += "- смены";
                        maskedTextBox1.Mask = "";
                        label3.Text = GlobalVar.selectedOld_value;
                        break;
                    }
            };
        }

        private void FUpdateDocData_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Medicine_Data data = new Medicine_Data();
            switch (GlobalVar.selected_RowIndex)
            {
                case 0:
                    {
                        data.Update_DoctorName(GlobalVar.selected_docID, maskedTextBox1.Text);
                        MessageBox.Show("Запись успешно обновлена!", "База данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        GlobalVar.needToUpdate_FDocInfoView = true;
                        GlobalVar.needToUpdate_FDocDataView = true;
                        Close();
                        break;
                    }
                case 1:
                    {
                        data.Update_DoctorProff(GlobalVar.selected_docID, comboBox1.Text.ToString());
                        MessageBox.Show("Запись успешно обновлена!", "База данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        GlobalVar.needToUpdate_FDocDataView = true;
                        GlobalVar.needToUpdate_FDocInfoView = true;
                        Close();
                        break;
                    }
                case 2:
                    {
                        if(!data.Check_Data_Room(numericUpDown1.Value.ToString()))
                        {
                            data.Update_DoctorRoom(GlobalVar.selected_docID, Convert.ToInt32(numericUpDown1.Value));
                            MessageBox.Show("Запись успешно обновлена!", "База данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            GlobalVar.needToUpdate_FDocDataView = true;
                            GlobalVar.needToUpdate_FDocInfoView = true;
                            Close();
                        }
                        else { MessageBox.Show("Кабинет под указанным номером занят.", "База данных", MessageBoxButtons.OK, MessageBoxIcon.Error); }

                        break;
                    }
                case 3:
                    {
                        data.Update_DoctorExp(GlobalVar.selected_docID, Convert.ToInt32(numericUpDown1.Value));
                        MessageBox.Show("Запись успешно обновлена!", "База данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        GlobalVar.needToUpdate_FDocDataView = true;
                        GlobalVar.needToUpdate_FDocInfoView = true;
                        Close();
                        break;
                    }
                case 4:
                    {
                        data.Update_DoctorPhone(GlobalVar.selected_docID, maskedTextBox1.Text);
                        MessageBox.Show("Запись успешно обновлена!", "База данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        GlobalVar.needToUpdate_FDocDataView = true;
                        GlobalVar.needToUpdate_FDocInfoView = true;
                        Close();
                        break;
                    }
                case 5:
                    {
                        data.Update_DoctorSex(GlobalVar.selected_docID, maskedTextBox1.Text);
                        MessageBox.Show("Запись успешно обновлена!", "База данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        GlobalVar.needToUpdate_FDocDataView = true;
                        GlobalVar.needToUpdate_FDocInfoView = true;
                        Close();
                        break;
                    }
                case 6:
                    {
                        data.Update_DoctorBirth(GlobalVar.selected_docID, maskedTextBox1.Text);
                        MessageBox.Show("Запись успешно обновлена!", "База данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        GlobalVar.needToUpdate_FDocDataView = true;
                        GlobalVar.needToUpdate_FDocInfoView = true;
                        Close();
                        break;
                    }
                case 7:
                    {
                        data.Update_DoctorPassport_Series(GlobalVar.selected_docID, maskedTextBox1.Text);
                        MessageBox.Show("Запись успешно обновлена!", "База данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        GlobalVar.needToUpdate_FDocDataView = true;
                        GlobalVar.needToUpdate_FDocInfoView = true;
                        Close();
                        break;
                    }
                case 8:
                    {
                        data.Update_DoctorPassport_Number(GlobalVar.selected_docID, maskedTextBox1.Text);
                        MessageBox.Show("Запись успешно обновлена!", "База данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        GlobalVar.needToUpdate_FDocDataView = true;
                        GlobalVar.needToUpdate_FDocInfoView = true;
                        Close();
                        break;
                    }
                case 9:
                    {
                        data.Update_DoctorAdress(GlobalVar.selected_docID, maskedTextBox1.Text);
                        MessageBox.Show("Запись успешно обновлена!", "База данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        GlobalVar.needToUpdate_FDocDataView = true;
                        GlobalVar.needToUpdate_FDocInfoView = true;
                        Close();
                        break;
                    }
                case 10:
                    {
                        if (!data.Check_Data_Card(maskedTextBox1.Text))
                        {
                            data.Update_DoctorCard(GlobalVar.selected_docID, maskedTextBox1.Text);
                            MessageBox.Show("Запись успешно обновлена!", "База данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            GlobalVar.needToUpdate_FDocDataView = true;
                            GlobalVar.needToUpdate_FDocInfoView = true;
                            Close();
                        }
                        else { MessageBox.Show("Полe *Номер карты* должно быть уникальным.", "Добавление данных", MessageBoxButtons.OK, MessageBoxIcon.Error); }

                        break;
                    }
                case 11:
                    {
                        if (!data.Check_Data_Archive(numericUpDown1.Value.ToString()))
                        {
                            data.Update_DoctorArchive(GlobalVar.selected_docID, Convert.ToInt32(numericUpDown1.Value));
                            MessageBox.Show("Запись успешно обновлена!", "База данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            GlobalVar.needToUpdate_FDocDataView = true;
                            GlobalVar.needToUpdate_FDocInfoView = true;
                            Close();
                        }
                        else { MessageBox.Show("Новое значение архивного номера должно быть уникальным.", "Добавление данных", MessageBoxButtons.OK, MessageBoxIcon.Error); }

                        break;
                    }
                case 12:
                    {
                        data.Update_DoctorStatus(GlobalVar.selected_docID, maskedTextBox1.Text);
                        MessageBox.Show("Запись успешно обновлена!", "База данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if(maskedTextBox1.Text == "Уволен") { data.Change_Doctor_Status(GlobalVar.selected_docID); }
                        GlobalVar.needToUpdate_FDocDataView = true;
                        GlobalVar.needToUpdate_FDocInfoView = true;
                        Close();
                        break;
                    }
                case 13:
                    {
                        data.Update_DoctorTimeWorking(GlobalVar.selected_docID, maskedTextBox1.Text);
                        MessageBox.Show("Запись успешно обновлена!", "База данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        GlobalVar.needToUpdate_FDocDataView = true;
                        GlobalVar.needToUpdate_FDocInfoView = true;
                        Close();
                        break;
                    }

            };
        }
    }
}
