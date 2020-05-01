using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Lab8_2
{
    public partial class Form1 : Form
    {
        private List<Group> groups = new List<Group>();
        private int groupCount = 0;
        public Form1()
        {
            InitializeComponent();
        }
        private void Initialize()
        {

        }
        private void LoadFiles()
        {
            string str = "";
            using (var fin = new StreamReader("groupsList.txt"))
            {
                while (!fin.EndOfStream)
                {
                    str = fin.ReadLine();
                }
            }
        }
        private void addGroup()
        {
            string name = add_group_tb.Text;
            if (name == "" || name == "Введите название") { name = "Новая группа"; name += groupCount + 1; }
            Group g = new Group(name, groupCount, Decimal.ToInt32(add_group_year.Value));
            addGroup(g);
        }
        private void addGroup(Group g)
        {
            groups.Add(g);
            groups_lb.Items.Add(g.Name);
            groupCount++;
            SaveGroup(g);
        }
            private void UpdateGroupList()
        {
            groups_lb.Items.Clear();
            for (int i = 0; i < groupCount; i++)
                groups_lb.Items.Add(groups[i].Name);
        }
        private void UpdateStudentList()
        {

        }
        private void UpdateStudentList(Group g)
        {
            students_lb.Items.Clear();

            for (int i = 0; i < g.students.Count; i++)
                students_lb.Items.Add(g.students[i].Name);
        }
        private void SaveGroup()
        {
            RewriteGroupInfo();
            for (int i = 0; i < groups.Count; i++) 
                SaveGroup(groups[i]);
        }
        private void SaveGroup(Group g)
        {
            SaveGroupInfo(g);
            SaveGroupStudents(g);
        }
        private void SaveGroupInfo(Group g)
        {
            int rowsCount = 2;
            //string str;
            string[] allLines;
            using (var fin = new StreamReader("groupList.txt"))
            {
                allLines = fin.ReadToEnd().Split('\n');
            }
            using (var fout = new StreamWriter("groupList.txt", false))
            {
                if (g.FileIndex * rowsCount < allLines.Length - 1)
                {
                    allLines[g.FileIndex * rowsCount] = g.Name;
                    allLines[g.FileIndex * rowsCount + 1] = g.Year.ToString();
                    foreach (string s in allLines)
                        if (s != "" && s != "\r")
                            fout.WriteLine(s.Trim());
                }
                else
                {
                    foreach (string s in allLines)
                        if (s != "" && s != "\r")
                            fout.WriteLine(s.Trim());
                    for (int i = 0; i < ((allLines.Length - 1) / rowsCount - g.FileIndex) * rowsCount; i++)
                        fout.WriteLine();
                    fout.WriteLine(g.Name);
                    fout.WriteLine(g.Year.ToString());
                }
            }
        }
        private void SaveGroupStudents(Group g)
        {
            string filename = g.FileIndex.ToString();
            filename += "grp.bin";
            FileStream f1 = new FileStream(filename, FileMode.OpenOrCreate);
            BinaryFormatter bf = new BinaryFormatter();
            for (int i = 0; i < g.students.Count; i++)
            {
                bf.Serialize(f1, g.students[i]);
            }
            f1.Close();
        }
        private void LoadGroup()
        {
            groups.Clear();
            LoadGroupsInfo();
            UpdateGroupList();
            LoadGroupStudents();
        }
        private void LoadGroupsInfo()
        {
            int rowsCount = 2;
            int groupsCount = 0;
            string[] allLines;
            using (var fin = new StreamReader("groupList.txt"))
            {
                allLines = fin.ReadToEnd().Split('\n');
            }
            groupsCount = (allLines.Length - 1) / rowsCount;

            for (int i = 0; i < groupsCount; i++)
            {
                groups.Add(new Group(allLines[i * rowsCount].Trim(), i, Int32.Parse(allLines[i * rowsCount + 1])));
            }
            groupCount = groups.Count;
        }
        private void LoadGroupStudents()
        {
            for (int i = 0; i < groups.Count; i++)
            {
                LoadGroupStudents(groups[i]);
            }
        }
        private void LoadGroupStudents(Group g)
        {
            string filename = g.FileIndex.ToString();
            filename += "grp.bin";
            FileStream f1 = new FileStream(filename, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            while (f1.Length != f1.Position)
            {
                Student st = (Student)bf.Deserialize(f1);
                g.AddStudent(st);
            }
            g.Count();
            f1.Close();
        }
        private void addStudent()
        {
            if (groups_lb.SelectedIndex != -1)
                addStudent(groups[groups_lb.SelectedIndex]);
            else
                ShowError("Выберите группу для добавления");
        }
        private void addStudent(Group g)
        {
            Student st = CreateStudent();
            if (st == null) { ShowError("поля не заполнены или заполнены неверно"); return; }

            st.Year = g.Year;
            g.AddStudent(st);
            students_lb.Items.Add(st.Name);

        }
        private void DelGroup()
        {
            if (groups_lb.SelectedIndex != -1)
            {
                File.Delete($"{groups[groups_lb.SelectedIndex].FileIndex }grp.bin");
                for (int i = groups_lb.SelectedIndex + 1; i < groups.Count; i++) 
                {
                    File.Move($"{groups[i].FileIndex }grp.bin", $"{groups[i].FileIndex - 1}grp.bin");
                    groups[i].pressF();
                    RewriteGroupInfo();
                }
                groups.RemoveAt(groups_lb.SelectedIndex);
                groups_lb.Items.RemoveAt(groups_lb.SelectedIndex);
                students_lb.Items.Clear();
            }
            else ShowError("Выберите группу для удаления");
        }
        private void ClearGroupInfo() 
        {
            FileStream f = new FileStream("groupList.txt", FileMode.Truncate);
            f.Close();
        }
        private void RewriteGroupInfo() 
        {
            ClearGroupInfo();
            for (int i = 0; i < groups.Count; i++)  
            {
                SaveGroupInfo(groups[i]);
            }
        }

        private void groups_lb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (groups_lb.SelectedIndex != -1)
            {
                UpdateStudentList(groups[groups_lb.SelectedIndex]);
                ClearFields();
                year_tb.Text = groups[groups_lb.SelectedIndex].Year.ToString();
            }
        }
        private void students_lb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (groups_lb.SelectedIndex != -1 && students_lb.SelectedIndex != -1)
            {
                UpdateFields(groups[groups_lb.SelectedIndex].students[students_lb.SelectedIndex]);
            }
        }

        private Student CreateStudent()
        {
            string name;
            int age;
            double rating;
            Student st;
            if (ParseTB(name_tb, out name) && ParseTB(age_tb, out age) && ParseTB(rating_tb, out rating))
            {
                st = new Student();
                st.Name = name;
                st.Rating = rating;
                st.Year = 0;
                st.Age = age;
            }
            else st = null;
            return st;
        }
        private bool ParseTB(TextBox tb, out string str)
        {
            if (tb.Text == "") { str = ""; return false; }
            else { str = tb.Text; return true; }
        }
        private bool ParseTB(TextBox tb, out int I)
        {
            if (tb.Text == "") { I = 0; return false; }
            else if (Int32.TryParse(tb.Text, out I)) return true;
            else return false;
        }
        private bool ParseTB(TextBox tb, out double D)
        {
            if (tb.Text == "") { D = 0; return false; }
            else if (Double.TryParse(tb.Text, out D)) return true;
            else return false;
        }
        private bool IsEmpty(TextBox tb)
        {
            if (tb.Text == "") return true;
            else return false;
        }
        private void ShowError(string str)
        {
            error_label.Text = str;
            error_label.Visible = true;
        }
        private void UnShowError()
        {
            error_label.Text = "";
            error_label.Visible = false;
        }
        private void ClearAll()
        {
            groups.Clear();
            students_lb.Items.Clear();
            groups_lb.Items.Clear();
            ClearFields();
        }
        private void add_group_button_Click(object sender, EventArgs e)
        {
            addGroup();
        }
        private void ClearFields()
        {
            name_tb.Text = "";
            age_tb.Text = "";
            year_tb.Text = "";
            rating_tb.Text = "";
        }
        private void UpdateFields(Student st)
        {
            name_tb.Text = st.Name;
            age_tb.Text = st.Age.ToString();
            year_tb.Text = st.Year.ToString();
            rating_tb.Text = st.Rating.ToString();
        }
        private void DelStudent()
        {
            if (students_lb.SelectedIndex != -1 && groups_lb.SelectedIndex != -1)
            {
                groups[groups_lb.SelectedIndex].DelStudent(students_lb.SelectedIndex);
                students_lb.Items.RemoveAt(students_lb.SelectedIndex);
            }
            else ShowError("Выберите запись студента для удаления");
            //ShowError(students_lb.SelectedIndex.ToString());
        }
        private void ChangeName()
        {
            if (groups_lb.SelectedIndex != -1)
            {
                if (new_name_tb.Text != "")
                {
                    groups[groups_lb.SelectedIndex].Name = new_name_tb.Text;
                    groups_lb.Items[groups_lb.SelectedIndex] = new_name_tb.Text;
                    new_name_tb.Text = "";
                }
                else
                    ShowError("Введите новое название для группы");
            }
            else
                ShowError("Выберите группу для изменения названия");
        }
        private void ChangeYear()
        {
            if (groups_lb.SelectedIndex != -1)
            {
                groups[groups_lb.SelectedIndex].ChangeYear(Decimal.ToInt32(new_year_tb.Value));

                //   if (students_lb.SelectedIndex != -1)
                //       UpdateFields(groups[groups_lb.SelectedIndex].students[students_lb.SelectedIndex]);
                year_tb.Text = new_year_tb.Value.ToString();
            }
            else
                ShowError("Выберите группу для изменения курса");
        }
        private void ChangeStudent() 
        {
            if (groups_lb.SelectedIndex != -1)
                ChangeStudent(groups[groups_lb.SelectedIndex]);
            else
                ShowError("Выберите группу");
        }
        private void ChangeStudent(Group g) 
        {
            if (students_lb.SelectedIndex != -1)
            {
                Student st = CreateStudent();
                if (st == null) { ShowError("поля не заполнены или заполнены неверно"); return; }

                st.Year = g.Year;
                g.students[students_lb.SelectedIndex] = st;
                students_lb.Items[students_lb.SelectedIndex] = st.Name;
            }
            else ShowError("Выберите запись для изменения");
        }
        private void MakeNewSuperList() 
        {
            Group g = new Group("Супер-список", groups.Count, Decimal.ToInt32(makenewlist_value.Value));
            List<Student> sts = new List<Student>();

            for (int i = 0; i < groups.Count; i++)  
            {
                if (groups[i].Year == Decimal.ToInt32(makenewlist_value.Value))
                    sts = sts.Union(groups[i].students).ToList();
            }
            sts.Sort((a, b) => a.Name.CompareTo(b.Name));

            g.students = sts;
            addGroup(g);
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
        private void _KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')
            {
                FormInput(sender, e);
                // e.Handled = true;
            }
        }

        private void add_student_button_Click(object sender, EventArgs e)
        {
            addStudent();
        }

        private void clear_fields_button_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void debug_active_CheckedChanged(object sender, EventArgs e)
        {
            debug_gb.Visible = debug_active.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveGroup();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadGroup();
        }

        private void clear_all_button_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void del_student_button_Click(object sender, EventArgs e)
        {
            DelStudent();
        }

        private void del_group_button_Click(object sender, EventArgs e)
        {
            DelGroup();
        }

        private void change_name_button_Click(object sender, EventArgs e)
        {
            ChangeName();
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            UnShowError();
        }

        private void change_year_button_Click(object sender, EventArgs e)
        {
            ChangeYear();
        }

        private void change_student_button_Click(object sender, EventArgs e)
        {
            ChangeStudent();  
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MakeNewSuperList();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            LoadGroup();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveGroup();
        }

        private void age_tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            _KeyPress(sender, e);
        }

        private void rating_tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            _KeyPress(sender, e);
        }
    }
}
