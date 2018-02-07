namespace Diplom_FastMedicine_
{
    partial class FUpdateDocData
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(225, 105);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Изменить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 105);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Закрыть";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Старое значение:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Новое значение:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(104, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "label3";
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(107, 53);
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(170, 20);
            this.maskedTextBox1.TabIndex = 5;
            this.maskedTextBox1.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.maskedTextBox1_MaskInputRejected);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Enabled = false;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
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
            this.comboBox1.Location = new System.Drawing.Point(12, 155);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(20, 21);
            this.comboBox1.TabIndex = 6;
            this.comboBox1.Visible = false;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Enabled = false;
            this.numericUpDown1.Location = new System.Drawing.Point(58, 155);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(20, 20);
            this.numericUpDown1.TabIndex = 7;
            this.numericUpDown1.Visible = false;
            // 
            // FUpdateDocData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 140);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.maskedTextBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FUpdateDocData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Изменение значения";
            this.Load += new System.EventHandler(this.FUpdateDocData_Load);
            this.Shown += new System.EventHandler(this.FUpdateDocData_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
    }
}