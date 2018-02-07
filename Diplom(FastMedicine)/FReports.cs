using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace Diplom_FastMedicine_
{
    public partial class FReports : Form
    {
        public FReports()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch(reports_list.SelectedItem.ToString())
            {
                case "Список предлогаемых услуг":
                    {
                        int i = 1;
                        string services_list = "";
                        MedicineContext context = new MedicineContext();
                        foreach(var r in context.Services.ToList())
                        {
                            services_list += i.ToString() + ") " + r.service_name + ". Цена: " + r.service_price.ToString() + Convert.ToChar(11);
                            i++;
                        }

                        Word.Application app = new Word.Application();
                        object fileName = Application.StartupPath + "\\Reports_Template\\ServiceList.dotx";
                        Word.Document doc = app.Documents.Open(fileName);

                        doc.Bookmarks["service"].Range.Text = services_list;
                        doc.Application.Visible = true;
                        break;
                    
                    }
                case "Список предлогаемых обследований":
                    {
                        int i = 1;
                        string insp_list = "";
                        MedicineContext context = new MedicineContext();
                        foreach (var r in context.Researches.ToList())
                        {
                            insp_list += i.ToString() + ") " + r.ins_name + ". Цена: " + r.ins_price.ToString() + Convert.ToChar(11);
                            i++;
                        }
                        Word.Application app = new Word.Application();
                        object fileName = Application.StartupPath + "\\Reports_Template\\ResearchList.dotx";
                        Word.Document doc = app.Documents.Open(fileName);
                        doc.Bookmarks["research"].Range.Text = insp_list;
                        doc.Application.Visible = true;

                        break;
                    }
                case "Список медикоментов в наличии":
                    {
                        int i = 1;
                        string med_list = "";
                        MedicineContext context = new MedicineContext();
                        foreach (var r in context.Preparations.ToList())
                        {
                            med_list += i.ToString() + ") " + r.med_name + ". Количество: " + r.med_count.ToString() + Convert.ToChar(11);
                            i++;
                        }
                        Word.Application app = new Word.Application();
                        object fileName = Application.StartupPath + "\\Reports_Template\\MedList.dotx";
                        Word.Document doc = app.Documents.Open(fileName);
                        doc.Bookmarks["med"].Range.Text = med_list;
                        doc.Application.Visible = true;

                        break;
                    }
                case "Загруженность графика работы каждого врача":
                    {
                        int i = 1;
                        
                        string rec_list = "";
                        MedicineContext context = new MedicineContext();
                        foreach(var r in context.Doctors.ToList())
                        {
                            int rec_count = context.Receptions.Where(c => c.doctor_id == r.doctor_id).Count();
                            rec_list += i.ToString() + ") " + r.doctor_name.ToString() + ". Записей на прием: " + rec_count.ToString() + Convert.ToChar(11);
                            i++;
                        }
                        Word.Application app = new Word.Application();
                        object fileName = Application.StartupPath + "\\Reports_Template\\ReceptionsDocList.dotx";
                        Word.Document doc = app.Documents.Open(fileName);
                        doc.Bookmarks["pop"].Range.Text = rec_list;
                        doc.Application.Visible = true;

                        break;
                    }
                case "Посещаемость мед. учреждения пациентами":
                    {
                        int i = 1;

                        string rec_list = "";
                        MedicineContext context = new MedicineContext();
                        foreach (var r in context.Patients.ToList())
                        {
                            int rec_count = context.Receptions.Where(c => c.patient_id == r.patient_id).Count();
                            rec_list += i.ToString() + ") " + r.patient_name.ToString() + ". Всего записей на прием: " + rec_count.ToString() + Convert.ToChar(11);
                            i++;
                        }
                        Word.Application app = new Word.Application();
                        object fileName = Application.StartupPath + "\\Reports_Template\\ReceptionsPatList.dotx";
                        Word.Document doc = app.Documents.Open(fileName);
                        doc.Bookmarks["patients"].Range.Text = rec_list;
                        doc.Application.Visible = true;

                        break;
                    }
            };
        }

        private void reports_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }
    }
}
