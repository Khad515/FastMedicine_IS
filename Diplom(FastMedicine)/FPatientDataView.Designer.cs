namespace Diplom_FastMedicine_
{
    partial class FPatientDataView
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pat_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pat_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pat_medcard = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pat_phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.back_btn = new System.Windows.Forms.Button();
            this.next_btn = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.page_label = new System.Windows.Forms.Label();
            this.id_context = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.полнаяИнформацияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьЗаписьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.Count_row_lbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.filtr_lbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.фильтрыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.простойФильтрToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отменитьФильтрToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.id_context.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pat_id,
            this.pat_name,
            this.pat_medcard,
            this.pat_phone});
            this.dataGridView1.Location = new System.Drawing.Point(12, 27);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(568, 260);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEnter);
            this.dataGridView1.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDown);
            this.dataGridView1.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellMouseEnter);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // pat_id
            // 
            this.pat_id.HeaderText = "ID";
            this.pat_id.Name = "pat_id";
            this.pat_id.ReadOnly = true;
            this.pat_id.Width = 45;
            // 
            // pat_name
            // 
            this.pat_name.HeaderText = "Имя(ФИО)";
            this.pat_name.Name = "pat_name";
            this.pat_name.ReadOnly = true;
            this.pat_name.Width = 200;
            // 
            // pat_medcard
            // 
            this.pat_medcard.HeaderText = "Номер карты";
            this.pat_medcard.Name = "pat_medcard";
            this.pat_medcard.ReadOnly = true;
            this.pat_medcard.Width = 150;
            // 
            // pat_phone
            // 
            this.pat_phone.HeaderText = "Телефон";
            this.pat_phone.Name = "pat_phone";
            this.pat_phone.ReadOnly = true;
            this.pat_phone.Width = 150;
            // 
            // back_btn
            // 
            this.back_btn.Enabled = false;
            this.back_btn.Location = new System.Drawing.Point(239, 293);
            this.back_btn.Name = "back_btn";
            this.back_btn.Size = new System.Drawing.Size(60, 23);
            this.back_btn.TabIndex = 1;
            this.back_btn.Text = "Назад";
            this.back_btn.UseVisualStyleBackColor = true;
            this.back_btn.Click += new System.EventHandler(this.back_btn_Click);
            // 
            // next_btn
            // 
            this.next_btn.Location = new System.Drawing.Point(324, 293);
            this.next_btn.Name = "next_btn";
            this.next_btn.Size = new System.Drawing.Size(60, 23);
            this.next_btn.TabIndex = 2;
            this.next_btn.Text = "Дальше";
            this.next_btn.UseVisualStyleBackColor = true;
            this.next_btn.Click += new System.EventHandler(this.next_btn_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(469, 333);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(111, 23);
            this.button4.TabIndex = 4;
            this.button4.Text = "Добавить запись";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // page_label
            // 
            this.page_label.AutoSize = true;
            this.page_label.Location = new System.Drawing.Point(305, 298);
            this.page_label.Name = "page_label";
            this.page_label.Size = new System.Drawing.Size(13, 13);
            this.page_label.TabIndex = 5;
            this.page_label.Text = "1";
            this.page_label.TextChanged += new System.EventHandler(this.page_label_TextChanged);
            // 
            // id_context
            // 
            this.id_context.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.полнаяИнформацияToolStripMenuItem,
            this.удалитьЗаписьToolStripMenuItem,
            this.SetToolStripMenuItem});
            this.id_context.Name = "contextMenuStrip1";
            this.id_context.Size = new System.Drawing.Size(177, 70);
            this.id_context.Opening += new System.ComponentModel.CancelEventHandler(this.id_context_Opening);
            // 
            // полнаяИнформацияToolStripMenuItem
            // 
            this.полнаяИнформацияToolStripMenuItem.Name = "полнаяИнформацияToolStripMenuItem";
            this.полнаяИнформацияToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.полнаяИнформацияToolStripMenuItem.Text = "Полная информация";
            this.полнаяИнформацияToolStripMenuItem.Click += new System.EventHandler(this.полнаяИнформацияToolStripMenuItem_Click);
            // 
            // удалитьЗаписьToolStripMenuItem
            // 
            this.удалитьЗаписьToolStripMenuItem.Name = "удалитьЗаписьToolStripMenuItem";
            this.удалитьЗаписьToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.удалитьЗаписьToolStripMenuItem.Text = "Удалить запись";
            this.удалитьЗаписьToolStripMenuItem.Click += new System.EventHandler(this.удалитьЗаписьToolStripMenuItem_Click);
            // 
            // SetToolStripMenuItem
            // 
            this.SetToolStripMenuItem.Name = "SetToolStripMenuItem";
            this.SetToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.SetToolStripMenuItem.Text = "Выбрать...";
            this.SetToolStripMenuItem.Click += new System.EventHandler(this.выбратьToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.Count_row_lbl,
            this.toolStripStatusLabel3,
            this.filtr_lbl});
            this.statusStrip1.Location = new System.Drawing.Point(0, 376);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(592, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(78, 17);
            this.toolStripStatusLabel1.Text = "Всего записей";
            // 
            // Count_row_lbl
            // 
            this.Count_row_lbl.Name = "Count_row_lbl";
            this.Count_row_lbl.Size = new System.Drawing.Size(29, 17);
            this.Count_row_lbl.Text = "<x>";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(69, 17);
            this.toolStripStatusLabel3.Text = "Фильтрация";
            // 
            // filtr_lbl
            // 
            this.filtr_lbl.Name = "filtr_lbl";
            this.filtr_lbl.Size = new System.Drawing.Size(29, 17);
            this.filtr_lbl.Text = "<x>";
            this.filtr_lbl.Click += new System.EventHandler(this.toolStripStatusLabel4_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.фильтрыToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(592, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // фильтрыToolStripMenuItem
            // 
            this.фильтрыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.простойФильтрToolStripMenuItem,
            this.отменитьФильтрToolStripMenuItem});
            this.фильтрыToolStripMenuItem.Name = "фильтрыToolStripMenuItem";
            this.фильтрыToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.фильтрыToolStripMenuItem.Text = "Фильтры";
            // 
            // простойФильтрToolStripMenuItem
            // 
            this.простойФильтрToolStripMenuItem.Name = "простойФильтрToolStripMenuItem";
            this.простойФильтрToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.простойФильтрToolStripMenuItem.Text = "Простой фильтр";
            this.простойФильтрToolStripMenuItem.Click += new System.EventHandler(this.простойФильтрToolStripMenuItem_Click);
            // 
            // отменитьФильтрToolStripMenuItem
            // 
            this.отменитьФильтрToolStripMenuItem.Name = "отменитьФильтрToolStripMenuItem";
            this.отменитьФильтрToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.отменитьФильтрToolStripMenuItem.Text = "Отменить фильтр";
            this.отменитьФильтрToolStripMenuItem.Click += new System.EventHandler(this.отменитьФильтрToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FPatientDataView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 398);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.page_label);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.next_btn);
            this.Controls.Add(this.back_btn);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "FPatientDataView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Пациенты";
            this.Activated += new System.EventHandler(this.FPatientDataView_Activated);
            this.Deactivate += new System.EventHandler(this.FPatientDataView_Deactivate);
            this.Load += new System.EventHandler(this.FPatientDataView_Load);
            this.Shown += new System.EventHandler(this.FPatientDataView_Shown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FPatientDataView_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.id_context.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button back_btn;
        private System.Windows.Forms.Button next_btn;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label page_label;
        private System.Windows.Forms.ContextMenuStrip id_context;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel Count_row_lbl;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel filtr_lbl;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem фильтрыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem простойФильтрToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отменитьФильтрToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem полнаяИнформацияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьЗаписьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SetToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn pat_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn pat_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn pat_medcard;
        private System.Windows.Forms.DataGridViewTextBoxColumn pat_phone;
    }
}