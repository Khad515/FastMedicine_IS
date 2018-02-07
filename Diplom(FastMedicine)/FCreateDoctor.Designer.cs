namespace Diplom_FastMedicine_
{
    partial class FCreateDoctor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCreateDoctor));
            this.label1 = new System.Windows.Forms.Label();
            this.doc_name_box = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.doc_proff_comboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.room_numberbox = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.passport_series_box = new System.Windows.Forms.TextBox();
            this.passport_number_box = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.exp_numberbox = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.label10 = new System.Windows.Forms.Label();
            this.card_number_box = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.phone_number_masked = new System.Windows.Forms.MaskedTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.address_box = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label13 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.room_numberbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exp_numberbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ФИО:";
            // 
            // doc_name_box
            // 
            this.doc_name_box.Location = new System.Drawing.Point(52, 16);
            this.doc_name_box.Name = "doc_name_box";
            this.doc_name_box.Size = new System.Drawing.Size(253, 20);
            this.doc_name_box.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(311, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Профессия:";
            // 
            // doc_proff_comboBox
            // 
            this.doc_proff_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.doc_proff_comboBox.FormattingEnabled = true;
            this.doc_proff_comboBox.Items.AddRange(new object[] {
            "Акушер-гинеколог",
            "Акушерка",
            "Аллерголог",
            "Аллерголог-иммунолог",
            "Ангиохирург",
            "Андролог",
            "Андролог-эндокринолог",
            "Анестезиолог",
            "Анестезиолог-реаниматолог",
            "Аритмолог",
            "Ароматерапевт",
            "Артролог",
            "Бактериолог",
            "Бальнеолог",
            "Валеолог",
            "Венеролог",
            "Вертебролог",
            "Вирусолог",
            "Врач общей практики\t",
            "Врач по лечебной физкультуре и спорту",
            "Врач по лечению бесплодия",
            "Врач по спортивной медицине",
            "Врач скорой помощи",
            "Врач УЗИ",
            "Врач функциональной диагностики",
            "Гастроэнтеролог",
            "Гематолог",
            "Генетик",
            "Гепатолог",
            "Гериатр",
            "Гинеколог",
            "Гинеколог-перинатолог",
            "Гинеколог-эндокринолог",
            "Гирудотерапевт",
            "Гомеопат",
            "Дерматовенеролог",
            "Дерматолог",
            "Диагност",
            "Диетолог",
            "Зубной врач",
            "Иглорефлексотерапевт",
            "Иммунолог",
            "Имплантолог",
            "Инфекционист",
            "Кардиолог",
            "Кардиоревматолог",
            "Кардиохирург",
            "Кинезиолог",
            "Колопроктолог",
            "Косметолог",
            "Курортолог",
            "Лаборант",
            "Логопед",
            "ЛОР\t",
            "Маммолог",
            "Мануальный терапевт",
            "Массажист",
            "Миколог\t",
            "Нарколог",
            "Невролог",
            "Невропатолог",
            "Нейротравматолог\t",
            "Нейрохирург",
            "Неонатолог",
            "Нефролог",
            "Окулист",
            "Онкогинеколог",
            "Онколог",
            "Онколог-гинеколог",
            "Онколог-хирург",
            "Онкоуролог",
            "Ортодонт",
            "Ортопед",
            "Ортопед-травматолог",
            "Остеопат",
            "Отоларинголог",
            "Отоневролог",
            "Офтальмолог",
            "Офтальмолог-хирург",
            "Паразитолог",
            "Паркинсонолог",
            "Пародонтолог",
            "Педиатр",
            "Педиатр-неонатолог",
            "Перинатолог",
            "Пластический хирург",
            "Подолог",
            "Проктолог",
            "Профпатолог",
            "Психиатр",
            "Психиатр-нарколог",
            "Психолог",
            "Психоневролог",
            "Психотерапевт",
            "Пульмонолог",
            "Радиолог",
            "Реабилитолог",
            "Реаниматолог",
            "Ревматолог",
            "Рентгенолог",
            "Репродуктолог",
            "Рефлексотерапевт",
            "Санитарный врач по гигиене детей и подростков",
            "Санитарный врач по гигиене питания",
            "Санитарный врач по гигиене труда",
            "Сексолог",
            "Сексопатолог",
            "Семейный врач\t",
            "Семейный доктор",
            "Сомнолог",
            "Сосудистый хирург",
            "Специалист восстановительного лечения",
            "Стоматолог",
            "Стоматолог-ортодонт",
            "Стоматолог-ортопед",
            "Стоматолог-протезист",
            "Стоматолог-терапевт",
            "Стоматолог-хирург",
            "Суггестолог",
            "Судебно-медицинский эксперт",
            "Сурдолог",
            "Сурдопедагог",
            "Терапевт",
            "Терапевт мануальный",
            "Токсиколог",
            "Торакальный хирург",
            "Травматолог",
            "Трансфузиолог",
            "Трихолог",
            "УЗИ врач",
            "Урогинеколог",
            "Уролог",
            "Фармаколог клинический",
            "Физиотерапевт",
            "Флеболог",
            "Фониатр",
            "Фтизиатр",
            "Фтизиопедиатр",
            "Хирург",
            "Хирург детский",
            "Хирург пластический",
            "Хирург сосудистый",
            "Хирург торакальный",
            "Хирург челюстно-лицевой",
            "Хирург-флеболог",
            "Челюстно-лицевой хирург",
            "Эмбриолог",
            "Эндодонт",
            "Эндокринолог",
            "Эндоскопист",
            "Эпидемиолог",
            "Эпилептолог"});
            this.doc_proff_comboBox.Location = new System.Drawing.Point(86, 48);
            this.doc_proff_comboBox.Name = "doc_proff_comboBox";
            this.doc_proff_comboBox.Size = new System.Drawing.Size(162, 21);
            this.doc_proff_comboBox.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Кабинет:";
            // 
            // room_numberbox
            // 
            this.room_numberbox.Location = new System.Drawing.Point(70, 84);
            this.room_numberbox.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.room_numberbox.Name = "room_numberbox";
            this.room_numberbox.Size = new System.Drawing.Size(53, 20);
            this.room_numberbox.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Паспорт:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(67, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Серия:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(178, 130);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Номер:";
            // 
            // passport_series_box
            // 
            this.passport_series_box.Location = new System.Drawing.Point(114, 127);
            this.passport_series_box.Name = "passport_series_box";
            this.passport_series_box.Size = new System.Drawing.Size(55, 20);
            this.passport_series_box.TabIndex = 10;
            // 
            // passport_number_box
            // 
            this.passport_number_box.Location = new System.Drawing.Point(225, 127);
            this.passport_number_box.Name = "passport_number_box";
            this.passport_number_box.Size = new System.Drawing.Size(100, 20);
            this.passport_number_box.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 173);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Стаж роботы:";
            // 
            // exp_numberbox
            // 
            this.exp_numberbox.Location = new System.Drawing.Point(86, 168);
            this.exp_numberbox.Name = "exp_numberbox";
            this.exp_numberbox.Size = new System.Drawing.Size(49, 20);
            this.exp_numberbox.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(141, 175);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(24, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "лет";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(336, 383);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "Добавить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 383);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 16;
            this.button2.Text = "Закрыть";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(178, 175);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Пол:";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(214, 173);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(34, 17);
            this.radioButton1.TabIndex = 18;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "М";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(269, 173);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(36, 17);
            this.radioButton2.TabIndex = 19;
            this.radioButton2.Text = "Ж";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 212);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "Номер карты:";
            // 
            // card_number_box
            // 
            this.card_number_box.Location = new System.Drawing.Point(93, 209);
            this.card_number_box.Name = "card_number_box";
            this.card_number_box.Size = new System.Drawing.Size(180, 20);
            this.card_number_box.TabIndex = 21;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 249);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(117, 13);
            this.label11.TabIndex = 22;
            this.label11.Text = "Контактный телефон:";
            // 
            // phone_number_masked
            // 
            this.phone_number_masked.Location = new System.Drawing.Point(135, 246);
            this.phone_number_masked.Mask = "(999) 00-000-0000";
            this.phone_number_masked.Name = "phone_number_masked";
            this.phone_number_masked.Size = new System.Drawing.Size(138, 20);
            this.phone_number_masked.TabIndex = 23;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 283);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(111, 13);
            this.label12.TabIndex = 24;
            this.label12.Text = "Обслуживает адрес:";
            // 
            // address_box
            // 
            this.address_box.Location = new System.Drawing.Point(129, 280);
            this.address_box.Name = "address_box";
            this.address_box.Size = new System.Drawing.Size(151, 20);
            this.address_box.TabIndex = 25;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 323);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(89, 13);
            this.label13.TabIndex = 26;
            this.label13.Text = "Дата рождения:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(107, 317);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(82, 20);
            this.dateTimePicker1.TabIndex = 27;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(13, 358);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(95, 13);
            this.label14.TabIndex = 28;
            this.label14.Text = "Архивный номер:";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(114, 356);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(75, 20);
            this.numericUpDown1.TabIndex = 29;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(195, 323);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(43, 13);
            this.label15.TabIndex = 30;
            this.label15.Text = "Смена:";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "1 смена",
            "2 смена"});
            this.comboBox1.Location = new System.Drawing.Point(244, 320);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 31;
            // 
            // FCreateDoctor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 418);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.address_box);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.phone_number_masked);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.card_number_box);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.exp_numberbox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.passport_number_box);
            this.Controls.Add(this.passport_series_box);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.room_numberbox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.doc_proff_comboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.doc_name_box);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FCreateDoctor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавление записи в базу данных - Доктор";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FCreateDoctor_FormClosing);
            this.Load += new System.EventHandler(this.FCreateDoctor_Load);
            this.Shown += new System.EventHandler(this.FCreateDoctor_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.room_numberbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exp_numberbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox doc_name_box;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox doc_proff_comboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown room_numberbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox passport_series_box;
        private System.Windows.Forms.TextBox passport_number_box;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown exp_numberbox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox card_number_box;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.MaskedTextBox phone_number_masked;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox address_box;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}