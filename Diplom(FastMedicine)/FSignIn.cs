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
    public partial class FSignIn : Form
    {
        public FSignIn()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            GlobalVar.exit = true;
            Close();
        }

        private void FSignIn_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Medicine_Data data = new Medicine_Data();
            if(data.Check_Server_Activity())
            {
               if(data.Sign_Check(login_box.Text,password_box.Text))
                {
                   if(data.Check_Sign_Status(login_box.Text))
                    {
                        data.Status_Offline_Change(login_box.Text);
                        GlobalVar.signIn_login = login_box.Text;
                        Close();
                    }
                    else { label3.Text = "Данный пользователь online"; }
                }else { label3.Text = "Неверный логин или пароль." + data.Sign_Check(login_box.Text, password_box.Text).ToString(); }
            }else { label3.Text = "MS SQL Server: не запущена служба сервера."; }
            
        }
    }
}
 