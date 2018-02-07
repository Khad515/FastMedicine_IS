using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Core;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Diplom_FastMedicine_
{
    class GlobalVar
    {
        public static string acc_type;
        public static int TabIndex = 0;
        public static bool exit = false;
        public static string signIn_login;
        public static Image doctor_photo_path = null;
        public static Image patient_photo_path = null;
        public static DateTime SelectedDate;
        public static DateTime Start_Week_Date;
        public static DateTime End_Week_Date;
        public static int pages_count;
        public static int count_datarows;
        public static int selected_docID;
        public static int selected_RowIndex;
        public static int selected_MedRowIndex;
        public static int selected_ListRowIndex;
        public static string selectedOld_value;
        public static bool needToUpdate_FPatientDataView = false;
        public static bool needToUpdate_FDocInfoView = false;
        public static bool needToUpdate_FPatInfoView = false;
        public static bool needToUpdate_FDocDataView = false;
        public static bool needToUpdate_FMedications = false;
        public static bool needToUpdate_FResearches = false;
        public static bool needToUpdate_FServices = false;
        public static bool doc_filtred = false;
        public static List<decimal> filtred_doc_id = new List<decimal>();

        public static List<decimal> reception_doctor_ids = new List<decimal>(); 

        public static int doc_signin_id;

        public static int _room_number;

        public static int FMain_selected_docid;
        public static string selected_time_reception;
        public static string selected_date_reception;
        public static int selected_patientID_reception = 0;
        public static int selected_reception_ID = 0;

        public static string selected_grid;
        public static int selected_grid_RowIndex;

        public static string agree_sms = "Нет";
        public static string agree_email = "Нет";

        public static bool set_patient_need;






        //цвет ячейки в зависимости от результата явки пациента

        public void SetColor_ReceptionCell(DataGridView grid,int _Row, int _Cell, string rec_status)
        {
            if(rec_status == "Не пришел")
            {
                grid.Rows[_Row].Cells[_Cell].Style.BackColor = Color.IndianRed;
            }else
            {
                if(rec_status == "Пришел")
                {
                    grid.Rows[_Row].Cells[_Cell].Style.BackColor = Color.LightGreen;
                }
            }
        }

        // уникальность по наименованию добавляемой услуги в грид(при создании записи к врачу)
        public bool CheckDistinct_ValueGrid(DataGridView grid, string value)
        {
            List<string> values_list = new List<string>();
            for(int i = 0;i < grid.Rows.Count;i++)
            {
                values_list.Add(grid.Rows[i].Cells[1].Value.ToString());
            }
            if(values_list.Contains(value))
            {
                return false;
            }else { return true; }
            
        }
        
        // Входит ли значение в заданный промежуток чисел
        public bool CheckNumberIn(NumericUpDown n1, NumericUpDown n2, int n3)
        {
            if(n3 >= n1.Value && n3 <= n2.Value)
            {
                return true;
            }
            else { return false; }
        }

        //фильтр по датам рождения(проверка возраста) и фильтрация по статусу
        public List<decimal> FilterBirthDoctors(DateTime d1, DateTime d2, string status)
        {
            DateTime d3;
            MedicineContext context = new MedicineContext();
            List<decimal> idlist = new List<decimal>();
            var doclist = context.Doctors.ToList();
            foreach(var r in doclist)
            {
                d3 = Convert.ToDateTime(r.doc_birthdate.ToString());
                
                    if (d1.CompareTo(d3) <= 0 && d2.CompareTo(d3) >= 0 && r.doc_status == status)
                    {
                        idlist.Add(r.doctor_id);
                    }
       
                
            }
            return idlist;
        }


        // количество страниц(по отношеню к количеству записей в бд)
        public int PageCount(int rows)
        {
            int pages = rows / 12;
            if (rows % 12 != 0 || pages == 0)
            {
                return pages + 1;
            }
            else
            {
                return pages;
            }
        }


        //снятия фокуса с ячеек таблиц
        public void FreeFocus_ALL_Cells(DataGridView grid)
        {
 
                    for (int i = 0; i < grid.RowCount; i++)
                    {
                        for (int j = 0; j < grid.ColumnCount; j++)
                        {
                            grid.Rows[i].Cells[j].Selected = false;
                        }
                    }  
            
        }

        //снятия фокуса с ячеек таблиц основной формы при нажатии правой кнопкой мыши
        public void FreeFocus_From_Cells(DataGridView grid, DataGridViewCellMouseEventArgs eCells)
        {
            if (eCells.RowIndex != -1 && eCells.ColumnIndex != -1)
            {
                if (eCells.Button == MouseButtons.Right)
                {
                    for (int i = 0; i < grid.RowCount; i++)
                    {
                        for (int j = 0; j < grid.ColumnCount; j++)
                        {
                            grid.Rows[i].Cells[j].Selected = false;
                        }
                    }
                    grid.Rows[eCells.RowIndex].Cells[eCells.ColumnIndex].Selected = true;
                }
            }
        }

        // назначаем ячейкам наших таблиц(главной формы) столбца пациентов контекстное меню 
        public void SetContextMenu_Cells(DataGridView grid, ContextMenuStrip strip)
        {
            for (int i = 0; i < grid.Rows.Count; i++)
            {
                grid.Rows[i].Cells[1].ContextMenuStrip = strip;
            }
        }

        // назначаем определенным столбцам определенные контекстные меню
        public void SetContextMenu_Collumns(DataGridView grid, ContextMenuStrip strip)
        {
            switch (strip.Name.ToString())
            {
                case "id_context": {
                        for (int i = 0; i < grid.Rows.Count; i++)
                        {
                            grid.Rows[i].Cells[0].ContextMenuStrip = strip;
                        }
                        break; }
                case "doctor_name_context": {
                        for (int i = 0; i < grid.Rows.Count; i++)
                        {
                            grid.Rows[i].Cells[1].ContextMenuStrip = strip;
                        }
                        break; }
                case "room_context": {
                        for (int i = 0; i < grid.Rows.Count; i++)
                        {
                            grid.Rows[i].Cells[2].ContextMenuStrip = strip;
                        }
                        break; }
                case "proff_context": {
                        for (int i = 0; i < grid.Rows.Count; i++)
                        {
                            grid.Rows[i].Cells[3].ContextMenuStrip = strip;
                        }
                        break; }
                case "phone_number_context": {
                        for (int i = 0; i < grid.Rows.Count; i++)
                        {
                            grid.Rows[i].Cells[4].ContextMenuStrip = strip;
                        }
                        break; }
                case "contextMenuStrip":
                    {
                        for(int i = 0;i < grid.Rows.Count;i++)
                        {
                            for(int j = 1;j < grid.Columns.Count;j++)
                            {
                                grid.Rows[i].Cells[j].ContextMenuStrip = strip;
                            }
                        }
                        break;
                    }
            };
        }

        // начало недели
        public string StartWeek(DateTime date)
        {
            DateTime date1 = date;
            switch (date.DayOfWeek.ToString())
            {
                case "Monday": { return date1.ToShortDateString(); break; }
                case "Tuesday": { return date1.AddDays(-1).ToShortDateString(); break; }
                case "Wednesday": { return date1.AddDays(-2).ToShortDateString(); break; }
                case "Thursday": { return date1.AddDays(-3).ToShortDateString(); break; }
                case "Friday": { return date1.AddDays(-4).ToShortDateString(); break; }
                case "Saturday": { return date1.AddDays(-5).ToShortDateString(); break; }
                default: { return date1.AddDays(-6).ToShortDateString(); break; }
            }
        }
        // конец недели
        public string EndWeek(DateTime date)
        {
            DateTime date1 = date;
            switch (date.DayOfWeek.ToString())
            {
                case "Monday": { return date1.AddDays(5).ToShortDateString(); break; }
                case "Tuesday": { return date1.AddDays(4).ToShortDateString(); break; }
                case "Wednesday": { return date1.AddDays(3).ToShortDateString(); break; }
                case "Thursday": { return date1.AddDays(2).ToShortDateString(); break; }
                case "Friday": { return date1.AddDays(1).ToShortDateString(); break; }
                case "Saturday": { return date1.ToShortDateString(); break; }
                default: { return date1.AddDays(-1).ToShortDateString(); break; }
            }


        }

        //добавление стартовых данных в grid
        public void GridDataAdd(DataGridView grid)
        {
            grid.Rows.Clear();
            grid.Rows.Add("7:00");
            grid.Rows.Add("7:30");
            grid.Rows.Add("8:00");
            grid.Rows.Add("8:30");
            grid.Rows.Add("9:00");
            grid.Rows.Add("9:30");
            grid.Rows.Add("10:00");
            grid.Rows.Add("10:30");
            grid.Rows.Add("11:00");
            grid.Rows.Add("11:30");
            grid.Rows.Add("12:30");
            grid.Rows.Add("13:00");
            grid.Rows.Add("13:30");
            grid.Rows.Add("14:00");
            grid.Rows.Add("14:30");
            grid.Rows.Add("15:00");

            grid.Rows.Add("15:30");
            grid.Rows.Add("16:00");
            grid.Rows.Add("16:30");
            grid.Rows.Add("17:00");
            grid.Rows.Add("17:30");
            grid.Rows.Add("18:00");
            grid.Rows.Add("18:30");
            grid.Rows.Add("19:00");
            grid.Rows.Add("19:30");
            grid.Rows.Add("20:00");
            grid.Rows.Add("20:30");
        }

        public void GridTimeWorking(DataGridView grid, int _doc_id)
        {
            MedicineContext context = new MedicineContext();
            string status_time = context.Doctors.Where(c => c.doctor_id == _doc_id).Select(c => c.time_working).FirstOrDefault().ToString();
            if(status_time == "1 смена")
            {
                for (int i = 0; i < 16; i++)
                {
                    grid.Rows[i].Visible = true;
                }
                for (int i = 16; i < 26; i++)
                {
                    grid.Rows[i].Visible = false;
                }

            }
            else
            {
                for (int i = 0; i < 16; i++)
                {
                    grid.Rows[i].Visible = false;
                }
                for (int i = 16; i < 26; i++)
                {
                    grid.Rows[i].Visible = true;
                }
            }
        }

        //запретить сортировку столбцов в grid
        public void Grid_Stop_Sortable(DataGridView grid)
        {
            foreach (DataGridViewColumn column in grid.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
    }



    class Medicine_Data : GlobalVar
    {
        //-----------------------------------
        //Изменение данных в базе докторов--- 
        //-----------------------------------

        //изменяем смену времени доктора в базе
        public void Update_DoctorTimeWorking(int doc_id, string new_value)
        {
            MedicineContext context = new MedicineContext();
            var doctor = context.Doctors.Where(c => c.doctor_id == doc_id).FirstOrDefault();
            doctor.time_working = new_value;
            context.SaveChanges();
        }

        //изменяем имя доктора в базе
        public void Update_DoctorName(int doc_id, string new_value)
        {
            MedicineContext context = new MedicineContext();
            var doctor = context.Doctors.Where(c => c.doctor_id == doc_id).FirstOrDefault();
            doctor.doctor_name = new_value;
            context.SaveChanges();
        }

            //изменяем номер кабинета доктора в базе
        public void Update_DoctorRoom(int doc_id, int new_value)
        {
            MedicineContext context = new MedicineContext();
            var doctor = context.Doctors.Where(c => c.doctor_id == doc_id).FirstOrDefault();
            doctor.room_number = new_value;
            context.SaveChanges();
        }

            //изменяем профессию в базе данных докторов
        public void Update_DoctorProff(int doc_id, string new_value)
        {
            MedicineContext context = new MedicineContext();
            var doctor = context.Doctors.Where(c => c.doctor_id == doc_id).FirstOrDefault();
            doctor.job_name = new_value;
            context.SaveChanges();
        }

            //изменяем мобильный номер телефона в базе данных докторов
        public void Update_DoctorPhone(int doc_id, string new_value)
        {
            MedicineContext context = new MedicineContext();
            var doctor = context.Doctors.Where(c => c.doctor_id == doc_id).FirstOrDefault();
            doctor.phone_number = new_value;
            context.SaveChanges();
        }

           //изменяем стаж доктора в базе данных
        public void Update_DoctorExp(int doc_id, int new_value)
        {
            MedicineContext context = new MedicineContext();
            var doctor = context.Doctors.Where(c => c.doctor_id == doc_id).FirstOrDefault();
            doctor.doc_experience = new_value;
            context.SaveChanges();
        }

            //изменяем значение пола доктора (вдруг ошибка :D)
        public void Update_DoctorSex(int doc_id, string new_value)
        {
            MedicineContext context = new MedicineContext();
            var doctor = context.Doctors.Where(c => c.doctor_id == doc_id).FirstOrDefault();
            doctor.doc_sex = new_value;
            context.SaveChanges();
        }

            //изменяем значение даты рождения доктора а базе
        public void Update_DoctorBirth(int doc_id, string new_value)
        {
            MedicineContext context = new MedicineContext();
            var doctor = context.Doctors.Where(c => c.doctor_id == doc_id).FirstOrDefault();
            doctor.doc_birthdate = new_value;
            context.SaveChanges();
        }

          //изменяем значение серии паспорта доктора а базе
        public void Update_DoctorPassport_Series(int doc_id, string new_value)
        {
            MedicineContext context = new MedicineContext();
            var doctor = context.Doctors.Where(c => c.doctor_id == doc_id).FirstOrDefault();
            doctor.passport_series = new_value;
            context.SaveChanges();
        }

           //изменяем значение номера паспорта доктора а базе
        public void Update_DoctorPassport_Number(int doc_id, string new_value)
        {
            MedicineContext context = new MedicineContext();
            var doctor = context.Doctors.Where(c => c.doctor_id == doc_id).FirstOrDefault();
            doctor.passport_number = new_value;
            context.SaveChanges();
        }

            //изменяем адресс который обслуживает доктор
        public void Update_DoctorAdress(int doc_id, string new_value)
        {
            MedicineContext context = new MedicineContext();
            var doctor = context.Regions.Where(c => c.doctor_id == doc_id).FirstOrDefault();
            doctor.region_name = new_value;
            context.SaveChanges();
        }


           //изменяем значение номера зарплатной карты доктора а базе
        public void Update_DoctorCard(int doc_id, string new_value)
        {
            MedicineContext context = new MedicineContext();
            var doctor = context.Doctors.Where(c => c.doctor_id == doc_id).FirstOrDefault();
            doctor.doc_card = new_value;
            context.SaveChanges();
        }

          //изменяем значение архивного номера доктора а базе
        public void Update_DoctorArchive(int doc_id, int new_value)
        {
            MedicineContext context = new MedicineContext();
            var doctor = context.Doctors.Where(c => c.doctor_id == doc_id).FirstOrDefault();
            doctor.archive_number = new_value;
            context.SaveChanges();
        }

         //изменяем статус доктора а базе
        public void Update_DoctorStatus(int doc_id, string new_value)
        {
            MedicineContext context = new MedicineContext();
            var doctor = context.Doctors.Where(c => c.doctor_id == doc_id).FirstOrDefault();
            doctor.doc_status = new_value;
            context.SaveChanges();
        }





        //---------------------------
        //действия с изображением----
        //---------------------------

        // конвертация изображения в масив байтов.
        public byte[] imageToByteArray(Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        //-------------------------------------------------------------
        // конвертация масива байтов в base64 в изображение и наоборот-
        //-------------------------------------------------------------

        public string ImageToBase64(Image image, ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // Convert Image to byte[]
                image.Save(ms, format);
                byte[] imageBytes = ms.ToArray();

                // Convert byte[] to Base64 String
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
        }

        // base64 string to image
        public Image Base64ToImage(string base64String)
        {
            // Convert Base64 String to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);

            // Convert byte[] to Image
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = Image.FromStream(ms, true);
            return image;
        }

        //-----------------------------------------------------------------------
        //Увольнение врача. данные сохраняются, но изменяется статус на "Уволен"-
        //-----------------------------------------------------------------------

        public void Delete_Doctor_Record(int doc_id)
        {
            MedicineContext context = new MedicineContext();
            var doc_remove = context.Doctors.Where(c => c.doctor_id == doc_id).FirstOrDefault();
            doc_remove.doc_status = "Уволен";
            doc_remove.room_number = 0;
            context.SaveChanges();
        }

        public void Change_Doctor_Status(int doc_id)
        {
            MedicineContext context = new MedicineContext();
            var doc = context.Doctors.Where(c => c.doctor_id == doc_id).FirstOrDefault();
            doc.doc_status = "Уволен";
            doc.room_number = 0;
            context.SaveChanges();
        }

        //------------------------------------
        //Создание записи в таблице Receptions
        //------------------------------------

        public void Create_Reception_Record(int _doc_id, int _patient_id, string date, string time, string dir)
        {
            MedicineContext context = new MedicineContext();
            Reception rec = new Reception
            {
                doctor_id = _doc_id,
                patient_id = _patient_id,
                date_reception = date,
                time_reception = time,
                directed = dir,
                reception_status = "Не пришел"
            };
            context.Receptions.Add(rec);
            context.SaveChanges();
        }


        //-------------------------------------
        //Создание записи в таблице AnMorbi----
        //-------------------------------------

        public void Create_AnMorbi_Record(int _reception_id, int _count_days)
        {
            MedicineContext context = new MedicineContext();
            AnMorbi mor = new AnMorbi
            {
                reception_id = _reception_id,
                count_days = _count_days
            };
            context.AnMorbis.Add(mor);
            context.SaveChanges();
        }


        //-------------------------------------
        //Изменение записи в таблице AnMorbi---
        //-------------------------------------

        public void UpdateAnMorbi_CountDays(int _reception, int new_value)
        {
            MedicineContext context = new MedicineContext();
            var mor = context.AnMorbis.Where(c => c.reception_id == _reception).FirstOrDefault();
            mor.count_days = new_value;
            context.SaveChanges();
        }


        //-------------------------------------
        //Создание записи в таблице AnVitae----
        //-------------------------------------


        public void Create_AnVitae_Record(int _reception_id, string anVit_value)
        {
            MedicineContext context = new MedicineContext();
            AnVitae vit = new AnVitae
            {
                reception_id = _reception_id,
                vitae_value = anVit_value
            };
            context.AnVitaes.Add(vit);
            context.SaveChanges();
        }

        //-------------------------------------
        //Удаление записи из таблицы AnVitae---
        //-------------------------------------

        public void Delete_AnVitae_Record(int _vitae_id)
        {
            MedicineContext context = new MedicineContext();
            var vit_remove = context.AnVitaes.Where(c => c.vitae_id == _vitae_id).FirstOrDefault();
            context.AnVitaes.Remove(vit_remove);
            context.SaveChanges();
        }

        //-----------------------------------------

        //-------------------------------------
        //Создание записи в таблице Diseas----
        //-------------------------------------


        public void Create_Diseas_Record(int _reception_id, string dis_value)
        {
            MedicineContext context = new MedicineContext();
            Disease vit = new Disease
            {
                reception_id = _reception_id,
                disease_value = dis_value
            };
            context.Diseases.Add(vit);
            context.SaveChanges();
        }

        //-------------------------------------
        //Удаление записи из таблицы Diseas---
        //-------------------------------------

        public void Delete_Diseas_Record(int _dis_it)
        {
            MedicineContext context = new MedicineContext();
            var vit_remove = context.Diseases.Where(c => c.dis_id == _dis_it).FirstOrDefault();
            context.Diseases.Remove(vit_remove);
            context.SaveChanges();
        }


        //----------------------------------------
        //Создание записи в таблице Current_Status
        //----------------------------------------


        public void Create_CurStatus_Record(int _reception_id, string _general, string _phyc)
        {
            MedicineContext context = new MedicineContext();
            Current_Status st = new Current_Status
            {
                reception_id = _reception_id,
                general_state = _general,
                physique_value = _phyc
            };
            context.Current_Status.Add(st);
            context.SaveChanges();
        }

        //-----------------------------------------
        //Изменение записи в таблице Current_Status
        //-----------------------------------------

        
        public void UpdateCurStatus_Status(int _reception_id, string new_general, string new_phyc)
        {
            MedicineContext context = new MedicineContext();
            var st = context.Current_Status.Where(c => c.reception_id == _reception_id).FirstOrDefault();
            st.general_state = new_general;
            st.physique_value = new_phyc;
            context.SaveChanges();
        }


        //-------------------------------------
        //Создание записи в таблицы Complaints-
        //-------------------------------------

        public void Create_Complaint_Record(int _reception_id, string complaint_name)
        {
            MedicineContext context = new MedicineContext();
            Complaint comp = new Complaint
            {
                reception_id = _reception_id,
                complaint_value = complaint_name
            };
            context.Complaints.Add(comp);
            context.SaveChanges();
        }

        //--------------------------------------
        //Удаление записи из таблицы Complaints-
        //--------------------------------------

        public void Delete_Complaint_Record(int _complaint_id)
        {
            MedicineContext context = new MedicineContext();
            var complaint_remove = context.Complaints.Where(c => c.complaint_id == _complaint_id).FirstOrDefault();
            context.Complaints.Remove(complaint_remove);
            context.SaveChanges();
        }
        

        //-------------------------------------
        //Создание записи в таблице Attendances
        //-------------------------------------

        public void CreateONE_Attendances_Record(int _reception_id, int _service_id)
        {
            MedicineContext context = new MedicineContext();
            Attendance att = new Attendance
            {
                reception_id = _reception_id,
                service_id = _service_id
            };
            context.Attendances.Add(att);
            context.SaveChanges();
        }

        public void Create_Attendances_Record(int _doc_id, string _time, string _date, List<int> services_list)
        {
            MedicineContext context = new MedicineContext();

            int recep_it = Convert.ToInt32(context.Receptions.Where(c => c.doctor_id == _doc_id && c.time_reception == _time && c.date_reception == _date).Select(c => c.reception_id).FirstOrDefault());

            
            foreach( int r in services_list)
            {
                Attendance att = new Attendance
                {
                    reception_id = recep_it,
                    service_id = context.Services.Where(c => c.service_id == r).Select(c => c.service_id).FirstOrDefault()
                };
                context.Attendances.Add(att);
                context.SaveChanges();
            }
            context.SaveChanges();
        }

        //--------------------------------------
        //Удаление записи из таблицы Attendances
        //--------------------------------------

        public void DeleteONE_Attendaces_Record(int _reception_id, int _service_id)
        {
            MedicineContext context = new MedicineContext();
            var att_remove = context.Attendances.Where(c => c.reception_id == _reception_id && c.service_id == _service_id).FirstOrDefault();
            context.Attendances.Remove(att_remove);
            context.SaveChanges();
        }


        //--------------------------------------
        //Изменение записи из таблицы Receptions
        //--------------------------------------

        //изменение статуса

        public void Update_Reception_Status_Yes(int _reception_id)
        {
            MedicineContext context = new MedicineContext();
            Reception rec = context.Receptions.Where(c => c.reception_id == _reception_id).FirstOrDefault();
            rec.reception_status = "Пришел";
            context.SaveChanges();
        }

        public void Update_Reception_Status_No(int _reception_id)
        {
            MedicineContext context = new MedicineContext();
            Reception rec = context.Receptions.Where(c => c.reception_id == _reception_id).FirstOrDefault();
            rec.reception_status = "Не пришел";
            context.SaveChanges();
        }


        //-------------------------------------
        //Удаление записи из таблицы Receptions
        //-------------------------------------

        public void Delete_Reception_Record(int _reception_id)
        {
            MedicineContext context = new MedicineContext();
            if (context.Complaints.Any(c => c.reception_id == _reception_id))
            {
                var com_remove = context.Complaints.Where(c => c.reception_id == _reception_id).ToList();
                context.Complaints.RemoveRange(com_remove);
                context.SaveChanges();
            }
             if(context.Medications.Any(c => c.reception_id == _reception_id))
            {
                var med_remove = context.Medications.Where(c => c.reception_id == _reception_id).ToList();
                context.Medications.RemoveRange(med_remove);
                context.SaveChanges();
            } 
            if(context.Diagnosis.Any(c => c.reception_id == _reception_id))
            {
                var diag_remove = context.Diagnosis.Where(c => c.reception_id == _reception_id).ToList();
                context.Diagnosis.RemoveRange(diag_remove);
                context.SaveChanges();
            }
            if(context.Diseases.Any(c => c.reception_id == _reception_id))
            {
                var dis_remove = context.Diseases.Where(c => c.reception_id == _reception_id).ToList();
                context.Diseases.RemoveRange(dis_remove);
                context.SaveChanges();
            }
            
            if(context.AnVitaes.Any(c => c.reception_id == _reception_id))
            {
                var vit_remove = context.AnVitaes.Where(c => c.reception_id == _reception_id).ToList();
                context.AnVitaes.RemoveRange(vit_remove);
                context.SaveChanges();
            }
            
            if(context.AnMorbis.Any(c => c.reception_id == _reception_id))
            {
                var morbi_remove = context.AnMorbis.Where(c => c.reception_id == _reception_id).FirstOrDefault();
                context.AnMorbis.Remove(morbi_remove);
                context.SaveChanges();
            }
            if(context.Inspections.Any(c => c.reception_id == _reception_id))
            {
                var ins_remove = context.Inspections.Where(c => c.reception_id == _reception_id).ToList();
                context.Inspections.RemoveRange(ins_remove);
                context.SaveChanges();
            }
            if(context.Current_Status.Any(c => c.reception_id == _reception_id))
            {
                var cur_remove = context.Current_Status.Where(c => c.reception_id == _reception_id).FirstOrDefault();
                context.Current_Status.Remove(cur_remove);
                context.SaveChanges();
            }

            if (context.Attendances.Any(c => c.reception_id == _reception_id))
            {
                var att_remove = context.Attendances.Where(c => c.reception_id == _reception_id).ToList();
                context.Attendances.RemoveRange(att_remove);
                context.SaveChanges();
            }

            var rec_remove = context.Receptions.Where(c => c.reception_id == _reception_id).FirstOrDefault();
            context.Receptions.Remove(rec_remove);
            context.SaveChanges();
        }

        //-----------------------------------------------------------
        //Получаем список ид записей на прием к определенному доктору
        //-----------------------------------------------------------

        public void GetDoctorReceptionsIDs(int _doc_id)
        {
            MedicineContext context = new MedicineContext();
            GlobalVar.reception_doctor_ids = context.Receptions.Where(c => c.doctor_id == _doc_id).Select(c => c.reception_id).ToList();
        }

        //---------------------------------------
        //Получаем ид записи таблицы Receptions--
        //по дате, времени и ид доктора----------
        //---------------------------------------

        public int Get_Reception_ID(string date, string time, int _doc_id)
        {
            MedicineContext context = new MedicineContext();
            int rec_id = Convert.ToInt32(context.Receptions.Where(c => c.doctor_id == _doc_id && c.date_reception == date && c.time_reception == time).Select(c => c.doctor_id).FirstOrDefault());
            return rec_id;
        }


        //----------------------------------------------------------------
        //Получаем ид доктора по кабинету из строки переденной из treeview
        //----------------------------------------------------------------

        public int GetSelectedNode_DoctorId(string node_text)
        {
            MedicineContext context = new MedicineContext();
            string[] split_node_text = node_text.Split(',');
            int n;
            
            int _doc_id;
            foreach (string r in split_node_text)
            {
                if(int.TryParse(r, out n))
                {
                    GlobalVar._room_number = int.Parse(r);
                }
            }
             _doc_id = Convert.ToInt32(context.Doctors.Where(c => c.room_number == GlobalVar._room_number).Select(c => c.doctor_id).FirstOrDefault());

            return _doc_id;
        }
        
        
        //---------------------------------------
        //Добавление записи в таблицу Services---
        //---------------------------------------

        public void Create_Service_Record(string serv_name, int serv_price)
        {
            MedicineContext context = new MedicineContext();
            Service ser = new Service
            {
                service_name = serv_name,
                service_price = serv_price
            };
            context.Services.Add(ser);
            context.SaveChanges();
        }

        //---------------------------------------
        //Удаление записи из таблицы Services----
        //---------------------------------------

        public void Delete_Service_Record(int serv_id)
        {
            MedicineContext context = new MedicineContext();
            if (context.Attendances.Any(c => c.service_id == serv_id))
            {
                var rel = context.Attendances.Where(c => c.service_id == serv_id).ToList();
                context.Attendances.RemoveRange(rel);
                context.SaveChanges();
            }
            context.SaveChanges();
            Service ser_remove = context.Services.Where(c => c.service_id == serv_id).FirstOrDefault();
            context.Services.Remove(ser_remove);
            context.SaveChanges();
        }

        //---------------------------------------
        //Изменение записи в таблицы Services----
        //---------------------------------------

        public void UpdateServices_Name(int serv_id, string new_value)
        {
            MedicineContext context = new MedicineContext();
            Service ser = context.Services.Where(c => c.service_id == serv_id).FirstOrDefault();
            ser.service_name = new_value;
            context.SaveChanges();
        }

        public void UpdateServices_Price(int serv_id, int new_value)
        {
            MedicineContext context = new MedicineContext();
            Service ser = context.Services.Where(c => c.service_id == serv_id).FirstOrDefault();
            ser.service_price = new_value;
            context.SaveChanges();
        }


        //---------------------------------------
        //Добавление записи в таблицу Medications
        //---------------------------------------

        public void Create_Medication_Record(int _reception_id, int _med_id, int count_days)
        {
            MedicineContext context = new MedicineContext();
            Medication med_c = new Medication
            {
                reception_id = _reception_id,
                med_id = _med_id,
                med_days = count_days
            };
            context.Medications.Add(med_c);
            context.SaveChanges();
        }


        //---------------------------------------
        //Удаление записи из таблицы Medications-
        //---------------------------------------


        public void Delete_Medication_Record(int sel_med_id)
        {
            MedicineContext context = new MedicineContext();
            var med_remove = context.Medications.Where(c => c.selected_med_id == sel_med_id).FirstOrDefault();
            context.Medications.Remove(med_remove);
            context.SaveChanges();
        }


        //---------------------------------------
        //Добавление записи в таблицу Preparation
        //---------------------------------------

        public void Create_Preparation_Record(string prep_name, string prep_code, int prep_count)
        {
            MedicineContext context = new MedicineContext();
            Preparation medicine = new Preparation
            {
                med_name = prep_name,
                med_code = prep_code,
                med_count = prep_count
            };
            context.Preparations.Add(medicine);
            context.SaveChanges();
        }

        //---------------------------------------
        //Удаление записи из таблицы Preparation-
        //---------------------------------------

        public void Delete_Preparation_Record(int prep_id)
        {
            MedicineContext context = new MedicineContext();
            if (context.Medications.Any(c => c.med_id == prep_id))
            {
                var rel = context.Medications.Where(c => c.med_id == prep_id).ToList();
                context.Medications.RemoveRange(rel);
                context.SaveChanges();
            }
            context.SaveChanges();

            Preparation medicine_remove = context.Preparations.Where(c => c.med_id == prep_id).FirstOrDefault();
            context.Preparations.Remove(medicine_remove);
            context.SaveChanges();
        }

        //---------------------------------------
        //Изменение записи в таблицу Preparation-
        //---------------------------------------

        public void UpdateMedication_Name(int _med_id, string new_value)
        {
            MedicineContext context = new MedicineContext();
            Preparation prep = context.Preparations.Where(c => c.med_id == _med_id).FirstOrDefault();
            prep.med_name = new_value;
            context.SaveChanges();
        }

        public void UpdateMedication_Code(int _med_id, string new_value)
        {
            MedicineContext context = new MedicineContext();
            Preparation prep = context.Preparations.Where(c => c.med_id == _med_id).FirstOrDefault();
            prep.med_code = new_value;
            context.SaveChanges();
        }

        public void UpdateMedication_Count(int _med_id, int new_value)
        {
            MedicineContext context = new MedicineContext();
            Preparation prep = context.Preparations.Where(c => c.med_id == _med_id).FirstOrDefault();
            prep.med_count = new_value;
            context.SaveChanges();
        }


        //---------------------------------------
        //Добавление записи в таблицу Inspection-
        //---------------------------------------

        public void Create_Inspection_Record(int _reception_id, int _ins_id, string status)
        {
            MedicineContext context = new MedicineContext();
            Inspection ins_c = new Inspection
            {
                reception_id = _reception_id,
                ins_id = _ins_id,
                inspection_status = status
            };
            context.Inspections.Add(ins_c);
            context.SaveChanges();
        }

        //---------------------------------------
        //Удаление записи из таблицы Inspection--
        //---------------------------------------

        public void Delete_Inspection_Record(int sel_ins_id)
        {
            MedicineContext context = new MedicineContext();
            var ins_remove = context.Inspections.Where(c => c.selected_ins_id == sel_ins_id).FirstOrDefault();
            context.Inspections.Remove(ins_remove);
            context.SaveChanges();
        }



        //---------------------------------------
        //Добавление записи в таблицу Researches
        //---------------------------------------

        public void Create_Research_Record(string inspec_name, int count_days, int inspec_price)
        {
            MedicineContext context = new MedicineContext();
            Research research = new Research
            {
                ins_name = inspec_name,
                ins_countdays = count_days,
                ins_price = inspec_price
            };
            context.Researches.Add(research);
            context.SaveChanges();
        }

        //---------------------------------------
        //Удаление записи из таблицу Researches--
        //---------------------------------------

        public void Delete_Research_Record(int _ins_id)
        {
            MedicineContext context = new MedicineContext();
            if (context.Inspections.Any(c => c.ins_id == _ins_id))
            {
                var rel = context.Inspections.Where(c => c.ins_id == _ins_id).ToList();
                context.Inspections.RemoveRange(rel);
                context.SaveChanges();
            }
            context.SaveChanges();
            
            Research res = context.Researches.Where(c => c.ins_id == _ins_id).FirstOrDefault();
            context.Researches.Remove(res);
            context.SaveChanges();
        }

        //---------------------------------------
        //Изменения записей из таблицы Researches
        //---------------------------------------

        public void UpdateResearches_Name(int _ins_id, string new_value)
        {
            MedicineContext context = new MedicineContext();
            Research res = context.Researches.Where(c => c.ins_id == _ins_id).FirstOrDefault();
            res.ins_name = new_value;
            context.SaveChanges();
        }

        public void UpdateResearches_CountDays(int _ins_id, int new_value)
        {
            MedicineContext context = new MedicineContext();
            Research res = context.Researches.Where(c => c.ins_id == _ins_id).FirstOrDefault();
            res.ins_countdays = new_value;
            context.SaveChanges();
        }

        public void UpdateResearches_Price(int _ins_id, int new_value)
        {
            MedicineContext context = new MedicineContext();
            Research res = context.Researches.Where(c => c.ins_id == _ins_id).FirstOrDefault();
            res.ins_price = new_value;
            context.SaveChanges();
        }

        //-------------------------------------
        //Добавление записи в таблицу Diagnosis
        //-------------------------------------


        public void Create_Diagnosis_Record(int _reception_id,string _diag_value, string _diag_type)
        {
            MedicineContext context = new MedicineContext();
            Diagnosi diag = new Diagnosi
            {
                reception_id = _reception_id,
                diag_value = _diag_value,
                diag_type = _diag_type
            };
            context.Diagnosis.Add(diag);
            context.SaveChanges();
        }


        //-------------------------------------
        //Удаление записи из таблицы Diagnosis-
        //-------------------------------------

        public void Delete_Diagnosis_Recird(int _diag_id)
        {
            MedicineContext context = new MedicineContext();
            var diag_remove = context.Diagnosis.Where(c => c.diag_id == _diag_id).FirstOrDefault();
            context.Diagnosis.Remove(diag_remove);
            context.SaveChanges();
        }




        //-----------------------------------
        //Добавление записи в таблицу Doctors
        //-----------------------------------

        public void Create_Doctor_Record(string doc_name, string doc_proff, int doc_room_number, string doc_passport_series, string doc_passport_number, int doc_job_exp,
            string doctor_sex, string doc_card_number, string doc_phone_number, string doc_address, string doc_photo_path, string doc_birth, int archive_num, string _time)
        {

            MedicineContext context = new MedicineContext();
            Medicine_Data gl = new Medicine_Data();
            Doctor doc = new Doctor
            {
                doctor_name = doc_name,
                job_name = doc_proff,
                room_number = doc_room_number,
                passport_series = doc_passport_series,
                passport_number = doc_passport_number,
                doc_experience = doc_job_exp,
                doc_photo = doc_photo_path,
                phone_number = doc_phone_number,
                doc_sex = doctor_sex,
                doc_birthdate = doc_birth,
                doc_card = doc_card_number,
                archive_number = archive_num,
                doc_status = "Работает",
                time_working = _time
            };
            context.Doctors.Add(doc);
            context.SaveChanges();

            int doc_id = Convert.ToInt32(context.Doctors.Where(c => c.room_number == doc_room_number).Select(c => c.doctor_id).FirstOrDefault());

            Region doc_region = new Region
            {
                doctor_id = doc_id,
                region_name = doc_address
            };
            context.Regions.Add(doc_region);
            context.SaveChanges();

        }

        //------------------------------------
        //Добавление записи в таблицу Patients
        //------------------------------------

        public void Create_Patient_Record(string _patient_name, string _patient_birth, string _patient_photo, string _home_adress, int _medcard, string _discount_card, string _agree_sms,
            string _agree_email, string _sms, string _email, string _patient_series, string _patient_passport_number)
        {
            MedicineContext context = new MedicineContext();
            Patient pat = new Patient
            {
                patient_name = _patient_name,
                birth_date = _patient_birth,
                photo_path = _patient_photo
            };
            context.Patients.Add(pat);
            context.SaveChanges();

            int person_id = Convert.ToInt32(context.Patients.Where(c => c.photo_path == _patient_photo).Select(c => c.patient_id).FirstOrDefault());

            Identifier ident = new Identifier
            {
                patient_id = person_id,
                medcard_number = _medcard
            };
            context.Identifiers.Add(ident);
            context.SaveChanges();

            Location loc = new Location
            {
                patient_id = person_id,
                home_adress = _home_adress
            };
            context.Locations.Add(loc);
            context.SaveChanges();

            Patients_Money pat_money = new Patients_Money
            {
                patient_id = person_id,
                discount_card = _discount_card
            };
            context.Patients_Money.Add(pat_money);
            context.SaveChanges();

            Agreement agree = new Agreement
            {
                patient_id = person_id,
                sms_bool = _agree_sms,
                email_bool = _agree_email
            };
            context.Agreements.Add(agree);
            context.SaveChanges();

            Communication com = new Communication
            {
                patient_id = person_id,
                sms_value = _sms,
                email_value = _email
            };
            context.Communications.Add(com);
            context.SaveChanges();

            Passport pass = new Passport
            {
                patient_id = person_id,
                series = _patient_series,
                numbers = _patient_passport_number
            };
            context.Passports.Add(pass);
            context.SaveChanges();
        }


        //------------------------------------
        //Удаление записи из таблицы Patients-
        //------------------------------------

        public void Delete_Patient_Record(int pat_id)
        {
            MedicineContext context = new MedicineContext();
            Identifier iden_remove = context.Identifiers.Where(c => c.patient_id == pat_id).FirstOrDefault();
            context.Identifiers.Remove(iden_remove);
            context.SaveChanges();

            Location loc_remove = context.Locations.Where(c => c.patient_id == pat_id).FirstOrDefault();
            context.Locations.Remove(loc_remove);
            context.SaveChanges();

            Passport pass_remove = context.Passports.Where(c => c.patient_id == pat_id).FirstOrDefault();
            context.Passports.Remove(pass_remove);
            context.SaveChanges();

            Communication com_remove = context.Communications.Where(c => c.patient_id == pat_id).FirstOrDefault();
            context.Communications.Remove(com_remove);
            context.SaveChanges();

            Patients_Money mon_remove = context.Patients_Money.Where(c => c.patient_id == pat_id).FirstOrDefault();
            context.Patients_Money.Remove(mon_remove);
            context.SaveChanges();

            Agreement agree_remove = context.Agreements.Where(c => c.patient_id == pat_id).FirstOrDefault();
            context.Agreements.Remove(agree_remove);
            context.SaveChanges();

            if (context.Receptions.Any(c => c.patient_id == pat_id))
            {
                var rel = context.Receptions.Where(c => c.patient_id == pat_id).ToList();
                context.Receptions.RemoveRange(rel);
                context.SaveChanges();
            }
            context.SaveChanges();

            Patient pat_remove = context.Patients.Where(c => c.patient_id == pat_id).FirstOrDefault();
            context.Patients.Remove(pat_remove);
            context.SaveChanges();

        }

        //------------------------------------
        //Изменение записи в таблице Patients-
        //------------------------------------

        public void UpdatePatient_Name(int pat_id, string new_value)
        {
            MedicineContext context = new MedicineContext();
            var pat = context.Patients.Where(c => c.patient_id == pat_id).FirstOrDefault();
            pat.patient_name = new_value;
            context.SaveChanges();
        }

        public void UpdatePatient_Birth(int pat_id, string new_value)
        {
            MedicineContext context = new MedicineContext();
            var pat = context.Patients.Where(c => c.patient_id == pat_id).FirstOrDefault();
            pat.birth_date = new_value;
            context.SaveChanges();
        }

        public void UpdatePatient_MedCard(int pat_id, int new_value)
        {
            MedicineContext context = new MedicineContext();
            var pat = context.Identifiers.Where(c => c.patient_id == pat_id).FirstOrDefault();
            pat.medcard_number = new_value;
            context.SaveChanges();
        }

        public void UpdatePatient_Passport_Series(int pat_id, string new_value)
        {
            MedicineContext context = new MedicineContext();
            var pat = context.Passports.Where(c => c.patient_id == pat_id).FirstOrDefault();
            pat.series = new_value;
            context.SaveChanges();
        }

        public void UpdatePatient_Passport_Number(int pat_id, string new_value)
        {
            MedicineContext context = new MedicineContext();
            var pat = context.Passports.Where(c => c.patient_id == pat_id).FirstOrDefault();
            pat.numbers = new_value;
            context.SaveChanges();
        }

        public void UpdatePatient_Phone(int pat_id, string new_value)
        {
            MedicineContext context = new MedicineContext();
            var pat = context.Communications.Where(c => c.patient_id == pat_id).FirstOrDefault();
            pat.sms_value = new_value;
            context.SaveChanges();
        }

        public void UpdatePatient_Email(int pat_id, string new_value)
        {
            MedicineContext context = new MedicineContext();
            var pat = context.Communications.Where(c => c.patient_id == pat_id).FirstOrDefault();
            pat.email_value = new_value;
            context.SaveChanges();
        }

        public void UpdatePatient_DiscountCard(int pat_id, string new_value)
        {
            MedicineContext context = new MedicineContext();
            var pat = context.Patients_Money.Where(c => c.patient_id == pat_id).FirstOrDefault();
            pat.discount_card = new_value;
            context.SaveChanges();
        }

        public void UpdatePatient_AgreeSMS(int pat_id, string new_value)
        {
            MedicineContext context = new MedicineContext();
            var pat = context.Agreements.Where(c => c.patient_id == pat_id).FirstOrDefault();
            pat.sms_bool = new_value;
            context.SaveChanges();
        }

        public void UpdatePatient_AgreeEmail(int pat_id, string new_value)
        {
            MedicineContext context = new MedicineContext();
            var pat = context.Agreements.Where(c => c.patient_id == pat_id).FirstOrDefault();
            pat.email_bool = new_value;
            context.SaveChanges();
        }

        public void UpdatePatient_Adress(int pat_id, string new_value)
        {
            MedicineContext context = new MedicineContext();
            var pat = context.Locations.Where(c => c.patient_id == pat_id).FirstOrDefault();
            pat.home_adress = new_value;
            context.SaveChanges();
        }


        // проверка на уникальность номера мед. карты пациента
        public bool Check_Data_DocLogin(string login)
        {
            MedicineContext context = new MedicineContext();
            List<string> login_list = new List<string>();
            foreach (var r in context.Doc_Accounts.ToList())
            {
                login_list.Add(r.doc_login.ToString());
            }
            if (login_list.Contains(login))
            {
                return true;
            }
            else { return false; }
        }

        // проверка на уникальность номера мед. карты пациента
        public bool Check_Data_Medcard(string medcard)
        {
            MedicineContext context = new MedicineContext();
            List<string> medcard_list = new List<string>();
            foreach (var r in context.Identifiers.ToList())
            {
                medcard_list.Add(r.medcard_number.ToString());
            }
            if (medcard_list.Contains(medcard))
            {
                return true;
            }
            else { return false; }
        }

        // проверка на уникальность архивного номера доктора
        public bool Check_Data_Archive(string archive)
        {
            MedicineContext context = new MedicineContext();
            List<string> archive_list = new List<string>();
            foreach (var r in context.Doctors.ToList())
            {
                archive_list.Add(r.archive_number.ToString());
            }
            if (archive_list.Contains(archive))
            {
                return true;
            }
            else { return false; }
        }

        // проверка на уникальность номера карты доктора
        public bool Check_Data_Card(string card)
        {
            MedicineContext context = new MedicineContext();
            List<string> card_list = new List<string>();
            foreach (var r in context.Doctors.ToList())
            {
                card_list.Add(r.doc_card.ToString());
            }
            if (card_list.Contains(card))
            {
                return true;
            }
            else { return false; }
        }

        // проверка на уникальность кабинета доктора
        public bool Check_Data_Room(string room)
        {
            MedicineContext context = new MedicineContext();
            List<string> room_list = new List<string>();
            foreach (var r in context.Doctors.ToList())
            {
                room_list.Add(r.room_number.ToString());
            }
            if (room_list.Contains(room))
            {
                return true;
            }
            else { return false; }
        }

        // Создание записи в таблицу Doc_Accounts

        public void Create_DocAcc_Record(int _doc_id, string login, string password, string doc_type)
        {
            MedicineContext context = new MedicineContext();
            Doc_Accounts acc = new Doc_Accounts
            {
                doctor_id = _doc_id,
                doc_login = login,
                doc_password = password,
                doc_status = "offline",
                doc_type = doc_type
            };
            context.Doc_Accounts.Add(acc);
            context.SaveChanges();
        }


        public bool Sign_Check(string log, string pass)
        {
            MedicineContext context = new MedicineContext();
            bool check1 = false;
            foreach (var r in context.Doc_Accounts.ToList())
            {
                if (log.Equals(r.doc_login.ToString()) && pass.Equals(r.doc_password.ToString()))
                {
                    check1 = true;
                    break;
                }
                else { check1 = false; }
                
            }
            if(check1 == true) { return true; }else { return false; }
        }
        /*     // аутентификация 
             public bool Sign_Check(string log, string pass)
             {
                 MedicineContext context = new MedicineContext();
                 bool check1 = false;
                 bool check2 = false;
                 foreach (var r in context.Doc_Accounts.ToList())
                 {
                     if (log.Equals(r.doc_login.ToString()) && pass.Equals(r.doc_password.ToString()))
                     {
                         check1 = true;
                     }
                     else { check1 = false; }
                 }

                 foreach (var r in context.Admin_Accounts.ToList())
                 {
                     if (log.Equals(r.a_login.ToString()) && pass.Equals(r.a_password.ToString()))
                     {
                         check2 = true;
                     }
                     else { check2 = false; }
                 }
                 if (check1 == true || check2 == true) { return true; } else { return false; }
             */
        /*
            // проверка статуса пользователя(онлайн, офлайн)
        public bool Check_Sign_Status(string login)
        {
            MedicineContext context = new MedicineContext();
            int a_user_id = Convert.ToInt32(context.Admin_Accounts.Where(c => c.a_login == login).Select(c => c.admin_id).FirstOrDefault());
            int doc_user_id = Convert.ToInt32(context.Doc_Accounts.Where(c => c.doc_login == login).Select(c => c.doctor_id).FirstOrDefault());

            if (a_user_id > 0)
            {
                if(context.Admin_Accounts.Where(c => c.admin_id == a_user_id).Select(c => c.a_status).FirstOrDefault().ToString().Equals("offline"))
                {
                    return true;
                }else { return false; }
            }else
            {

                    if (context.Doc_Accounts.Where(c => c.doctor_id == doc_user_id).Select(c => c.doc_status).FirstOrDefault().ToString().Equals("offline"))
                    {
                        return true;
                    }
                    else { return false; }
            }

        }
        */

        // проверка статуса пользователя(онлайн, офлайн)
        public bool Check_Sign_Status(string login)
        {
            MedicineContext context = new MedicineContext();
            
            int doc_user_id = Convert.ToInt32(context.Doc_Accounts.Where(c => c.doc_login == login).Select(c => c.doctor_id).FirstOrDefault());

                if (context.Doc_Accounts.Where(c => c.doctor_id == doc_user_id).Select(c => c.doc_status).FirstOrDefault().ToString().Equals("offline"))
                {
                    return true;
                }
                else { return false; }
        }


        //проверка состояния сервера MS SQL SERVER
        public bool Check_Server_Activity()
        {
            MedicineContext context = new MedicineContext();
            return context.Database.Exists();
        }


        //изменения статуса offline на online
        public void Status_Offline_Change(string login)
        {
            MedicineContext context = new MedicineContext();
            int doc_user_id = Convert.ToInt32(context.Doc_Accounts.Where(c => c.doc_login == login).Select(c => c.doctor_id).FirstOrDefault());
            
            var doctor = context.Doc_Accounts.Where(c => c.doctor_id == doc_user_id).FirstOrDefault();
            doctor.doc_status = "online";
            context.SaveChanges();

        }

        //изменения статуса online на offline 
        public void Status_Online_Change(string login)
        {
            MedicineContext context = new MedicineContext();
            int doc_user_id = Convert.ToInt32(context.Doc_Accounts.Where(c => c.doc_login == login).Select(c => c.doctor_id).FirstOrDefault());

            var doctor = context.Doc_Accounts.Where(c => c.doctor_id == doc_user_id).FirstOrDefault();
            doctor.doc_status = "offline";
            context.SaveChanges();
            

        }

    }



}


