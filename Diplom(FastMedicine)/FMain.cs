using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diplom_FastMedicine_
{
    public partial class FMain : Form
    {
        public FMain()
        {
            InitializeComponent();
        }

        private void FMain_Load(object sender, EventArgs e)
        {
            if(GlobalVar.exit == true)
            {
                Close();
            }
        }

        private void FMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Medicine_Data data = new Medicine_Data();
            if(GlobalVar.exit == false)
            {
                data.Status_Online_Change(GlobalVar.signIn_login);
            }
            
        }

        private void exit_tool_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void создатьToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            Medicine_Data data = new Medicine_Data();
            MedicineContext context = new MedicineContext();
            GlobalVar vr = new GlobalVar();
            label1.ForeColor = DefaultForeColor;
            label2.ForeColor = DefaultForeColor;
            label3.ForeColor = DefaultForeColor;
            label4.ForeColor = DefaultForeColor;
            label5.ForeColor = DefaultForeColor;
            label6.ForeColor = DefaultForeColor;
            DateTime date = Convert.ToDateTime(dateTimePicker1.Text);
            GlobalVar.SelectedDate = Convert.ToDateTime(dateTimePicker1.Text);
            GlobalVar.Start_Week_Date = Convert.ToDateTime(vr.StartWeek(GlobalVar.SelectedDate));
            GlobalVar.End_Week_Date = Convert.ToDateTime(vr.EndWeek(GlobalVar.SelectedDate));

            label7.Text = GlobalVar.Start_Week_Date.ToShortDateString();
            label8.Text = GlobalVar.Start_Week_Date.AddDays(1).ToShortDateString();
            label9.Text = GlobalVar.Start_Week_Date.AddDays(2).ToShortDateString();
            label10.Text = GlobalVar.Start_Week_Date.AddDays(3).ToShortDateString();
            label11.Text = GlobalVar.Start_Week_Date.AddDays(4).ToShortDateString();
            label12.Text = GlobalVar.End_Week_Date.ToShortDateString();

            switch (date.DayOfWeek.ToString())
            {
                case "Monday": { label1.ForeColor = Color.Red; break; }
                case "Tuesday": { label2.ForeColor = Color.Red; break; }
                case "Wednesday": { label3.ForeColor = Color.Red; break; }
                case "Thursday": { label4.ForeColor = Color.Red; break; }
                case "Friday": { label5.ForeColor = Color.Red; break; }
                case "Saturday": { label6.ForeColor = Color.Red; break; }
            }

            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            dataGridView3.Rows.Clear();
            dataGridView4.Rows.Clear();
            dataGridView5.Rows.Clear();
            dataGridView6.Rows.Clear();

            vr.GridDataAdd(dataGridView1);
            vr.GridDataAdd(dataGridView2);
            vr.GridDataAdd(dataGridView3);
            vr.GridDataAdd(dataGridView4);
            vr.GridDataAdd(dataGridView5);
            vr.GridDataAdd(dataGridView6);




            vr.SetContextMenu_Cells(dataGridView1, contextMenuStrip1);
            vr.SetContextMenu_Cells(dataGridView2, contextMenuStrip1);
            vr.SetContextMenu_Cells(dataGridView3, contextMenuStrip1);
            vr.SetContextMenu_Cells(dataGridView4, contextMenuStrip1);
            vr.SetContextMenu_Cells(dataGridView5, contextMenuStrip1);
            vr.SetContextMenu_Cells(dataGridView6, contextMenuStrip1);

            vr.Grid_Stop_Sortable(dataGridView1);
            vr.Grid_Stop_Sortable(dataGridView2);
            vr.Grid_Stop_Sortable(dataGridView3);
            vr.Grid_Stop_Sortable(dataGridView4);
            vr.Grid_Stop_Sortable(dataGridView5);
            vr.Grid_Stop_Sortable(dataGridView6);

            vr.FreeFocus_ALL_Cells(dataGridView1);
            vr.FreeFocus_ALL_Cells(dataGridView2);
            vr.FreeFocus_ALL_Cells(dataGridView3);
            vr.FreeFocus_ALL_Cells(dataGridView4);
            vr.FreeFocus_ALL_Cells(dataGridView5);
            vr.FreeFocus_ALL_Cells(dataGridView6);

            //Проверяем на наличие записей на этой неделе
            if (GlobalVar.reception_doctor_ids.Count > 0)
            {
                foreach (var r in GlobalVar.reception_doctor_ids)
                {
                    string date_rec = context.Receptions.Where(c => c.reception_id == r).Select(c => c.date_reception).FirstOrDefault().ToString();
                    string time_rec = context.Receptions.Where(c => c.reception_id == r).Select(c => c.time_reception).FirstOrDefault().ToString();
                    string status_rec = context.Receptions.Where(c => c.reception_id == r).Select(c => c.reception_status).FirstOrDefault().ToString();
                    int patient_rec = Convert.ToInt32(context.Receptions.Where(c => c.reception_id == r).Select(c => c.patient_id).FirstOrDefault().ToString());
                    string patient_rec_name = context.Patients.Where(c => c.patient_id == patient_rec).Select(c => c.patient_name).FirstOrDefault().ToString();
                    if (date_rec == label7.Text)
                    {
                        switch (time_rec)
                        {
                            case "7:00": { dataGridView1.Rows[0].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 0, 1, status_rec); break; }
                            case "7:30": { dataGridView1.Rows[1].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 1, 1, status_rec); break; }
                            case "8:00": { dataGridView1.Rows[2].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 2, 1, status_rec); break; }
                            case "8:30": { dataGridView1.Rows[3].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 3, 1, status_rec); break; }
                            case "9:00": { dataGridView1.Rows[4].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 4, 1, status_rec); break; }
                            case "9:30": { dataGridView1.Rows[5].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 5, 1, status_rec); break; }
                            case "10:00": { dataGridView1.Rows[6].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 6, 1, status_rec); break; }
                            case "10:30": { dataGridView1.Rows[7].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 7, 1, status_rec); break; }
                            case "11:00": { dataGridView1.Rows[8].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 8, 1, status_rec); break; }
                            case "11:30": { dataGridView1.Rows[9].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 9, 1, status_rec); break; }
                            case "12:30": { dataGridView1.Rows[10].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 10, 1, status_rec); break; }
                            case "13:00": { dataGridView1.Rows[11].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 11, 1, status_rec); break; }
                            case "13:30": { dataGridView1.Rows[12].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 12, 1, status_rec); break; }
                            case "14:00": { dataGridView1.Rows[13].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 13, 1, status_rec); break; }
                            case "14:30": { dataGridView1.Rows[14].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 14, 1, status_rec); break; }
                            case "15:00": { dataGridView1.Rows[15].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 15, 1, status_rec); break; }
                            case "15:30": { dataGridView1.Rows[16].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 16, 1, status_rec); break; }
                            case "16:00": { dataGridView1.Rows[17].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 17, 1, status_rec); break; }
                            case "16:30": { dataGridView1.Rows[18].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 18, 1, status_rec); break; }
                            case "17:00": { dataGridView1.Rows[19].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 19, 1, status_rec); break; }
                            case "17:30": { dataGridView1.Rows[20].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 20, 1, status_rec); break; }
                            case "18:00": { dataGridView1.Rows[21].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 21, 1, status_rec); break; }
                            case "18:30": { dataGridView1.Rows[22].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 22, 1, status_rec); break; }
                            case "19:00": { dataGridView1.Rows[23].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 23, 1, status_rec); break; }
                            case "19:30": { dataGridView1.Rows[24].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 24, 1, status_rec); break; }
                            case "20:00": { dataGridView1.Rows[25].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 25, 1, status_rec); break; }
                            case "20:30": { dataGridView1.Rows[26].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 26, 1, status_rec); break; }
                        };
                    }
                    else
                    {
                        if (date_rec == label8.Text)
                        {
                            switch (time_rec)
                            {
                                case "7:00": { dataGridView2.Rows[0].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 0, 1, status_rec); break; }
                                case "7:30": { dataGridView2.Rows[1].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 1, 1, status_rec); break; }
                                case "8:00": { dataGridView2.Rows[2].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 2, 1, status_rec); break; }
                                case "8:30": { dataGridView2.Rows[3].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 3, 1, status_rec); break; }
                                case "9:00": { dataGridView2.Rows[4].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 4, 1, status_rec); break; }
                                case "9:30": { dataGridView2.Rows[5].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 5, 1, status_rec); break; }
                                case "10:00": { dataGridView2.Rows[6].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 6, 1, status_rec); break; }
                                case "10:30": { dataGridView2.Rows[7].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 7, 1, status_rec); break; }
                                case "11:00": { dataGridView2.Rows[8].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 8, 1, status_rec); break; }
                                case "11:30": { dataGridView2.Rows[9].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 9, 1, status_rec); break; }
                                case "12:30": { dataGridView2.Rows[10].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 10, 1, status_rec); break; }
                                case "13:00": { dataGridView2.Rows[11].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 11, 1, status_rec); break; }
                                case "13:30": { dataGridView2.Rows[12].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 12, 1, status_rec); break; }
                                case "14:00": { dataGridView2.Rows[13].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 13, 1, status_rec); break; }
                                case "14:30": { dataGridView2.Rows[14].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 14, 1, status_rec); break; }
                                case "15:00": { dataGridView2.Rows[15].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 15, 1, status_rec); break; }
                                case "15:30": { dataGridView2.Rows[16].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 16, 1, status_rec); break; }
                                case "16:00": { dataGridView2.Rows[17].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 17, 1, status_rec); break; }
                                case "16:30": { dataGridView2.Rows[18].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 18, 1, status_rec); break; }
                                case "17:00": { dataGridView2.Rows[19].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 19, 1, status_rec); break; }
                                case "17:30": { dataGridView2.Rows[20].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 20, 1, status_rec); break; }
                                case "18:00": { dataGridView2.Rows[21].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 21, 1, status_rec); break; }
                                case "18:30": { dataGridView2.Rows[22].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 22, 1, status_rec); break; }
                                case "19:00": { dataGridView2.Rows[23].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 23, 1, status_rec); break; }
                                case "19:30": { dataGridView2.Rows[24].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 24, 1, status_rec); break; }
                                case "20:00": { dataGridView2.Rows[25].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 25, 1, status_rec); break; }
                                case "20:30": { dataGridView2.Rows[26].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 26, 1, status_rec); break; }
                            };
                        }
                        else
                        {
                            if (date_rec == label9.Text)
                            {
                                switch (time_rec)
                                {
                                    case "7:00": { dataGridView3.Rows[0].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 0, 1, status_rec); break; }
                                    case "7:30": { dataGridView3.Rows[1].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 1, 1, status_rec); break; }
                                    case "8:00": { dataGridView3.Rows[2].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 2, 1, status_rec); break; }
                                    case "8:30": { dataGridView3.Rows[3].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 3, 1, status_rec); break; }
                                    case "9:00": { dataGridView3.Rows[4].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 4, 1, status_rec); break; }
                                    case "9:30": { dataGridView3.Rows[5].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 5, 1, status_rec); break; }
                                    case "10:00": { dataGridView3.Rows[6].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 6, 1, status_rec); break; }
                                    case "10:30": { dataGridView3.Rows[7].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 7, 1, status_rec); break; }
                                    case "11:00": { dataGridView3.Rows[8].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 8, 1, status_rec); break; }
                                    case "11:30": { dataGridView3.Rows[9].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 9, 1, status_rec); break; }
                                    case "12:30": { dataGridView3.Rows[10].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 10, 1, status_rec); break; }
                                    case "13:00": { dataGridView3.Rows[11].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 11, 1, status_rec); break; }
                                    case "13:30": { dataGridView3.Rows[12].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 12, 1, status_rec); break; }
                                    case "14:00": { dataGridView3.Rows[13].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 13, 1, status_rec); break; }
                                    case "14:30": { dataGridView3.Rows[14].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 14, 1, status_rec); break; }
                                    case "15:00": { dataGridView3.Rows[15].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 15, 1, status_rec); break; }
                                    case "15:30": { dataGridView3.Rows[16].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 16, 1, status_rec); break; }
                                    case "16:00": { dataGridView3.Rows[17].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 17, 1, status_rec); break; }
                                    case "16:30": { dataGridView3.Rows[18].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 18, 1, status_rec); break; }
                                    case "17:00": { dataGridView3.Rows[19].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 19, 1, status_rec); break; }
                                    case "17:30": { dataGridView3.Rows[20].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 20, 1, status_rec); break; }
                                    case "18:00": { dataGridView3.Rows[21].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 21, 1, status_rec); break; }
                                    case "18:30": { dataGridView3.Rows[22].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 22, 1, status_rec); break; }
                                    case "19:00": { dataGridView3.Rows[23].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 23, 1, status_rec); break; }
                                    case "19:30": { dataGridView3.Rows[24].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 24, 1, status_rec); break; }
                                    case "20:00": { dataGridView3.Rows[25].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 25, 1, status_rec); break; }
                                    case "20:30": { dataGridView3.Rows[26].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 26, 1, status_rec); break; }
                                };
                            }
                            else
                            {
                                if (date_rec == label10.Text)
                                {
                                    switch (time_rec)
                                    {
                                        case "7:00": { dataGridView4.Rows[0].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 0, 1, status_rec); break; }
                                        case "7:30": { dataGridView4.Rows[1].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 1, 1, status_rec); break; }
                                        case "8:00": { dataGridView4.Rows[2].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 2, 1, status_rec); break; }
                                        case "8:30": { dataGridView4.Rows[3].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 3, 1, status_rec); break; }
                                        case "9:00": { dataGridView4.Rows[4].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 4, 1, status_rec); break; }
                                        case "9:30": { dataGridView4.Rows[5].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 5, 1, status_rec); break; }
                                        case "10:00": { dataGridView4.Rows[6].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 6, 1, status_rec); break; }
                                        case "10:30": { dataGridView4.Rows[7].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 7, 1, status_rec); break; }
                                        case "11:00": { dataGridView4.Rows[8].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 8, 1, status_rec); break; }
                                        case "11:30": { dataGridView4.Rows[9].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 9, 1, status_rec); break; }
                                        case "12:30": { dataGridView4.Rows[10].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 10, 1, status_rec); break; }
                                        case "13:00": { dataGridView4.Rows[11].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 11, 1, status_rec); break; }
                                        case "13:30": { dataGridView4.Rows[12].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 12, 1, status_rec); break; }
                                        case "14:00": { dataGridView4.Rows[13].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 13, 1, status_rec); break; }
                                        case "14:30": { dataGridView4.Rows[14].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 14, 1, status_rec); break; }
                                        case "15:00": { dataGridView4.Rows[15].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 15, 1, status_rec); break; }
                                        case "15:30": { dataGridView4.Rows[16].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 16, 1, status_rec); break; }
                                        case "16:00": { dataGridView4.Rows[17].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 17, 1, status_rec); break; }
                                        case "16:30": { dataGridView4.Rows[18].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 18, 1, status_rec); break; }
                                        case "17:00": { dataGridView4.Rows[19].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 19, 1, status_rec); break; }
                                        case "17:30": { dataGridView4.Rows[20].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 20, 1, status_rec); break; }
                                        case "18:00": { dataGridView4.Rows[21].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 21, 1, status_rec); break; }
                                        case "18:30": { dataGridView4.Rows[22].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 22, 1, status_rec); break; }
                                        case "19:00": { dataGridView4.Rows[23].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 23, 1, status_rec); break; }
                                        case "19:30": { dataGridView4.Rows[24].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 24, 1, status_rec); break; }
                                        case "20:00": { dataGridView4.Rows[25].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 25, 1, status_rec); break; }
                                        case "20:30": { dataGridView4.Rows[26].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 26, 1, status_rec); break; }
                                    };
                                }
                                else
                                {
                                    if (date_rec == label11.Text)
                                    {
                                        switch (time_rec)
                                        {
                                            case "7:00": { dataGridView6.Rows[0].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 0, 1, status_rec); break; }
                                            case "7:30": { dataGridView6.Rows[1].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 1, 1, status_rec); break; }
                                            case "8:00": { dataGridView6.Rows[2].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 2, 1, status_rec); break; }
                                            case "8:30": { dataGridView6.Rows[3].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 3, 1, status_rec); break; }
                                            case "9:00": { dataGridView6.Rows[4].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 4, 1, status_rec); break; }
                                            case "9:30": { dataGridView6.Rows[5].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 5, 1, status_rec); break; }
                                            case "10:00": { dataGridView6.Rows[6].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 6, 1, status_rec); break; }
                                            case "10:30": { dataGridView6.Rows[7].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 7, 1, status_rec); break; }
                                            case "11:00": { dataGridView6.Rows[8].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 8, 1, status_rec); break; }
                                            case "11:30": { dataGridView6.Rows[9].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 9, 1, status_rec); break; }
                                            case "12:30": { dataGridView6.Rows[10].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 10, 1, status_rec); break; }
                                            case "13:00": { dataGridView6.Rows[11].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 11, 1, status_rec); break; }
                                            case "13:30": { dataGridView6.Rows[12].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 12, 1, status_rec); break; }
                                            case "14:00": { dataGridView6.Rows[13].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 13, 1, status_rec); break; }
                                            case "14:30": { dataGridView6.Rows[14].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 14, 1, status_rec); break; }
                                            case "15:00": { dataGridView6.Rows[15].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 15, 1, status_rec); break; }
                                            case "15:30": { dataGridView6.Rows[16].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 16, 1, status_rec); break; }
                                            case "16:00": { dataGridView6.Rows[17].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 17, 1, status_rec); break; }
                                            case "16:30": { dataGridView6.Rows[18].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 18, 1, status_rec); break; }
                                            case "17:00": { dataGridView6.Rows[19].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 19, 1, status_rec); break; }
                                            case "17:30": { dataGridView6.Rows[20].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 20, 1, status_rec); break; }
                                            case "18:00": { dataGridView6.Rows[21].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 21, 1, status_rec); break; }
                                            case "18:30": { dataGridView6.Rows[22].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 22, 1, status_rec); break; }
                                            case "19:00": { dataGridView6.Rows[23].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 23, 1, status_rec); break; }
                                            case "19:30": { dataGridView6.Rows[24].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 24, 1, status_rec); break; }
                                            case "20:00": { dataGridView6.Rows[25].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 25, 1, status_rec); break; }
                                            case "20:30": { dataGridView6.Rows[26].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 26, 1, status_rec); break; }
                                        };
                                    }
                                    else
                                    {
                                        if (date_rec == label12.Text)
                                        {
                                            switch (time_rec)
                                            {
                                                case "7:00": { dataGridView5.Rows[0].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 0, 1, status_rec); break; }
                                                case "7:30": { dataGridView5.Rows[1].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 1, 1, status_rec); break; }
                                                case "8:00": { dataGridView5.Rows[2].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 2, 1, status_rec); break; }
                                                case "8:30": { dataGridView5.Rows[3].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 3, 1, status_rec); break; }
                                                case "9:00": { dataGridView5.Rows[4].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 4, 1, status_rec); break; }
                                                case "9:30": { dataGridView5.Rows[5].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 5, 1, status_rec); break; }
                                                case "10:00": { dataGridView5.Rows[6].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 6, 1, status_rec); break; }
                                                case "10:30": { dataGridView5.Rows[7].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 7, 1, status_rec); break; }
                                                case "11:00": { dataGridView5.Rows[8].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 8, 1, status_rec); break; }
                                                case "11:30": { dataGridView5.Rows[9].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 9, 1, status_rec); break; }
                                                case "12:30": { dataGridView5.Rows[10].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 10, 1, status_rec); break; }
                                                case "13:00": { dataGridView5.Rows[11].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 11, 1, status_rec); break; }
                                                case "13:30": { dataGridView5.Rows[12].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 12, 1, status_rec); break; }
                                                case "14:00": { dataGridView5.Rows[13].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 13, 1, status_rec); break; }
                                                case "14:30": { dataGridView5.Rows[14].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 14, 1, status_rec); break; }
                                                case "15:00": { dataGridView5.Rows[15].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 15, 1, status_rec); break; }
                                                case "15:30": { dataGridView5.Rows[16].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 16, 1, status_rec); break; }
                                                case "16:00": { dataGridView5.Rows[17].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 17, 1, status_rec); break; }
                                                case "16:30": { dataGridView5.Rows[18].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 18, 1, status_rec); break; }
                                                case "17:00": { dataGridView5.Rows[19].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 19, 1, status_rec); break; }
                                                case "17:30": { dataGridView5.Rows[20].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 20, 1, status_rec); break; }
                                                case "18:00": { dataGridView5.Rows[21].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 21, 1, status_rec); break; }
                                                case "18:30": { dataGridView5.Rows[22].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 22, 1, status_rec); break; }
                                                case "19:00": { dataGridView5.Rows[23].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 23, 1, status_rec); break; }
                                                case "19:30": { dataGridView5.Rows[24].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 24, 1, status_rec); break; }
                                                case "20:00": { dataGridView5.Rows[25].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 25, 1, status_rec); break; }
                                                case "20:30": { dataGridView5.Rows[26].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 26, 1, status_rec); break; }
                                            };
                                        }
                                    }
                                }
                            }
                        }
                    }

                }
            }
        }

        private void FMain_Shown(object sender, EventArgs e)
        {
            Medicine_Data data = new Medicine_Data();
            MedicineContext context = new MedicineContext();
            GlobalVar vr = new GlobalVar();
            label1.ForeColor = DefaultForeColor;
            label2.ForeColor = DefaultForeColor;
            label3.ForeColor = DefaultForeColor;
            label4.ForeColor = DefaultForeColor;
            label5.ForeColor = DefaultForeColor;
            label6.ForeColor = DefaultForeColor;
            DateTime date = Convert.ToDateTime(dateTimePicker1.Text);
            GlobalVar.SelectedDate = Convert.ToDateTime(dateTimePicker1.Text);
            GlobalVar.Start_Week_Date = Convert.ToDateTime(vr.StartWeek(GlobalVar.SelectedDate));
            GlobalVar.End_Week_Date = Convert.ToDateTime(vr.EndWeek(GlobalVar.SelectedDate));
            GlobalVar.acc_type = context.Doc_Accounts.Where(c => c.doc_login == GlobalVar.signIn_login).Select(c => c.doc_type).FirstOrDefault().ToString();
            int sign_doc_id = Convert.ToInt32(context.Doc_Accounts.Where(c => c.doc_login == GlobalVar.signIn_login).Select(c => c.doctor_id).FirstOrDefault());

            switch (GlobalVar.acc_type)
            {
                case "Админ":
                    {
                        doc_job_lbl.Text = context.Doctors.Where(c => c.doctor_id == sign_doc_id).Select(c => c.job_name).FirstOrDefault().ToString();
                        doc_name_lbl.Text = context.Doctors.Where(c => c.doctor_id == sign_doc_id).Select(c => c.doctor_name).FirstOrDefault().ToString();
                        if (context.Doctors.Count() > 0)
                        {
                            treeView1.Nodes[0].Nodes.Clear();
                            foreach (var r in context.Doctors.ToList())
                            {
                                treeView1.Nodes[0].Nodes.Add(String.Format(r.doctor_name.ToString() + "," + r.room_number.ToString()));
                            }
                            treeView1.Nodes[0].Expand();
                            TreeNode _node = treeView1.Nodes[0].Nodes[0];
                            treeView1.SelectedNode = _node;
                        }
                        break;
                    }
                case "Врач":
                    {
                        GlobalVar.FMain_selected_docid = sign_doc_id;
                        data.GetDoctorReceptionsIDs(GlobalVar.FMain_selected_docid);

                        doc_job_lbl.Text = context.Doctors.Where(c => c.doctor_id == sign_doc_id).Select(c => c.job_name).FirstOrDefault().ToString();
                        doc_name_lbl.Text = context.Doctors.Where(c => c.doctor_id == sign_doc_id).Select(c => c.doctor_name).FirstOrDefault().ToString();
                        treeView1.Nodes[0].Nodes.Clear();
                        treeView1.Enabled = false;

                        DoctorsToolStripMenuItem.Enabled = false;
                        DoctorsToolStripMenuItem.Visible = false;

                        ServicesToolStripMenuItem.Enabled = false;
                        ServicesToolStripMenuItem.Visible = false;

                        ReportsToolStripMenuItem.Enabled = false;
                        ReportsToolStripMenuItem.Visible = false;

                        PreparationsToolStripMenuItem.Enabled = false;
                        PreparationsToolStripMenuItem.Visible = false;

                        InspectionToolStripMenuItem.Enabled = false;
                        InspectionToolStripMenuItem.Visible = false;

                        break;
                    }
                case "Лаборатория":
                    {
                        GlobalVar.FMain_selected_docid = sign_doc_id;
                        data.GetDoctorReceptionsIDs(GlobalVar.FMain_selected_docid);

                        doc_job_lbl.Text = context.Doctors.Where(c => c.doctor_id == sign_doc_id).Select(c => c.job_name).FirstOrDefault().ToString();
                        doc_name_lbl.Text = context.Doctors.Where(c => c.doctor_id == sign_doc_id).Select(c => c.doctor_name).FirstOrDefault().ToString();
                        treeView1.Nodes[0].Nodes.Clear();
                        treeView1.Enabled = false;

                        DoctorsToolStripMenuItem.Enabled = false;
                        DoctorsToolStripMenuItem.Visible = false;

                        ServicesToolStripMenuItem.Enabled = false;
                        ServicesToolStripMenuItem.Visible = false;

                        ReportsToolStripMenuItem.Enabled = false;
                        ReportsToolStripMenuItem.Visible = false;

                        break;
                    }
            };

            /*
            if (acc_type == "Админ")
            {
                doc_job_lbl.Text = context.Doctors.Where(c => c.doctor_id == sign_doc_id).Select(c => c.job_name).FirstOrDefault().ToString();
                doc_name_lbl.Text = context.Doctors.Where(c => c.doctor_id == sign_doc_id).Select(c => c.doctor_name).FirstOrDefault().ToString(); ;
                if(context.Doctors.Count() > 0)
                {
                    treeView1.Nodes[0].Nodes.Clear();
                    foreach (var r in context.Doctors.ToList())
                    {
                        treeView1.Nodes[0].Nodes.Add(String.Format(r.doctor_name.ToString() + "," + r.room_number.ToString()));
                    }
                    treeView1.Nodes[0].Expand();
                    TreeNode _node = treeView1.Nodes[0].Nodes[0];
                    treeView1.SelectedNode = _node;
                }
            }
            else
            {
                GlobalVar.doc_signin_id = Convert.ToInt32(context.Doc_Accounts.Where(c => c.doc_login == GlobalVar.signIn_login).Select(c => c.doctor_id).FirstOrDefault());
                GlobalVar.FMain_selected_docid = GlobalVar.doc_signin_id;
                data.GetDoctorReceptionsIDs(GlobalVar.FMain_selected_docid);

                doc_job_lbl.Text = context.Doctors.Where(c => c.doctor_id == GlobalVar.doc_signin_id).Select(c => c.job_name).FirstOrDefault().ToString();
                doc_name_lbl.Text = context.Doctors.Where(c => c.doctor_id == GlobalVar.doc_signin_id).Select(c => c.doctor_name).FirstOrDefault().ToString();
                treeView1.Enabled = false;
            }
            */
            vr.GridDataAdd(dataGridView1);
            vr.GridDataAdd(dataGridView2);
            vr.GridDataAdd(dataGridView3);
            vr.GridDataAdd(dataGridView4);
            vr.GridDataAdd(dataGridView5);
            vr.GridDataAdd(dataGridView6);

            


            vr.SetContextMenu_Cells(dataGridView1, contextMenuStrip1);
            vr.SetContextMenu_Cells(dataGridView2, contextMenuStrip1);
            vr.SetContextMenu_Cells(dataGridView3, contextMenuStrip1);
            vr.SetContextMenu_Cells(dataGridView4, contextMenuStrip1);
            vr.SetContextMenu_Cells(dataGridView5, contextMenuStrip1);
            vr.SetContextMenu_Cells(dataGridView6, contextMenuStrip1);

            label7.Text = GlobalVar.Start_Week_Date.ToShortDateString();
            label8.Text = GlobalVar.Start_Week_Date.AddDays(1).ToShortDateString();
            label9.Text = GlobalVar.Start_Week_Date.AddDays(2).ToShortDateString();
            label10.Text = GlobalVar.Start_Week_Date.AddDays(3).ToShortDateString();
            label11.Text = GlobalVar.Start_Week_Date.AddDays(4).ToShortDateString();
            label12.Text = GlobalVar.End_Week_Date.ToShortDateString();


            switch (date.DayOfWeek.ToString())
            {
                case "Monday": { label1.ForeColor = Color.Red; break; }
                case "Tuesday": { label2.ForeColor = Color.Red; break; }
                case "Wednesday": { label3.ForeColor = Color.Red; break; }
                case "Thursday": { label4.ForeColor = Color.Red; break; }
                case "Friday": { label5.ForeColor = Color.Red; break; }
                case "Saturday": { label6.ForeColor = Color.Red; break; }
            }
            


            //Проверяем на наличие записей на этой неделе
            if (GlobalVar.reception_doctor_ids.Count > 0)
            {
                foreach(var r in GlobalVar.reception_doctor_ids)
                {
                    string date_rec = context.Receptions.Where(c => c.reception_id == r).Select(c => c.date_reception).FirstOrDefault().ToString();
                    string time_rec = context.Receptions.Where(c => c.reception_id == r).Select(c => c.time_reception).FirstOrDefault().ToString();
                    string status_rec = context.Receptions.Where(c => c.reception_id == r).Select(c => c.reception_status).FirstOrDefault().ToString();
                    int patient_rec = Convert.ToInt32(context.Receptions.Where(c => c.reception_id == r).Select(c => c.patient_id).FirstOrDefault().ToString());
                    string patient_rec_name = context.Patients.Where(c => c.patient_id == patient_rec).Select(c => c.patient_name).FirstOrDefault().ToString();
                    if (date_rec == label7.Text)
                    {
                        switch (time_rec)
                        {
                            case "7:00": { dataGridView1.Rows[0].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 0, 1, status_rec);  break; }
                            case  "7:30": { dataGridView1.Rows[1].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 1, 1, status_rec); break; }
                            case "8:00": { dataGridView1.Rows[2].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 2, 1, status_rec); break; }
                            case "8:30": { dataGridView1.Rows[3].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 3, 1, status_rec); break; }
                            case "9:00": { dataGridView1.Rows[4].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 4, 1, status_rec); break; }
                            case "9:30": { dataGridView1.Rows[5].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 5, 1, status_rec); break; }
                            case "10:00": { dataGridView1.Rows[6].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 6, 1, status_rec); break; }
                            case "10:30": { dataGridView1.Rows[7].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 7, 1, status_rec); break; }
                            case "11:00": { dataGridView1.Rows[8].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 8, 1, status_rec); break; }
                            case "11:30": { dataGridView1.Rows[9].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 9, 1, status_rec); break; }
                            case "12:30": { dataGridView1.Rows[10].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 10, 1, status_rec); break; }
                            case "13:00": { dataGridView1.Rows[11].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 11, 1, status_rec); break; }
                            case "13:30": { dataGridView1.Rows[12].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 12, 1, status_rec); break; }
                            case "14:00": { dataGridView1.Rows[13].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 13, 1, status_rec); break; }
                            case "14:30": { dataGridView1.Rows[14].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 14, 1, status_rec); break; }
                            case "15:00": { dataGridView1.Rows[15].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 15, 1, status_rec); break; }
                            case "15:30": { dataGridView1.Rows[16].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 16, 1, status_rec); break; }
                            case "16:00": { dataGridView1.Rows[17].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 17, 1, status_rec); break; }
                            case "16:30": { dataGridView1.Rows[18].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 18, 1, status_rec); break; }
                            case "17:00": { dataGridView1.Rows[19].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 19, 1, status_rec); break; }
                            case "17:30": { dataGridView1.Rows[20].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 20, 1, status_rec); break; }
                            case "18:00": { dataGridView1.Rows[21].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 21, 1, status_rec); break; }
                            case "18:30": { dataGridView1.Rows[22].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 22, 1, status_rec); break; }
                            case "19:00": { dataGridView1.Rows[23].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 23, 1, status_rec); break; }
                            case "19:30": { dataGridView1.Rows[24].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 24, 1, status_rec); break; }
                            case "20:00": { dataGridView1.Rows[25].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 25, 1, status_rec); break; }
                            case "20:30": { dataGridView1.Rows[26].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 26, 1, status_rec); break; }
                        };
                    }else
                    {
                        if (date_rec == label8.Text)
                        {
                            switch (time_rec)
                            {
                                case "7:00": { dataGridView2.Rows[0].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 0, 1, status_rec); break; }
                                case "7:30": { dataGridView2.Rows[1].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 1, 1, status_rec); break; }
                                case "8:00": { dataGridView2.Rows[2].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 2, 1, status_rec); break; }
                                case "8:30": { dataGridView2.Rows[3].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 3, 1, status_rec); break; }
                                case "9:00": { dataGridView2.Rows[4].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 4, 1, status_rec); break; }
                                case "9:30": { dataGridView2.Rows[5].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 5, 1, status_rec); break; }
                                case "10:00": { dataGridView2.Rows[6].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 6, 1, status_rec); break; }
                                case "10:30": { dataGridView2.Rows[7].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 7, 1, status_rec); break; }
                                case "11:00": { dataGridView2.Rows[8].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 8, 1, status_rec); break; }
                                case "11:30": { dataGridView2.Rows[9].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 9, 1, status_rec); break; }
                                case "12:30": { dataGridView2.Rows[10].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 10, 1, status_rec); break; }
                                case "13:00": { dataGridView2.Rows[11].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 11, 1, status_rec); break; }
                                case "13:30": { dataGridView2.Rows[12].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 12, 1, status_rec); break; }
                                case "14:00": { dataGridView2.Rows[13].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 13, 1, status_rec); break; }
                                case "14:30": { dataGridView2.Rows[14].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 14, 1, status_rec); break; }
                                case "15:00": { dataGridView2.Rows[15].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 15, 1, status_rec); break; }
                                case "15:30": { dataGridView2.Rows[16].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 16, 1, status_rec); break; }
                                case "16:00": { dataGridView2.Rows[17].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 17, 1, status_rec); break; }
                                case "16:30": { dataGridView2.Rows[18].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 18, 1, status_rec); break; }
                                case "17:00": { dataGridView2.Rows[19].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 19, 1, status_rec); break; }
                                case "17:30": { dataGridView2.Rows[20].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 20, 1, status_rec); break; }
                                case "18:00": { dataGridView2.Rows[21].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 21, 1, status_rec); break; }
                                case "18:30": { dataGridView2.Rows[22].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 22, 1, status_rec); break; }
                                case "19:00": { dataGridView2.Rows[23].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 23, 1, status_rec); break; }
                                case "19:30": { dataGridView2.Rows[24].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 24, 1, status_rec); break; }
                                case "20:00": { dataGridView2.Rows[25].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 25, 1, status_rec); break; }
                                case "20:30": { dataGridView2.Rows[26].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 26, 1, status_rec); break; }
                            };
                        }
                        else
                        {
                            if (date_rec == label9.Text)
                            {
                                switch (time_rec)
                                {
                                    case "7:00": { dataGridView3.Rows[0].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 0, 1, status_rec); break; }
                                    case "7:30": { dataGridView3.Rows[1].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 1, 1, status_rec); break; }
                                    case "8:00": { dataGridView3.Rows[2].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 2, 1, status_rec); break; }
                                    case "8:30": { dataGridView3.Rows[3].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 3, 1, status_rec); break; }
                                    case "9:00": { dataGridView3.Rows[4].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 4, 1, status_rec); break; }
                                    case "9:30": { dataGridView3.Rows[5].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 5, 1, status_rec); break; }
                                    case "10:00": { dataGridView3.Rows[6].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 6, 1, status_rec); break; }
                                    case "10:30": { dataGridView3.Rows[7].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 7, 1, status_rec); break; }
                                    case "11:00": { dataGridView3.Rows[8].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 8, 1, status_rec); break; }
                                    case "11:30": { dataGridView3.Rows[9].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 9, 1, status_rec); break; }
                                    case "12:30": { dataGridView3.Rows[10].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 10, 1, status_rec); break; }
                                    case "13:00": { dataGridView3.Rows[11].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 11, 1, status_rec); break; }
                                    case "13:30": { dataGridView3.Rows[12].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 12, 1, status_rec); break; }
                                    case "14:00": { dataGridView3.Rows[13].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 13, 1, status_rec); break; }
                                    case "14:30": { dataGridView3.Rows[14].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 14, 1, status_rec); break; }
                                    case "15:00": { dataGridView3.Rows[15].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 15, 1, status_rec); break; }
                                    case "15:30": { dataGridView3.Rows[16].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 16, 1, status_rec); break; }
                                    case "16:00": { dataGridView3.Rows[17].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 17, 1, status_rec); break; }
                                    case "16:30": { dataGridView3.Rows[18].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 18, 1, status_rec); break; }
                                    case "17:00": { dataGridView3.Rows[19].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 19, 1, status_rec); break; }
                                    case "17:30": { dataGridView3.Rows[20].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 20, 1, status_rec); break; }
                                    case "18:00": { dataGridView3.Rows[21].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 21, 1, status_rec); break; }
                                    case "18:30": { dataGridView3.Rows[22].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 22, 1, status_rec); break; }
                                    case "19:00": { dataGridView3.Rows[23].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 23, 1, status_rec); break; }
                                    case "19:30": { dataGridView3.Rows[24].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 24, 1, status_rec); break; }
                                    case "20:00": { dataGridView3.Rows[25].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 25, 1, status_rec); break; }
                                    case "20:30": { dataGridView3.Rows[26].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 26, 1, status_rec); break; }
                                };
                            }
                            else
                            {
                                if (date_rec == label10.Text)
                                {
                                    switch (time_rec)
                                    {
                                        case "7:00": { dataGridView4.Rows[0].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 0, 1, status_rec); break; }
                                        case "7:30": { dataGridView4.Rows[1].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 1, 1, status_rec); break; }
                                        case "8:00": { dataGridView4.Rows[2].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 2, 1, status_rec); break; }
                                        case "8:30": { dataGridView4.Rows[3].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 3, 1, status_rec); break; }
                                        case "9:00": { dataGridView4.Rows[4].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 4, 1, status_rec); break; }
                                        case "9:30": { dataGridView4.Rows[5].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 5, 1, status_rec); break; }
                                        case "10:00": { dataGridView4.Rows[6].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 6, 1, status_rec); break; }
                                        case "10:30": { dataGridView4.Rows[7].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 7, 1, status_rec); break; }
                                        case "11:00": { dataGridView4.Rows[8].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 8, 1, status_rec); break; }
                                        case "11:30": { dataGridView4.Rows[9].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 9, 1, status_rec); break; }
                                        case "12:30": { dataGridView4.Rows[10].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 10, 1, status_rec); break; }
                                        case "13:00": { dataGridView4.Rows[11].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 11, 1, status_rec); break; }
                                        case "13:30": { dataGridView4.Rows[12].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 12, 1, status_rec); break; }
                                        case "14:00": { dataGridView4.Rows[13].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 13, 1, status_rec); break; }
                                        case "14:30": { dataGridView4.Rows[14].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 14, 1, status_rec); break; }
                                        case "15:00": { dataGridView4.Rows[15].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 15, 1, status_rec); break; }
                                        case "15:30": { dataGridView4.Rows[16].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 16, 1, status_rec); break; }
                                        case "16:00": { dataGridView4.Rows[17].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 17, 1, status_rec); break; }
                                        case "16:30": { dataGridView4.Rows[18].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 18, 1, status_rec); break; }
                                        case "17:00": { dataGridView4.Rows[19].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 19, 1, status_rec); break; }
                                        case "17:30": { dataGridView4.Rows[20].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 20, 1, status_rec); break; }
                                        case "18:00": { dataGridView4.Rows[21].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 21, 1, status_rec); break; }
                                        case "18:30": { dataGridView4.Rows[22].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 22, 1, status_rec); break; }
                                        case "19:00": { dataGridView4.Rows[23].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 23, 1, status_rec); break; }
                                        case "19:30": { dataGridView4.Rows[24].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 24, 1, status_rec); break; }
                                        case "20:00": { dataGridView4.Rows[25].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 25, 1, status_rec); break; }
                                        case "20:30": { dataGridView4.Rows[26].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 26, 1, status_rec); break; }
                                    };
                                }
                                else
                                {
                                    if (date_rec == label11.Text)
                                    {
                                        switch (time_rec)
                                        {
                                            case "7:00": { dataGridView6.Rows[0].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 0, 1, status_rec); break; }
                                            case "7:30": { dataGridView6.Rows[1].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 1, 1, status_rec); break; }
                                            case "8:00": { dataGridView6.Rows[2].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 2, 1, status_rec); break; }
                                            case "8:30": { dataGridView6.Rows[3].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 3, 1, status_rec); break; }
                                            case "9:00": { dataGridView6.Rows[4].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 4, 1, status_rec); break; }
                                            case "9:30": { dataGridView6.Rows[5].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 5, 1, status_rec); break; }
                                            case "10:00": { dataGridView6.Rows[6].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 6, 1, status_rec); break; }
                                            case "10:30": { dataGridView6.Rows[7].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 7, 1, status_rec); break; }
                                            case "11:00": { dataGridView6.Rows[8].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 8, 1, status_rec); break; }
                                            case "11:30": { dataGridView6.Rows[9].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 9, 1, status_rec); break; }
                                            case "12:30": { dataGridView6.Rows[10].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 10, 1, status_rec); break; }
                                            case "13:00": { dataGridView6.Rows[11].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 11, 1, status_rec); break; }
                                            case "13:30": { dataGridView6.Rows[12].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 12, 1, status_rec); break; }
                                            case "14:00": { dataGridView6.Rows[13].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 13, 1, status_rec); break; }
                                            case "14:30": { dataGridView6.Rows[14].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 14, 1, status_rec); break; }
                                            case "15:00": { dataGridView6.Rows[15].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 15, 1, status_rec); break; }
                                            case "15:30": { dataGridView6.Rows[16].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 16, 1, status_rec); break; }
                                            case "16:00": { dataGridView6.Rows[17].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 17, 1, status_rec); break; }
                                            case "16:30": { dataGridView6.Rows[18].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 18, 1, status_rec); break; }
                                            case "17:00": { dataGridView6.Rows[19].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 19, 1, status_rec); break; }
                                            case "17:30": { dataGridView6.Rows[20].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 20, 1, status_rec); break; }
                                            case "18:00": { dataGridView6.Rows[21].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 21, 1, status_rec); break; }
                                            case "18:30": { dataGridView6.Rows[22].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 22, 1, status_rec); break; }
                                            case "19:00": { dataGridView6.Rows[23].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 23, 1, status_rec); break; }
                                            case "19:30": { dataGridView6.Rows[24].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 24, 1, status_rec); break; }
                                            case "20:00": { dataGridView6.Rows[25].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 25, 1, status_rec); break; }
                                            case "20:30": { dataGridView6.Rows[26].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 26, 1, status_rec); break; }
                                        };
                                    }
                                    else
                                    {
                                        if (date_rec == label12.Text)
                                        {
                                            switch (time_rec)
                                            {
                                                case "7:00": { dataGridView5.Rows[0].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 0, 1, status_rec); break; }
                                                case "7:30": { dataGridView5.Rows[1].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 1, 1, status_rec); break; }
                                                case "8:00": { dataGridView5.Rows[2].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 2, 1, status_rec); break; }
                                                case "8:30": { dataGridView5.Rows[3].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 3, 1, status_rec); break; }
                                                case "9:00": { dataGridView5.Rows[4].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 4, 1, status_rec); break; }
                                                case "9:30": { dataGridView5.Rows[5].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 5, 1, status_rec); break; }
                                                case "10:00": { dataGridView5.Rows[6].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 6, 1, status_rec); break; }
                                                case "10:30": { dataGridView5.Rows[7].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 7, 1, status_rec); break; }
                                                case "11:00": { dataGridView5.Rows[8].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 8, 1, status_rec); break; }
                                                case "11:30": { dataGridView5.Rows[9].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 9, 1, status_rec); break; }
                                                case "12:30": { dataGridView5.Rows[10].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 10, 1, status_rec); break; }
                                                case "13:00": { dataGridView5.Rows[11].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 11, 1, status_rec); break; }
                                                case "13:30": { dataGridView5.Rows[12].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 12, 1, status_rec); break; }
                                                case "14:00": { dataGridView5.Rows[13].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 13, 1, status_rec); break; }
                                                case "14:30": { dataGridView5.Rows[14].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 14, 1, status_rec); break; }
                                                case "15:00": { dataGridView5.Rows[15].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 15, 1, status_rec); break; }
                                                case "15:30": { dataGridView5.Rows[16].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 16, 1, status_rec); break; }
                                                case "16:00": { dataGridView5.Rows[17].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 17, 1, status_rec); break; }
                                                case "16:30": { dataGridView5.Rows[18].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 18, 1, status_rec); break; }
                                                case "17:00": { dataGridView5.Rows[19].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 19, 1, status_rec); break; }
                                                case "17:30": { dataGridView5.Rows[20].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 20, 1, status_rec); break; }
                                                case "18:00": { dataGridView5.Rows[21].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 21, 1, status_rec); break; }
                                                case "18:30": { dataGridView5.Rows[22].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 22, 1, status_rec); break; }
                                                case "19:00": { dataGridView5.Rows[23].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 23, 1, status_rec); break; }
                                                case "19:30": { dataGridView5.Rows[24].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 24, 1, status_rec); break; }
                                                case "20:00": { dataGridView5.Rows[25].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 25, 1, status_rec); break; }
                                                case "20:30": { dataGridView5.Rows[26].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 26, 1, status_rec); break; }
                                            };
                                        }
                                    }
                                }
                            }
                        }
                    }
                    
                }
            }

            vr.FreeFocus_ALL_Cells(dataGridView1);
            vr.FreeFocus_ALL_Cells(dataGridView2);
            vr.FreeFocus_ALL_Cells(dataGridView3);
            vr.FreeFocus_ALL_Cells(dataGridView4);
            vr.FreeFocus_ALL_Cells(dataGridView5);
            vr.FreeFocus_ALL_Cells(dataGridView6);

            vr.Grid_Stop_Sortable(dataGridView1);
            vr.Grid_Stop_Sortable(dataGridView2);
            vr.Grid_Stop_Sortable(dataGridView3);
            vr.Grid_Stop_Sortable(dataGridView4);
            vr.Grid_Stop_Sortable(dataGridView5);
            vr.Grid_Stop_Sortable(dataGridView6);
            
            

        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            GlobalVar vr = new GlobalVar();
            
            vr.FreeFocus_ALL_Cells(dataGridView2);
            vr.FreeFocus_ALL_Cells(dataGridView3);
            vr.FreeFocus_ALL_Cells(dataGridView4);
            vr.FreeFocus_ALL_Cells(dataGridView5);
            vr.FreeFocus_ALL_Cells(dataGridView6);

            vr.FreeFocus_From_Cells(dataGridView1, e);
            GlobalVar.selected_grid_RowIndex = e.RowIndex;
            GlobalVar.selected_grid = (sender as DataGridView).Name.ToString();
        }

        private void dataGridView2_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {


            GlobalVar vr = new GlobalVar();

            vr.FreeFocus_ALL_Cells(dataGridView1);
            vr.FreeFocus_ALL_Cells(dataGridView3);
            vr.FreeFocus_ALL_Cells(dataGridView4);
            vr.FreeFocus_ALL_Cells(dataGridView5);
            vr.FreeFocus_ALL_Cells(dataGridView6);

            vr.FreeFocus_From_Cells(dataGridView2, e);
            GlobalVar.selected_grid_RowIndex = e.RowIndex;
            GlobalVar.selected_grid = (sender as DataGridView).Name.ToString();
        }

        private void dataGridView3_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            GlobalVar vr = new GlobalVar();
            vr.FreeFocus_ALL_Cells(dataGridView1);
            vr.FreeFocus_ALL_Cells(dataGridView2);
            vr.FreeFocus_ALL_Cells(dataGridView4);
            vr.FreeFocus_ALL_Cells(dataGridView5);
            vr.FreeFocus_ALL_Cells(dataGridView6);

            vr.FreeFocus_From_Cells(dataGridView3, e);
            GlobalVar.selected_grid_RowIndex = e.RowIndex;
            GlobalVar.selected_grid = (sender as DataGridView).Name.ToString();
        }

        private void dataGridView4_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            GlobalVar vr = new GlobalVar();
            vr.FreeFocus_ALL_Cells(dataGridView1);
            vr.FreeFocus_ALL_Cells(dataGridView2);
            vr.FreeFocus_ALL_Cells(dataGridView3);
            vr.FreeFocus_ALL_Cells(dataGridView5);
            vr.FreeFocus_ALL_Cells(dataGridView6);

            vr.FreeFocus_From_Cells(dataGridView4, e);
            GlobalVar.selected_grid_RowIndex = e.RowIndex;
            GlobalVar.selected_grid = (sender as DataGridView).Name.ToString();
        }

        private void dataGridView6_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            GlobalVar vr = new GlobalVar();
            vr.FreeFocus_ALL_Cells(dataGridView1);
            vr.FreeFocus_ALL_Cells(dataGridView2);
            vr.FreeFocus_ALL_Cells(dataGridView3);
            vr.FreeFocus_ALL_Cells(dataGridView4);
            vr.FreeFocus_ALL_Cells(dataGridView5);

            vr.FreeFocus_From_Cells(dataGridView6, e);
            GlobalVar.selected_grid_RowIndex = e.RowIndex;
            GlobalVar.selected_grid = (sender as DataGridView).Name.ToString();
        }

        private void dataGridView5_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            GlobalVar vr = new GlobalVar();
            vr.FreeFocus_ALL_Cells(dataGridView1);
            vr.FreeFocus_ALL_Cells(dataGridView2);
            vr.FreeFocus_ALL_Cells(dataGridView3);
            vr.FreeFocus_ALL_Cells(dataGridView4);
            vr.FreeFocus_ALL_Cells(dataGridView6);

            vr.FreeFocus_From_Cells(dataGridView5, e);
            GlobalVar.selected_grid_RowIndex = e.RowIndex;
            GlobalVar.selected_grid = (sender as DataGridView).Name.ToString();
        }

        private void dataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void просмотрЗаписейToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FDocDataView view = new FDocDataView();
            view.ShowDialog();
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FCreateDoctor docC = new FCreateDoctor();
            docC.ShowDialog();
        }

        private void просмотретьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FMedications medicine = new FMedications();
            medicine.ShowDialog();
        }

        private void просмотрToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FResearches res = new FResearches();
            res.ShowDialog();
        }

        private void просмотрToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FServices ser = new FServices();
            ser.ShowDialog();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            MedicineContext context = new MedicineContext();
            GlobalVar vr = new GlobalVar();

            if(e.Node.Text != "Врач")
            {
                Medicine_Data data = new Medicine_Data();
                GlobalVar.FMain_selected_docid = data.GetSelectedNode_DoctorId(e.Node.Text);
                data.GetDoctorReceptionsIDs(GlobalVar.FMain_selected_docid);

            }

            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            dataGridView3.Rows.Clear();
            dataGridView4.Rows.Clear();
            dataGridView5.Rows.Clear();
            dataGridView6.Rows.Clear();

            vr.GridDataAdd(dataGridView1);
            vr.GridDataAdd(dataGridView2);
            vr.GridDataAdd(dataGridView3);
            vr.GridDataAdd(dataGridView4);
            vr.GridDataAdd(dataGridView5);
            vr.GridDataAdd(dataGridView6);




            vr.SetContextMenu_Cells(dataGridView1, contextMenuStrip1);
            vr.SetContextMenu_Cells(dataGridView2, contextMenuStrip1);
            vr.SetContextMenu_Cells(dataGridView3, contextMenuStrip1);
            vr.SetContextMenu_Cells(dataGridView4, contextMenuStrip1);
            vr.SetContextMenu_Cells(dataGridView5, contextMenuStrip1);
            vr.SetContextMenu_Cells(dataGridView6, contextMenuStrip1);

            vr.Grid_Stop_Sortable(dataGridView1);
            vr.Grid_Stop_Sortable(dataGridView2);
            vr.Grid_Stop_Sortable(dataGridView3);
            vr.Grid_Stop_Sortable(dataGridView4);
            vr.Grid_Stop_Sortable(dataGridView5);
            vr.Grid_Stop_Sortable(dataGridView6);

            vr.FreeFocus_ALL_Cells(dataGridView1);
            vr.FreeFocus_ALL_Cells(dataGridView2);
            vr.FreeFocus_ALL_Cells(dataGridView3);
            vr.FreeFocus_ALL_Cells(dataGridView4);
            vr.FreeFocus_ALL_Cells(dataGridView5);
            vr.FreeFocus_ALL_Cells(dataGridView6);

            

            //Проверяем на наличие записей на этой неделе
            if (GlobalVar.reception_doctor_ids.Count > 0)
            {
                foreach (var r in GlobalVar.reception_doctor_ids)
                {
                    string date_rec = context.Receptions.Where(c => c.reception_id == r).Select(c => c.date_reception).FirstOrDefault().ToString();
                    string time_rec = context.Receptions.Where(c => c.reception_id == r).Select(c => c.time_reception).FirstOrDefault().ToString();
                    string status_rec = context.Receptions.Where(c => c.reception_id == r).Select(c => c.reception_status).FirstOrDefault().ToString();
                    int patient_rec = Convert.ToInt32(context.Receptions.Where(c => c.reception_id == r).Select(c => c.patient_id).FirstOrDefault().ToString());
                    string patient_rec_name = context.Patients.Where(c => c.patient_id == patient_rec).Select(c => c.patient_name).FirstOrDefault().ToString();
                    if (date_rec == label7.Text)
                    {
                        switch (time_rec)
                        {
                            case "7:00": { dataGridView1.Rows[0].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 0, 1, status_rec); break; }
                            case "7:30": { dataGridView1.Rows[1].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 1, 1, status_rec); break; }
                            case "8:00": { dataGridView1.Rows[2].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 2, 1, status_rec); break; }
                            case "8:30": { dataGridView1.Rows[3].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 3, 1, status_rec); break; }
                            case "9:00": { dataGridView1.Rows[4].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 4, 1, status_rec); break; }
                            case "9:30": { dataGridView1.Rows[5].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 5, 1, status_rec); break; }
                            case "10:00": { dataGridView1.Rows[6].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 6, 1, status_rec); break; }
                            case "10:30": { dataGridView1.Rows[7].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 7, 1, status_rec); break; }
                            case "11:00": { dataGridView1.Rows[8].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 8, 1, status_rec); break; }
                            case "11:30": { dataGridView1.Rows[9].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 9, 1, status_rec); break; }
                            case "12:30": { dataGridView1.Rows[10].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 10, 1, status_rec); break; }
                            case "13:00": { dataGridView1.Rows[11].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 11, 1, status_rec); break; }
                            case "13:30": { dataGridView1.Rows[12].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 12, 1, status_rec); break; }
                            case "14:00": { dataGridView1.Rows[13].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 13, 1, status_rec); break; }
                            case "14:30": { dataGridView1.Rows[14].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 14, 1, status_rec); break; }
                            case "15:00": { dataGridView1.Rows[15].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 15, 1, status_rec); break; }
                            case "15:30": { dataGridView1.Rows[16].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 16, 1, status_rec); break; }
                            case "16:00": { dataGridView1.Rows[17].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 17, 1, status_rec); break; }
                            case "16:30": { dataGridView1.Rows[18].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 18, 1, status_rec); break; }
                            case "17:00": { dataGridView1.Rows[19].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 19, 1, status_rec); break; }
                            case "17:30": { dataGridView1.Rows[20].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 20, 1, status_rec); break; }
                            case "18:00": { dataGridView1.Rows[21].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 21, 1, status_rec); break; }
                            case "18:30": { dataGridView1.Rows[22].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 22, 1, status_rec); break; }
                            case "19:00": { dataGridView1.Rows[23].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 23, 1, status_rec); break; }
                            case "19:30": { dataGridView1.Rows[24].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 24, 1, status_rec); break; }
                            case "20:00": { dataGridView1.Rows[25].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 25, 1, status_rec); break; }
                            case "20:30": { dataGridView1.Rows[26].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 26, 1, status_rec); break; }
                        };
                    }
                    else
                    {
                        if (date_rec == label8.Text)
                        {
                            switch (time_rec)
                            {
                                case "7:00": { dataGridView2.Rows[0].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 0, 1, status_rec); break; }
                                case "7:30": { dataGridView2.Rows[1].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 1, 1, status_rec); break; }
                                case "8:00": { dataGridView2.Rows[2].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 2, 1, status_rec); break; }
                                case "8:30": { dataGridView2.Rows[3].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 3, 1, status_rec); break; }
                                case "9:00": { dataGridView2.Rows[4].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 4, 1, status_rec); break; }
                                case "9:30": { dataGridView2.Rows[5].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 5, 1, status_rec); break; }
                                case "10:00": { dataGridView2.Rows[6].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 6, 1, status_rec); break; }
                                case "10:30": { dataGridView2.Rows[7].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 7, 1, status_rec); break; }
                                case "11:00": { dataGridView2.Rows[8].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 8, 1, status_rec); break; }
                                case "11:30": { dataGridView2.Rows[9].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 9, 1, status_rec); break; }
                                case "12:30": { dataGridView2.Rows[10].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 10, 1, status_rec); break; }
                                case "13:00": { dataGridView2.Rows[11].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 11, 1, status_rec); break; }
                                case "13:30": { dataGridView2.Rows[12].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 12, 1, status_rec); break; }
                                case "14:00": { dataGridView2.Rows[13].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 13, 1, status_rec); break; }
                                case "14:30": { dataGridView2.Rows[14].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 14, 1, status_rec); break; }
                                case "15:00": { dataGridView2.Rows[15].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 15, 1, status_rec); break; }
                                case "15:30": { dataGridView2.Rows[16].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 16, 1, status_rec); break; }
                                case "16:00": { dataGridView2.Rows[17].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 17, 1, status_rec); break; }
                                case "16:30": { dataGridView2.Rows[18].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 18, 1, status_rec); break; }
                                case "17:00": { dataGridView2.Rows[19].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 19, 1, status_rec); break; }
                                case "17:30": { dataGridView2.Rows[20].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 20, 1, status_rec); break; }
                                case "18:00": { dataGridView2.Rows[21].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 21, 1, status_rec); break; }
                                case "18:30": { dataGridView2.Rows[22].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 22, 1, status_rec); break; }
                                case "19:00": { dataGridView2.Rows[23].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 23, 1, status_rec); break; }
                                case "19:30": { dataGridView2.Rows[24].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 24, 1, status_rec); break; }
                                case "20:00": { dataGridView2.Rows[25].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 25, 1, status_rec); break; }
                                case "20:30": { dataGridView2.Rows[26].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 26, 1, status_rec); break; }
                            };
                        }
                        else
                        {
                            if (date_rec == label9.Text)
                            {
                                switch (time_rec)
                                {
                                    case "7:00": { dataGridView3.Rows[0].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 0, 1, status_rec); break; }
                                    case "7:30": { dataGridView3.Rows[1].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 1, 1, status_rec); break; }
                                    case "8:00": { dataGridView3.Rows[2].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 2, 1, status_rec); break; }
                                    case "8:30": { dataGridView3.Rows[3].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 3, 1, status_rec); break; }
                                    case "9:00": { dataGridView3.Rows[4].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 4, 1, status_rec); break; }
                                    case "9:30": { dataGridView3.Rows[5].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 5, 1, status_rec); break; }
                                    case "10:00": { dataGridView3.Rows[6].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 6, 1, status_rec); break; }
                                    case "10:30": { dataGridView3.Rows[7].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 7, 1, status_rec); break; }
                                    case "11:00": { dataGridView3.Rows[8].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 8, 1, status_rec); break; }
                                    case "11:30": { dataGridView3.Rows[9].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 9, 1, status_rec); break; }
                                    case "12:30": { dataGridView3.Rows[10].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 10, 1, status_rec); break; }
                                    case "13:00": { dataGridView3.Rows[11].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 11, 1, status_rec); break; }
                                    case "13:30": { dataGridView3.Rows[12].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 12, 1, status_rec); break; }
                                    case "14:00": { dataGridView3.Rows[13].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 13, 1, status_rec); break; }
                                    case "14:30": { dataGridView3.Rows[14].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 14, 1, status_rec); break; }
                                    case "15:00": { dataGridView3.Rows[15].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 15, 1, status_rec); break; }
                                    case "15:30": { dataGridView3.Rows[16].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 16, 1, status_rec); break; }
                                    case "16:00": { dataGridView3.Rows[17].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 17, 1, status_rec); break; }
                                    case "16:30": { dataGridView3.Rows[18].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 18, 1, status_rec); break; }
                                    case "17:00": { dataGridView3.Rows[19].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 19, 1, status_rec); break; }
                                    case "17:30": { dataGridView3.Rows[20].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 20, 1, status_rec); break; }
                                    case "18:00": { dataGridView3.Rows[21].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 21, 1, status_rec); break; }
                                    case "18:30": { dataGridView3.Rows[22].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 22, 1, status_rec); break; }
                                    case "19:00": { dataGridView3.Rows[23].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 23, 1, status_rec); break; }
                                    case "19:30": { dataGridView3.Rows[24].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 24, 1, status_rec); break; }
                                    case "20:00": { dataGridView3.Rows[25].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 25, 1, status_rec); break; }
                                    case "20:30": { dataGridView3.Rows[26].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 26, 1, status_rec); break; }
                                };
                            }
                            else
                            {
                                if (date_rec == label10.Text)
                                {
                                    switch (time_rec)
                                    {
                                        case "7:00": { dataGridView4.Rows[0].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 0, 1, status_rec); break; }
                                        case "7:30": { dataGridView4.Rows[1].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 1, 1, status_rec); break; }
                                        case "8:00": { dataGridView4.Rows[2].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 2, 1, status_rec); break; }
                                        case "8:30": { dataGridView4.Rows[3].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 3, 1, status_rec); break; }
                                        case "9:00": { dataGridView4.Rows[4].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 4, 1, status_rec); break; }
                                        case "9:30": { dataGridView4.Rows[5].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 5, 1, status_rec); break; }
                                        case "10:00": { dataGridView4.Rows[6].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 6, 1, status_rec); break; }
                                        case "10:30": { dataGridView4.Rows[7].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 7, 1, status_rec); break; }
                                        case "11:00": { dataGridView4.Rows[8].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 8, 1, status_rec); break; }
                                        case "11:30": { dataGridView4.Rows[9].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 9, 1, status_rec); break; }
                                        case "12:30": { dataGridView4.Rows[10].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 10, 1, status_rec); break; }
                                        case "13:00": { dataGridView4.Rows[11].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 11, 1, status_rec); break; }
                                        case "13:30": { dataGridView4.Rows[12].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 12, 1, status_rec); break; }
                                        case "14:00": { dataGridView4.Rows[13].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 13, 1, status_rec); break; }
                                        case "14:30": { dataGridView4.Rows[14].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 14, 1, status_rec); break; }
                                        case "15:00": { dataGridView4.Rows[15].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 15, 1, status_rec); break; }
                                        case "15:30": { dataGridView4.Rows[16].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 16, 1, status_rec); break; }
                                        case "16:00": { dataGridView4.Rows[17].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 17, 1, status_rec); break; }
                                        case "16:30": { dataGridView4.Rows[18].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 18, 1, status_rec); break; }
                                        case "17:00": { dataGridView4.Rows[19].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 19, 1, status_rec); break; }
                                        case "17:30": { dataGridView4.Rows[20].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 20, 1, status_rec); break; }
                                        case "18:00": { dataGridView4.Rows[21].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 21, 1, status_rec); break; }
                                        case "18:30": { dataGridView4.Rows[22].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 22, 1, status_rec); break; }
                                        case "19:00": { dataGridView4.Rows[23].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 23, 1, status_rec); break; }
                                        case "19:30": { dataGridView4.Rows[24].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 24, 1, status_rec); break; }
                                        case "20:00": { dataGridView4.Rows[25].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 25, 1, status_rec); break; }
                                        case "20:30": { dataGridView4.Rows[26].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 26, 1, status_rec); break; }
                                    };
                                }
                                else
                                {
                                    if (date_rec == label11.Text)
                                    {
                                        switch (time_rec)
                                        {
                                            case "7:00": { dataGridView6.Rows[0].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 0, 1, status_rec); break; }
                                            case "7:30": { dataGridView6.Rows[1].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 1, 1, status_rec); break; }
                                            case "8:00": { dataGridView6.Rows[2].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 2, 1, status_rec); break; }
                                            case "8:30": { dataGridView6.Rows[3].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 3, 1, status_rec); break; }
                                            case "9:00": { dataGridView6.Rows[4].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 4, 1, status_rec); break; }
                                            case "9:30": { dataGridView6.Rows[5].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 5, 1, status_rec); break; }
                                            case "10:00": { dataGridView6.Rows[6].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 6, 1, status_rec); break; }
                                            case "10:30": { dataGridView6.Rows[7].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 7, 1, status_rec); break; }
                                            case "11:00": { dataGridView6.Rows[8].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 8, 1, status_rec); break; }
                                            case "11:30": { dataGridView6.Rows[9].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 9, 1, status_rec); break; }
                                            case "12:30": { dataGridView6.Rows[10].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 10, 1, status_rec); break; }
                                            case "13:00": { dataGridView6.Rows[11].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 11, 1, status_rec); break; }
                                            case "13:30": { dataGridView6.Rows[12].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 12, 1, status_rec); break; }
                                            case "14:00": { dataGridView6.Rows[13].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 13, 1, status_rec); break; }
                                            case "14:30": { dataGridView6.Rows[14].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 14, 1, status_rec); break; }
                                            case "15:00": { dataGridView6.Rows[15].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 15, 1, status_rec); break; }
                                            case "15:30": { dataGridView6.Rows[16].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 16, 1, status_rec); break; }
                                            case "16:00": { dataGridView6.Rows[17].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 17, 1, status_rec); break; }
                                            case "16:30": { dataGridView6.Rows[18].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 18, 1, status_rec); break; }
                                            case "17:00": { dataGridView6.Rows[19].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 19, 1, status_rec); break; }
                                            case "17:30": { dataGridView6.Rows[20].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 20, 1, status_rec); break; }
                                            case "18:00": { dataGridView6.Rows[21].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 21, 1, status_rec); break; }
                                            case "18:30": { dataGridView6.Rows[22].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 22, 1, status_rec); break; }
                                            case "19:00": { dataGridView6.Rows[23].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 23, 1, status_rec); break; }
                                            case "19:30": { dataGridView6.Rows[24].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 24, 1, status_rec); break; }
                                            case "20:00": { dataGridView6.Rows[25].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 25, 1, status_rec); break; }
                                            case "20:30": { dataGridView6.Rows[26].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 26, 1, status_rec); break; }
                                        };
                                    }
                                    else
                                    {
                                        if (date_rec == label12.Text)
                                        {
                                            switch (time_rec)
                                            {
                                                case "7:00": { dataGridView5.Rows[0].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 0, 1, status_rec); break; }
                                                case "7:30": { dataGridView5.Rows[1].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 1, 1, status_rec); break; }
                                                case "8:00": { dataGridView5.Rows[2].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 2, 1, status_rec); break; }
                                                case "8:30": { dataGridView5.Rows[3].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 3, 1, status_rec); break; }
                                                case "9:00": { dataGridView5.Rows[4].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 4, 1, status_rec); break; }
                                                case "9:30": { dataGridView5.Rows[5].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 5, 1, status_rec); break; }
                                                case "10:00": { dataGridView5.Rows[6].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 6, 1, status_rec); break; }
                                                case "10:30": { dataGridView5.Rows[7].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 7, 1, status_rec); break; }
                                                case "11:00": { dataGridView5.Rows[8].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 8, 1, status_rec); break; }
                                                case "11:30": { dataGridView5.Rows[9].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 9, 1, status_rec); break; }
                                                case "12:30": { dataGridView5.Rows[10].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 10, 1, status_rec); break; }
                                                case "13:00": { dataGridView5.Rows[11].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 11, 1, status_rec); break; }
                                                case "13:30": { dataGridView5.Rows[12].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 12, 1, status_rec); break; }
                                                case "14:00": { dataGridView5.Rows[13].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 13, 1, status_rec); break; }
                                                case "14:30": { dataGridView5.Rows[14].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 14, 1, status_rec); break; }
                                                case "15:00": { dataGridView5.Rows[15].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 15, 1, status_rec); break; }
                                                case "15:30": { dataGridView5.Rows[16].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 16, 1, status_rec); break; }
                                                case "16:00": { dataGridView5.Rows[17].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 17, 1, status_rec); break; }
                                                case "16:30": { dataGridView5.Rows[18].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 18, 1, status_rec); break; }
                                                case "17:00": { dataGridView5.Rows[19].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 19, 1, status_rec); break; }
                                                case "17:30": { dataGridView5.Rows[20].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 20, 1, status_rec); break; }
                                                case "18:00": { dataGridView5.Rows[21].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 21, 1, status_rec); break; }
                                                case "18:30": { dataGridView5.Rows[22].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 22, 1, status_rec); break; }
                                                case "19:00": { dataGridView5.Rows[23].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 23, 1, status_rec); break; }
                                                case "19:30": { dataGridView5.Rows[24].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 24, 1, status_rec); break; }
                                                case "20:00": { dataGridView5.Rows[25].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 25, 1, status_rec); break; }
                                                case "20:30": { dataGridView5.Rows[26].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 26, 1, status_rec); break; }
                                            };
                                        }
                                    }
                                }
                            }
                        }
                    }

                }
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
            
        }

        private void dataGridView2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }

        private void dataGridView3_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }

        private void dataGridView4_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }

        private void dataGridView6_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }

        private void dataGridView5_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }

        private void Set_patient_Item_Click(object sender, EventArgs e)
        {
            FSetReseption set_res = new FSetReseption();
            set_res.ShowDialog();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            switch (GlobalVar.selected_grid)
            {
                case "dataGridView1":
                    {
                        test_lbl.Text = GlobalVar.selected_grid + " " + GlobalVar.selected_grid_RowIndex.ToString();
                        if (dataGridView1.Rows[GlobalVar.selected_grid_RowIndex].Cells[1].Value != null)
                        {
                            Set_ColorCell_Item.Enabled = true;
                            Select_Record_Item.Enabled = true;
                            Delete_Record_Item.Enabled = true;
                            Set_patient_Item.Enabled = false;
                        }else
                        {
                            Set_patient_Item.Enabled = true;
                            Set_ColorCell_Item.Enabled = false;
                            Select_Record_Item.Enabled = false;
                            Delete_Record_Item.Enabled = false;
                            GlobalVar.selected_date_reception = label7.Text;
                            GlobalVar.selected_time_reception = dataGridView1.Rows[GlobalVar.selected_grid_RowIndex].Cells[0].Value.ToString();
                        }
                        break;
                    }
                case "dataGridView2":
                    {

                        if (dataGridView2.Rows[GlobalVar.selected_grid_RowIndex].Cells[1].Value != null)
                        {
                            Set_ColorCell_Item.Enabled = true;
                            Select_Record_Item.Enabled = true;
                            Delete_Record_Item.Enabled = true;
                            Set_patient_Item.Enabled = false;
                        }
                        else
                        {
                            Set_patient_Item.Enabled = true;
                            Set_ColorCell_Item.Enabled = false;
                            Select_Record_Item.Enabled = false;
                            Delete_Record_Item.Enabled = false;
                            GlobalVar.selected_date_reception = label8.Text;
                            GlobalVar.selected_time_reception = dataGridView2.Rows[GlobalVar.selected_grid_RowIndex].Cells[0].Value.ToString();
                        }
                        test_lbl.Text = GlobalVar.selected_grid + " " + GlobalVar.selected_grid_RowIndex.ToString();
                        break;
                    }
                case "dataGridView3":
                    {
                        if (dataGridView3.Rows[GlobalVar.selected_grid_RowIndex].Cells[1].Value != null)
                        {
                            Set_ColorCell_Item.Enabled = true;
                            Select_Record_Item.Enabled = true;
                            Delete_Record_Item.Enabled = true;
                            Set_patient_Item.Enabled = false;
                        }
                        else
                        {
                            Set_patient_Item.Enabled = true;
                            Set_ColorCell_Item.Enabled = false;
                            Select_Record_Item.Enabled = false;
                            Delete_Record_Item.Enabled = false;
                            GlobalVar.selected_date_reception = label9.Text;
                            GlobalVar.selected_time_reception = dataGridView3.Rows[GlobalVar.selected_grid_RowIndex].Cells[0].Value.ToString();
                        }
                        test_lbl.Text = GlobalVar.selected_grid + " " + GlobalVar.selected_grid_RowIndex.ToString();
                        break;
                    }
                case "dataGridView4":
                    {
                        if (dataGridView4.Rows[GlobalVar.selected_grid_RowIndex].Cells[1].Value != null)
                        {
                            Set_ColorCell_Item.Enabled = true;
                            Select_Record_Item.Enabled = true;
                            Delete_Record_Item.Enabled = true;
                            Set_patient_Item.Enabled = false;
                        }
                        else
                        {
                            Set_patient_Item.Enabled = true;
                            Set_ColorCell_Item.Enabled = false;
                            Select_Record_Item.Enabled = false;
                            Delete_Record_Item.Enabled = false;
                            GlobalVar.selected_date_reception = label10.Text;
                            GlobalVar.selected_time_reception = dataGridView4.Rows[GlobalVar.selected_grid_RowIndex].Cells[0].Value.ToString();
                        }
                        test_lbl.Text = GlobalVar.selected_grid + " " + GlobalVar.selected_grid_RowIndex.ToString();
                        break;
                    }
                case "dataGridView5":
                    {
                        if (dataGridView5.Rows[GlobalVar.selected_grid_RowIndex].Cells[1].Value != null)
                        {
                            Set_ColorCell_Item.Enabled = true;
                            Select_Record_Item.Enabled = true;
                            Delete_Record_Item.Enabled = true;
                            Set_patient_Item.Enabled = false;
                        }
                        else
                        {
                            Set_patient_Item.Enabled = true;
                            Set_ColorCell_Item.Enabled = false;
                            Select_Record_Item.Enabled = false;
                            Delete_Record_Item.Enabled = false;
                            GlobalVar.selected_date_reception = label12.Text;
                            GlobalVar.selected_time_reception = dataGridView5.Rows[GlobalVar.selected_grid_RowIndex].Cells[0].Value.ToString();
                        }
                        test_lbl.Text = GlobalVar.selected_grid + " " + GlobalVar.selected_grid_RowIndex.ToString();
                        break;
                    }
                case "dataGridView6":
                    {
                        if (dataGridView6.Rows[GlobalVar.selected_grid_RowIndex].Cells[1].Value != null)
                        {
                            Set_ColorCell_Item.Enabled = true;
                            Select_Record_Item.Enabled = true;
                            Delete_Record_Item.Enabled = true;
                            Set_patient_Item.Enabled = false;
                        }
                        else
                        {
                            Set_patient_Item.Enabled = true;
                            Set_ColorCell_Item.Enabled = false;
                            Select_Record_Item.Enabled = false;
                            Delete_Record_Item.Enabled = false;
                            GlobalVar.selected_date_reception = label11.Text;
                            GlobalVar.selected_time_reception = dataGridView6.Rows[GlobalVar.selected_grid_RowIndex].Cells[0].Value.ToString();
                        }
                        test_lbl.Text = GlobalVar.selected_grid +" "+ GlobalVar.selected_grid_RowIndex.ToString();
                        break;
                    }
            };
        }

        private void добавитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GlobalVar.set_patient_need = false;
            FPatientDataView vi = new FPatientDataView();
            vi.ShowDialog();
        }

        private void FMain_Activated(object sender, EventArgs e)
        {
            Medicine_Data data = new Medicine_Data();
            MedicineContext context = new MedicineContext();
            GlobalVar vr = new GlobalVar();

            switch (GlobalVar.acc_type)
            {
                case "Админ":
                    {
                        if (context.Doctors.Count() > 0)
                        {
                            treeView1.Nodes[0].Nodes.Clear();
                            foreach (var r in context.Doctors.ToList())
                            {
                                treeView1.Nodes[0].Nodes.Add(String.Format(r.doctor_name.ToString() + "," + r.room_number.ToString()));
                            }
                            treeView1.Nodes[0].Expand();
                            TreeNode _node = treeView1.Nodes[0].Nodes[0];
                            treeView1.SelectedNode = _node;
                        }
                        break;
                    }
                case "Врач":
                    {
                        treeView1.Nodes[0].Nodes.Clear();
                        treeView1.Enabled = false;
                        break;
                    }
                case "Лаборатория":
                    {
                        treeView1.Nodes[0].Nodes.Clear();
                        treeView1.Enabled = false;
                        break;
                    }
            };

            data.GetDoctorReceptionsIDs(GlobalVar.FMain_selected_docid);

            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            dataGridView3.Rows.Clear();
            dataGridView4.Rows.Clear();
            dataGridView5.Rows.Clear();
            dataGridView6.Rows.Clear();

            vr.GridDataAdd(dataGridView1);
            vr.GridDataAdd(dataGridView2);
            vr.GridDataAdd(dataGridView3);
            vr.GridDataAdd(dataGridView4);
            vr.GridDataAdd(dataGridView5);
            vr.GridDataAdd(dataGridView6);




            vr.SetContextMenu_Cells(dataGridView1, contextMenuStrip1);
            vr.SetContextMenu_Cells(dataGridView2, contextMenuStrip1);
            vr.SetContextMenu_Cells(dataGridView3, contextMenuStrip1);
            vr.SetContextMenu_Cells(dataGridView4, contextMenuStrip1);
            vr.SetContextMenu_Cells(dataGridView5, contextMenuStrip1);
            vr.SetContextMenu_Cells(dataGridView6, contextMenuStrip1);

            vr.Grid_Stop_Sortable(dataGridView1);
            vr.Grid_Stop_Sortable(dataGridView2);
            vr.Grid_Stop_Sortable(dataGridView3);
            vr.Grid_Stop_Sortable(dataGridView4);
            vr.Grid_Stop_Sortable(dataGridView5);
            vr.Grid_Stop_Sortable(dataGridView6);

            vr.FreeFocus_ALL_Cells(dataGridView1);
            vr.FreeFocus_ALL_Cells(dataGridView2);
            vr.FreeFocus_ALL_Cells(dataGridView3);
            vr.FreeFocus_ALL_Cells(dataGridView4);
            vr.FreeFocus_ALL_Cells(dataGridView5);
            vr.FreeFocus_ALL_Cells(dataGridView6);

            

            //Проверяем на наличие записей на этой неделе
            if (GlobalVar.reception_doctor_ids.Count > 0)
            {
                foreach (var r in GlobalVar.reception_doctor_ids)
                {
                    string date_rec = context.Receptions.Where(c => c.reception_id == r).Select(c => c.date_reception).FirstOrDefault().ToString();
                    string time_rec = context.Receptions.Where(c => c.reception_id == r).Select(c => c.time_reception).FirstOrDefault().ToString();
                    string status_rec = context.Receptions.Where(c => c.reception_id == r).Select(c => c.reception_status).FirstOrDefault().ToString();
                    int patient_rec = Convert.ToInt32(context.Receptions.Where(c => c.reception_id == r).Select(c => c.patient_id).FirstOrDefault().ToString());
                    string patient_rec_name = context.Patients.Where(c => c.patient_id == patient_rec).Select(c => c.patient_name).FirstOrDefault().ToString();
                    if (date_rec == label7.Text)
                    {
                        switch (time_rec)
                        {
                            case "7:00": { dataGridView1.Rows[0].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 0, 1, status_rec); break; }
                            case "7:30": { dataGridView1.Rows[1].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 1, 1, status_rec); break; }
                            case "8:00": { dataGridView1.Rows[2].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 2, 1, status_rec); break; }
                            case "8:30": { dataGridView1.Rows[3].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 3, 1, status_rec); break; }
                            case "9:00": { dataGridView1.Rows[4].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 4, 1, status_rec); break; }
                            case "9:30": { dataGridView1.Rows[5].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 5, 1, status_rec); break; }
                            case "10:00": { dataGridView1.Rows[6].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 6, 1, status_rec); break; }
                            case "10:30": { dataGridView1.Rows[7].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 7, 1, status_rec); break; }
                            case "11:00": { dataGridView1.Rows[8].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 8, 1, status_rec); break; }
                            case "11:30": { dataGridView1.Rows[9].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 9, 1, status_rec); break; }
                            case "12:30": { dataGridView1.Rows[10].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 10, 1, status_rec); break; }
                            case "13:00": { dataGridView1.Rows[11].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 11, 1, status_rec); break; }
                            case "13:30": { dataGridView1.Rows[12].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 12, 1, status_rec); break; }
                            case "14:00": { dataGridView1.Rows[13].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 13, 1, status_rec); break; }
                            case "14:30": { dataGridView1.Rows[14].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 14, 1, status_rec); break; }
                            case "15:00": { dataGridView1.Rows[15].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 15, 1, status_rec); break; }
                            case "15:30": { dataGridView1.Rows[16].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 16, 1, status_rec); break; }
                            case "16:00": { dataGridView1.Rows[17].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 17, 1, status_rec); break; }
                            case "16:30": { dataGridView1.Rows[18].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 18, 1, status_rec); break; }
                            case "17:00": { dataGridView1.Rows[19].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 19, 1, status_rec); break; }
                            case "17:30": { dataGridView1.Rows[20].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 20, 1, status_rec); break; }
                            case "18:00": { dataGridView1.Rows[21].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 21, 1, status_rec); break; }
                            case "18:30": { dataGridView1.Rows[22].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 22, 1, status_rec); break; }
                            case "19:00": { dataGridView1.Rows[23].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 23, 1, status_rec); break; }
                            case "19:30": { dataGridView1.Rows[24].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 24, 1, status_rec); break; }
                            case "20:00": { dataGridView1.Rows[25].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 25, 1, status_rec); break; }
                            case "20:30": { dataGridView1.Rows[26].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 26, 1, status_rec); break; }
                        };
                    }
                    else
                    {
                        if (date_rec == label8.Text)
                        {
                            switch (time_rec)
                            {
                                case "7:00": { dataGridView2.Rows[0].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 0, 1, status_rec); break; }
                                case "7:30": { dataGridView2.Rows[1].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 1, 1, status_rec); break; }
                                case "8:00": { dataGridView2.Rows[2].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 2, 1, status_rec); break; }
                                case "8:30": { dataGridView2.Rows[3].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 3, 1, status_rec); break; }
                                case "9:00": { dataGridView2.Rows[4].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 4, 1, status_rec); break; }
                                case "9:30": { dataGridView2.Rows[5].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 5, 1, status_rec); break; }
                                case "10:00": { dataGridView2.Rows[6].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 6, 1, status_rec); break; }
                                case "10:30": { dataGridView2.Rows[7].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 7, 1, status_rec); break; }
                                case "11:00": { dataGridView2.Rows[8].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 8, 1, status_rec); break; }
                                case "11:30": { dataGridView2.Rows[9].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 9, 1, status_rec); break; }
                                case "12:30": { dataGridView2.Rows[10].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 10, 1, status_rec); break; }
                                case "13:00": { dataGridView2.Rows[11].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 11, 1, status_rec); break; }
                                case "13:30": { dataGridView2.Rows[12].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 12, 1, status_rec); break; }
                                case "14:00": { dataGridView2.Rows[13].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 13, 1, status_rec); break; }
                                case "14:30": { dataGridView2.Rows[14].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 14, 1, status_rec); break; }
                                case "15:00": { dataGridView2.Rows[15].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 15, 1, status_rec); break; }
                                case "15:30": { dataGridView2.Rows[16].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 16, 1, status_rec); break; }
                                case "16:00": { dataGridView2.Rows[17].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 17, 1, status_rec); break; }
                                case "16:30": { dataGridView2.Rows[18].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 18, 1, status_rec); break; }
                                case "17:00": { dataGridView2.Rows[19].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 19, 1, status_rec); break; }
                                case "17:30": { dataGridView2.Rows[20].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 20, 1, status_rec); break; }
                                case "18:00": { dataGridView2.Rows[21].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 21, 1, status_rec); break; }
                                case "18:30": { dataGridView2.Rows[22].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 22, 1, status_rec); break; }
                                case "19:00": { dataGridView2.Rows[23].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 23, 1, status_rec); break; }
                                case "19:30": { dataGridView2.Rows[24].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 24, 1, status_rec); break; }
                                case "20:00": { dataGridView2.Rows[25].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 25, 1, status_rec); break; }
                                case "20:30": { dataGridView2.Rows[26].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 26, 1, status_rec); break; }
                            };
                        }
                        else
                        {
                            if (date_rec == label9.Text)
                            {
                                switch (time_rec)
                                {
                                    case "7:00": { dataGridView3.Rows[0].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 0, 1, status_rec); break; }
                                    case "7:30": { dataGridView3.Rows[1].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 1, 1, status_rec); break; }
                                    case "8:00": { dataGridView3.Rows[2].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 2, 1, status_rec); break; }
                                    case "8:30": { dataGridView3.Rows[3].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 3, 1, status_rec); break; }
                                    case "9:00": { dataGridView3.Rows[4].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 4, 1, status_rec); break; }
                                    case "9:30": { dataGridView3.Rows[5].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 5, 1, status_rec); break; }
                                    case "10:00": { dataGridView3.Rows[6].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 6, 1, status_rec); break; }
                                    case "10:30": { dataGridView3.Rows[7].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 7, 1, status_rec); break; }
                                    case "11:00": { dataGridView3.Rows[8].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 8, 1, status_rec); break; }
                                    case "11:30": { dataGridView3.Rows[9].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 9, 1, status_rec); break; }
                                    case "12:30": { dataGridView3.Rows[10].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 10, 1, status_rec); break; }
                                    case "13:00": { dataGridView3.Rows[11].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 11, 1, status_rec); break; }
                                    case "13:30": { dataGridView3.Rows[12].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 12, 1, status_rec); break; }
                                    case "14:00": { dataGridView3.Rows[13].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 13, 1, status_rec); break; }
                                    case "14:30": { dataGridView3.Rows[14].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 14, 1, status_rec); break; }
                                    case "15:00": { dataGridView3.Rows[15].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 15, 1, status_rec); break; }
                                    case "15:30": { dataGridView3.Rows[16].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 16, 1, status_rec); break; }
                                    case "16:00": { dataGridView3.Rows[17].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 17, 1, status_rec); break; }
                                    case "16:30": { dataGridView3.Rows[18].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 18, 1, status_rec); break; }
                                    case "17:00": { dataGridView3.Rows[19].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 19, 1, status_rec); break; }
                                    case "17:30": { dataGridView3.Rows[20].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 20, 1, status_rec); break; }
                                    case "18:00": { dataGridView3.Rows[21].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 21, 1, status_rec); break; }
                                    case "18:30": { dataGridView3.Rows[22].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 22, 1, status_rec); break; }
                                    case "19:00": { dataGridView3.Rows[23].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 23, 1, status_rec); break; }
                                    case "19:30": { dataGridView3.Rows[24].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 24, 1, status_rec); break; }
                                    case "20:00": { dataGridView3.Rows[25].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 25, 1, status_rec); break; }
                                    case "20:30": { dataGridView3.Rows[26].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 26, 1, status_rec); break; }
                                };
                            }
                            else
                            {
                                if (date_rec == label10.Text)
                                {
                                    switch (time_rec)
                                    {
                                        case "7:00": { dataGridView4.Rows[0].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 0, 1, status_rec); break; }
                                        case "7:30": { dataGridView4.Rows[1].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 1, 1, status_rec); break; }
                                        case "8:00": { dataGridView4.Rows[2].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 2, 1, status_rec); break; }
                                        case "8:30": { dataGridView4.Rows[3].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 3, 1, status_rec); break; }
                                        case "9:00": { dataGridView4.Rows[4].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 4, 1, status_rec); break; }
                                        case "9:30": { dataGridView4.Rows[5].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 5, 1, status_rec); break; }
                                        case "10:00": { dataGridView4.Rows[6].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 6, 1, status_rec); break; }
                                        case "10:30": { dataGridView4.Rows[7].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 7, 1, status_rec); break; }
                                        case "11:00": { dataGridView4.Rows[8].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 8, 1, status_rec); break; }
                                        case "11:30": { dataGridView4.Rows[9].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 9, 1, status_rec); break; }
                                        case "12:30": { dataGridView4.Rows[10].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 10, 1, status_rec); break; }
                                        case "13:00": { dataGridView4.Rows[11].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 11, 1, status_rec); break; }
                                        case "13:30": { dataGridView4.Rows[12].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 12, 1, status_rec); break; }
                                        case "14:00": { dataGridView4.Rows[13].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 13, 1, status_rec); break; }
                                        case "14:30": { dataGridView4.Rows[14].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 14, 1, status_rec); break; }
                                        case "15:00": { dataGridView4.Rows[15].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 15, 1, status_rec); break; }
                                        case "15:30": { dataGridView4.Rows[16].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 16, 1, status_rec); break; }
                                        case "16:00": { dataGridView4.Rows[17].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 17, 1, status_rec); break; }
                                        case "16:30": { dataGridView4.Rows[18].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 18, 1, status_rec); break; }
                                        case "17:00": { dataGridView4.Rows[19].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 19, 1, status_rec); break; }
                                        case "17:30": { dataGridView4.Rows[20].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 20, 1, status_rec); break; }
                                        case "18:00": { dataGridView4.Rows[21].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 21, 1, status_rec); break; }
                                        case "18:30": { dataGridView4.Rows[22].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 22, 1, status_rec); break; }
                                        case "19:00": { dataGridView4.Rows[23].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 23, 1, status_rec); break; }
                                        case "19:30": { dataGridView4.Rows[24].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 24, 1, status_rec); break; }
                                        case "20:00": { dataGridView4.Rows[25].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 25, 1, status_rec); break; }
                                        case "20:30": { dataGridView4.Rows[26].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 26, 1, status_rec); break; }
                                    };
                                }
                                else
                                {
                                    if (date_rec == label11.Text)
                                    {
                                        switch (time_rec)
                                        {
                                            case "7:00": { dataGridView6.Rows[0].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 0, 1, status_rec); break; }
                                            case "7:30": { dataGridView6.Rows[1].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 1, 1, status_rec); break; }
                                            case "8:00": { dataGridView6.Rows[2].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 2, 1, status_rec); break; }
                                            case "8:30": { dataGridView6.Rows[3].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 3, 1, status_rec); break; }
                                            case "9:00": { dataGridView6.Rows[4].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 4, 1, status_rec); break; }
                                            case "9:30": { dataGridView6.Rows[5].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 5, 1, status_rec); break; }
                                            case "10:00": { dataGridView6.Rows[6].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 6, 1, status_rec); break; }
                                            case "10:30": { dataGridView6.Rows[7].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 7, 1, status_rec); break; }
                                            case "11:00": { dataGridView6.Rows[8].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 8, 1, status_rec); break; }
                                            case "11:30": { dataGridView6.Rows[9].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 9, 1, status_rec); break; }
                                            case "12:30": { dataGridView6.Rows[10].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 10, 1, status_rec); break; }
                                            case "13:00": { dataGridView6.Rows[11].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 11, 1, status_rec); break; }
                                            case "13:30": { dataGridView6.Rows[12].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 12, 1, status_rec); break; }
                                            case "14:00": { dataGridView6.Rows[13].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 13, 1, status_rec); break; }
                                            case "14:30": { dataGridView6.Rows[14].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 14, 1, status_rec); break; }
                                            case "15:00": { dataGridView6.Rows[15].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 15, 1, status_rec); break; }
                                            case "15:30": { dataGridView6.Rows[16].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 16, 1, status_rec); break; }
                                            case "16:00": { dataGridView6.Rows[17].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 17, 1, status_rec); break; }
                                            case "16:30": { dataGridView6.Rows[18].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 18, 1, status_rec); break; }
                                            case "17:00": { dataGridView6.Rows[19].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 19, 1, status_rec); break; }
                                            case "17:30": { dataGridView6.Rows[20].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 20, 1, status_rec); break; }
                                            case "18:00": { dataGridView6.Rows[21].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 21, 1, status_rec); break; }
                                            case "18:30": { dataGridView6.Rows[22].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 22, 1, status_rec); break; }
                                            case "19:00": { dataGridView6.Rows[23].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 23, 1, status_rec); break; }
                                            case "19:30": { dataGridView6.Rows[24].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 24, 1, status_rec); break; }
                                            case "20:00": { dataGridView6.Rows[25].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 25, 1, status_rec); break; }
                                            case "20:30": { dataGridView6.Rows[26].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 26, 1, status_rec); break; }
                                        };
                                    }
                                    else
                                    {
                                        if (date_rec == label12.Text)
                                        {
                                            switch (time_rec)
                                            {
                                                case "7:00": { dataGridView5.Rows[0].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 0, 1, status_rec); break; }
                                                case "7:30": { dataGridView5.Rows[1].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 1, 1, status_rec); break; }
                                                case "8:00": { dataGridView5.Rows[2].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 2, 1, status_rec); break; }
                                                case "8:30": { dataGridView5.Rows[3].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 3, 1, status_rec); break; }
                                                case "9:00": { dataGridView5.Rows[4].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 4, 1, status_rec); break; }
                                                case "9:30": { dataGridView5.Rows[5].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 5, 1, status_rec); break; }
                                                case "10:00": { dataGridView5.Rows[6].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 6, 1, status_rec); break; }
                                                case "10:30": { dataGridView5.Rows[7].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 7, 1, status_rec); break; }
                                                case "11:00": { dataGridView5.Rows[8].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 8, 1, status_rec); break; }
                                                case "11:30": { dataGridView5.Rows[9].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 9, 1, status_rec); break; }
                                                case "12:30": { dataGridView5.Rows[10].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 10, 1, status_rec); break; }
                                                case "13:00": { dataGridView5.Rows[11].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 11, 1, status_rec); break; }
                                                case "13:30": { dataGridView5.Rows[12].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 12, 1, status_rec); break; }
                                                case "14:00": { dataGridView5.Rows[13].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 13, 1, status_rec); break; }
                                                case "14:30": { dataGridView5.Rows[14].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 14, 1, status_rec); break; }
                                                case "15:00": { dataGridView5.Rows[15].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 15, 1, status_rec); break; }
                                                case "15:30": { dataGridView5.Rows[16].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 16, 1, status_rec); break; }
                                                case "16:00": { dataGridView5.Rows[17].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 17, 1, status_rec); break; }
                                                case "16:30": { dataGridView5.Rows[18].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 18, 1, status_rec); break; }
                                                case "17:00": { dataGridView5.Rows[19].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 19, 1, status_rec); break; }
                                                case "17:30": { dataGridView5.Rows[20].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 20, 1, status_rec); break; }
                                                case "18:00": { dataGridView5.Rows[21].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 21, 1, status_rec); break; }
                                                case "18:30": { dataGridView5.Rows[22].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 22, 1, status_rec); break; }
                                                case "19:00": { dataGridView5.Rows[23].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 23, 1, status_rec); break; }
                                                case "19:30": { dataGridView5.Rows[24].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 24, 1, status_rec); break; }
                                                case "20:00": { dataGridView5.Rows[25].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 25, 1, status_rec); break; }
                                                case "20:30": { dataGridView5.Rows[26].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 26, 1, status_rec); break; }
                                            };
                                        }
                                    }
                                }
                            }
                        }
                    }

                }
            }
        }

        private void Select_Record_Item_Click(object sender, EventArgs e)
        {
            MedicineContext context = new MedicineContext();
            switch (GlobalVar.selected_grid)
            {
                case "dataGridView1":
                    {
                        string _data = label7.Text;
                        int Row_Index = dataGridView1.SelectedCells[0].RowIndex;
                        string _time = dataGridView1.Rows[Row_Index].Cells[0].Value.ToString();
                        GlobalVar.selected_time_reception = _time;
                        GlobalVar.selected_date_reception = _data;
                        GlobalVar.selected_patientID_reception = Convert.ToInt32(context.Receptions.Where(c => c.doctor_id == GlobalVar.FMain_selected_docid && c.date_reception == _data && c.time_reception == _time).Select(c => c.patient_id).FirstOrDefault());
                        GlobalVar.selected_reception_ID = Convert.ToInt32(context.Receptions.Where(c => c.doctor_id == GlobalVar.FMain_selected_docid && c.date_reception == _data && c.time_reception == _time).Select(c => c.reception_id).FirstOrDefault());
                        break;
                    }
                case "dataGridView2":
                    {
                        string _data = label8.Text;
                        int Row_Index = dataGridView2.SelectedCells[0].RowIndex;
                        string _time = dataGridView2.Rows[Row_Index].Cells[0].Value.ToString();
                        GlobalVar.selected_time_reception = _time;
                        GlobalVar.selected_date_reception = _data;
                        GlobalVar.selected_patientID_reception = Convert.ToInt32(context.Receptions.Where(c => c.doctor_id == GlobalVar.FMain_selected_docid && c.date_reception == _data && c.time_reception == _time).Select(c => c.patient_id).FirstOrDefault());
                        GlobalVar.selected_reception_ID = Convert.ToInt32(context.Receptions.Where(c => c.doctor_id == GlobalVar.FMain_selected_docid && c.date_reception == _data && c.time_reception == _time).Select(c => c.reception_id).FirstOrDefault());
                        break;
                    }
                case "dataGridView3":
                    {
                        string _data = label9.Text;
                        int Row_Index = dataGridView3.SelectedCells[0].RowIndex;
                        string _time = dataGridView3.Rows[Row_Index].Cells[0].Value.ToString();
                        GlobalVar.selected_time_reception = _time;
                        GlobalVar.selected_date_reception = _data;
                        GlobalVar.selected_patientID_reception = Convert.ToInt32(context.Receptions.Where(c => c.doctor_id == GlobalVar.FMain_selected_docid && c.date_reception == _data && c.time_reception == _time).Select(c => c.patient_id).FirstOrDefault());
                        GlobalVar.selected_reception_ID = Convert.ToInt32(context.Receptions.Where(c => c.doctor_id == GlobalVar.FMain_selected_docid && c.date_reception == _data && c.time_reception == _time).Select(c => c.reception_id).FirstOrDefault());
                        break;
                    }
                case "dataGridView4":
                    {
                        string _data = label10.Text;
                        int Row_Index = dataGridView4.SelectedCells[0].RowIndex;
                        string _time = dataGridView4.Rows[Row_Index].Cells[0].Value.ToString();
                        GlobalVar.selected_time_reception = _time;
                        GlobalVar.selected_date_reception = _data;
                        GlobalVar.selected_patientID_reception = Convert.ToInt32(context.Receptions.Where(c => c.doctor_id == GlobalVar.FMain_selected_docid && c.date_reception == _data && c.time_reception == _time).Select(c => c.patient_id).FirstOrDefault());
                        GlobalVar.selected_reception_ID = Convert.ToInt32(context.Receptions.Where(c => c.doctor_id == GlobalVar.FMain_selected_docid && c.date_reception == _data && c.time_reception == _time).Select(c => c.reception_id).FirstOrDefault());
                        break;
                    }
                case "dataGridView5":
                    {
                        string _data = label12.Text;
                        int Row_Index = dataGridView5.SelectedCells[0].RowIndex;
                        string _time = dataGridView5.Rows[Row_Index].Cells[0].Value.ToString();
                        GlobalVar.selected_time_reception = _time;
                        GlobalVar.selected_date_reception = _data;
                        GlobalVar.selected_patientID_reception = Convert.ToInt32(context.Receptions.Where(c => c.doctor_id == GlobalVar.FMain_selected_docid && c.date_reception == _data && c.time_reception == _time).Select(c => c.patient_id).FirstOrDefault());
                        GlobalVar.selected_reception_ID = Convert.ToInt32(context.Receptions.Where(c => c.doctor_id == GlobalVar.FMain_selected_docid && c.date_reception == _data && c.time_reception == _time).Select(c => c.reception_id).FirstOrDefault());
                        break;
                    }
                case "dataGridView6":
                    {
                        string _data = label11.Text;
                        int Row_Index = dataGridView6.SelectedCells[0].RowIndex;
                        string _time = dataGridView6.Rows[Row_Index].Cells[0].Value.ToString();
                        GlobalVar.selected_time_reception = _time;
                        GlobalVar.selected_date_reception = _data;
                        GlobalVar.selected_patientID_reception = Convert.ToInt32(context.Receptions.Where(c => c.doctor_id == GlobalVar.FMain_selected_docid && c.date_reception == _data && c.time_reception == _time).Select(c => c.patient_id).FirstOrDefault());
                        GlobalVar.selected_reception_ID = Convert.ToInt32(context.Receptions.Where(c => c.doctor_id == GlobalVar.FMain_selected_docid && c.date_reception == _data && c.time_reception == _time).Select(c => c.reception_id).FirstOrDefault());
                        break;
                    }
            };
            FReceptionHistory his = new FReceptionHistory();
            his.ShowDialog();
        }

        private void Delete_Record_Item_Click(object sender, EventArgs e)
        {
            MedicineContext context = new MedicineContext();
            Medicine_Data data = new Medicine_Data();
            GlobalVar vr = new GlobalVar();
            switch (GlobalVar.selected_grid)
            {
                case "dataGridView1":
                    {
                        string _data = label7.Text;
                        int Row_Index = dataGridView1.SelectedCells[0].RowIndex;
                        string _time = dataGridView1.Rows[Row_Index].Cells[0].Value.ToString();
                        GlobalVar.selected_time_reception = _time;
                        GlobalVar.selected_date_reception = _data;
                        GlobalVar.selected_patientID_reception = Convert.ToInt32(context.Receptions.Where(c => c.doctor_id == GlobalVar.FMain_selected_docid && c.date_reception == _data && c.time_reception == _time).Select(c => c.patient_id).FirstOrDefault());
                        GlobalVar.selected_reception_ID = Convert.ToInt32(context.Receptions.Where(c => c.doctor_id == GlobalVar.FMain_selected_docid && c.date_reception == _data && c.time_reception == _time).Select(c => c.reception_id).FirstOrDefault());
                        break;
                    }
                case "dataGridView2":
                    {
                        string _data = label8.Text;
                        int Row_Index = dataGridView2.SelectedCells[0].RowIndex;
                        string _time = dataGridView2.Rows[Row_Index].Cells[0].Value.ToString();
                        GlobalVar.selected_time_reception = _time;
                        GlobalVar.selected_date_reception = _data;
                        GlobalVar.selected_patientID_reception = Convert.ToInt32(context.Receptions.Where(c => c.doctor_id == GlobalVar.FMain_selected_docid && c.date_reception == _data && c.time_reception == _time).Select(c => c.patient_id).FirstOrDefault());
                        GlobalVar.selected_reception_ID = Convert.ToInt32(context.Receptions.Where(c => c.doctor_id == GlobalVar.FMain_selected_docid && c.date_reception == _data && c.time_reception == _time).Select(c => c.reception_id).FirstOrDefault());
                        break;
                    }
                case "dataGridView3":
                    {
                        string _data = label9.Text;
                        int Row_Index = dataGridView3.SelectedCells[0].RowIndex;
                        string _time = dataGridView3.Rows[Row_Index].Cells[0].Value.ToString();
                        GlobalVar.selected_time_reception = _time;
                        GlobalVar.selected_date_reception = _data;
                        GlobalVar.selected_patientID_reception = Convert.ToInt32(context.Receptions.Where(c => c.doctor_id == GlobalVar.FMain_selected_docid && c.date_reception == _data && c.time_reception == _time).Select(c => c.patient_id).FirstOrDefault());
                        GlobalVar.selected_reception_ID = Convert.ToInt32(context.Receptions.Where(c => c.doctor_id == GlobalVar.FMain_selected_docid && c.date_reception == _data && c.time_reception == _time).Select(c => c.reception_id).FirstOrDefault());
                        break;
                    }
                case "dataGridView4":
                    {
                        string _data = label10.Text;
                        int Row_Index = dataGridView4.SelectedCells[0].RowIndex;
                        string _time = dataGridView4.Rows[Row_Index].Cells[0].Value.ToString();
                        GlobalVar.selected_time_reception = _time;
                        GlobalVar.selected_date_reception = _data;
                        GlobalVar.selected_patientID_reception = Convert.ToInt32(context.Receptions.Where(c => c.doctor_id == GlobalVar.FMain_selected_docid && c.date_reception == _data && c.time_reception == _time).Select(c => c.patient_id).FirstOrDefault());
                        GlobalVar.selected_reception_ID = Convert.ToInt32(context.Receptions.Where(c => c.doctor_id == GlobalVar.FMain_selected_docid && c.date_reception == _data && c.time_reception == _time).Select(c => c.reception_id).FirstOrDefault());
                        break;
                    }
                case "dataGridView5":
                    {
                        string _data = label12.Text;
                        int Row_Index = dataGridView5.SelectedCells[0].RowIndex;
                        string _time = dataGridView5.Rows[Row_Index].Cells[0].Value.ToString();
                        GlobalVar.selected_time_reception = _time;
                        GlobalVar.selected_date_reception = _data;
                        GlobalVar.selected_patientID_reception = Convert.ToInt32(context.Receptions.Where(c => c.doctor_id == GlobalVar.FMain_selected_docid && c.date_reception == _data && c.time_reception == _time).Select(c => c.patient_id).FirstOrDefault());
                        GlobalVar.selected_reception_ID = Convert.ToInt32(context.Receptions.Where(c => c.doctor_id == GlobalVar.FMain_selected_docid && c.date_reception == _data && c.time_reception == _time).Select(c => c.reception_id).FirstOrDefault());
                        break;
                    }
                case "dataGridView6":
                    {
                        string _data = label11.Text;
                        int Row_Index = dataGridView6.SelectedCells[0].RowIndex;
                        string _time = dataGridView6.Rows[Row_Index].Cells[0].Value.ToString();
                        GlobalVar.selected_time_reception = _time;
                        GlobalVar.selected_date_reception = _data;
                        GlobalVar.selected_patientID_reception = Convert.ToInt32(context.Receptions.Where(c => c.doctor_id == GlobalVar.FMain_selected_docid && c.date_reception == _data && c.time_reception == _time).Select(c => c.patient_id).FirstOrDefault());
                        GlobalVar.selected_reception_ID = Convert.ToInt32(context.Receptions.Where(c => c.doctor_id == GlobalVar.FMain_selected_docid && c.date_reception == _data && c.time_reception == _time).Select(c => c.reception_id).FirstOrDefault());
                        break;
                    }
            };
            data.Delete_Reception_Record(GlobalVar.selected_reception_ID);
            data.GetDoctorReceptionsIDs(GlobalVar.FMain_selected_docid);


            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            dataGridView3.Rows.Clear();
            dataGridView4.Rows.Clear();
            dataGridView5.Rows.Clear();
            dataGridView6.Rows.Clear();

            vr.GridDataAdd(dataGridView1);
            vr.GridDataAdd(dataGridView2);
            vr.GridDataAdd(dataGridView3);
            vr.GridDataAdd(dataGridView4);
            vr.GridDataAdd(dataGridView5);
            vr.GridDataAdd(dataGridView6);




            vr.SetContextMenu_Cells(dataGridView1, contextMenuStrip1);
            vr.SetContextMenu_Cells(dataGridView2, contextMenuStrip1);
            vr.SetContextMenu_Cells(dataGridView3, contextMenuStrip1);
            vr.SetContextMenu_Cells(dataGridView4, contextMenuStrip1);
            vr.SetContextMenu_Cells(dataGridView5, contextMenuStrip1);
            vr.SetContextMenu_Cells(dataGridView6, contextMenuStrip1);

            vr.Grid_Stop_Sortable(dataGridView1);
            vr.Grid_Stop_Sortable(dataGridView2);
            vr.Grid_Stop_Sortable(dataGridView3);
            vr.Grid_Stop_Sortable(dataGridView4);
            vr.Grid_Stop_Sortable(dataGridView5);
            vr.Grid_Stop_Sortable(dataGridView6);

            vr.FreeFocus_ALL_Cells(dataGridView1);
            vr.FreeFocus_ALL_Cells(dataGridView2);
            vr.FreeFocus_ALL_Cells(dataGridView3);
            vr.FreeFocus_ALL_Cells(dataGridView4);
            vr.FreeFocus_ALL_Cells(dataGridView5);
            vr.FreeFocus_ALL_Cells(dataGridView6);

            //Проверяем на наличие записей на этой неделе
            if (GlobalVar.reception_doctor_ids.Count > 0)
            {
                foreach (var r in GlobalVar.reception_doctor_ids)
                {
                    string date_rec = context.Receptions.Where(c => c.reception_id == r).Select(c => c.date_reception).FirstOrDefault().ToString();
                    string time_rec = context.Receptions.Where(c => c.reception_id == r).Select(c => c.time_reception).FirstOrDefault().ToString();
                    string status_rec = context.Receptions.Where(c => c.reception_id == r).Select(c => c.reception_status).FirstOrDefault().ToString();
                    int patient_rec = Convert.ToInt32(context.Receptions.Where(c => c.reception_id == r).Select(c => c.patient_id).FirstOrDefault().ToString());
                    string patient_rec_name = context.Patients.Where(c => c.patient_id == patient_rec).Select(c => c.patient_name).FirstOrDefault().ToString();
                    if (date_rec == label7.Text)
                    {
                        switch (time_rec)
                        {
                            case "7:00": { dataGridView1.Rows[0].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 0, 1, status_rec); break; }
                            case "7:30": { dataGridView1.Rows[1].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 1, 1, status_rec); break; }
                            case "8:00": { dataGridView1.Rows[2].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 2, 1, status_rec); break; }
                            case "8:30": { dataGridView1.Rows[3].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 3, 1, status_rec); break; }
                            case "9:00": { dataGridView1.Rows[4].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 4, 1, status_rec); break; }
                            case "9:30": { dataGridView1.Rows[5].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 5, 1, status_rec); break; }
                            case "10:00": { dataGridView1.Rows[6].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 6, 1, status_rec); break; }
                            case "10:30": { dataGridView1.Rows[7].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 7, 1, status_rec); break; }
                            case "11:00": { dataGridView1.Rows[8].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 8, 1, status_rec); break; }
                            case "11:30": { dataGridView1.Rows[9].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 9, 1, status_rec); break; }
                            case "12:30": { dataGridView1.Rows[10].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 10, 1, status_rec); break; }
                            case "13:00": { dataGridView1.Rows[11].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 11, 1, status_rec); break; }
                            case "13:30": { dataGridView1.Rows[12].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 12, 1, status_rec); break; }
                            case "14:00": { dataGridView1.Rows[13].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 13, 1, status_rec); break; }
                            case "14:30": { dataGridView1.Rows[14].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 14, 1, status_rec); break; }
                            case "15:00": { dataGridView1.Rows[15].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 15, 1, status_rec); break; }
                            case "15:30": { dataGridView1.Rows[16].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 16, 1, status_rec); break; }
                            case "16:00": { dataGridView1.Rows[17].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 17, 1, status_rec); break; }
                            case "16:30": { dataGridView1.Rows[18].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 18, 1, status_rec); break; }
                            case "17:00": { dataGridView1.Rows[19].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 19, 1, status_rec); break; }
                            case "17:30": { dataGridView1.Rows[20].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 20, 1, status_rec); break; }
                            case "18:00": { dataGridView1.Rows[21].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 21, 1, status_rec); break; }
                            case "18:30": { dataGridView1.Rows[22].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 22, 1, status_rec); break; }
                            case "19:00": { dataGridView1.Rows[23].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 23, 1, status_rec); break; }
                            case "19:30": { dataGridView1.Rows[24].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 24, 1, status_rec); break; }
                            case "20:00": { dataGridView1.Rows[25].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 25, 1, status_rec); break; }
                            case "20:30": { dataGridView1.Rows[26].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 26, 1, status_rec); break; }
                        };
                    }
                    else
                    {
                        if (date_rec == label8.Text)
                        {
                            switch (time_rec)
                            {
                                case "7:00": { dataGridView2.Rows[0].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 0, 1, status_rec); break; }
                                case "7:30": { dataGridView2.Rows[1].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 1, 1, status_rec); break; }
                                case "8:00": { dataGridView2.Rows[2].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 2, 1, status_rec); break; }
                                case "8:30": { dataGridView2.Rows[3].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 3, 1, status_rec); break; }
                                case "9:00": { dataGridView2.Rows[4].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 4, 1, status_rec); break; }
                                case "9:30": { dataGridView2.Rows[5].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 5, 1, status_rec); break; }
                                case "10:00": { dataGridView2.Rows[6].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 6, 1, status_rec); break; }
                                case "10:30": { dataGridView2.Rows[7].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 7, 1, status_rec); break; }
                                case "11:00": { dataGridView2.Rows[8].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 8, 1, status_rec); break; }
                                case "11:30": { dataGridView2.Rows[9].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 9, 1, status_rec); break; }
                                case "12:30": { dataGridView2.Rows[10].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 10, 1, status_rec); break; }
                                case "13:00": { dataGridView2.Rows[11].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 11, 1, status_rec); break; }
                                case "13:30": { dataGridView2.Rows[12].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 12, 1, status_rec); break; }
                                case "14:00": { dataGridView2.Rows[13].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 13, 1, status_rec); break; }
                                case "14:30": { dataGridView2.Rows[14].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 14, 1, status_rec); break; }
                                case "15:00": { dataGridView2.Rows[15].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 15, 1, status_rec); break; }
                                case "15:30": { dataGridView2.Rows[16].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 16, 1, status_rec); break; }
                                case "16:00": { dataGridView2.Rows[17].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 17, 1, status_rec); break; }
                                case "16:30": { dataGridView2.Rows[18].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 18, 1, status_rec); break; }
                                case "17:00": { dataGridView2.Rows[19].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 19, 1, status_rec); break; }
                                case "17:30": { dataGridView2.Rows[20].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 20, 1, status_rec); break; }
                                case "18:00": { dataGridView2.Rows[21].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 21, 1, status_rec); break; }
                                case "18:30": { dataGridView2.Rows[22].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 22, 1, status_rec); break; }
                                case "19:00": { dataGridView2.Rows[23].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 23, 1, status_rec); break; }
                                case "19:30": { dataGridView2.Rows[24].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 24, 1, status_rec); break; }
                                case "20:00": { dataGridView2.Rows[25].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 25, 1, status_rec); break; }
                                case "20:30": { dataGridView2.Rows[26].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 26, 1, status_rec); break; }
                            };
                        }
                        else
                        {
                            if (date_rec == label9.Text)
                            {
                                switch (time_rec)
                                {
                                    case "7:00": { dataGridView3.Rows[0].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 0, 1, status_rec); break; }
                                    case "7:30": { dataGridView3.Rows[1].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 1, 1, status_rec); break; }
                                    case "8:00": { dataGridView3.Rows[2].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 2, 1, status_rec); break; }
                                    case "8:30": { dataGridView3.Rows[3].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 3, 1, status_rec); break; }
                                    case "9:00": { dataGridView3.Rows[4].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 4, 1, status_rec); break; }
                                    case "9:30": { dataGridView3.Rows[5].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 5, 1, status_rec); break; }
                                    case "10:00": { dataGridView3.Rows[6].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 6, 1, status_rec); break; }
                                    case "10:30": { dataGridView3.Rows[7].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 7, 1, status_rec); break; }
                                    case "11:00": { dataGridView3.Rows[8].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 8, 1, status_rec); break; }
                                    case "11:30": { dataGridView3.Rows[9].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 9, 1, status_rec); break; }
                                    case "12:30": { dataGridView3.Rows[10].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 10, 1, status_rec); break; }
                                    case "13:00": { dataGridView3.Rows[11].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 11, 1, status_rec); break; }
                                    case "13:30": { dataGridView3.Rows[12].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 12, 1, status_rec); break; }
                                    case "14:00": { dataGridView3.Rows[13].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 13, 1, status_rec); break; }
                                    case "14:30": { dataGridView3.Rows[14].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 14, 1, status_rec); break; }
                                    case "15:00": { dataGridView3.Rows[15].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 15, 1, status_rec); break; }
                                    case "15:30": { dataGridView3.Rows[16].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 16, 1, status_rec); break; }
                                    case "16:00": { dataGridView3.Rows[17].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 17, 1, status_rec); break; }
                                    case "16:30": { dataGridView3.Rows[18].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 18, 1, status_rec); break; }
                                    case "17:00": { dataGridView3.Rows[19].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 19, 1, status_rec); break; }
                                    case "17:30": { dataGridView3.Rows[20].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 20, 1, status_rec); break; }
                                    case "18:00": { dataGridView3.Rows[21].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 21, 1, status_rec); break; }
                                    case "18:30": { dataGridView3.Rows[22].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 22, 1, status_rec); break; }
                                    case "19:00": { dataGridView3.Rows[23].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 23, 1, status_rec); break; }
                                    case "19:30": { dataGridView3.Rows[24].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 24, 1, status_rec); break; }
                                    case "20:00": { dataGridView3.Rows[25].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 25, 1, status_rec); break; }
                                    case "20:30": { dataGridView3.Rows[26].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 26, 1, status_rec); break; }
                                };
                            }
                            else
                            {
                                if (date_rec == label10.Text)
                                {
                                    switch (time_rec)
                                    {
                                        case "7:00": { dataGridView4.Rows[0].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 0, 1, status_rec); break; }
                                        case "7:30": { dataGridView4.Rows[1].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 1, 1, status_rec); break; }
                                        case "8:00": { dataGridView4.Rows[2].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 2, 1, status_rec); break; }
                                        case "8:30": { dataGridView4.Rows[3].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 3, 1, status_rec); break; }
                                        case "9:00": { dataGridView4.Rows[4].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 4, 1, status_rec); break; }
                                        case "9:30": { dataGridView4.Rows[5].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 5, 1, status_rec); break; }
                                        case "10:00": { dataGridView4.Rows[6].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 6, 1, status_rec); break; }
                                        case "10:30": { dataGridView4.Rows[7].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 7, 1, status_rec); break; }
                                        case "11:00": { dataGridView4.Rows[8].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 8, 1, status_rec); break; }
                                        case "11:30": { dataGridView4.Rows[9].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 9, 1, status_rec); break; }
                                        case "12:30": { dataGridView4.Rows[10].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 10, 1, status_rec); break; }
                                        case "13:00": { dataGridView4.Rows[11].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 11, 1, status_rec); break; }
                                        case "13:30": { dataGridView4.Rows[12].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 12, 1, status_rec); break; }
                                        case "14:00": { dataGridView4.Rows[13].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 13, 1, status_rec); break; }
                                        case "14:30": { dataGridView4.Rows[14].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 14, 1, status_rec); break; }
                                        case "15:00": { dataGridView4.Rows[15].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 15, 1, status_rec); break; }
                                        case "15:30": { dataGridView4.Rows[16].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 16, 1, status_rec); break; }
                                        case "16:00": { dataGridView4.Rows[17].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 17, 1, status_rec); break; }
                                        case "16:30": { dataGridView4.Rows[18].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 18, 1, status_rec); break; }
                                        case "17:00": { dataGridView4.Rows[19].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 19, 1, status_rec); break; }
                                        case "17:30": { dataGridView4.Rows[20].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 20, 1, status_rec); break; }
                                        case "18:00": { dataGridView4.Rows[21].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 21, 1, status_rec); break; }
                                        case "18:30": { dataGridView4.Rows[22].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 22, 1, status_rec); break; }
                                        case "19:00": { dataGridView4.Rows[23].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 23, 1, status_rec); break; }
                                        case "19:30": { dataGridView4.Rows[24].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 24, 1, status_rec); break; }
                                        case "20:00": { dataGridView4.Rows[25].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 25, 1, status_rec); break; }
                                        case "20:30": { dataGridView4.Rows[26].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 26, 1, status_rec); break; }
                                    };
                                }
                                else
                                {
                                    if (date_rec == label11.Text)
                                    {
                                        switch (time_rec)
                                        {
                                            case "7:00": { dataGridView6.Rows[0].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 0, 1, status_rec); break; }
                                            case "7:30": { dataGridView6.Rows[1].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 1, 1, status_rec); break; }
                                            case "8:00": { dataGridView6.Rows[2].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 2, 1, status_rec); break; }
                                            case "8:30": { dataGridView6.Rows[3].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 3, 1, status_rec); break; }
                                            case "9:00": { dataGridView6.Rows[4].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 4, 1, status_rec); break; }
                                            case "9:30": { dataGridView6.Rows[5].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 5, 1, status_rec); break; }
                                            case "10:00": { dataGridView6.Rows[6].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 6, 1, status_rec); break; }
                                            case "10:30": { dataGridView6.Rows[7].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 7, 1, status_rec); break; }
                                            case "11:00": { dataGridView6.Rows[8].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 8, 1, status_rec); break; }
                                            case "11:30": { dataGridView6.Rows[9].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 9, 1, status_rec); break; }
                                            case "12:30": { dataGridView6.Rows[10].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 10, 1, status_rec); break; }
                                            case "13:00": { dataGridView6.Rows[11].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 11, 1, status_rec); break; }
                                            case "13:30": { dataGridView6.Rows[12].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 12, 1, status_rec); break; }
                                            case "14:00": { dataGridView6.Rows[13].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 13, 1, status_rec); break; }
                                            case "14:30": { dataGridView6.Rows[14].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 14, 1, status_rec); break; }
                                            case "15:00": { dataGridView6.Rows[15].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 15, 1, status_rec); break; }
                                            case "15:30": { dataGridView6.Rows[16].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 16, 1, status_rec); break; }
                                            case "16:00": { dataGridView6.Rows[17].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 17, 1, status_rec); break; }
                                            case "16:30": { dataGridView6.Rows[18].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 18, 1, status_rec); break; }
                                            case "17:00": { dataGridView6.Rows[19].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 19, 1, status_rec); break; }
                                            case "17:30": { dataGridView6.Rows[20].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 20, 1, status_rec); break; }
                                            case "18:00": { dataGridView6.Rows[21].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 21, 1, status_rec); break; }
                                            case "18:30": { dataGridView6.Rows[22].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 22, 1, status_rec); break; }
                                            case "19:00": { dataGridView6.Rows[23].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 23, 1, status_rec); break; }
                                            case "19:30": { dataGridView6.Rows[24].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 24, 1, status_rec); break; }
                                            case "20:00": { dataGridView6.Rows[25].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 25, 1, status_rec); break; }
                                            case "20:30": { dataGridView6.Rows[26].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 26, 1, status_rec); break; }
                                        };
                                    }
                                    else
                                    {
                                        if (date_rec == label12.Text)
                                        {
                                            switch (time_rec)
                                            {
                                                case "7:00": { dataGridView5.Rows[0].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 0, 1, status_rec); break; }
                                                case "7:30": { dataGridView5.Rows[1].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 1, 1, status_rec); break; }
                                                case "8:00": { dataGridView5.Rows[2].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 2, 1, status_rec); break; }
                                                case "8:30": { dataGridView5.Rows[3].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 3, 1, status_rec); break; }
                                                case "9:00": { dataGridView5.Rows[4].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 4, 1, status_rec); break; }
                                                case "9:30": { dataGridView5.Rows[5].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 5, 1, status_rec); break; }
                                                case "10:00": { dataGridView5.Rows[6].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 6, 1, status_rec); break; }
                                                case "10:30": { dataGridView5.Rows[7].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 7, 1, status_rec); break; }
                                                case "11:00": { dataGridView5.Rows[8].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 8, 1, status_rec); break; }
                                                case "11:30": { dataGridView5.Rows[9].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 9, 1, status_rec); break; }
                                                case "12:30": { dataGridView5.Rows[10].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 10, 1, status_rec); break; }
                                                case "13:00": { dataGridView5.Rows[11].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 11, 1, status_rec); break; }
                                                case "13:30": { dataGridView5.Rows[12].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 12, 1, status_rec); break; }
                                                case "14:00": { dataGridView5.Rows[13].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 13, 1, status_rec); break; }
                                                case "14:30": { dataGridView5.Rows[14].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 14, 1, status_rec); break; }
                                                case "15:00": { dataGridView5.Rows[15].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 15, 1, status_rec); break; }
                                                case "15:30": { dataGridView5.Rows[16].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 16, 1, status_rec); break; }
                                                case "16:00": { dataGridView5.Rows[17].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 17, 1, status_rec); break; }
                                                case "16:30": { dataGridView5.Rows[18].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 18, 1, status_rec); break; }
                                                case "17:00": { dataGridView5.Rows[19].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 19, 1, status_rec); break; }
                                                case "17:30": { dataGridView5.Rows[20].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 20, 1, status_rec); break; }
                                                case "18:00": { dataGridView5.Rows[21].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 21, 1, status_rec); break; }
                                                case "18:30": { dataGridView5.Rows[22].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 22, 1, status_rec); break; }
                                                case "19:00": { dataGridView5.Rows[23].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 23, 1, status_rec); break; }
                                                case "19:30": { dataGridView5.Rows[24].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 24, 1, status_rec); break; }
                                                case "20:00": { dataGridView5.Rows[25].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 25, 1, status_rec); break; }
                                                case "20:30": { dataGridView5.Rows[26].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 26, 1, status_rec); break; }
                                            };
                                        }
                                    }
                                }
                            }
                        }
                    }

                }
            }

        }

        private void пришелToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MedicineContext context = new MedicineContext();
            Medicine_Data data = new Medicine_Data();
            GlobalVar vr = new GlobalVar();
            switch (GlobalVar.selected_grid)
            {
                case "dataGridView1":
                    {
                        string _data = label7.Text;
                        int Row_Index = dataGridView1.SelectedCells[0].RowIndex;
                        string _time = dataGridView1.Rows[Row_Index].Cells[0].Value.ToString();
                        GlobalVar.selected_time_reception = _time;
                        GlobalVar.selected_date_reception = _data;
                        GlobalVar.selected_patientID_reception = Convert.ToInt32(context.Receptions.Where(c => c.doctor_id == GlobalVar.FMain_selected_docid && c.date_reception == _data && c.time_reception == _time).Select(c => c.patient_id).FirstOrDefault());
                        GlobalVar.selected_reception_ID = Convert.ToInt32(context.Receptions.Where(c => c.doctor_id == GlobalVar.FMain_selected_docid && c.date_reception == _data && c.time_reception == _time).Select(c => c.reception_id).FirstOrDefault());
                        break;
                    }
                case "dataGridView2":
                    {
                        string _data = label8.Text;
                        int Row_Index = dataGridView2.SelectedCells[0].RowIndex;
                        string _time = dataGridView2.Rows[Row_Index].Cells[0].Value.ToString();
                        GlobalVar.selected_time_reception = _time;
                        GlobalVar.selected_date_reception = _data;
                        GlobalVar.selected_patientID_reception = Convert.ToInt32(context.Receptions.Where(c => c.doctor_id == GlobalVar.FMain_selected_docid && c.date_reception == _data && c.time_reception == _time).Select(c => c.patient_id).FirstOrDefault());
                        GlobalVar.selected_reception_ID = Convert.ToInt32(context.Receptions.Where(c => c.doctor_id == GlobalVar.FMain_selected_docid && c.date_reception == _data && c.time_reception == _time).Select(c => c.reception_id).FirstOrDefault());
                        break;
                    }
                case "dataGridView3":
                    {
                        string _data = label9.Text;
                        int Row_Index = dataGridView3.SelectedCells[0].RowIndex;
                        string _time = dataGridView3.Rows[Row_Index].Cells[0].Value.ToString();
                        GlobalVar.selected_time_reception = _time;
                        GlobalVar.selected_date_reception = _data;
                        GlobalVar.selected_patientID_reception = Convert.ToInt32(context.Receptions.Where(c => c.doctor_id == GlobalVar.FMain_selected_docid && c.date_reception == _data && c.time_reception == _time).Select(c => c.patient_id).FirstOrDefault());
                        GlobalVar.selected_reception_ID = Convert.ToInt32(context.Receptions.Where(c => c.doctor_id == GlobalVar.FMain_selected_docid && c.date_reception == _data && c.time_reception == _time).Select(c => c.reception_id).FirstOrDefault());
                        break;
                    }
                case "dataGridView4":
                    {
                        string _data = label10.Text;
                        int Row_Index = dataGridView4.SelectedCells[0].RowIndex;
                        string _time = dataGridView4.Rows[Row_Index].Cells[0].Value.ToString();
                        GlobalVar.selected_time_reception = _time;
                        GlobalVar.selected_date_reception = _data;
                        GlobalVar.selected_patientID_reception = Convert.ToInt32(context.Receptions.Where(c => c.doctor_id == GlobalVar.FMain_selected_docid && c.date_reception == _data && c.time_reception == _time).Select(c => c.patient_id).FirstOrDefault());
                        GlobalVar.selected_reception_ID = Convert.ToInt32(context.Receptions.Where(c => c.doctor_id == GlobalVar.FMain_selected_docid && c.date_reception == _data && c.time_reception == _time).Select(c => c.reception_id).FirstOrDefault());
                        break;
                    }
                case "dataGridView5":
                    {
                        string _data = label12.Text;
                        int Row_Index = dataGridView5.SelectedCells[0].RowIndex;
                        string _time = dataGridView5.Rows[Row_Index].Cells[0].Value.ToString();
                        GlobalVar.selected_time_reception = _time;
                        GlobalVar.selected_date_reception = _data;
                        GlobalVar.selected_patientID_reception = Convert.ToInt32(context.Receptions.Where(c => c.doctor_id == GlobalVar.FMain_selected_docid && c.date_reception == _data && c.time_reception == _time).Select(c => c.patient_id).FirstOrDefault());
                        GlobalVar.selected_reception_ID = Convert.ToInt32(context.Receptions.Where(c => c.doctor_id == GlobalVar.FMain_selected_docid && c.date_reception == _data && c.time_reception == _time).Select(c => c.reception_id).FirstOrDefault());
                        break;
                    }
                case "dataGridView6":
                    {
                        string _data = label11.Text;
                        int Row_Index = dataGridView6.SelectedCells[0].RowIndex;
                        string _time = dataGridView6.Rows[Row_Index].Cells[0].Value.ToString();
                        GlobalVar.selected_time_reception = _time;
                        GlobalVar.selected_date_reception = _data;
                        GlobalVar.selected_patientID_reception = Convert.ToInt32(context.Receptions.Where(c => c.doctor_id == GlobalVar.FMain_selected_docid && c.date_reception == _data && c.time_reception == _time).Select(c => c.patient_id).FirstOrDefault());
                        GlobalVar.selected_reception_ID = Convert.ToInt32(context.Receptions.Where(c => c.doctor_id == GlobalVar.FMain_selected_docid && c.date_reception == _data && c.time_reception == _time).Select(c => c.reception_id).FirstOrDefault());
                        break;
                    }
            };
            data.Update_Reception_Status_Yes(GlobalVar.selected_reception_ID);
            data.GetDoctorReceptionsIDs(GlobalVar.FMain_selected_docid);


            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            dataGridView3.Rows.Clear();
            dataGridView4.Rows.Clear();
            dataGridView5.Rows.Clear();
            dataGridView6.Rows.Clear();

            vr.GridDataAdd(dataGridView1);
            vr.GridDataAdd(dataGridView2);
            vr.GridDataAdd(dataGridView3);
            vr.GridDataAdd(dataGridView4);
            vr.GridDataAdd(dataGridView5);
            vr.GridDataAdd(dataGridView6);




            vr.SetContextMenu_Cells(dataGridView1, contextMenuStrip1);
            vr.SetContextMenu_Cells(dataGridView2, contextMenuStrip1);
            vr.SetContextMenu_Cells(dataGridView3, contextMenuStrip1);
            vr.SetContextMenu_Cells(dataGridView4, contextMenuStrip1);
            vr.SetContextMenu_Cells(dataGridView5, contextMenuStrip1);
            vr.SetContextMenu_Cells(dataGridView6, contextMenuStrip1);

            vr.Grid_Stop_Sortable(dataGridView1);
            vr.Grid_Stop_Sortable(dataGridView2);
            vr.Grid_Stop_Sortable(dataGridView3);
            vr.Grid_Stop_Sortable(dataGridView4);
            vr.Grid_Stop_Sortable(dataGridView5);
            vr.Grid_Stop_Sortable(dataGridView6);

            vr.FreeFocus_ALL_Cells(dataGridView1);
            vr.FreeFocus_ALL_Cells(dataGridView2);
            vr.FreeFocus_ALL_Cells(dataGridView3);
            vr.FreeFocus_ALL_Cells(dataGridView4);
            vr.FreeFocus_ALL_Cells(dataGridView5);
            vr.FreeFocus_ALL_Cells(dataGridView6);

            //Проверяем на наличие записей на этой неделе
            if (GlobalVar.reception_doctor_ids.Count > 0)
            {
                foreach (var r in GlobalVar.reception_doctor_ids)
                {
                    string date_rec = context.Receptions.Where(c => c.reception_id == r).Select(c => c.date_reception).FirstOrDefault().ToString();
                    string time_rec = context.Receptions.Where(c => c.reception_id == r).Select(c => c.time_reception).FirstOrDefault().ToString();
                    string status_rec = context.Receptions.Where(c => c.reception_id == r).Select(c => c.reception_status).FirstOrDefault().ToString();
                    int patient_rec = Convert.ToInt32(context.Receptions.Where(c => c.reception_id == r).Select(c => c.patient_id).FirstOrDefault().ToString());
                    string patient_rec_name = context.Patients.Where(c => c.patient_id == patient_rec).Select(c => c.patient_name).FirstOrDefault().ToString();
                    if (date_rec == label7.Text)
                    {
                        switch (time_rec)
                        {
                            case "7:00": { dataGridView1.Rows[0].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 0, 1, status_rec); break; }
                            case "7:30": { dataGridView1.Rows[1].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 1, 1, status_rec); break; }
                            case "8:00": { dataGridView1.Rows[2].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 2, 1, status_rec); break; }
                            case "8:30": { dataGridView1.Rows[3].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 3, 1, status_rec); break; }
                            case "9:00": { dataGridView1.Rows[4].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 4, 1, status_rec); break; }
                            case "9:30": { dataGridView1.Rows[5].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 5, 1, status_rec); break; }
                            case "10:00": { dataGridView1.Rows[6].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 6, 1, status_rec); break; }
                            case "10:30": { dataGridView1.Rows[7].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 7, 1, status_rec); break; }
                            case "11:00": { dataGridView1.Rows[8].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 8, 1, status_rec); break; }
                            case "11:30": { dataGridView1.Rows[9].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 9, 1, status_rec); break; }
                            case "12:30": { dataGridView1.Rows[10].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 10, 1, status_rec); break; }
                            case "13:00": { dataGridView1.Rows[11].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 11, 1, status_rec); break; }
                            case "13:30": { dataGridView1.Rows[12].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 12, 1, status_rec); break; }
                            case "14:00": { dataGridView1.Rows[13].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 13, 1, status_rec); break; }
                            case "14:30": { dataGridView1.Rows[14].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 14, 1, status_rec); break; }
                            case "15:00": { dataGridView1.Rows[15].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 15, 1, status_rec); break; }
                            case "15:30": { dataGridView1.Rows[16].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 16, 1, status_rec); break; }
                            case "16:00": { dataGridView1.Rows[17].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 17, 1, status_rec); break; }
                            case "16:30": { dataGridView1.Rows[18].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 18, 1, status_rec); break; }
                            case "17:00": { dataGridView1.Rows[19].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 19, 1, status_rec); break; }
                            case "17:30": { dataGridView1.Rows[20].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 20, 1, status_rec); break; }
                            case "18:00": { dataGridView1.Rows[21].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 21, 1, status_rec); break; }
                            case "18:30": { dataGridView1.Rows[22].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 22, 1, status_rec); break; }
                            case "19:00": { dataGridView1.Rows[23].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 23, 1, status_rec); break; }
                            case "19:30": { dataGridView1.Rows[24].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 24, 1, status_rec); break; }
                            case "20:00": { dataGridView1.Rows[25].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 25, 1, status_rec); break; }
                            case "20:30": { dataGridView1.Rows[26].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 26, 1, status_rec); break; }
                        };
                    }
                    else
                    {
                        if (date_rec == label8.Text)
                        {
                            switch (time_rec)
                            {
                                case "7:00": { dataGridView2.Rows[0].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 0, 1, status_rec); break; }
                                case "7:30": { dataGridView2.Rows[1].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 1, 1, status_rec); break; }
                                case "8:00": { dataGridView2.Rows[2].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 2, 1, status_rec); break; }
                                case "8:30": { dataGridView2.Rows[3].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 3, 1, status_rec); break; }
                                case "9:00": { dataGridView2.Rows[4].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 4, 1, status_rec); break; }
                                case "9:30": { dataGridView2.Rows[5].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 5, 1, status_rec); break; }
                                case "10:00": { dataGridView2.Rows[6].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 6, 1, status_rec); break; }
                                case "10:30": { dataGridView2.Rows[7].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 7, 1, status_rec); break; }
                                case "11:00": { dataGridView2.Rows[8].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 8, 1, status_rec); break; }
                                case "11:30": { dataGridView2.Rows[9].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 9, 1, status_rec); break; }
                                case "12:30": { dataGridView2.Rows[10].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 10, 1, status_rec); break; }
                                case "13:00": { dataGridView2.Rows[11].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 11, 1, status_rec); break; }
                                case "13:30": { dataGridView2.Rows[12].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 12, 1, status_rec); break; }
                                case "14:00": { dataGridView2.Rows[13].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 13, 1, status_rec); break; }
                                case "14:30": { dataGridView2.Rows[14].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 14, 1, status_rec); break; }
                                case "15:00": { dataGridView2.Rows[15].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 15, 1, status_rec); break; }
                                case "15:30": { dataGridView2.Rows[16].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 16, 1, status_rec); break; }
                                case "16:00": { dataGridView2.Rows[17].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 17, 1, status_rec); break; }
                                case "16:30": { dataGridView2.Rows[18].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 18, 1, status_rec); break; }
                                case "17:00": { dataGridView2.Rows[19].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 19, 1, status_rec); break; }
                                case "17:30": { dataGridView2.Rows[20].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 20, 1, status_rec); break; }
                                case "18:00": { dataGridView2.Rows[21].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 21, 1, status_rec); break; }
                                case "18:30": { dataGridView2.Rows[22].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 22, 1, status_rec); break; }
                                case "19:00": { dataGridView2.Rows[23].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 23, 1, status_rec); break; }
                                case "19:30": { dataGridView2.Rows[24].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 24, 1, status_rec); break; }
                                case "20:00": { dataGridView2.Rows[25].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 25, 1, status_rec); break; }
                                case "20:30": { dataGridView2.Rows[26].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 26, 1, status_rec); break; }
                            };
                        }
                        else
                        {
                            if (date_rec == label9.Text)
                            {
                                switch (time_rec)
                                {
                                    case "7:00": { dataGridView3.Rows[0].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 0, 1, status_rec); break; }
                                    case "7:30": { dataGridView3.Rows[1].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 1, 1, status_rec); break; }
                                    case "8:00": { dataGridView3.Rows[2].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 2, 1, status_rec); break; }
                                    case "8:30": { dataGridView3.Rows[3].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 3, 1, status_rec); break; }
                                    case "9:00": { dataGridView3.Rows[4].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 4, 1, status_rec); break; }
                                    case "9:30": { dataGridView3.Rows[5].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 5, 1, status_rec); break; }
                                    case "10:00": { dataGridView3.Rows[6].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 6, 1, status_rec); break; }
                                    case "10:30": { dataGridView3.Rows[7].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 7, 1, status_rec); break; }
                                    case "11:00": { dataGridView3.Rows[8].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 8, 1, status_rec); break; }
                                    case "11:30": { dataGridView3.Rows[9].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 9, 1, status_rec); break; }
                                    case "12:30": { dataGridView3.Rows[10].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 10, 1, status_rec); break; }
                                    case "13:00": { dataGridView3.Rows[11].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 11, 1, status_rec); break; }
                                    case "13:30": { dataGridView3.Rows[12].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 12, 1, status_rec); break; }
                                    case "14:00": { dataGridView3.Rows[13].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 13, 1, status_rec); break; }
                                    case "14:30": { dataGridView3.Rows[14].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 14, 1, status_rec); break; }
                                    case "15:00": { dataGridView3.Rows[15].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 15, 1, status_rec); break; }
                                    case "15:30": { dataGridView3.Rows[16].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 16, 1, status_rec); break; }
                                    case "16:00": { dataGridView3.Rows[17].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 17, 1, status_rec); break; }
                                    case "16:30": { dataGridView3.Rows[18].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 18, 1, status_rec); break; }
                                    case "17:00": { dataGridView3.Rows[19].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 19, 1, status_rec); break; }
                                    case "17:30": { dataGridView3.Rows[20].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 20, 1, status_rec); break; }
                                    case "18:00": { dataGridView3.Rows[21].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 21, 1, status_rec); break; }
                                    case "18:30": { dataGridView3.Rows[22].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 22, 1, status_rec); break; }
                                    case "19:00": { dataGridView3.Rows[23].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 23, 1, status_rec); break; }
                                    case "19:30": { dataGridView3.Rows[24].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 24, 1, status_rec); break; }
                                    case "20:00": { dataGridView3.Rows[25].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 25, 1, status_rec); break; }
                                    case "20:30": { dataGridView3.Rows[26].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 26, 1, status_rec); break; }
                                };
                            }
                            else
                            {
                                if (date_rec == label10.Text)
                                {
                                    switch (time_rec)
                                    {
                                        case "7:00": { dataGridView4.Rows[0].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 0, 1, status_rec); break; }
                                        case "7:30": { dataGridView4.Rows[1].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 1, 1, status_rec); break; }
                                        case "8:00": { dataGridView4.Rows[2].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 2, 1, status_rec); break; }
                                        case "8:30": { dataGridView4.Rows[3].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 3, 1, status_rec); break; }
                                        case "9:00": { dataGridView4.Rows[4].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 4, 1, status_rec); break; }
                                        case "9:30": { dataGridView4.Rows[5].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 5, 1, status_rec); break; }
                                        case "10:00": { dataGridView4.Rows[6].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 6, 1, status_rec); break; }
                                        case "10:30": { dataGridView4.Rows[7].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 7, 1, status_rec); break; }
                                        case "11:00": { dataGridView4.Rows[8].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 8, 1, status_rec); break; }
                                        case "11:30": { dataGridView4.Rows[9].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 9, 1, status_rec); break; }
                                        case "12:30": { dataGridView4.Rows[10].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 10, 1, status_rec); break; }
                                        case "13:00": { dataGridView4.Rows[11].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 11, 1, status_rec); break; }
                                        case "13:30": { dataGridView4.Rows[12].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 12, 1, status_rec); break; }
                                        case "14:00": { dataGridView4.Rows[13].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 13, 1, status_rec); break; }
                                        case "14:30": { dataGridView4.Rows[14].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 14, 1, status_rec); break; }
                                        case "15:00": { dataGridView4.Rows[15].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 15, 1, status_rec); break; }
                                        case "15:30": { dataGridView4.Rows[16].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 16, 1, status_rec); break; }
                                        case "16:00": { dataGridView4.Rows[17].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 17, 1, status_rec); break; }
                                        case "16:30": { dataGridView4.Rows[18].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 18, 1, status_rec); break; }
                                        case "17:00": { dataGridView4.Rows[19].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 19, 1, status_rec); break; }
                                        case "17:30": { dataGridView4.Rows[20].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 20, 1, status_rec); break; }
                                        case "18:00": { dataGridView4.Rows[21].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 21, 1, status_rec); break; }
                                        case "18:30": { dataGridView4.Rows[22].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 22, 1, status_rec); break; }
                                        case "19:00": { dataGridView4.Rows[23].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 23, 1, status_rec); break; }
                                        case "19:30": { dataGridView4.Rows[24].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 24, 1, status_rec); break; }
                                        case "20:00": { dataGridView4.Rows[25].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 25, 1, status_rec); break; }
                                        case "20:30": { dataGridView4.Rows[26].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 26, 1, status_rec); break; }
                                    };
                                }
                                else
                                {
                                    if (date_rec == label11.Text)
                                    {
                                        switch (time_rec)
                                        {
                                            case "7:00": { dataGridView6.Rows[0].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 0, 1, status_rec); break; }
                                            case "7:30": { dataGridView6.Rows[1].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 1, 1, status_rec); break; }
                                            case "8:00": { dataGridView6.Rows[2].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 2, 1, status_rec); break; }
                                            case "8:30": { dataGridView6.Rows[3].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 3, 1, status_rec); break; }
                                            case "9:00": { dataGridView6.Rows[4].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 4, 1, status_rec); break; }
                                            case "9:30": { dataGridView6.Rows[5].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 5, 1, status_rec); break; }
                                            case "10:00": { dataGridView6.Rows[6].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 6, 1, status_rec); break; }
                                            case "10:30": { dataGridView6.Rows[7].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 7, 1, status_rec); break; }
                                            case "11:00": { dataGridView6.Rows[8].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 8, 1, status_rec); break; }
                                            case "11:30": { dataGridView6.Rows[9].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 9, 1, status_rec); break; }
                                            case "12:30": { dataGridView6.Rows[10].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 10, 1, status_rec); break; }
                                            case "13:00": { dataGridView6.Rows[11].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 11, 1, status_rec); break; }
                                            case "13:30": { dataGridView6.Rows[12].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 12, 1, status_rec); break; }
                                            case "14:00": { dataGridView6.Rows[13].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 13, 1, status_rec); break; }
                                            case "14:30": { dataGridView6.Rows[14].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 14, 1, status_rec); break; }
                                            case "15:00": { dataGridView6.Rows[15].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 15, 1, status_rec); break; }
                                            case "15:30": { dataGridView6.Rows[16].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 16, 1, status_rec); break; }
                                            case "16:00": { dataGridView6.Rows[17].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 17, 1, status_rec); break; }
                                            case "16:30": { dataGridView6.Rows[18].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 18, 1, status_rec); break; }
                                            case "17:00": { dataGridView6.Rows[19].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 19, 1, status_rec); break; }
                                            case "17:30": { dataGridView6.Rows[20].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 20, 1, status_rec); break; }
                                            case "18:00": { dataGridView6.Rows[21].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 21, 1, status_rec); break; }
                                            case "18:30": { dataGridView6.Rows[22].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 22, 1, status_rec); break; }
                                            case "19:00": { dataGridView6.Rows[23].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 23, 1, status_rec); break; }
                                            case "19:30": { dataGridView6.Rows[24].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 24, 1, status_rec); break; }
                                            case "20:00": { dataGridView6.Rows[25].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 25, 1, status_rec); break; }
                                            case "20:30": { dataGridView6.Rows[26].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 26, 1, status_rec); break; }
                                        };
                                    }
                                    else
                                    {
                                        if (date_rec == label12.Text)
                                        {
                                            switch (time_rec)
                                            {
                                                case "7:00": { dataGridView5.Rows[0].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 0, 1, status_rec); break; }
                                                case "7:30": { dataGridView5.Rows[1].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 1, 1, status_rec); break; }
                                                case "8:00": { dataGridView5.Rows[2].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 2, 1, status_rec); break; }
                                                case "8:30": { dataGridView5.Rows[3].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 3, 1, status_rec); break; }
                                                case "9:00": { dataGridView5.Rows[4].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 4, 1, status_rec); break; }
                                                case "9:30": { dataGridView5.Rows[5].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 5, 1, status_rec); break; }
                                                case "10:00": { dataGridView5.Rows[6].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 6, 1, status_rec); break; }
                                                case "10:30": { dataGridView5.Rows[7].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 7, 1, status_rec); break; }
                                                case "11:00": { dataGridView5.Rows[8].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 8, 1, status_rec); break; }
                                                case "11:30": { dataGridView5.Rows[9].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 9, 1, status_rec); break; }
                                                case "12:30": { dataGridView5.Rows[10].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 10, 1, status_rec); break; }
                                                case "13:00": { dataGridView5.Rows[11].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 11, 1, status_rec); break; }
                                                case "13:30": { dataGridView5.Rows[12].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 12, 1, status_rec); break; }
                                                case "14:00": { dataGridView5.Rows[13].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 13, 1, status_rec); break; }
                                                case "14:30": { dataGridView5.Rows[14].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 14, 1, status_rec); break; }
                                                case "15:00": { dataGridView5.Rows[15].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 15, 1, status_rec); break; }
                                                case "15:30": { dataGridView5.Rows[16].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 16, 1, status_rec); break; }
                                                case "16:00": { dataGridView5.Rows[17].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 17, 1, status_rec); break; }
                                                case "16:30": { dataGridView5.Rows[18].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 18, 1, status_rec); break; }
                                                case "17:00": { dataGridView5.Rows[19].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 19, 1, status_rec); break; }
                                                case "17:30": { dataGridView5.Rows[20].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 20, 1, status_rec); break; }
                                                case "18:00": { dataGridView5.Rows[21].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 21, 1, status_rec); break; }
                                                case "18:30": { dataGridView5.Rows[22].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 22, 1, status_rec); break; }
                                                case "19:00": { dataGridView5.Rows[23].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 23, 1, status_rec); break; }
                                                case "19:30": { dataGridView5.Rows[24].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 24, 1, status_rec); break; }
                                                case "20:00": { dataGridView5.Rows[25].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 25, 1, status_rec); break; }
                                                case "20:30": { dataGridView5.Rows[26].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 26, 1, status_rec); break; }
                                            };
                                        }
                                    }
                                }
                            }
                        }
                    }

                }
            }
        }

        private void неПришелToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MedicineContext context = new MedicineContext();
            Medicine_Data data = new Medicine_Data();
            GlobalVar vr = new GlobalVar();
            switch (GlobalVar.selected_grid)
            {
                case "dataGridView1":
                    {
                        string _data = label7.Text;
                        int Row_Index = dataGridView1.SelectedCells[0].RowIndex;
                        string _time = dataGridView1.Rows[Row_Index].Cells[0].Value.ToString();
                        GlobalVar.selected_time_reception = _time;
                        GlobalVar.selected_date_reception = _data;
                        GlobalVar.selected_patientID_reception = Convert.ToInt32(context.Receptions.Where(c => c.doctor_id == GlobalVar.FMain_selected_docid && c.date_reception == _data && c.time_reception == _time).Select(c => c.patient_id).FirstOrDefault());
                        GlobalVar.selected_reception_ID = Convert.ToInt32(context.Receptions.Where(c => c.doctor_id == GlobalVar.FMain_selected_docid && c.date_reception == _data && c.time_reception == _time).Select(c => c.reception_id).FirstOrDefault());
                        break;
                    }
                case "dataGridView2":
                    {
                        string _data = label8.Text;
                        int Row_Index = dataGridView2.SelectedCells[0].RowIndex;
                        string _time = dataGridView2.Rows[Row_Index].Cells[0].Value.ToString();
                        GlobalVar.selected_time_reception = _time;
                        GlobalVar.selected_date_reception = _data;
                        GlobalVar.selected_patientID_reception = Convert.ToInt32(context.Receptions.Where(c => c.doctor_id == GlobalVar.FMain_selected_docid && c.date_reception == _data && c.time_reception == _time).Select(c => c.patient_id).FirstOrDefault());
                        GlobalVar.selected_reception_ID = Convert.ToInt32(context.Receptions.Where(c => c.doctor_id == GlobalVar.FMain_selected_docid && c.date_reception == _data && c.time_reception == _time).Select(c => c.reception_id).FirstOrDefault());
                        break;
                    }
                case "dataGridView3":
                    {
                        string _data = label9.Text;
                        int Row_Index = dataGridView3.SelectedCells[0].RowIndex;
                        string _time = dataGridView3.Rows[Row_Index].Cells[0].Value.ToString();
                        GlobalVar.selected_time_reception = _time;
                        GlobalVar.selected_date_reception = _data;
                        GlobalVar.selected_patientID_reception = Convert.ToInt32(context.Receptions.Where(c => c.doctor_id == GlobalVar.FMain_selected_docid && c.date_reception == _data && c.time_reception == _time).Select(c => c.patient_id).FirstOrDefault());
                        GlobalVar.selected_reception_ID = Convert.ToInt32(context.Receptions.Where(c => c.doctor_id == GlobalVar.FMain_selected_docid && c.date_reception == _data && c.time_reception == _time).Select(c => c.reception_id).FirstOrDefault());
                        break;
                    }
                case "dataGridView4":
                    {
                        string _data = label10.Text;
                        int Row_Index = dataGridView4.SelectedCells[0].RowIndex;
                        string _time = dataGridView4.Rows[Row_Index].Cells[0].Value.ToString();
                        GlobalVar.selected_time_reception = _time;
                        GlobalVar.selected_date_reception = _data;
                        GlobalVar.selected_patientID_reception = Convert.ToInt32(context.Receptions.Where(c => c.doctor_id == GlobalVar.FMain_selected_docid && c.date_reception == _data && c.time_reception == _time).Select(c => c.patient_id).FirstOrDefault());
                        GlobalVar.selected_reception_ID = Convert.ToInt32(context.Receptions.Where(c => c.doctor_id == GlobalVar.FMain_selected_docid && c.date_reception == _data && c.time_reception == _time).Select(c => c.reception_id).FirstOrDefault());
                        break;
                    }
                case "dataGridView5":
                    {
                        string _data = label12.Text;
                        int Row_Index = dataGridView5.SelectedCells[0].RowIndex;
                        string _time = dataGridView5.Rows[Row_Index].Cells[0].Value.ToString();
                        GlobalVar.selected_time_reception = _time;
                        GlobalVar.selected_date_reception = _data;
                        GlobalVar.selected_patientID_reception = Convert.ToInt32(context.Receptions.Where(c => c.doctor_id == GlobalVar.FMain_selected_docid && c.date_reception == _data && c.time_reception == _time).Select(c => c.patient_id).FirstOrDefault());
                        GlobalVar.selected_reception_ID = Convert.ToInt32(context.Receptions.Where(c => c.doctor_id == GlobalVar.FMain_selected_docid && c.date_reception == _data && c.time_reception == _time).Select(c => c.reception_id).FirstOrDefault());
                        break;
                    }
                case "dataGridView6":
                    {
                        string _data = label11.Text;
                        int Row_Index = dataGridView6.SelectedCells[0].RowIndex;
                        string _time = dataGridView6.Rows[Row_Index].Cells[0].Value.ToString();
                        GlobalVar.selected_time_reception = _time;
                        GlobalVar.selected_date_reception = _data;
                        GlobalVar.selected_patientID_reception = Convert.ToInt32(context.Receptions.Where(c => c.doctor_id == GlobalVar.FMain_selected_docid && c.date_reception == _data && c.time_reception == _time).Select(c => c.patient_id).FirstOrDefault());
                        GlobalVar.selected_reception_ID = Convert.ToInt32(context.Receptions.Where(c => c.doctor_id == GlobalVar.FMain_selected_docid && c.date_reception == _data && c.time_reception == _time).Select(c => c.reception_id).FirstOrDefault());
                        break;
                    }
            };
            data.Update_Reception_Status_No(GlobalVar.selected_reception_ID);
            data.GetDoctorReceptionsIDs(GlobalVar.FMain_selected_docid);


            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            dataGridView3.Rows.Clear();
            dataGridView4.Rows.Clear();
            dataGridView5.Rows.Clear();
            dataGridView6.Rows.Clear();

            vr.GridDataAdd(dataGridView1);
            vr.GridDataAdd(dataGridView2);
            vr.GridDataAdd(dataGridView3);
            vr.GridDataAdd(dataGridView4);
            vr.GridDataAdd(dataGridView5);
            vr.GridDataAdd(dataGridView6);




            vr.SetContextMenu_Cells(dataGridView1, contextMenuStrip1);
            vr.SetContextMenu_Cells(dataGridView2, contextMenuStrip1);
            vr.SetContextMenu_Cells(dataGridView3, contextMenuStrip1);
            vr.SetContextMenu_Cells(dataGridView4, contextMenuStrip1);
            vr.SetContextMenu_Cells(dataGridView5, contextMenuStrip1);
            vr.SetContextMenu_Cells(dataGridView6, contextMenuStrip1);

            vr.Grid_Stop_Sortable(dataGridView1);
            vr.Grid_Stop_Sortable(dataGridView2);
            vr.Grid_Stop_Sortable(dataGridView3);
            vr.Grid_Stop_Sortable(dataGridView4);
            vr.Grid_Stop_Sortable(dataGridView5);
            vr.Grid_Stop_Sortable(dataGridView6);

            vr.FreeFocus_ALL_Cells(dataGridView1);
            vr.FreeFocus_ALL_Cells(dataGridView2);
            vr.FreeFocus_ALL_Cells(dataGridView3);
            vr.FreeFocus_ALL_Cells(dataGridView4);
            vr.FreeFocus_ALL_Cells(dataGridView5);
            vr.FreeFocus_ALL_Cells(dataGridView6);

            //Проверяем на наличие записей на этой неделе
            if (GlobalVar.reception_doctor_ids.Count > 0)
            {
                foreach (var r in GlobalVar.reception_doctor_ids)
                {
                    string date_rec = context.Receptions.Where(c => c.reception_id == r).Select(c => c.date_reception).FirstOrDefault().ToString();
                    string time_rec = context.Receptions.Where(c => c.reception_id == r).Select(c => c.time_reception).FirstOrDefault().ToString();
                    string status_rec = context.Receptions.Where(c => c.reception_id == r).Select(c => c.reception_status).FirstOrDefault().ToString();
                    int patient_rec = Convert.ToInt32(context.Receptions.Where(c => c.reception_id == r).Select(c => c.patient_id).FirstOrDefault().ToString());
                    string patient_rec_name = context.Patients.Where(c => c.patient_id == patient_rec).Select(c => c.patient_name).FirstOrDefault().ToString();
                    if (date_rec == label7.Text)
                    {
                        switch (time_rec)
                        {
                            case "7:00": { dataGridView1.Rows[0].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 0, 1, status_rec); break; }
                            case "7:30": { dataGridView1.Rows[1].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 1, 1, status_rec); break; }
                            case "8:00": { dataGridView1.Rows[2].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 2, 1, status_rec); break; }
                            case "8:30": { dataGridView1.Rows[3].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 3, 1, status_rec); break; }
                            case "9:00": { dataGridView1.Rows[4].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 4, 1, status_rec); break; }
                            case "9:30": { dataGridView1.Rows[5].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 5, 1, status_rec); break; }
                            case "10:00": { dataGridView1.Rows[6].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 6, 1, status_rec); break; }
                            case "10:30": { dataGridView1.Rows[7].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 7, 1, status_rec); break; }
                            case "11:00": { dataGridView1.Rows[8].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 8, 1, status_rec); break; }
                            case "11:30": { dataGridView1.Rows[9].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 9, 1, status_rec); break; }
                            case "12:30": { dataGridView1.Rows[10].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 10, 1, status_rec); break; }
                            case "13:00": { dataGridView1.Rows[11].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 11, 1, status_rec); break; }
                            case "13:30": { dataGridView1.Rows[12].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 12, 1, status_rec); break; }
                            case "14:00": { dataGridView1.Rows[13].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 13, 1, status_rec); break; }
                            case "14:30": { dataGridView1.Rows[14].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 14, 1, status_rec); break; }
                            case "15:00": { dataGridView1.Rows[15].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 15, 1, status_rec); break; }
                            case "15:30": { dataGridView1.Rows[16].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 16, 1, status_rec); break; }
                            case "16:00": { dataGridView1.Rows[17].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 17, 1, status_rec); break; }
                            case "16:30": { dataGridView1.Rows[18].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 18, 1, status_rec); break; }
                            case "17:00": { dataGridView1.Rows[19].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 19, 1, status_rec); break; }
                            case "17:30": { dataGridView1.Rows[20].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 20, 1, status_rec); break; }
                            case "18:00": { dataGridView1.Rows[21].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 21, 1, status_rec); break; }
                            case "18:30": { dataGridView1.Rows[22].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 22, 1, status_rec); break; }
                            case "19:00": { dataGridView1.Rows[23].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 23, 1, status_rec); break; }
                            case "19:30": { dataGridView1.Rows[24].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 24, 1, status_rec); break; }
                            case "20:00": { dataGridView1.Rows[25].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 25, 1, status_rec); break; }
                            case "20:30": { dataGridView1.Rows[26].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView1, 26, 1, status_rec); break; }
                        };
                    }
                    else
                    {
                        if (date_rec == label8.Text)
                        {
                            switch (time_rec)
                            {
                                case "7:00": { dataGridView2.Rows[0].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 0, 1, status_rec); break; }
                                case "7:30": { dataGridView2.Rows[1].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 1, 1, status_rec); break; }
                                case "8:00": { dataGridView2.Rows[2].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 2, 1, status_rec); break; }
                                case "8:30": { dataGridView2.Rows[3].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 3, 1, status_rec); break; }
                                case "9:00": { dataGridView2.Rows[4].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 4, 1, status_rec); break; }
                                case "9:30": { dataGridView2.Rows[5].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 5, 1, status_rec); break; }
                                case "10:00": { dataGridView2.Rows[6].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 6, 1, status_rec); break; }
                                case "10:30": { dataGridView2.Rows[7].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 7, 1, status_rec); break; }
                                case "11:00": { dataGridView2.Rows[8].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 8, 1, status_rec); break; }
                                case "11:30": { dataGridView2.Rows[9].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 9, 1, status_rec); break; }
                                case "12:30": { dataGridView2.Rows[10].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 10, 1, status_rec); break; }
                                case "13:00": { dataGridView2.Rows[11].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 11, 1, status_rec); break; }
                                case "13:30": { dataGridView2.Rows[12].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 12, 1, status_rec); break; }
                                case "14:00": { dataGridView2.Rows[13].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 13, 1, status_rec); break; }
                                case "14:30": { dataGridView2.Rows[14].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 14, 1, status_rec); break; }
                                case "15:00": { dataGridView2.Rows[15].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 15, 1, status_rec); break; }
                                case "15:30": { dataGridView2.Rows[16].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 16, 1, status_rec); break; }
                                case "16:00": { dataGridView2.Rows[17].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 17, 1, status_rec); break; }
                                case "16:30": { dataGridView2.Rows[18].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 18, 1, status_rec); break; }
                                case "17:00": { dataGridView2.Rows[19].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 19, 1, status_rec); break; }
                                case "17:30": { dataGridView2.Rows[20].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 20, 1, status_rec); break; }
                                case "18:00": { dataGridView2.Rows[21].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 21, 1, status_rec); break; }
                                case "18:30": { dataGridView2.Rows[22].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 22, 1, status_rec); break; }
                                case "19:00": { dataGridView2.Rows[23].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 23, 1, status_rec); break; }
                                case "19:30": { dataGridView2.Rows[24].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 24, 1, status_rec); break; }
                                case "20:00": { dataGridView2.Rows[25].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 25, 1, status_rec); break; }
                                case "20:30": { dataGridView2.Rows[26].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView2, 26, 1, status_rec); break; }
                            };
                        }
                        else
                        {
                            if (date_rec == label9.Text)
                            {
                                switch (time_rec)
                                {
                                    case "7:00": { dataGridView3.Rows[0].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 0, 1, status_rec); break; }
                                    case "7:30": { dataGridView3.Rows[1].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 1, 1, status_rec); break; }
                                    case "8:00": { dataGridView3.Rows[2].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 2, 1, status_rec); break; }
                                    case "8:30": { dataGridView3.Rows[3].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 3, 1, status_rec); break; }
                                    case "9:00": { dataGridView3.Rows[4].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 4, 1, status_rec); break; }
                                    case "9:30": { dataGridView3.Rows[5].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 5, 1, status_rec); break; }
                                    case "10:00": { dataGridView3.Rows[6].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 6, 1, status_rec); break; }
                                    case "10:30": { dataGridView3.Rows[7].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 7, 1, status_rec); break; }
                                    case "11:00": { dataGridView3.Rows[8].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 8, 1, status_rec); break; }
                                    case "11:30": { dataGridView3.Rows[9].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 9, 1, status_rec); break; }
                                    case "12:30": { dataGridView3.Rows[10].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 10, 1, status_rec); break; }
                                    case "13:00": { dataGridView3.Rows[11].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 11, 1, status_rec); break; }
                                    case "13:30": { dataGridView3.Rows[12].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 12, 1, status_rec); break; }
                                    case "14:00": { dataGridView3.Rows[13].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 13, 1, status_rec); break; }
                                    case "14:30": { dataGridView3.Rows[14].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 14, 1, status_rec); break; }
                                    case "15:00": { dataGridView3.Rows[15].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 15, 1, status_rec); break; }
                                    case "15:30": { dataGridView3.Rows[16].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 16, 1, status_rec); break; }
                                    case "16:00": { dataGridView3.Rows[17].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 17, 1, status_rec); break; }
                                    case "16:30": { dataGridView3.Rows[18].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 18, 1, status_rec); break; }
                                    case "17:00": { dataGridView3.Rows[19].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 19, 1, status_rec); break; }
                                    case "17:30": { dataGridView3.Rows[20].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 20, 1, status_rec); break; }
                                    case "18:00": { dataGridView3.Rows[21].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 21, 1, status_rec); break; }
                                    case "18:30": { dataGridView3.Rows[22].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 22, 1, status_rec); break; }
                                    case "19:00": { dataGridView3.Rows[23].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 23, 1, status_rec); break; }
                                    case "19:30": { dataGridView3.Rows[24].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 24, 1, status_rec); break; }
                                    case "20:00": { dataGridView3.Rows[25].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 25, 1, status_rec); break; }
                                    case "20:30": { dataGridView3.Rows[26].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView3, 26, 1, status_rec); break; }
                                };
                            }
                            else
                            {
                                if (date_rec == label10.Text)
                                {
                                    switch (time_rec)
                                    {
                                        case "7:00": { dataGridView4.Rows[0].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 0, 1, status_rec); break; }
                                        case "7:30": { dataGridView4.Rows[1].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 1, 1, status_rec); break; }
                                        case "8:00": { dataGridView4.Rows[2].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 2, 1, status_rec); break; }
                                        case "8:30": { dataGridView4.Rows[3].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 3, 1, status_rec); break; }
                                        case "9:00": { dataGridView4.Rows[4].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 4, 1, status_rec); break; }
                                        case "9:30": { dataGridView4.Rows[5].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 5, 1, status_rec); break; }
                                        case "10:00": { dataGridView4.Rows[6].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 6, 1, status_rec); break; }
                                        case "10:30": { dataGridView4.Rows[7].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 7, 1, status_rec); break; }
                                        case "11:00": { dataGridView4.Rows[8].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 8, 1, status_rec); break; }
                                        case "11:30": { dataGridView4.Rows[9].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 9, 1, status_rec); break; }
                                        case "12:30": { dataGridView4.Rows[10].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 10, 1, status_rec); break; }
                                        case "13:00": { dataGridView4.Rows[11].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 11, 1, status_rec); break; }
                                        case "13:30": { dataGridView4.Rows[12].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 12, 1, status_rec); break; }
                                        case "14:00": { dataGridView4.Rows[13].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 13, 1, status_rec); break; }
                                        case "14:30": { dataGridView4.Rows[14].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 14, 1, status_rec); break; }
                                        case "15:00": { dataGridView4.Rows[15].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 15, 1, status_rec); break; }
                                        case "15:30": { dataGridView4.Rows[16].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 16, 1, status_rec); break; }
                                        case "16:00": { dataGridView4.Rows[17].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 17, 1, status_rec); break; }
                                        case "16:30": { dataGridView4.Rows[18].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 18, 1, status_rec); break; }
                                        case "17:00": { dataGridView4.Rows[19].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 19, 1, status_rec); break; }
                                        case "17:30": { dataGridView4.Rows[20].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 20, 1, status_rec); break; }
                                        case "18:00": { dataGridView4.Rows[21].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 21, 1, status_rec); break; }
                                        case "18:30": { dataGridView4.Rows[22].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 22, 1, status_rec); break; }
                                        case "19:00": { dataGridView4.Rows[23].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 23, 1, status_rec); break; }
                                        case "19:30": { dataGridView4.Rows[24].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 24, 1, status_rec); break; }
                                        case "20:00": { dataGridView4.Rows[25].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 25, 1, status_rec); break; }
                                        case "20:30": { dataGridView4.Rows[26].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView4, 26, 1, status_rec); break; }
                                    };
                                }
                                else
                                {
                                    if (date_rec == label11.Text)
                                    {
                                        switch (time_rec)
                                        {
                                            case "7:00": { dataGridView6.Rows[0].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 0, 1, status_rec); break; }
                                            case "7:30": { dataGridView6.Rows[1].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 1, 1, status_rec); break; }
                                            case "8:00": { dataGridView6.Rows[2].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 2, 1, status_rec); break; }
                                            case "8:30": { dataGridView6.Rows[3].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 3, 1, status_rec); break; }
                                            case "9:00": { dataGridView6.Rows[4].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 4, 1, status_rec); break; }
                                            case "9:30": { dataGridView6.Rows[5].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 5, 1, status_rec); break; }
                                            case "10:00": { dataGridView6.Rows[6].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 6, 1, status_rec); break; }
                                            case "10:30": { dataGridView6.Rows[7].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 7, 1, status_rec); break; }
                                            case "11:00": { dataGridView6.Rows[8].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 8, 1, status_rec); break; }
                                            case "11:30": { dataGridView6.Rows[9].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 9, 1, status_rec); break; }
                                            case "12:30": { dataGridView6.Rows[10].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 10, 1, status_rec); break; }
                                            case "13:00": { dataGridView6.Rows[11].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 11, 1, status_rec); break; }
                                            case "13:30": { dataGridView6.Rows[12].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 12, 1, status_rec); break; }
                                            case "14:00": { dataGridView6.Rows[13].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 13, 1, status_rec); break; }
                                            case "14:30": { dataGridView6.Rows[14].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 14, 1, status_rec); break; }
                                            case "15:00": { dataGridView6.Rows[15].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 15, 1, status_rec); break; }
                                            case "15:30": { dataGridView6.Rows[16].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 16, 1, status_rec); break; }
                                            case "16:00": { dataGridView6.Rows[17].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 17, 1, status_rec); break; }
                                            case "16:30": { dataGridView6.Rows[18].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 18, 1, status_rec); break; }
                                            case "17:00": { dataGridView6.Rows[19].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 19, 1, status_rec); break; }
                                            case "17:30": { dataGridView6.Rows[20].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 20, 1, status_rec); break; }
                                            case "18:00": { dataGridView6.Rows[21].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 21, 1, status_rec); break; }
                                            case "18:30": { dataGridView6.Rows[22].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 22, 1, status_rec); break; }
                                            case "19:00": { dataGridView6.Rows[23].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 23, 1, status_rec); break; }
                                            case "19:30": { dataGridView6.Rows[24].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 24, 1, status_rec); break; }
                                            case "20:00": { dataGridView6.Rows[25].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 25, 1, status_rec); break; }
                                            case "20:30": { dataGridView6.Rows[26].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView6, 26, 1, status_rec); break; }
                                        };
                                    }
                                    else
                                    {
                                        if (date_rec == label12.Text)
                                        {
                                            switch (time_rec)
                                            {
                                                case "7:00": { dataGridView5.Rows[0].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 0, 1, status_rec); break; }
                                                case "7:30": { dataGridView5.Rows[1].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 1, 1, status_rec); break; }
                                                case "8:00": { dataGridView5.Rows[2].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 2, 1, status_rec); break; }
                                                case "8:30": { dataGridView5.Rows[3].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 3, 1, status_rec); break; }
                                                case "9:00": { dataGridView5.Rows[4].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 4, 1, status_rec); break; }
                                                case "9:30": { dataGridView5.Rows[5].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 5, 1, status_rec); break; }
                                                case "10:00": { dataGridView5.Rows[6].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 6, 1, status_rec); break; }
                                                case "10:30": { dataGridView5.Rows[7].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 7, 1, status_rec); break; }
                                                case "11:00": { dataGridView5.Rows[8].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 8, 1, status_rec); break; }
                                                case "11:30": { dataGridView5.Rows[9].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 9, 1, status_rec); break; }
                                                case "12:30": { dataGridView5.Rows[10].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 10, 1, status_rec); break; }
                                                case "13:00": { dataGridView5.Rows[11].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 11, 1, status_rec); break; }
                                                case "13:30": { dataGridView5.Rows[12].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 12, 1, status_rec); break; }
                                                case "14:00": { dataGridView5.Rows[13].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 13, 1, status_rec); break; }
                                                case "14:30": { dataGridView5.Rows[14].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 14, 1, status_rec); break; }
                                                case "15:00": { dataGridView5.Rows[15].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 15, 1, status_rec); break; }
                                                case "15:30": { dataGridView5.Rows[16].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 16, 1, status_rec); break; }
                                                case "16:00": { dataGridView5.Rows[17].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 17, 1, status_rec); break; }
                                                case "16:30": { dataGridView5.Rows[18].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 18, 1, status_rec); break; }
                                                case "17:00": { dataGridView5.Rows[19].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 19, 1, status_rec); break; }
                                                case "17:30": { dataGridView5.Rows[20].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 20, 1, status_rec); break; }
                                                case "18:00": { dataGridView5.Rows[21].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 21, 1, status_rec); break; }
                                                case "18:30": { dataGridView5.Rows[22].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 22, 1, status_rec); break; }
                                                case "19:00": { dataGridView5.Rows[23].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 23, 1, status_rec); break; }
                                                case "19:30": { dataGridView5.Rows[24].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 24, 1, status_rec); break; }
                                                case "20:00": { dataGridView5.Rows[25].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 25, 1, status_rec); break; }
                                                case "20:30": { dataGridView5.Rows[26].Cells[1].Value = patient_rec_name; vr.SetColor_ReceptionCell(dataGridView5, 26, 1, status_rec); break; }
                                            };
                                        }
                                    }
                                }
                            }
                        }
                    }

                }
            }
        }

        private void просмотрToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FReports rep = new FReports();
            rep.ShowDialog();
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process SysInfo = new Process();
            SysInfo.StartInfo.ErrorDialog = true;
            SysInfo.StartInfo.FileName = Application.StartupPath + @"\HELPMedicine.chm";
            SysInfo.Start();
        }
    }
}
