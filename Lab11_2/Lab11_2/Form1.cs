using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;


namespace Lab11_2
{
    public partial class Form1 : Form
    {
        SortedList<int, Lab10_2.Animal> sl = new SortedList<int, Lab10_2.Animal>();
        SortedList<int, Lab10_2.Animal> clone_sl = null;
        SortedDictionary<int, Lab10_2.Animal> sd = new SortedDictionary<int, Lab10_2.Animal>();
        SortedDictionary<int, Lab10_2.Animal> clone_sd = null;
        TestCollections tc = new TestCollections(0);
        public Form1()
        {
            InitializeComponent();
        }
        private Random rand = new Random();
        private void _KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')
            {
                FormInput(sender, e);
                // e.Handled = true;
            }
        }
        private void FormInput(object sender, KeyPressEventArgs e)
        {
            if (!(sender is TextBox)) return;
            TextBox tb = (TextBox)sender;

            if (!Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                //  tb.Text += e.KeyChar;
                //tb.Select(tb.SelectionStart + 1, 0);
            }
        }
        private void Action1()
        {

        }
        int GetKey(ListBox lb)
        {
            string[] tmp = lb.SelectedItem.ToString().Split(' ');
            return Int32.Parse(tmp[0]);
        }
        private void DeleteSD()
        {
            if (collection_listbox.SelectedIndex == -1) { ShowError("Выберите запись для удаления"); return; } else UnShowError();
            sd.Remove(GetKey(collection_listbox));
            UpdateListbox(collection_listbox, sd);
        }
        private void Delete()
        {
            if (collection_listbox.SelectedIndex == -1) { ShowError("Выберите запись для удаления"); return; } else UnShowError();
            sl.RemoveAt(collection_listbox.SelectedIndex);
            UpdateListbox(collection_listbox, sl);
        }
        private void DeleteCloned()
        {
            if (cloned_collection_listbox.SelectedIndex == -1) { ShowError("Выберите запись для удаления"); return; } else UnShowError();
            if (sorted_list_rb.Checked)
            {
                clone_sl.RemoveAt(cloned_collection_listbox.SelectedIndex);
                UpdateListbox(cloned_collection_listbox, clone_sl);
            }
            else
            {
                clone_sd.Remove(GetKey(cloned_collection_listbox));
                UpdateListbox(cloned_collection_listbox, clone_sd);
            }
        }

        private void FillRandom(SortedDictionary<int, Lab10_2.Animal> list, int n)
        {
            list.Clear();
            int tmp;
            bool f = true;
            Lab10_2.Animal an;
            for (int i = 0; i < n; i++)
            {
                tmp = rand.Next(1, 999);
                an = RandomAnimal();
                do
                {
                    try
                    {
                        list.Add(tmp, an);
                        f = true;
                    }
                    catch (System.ArgumentException) { tmp++; f = false; }
                } while (!f);
            }
        }
        private void FillRandom(SortedList<int, Lab10_2.Animal> list, int n)
        {
            list.Clear();
            int tmp;
            bool f = true;
            Lab10_2.Animal an;
            for (int i = 0; i < n; i++)
            {
                tmp = rand.Next(1, 999);
                an = RandomAnimal();
                do
                {
                    try
                    {
                        list.Add(tmp, an);
                        f = true;
                    }
                    catch (System.ArgumentException) { tmp++; f = false; }
                } while (!f);
            }
        }
        private void ShowAnimal(Lab10_2.Animal an)
        {
            if (an is Lab10_2.Artiodactyl)
                add_atipdactyl_rb.Checked = true;
            else if (an is Lab10_2.Mammal)
                add_mammal_rb.Checked = true;
            else if (an is Lab10_2.Animal)
                add_animal_rb.Checked = true;
            if (an is Lab10_2.Bird)
            {
                Lab10_2.Bird p = an as Lab10_2.Bird;
                this.wing_width_tb.Text = p.wingsWidth.ToString();
                wing_width_tb.Visible = true;
                wing_width_label.Visible = true;
                add_bird_rb.Checked = true;
            }
            else
            {
                wing_width_tb.Visible = false;
                wing_width_label.Visible = false;
            }
            name_tb.Text = an.Name;
            age_tb.Text = an.Age.ToString();
        }
        private void TestShowAnimal(Lab10_2.Bird b)
        {
            test_name_tb.Text = b.Name;
            test_age_tb.Text = b.Age.ToString();
            test_wingwidth_tb.Text = b.wingsWidth.ToString();
        }
        private void UpdateListbox(ListBox lb, SortedList<int, Lab10_2.Animal> list)
        {
            lb.Items.Clear();
            if (list == null) return;
            //TODO: Тут перебор через foreach
            foreach (var i in list)
            {
                lb.Items.Add(i.Key + " " + i.Value.Name);
            }
        }
        private void UpdateListbox(ListBox lb, SortedDictionary<int, Lab10_2.Animal> list)
        {
            lb.Items.Clear();
            if (list == null) return;
            //TODO: Тут перебор через foreach
            foreach (var i in list)
            {
                lb.Items.Add(i.Key + " " + i.Value.Name);
            }
        }
        private void FillRandom()
        {
            if (random_add_tb.Text == "") { ShowError("Введите количество"); return; } else UnShowError();

            FillRandom(sl, Int32.Parse(random_add_tb.Text));
            UpdateListbox(collection_listbox, sl);
        }
        private void FillRandomSD()
        {
            if (random_add_tb.Text == "") { ShowError("Введите количество"); return; } else UnShowError();

            FillRandom(sd, Int32.Parse(random_add_tb.Text));
            UpdateListbox(collection_listbox, sd);
        }
        private void ShowError(string msg)
        {
            error_label.Text = msg;
            error_label.Visible = true;
        }
        private void UnShowError()
        {
            error_label.Visible = false;
        }
        Lab10_2.Bird RandomBird()
        {
            Lab10_2.Bird an = null;
            string str;
            string[] names = null;
            using (var fin = new StreamReader("names.txt", Encoding.Default))
            {
                str = fin.ReadLine();
                var re = new Regex(" ");
                str = re.Replace(str, "");
                names = str.Split(',');
            }
            int n = rand.Next(0, 4);
            an = new Lab10_2.Bird(names[rand.Next(0, names.Length - 1)], rand.Next(1, 500), rand.Next(10, 250));
            return an;
        }

