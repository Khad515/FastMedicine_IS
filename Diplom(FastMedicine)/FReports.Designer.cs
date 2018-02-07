namespace Diplom_FastMedicine_
{
    partial class FReports
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
            this.reports_list = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // reports_list
            // 
            this.reports_list.FormattingEnabled = true;
            this.reports_list.Items.AddRange(new object[] {
            "Список предлогаемых услуг",
            "Список предлогаемых обследований",
            "Список медикоментов в наличии",
            "Загруженность графика работы каждого врача",
            "Посещаемость мед. учреждения пациентами"});
            this.reports_list.Location = new System.Drawing.Point(12, 12);
            this.reports_list.Name = "reports_list";
            this.reports_list.Size = new System.Drawing.Size(389, 134);
            this.reports_list.TabIndex = 0;
            this.reports_list.SelectedIndexChanged += new System.EventHandler(this.reports_list_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(286, 173);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Создать отчет";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 208);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.reports_list);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FReports";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Отчеты";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox reports_list;
        private System.Windows.Forms.Button button1;
    }
}