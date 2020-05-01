namespace Lab11_2
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
            this.update_cloned_collection = new System.Windows.Forms.Button();
            this.collection_listbox = new System.Windows.Forms.ListBox();
            this.delete_button = new System.Windows.Forms.Button();
            this.clone_button = new System.Windows.Forms.Button();
            this.add_button = new System.Windows.Forms.Button();
            this.name_tb = new System.Windows.Forms.TextBox();
            this.age_tb = new System.Windows.Forms.TextBox();
            this.wing_width_tb = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.random_add_tb = new System.Windows.Forms.TextBox();
            this.random_add = new System.Windows.Forms.Button();
            this.key_tb = new System.Windows.Forms.TextBox();
            this.key_label = new System.Windows.Forms.Label();
            this.wing_width_label = new System.Windows.Forms.Label();
            this.age_label = new System.Windows.Forms.Label();
            this.name_label = new System.Windows.Forms.Label();
            this.add_animal_rb = new System.Windows.Forms.RadioButton();
            this.add_mammal_rb = new System.Windows.Forms.RadioButton();
            this.add_atipdactyl_rb = new System.Windows.Forms.RadioButton();
            this.add_bird_rb = new System.Windows.Forms.RadioButton();
            this.error_label = new System.Windows.Forms.Label();
            this.cloned_collection_listbox = new System.Windows.Forms.ListBox();
            this.delete_cloned_button = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.sorted_dict_rb = new System.Windows.Forms.RadioButton();
            this.sorted_list_rb = new System.Windows.Forms.RadioButton();
            this.collection_1_1 = new System.Windows.Forms.ListBox();
            this.collection_1_2 = new System.Windows.Forms.ListBox();
            this.collection_2_1 = new System.Windows.Forms.ListBox();
            this.collection_2_2 = new System.Windows.Forms.ListBox();
            this.test_random_add_tb = new System.Windows.Forms.TextBox();
            this.test_random_add_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.test_name_tb = new System.Windows.Forms.TextBox();
            this.test_add_button = new System.Windows.Forms.Button();
            this.test_wingwidth_tb = new System.Windows.Forms.TextBox();
            this.test_age_tb = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.test_delete_button = new System.Windows.Forms.Button();
            this.speed_test_button = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // update_cloned_collection
            // 
            this.update_cloned_collection.Location = new System.Drawing.Point(416, 413);
            this.update_cloned_collection.Name = "update_cloned_collection";
            this.update_cloned_collection.Size = new System.Drawing.Size(75, 23);
            this.update_cloned_collection.TabIndex = 0;
            this.update_cloned_collection.Text = "Обновить";
            this.update_cloned_collection.UseVisualStyleBackColor = true;
            this.update_cloned_collection.Click += new System.EventHandler(this.update_cloned_collection_Click);
            // 
            // collection_listbox
            // 
            this.collection_listbox.FormattingEnabled = true;
            this.collection_listbox.Location = new System.Drawing.Point(13, 13);
            this.collection_listbox.Name = "collection_listbox";
            this.collection_listbox.Size = new System.Drawing.Size(120, 394);
            this.collection_listbox.TabIndex = 2;
            this.collection_listbox.SelectedIndexChanged += new System.EventHandler(this.collection_listbox_SelectedIndexChanged);
            // 
            // delete_button
            // 
            this.delete_button.Location = new System.Drawing.Point(12, 415);
            this.delete_button.Name = "delete_button";
            this.delete_button.Size = new System.Drawing.Size(75, 23);
            this.delete_button.TabIndex = 3;
            this.delete_button.Text = "Удалить";
            this.delete_button.UseVisualStyleBackColor = true;
            this.delete_button.Click += new System.EventHandler(this.delete_button_Click);
            // 
            // clone_button
            // 
            this.clone_button.Location = new System.Drawing.Point(329, 413);
            this.clone_button.Name = "clone_button";
            this.clone_button.Size = new System.Drawing.Size(81, 23);
            this.clone_button.TabIndex = 4;
            this.clone_button.Text = "Клонировать";
            this.clone_button.UseVisualStyleBackColor = true;
            this.clone_button.Click += new System.EventHandler(this.clone_button_Click);
            // 
            // add_button
            // 
            this.add_button.Location = new System.Drawing.Point(6, 193);
            this.add_button.Name = "add_button";
            this.add_button.Size = new System.Drawing.Size(75, 23);
            this.add_button.TabIndex = 5;
            this.add_button.Text = "Добавить";
            this.add_button.UseVisualStyleBackColor = true;
            this.add_button.Click += new System.EventHandler(this.add_button_Click);
            // 
            // name_tb
            // 
            this.name_tb.Location = new System.Drawing.Point(6, 26);
            this.name_tb.Name = "name_tb";
            this.name_tb.Size = new System.Drawing.Size(100, 20);
            this.name_tb.TabIndex = 6;
            // 
            // age_tb
            // 
            this.age_tb.Location = new System.Drawing.Point(6, 65);
            this.age_tb.Name = "age_tb";
            this.age_tb.Size = new System.Drawing.Size(100, 20);
            this.age_tb.TabIndex = 7;
            this.age_tb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.age_tb_KeyPress);
            // 
            // wing_width_tb
            // 
            this.wing_width_tb.Location = new System.Drawing.Point(6, 106);
            this.wing_width_tb.Name = "wing_width_tb";
            this.wing_width_tb.Size = new System.Drawing.Size(100, 20);
            this.wing_width_tb.TabIndex = 8;
            this.wing_width_tb.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.random_add_tb);
            this.groupBox1.Controls.Add(this.random_add);
            this.groupBox1.Controls.Add(this.key_tb);
            this.groupBox1.Controls.Add(this.key_label);
            this.groupBox1.Controls.Add(this.wing_width_label);
            this.groupBox1.Controls.Add(this.age_label);
            this.groupBox1.Controls.Add(this.name_label);
            this.groupBox1.Controls.Add(this.add_animal_rb);
            this.groupBox1.Controls.Add(this.add_mammal_rb);
            this.groupBox1.Controls.Add(this.add_atipdactyl_rb);
            this.groupBox1.Controls.Add(this.add_bird_rb);
            this.groupBox1.Controls.Add(this.name_tb);
            this.groupBox1.Controls.Add(this.add_button);
            this.groupBox1.Controls.Add(this.wing_width_tb);
            this.groupBox1.Controls.Add(this.age_tb);
            this.groupBox1.Location = new System.Drawing.Point(139, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 400);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 338);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(93, 23);
            this.button2.TabIndex = 21;
            this.button2.Text = "Очистить поля";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(117, 163);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 20;
            this.button1.Text = "Поиск";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // random_add_tb
            // 
            this.random_add_tb.Location = new System.Drawing.Point(86, 287);
            this.random_add_tb.Name = "random_add_tb";
            this.random_add_tb.Size = new System.Drawing.Size(56, 20);
            this.random_add_tb.TabIndex = 19;
            this.random_add_tb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.random_add_tb_KeyPress);
            // 
            // random_add
            // 
            this.random_add.Location = new System.Drawing.Point(6, 285);
            this.random_add.Name = "random_add";
            this.random_add.Size = new System.Drawing.Size(75, 23);
            this.random_add.TabIndex = 18;
            this.random_add.Text = "Рандом";
            this.random_add.UseVisualStyleBackColor = true;
            this.random_add.Click += new System.EventHandler(this.random_add_Click);
            // 
            // key_tb
            // 
            this.key_tb.Location = new System.Drawing.Point(6, 163);
            this.key_tb.Name = "key_tb";
            this.key_tb.Size = new System.Drawing.Size(100, 20);
            this.key_tb.TabIndex = 17;
            this.key_tb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.key_tb_KeyPress);
            // 
            // key_label
            // 
            this.key_label.AutoSize = true;
            this.key_label.Location = new System.Drawing.Point(6, 147);
            this.key_label.Name = "key_label";
            this.key_label.Size = new System.Drawing.Size(93, 13);
            this.key_label.TabIndex = 16;
            this.key_label.Text = "Серийный номер";
            // 
            // wing_width_label
            // 
            this.wing_width_label.AutoSize = true;
            this.wing_width_label.Location = new System.Drawing.Point(7, 90);
            this.wing_width_label.Name = "wing_width_label";
            this.wing_width_label.Size = new System.Drawing.Size(95, 13);
            this.wing_width_label.TabIndex = 15;
            this.wing_width_label.Text = "Размах крыльев:";
            this.wing_width_label.Visible = false;
            // 
            // age_label
            // 
            this.age_label.AutoSize = true;
            this.age_label.Location = new System.Drawing.Point(7, 49);
            this.age_label.Name = "age_label";
            this.age_label.Size = new System.Drawing.Size(52, 13);
            this.age_label.TabIndex = 14;
            this.age_label.Text = "Возраст:";
            // 
            // name_label
            // 
            this.name_label.AutoSize = true;
            this.name_label.Location = new System.Drawing.Point(7, 10);
            this.name_label.Name = "name_label";
            this.name_label.Size = new System.Drawing.Size(32, 13);
            this.name_label.TabIndex = 13;
            this.name_label.Text = "Имя:";
            // 
            // add_animal_rb
            // 
            this.add_animal_rb.AutoSize = true;
            this.add_animal_rb.Checked = true;
            this.add_animal_rb.Location = new System.Drawing.Point(86, 193);
            this.add_animal_rb.Name = "add_animal_rb";
            this.add_animal_rb.Size = new System.Drawing.Size(77, 17);
            this.add_animal_rb.TabIndex = 12;
            this.add_animal_rb.TabStop = true;
            this.add_animal_rb.Text = "Животное";
            this.add_animal_rb.UseVisualStyleBackColor = true;
            // 
            // add_mammal_rb
            // 
            this.add_mammal_rb.AutoSize = true;
            this.add_mammal_rb.Location = new System.Drawing.Point(86, 216);
            this.add_mammal_rb.Name = "add_mammal_rb";
            this.add_mammal_rb.Size = new System.Drawing.Size(110, 17);
            this.add_mammal_rb.TabIndex = 11;
            this.add_mammal_rb.Text = "Млекопитающее";
            this.add_mammal_rb.UseVisualStyleBackColor = true;
            // 
            // add_atipdactyl_rb
            // 
            this.add_atipdactyl_rb.AutoSize = true;
            this.add_atipdactyl_rb.Location = new System.Drawing.Point(86, 239);
            this.add_atipdactyl_rb.Name = "add_atipdactyl_rb";
            this.add_atipdactyl_rb.Size = new System.Drawing.Size(106, 17);
            this.add_atipdactyl_rb.TabIndex = 10;
            this.add_atipdactyl_rb.Text = "Парнокопытное";
            this.add_atipdactyl_rb.UseVisualStyleBackColor = true;
            // 
            // add_bird_rb
            // 
            this.add_bird_rb.AutoSize = true;
            this.add_bird_rb.Location = new System.Drawing.Point(86, 262);
            this.add_bird_rb.Name = "add_bird_rb";
            this.add_bird_rb.Size = new System.Drawing.Size(56, 17);
            this.add_bird_rb.TabIndex = 9;
            this.add_bird_rb.Text = "Птица";
            this.add_bird_rb.UseVisualStyleBackColor = true;
            this.add_bird_rb.CheckedChanged += new System.EventHandler(this.add_bird_rb_CheckedChanged);
            // 
            // error_label
            // 
            this.error_label.AutoSize = true;
            this.error_label.Location = new System.Drawing.Point(12, 452);
            this.error_label.Name = "error_label";
            this.error_label.Size = new System.Drawing.Size(47, 13);
            this.error_label.TabIndex = 10;
            this.error_label.Text = "Ошибка";
            this.error_label.Visible = false;
            // 
            // cloned_collection_listbox
            // 
            this.cloned_collection_listbox.FormattingEnabled = true;
            this.cloned_collection_listbox.Location = new System.Drawing.Point(347, 13);
            this.cloned_collection_listbox.Name = "cloned_collection_listbox";
            this.cloned_collection_listbox.Size = new System.Drawing.Size(120, 394);
            this.cloned_collection_listbox.TabIndex = 11;
            // 
            // delete_cloned_button
            // 
            this.delete_cloned_button.Location = new System.Drawing.Point(329, 442);
            this.delete_cloned_button.Name = "delete_cloned_button";
            this.delete_cloned_button.Size = new System.Drawing.Size(75, 23);
            this.delete_cloned_button.TabIndex = 12;
            this.delete_cloned_button.Text = "Удалить";
            this.delete_cloned_button.UseVisualStyleBackColor = true;
            this.delete_cloned_button.Click += new System.EventHandler(this.delete_cloned_button_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.sorted_dict_rb);
            this.groupBox2.Controls.Add(this.sorted_list_rb);
            this.groupBox2.Location = new System.Drawing.Point(93, 409);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 38);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            // 
            // sorted_dict_rb
            // 
            this.sorted_dict_rb.AutoSize = true;
            this.sorted_dict_rb.Location = new System.Drawing.Point(85, 14);
            this.sorted_dict_rb.Name = "sorted_dict_rb";
            this.sorted_dict_rb.Size = new System.Drawing.Size(103, 17);
            this.sorted_dict_rb.TabIndex = 1;
            this.sorted_dict_rb.Text = "SortedDictionary";
            this.sorted_dict_rb.UseVisualStyleBackColor = true;
            this.sorted_dict_rb.CheckedChanged += new System.EventHandler(this.sorted_dict_rb_CheckedChanged);
            // 
            // sorted_list_rb
            // 
            this.sorted_list_rb.AutoSize = true;
            this.sorted_list_rb.Checked = true;
            this.sorted_list_rb.Location = new System.Drawing.Point(6, 14);
            this.sorted_list_rb.Name = "sorted_list_rb";
            this.sorted_list_rb.Size = new System.Drawing.Size(72, 17);
            this.sorted_list_rb.TabIndex = 0;
            this.sorted_list_rb.TabStop = true;
            this.sorted_list_rb.Text = "SortedList";
            this.sorted_list_rb.UseVisualStyleBackColor = true;
            this.sorted_list_rb.CheckedChanged += new System.EventHandler(this.sorted_list_rb_CheckedChanged);
            // 
            // collection_1_1
            // 
            this.collection_1_1.FormattingEnabled = true;
            this.collection_1_1.Location = new System.Drawing.Point(629, 39);
            this.collection_1_1.Name = "collection_1_1";
            this.collection_1_1.Size = new System.Drawing.Size(120, 368);
            this.collection_1_1.TabIndex = 14;
            this.collection_1_1.SelectedIndexChanged += new System.EventHandler(this.collection_1_1_SelectedIndexChanged);
            // 
            // collection_1_2
            // 
            this.collection_1_2.FormattingEnabled = true;
            this.collection_1_2.Location = new System.Drawing.Point(765, 39);
            this.collection_1_2.Name = "collection_1_2";
            this.collection_1_2.Size = new System.Drawing.Size(120, 368);
            this.collection_1_2.TabIndex = 15;
            this.collection_1_2.SelectedIndexChanged += new System.EventHandler(this.collection_1_2_SelectedIndexChanged);
            // 
            // collection_2_1
            // 
            this.collection_2_1.FormattingEnabled = true;
            this.collection_2_1.Location = new System.Drawing.Point(903, 39);
            this.collection_2_1.Name = "collection_2_1";
            this.collection_2_1.Size = new System.Drawing.Size(120, 368);
            this.collection_2_1.TabIndex = 16;
            this.collection_2_1.SelectedIndexChanged += new System.EventHandler(this.collection_2_1_SelectedIndexChanged);
            // 
            // collection_2_2
            // 
            this.collection_2_2.FormattingEnabled = true;
            this.collection_2_2.Location = new System.Drawing.Point(1043, 39);
            this.collection_2_2.Name = "collection_2_2";
            this.collection_2_2.Size = new System.Drawing.Size(211, 368);
            this.collection_2_2.TabIndex = 17;
            this.collection_2_2.SelectedIndexChanged += new System.EventHandler(this.collection_2_2_SelectedIndexChanged);
            // 
            // test_random_add_tb
            // 
            this.test_random_add_tb.Location = new System.Drawing.Point(548, 223);
            this.test_random_add_tb.Name = "test_random_add_tb";
            this.test_random_add_tb.Size = new System.Drawing.Size(75, 20);
            this.test_random_add_tb.TabIndex = 28;
            this.test_random_add_tb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.test_random_add_tb_KeyPress);
            // 
            // test_random_add_button
            // 
            this.test_random_add_button.Location = new System.Drawing.Point(548, 194);
            this.test_random_add_button.Name = "test_random_add_button";
            this.test_random_add_button.Size = new System.Drawing.Size(75, 23);
            this.test_random_add_button.TabIndex = 27;
            this.test_random_add_button.Text = "Рандом";
            this.test_random_add_button.UseVisualStyleBackColor = true;
            this.test_random_add_button.Click += new System.EventHandler(this.random_add_button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(524, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Размах крыльев:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(524, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Возраст:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(524, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Имя:";
            // 
            // test_name_tb
            // 
            this.test_name_tb.Location = new System.Drawing.Point(523, 33);
            this.test_name_tb.Name = "test_name_tb";
            this.test_name_tb.Size = new System.Drawing.Size(100, 20);
            this.test_name_tb.TabIndex = 21;
            // 
            // test_add_button
            // 
            this.test_add_button.Location = new System.Drawing.Point(548, 144);
            this.test_add_button.Name = "test_add_button";
            this.test_add_button.Size = new System.Drawing.Size(75, 23);
            this.test_add_button.TabIndex = 20;
            this.test_add_button.Text = "Добавить";
            this.test_add_button.UseVisualStyleBackColor = true;
            this.test_add_button.Click += new System.EventHandler(this.test_add_button_Click);
            // 
            // test_wingwidth_tb
            // 
            this.test_wingwidth_tb.Location = new System.Drawing.Point(523, 113);
            this.test_wingwidth_tb.Name = "test_wingwidth_tb";
            this.test_wingwidth_tb.Size = new System.Drawing.Size(100, 20);
            this.test_wingwidth_tb.TabIndex = 23;
            this.test_wingwidth_tb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.test_wingwidth_tb_KeyPress);
            // 
            // test_age_tb
            // 
            this.test_age_tb.Location = new System.Drawing.Point(523, 72);
            this.test_age_tb.Name = "test_age_tb";
            this.test_age_tb.Size = new System.Drawing.Size(100, 20);
            this.test_age_tb.TabIndex = 22;
            this.test_age_tb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.test_age_tb_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(626, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 29;
            this.label4.Text = "List<Animal>";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(762, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 30;
            this.label5.Text = "List<string>";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(900, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 13);
            this.label6.TabIndex = 31;
            this.label6.Text = "Dictionary<Animal, Bird>";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1040, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 13);
            this.label7.TabIndex = 32;
            this.label7.Text = "Dictionary<string, Bird>";
            // 
            // test_delete_button
            // 
            this.test_delete_button.Location = new System.Drawing.Point(548, 291);
            this.test_delete_button.Name = "test_delete_button";
            this.test_delete_button.Size = new System.Drawing.Size(75, 23);
            this.test_delete_button.TabIndex = 33;
            this.test_delete_button.Text = "Удалить";
            this.test_delete_button.UseVisualStyleBackColor = true;
            this.test_delete_button.Click += new System.EventHandler(this.test_delete_button_Click);
            // 
            // speed_test_button
            // 
            this.speed_test_button.Location = new System.Drawing.Point(861, 486);
            this.speed_test_button.Name = "speed_test_button";
            this.speed_test_button.Size = new System.Drawing.Size(75, 23);
            this.speed_test_button.TabIndex = 34;
            this.speed_test_button.Text = "Пуск";
            this.speed_test_button.UseVisualStyleBackColor = true;
            this.speed_test_button.Click += new System.EventHandler(this.speed_test_button_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(833, 470);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(137, 13);
            this.label8.TabIndex = 35;
            this.label8.Text = "Рассчет времени поиска:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(588, 409);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 13);
            this.label9.TabIndex = 36;
            this.label9.Text = "Первый:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(572, 429);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 13);
            this.label10.TabIndex = 37;
            this.label10.Text = "Последний:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(555, 447);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(83, 13);
            this.label11.TabIndex = 38;
            this.label11.Text = "Вне коллекции";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(683, 409);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(25, 13);
            this.label12.TabIndex = 39;
            this.label12.Text = "0 с.";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(683, 428);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(25, 13);
            this.label13.TabIndex = 40;
            this.label13.Text = "0 с.";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(683, 447);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(25, 13);
            this.label14.TabIndex = 41;
            this.label14.Text = "0 с.";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(819, 409);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(25, 13);
            this.label15.TabIndex = 42;
            this.label15.Text = "0 с.";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(819, 428);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(25, 13);
            this.label16.TabIndex = 43;
            this.label16.Text = "0 с.";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(820, 447);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(25, 13);
            this.label17.TabIndex = 44;
            this.label17.Text = "0 с.";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(957, 409);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(25, 13);
            this.label18.TabIndex = 45;
            this.label18.Text = "0 с.";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(957, 428);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(25, 13);
            this.label19.TabIndex = 46;
            this.label19.Text = "0 с.";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(958, 447);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(25, 13);
            this.label20.TabIndex = 47;
            this.label20.Text = "0 с.";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(1188, 413);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(25, 13);
            this.label21.TabIndex = 48;
            this.label21.Text = "0 с.";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(1188, 430);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(25, 13);
            this.label22.TabIndex = 49;
            this.label22.Text = "0 с.";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(1189, 447);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(25, 13);
            this.label23.TabIndex = 50;
            this.label23.Text = "0 с.";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 518);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.speed_test_button);
            this.Controls.Add(this.test_delete_button);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.test_random_add_tb);
            this.Controls.Add(this.test_random_add_button);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.test_name_tb);
            this.Controls.Add(this.test_add_button);
            this.Controls.Add(this.test_wingwidth_tb);
            this.Controls.Add(this.test_age_tb);
            this.Controls.Add(this.collection_2_2);
            this.Controls.Add(this.collection_2_1);
            this.Controls.Add(this.collection_1_2);
            this.Controls.Add(this.collection_1_1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.delete_cloned_button);
            this.Controls.Add(this.cloned_collection_listbox);
            this.Controls.Add(this.error_label);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.clone_button);
            this.Controls.Add(this.delete_button);
            this.Controls.Add(this.collection_listbox);
            this.Controls.Add(this.update_cloned_collection);
            this.Name = "Form1";
            this.Text = "Lab11_2";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button update_cloned_collection;
        private System.Windows.Forms.ListBox collection_listbox;
        private System.Windows.Forms.Button delete_button;
        private System.Windows.Forms.Button clone_button;
        private System.Windows.Forms.Button add_button;
        private System.Windows.Forms.TextBox name_tb;
        private System.Windows.Forms.TextBox age_tb;
        private System.Windows.Forms.TextBox wing_width_tb;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label age_label;
        private System.Windows.Forms.Label name_label;
        private System.Windows.Forms.RadioButton add_animal_rb;
        private System.Windows.Forms.RadioButton add_mammal_rb;
        private System.Windows.Forms.RadioButton add_atipdactyl_rb;
        private System.Windows.Forms.RadioButton add_bird_rb;
        private System.Windows.Forms.Label wing_width_label;
        private System.Windows.Forms.TextBox key_tb;
        private System.Windows.Forms.Label key_label;
        private System.Windows.Forms.TextBox random_add_tb;
        private System.Windows.Forms.Button random_add;
        private System.Windows.Forms.Label error_label;
        private System.Windows.Forms.ListBox cloned_collection_listbox;
        private System.Windows.Forms.Button delete_cloned_button;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton sorted_dict_rb;
        private System.Windows.Forms.RadioButton sorted_list_rb;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox collection_1_1;
        private System.Windows.Forms.ListBox collection_1_2;
        private System.Windows.Forms.ListBox collection_2_1;
        private System.Windows.Forms.ListBox collection_2_2;
        private System.Windows.Forms.TextBox test_random_add_tb;
        private System.Windows.Forms.Button test_random_add_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox test_name_tb;
        private System.Windows.Forms.Button test_add_button;
        private System.Windows.Forms.TextBox test_wingwidth_tb;
        private System.Windows.Forms.TextBox test_age_tb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button test_delete_button;
        private System.Windows.Forms.Button speed_test_button;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
    }
}