        Lab10_2.Animal RandomAnimal()
        {
            Lab10_2.Animal an = null;

            string str;
            string[] names = null;
            using (var fin = new StreamReader("names.txt", Encoding.Default))
            {
                str = fin.ReadLine();
                var re = new Regex(" ");
                // str.Remove(str.IndexOf(' '));
                str = re.Replace(str, "");
                names = str.Split(',');
            }
            int n = rand.Next(0, 4);
            switch (n)
            {
                case 0:
                    an = new Lab10_2.Animal(names[rand.Next(0, names.Length - 1)], rand.Next(1, 30));
                    break;
                case 1:
                    an = new Lab10_2.Mammal(names[rand.Next(0, names.Length - 1)], rand.Next(1, 30));
                    break;
                case 2:
                    an = new Lab10_2.Artiodactyl(names[rand.Next(0, names.Length - 1)], rand.Next(1, 30));
                    break;
                case 3:
                    an = new Lab10_2.Bird(names[rand.Next(0, names.Length - 1)], rand.Next(1, 10), rand.Next(10, 250));
                    break;
            }
            return an;
        }
        private void AddAnimal()
        {
            if (FieldsIsEmpty()) { ShowError("Заполните поля"); return; } else UnShowError();

            Lab10_2.Animal an = null;
            if (add_animal_rb.Checked)
                an = new Lab10_2.Animal(name_tb.Text, Int32.Parse(age_tb.Text));
            else if (add_mammal_rb.Checked)
                an = new Lab10_2.Mammal(name_tb.Text, Int32.Parse(age_tb.Text));
            else if (add_atipdactyl_rb.Checked)
                an = new Lab10_2.Artiodactyl(name_tb.Text, Int32.Parse(age_tb.Text));
            else if (add_bird_rb.Checked)
                an = new Lab10_2.Bird(name_tb.Text, Int32.Parse(age_tb.Text), Int32.Parse(wing_width_tb.Text));
            try
            {
                if (sorted_list_rb.Checked)
                {
                    sl.Add(Int32.Parse(key_tb.Text), an);
                    UpdateListbox(collection_listbox, sl);
                }
                else
                {
                    sd.Add(Int32.Parse(key_tb.Text), an);
                    UpdateListbox(collection_listbox, sd);
                }
            }
            catch (System.ArgumentException)
            {
                ShowError("Такой серийный номер уже используется");
                return;
            }
        }

