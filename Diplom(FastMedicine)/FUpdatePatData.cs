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
    public partial class FUpdatePatData : Form
    {
        public FUpdatePatData()
        {
            InitializeComponent();
        }

        private void FUpdatePatData_Shown(object sender, EventArgs e)
        {
            switch (GlobalVar.selected_RowIndex)
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
                        this.Text += "- даты рождения";
                        maskedTextBox1.Mask = "00/00/0000";
                        label3.Text = GlobalVar.selectedOld_value;
                        break;
                    }
                case 2:
                    {
                        this.Text += "- номера мед. карты";
                        maskedTextBox1.Size = new Size(20, 21);
                        maskedTextBox1.Location = new Point(58, 155);
                        maskedTextBox1.Enabled = false;
                        maskedTextBox1.Visible = false;
                        numericUpDown1.Size = new Size(170, 20);
                        numericUpDown1.Location = new Point(110, 61);
                        numericUpDown1.Visible = true;
                        numericUpDown1.Enabled = true;
                        label3.Text = GlobalVar.selectedOld_value;
                        break;
                    }
                case 3:
                    {
                        this.Text += "- места жительства";
                        maskedTextBox1.Mask = "";
                        label3.Text = GlobalVar.selectedOld_value;
                        break;
                    }
                case 4:
                    {
                        this.Text += "- серии паспорта";
                        maskedTextBox1.Mask = "";
                        label3.Text = GlobalVar.selectedOld_value;
                        break;
                    }
                case 5:
                    {
                        this.Text += "- номера паспорта";
                        maskedTextBox1.Mask = "";
                        label3.Text = GlobalVar.selectedOld_value;
                        break;
                    }
                case 6:
                    {
                        this.Text += "- моб. телефона";
                        maskedTextBox1.Mask = "(999) 00-000-0000";
                        label3.Text = GlobalVar.selectedOld_value;
                        break;
                    }
                case 7:
                    {
                        this.Text += "- email";
                        maskedTextBox1.Mask = "";
                        label3.Text = GlobalVar.selectedOld_value;
                        break;
                    }
                case 8:
                    {
                        this.Text += "- платежной карты";
                        maskedTextBox1.Mask = "";
                        label3.Text = GlobalVar.selectedOld_value;
                        break;
                    }
                case 9:
                    {
                        this.Text += "- разрешение на sms";
                        maskedTextBox1.Mask = "";
                        label3.Text = GlobalVar.selectedOld_value;
                        break;
                    }
                case 10:
                    {
                        this.Text += "- разрешение на email";
                        maskedTextBox1.Mask = "";
                        label3.Text = GlobalVar.selectedOld_value;
                        break;
                    }
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Medicine_Data data = new Medicine_Data();
            switch (GlobalVar.selected_RowIndex)
            {
                case 0:
                    {
                        data.UpdatePatient_Name(GlobalVar.selected_docID, maskedTextBox1.Text);
                        MessageBox.Show("Запись успешно обновлена!", "База данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        GlobalVar.needToUpdate_FPatInfoView = true;
                        GlobalVar.needToUpdate_FPatientDataView = true;
                        Close();
                        break;
                    }
                case 1:
                    {
                        data.UpdatePatient_Birth(GlobalVar.selected_docID, maskedTextBox1.Text);
                        MessageBox.Show("Запись успешно обновлена!", "База данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        GlobalVar.needToUpdate_FPatInfoView = true;
                        GlobalVar.needToUpdate_FPatientDataView = true;
                        Close();
                        break;
                    }
                case 2:
                    {
                        if(!data.Check_Data_Medcard(numericUpDown1.Value.ToString()))
                        {
                            data.UpdatePatient_MedCard(GlobalVar.selected_docID, Convert.ToInt32(numericUpDown1.Value));
                        }else { MessageBox.Show("Номер карты должен быть уникальным!", "База данных", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        
                        MessageBox.Show("Запись успешно обновлена!", "База данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        GlobalVar.needToUpdate_FPatInfoView = true;
                        GlobalVar.needToUpdate_FPatientDataView = true;
                        Close();
                        break;
                    }
                case 3:
                    {
                        data.UpdatePatient_Adress(GlobalVar.selected_docID, maskedTextBox1.Text);
                        MessageBox.Show("Запись успешно обновлена!", "База данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        GlobalVar.needToUpdate_FPatInfoView = true;
                        GlobalVar.needToUpdate_FPatientDataView = true;
                        Close();
                        break;
                    }
                case 4:
                    {
                        data.UpdatePatient_Passport_Series(GlobalVar.selected_docID, maskedTextBox1.Text);
                        MessageBox.Show("Запись успешно обновлена!", "База данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        GlobalVar.needToUpdate_FPatInfoView = true;
                        GlobalVar.needToUpdate_FPatientDataView = true;
                        Close();
                        break;
                    }
                case 5:
                    {
                        data.UpdatePatient_Passport_Number(GlobalVar.selected_docID, maskedTextBox1.Text);
                        MessageBox.Show("Запись успешно обновлена!", "База данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        GlobalVar.needToUpdate_FPatInfoView = true;
                        GlobalVar.needToUpdate_FPatientDataView = true;
                        Close();
                        break;
                    }
                case 6:
                    {
                        data.UpdatePatient_Phone(GlobalVar.selected_docID, maskedTextBox1.Text);
                        MessageBox.Show("Запись успешно обновлена!", "База данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        GlobalVar.needToUpdate_FPatInfoView = true;
                        GlobalVar.needToUpdate_FPatientDataView = true;
                        Close();
                        break;
                    }
                case 7:
                    {
                        data.UpdatePatient_Email(GlobalVar.selected_docID, maskedTextBox1.Text);
                        MessageBox.Show("Запись успешно обновлена!", "База данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        GlobalVar.needToUpdate_FPatInfoView = true;
                        GlobalVar.needToUpdate_FPatientDataView = true;
                        Close();
                        break;
                    }
                case 8:
                    {
                        data.UpdatePatient_DiscountCard(GlobalVar.selected_docID, maskedTextBox1.Text);
                        MessageBox.Show("Запись успешно обновлена!", "База данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        GlobalVar.needToUpdate_FPatInfoView = true;
                        GlobalVar.needToUpdate_FPatientDataView = true;
                        Close();
                        break;
                    }
                case 9:
                    {
                        data.UpdatePatient_AgreeSMS(GlobalVar.selected_docID, maskedTextBox1.Text);
                        MessageBox.Show("Запись успешно обновлена!", "База данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        GlobalVar.needToUpdate_FPatInfoView = true;
                        GlobalVar.needToUpdate_FPatientDataView = true;
                        Close();
                        break;
                    }
                case 10:
                    {
                        data.UpdatePatient_AgreeEmail(GlobalVar.selected_docID, maskedTextBox1.Text);
                        MessageBox.Show("Запись успешно обновлена!", "База данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        GlobalVar.needToUpdate_FPatInfoView = true;
                        GlobalVar.needToUpdate_FPatientDataView = true;
                        Close();
                        break;
                    }
            };
        }

        private void FUpdatePatData_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
