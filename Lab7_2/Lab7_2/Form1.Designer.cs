namespace Lab7_2
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
            this.arrayType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.output_tb = new System.Windows.Forms.RichTextBox();
            this.create = new System.Windows.Forms.Button();
            this.size1_tb = new System.Windows.Forms.TextBox();
            this.size1_label = new System.Windows.Forms.Label();
            this.size2_label = new System.Windows.Forms.Label();
            this.size2_tb = new System.Windows.Forms.TextBox();
            this.msg_label = new System.Windows.Forms.Label();
            this.autoComplete = new System.Windows.Forms.CheckBox();
            this.input_tb = new System.Windows.Forms.RichTextBox();
            this.inp_label = new System.Windows.Forms.Label();
            this.to_begin = new System.Windows.Forms.RadioButton();
            this.to_end = new System.Windows.Forms.RadioButton();
            this.add_elms = new System.Windows.Forms.Button();
            this.del_many = new System.Windows.Forms.RadioButton();
            this.del_one = new System.Windows.Forms.RadioButton();
            this.oneMany = new System.Windows.Forms.GroupBox();
            this.del_label = new System.Windows.Forms.Label();
            this.rowsColumns = new System.Windows.Forms.GroupBox();
            this.columns_button = new System.Windows.Forms.RadioButton();
            this.rows_button = new System.Windows.Forms.RadioButton();
            this.pos1_label = new System.Windows.Forms.Label();
            this.pos1_tb = new System.Windows.Forms.TextBox();
            this.pos2_tb = new System.Windows.Forms.TextBox();
            this.pos2_label = new System.Windows.Forms.Label();
            this.del_button = new System.Windows.Forms.Button();
            this.torn_add_row = new System.Windows.Forms.Button();
            this.torn_del_row = new System.Windows.Forms.Button();
            this.torn_add_num = new System.Windows.Forms.Button();
            this.torn_pos = new System.Windows.Forms.TextBox();
            this.save = new System.Windows.Forms.Button();
            this.load = new System.Windows.Forms.Button();
            this.oneMany.SuspendLayout();
            this.rowsColumns.SuspendLayout();
            this.SuspendLayout();
            // 
            // arrayType
            // 
            this.arrayType.FormattingEnabled = true;
            this.arrayType.Items.AddRange(new object[] {
            "Одномерный",
            "Двумерный",
            "Рваный"});
            this.arrayType.Location = new System.Drawing.Point(12, 37);
            this.arrayType.Name = "arrayType";
            this.arrayType.Size = new System.Drawing.Size(121, 21);
            this.arrayType.TabIndex = 0;
            this.arrayType.SelectedIndexChanged += new System.EventHandler(this.ArrayType_SelectedIndexChanged);
            this.arrayType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ArrayType_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Тип массива";
            // 
            // output_tb
            // 
            this.output_tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.output_tb.Location = new System.Drawing.Point(389, 12);
            this.output_tb.Name = "output_tb";
            this.output_tb.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.output_tb.Size = new System.Drawing.Size(399, 426);
            this.output_tb.TabIndex = 2;
            this.output_tb.Text = "";
            // 
            // create
            // 
            this.create.Location = new System.Drawing.Point(12, 64);
            this.create.Name = "create";
            this.create.Size = new System.Drawing.Size(121, 23);
            this.create.TabIndex = 3;
            this.create.Text = "Создать массив";
            this.create.UseVisualStyleBackColor = true;
            this.create.Click += new System.EventHandler(this.Create_Click);
            // 
            // size1_tb
            // 
            this.size1_tb.Location = new System.Drawing.Point(84, 115);
            this.size1_tb.Name = "size1_tb";
            this.size1_tb.Size = new System.Drawing.Size(49, 20);
            this.size1_tb.TabIndex = 4;
            this.size1_tb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Size1_tb_KeyPress);
            // 
            // size1_label
            // 
            this.size1_label.AutoSize = true;
            this.size1_label.Location = new System.Drawing.Point(15, 118);
            this.size1_label.Name = "size1_label";
            this.size1_label.Size = new System.Drawing.Size(63, 13);
            this.size1_label.TabIndex = 5;
            this.size1_label.Text = "Элементов";
            // 
            // size2_label
            // 
            this.size2_label.AutoSize = true;
            this.size2_label.Location = new System.Drawing.Point(15, 144);
            this.size2_label.Name = "size2_label";
            this.size2_label.Size = new System.Drawing.Size(55, 13);
            this.size2_label.TabIndex = 7;
            this.size2_label.Text = "Столбцов";
            this.size2_label.Visible = false;
            // 
            // size2_tb
            // 
            this.size2_tb.Location = new System.Drawing.Point(84, 141);
            this.size2_tb.Name = "size2_tb";
            this.size2_tb.Size = new System.Drawing.Size(49, 20);
            this.size2_tb.TabIndex = 6;
            this.size2_tb.Visible = false;
            this.size2_tb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Size2_tb_KeyPress);
            // 
            // msg_label
            // 
            this.msg_label.AutoSize = true;
            this.msg_label.Location = new System.Drawing.Point(12, 424);
            this.msg_label.Name = "msg_label";
            this.msg_label.Size = new System.Drawing.Size(47, 13);
            this.msg_label.TabIndex = 8;
            this.msg_label.Text = "Ошибка";
            this.msg_label.Visible = false;
            // 
            // autoComplete
            // 
            this.autoComplete.AutoSize = true;
            this.autoComplete.Checked = true;
            this.autoComplete.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoComplete.Location = new System.Drawing.Point(18, 94);
            this.autoComplete.Name = "autoComplete";
            this.autoComplete.Size = new System.Drawing.Size(110, 17);
            this.autoComplete.TabIndex = 9;
            this.autoComplete.Text = "Автозаполнение";
            this.autoComplete.UseVisualStyleBackColor = true;
            // 
            // input_tb
            // 
            this.input_tb.Location = new System.Drawing.Point(12, 183);
            this.input_tb.Name = "input_tb";
            this.input_tb.Size = new System.Drawing.Size(226, 21);
            this.input_tb.TabIndex = 10;
            this.input_tb.Text = "";
            // 
            // inp_label
            // 
            this.inp_label.AutoSize = true;
            this.inp_label.Location = new System.Drawing.Point(12, 207);
            this.inp_label.Name = "inp_label";
            this.inp_label.Size = new System.Drawing.Size(187, 13);
            this.inp_label.TabIndex = 11;
            this.inp_label.Text = "Введите элементы для добавления";
            // 
            // to_begin
            // 
            this.to_begin.AutoSize = true;
            this.to_begin.Location = new System.Drawing.Point(15, 223);
            this.to_begin.Name = "to_begin";
            this.to_begin.Size = new System.Drawing.Size(70, 17);
            this.to_begin.TabIndex = 12;
            this.to_begin.Text = "В начало";
            this.to_begin.UseVisualStyleBackColor = true;
            // 
            // to_end
            // 
            this.to_end.AutoSize = true;
            this.to_end.Checked = true;
            this.to_end.Location = new System.Drawing.Point(91, 223);
            this.to_end.Name = "to_end";
            this.to_end.Size = new System.Drawing.Size(65, 17);
            this.to_end.TabIndex = 13;
            this.to_end.TabStop = true;
            this.to_end.Text = "В конец";
            this.to_end.UseVisualStyleBackColor = true;
            // 
            // add_elms
            // 
            this.add_elms.Location = new System.Drawing.Point(163, 220);
            this.add_elms.Name = "add_elms";
            this.add_elms.Size = new System.Drawing.Size(75, 23);
            this.add_elms.TabIndex = 14;
            this.add_elms.Text = "Добавить";
            this.add_elms.UseVisualStyleBackColor = true;
            this.add_elms.Click += new System.EventHandler(this.add_elms_Click);
            // 
            // del_many
            // 
            this.del_many.AutoSize = true;
            this.del_many.Location = new System.Drawing.Point(88, 9);
            this.del_many.Name = "del_many";
            this.del_many.Size = new System.Drawing.Size(81, 17);
            this.del_many.TabIndex = 15;
            this.del_many.Text = "Несколько";
            this.del_many.UseVisualStyleBackColor = true;
            this.del_many.CheckedChanged += new System.EventHandler(this.del_many_CheckedChanged);
            // 
            // del_one
            // 
            this.del_one.AutoSize = true;
            this.del_one.Checked = true;
            this.del_one.Location = new System.Drawing.Point(12, 9);
            this.del_one.Name = "del_one";
            this.del_one.Size = new System.Drawing.Size(51, 17);
            this.del_one.TabIndex = 16;
            this.del_one.TabStop = true;
            this.del_one.Text = "Один";
            this.del_one.UseVisualStyleBackColor = true;
            this.del_one.CheckedChanged += new System.EventHandler(this.del_one_CheckedChanged);
            // 
            // oneMany
            // 
            this.oneMany.Controls.Add(this.del_one);
            this.oneMany.Controls.Add(this.del_many);
            this.oneMany.Location = new System.Drawing.Point(15, 246);
            this.oneMany.Name = "oneMany";
            this.oneMany.Size = new System.Drawing.Size(200, 30);
            this.oneMany.TabIndex = 17;
            this.oneMany.TabStop = false;
            // 
            // del_label
            // 
            this.del_label.AutoSize = true;
            this.del_label.Location = new System.Drawing.Point(12, 167);
            this.del_label.Name = "del_label";
            this.del_label.Size = new System.Drawing.Size(115, 13);
            this.del_label.TabIndex = 18;
            this.del_label.Text = "Удаление элементов";
            // 
            // rowsColumns
            // 
            this.rowsColumns.Controls.Add(this.columns_button);
            this.rowsColumns.Controls.Add(this.rows_button);
            this.rowsColumns.Location = new System.Drawing.Point(15, 278);
            this.rowsColumns.Name = "rowsColumns";
            this.rowsColumns.Size = new System.Drawing.Size(200, 30);
            this.rowsColumns.TabIndex = 19;
            this.rowsColumns.TabStop = false;
            // 
            // columns_button
            // 
            this.columns_button.AutoSize = true;
            this.columns_button.Location = new System.Drawing.Point(88, 9);
            this.columns_button.Name = "columns_button";
            this.columns_button.Size = new System.Drawing.Size(69, 17);
            this.columns_button.TabIndex = 1;
            this.columns_button.Text = "Столбцы";
            this.columns_button.UseVisualStyleBackColor = true;
            // 
            // rows_button
            // 
            this.rows_button.AutoSize = true;
            this.rows_button.Checked = true;
            this.rows_button.Location = new System.Drawing.Point(12, 9);
            this.rows_button.Name = "rows_button";
            this.rows_button.Size = new System.Drawing.Size(61, 17);
            this.rows_button.TabIndex = 0;
            this.rows_button.TabStop = true;
            this.rows_button.Text = "Строки";
            this.rows_button.UseVisualStyleBackColor = true;
            // 
            // pos1_label
            // 
            this.pos1_label.AutoSize = true;
            this.pos1_label.Location = new System.Drawing.Point(15, 311);
            this.pos1_label.Name = "pos1_label";
            this.pos1_label.Size = new System.Drawing.Size(51, 13);
            this.pos1_label.TabIndex = 20;
            this.pos1_label.Text = "Позиция";
            // 
            // pos1_tb
            // 
            this.pos1_tb.Location = new System.Drawing.Point(82, 311);
            this.pos1_tb.Name = "pos1_tb";
            this.pos1_tb.Size = new System.Drawing.Size(29, 20);
            this.pos1_tb.TabIndex = 21;
            this.pos1_tb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.pos1_tb_KeyPress);
            // 
            // pos2_tb
            // 
            this.pos2_tb.Location = new System.Drawing.Point(185, 311);
            this.pos2_tb.Name = "pos2_tb";
            this.pos2_tb.Size = new System.Drawing.Size(29, 20);
            this.pos2_tb.TabIndex = 23;
            this.pos2_tb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.pos2_tb_KeyPress);
            // 
            // pos2_label
            // 
            this.pos2_label.AutoSize = true;
            this.pos2_label.Location = new System.Drawing.Point(127, 311);
            this.pos2_label.Name = "pos2_label";
            this.pos2_label.Size = new System.Drawing.Size(57, 13);
            this.pos2_label.TabIndex = 22;
            this.pos2_label.Text = "Конечный";
            // 
            // del_button
            // 
            this.del_button.Location = new System.Drawing.Point(140, 338);
            this.del_button.Name = "del_button";
            this.del_button.Size = new System.Drawing.Size(75, 23);
            this.del_button.TabIndex = 24;
            this.del_button.Text = "Удалить";
            this.del_button.UseVisualStyleBackColor = true;
            this.del_button.Click += new System.EventHandler(this.del_button_Click);
            // 
            // torn_add_row
            // 
            this.torn_add_row.Location = new System.Drawing.Point(156, 12);
            this.torn_add_row.Name = "torn_add_row";
            this.torn_add_row.Size = new System.Drawing.Size(227, 23);
            this.torn_add_row.TabIndex = 25;
            this.torn_add_row.Text = "Добавить строку в начало";
            this.torn_add_row.UseVisualStyleBackColor = true;
            this.torn_add_row.Click += new System.EventHandler(this.torn_add_row_Click);
            // 
            // torn_del_row
            // 
            this.torn_del_row.Location = new System.Drawing.Point(156, 41);
            this.torn_del_row.Name = "torn_del_row";
            this.torn_del_row.Size = new System.Drawing.Size(227, 23);
            this.torn_del_row.TabIndex = 26;
            this.torn_del_row.Text = "Удалить строку из конца";
            this.torn_del_row.UseVisualStyleBackColor = true;
            this.torn_del_row.Click += new System.EventHandler(this.torn_del_row_Click);
            // 
            // torn_add_num
            // 
            this.torn_add_num.Location = new System.Drawing.Point(156, 71);
            this.torn_add_num.Name = "torn_add_num";
            this.torn_add_num.Size = new System.Drawing.Size(174, 23);
            this.torn_add_num.TabIndex = 27;
            this.torn_add_num.Text = "Добавить строку под номером";
            this.torn_add_num.UseVisualStyleBackColor = true;
            this.torn_add_num.Click += new System.EventHandler(this.torn_add_num_Click);
            // 
            // torn_pos
            // 
            this.torn_pos.Location = new System.Drawing.Point(337, 71);
            this.torn_pos.Name = "torn_pos";
            this.torn_pos.Size = new System.Drawing.Size(46, 20);
            this.torn_pos.TabIndex = 28;
            this.torn_pos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(227, 157);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(75, 23);
            this.save.TabIndex = 29;
            this.save.Text = "Сохранить";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.Save_Click);
            // 
            // load
            // 
            this.load.Location = new System.Drawing.Point(308, 157);
            this.load.Name = "load";
            this.load.Size = new System.Drawing.Size(75, 23);
            this.load.TabIndex = 30;
            this.load.Text = "Загрузить";
            this.load.UseVisualStyleBackColor = true;
            this.load.Click += new System.EventHandler(this.Load_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.load);
            this.Controls.Add(this.save);
            this.Controls.Add(this.torn_pos);
            this.Controls.Add(this.torn_add_num);
            this.Controls.Add(this.torn_del_row);
            this.Controls.Add(this.torn_add_row);
            this.Controls.Add(this.del_button);
            this.Controls.Add(this.pos2_tb);
            this.Controls.Add(this.pos2_label);
            this.Controls.Add(this.pos1_tb);
            this.Controls.Add(this.pos1_label);
            this.Controls.Add(this.rowsColumns);
            this.Controls.Add(this.del_label);
            this.Controls.Add(this.oneMany);
            this.Controls.Add(this.add_elms);
            this.Controls.Add(this.to_end);
            this.Controls.Add(this.to_begin);
            this.Controls.Add(this.inp_label);
            this.Controls.Add(this.input_tb);
            this.Controls.Add(this.autoComplete);
            this.Controls.Add(this.msg_label);
            this.Controls.Add(this.size2_label);
            this.Controls.Add(this.size2_tb);
            this.Controls.Add(this.size1_label);
            this.Controls.Add(this.size1_tb);
            this.Controls.Add(this.create);
            this.Controls.Add(this.output_tb);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.arrayType);
            this.Name = "Form1";
            this.Text = "Lab7";
            this.oneMany.ResumeLayout(false);
            this.oneMany.PerformLayout();
            this.rowsColumns.ResumeLayout(false);
            this.rowsColumns.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox arrayType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox output_tb;
        private System.Windows.Forms.Button create;
        private System.Windows.Forms.TextBox size1_tb;
        private System.Windows.Forms.Label size1_label;
        private System.Windows.Forms.Label size2_label;
        private System.Windows.Forms.TextBox size2_tb;
        private System.Windows.Forms.Label msg_label;
        private System.Windows.Forms.CheckBox autoComplete;
        private System.Windows.Forms.RichTextBox input_tb;
        private System.Windows.Forms.Label inp_label;
        private System.Windows.Forms.RadioButton to_begin;
        private System.Windows.Forms.RadioButton to_end;
        private System.Windows.Forms.Button add_elms;
        private System.Windows.Forms.RadioButton del_many;
        private System.Windows.Forms.RadioButton del_one;
        private System.Windows.Forms.GroupBox oneMany;
        private System.Windows.Forms.Label del_label;
        private System.Windows.Forms.GroupBox rowsColumns;
        private System.Windows.Forms.RadioButton columns_button;
        private System.Windows.Forms.RadioButton rows_button;
        private System.Windows.Forms.Label pos1_label;
        private System.Windows.Forms.TextBox pos1_tb;
        private System.Windows.Forms.TextBox pos2_tb;
        private System.Windows.Forms.Label pos2_label;
        private System.Windows.Forms.Button del_button;
        private System.Windows.Forms.Button torn_add_row;
        private System.Windows.Forms.Button torn_del_row;
        private System.Windows.Forms.Button torn_add_num;
        private System.Windows.Forms.TextBox torn_pos;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Button load;
    }
}

