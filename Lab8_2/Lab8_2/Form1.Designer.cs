namespace Lab8_2
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.students_lb = new System.Windows.Forms.ListBox();
            this.name_tb = new System.Windows.Forms.TextBox();
            this.age_tb = new System.Windows.Forms.TextBox();
            this.year_tb = new System.Windows.Forms.TextBox();
            this.rating_tb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groups_lb = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label_5 = new System.Windows.Forms.Label();
            this.add_group_button = new System.Windows.Forms.Button();
            this.add_group_tb = new System.Windows.Forms.TextBox();
            this.del_group_button = new System.Windows.Forms.Button();
            this.add_student_button = new System.Windows.Forms.Button();
            this.change_student_button = new System.Windows.Forms.Button();
            this.del_student_button = new System.Windows.Forms.Button();
            this.clear_fields_button = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.makenewlist_value = new System.Windows.Forms.NumericUpDown();
            this.error_label = new System.Windows.Forms.Label();
            this.add_group_year = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.debug_gb = new System.Windows.Forms.GroupBox();
            this.clear_all_button = new System.Windows.Forms.Button();
            this.debug_active = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.change_name_button = new System.Windows.Forms.Button();
            this.new_name_tb = new System.Windows.Forms.TextBox();
            this.change_year_button = new System.Windows.Forms.Button();
            this.new_year_tb = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.makenewlist_value)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.add_group_year)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.debug_gb.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.new_year_tb)).BeginInit();
            this.SuspendLayout();
            // 
            // students_lb
            // 
            this.students_lb.FormattingEnabled = true;
            this.students_lb.Location = new System.Drawing.Point(11, 169);
            this.students_lb.Name = "students_lb";
            this.students_lb.Size = new System.Drawing.Size(118, 277);
            this.students_lb.TabIndex = 0;
            this.students_lb.SelectedIndexChanged += new System.EventHandler(this.students_lb_SelectedIndexChanged);
            // 
            // name_tb
            // 
            this.name_tb.Location = new System.Drawing.Point(135, 169);
            this.name_tb.Name = "name_tb";
            this.name_tb.Size = new System.Drawing.Size(192, 20);
            this.name_tb.TabIndex = 1;
            // 
            // age_tb
            // 
            this.age_tb.Location = new System.Drawing.Point(135, 216);
            this.age_tb.Name = "age_tb";
            this.age_tb.Size = new System.Drawing.Size(67, 20);
            this.age_tb.TabIndex = 2;
            this.age_tb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.age_tb_KeyPress);
            // 
            // year_tb
            // 
            this.year_tb.Location = new System.Drawing.Point(135, 310);
            this.year_tb.Name = "year_tb";
            this.year_tb.ReadOnly = true;
            this.year_tb.Size = new System.Drawing.Size(67, 20);
            this.year_tb.TabIndex = 3;
            // 
            // rating_tb
            // 
            this.rating_tb.Location = new System.Drawing.Point(135, 265);
            this.rating_tb.Name = "rating_tb";
            this.rating_tb.Size = new System.Drawing.Size(67, 20);
            this.rating_tb.TabIndex = 4;
            this.rating_tb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rating_tb_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(135, 151);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Имя";
            // 
            // groups_lb
            // 
            this.groups_lb.FormattingEnabled = true;
            this.groups_lb.Location = new System.Drawing.Point(11, 31);
            this.groups_lb.Name = "groups_lb";
            this.groups_lb.Size = new System.Drawing.Size(118, 95);
            this.groups_lb.TabIndex = 6;
            this.groups_lb.SelectedIndexChanged += new System.EventHandler(this.groups_lb_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Группы";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Студенты";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(135, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Возраст";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(135, 294);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Курс";
            // 
            // label_5
            // 
            this.label_5.AutoSize = true;
            this.label_5.Location = new System.Drawing.Point(135, 249);
            this.label_5.Name = "label_5";
            this.label_5.Size = new System.Drawing.Size(77, 13);
            this.label_5.TabIndex = 11;
            this.label_5.Text = "Средний балл";
            // 
            // add_group_button
            // 
            this.add_group_button.Location = new System.Drawing.Point(10, 63);
            this.add_group_button.Name = "add_group_button";
            this.add_group_button.Size = new System.Drawing.Size(71, 23);
            this.add_group_button.TabIndex = 12;
            this.add_group_button.Text = "Добавить";
            this.add_group_button.UseVisualStyleBackColor = true;
            this.add_group_button.Click += new System.EventHandler(this.add_group_button_Click);
            // 
            // add_group_tb
            // 
            this.add_group_tb.Location = new System.Drawing.Point(10, 33);
            this.add_group_tb.Name = "add_group_tb";
            this.add_group_tb.Size = new System.Drawing.Size(110, 20);
            this.add_group_tb.TabIndex = 13;
            // 
            // del_group_button
            // 
            this.del_group_button.Location = new System.Drawing.Point(165, 27);
            this.del_group_button.Name = "del_group_button";
            this.del_group_button.Size = new System.Drawing.Size(77, 23);
            this.del_group_button.TabIndex = 14;
            this.del_group_button.Text = "Удалить";
            this.del_group_button.UseVisualStyleBackColor = true;
            this.del_group_button.Click += new System.EventHandler(this.del_group_button_Click);
            // 
            // add_student_button
            // 
            this.add_student_button.Location = new System.Drawing.Point(220, 200);
            this.add_student_button.Name = "add_student_button";
            this.add_student_button.Size = new System.Drawing.Size(107, 23);
            this.add_student_button.TabIndex = 15;
            this.add_student_button.Text = "Добавить";
            this.add_student_button.UseVisualStyleBackColor = true;
            this.add_student_button.Click += new System.EventHandler(this.add_student_button_Click);
            // 
            // change_student_button
            // 
            this.change_student_button.Location = new System.Drawing.Point(220, 229);
            this.change_student_button.Name = "change_student_button";
            this.change_student_button.Size = new System.Drawing.Size(107, 23);
            this.change_student_button.TabIndex = 16;
            this.change_student_button.Text = "Изменить";
            this.change_student_button.UseVisualStyleBackColor = true;
            this.change_student_button.Click += new System.EventHandler(this.change_student_button_Click);
            // 
            // del_student_button
            // 
            this.del_student_button.Location = new System.Drawing.Point(220, 258);
            this.del_student_button.Name = "del_student_button";
            this.del_student_button.Size = new System.Drawing.Size(107, 23);
            this.del_student_button.TabIndex = 17;
            this.del_student_button.Text = "Удалить";
            this.del_student_button.UseVisualStyleBackColor = true;
            this.del_student_button.Click += new System.EventHandler(this.del_student_button_Click);
            // 
            // clear_fields_button
            // 
            this.clear_fields_button.Location = new System.Drawing.Point(220, 287);
            this.clear_fields_button.Name = "clear_fields_button";
            this.clear_fields_button.Size = new System.Drawing.Size(107, 23);
            this.clear_fields_button.TabIndex = 18;
            this.clear_fields_button.Text = "Очистить поля";
            this.clear_fields_button.UseVisualStyleBackColor = true;
            this.clear_fields_button.Click += new System.EventHandler(this.clear_fields_button_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(355, 166);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(360, 23);
            this.button5.TabIndex = 19;
            this.button5.Text = "Создать новый отсортированный супер пупер список курса номер ";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // makenewlist_value
            // 
            this.makenewlist_value.Location = new System.Drawing.Point(721, 166);
            this.makenewlist_value.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.makenewlist_value.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.makenewlist_value.Name = "makenewlist_value";
            this.makenewlist_value.Size = new System.Drawing.Size(47, 20);
            this.makenewlist_value.TabIndex = 20;
            this.makenewlist_value.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // error_label
            // 
            this.error_label.AutoSize = true;
            this.error_label.Location = new System.Drawing.Point(135, 428);
            this.error_label.Name = "error_label";
            this.error_label.Size = new System.Drawing.Size(47, 13);
            this.error_label.TabIndex = 21;
            this.error_label.Text = "Ошибка";
            this.error_label.Visible = false;
            // 
            // add_group_year
            // 
            this.add_group_year.Location = new System.Drawing.Point(130, 34);
            this.add_group_year.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.add_group_year.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.add_group_year.Name = "add_group_year";
            this.add_group_year.Size = new System.Drawing.Size(47, 20);
            this.add_group_year.TabIndex = 22;
            this.add_group_year.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.add_group_button);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.add_group_tb);
            this.groupBox1.Controls.Add(this.add_group_year);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(135, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(214, 95);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Добавить группу";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(127, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Выберите курс";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Введите название";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 24;
            this.button1.Text = "save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(87, 19);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 25;
            this.button2.Text = "load";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // debug_gb
            // 
            this.debug_gb.Controls.Add(this.clear_all_button);
            this.debug_gb.Controls.Add(this.button2);
            this.debug_gb.Controls.Add(this.button1);
            this.debug_gb.Location = new System.Drawing.Point(587, 351);
            this.debug_gb.Name = "debug_gb";
            this.debug_gb.Size = new System.Drawing.Size(168, 95);
            this.debug_gb.TabIndex = 26;
            this.debug_gb.TabStop = false;
            this.debug_gb.Text = "debug";
            this.debug_gb.Visible = false;
            // 
            // clear_all_button
            // 
            this.clear_all_button.Location = new System.Drawing.Point(6, 48);
            this.clear_all_button.Name = "clear_all_button";
            this.clear_all_button.Size = new System.Drawing.Size(75, 23);
            this.clear_all_button.TabIndex = 26;
            this.clear_all_button.Text = "clear";
            this.clear_all_button.UseVisualStyleBackColor = true;
            this.clear_all_button.Click += new System.EventHandler(this.clear_all_button_Click);
            // 
            // debug_active
            // 
            this.debug_active.AutoSize = true;
            this.debug_active.Location = new System.Drawing.Point(771, 427);
            this.debug_active.Name = "debug_active";
            this.debug_active.Size = new System.Drawing.Size(15, 14);
            this.debug_active.TabIndex = 27;
            this.debug_active.UseVisualStyleBackColor = true;
            this.debug_active.CheckedChanged += new System.EventHandler(this.debug_active_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.change_name_button);
            this.groupBox2.Controls.Add(this.new_name_tb);
            this.groupBox2.Controls.Add(this.change_year_button);
            this.groupBox2.Controls.Add(this.new_year_tb);
            this.groupBox2.Controls.Add(this.del_group_button);
            this.groupBox2.Location = new System.Drawing.Point(355, 31);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(248, 95);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Изменить/удалить группу";
            // 
            // change_name_button
            // 
            this.change_name_button.Location = new System.Drawing.Point(122, 63);
            this.change_name_button.Name = "change_name_button";
            this.change_name_button.Size = new System.Drawing.Size(120, 23);
            this.change_name_button.TabIndex = 26;
            this.change_name_button.Text = "Изменить название";
            this.change_name_button.UseVisualStyleBackColor = true;
            this.change_name_button.Click += new System.EventHandler(this.change_name_button_Click);
            // 
            // new_name_tb
            // 
            this.new_name_tb.Location = new System.Drawing.Point(6, 66);
            this.new_name_tb.Name = "new_name_tb";
            this.new_name_tb.Size = new System.Drawing.Size(110, 20);
            this.new_name_tb.TabIndex = 25;
            // 
            // change_year_button
            // 
            this.change_year_button.Location = new System.Drawing.Point(59, 27);
            this.change_year_button.Name = "change_year_button";
            this.change_year_button.Size = new System.Drawing.Size(100, 23);
            this.change_year_button.TabIndex = 24;
            this.change_year_button.Text = "Изменить курс";
            this.change_year_button.UseVisualStyleBackColor = true;
            this.change_year_button.Click += new System.EventHandler(this.change_year_button_Click);
            // 
            // new_year_tb
            // 
            this.new_year_tb.Location = new System.Drawing.Point(6, 30);
            this.new_year_tb.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.new_year_tb.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.new_year_tb.Name = "new_year_tb";
            this.new_year_tb.Size = new System.Drawing.Size(47, 20);
            this.new_year_tb.TabIndex = 23;
            this.new_year_tb.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.debug_active);
            this.Controls.Add(this.debug_gb);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.error_label);
            this.Controls.Add(this.makenewlist_value);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.clear_fields_button);
            this.Controls.Add(this.del_student_button);
            this.Controls.Add(this.change_student_button);
            this.Controls.Add(this.add_student_button);
            this.Controls.Add(this.label_5);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groups_lb);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rating_tb);
            this.Controls.Add(this.year_tb);
            this.Controls.Add(this.age_tb);
            this.Controls.Add(this.name_tb);
            this.Controls.Add(this.students_lb);
            this.Name = "Form1";
            this.Text = "Lab8_2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.Click += new System.EventHandler(this.Form1_Click);
            ((System.ComponentModel.ISupportInitialize)(this.makenewlist_value)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.add_group_year)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.debug_gb.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.new_year_tb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox students_lb;
        private System.Windows.Forms.TextBox name_tb;
        private System.Windows.Forms.TextBox age_tb;
        private System.Windows.Forms.TextBox year_tb;
        private System.Windows.Forms.TextBox rating_tb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox groups_lb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label_5;
        private System.Windows.Forms.Button add_group_button;
        private System.Windows.Forms.TextBox add_group_tb;
        private System.Windows.Forms.Button del_group_button;
        private System.Windows.Forms.Button add_student_button;
        private System.Windows.Forms.Button change_student_button;
        private System.Windows.Forms.Button del_student_button;
        private System.Windows.Forms.Button clear_fields_button;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.NumericUpDown makenewlist_value;
        private System.Windows.Forms.Label error_label;
        private System.Windows.Forms.NumericUpDown add_group_year;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox debug_gb;
        private System.Windows.Forms.CheckBox debug_active;
        private System.Windows.Forms.Button clear_all_button;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button change_name_button;
        private System.Windows.Forms.TextBox new_name_tb;
        private System.Windows.Forms.Button change_year_button;
        private System.Windows.Forms.NumericUpDown new_year_tb;
    }
}