        private void TestAddAnimal()
        {
            if (TestFieldsIsEmpty()) { ShowError("Заполните поля"); return; } else UnShowError();

            Lab10_2.Bird b = new Lab10_2.Bird(test_name_tb.Text, Int32.Parse(test_age_tb.Text), Int32.Parse(test_wingwidth_tb.Text));
            try
            {
                tc.Add(b);
                TestUpdateLists();
                UnShowError();
            }
            catch (System.ArgumentException)
            {
                ShowError("Элемент с таким ключом уже добавлен");
            }

        }

        private bool FieldsIsEmpty()
        {
            if (add_bird_rb.Checked)
                return name_tb.Text == "" || key_tb.Text == "" || age_tb.Text == "" || wing_width_tb.Text == "";
            else
                return name_tb.Text == "" || key_tb.Text == "" || age_tb.Text == "";
        }
        private bool TestFieldsIsEmpty()
        {
            return test_name_tb.Text == "" || test_age_tb.Text == "" || test_wingwidth_tb.Text == "";
        }
        private void CloneCollection()
        {
            if (sorted_list_rb.Checked)
            {
                if (sl.Count == 0) { ShowError("Нечего клонировать"); return; } else UnShowError();

                clone_sl = new SortedList<int, Lab10_2.Animal>(sl);
                UpdateCloned();
            }
            else
            {
                if (sd.Count == 0) { ShowError("Нечего клонировать"); return; } else UnShowError();
                clone_sd = new SortedDictionary<int, Lab10_2.Animal>(sd);
                UpdateCloned();
            }
            //clone_sl = (ICloneable)sl.
        }
        private void UpdateCloned()
        {
            if (sorted_list_rb.Checked)
            {
                if (clone_sl == null) { cloned_collection_listbox.Items.Add("Пусто"); }
                UpdateListbox(cloned_collection_listbox, clone_sl);
            }
            else
            {
                if (clone_sd == null) { cloned_collection_listbox.Items.Add("Пусто"); }
                UpdateListbox(cloned_collection_listbox, clone_sd);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Action1();
        }

        private void ClearAll()
        {
            name_tb.Text = "";
            age_tb.Text = "";
            wing_width_tb.Text = "";
            error_label.Visible = false;
            cloned_collection_listbox.Items.Clear();
            collection_listbox.Items.Clear();
            sl.Clear();
            sd.Clear();
            if (clone_sl != null)
                clone_sl.Clear();
            if (clone_sd != null)
                clone_sd.Clear();
        }
        private void ClearFields()
        {
            name_tb.Text = "";
            age_tb.Text = "";
            wing_width_tb.Text = "";
            key_tb.Text = "";
        }
        private void add_bird_rb_CheckedChanged(object sender, EventArgs e)
        {
            wing_width_tb.Visible = add_bird_rb.Checked;
            wing_width_label.Visible = add_bird_rb.Checked;
        }
        private void key_tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            _KeyPress(sender, e);
        }

