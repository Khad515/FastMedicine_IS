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
    public partial class FDocAccCreate : Form
    {
        public FDocAccCreate()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FDocAccCreate_Shown(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MedicineContext context = new MedicineContext();
            Medicine_Data data = new Medicine_Data();
            if(textBox1.Text != "")
            {
                if(textBox2.Text != "")
                {
                    if(textBox3.Text != "")
                    {
                        if (!data.Check_Data_DocLogin(textBox1.Text))
                        {
                            if(textBox3.Text == textBox2.Text)
                            {
                                data.Create_DocAcc_Record(GlobalVar.selected_docID, textBox1.Text, textBox2.Text,comboBox1.Text);
                                MessageBox.Show("Аккаунт успешно создан!", "База данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Close();
                            }
                            else { MessageBox.Show("Поле повтор пароля не равен полю пароля!", "База данных", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        }else { MessageBox.Show("Такой логин уже существует!", "База данных", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }else { MessageBox.Show("Поле повтора пароля не заполнено!", "База данных", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }else { MessageBox.Show("Поле пароля не заполнено!", "База данных", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }else { MessageBox.Show("Поле логина не заполнено!", "База данных", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
