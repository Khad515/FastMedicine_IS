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
    public partial class FUpdateMedications : Form
    {
        public FUpdateMedications()
        {
            InitializeComponent();
        }

        private void FUpdateMedications_Shown(object sender, EventArgs e)
        {
            switch (GlobalVar.selected_MedRowIndex)
            {
                case 1:
                    {
                        this.Text += "- наименование";
                        label1.Text = GlobalVar.selectedOld_value;
                        break;
                    }
                case 2:
                    {
                        this.Text += "- штрих-кода";
                        label1.Text = GlobalVar.selectedOld_value;
                        break;
                    }
                case 3:
                    {
                        this.Text += "- количества";
                        textBox1.Size = new Size(20, 21);
                        textBox1.Location = new Point(15, 169);
                        textBox1.Enabled = false;
                        textBox1.Visible = false;
                        numericUpDown1.Size = new Size(170, 20);
                        numericUpDown1.Location = new Point(110, 64);
                        numericUpDown1.Visible = true;
                        numericUpDown1.Enabled = true;
                        label1.Text = GlobalVar.selectedOld_value;
                        break;
                    }
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Medicine_Data data = new Medicine_Data();
            switch (GlobalVar.selected_MedRowIndex)
            {
                case 1:
                    {
                        data.UpdateMedication_Name(GlobalVar.selected_docID, textBox1.Text);
                        MessageBox.Show("Запись успешно обновлена!", "База данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        GlobalVar.needToUpdate_FMedications = true;
                        Close();
                        break;
                    }
                case 2:
                    {
                        data.UpdateMedication_Code(GlobalVar.selected_docID, textBox1.Text);
                        MessageBox.Show("Запись успешно обновлена!", "База данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        GlobalVar.needToUpdate_FMedications = true;
                        Close();
                        break;
                    }
                case 3:
                    {

                        data.UpdateMedication_Count(GlobalVar.selected_docID, Convert.ToInt32(numericUpDown1.Value));
                        MessageBox.Show("Запись успешно обновлена!", "База данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        GlobalVar.needToUpdate_FMedications = true;
                        Close();
                        break;
                    }
            };
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