        private void age_tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            _KeyPress(sender, e);
        }

        private void collection_listbox_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (collection_listbox.SelectedIndex != -1)
            {
                if (sorted_list_rb.Checked)
                {
                    ShowAnimal(sl.Values[collection_listbox.SelectedIndex]);
                    key_tb.Text = sl.Keys[collection_listbox.SelectedIndex].ToString();
                }
                else
                {
                    // ClearFields();
                    int key = GetKey(collection_listbox);
                    ShowAnimal(sd[key]);
                    key_tb.Text = key.ToString();
                }
            }
        }
        private void Find()
        {
            if (key_tb.Text == "") { ShowError("Введите значение для поиска"); return; } else UnShowError();

            try
            {
                if (sorted_list_rb.Checked)
                    ShowAnimal(sl[Int32.Parse(key_tb.Text)]);
                else
                    ShowAnimal(sd[Int32.Parse(key_tb.Text)]);
            }
            catch (KeyNotFoundException)
            { ShowError("Элемент с данным номером не найден"); }
        }
        private void TestRandomFill()
        {
            if (test_random_add_tb.Text == "") { ShowError("Введите количество"); return; } else UnShowError();

            List<Lab10_2.Bird> ls = new List<Lab10_2.Bird>();
            for (int i = 0; i < Int32.Parse(test_random_add_tb.Text); i++)
                ls.Add(RandomBird());
            try
            {
                tc = new TestCollections(ls);
                UnShowError();
            }
            catch (/*System.OutOfMemoryException*/System.ArgumentException) { ShowError("Слишком много элементов. Возникают повторы "); tc = new TestCollections(0); }
            TestUpdateLists();

        }
        private void TestUpdateLists()
        {
            collection_1_1.Items.Clear();
            collection_1_2.Items.Clear();
            collection_2_1.Items.Clear();
            collection_2_2.Items.Clear();

            for (int i = 0; i < tc.collection_1_1.Count; i++)
            {
                collection_1_1.Items.Add(tc.collection_1_1[i].Name);
                collection_1_2.Items.Add(tc.collection_1_2[i]);
            }
            foreach (var i in tc.collection_2_1)
                collection_2_1.Items.Add(i.Key.Name + " " + i.Key.Age + " | " + i.Value.wingsWidth.ToString());
            foreach (var i in tc.collection_2_2)
                collection_2_2.Items.Add(i.Key + " | " + i.Value.Name + " " + i.Value.Age + " " + i.Value.wingsWidth.ToString());
        }

        private void TestDelete()
        {
            if (collection_1_1.SelectedIndex == -1) { ShowError("Выберите элемент для удаления"); return; } else UnShowError();

            tc.RemoveAt(collection_1_1.SelectedIndex);
            TestUpdateLists();
        }
        private void SpeedTest()
        {
            if (tc.collection_1_1.Count == 0) { ShowError("Коллекция пуста"); return; } else UnShowError();
            List<double> res = new List<double>();
            SpeedTest(tc.collection_1_1, res);
            label12.Text = res[0].ToString() + " мс.";
            label13.Text = res[1].ToString() + " мс.";
            label14.Text = res[2].ToString() + " мс.";
            SpeedTest(tc.collection_1_2, res);
            label15.Text = res[0].ToString() + " мс.";
            label16.Text = res[1].ToString() + " мс.";
            label17.Text = res[2].ToString() + " мс.";
            SpeedTest(tc.collection_2_1, res);
            label18.Text = res[0].ToString() + " мс.";
            label19.Text = res[1].ToString() + " мс.";
            label20.Text = res[2].ToString() + " мс.";
            SpeedTest(tc.collection_2_2, res);
            label21.Text = res[0].ToString() + " мс.";
            label22.Text = res[1].ToString() + " мс.";
            label23.Text = res[2].ToString() + " мс.";
        }
        private void SpeedTest(List<Lab10_2.Animal> list, List<double> res)
        {
            res.Clear();
            Lab10_2.Animal first = (Lab10_2.Animal)list[0].Clone();
            Lab10_2.Animal last = (Lab10_2.Animal)list[list.Count - 1].Clone();
            Lab10_2.Animal outCol = new Lab10_2.Animal("__", 0);
            res.Add(SpeedTest(list, first));
            res.Add(SpeedTest(list, last));
            res.Add(SpeedTest(list, outCol));
        }
        private double SpeedTest(List<Lab10_2.Animal> list, Lab10_2.Animal entry)
        {
            var startTime = System.Diagnostics.Stopwatch.StartNew();
            bool f = list.Contains(entry);
            startTime.Stop();
            var resTime = startTime.Elapsed;
            return resTime.TotalMilliseconds;
        }
        private void SpeedTest(List<string> list, List<double> res)
        {
            res.Clear();
            string first = (string)list[0].Clone();
            string last = (string)list[list.Count - 1].Clone();
            string outCol = "__-_-_";
            res.Add(SpeedTest(list, first));
            res.Add(SpeedTest(list, last));
            res.Add(SpeedTest(list, outCol));
        }
        private double SpeedTest(List<string> list, string entry)
        {
            var startTime = System.Diagnostics.Stopwatch.StartNew();
            bool f = list.Contains(entry);
            startTime.Stop();
            var resTime = startTime.Elapsed;
            return resTime.TotalMilliseconds;
        }
        private void SpeedTest(Dictionary<Lab10_2.Animal, Lab10_2.Bird> list, List<double> res)
        {
            res.Clear();
            Lab10_2.Animal first = (Lab10_2.Animal)list.First().Key.Clone();
            Lab10_2.Animal last = (Lab10_2.Animal)list.Last().Key.Clone();
            Lab10_2.Animal outCol = new Lab10_2.Animal("__", 0);
            res.Add(SpeedTest(list, first));
            res.Add(SpeedTest(list, last));
            res.Add(SpeedTest(list, outCol));
        }
        private double SpeedTest(Dictionary<Lab10_2.Animal, Lab10_2.Bird> list, Lab10_2.Animal entry)
        {
            var startTime = System.Diagnostics.Stopwatch.StartNew();
            try
            {
                Lab10_2.Bird an = list[entry];
            }
            catch (KeyNotFoundException) { }
            startTime.Stop();
            var resTime = startTime.Elapsed;
            return resTime.TotalMilliseconds;
        }
        private void SpeedTest(Dictionary<string, Lab10_2.Bird> list, List<double> res)
        {
            res.Clear();
            string first = (string)list.First().Key.Clone();
            string last = (string)list.Last().Key.Clone();
            string outCol = "__-_-_";
            res.Add(SpeedTest(list, first));
            res.Add(SpeedTest(list, last));
            res.Add(SpeedTest(list, outCol));
        }
        private double SpeedTest(Dictionary<string, Lab10_2.Bird> list, string entry)
        {
            var startTime = System.Diagnostics.Stopwatch.StartNew();
            try
            {
                Lab10_2.Bird an = list[entry];
            }
            catch (KeyNotFoundException) { }
            startTime.Stop();
            var resTime = startTime.Elapsed;
            return resTime.TotalMilliseconds;
        }

        private void random_add_tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            _KeyPress(sender, e);
        }

        private void random_add_Click(object sender, EventArgs e)
        {
            if (sorted_list_rb.Checked)
                FillRandom();
            else
                FillRandomSD();
        }

        private void delete_button_Click(object sender, EventArgs e)
        {
            if (sorted_list_rb.Checked)
                Delete();
            else
                DeleteSD();
        }

        private void add_button_Click(object sender, EventArgs e)
        {
            AddAnimal();
        }

        private void clone_button_Click(object sender, EventArgs e)
        {
            CloneCollection();
        }

        private void update_cloned_collection_Click(object sender, EventArgs e)
        {
            UpdateCloned();
        }

        private void delete_cloned_button_Click(object sender, EventArgs e)
        {
            DeleteCloned();
        }

        private void sorted_list_rb_CheckedChanged(object sender, EventArgs e)
        {
            if (sorted_dict_rb.Checked)
            {
                ClearFields();
                UpdateListbox(collection_listbox, sd);
                UpdateListbox(cloned_collection_listbox, clone_sd);
            }
        }

        private void sorted_dict_rb_CheckedChanged(object sender, EventArgs e)
        {
            if (sorted_list_rb.Checked)
            {
                ClearFields();
                UpdateListbox(collection_listbox, sl);
                UpdateListbox(cloned_collection_listbox, clone_sl);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Find();
        }

        private void test_random_add_tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            _KeyPress(sender, e);
        }

        private void test_age_tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            _KeyPress(sender, e);
        }

        private void test_wingwidth_tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            _KeyPress(sender, e);
        }

        private void random_add_button_Click(object sender, EventArgs e)
        {
            TestRandomFill();
        }

        private void collection_1_1_SelectedIndexChanged(object sender, EventArgs e)
        {
            collection_1_2.SelectedIndex = collection_1_1.SelectedIndex;
            collection_2_2.SelectedIndex = collection_1_1.SelectedIndex;
            collection_2_1.SelectedIndex = collection_1_1.SelectedIndex;
        }

        private void collection_1_2_SelectedIndexChanged(object sender, EventArgs e)
        {
            collection_1_1.SelectedIndex = collection_1_2.SelectedIndex;
            collection_2_2.SelectedIndex = collection_1_2.SelectedIndex;
            collection_2_1.SelectedIndex = collection_1_2.SelectedIndex;
        }

        private void collection_2_1_SelectedIndexChanged(object sender, EventArgs e)
        {
            collection_1_2.SelectedIndex = collection_2_1.SelectedIndex;
            collection_1_1.SelectedIndex = collection_2_1.SelectedIndex;
            collection_2_2.SelectedIndex = collection_2_1.SelectedIndex;
        }

        private void collection_2_2_SelectedIndexChanged(object sender, EventArgs e)
        {
            collection_1_2.SelectedIndex = collection_2_2.SelectedIndex;
            collection_1_1.SelectedIndex = collection_2_2.SelectedIndex;
            collection_2_1.SelectedIndex = collection_2_2.SelectedIndex;

            TestShowAnimal(tc.collection_2_2[tc.collection_1_2[collection_1_1.SelectedIndex]]);
        }

        private void test_add_button_Click(object sender, EventArgs e)
        {
            TestAddAnimal();
        }

        private void test_delete_button_Click(object sender, EventArgs e)
        {
            TestDelete();
        }

        private void speed_test_button_Click(object sender, EventArgs e)
        {
            SpeedTest();
        }
    }
}
