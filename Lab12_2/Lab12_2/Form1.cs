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

namespace Lab12_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            task2_panel.Location = task1_panel.Location;
            task3_panel.Location = task1_panel.Location;
            task4_panel.Location = task1_panel.Location;
            task2_panel.Visible = false;
            task3_panel.Visible = false;
            task4_panel.Visible = false;
        }
        MyList1d list1d = new MyList1d();
        MyList2d list2d = new MyList2d();
        MyTree tree = new MyTree();
        MyCollection<Lab10_2.Animal> coll = new MyCollection<Lab10_2.Animal>();
        Random rand = new Random(0);

        private void FindElement()
        {
            if (FieldsIsEmpty()) { ShowError("Введите значения для поиска"); return; }

            Lab10_2.Animal an = GetAnimal();

            bool done = coll.Find(an);
            if (done) ShowMsg("Элемент найден");
            else ShowMsg("Элемент не найден");
        }


        private void Action1()
        {
            tree.Clear();
            UpdateTree();
        }
        private void ToBalanced()
        {
            tree.ToBalanced();
            UpdateTree();
        }
        private void ToSearch()
        {
            tree.ToSearch();
            UpdateTree();
        }
        private void UpdateTree()
        {
            treeView1.Nodes.Clear();
            tree.PrintTree(treeView1);
        }
        private void Add3()
        {
            if (add3_tb.Text == "") { ShowError("Введите значение для добавления"); return; }
            int res;
            bool right = Int32.TryParse(add3_tb.Text, out res);
            if (!right) { ShowError("Введено неверное значение"); add3_tb.Text = ""; return; }

            if (balanced_rb.Checked)
                tree.AddBalanced(res);
            else
                tree.AddSearch(res);
            UpdateTree();
        }
        private void ShowError(string msg)
        {
            //msg_label.Text = msg;
            //msg_label.Visible = true;
            MessageBox.Show(
             msg,
              "Ошибка",
            MessageBoxButtons.OK,
      MessageBoxIcon.Error);
        }
        private void ShowMsg(string msg)
        {
            //msg_label.Text = msg;
            //msg_label.Visible = true;
            MessageBox.Show(
             msg,
              "Cообщение",
            MessageBoxButtons.OK,
      MessageBoxIcon.Information);
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
        private void RandomFill(MyList1d list)
        {
            if (randomCount1_tb.Text == "") { ShowError("Введите количество элементов"); return; }
            list.Clear();
            int n = Int32.Parse(randomCount1_tb.Text);

            for (int i = 0; i < n; i++)
            {
                list.Add(RandomWord());
            }
            UpdateListbox(listBox1, list);
        }
        private void RandomFill(MyList2d list)
        {
            if (randomCount2_tb.Text == "") { ShowError("Введите количество элементов"); return; }
            list.Clear();
            int n = Int32.Parse(randomCount2_tb.Text);

            for (int i = 0; i < n; i++)
            {
                list.Add(RandomDouble());
            }
            UpdateListbox(listBox2, list);
        }

        private void RandomFill(MyTree list)
        {
            if (randomFill3_tb.Text == "") { ShowError("Введите количество элементов"); return; }

            list.Clear();
            int n = Int32.Parse(randomFill3_tb.Text);
            for (int i = 0; i < n; i++)
            {
                if (balanced_rb.Checked == true)
                    list.AddBalanced(rand.Next(0, 1000));
                else
                    list.AddSearch(rand.Next(0, 1000));
            }
            UpdateTree();
        }

        private double RandomDouble()
        {
            double n = 0;
            double tmp = rand.Next(0, 1000);
            n += rand.Next(0, 1000);
            n += tmp / Math.Pow(10, tmp.ToString().Length);

            if (rand.Next(0, 2) == 1) n *= -1;

            return n;
        }

        private void UpdateListbox(ListBox list1, MyList1d list2)
        {
            list1.Items.Clear();

            foreach (var i in list2)
            {
                list1.Items.Add(i);
            }
        }
        private void UpdateListbox(ListBox list1, MyCollection<Lab10_2.Animal> list2)
        {
            list1.Items.Clear();

            foreach (Lab10_2.Animal i in list2)
            {
                list1.Items.Add(i.Name);
            }
        }
        private void UpdateListbox(ListBox list1, MyList2d list2)
        {
            list1.Items.Clear();

            foreach (var i in list2)
            {
                list1.Items.Add(i);
            }
        }
        private void AddLast()
        {
            if (add1_tb.Text == "") { ShowError("Введите элемент"); return; }

            list1d.Add(add1_tb.Text);

            UpdateListbox(listBox1, list1d);

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
        private string RandomWord()
        {
            string str = "";
            using (var fin = new StreamReader("words.txt", Encoding.Default))
            {
                int n = rand.Next(0, 199);
                for (int i = 0; i < n; i++)
                    str = fin.ReadLine();
            }
            return str;
        }

        private void AddAfter()
        {
            if (add1_tb.Text == "") { ShowError("Введите элемент для добавления"); return; }
            if (addAfter1_tb.Text == "") { ShowError("Введите заданный элемент"); return; }
            bool done = list1d.AddAfter(addAfter1_tb.Text, add1_tb.Text);

            if (!done) ShowError("Заданный элемент не найден");
            else
                UpdateListbox(listBox1, list1d);
        }
        private void RemoveAt()
        {
            if (listBox1.SelectedIndex == -1) { ShowError("Выберите элемент для удаления"); return; }

            list1d.RemoveAt(listBox1.SelectedIndex);
            UpdateListbox(listBox1, list1d);
        }
        private void RemoveAt2()
        {
            if (listBox2.SelectedIndex == -1) { ShowError("Выберите элемент для удаления"); return; }

            list2d.RemoveAt(listBox2.SelectedIndex);
            UpdateListbox(listBox2, list2d);
        }
        private void RemoveAt3()
        {
            if (collection_listbox.SelectedIndex == -1) { ShowError("Выберите элемент для удаления"); return; }

            coll.RemoveAt(collection_listbox.SelectedIndex);
            UpdateListbox(collection_listbox, coll);
        }

        private void AddLast2()
        {
            if (add2_tb.Text == "") { ShowError("Введите значение для добавления"); }
            double res;
            bool right = Double.TryParse(add2_tb.Text, out res);
            if (!right) { ShowError("Введено неверное значение"); add2_tb.Text = ""; return; }

            list2d.Add(res);
            UpdateListbox(listBox2, list2d);
        }
        private void AddFirst2()
        {
            if (add2_tb.Text == "") { ShowError("Введите значение для добавления"); }
            double res;
            bool right = Double.TryParse(add2_tb.Text, out res);
            if (!right) { ShowError("Введено неверное значение"); add2_tb.Text = ""; return; }

            list2d.AddFirst(res);
            UpdateListbox(listBox2, list2d);
        }

        private void ShowTask(int n)
        {
            switch (n)
            {
                case 1:
                    task1_panel.Visible = true;
                    task2_panel.Visible = false;
                    task3_panel.Visible = false;
                    task4_panel.Visible = false;
                    break;
                case 2:
                    task1_panel.Visible = false;
                    task2_panel.Visible = true;
                    task3_panel.Visible = false;
                    task4_panel.Visible = false;
                    break;
                case 3:
                    task1_panel.Visible = false;
                    task2_panel.Visible = false;
                    task3_panel.Visible = true;
                    task4_panel.Visible = false;
                    break;
                case 4:
                    task1_panel.Visible = false;
                    task2_panel.Visible = false;
                    task3_panel.Visible = false;
                    task4_panel.Visible = true;
                    break;
            }
        }

        private void DelNegatives()
        {
            bool done = list2d.DelNegatives();

            if (done)
            {
                UpdateListbox(listBox2, list2d);
                ShowMsg("Элементы удалены");
            }
            else
                ShowMsg("Отрицательных элементов нет");
        }
        private bool FieldsIsEmpty()
        {
            if (add_bird_rb.Checked)
                return name_tb.Text == "" || age_tb.Text == "" || wing_width_tb.Text == "";
            else
                return name_tb.Text == "" || age_tb.Text == "";
        }
        private void FillRandom()
        {
            if (random_add_tb.Text == "") { ShowError("Введите количество"); return; }

            FillRandom(coll, Int32.Parse(random_add_tb.Text));
            UpdateListbox(collection_listbox, coll);
        }
        private void FillRandom(MyCollection<Lab10_2.Animal> list, int n)
        {
            list.Clear();
            bool f = true;
            Lab10_2.Animal an;
            for (int i = 0; i < n; i++)
            {
                an = RandomAnimal();
                list.Add(an);
            }
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
            if (FieldsIsEmpty()) { ShowError("Заполните поля"); return; }

            Lab10_2.Animal an = GetAnimal();
            coll.Add(an);
            UpdateListbox(collection_listbox, coll);

        }

        private Lab10_2.Animal GetAnimal()
        {
            Lab10_2.Animal an = null;
            if (add_animal_rb.Checked)
                an = new Lab10_2.Animal(name_tb.Text, Int32.Parse(age_tb.Text));
            else if (add_mammal_rb.Checked)
                an = new Lab10_2.Mammal(name_tb.Text, Int32.Parse(age_tb.Text));
            else if (add_atipdactyl_rb.Checked)
                an = new Lab10_2.Artiodactyl(name_tb.Text, Int32.Parse(age_tb.Text));
            else if (add_bird_rb.Checked)
                an = new Lab10_2.Bird(name_tb.Text, Int32.Parse(age_tb.Text), Int32.Parse(wing_width_tb.Text));
            return an;
        }

        private void _KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')
            {
                FormInput(sender, e);
            }
        }
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            _KeyPress(sender, e);
        }

        private void randomFill_button1_Click(object sender, EventArgs e)
        {
            RandomFill(list1d);
        }

        private void addLast_button_Click(object sender, EventArgs e)
        {
            AddLast();
        }

        private void addAfter_button_Click(object sender, EventArgs e)
        {
            AddAfter();
        }

        private void task1_rb_CheckedChanged(object sender, EventArgs e)
        {
            ShowTask(1);
        }

        private void task2_rb_CheckedChanged(object sender, EventArgs e)
        {
            ShowTask(2);
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            ShowTask(3);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RemoveAt();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (list1d.Count != 0)
            {
                list1d.Clear();
                UpdateListbox(listBox1, list1d);
                ShowMsg("Список удален");

            }
            else
            {
                ShowError("Список пуст");
            }
        }
        private void randomCount2_tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            _KeyPress(sender, e);
        }

        private void randomFill2_button1_Click(object sender, EventArgs e)
        {
            RandomFill(list2d);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DelNegatives();
        }

        private void addlast2_button_Click(object sender, EventArgs e)
        {
            AddLast2();
        }

        private void addfirst2_button_Click(object sender, EventArgs e)
        {
            AddFirst2();
        }

        private void delSelected2_button_Click(object sender, EventArgs e)
        {
            RemoveAt2();
        }

        private void clearList2_button_Click(object sender, EventArgs e)
        {
            if (list2d.Count != 0)
            {
                list2d.Clear();
                UpdateListbox(listBox2, list2d);
                ShowMsg("Список удален");
            }
            else
            {
                ShowError("Список пуст");
            }
        }
        private void ClearFields()
        {
            name_tb.Text = "";
            age_tb.Text = "";
            wing_width_tb.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Action1();
        }

        private void add3_button_Click(object sender, EventArgs e)
        {
            Add3();
        }
        private void balanced_rb_CheckedChanged(object sender, EventArgs e)
        {
            if (balanced_rb.Checked == true)
                ToBalanced();
        }

        private void search_rb_CheckedChanged(object sender, EventArgs e)
        {
            if (search_rb.Checked == true)
                ToSearch();
        }

        private void randomFill3_tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            _KeyPress(sender, e);
        }

        private void randomFill_button_Click(object sender, EventArgs e)
        {
            RandomFill(tree);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = tree.CalcAver().ToString();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            ShowTask(4);
        }

        private void add_button_Click(object sender, EventArgs e)
        {
            AddAnimal();
        }

        private void random_add_Click(object sender, EventArgs e)
        {
            FillRandom();
        }

        private void collection_listbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (collection_listbox.SelectedIndex != -1)
            {
                ShowAnimal(coll[collection_listbox.SelectedIndex]);
            }
        }

        private void add_bird_rb_CheckedChanged(object sender, EventArgs e)
        {
            wing_width_tb.Visible = add_bird_rb.Checked;
            wing_width_label.Visible = add_bird_rb.Checked;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (coll.Count != 0)
            {
                coll.Clear();
                UpdateListbox(collection_listbox, coll);
                ShowMsg("Коллекция удалена");

            }
            else
            {
                ShowError("Коллекция пуста");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            RemoveAt3();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            FindElement();
        }

        private void random_add_tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            _KeyPress(sender, e);
        }
    }
}
