using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;

namespace Lab7_2
{
    public partial class Form1 : Form
    {
        private int[] arr1;
        private int[,] arr2;
        private int[][] arr3 = new int[0][];
        private readonly Random rand;

        public Form1()
        {
            rand = new Random(0);
            InitializeComponent();
            arrayType.SelectedIndex = 0;
            inp_label.Location = new Point(157, 12);
            input_tb.Location = new Point(157, 28);
            to_begin.Location = new Point(157, 55);
            to_end.Location = new Point(233, 55);
            add_elms.Location = new Point(305, 55);

            del_button.Location = new Point(285, 127);
            del_label.Location = new Point(157, 12);
            rowsColumns.Location = new Point(160, 28);
            oneMany.Location = new Point(160, 64);
            pos1_label.Location = new Point(160, 100);
            pos2_label.Location = new Point(272, 100);
            pos1_tb.Location = new Point(227, 100);
            pos2_tb.Location = new Point(330, 100);



        }

        private void ArrayType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowBottons(arrayType.SelectedIndex);
            UnShowError();
            UpdateOutput();
            switch (arrayType.SelectedIndex)
            {
                case 0:
                    size1_label.Text = "Элементов";
                    size1_label.Visible = true;
                    size2_label.Visible = false;
                    size1_tb.Visible = true;
                    size2_tb.Visible = false;

                    ToggleInp(true);
                    ToggleDel(false);
                    ToggleTorn(false);

                    OneOrMany(0);
                    break;
                case 1:
                    size1_label.Text = "Строк";
                    size1_label.Visible = true;
                    size2_label.Visible = true;
                    size1_tb.Visible = true;
                    size2_tb.Visible = true;
                    ToggleInp(false);
                    ToggleDel(true);
                    ToggleTorn(false);
                    OneOrMany(1);
                    del_one.Checked = true;
                    break;
                case 2:
                    size1_label.Text = "Строк";
                    size1_label.Visible = true;
                    size2_label.Visible = false;
                    size1_tb.Visible = true;
                    size2_tb.Visible = false;
                    ToggleInp(false);
                    ToggleDel(false);
                    ToggleTorn(true);
                    OneOrMany(0);
                    break;
            }
        }
        private void ToggleInp(bool lever)
        {
            inp_label.Visible = lever;
            input_tb.Visible = lever;
            to_begin.Visible = lever;
            to_end.Visible = lever;
            add_elms.Visible = lever;
        }
        private void ToggleTorn(bool lever)
        {
            torn_add_num.Visible = lever;
            torn_add_row.Visible = lever;
            torn_del_row.Visible = lever;
            torn_pos.Visible = lever;
        }
        private void ToggleDel(bool lever)
        {
            del_button.Visible = lever;
            del_label.Visible = lever;
            del_many.Visible = lever;
            del_one.Visible = lever;
            rowsColumns.Visible = lever;
            rows_button.Visible = lever;
            columns_button.Visible = lever;
            oneMany.Visible = lever;
        }
        private void ArrayType_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void Create_Click(object sender, EventArgs e)
        {
            switch (arrayType.SelectedIndex)
            {
                case 0:
                    Make1dArr();
                    break;
                case 1:
                    Make2dArr();
                    break;
                case 2:
                    MakeTdArr();
                    break;
            }
        }

        private void ShowBottons(int ind)
        {
            switch (ind)
            {
                case 0:
                    inp_label.Visible = true;
                    to_begin.Visible = true;
                    to_end.Checked = true;
                    to_end.Visible = true;
                    input_tb.Visible = true;
                    add_elms.Visible = true;
                    break;
                case 1:
                    inp_label.Visible = false;
                    to_begin.Visible = false;
                    to_end.Visible = false;
                    input_tb.Visible = false;
                    add_elms.Visible = false;
                    break;
                case 2:
                    inp_label.Visible = false;
                    to_begin.Visible = false;
                    to_end.Visible = false;
                    input_tb.Visible = false;
                    add_elms.Visible = false;
                    break;

            }
        }

        private static int GetSize(TextBox t)
        {
            bool right = Int32.TryParse(t.Text, out int res);
            if (right)
                return res;
            else return 0;
        }
        static void addArray(ref int[] arr1, int[] arr2, bool toBegin)
        {
            if (arr1 == null) arr1 = new int[0];
            int[] added = new int[arr1.Length + arr2.Length];
            if (toBegin)
            {
                arr1.CopyTo(added, 0);
                arr2.CopyTo(added, arr1.Length);
            }
            else
            {
                arr2.CopyTo(added, 0);
                arr1.CopyTo(added, arr2.Length);
            }
            arr1 = added;
        }
        private void Make1dArr()
        {
            bool s = true;
            if (autoComplete.Checked)
            {
                s = AutoComplete(ref arr1);
                if (s) ShowError("Массив создан");
            }
            else
            {
                s = ManualComplete(ref arr1, output_tb);
                if (s) ShowError("Массив прочитан");
            }

            if (arr1 != null && s)
            {
                output_tb.Text = PrintArray(arr1);
                size1_tb.Text = arr1.Length.ToString();
            }
        }
        private void Make2dArr()
        {
            bool s = true;
            if (autoComplete.Checked)
            {
                s = AutoComplete(ref arr2);
                if (s) ShowError("Массив создан");
            }
            else
            {
                s = ManualComplete(ref arr2, output_tb);
                if (s) ShowError("Массив прочитан");
            }

            if (arr2 != null && s)
            {
                output_tb.Text = PrintArray(arr2);
                // ShowError("Массив прочитан");
                size1_tb.Text = arr2.GetLength(0).ToString();
                size2_tb.Text = arr2.GetLength(1).ToString();
            }
        }
        private void MakeTdArr()
        {
            bool s = true;
            if (autoComplete.Checked)
            {
                s = AutoComplete(ref arr3);
                if (s) ShowError("Массив создан");
            }
            else
            {
                s = ManualComplete(ref arr3, output_tb);
                if (s) ShowError("Массив прочитан");
            }

            if (arr3 != null && s)
            {
                output_tb.Text = PrintArray(arr3);
                ShowError("Массив прочитан");
                size1_tb.Text = arr3.Length.ToString();
            }
        }
        private bool ManualComplete(ref int[][] arr, RichTextBox output_tb)
        {
            if (CheckInput(output_tb.Text))
                UnShowError();
            else { ShowError("Ошибка ввода"); return false; }
            output_tb.Text = Regex.Replace(output_tb.Text, "[ ]+", " ");
            output_tb.Text = Regex.Replace(output_tb.Text, "[\n]+", "\n");
            output_tb.Text = output_tb.Text.TrimEnd('\n');
            output_tb.Text = output_tb.Text.TrimEnd(' ');
            string[] rows = output_tb.Text.Split('\n');
            string[] digs;
            arr = new int[rows.Length][];
            for (int i = 0; i < rows.Length; i++)
            {
                rows[i] = rows[i].TrimEnd(' ');
                digs = rows[i].Split(' ');
                arr[i] = new int[digs.Length];
                for (int j = 0; j < digs.Length; j++)
                {
                    Int32.TryParse(digs[j], out arr[i][j]);
                }
            }
            return true;
        }
        private bool ManualComplete(ref int[,] arr, RichTextBox output_tb)
        {
            if (CheckInput(output_tb.Text))
                UnShowError();
            else { ShowError("Ошибка ввода"); return false; }

            //ShowError("Перенос строки: " + output_tb.Text.IndexOf("\n"));
            output_tb.Text = Regex.Replace(output_tb.Text, "[ ]+", " ");
            output_tb.Text = Regex.Replace(output_tb.Text, "[\n]+", "\n");
            output_tb.Text = output_tb.Text.TrimEnd('\n');
            output_tb.Text = output_tb.Text.TrimEnd(' ');
            int r, c = 0, c1;
            string[] rows = output_tb.Text.Split('\n');
            string[] digs;
            r = rows.Length;
            for (int i = 0; i < rows.Length; i++)
            {
                rows[i] = rows[i].TrimEnd(' ');
                c1 = 0;
                for (int j = 0; j < rows[i].Length; j++)
                    if (rows[i][j] == ' ') c1++;
                if (c1 > c) c = c1;
            }
            arr = new int[r, c + 1];
            for (int i = 0; i < rows.Length; i++)
            {
                digs = rows[i].Split(' ');
                for (int j = 0; j < digs.Length; j++)
                {
                    Int32.TryParse(digs[j], out arr[i, j]);
                }
            }
            return true;
        }
        private bool ManualComplete(ref int[] arr, RichTextBox output_tb)
        {
            if (CheckInput(output_tb.Text))
                UnShowError();
            else { ShowError("Ошибка ввода"); return false; }
            output_tb.Text = Regex.Replace(output_tb.Text, "[ ]+", " ");
            output_tb.Text = Regex.Replace(output_tb.Text, "[\n]+", "");
            output_tb.Text = output_tb.Text.TrimEnd(' ');
            output_tb.Text = output_tb.Text.TrimEnd('\n');
            string[] tmpstr = output_tb.Text.Split(' ');
            arr = new int[tmpstr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = Int32.Parse(tmpstr[i]);
            }
            return true;
        }

        private bool CheckInput(string str)
        {
            if (str == "") return false;
            for (int i = 0; i < str.Length; i++)
            {
                if (!Char.IsDigit(str[i]) && str[i] != ' ' && str[i] != '\n')
                {
                    if (str[i] == '-')
                    {
                        if (i == str.Length - 1) return false;
                        if (i != 0 && (!(str[i - 1] == ' ' || str[i - 1] == '\n') || !Char.IsDigit(str[i + 1]))) return false;
                        if (i == 0 && !Char.IsDigit(str[i + 1])) return false;
                    }
                    else return false;
                }
            }
            return true;
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
        private void UnShowError()
        {
            msg_label.Text = "";
            msg_label.Visible = false;
        }
        private bool AutoComplete(ref int[,] arr)
        {
            if (GetSize(size1_tb) == 0 || GetSize(size2_tb) == 0) { ShowError("Введите размерность"); return false; } else UnShowError();
            arr = new int[GetSize(size1_tb), GetSize(size2_tb)];
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = rand.Next(10, 99);
                }
            }
            return true;
        }
        private bool AutoComplete(ref int[][] arr)
        {
            if (GetSize(size1_tb) == 0) { ShowError("Введите количество строк"); return false; } else UnShowError();
            arr = new int[GetSize(size1_tb)][];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = new int[rand.Next(5, 15)];
                for (int j = 0; j < arr[i].Length; j++)
                    arr[i][j] = rand.Next(10, 99);
            }
            return true;
        }
        private bool AutoComplete(ref int[] arr)
        {
            if (GetSize(size1_tb) == 0) { ShowError("Введите размерность"); return false; } else UnShowError();
            arr = new int[GetSize(size1_tb)];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next(10, 99);
            }
            return true;
        }

        private void Size1_tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')
            {
                FormInput(sender, e);
                e.Handled = true;
            }
        }
        private void FormInput(object sender, KeyPressEventArgs e)
        {
            if (!(sender is TextBox)) return;
            TextBox tb = (TextBox)sender;

            if (Char.IsDigit(e.KeyChar))
            {
                tb.Text += e.KeyChar;
            }
        }
        private string PrintArray(int[][] arr)
        {
            if (isEmpty(arr)) return "Массив пуст";
            string str = "";
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    str += arr[i][j] + " ";
                }
                str += "\n";
            }
            if (str == "") str += "Массив пуст";
            return str;
        }
        private string PrintArray(int[,] arr)
        {
            if (isEmpty(arr)) return "Массив пуст";
            string str = "";
            int max = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j].ToString().Length > max) max = arr[i, j].ToString().Length;
                }
            }

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    str += arr[i, j] + " ";
                    for (int k = 0; k < max - arr[i, j].ToString().Length; k++) str += " ";
                }
                str += "\n";
            }
            if (str == "") str += "Массив пуст";
            return str;
        }
        private string PrintArray(int[] arr)
        {
            if (isEmpty(arr)) return "Массив пуст";
            string str = "";
            for (int i = 0; i < arr.Length; i++)
                str += arr[i] + " ";
            str += "\n";
            if (str == "") str += "Массив пуст";
            return str;
        }
        private void Size2_tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')
            {
                FormInput(sender, e);
                e.Handled = true;
            }
        }

        private void add_elms_Click(object sender, EventArgs e)
        {
            bool toBegin = !to_begin.Checked, done;
            //if (this.to_begin.Checked == true) toBegin = false; else toBegin = true;
            int[] arrT = null;
            done = ManualComplete(ref arrT, input_tb);
            if (done)
            {
                addArray(ref arr1, arrT, toBegin);
                ShowError("Элементы добавлены");
                output_tb.Text = PrintArray(arr1);
            }
        }
        private bool isEmpty(TextBox t)
        {
            if (t.Text == "") return true;
            else return false;
        }
        private void OneOrMany(int ind)
        {
            switch (ind)
            {
                case 0:
                    pos2_label.Visible = false;
                    pos2_tb.Visible = false;
                    pos1_label.Visible = false;
                    pos1_tb.Visible = false;
                    break;
                case 1:
                    pos2_label.Visible = false;
                    pos2_tb.Visible = false;
                    pos1_label.Text = "Позиция";
                    pos1_label.Visible = true;
                    pos1_tb.Visible = true;

                    break;
                case 2:
                    pos2_label.Visible = true;
                    pos2_tb.Visible = true;
                    pos1_label.Text = "Начальный";
                    pos1_label.Visible = true;
                    pos1_tb.Visible = true;
                    break;
            }
        }
        private void pos1_tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')
            {
                FormInput(sender, e);
                e.Handled = true;
            }
        }

        private void pos2_tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')
            {
                FormInput(sender, e);
                e.Handled = true;
            }
        }

        private void del_one_CheckedChanged(object sender, EventArgs e)
        {
            if (del_one.Checked) OneOrMany(1); else OneOrMany(2);
        }

        private void del_many_CheckedChanged(object sender, EventArgs e)
        {
            // if (del_one.Checked) OneOrMany(2);
        }

        private void del_button_Click(object sender, EventArgs e)
        {
            bool s = true;
            if (rows_button.Checked)
            {
                if (del_one.Checked)
                {
                    s = delRow(ref arr2);
                    if (s)
                    {
                        ShowError("Строка удалены");
                        UpdateRes();
                    }
                }
                else
                {
                    s = delSomeRows(ref arr2);
                    if (s)
                    {
                        ShowError("Строки удалены");
                        UpdateRes();
                    }
                }
            }
            else
            {
                if (del_one.Checked)
                {
                    s = delColumn(ref arr2);
                    if (s)
                    {
                        ShowError("Столбец удалены");
                        UpdateRes();
                    }
                }
                else
                {
                    s = delSomeColumns(ref arr2);
                    if (s)
                    {
                        ShowError("Столбцы удалены");
                        UpdateRes();
                    }
                }
            }
        }
        private void UpdateRes()
        {
            UpdateOutput();
        }
        private bool delSomeRows(ref int[,] arr)
        {
            if (arr == null) { ShowError("Массив пуст"); return false; }
            if (pos1_tb.Text == "" || pos2_tb.Text == "") { ShowError("Неверный диапазон"); return false; }
            if (GetSize(pos1_tb) < 1 || GetSize(pos2_tb) < 1 || GetSize(pos2_tb) > arr.GetLength(1) || GetSize(pos1_tb) > arr.GetLength(1)) { ShowError("Неверный диапазон"); return false; }
            UnShowError();
            int r1 = GetSize(pos1_tb) - 1, r2 = GetSize(pos2_tb) - 1, counter = 0;
            //Console.Clear();
            //choose("Выберите начальную строку для удаления (выбор пр помощи стрелок)", arr, out r1, out column);
            // choose("Выберите конечную строку для удаления  (выбор пр помощи стрелок)", arr, out r2, out column);
            if (r1 > r2) { int tmp = r2; r2 = r1; r1 = tmp; }

            int[,] res = new int[arr.GetLength(0) - (r2 - r1 + 1), arr.GetLength(1)];
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                if (i >= r1 && i <= r2) continue;
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    res[counter, j] = arr[i, j];
                }
                counter++;
            }
            arr = res;
            return true;
        }
        private bool delSomeColumns(ref int[,] arr)
        {
            if (arr == null) { ShowError("Массив пуст"); return false; }
            if (pos1_tb.Text == "" || pos2_tb.Text == "") { ShowError("Неверный диапазон"); return false; }
            if (GetSize(pos1_tb) < 1 || GetSize(pos2_tb) < 1 || GetSize(pos2_tb) > arr.GetLength(1) || GetSize(pos1_tb) > arr.GetLength(1)) { ShowError("Неверный диапазон"); return false; }
            UnShowError();

            int c1 = GetSize(pos1_tb) - 1, c2 = GetSize(pos2_tb) - 1, counter = 0;

            //Console.Clear();
            // choose("Выберите начальный столбец для удаления (выбор пр помощи стрелок)", arr, out row, out c1);
            // choose("Выберите конечный столбец для удаления  (выбор пр помощи стрелок)", arr, out row, out c2);

            if (c1 > c2) { int tmp = c2; c2 = c1; c1 = tmp; }

            int[,] res = new int[arr.GetLength(0), arr.GetLength(1) - (c2 - c1 + 1)];

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (j >= c1 && j <= c2) continue;
                    res[i, counter] = arr[i, j];
                    counter++;
                }
                counter = 0;
            }
            arr = res;
            return true;
        }
        private bool delRow(ref int[,] arr)
        {
            if (arr == null) { ShowError("Массив пуст"); return false; }
            if (pos1_tb.Text == "") { ShowError("Неверная позиция"); return false; }
            if (GetSize(pos1_tb) < 1 || GetSize(pos1_tb) > arr.GetLength(0)) { ShowError("Неверная позиция"); return false; }
            UnShowError();
            int n = GetSize(pos1_tb) - 1;
            int counter = 0;
            int[,] res = new int[arr.GetLength(0) - 1, arr.GetLength(1)];

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                if (i == n) continue;
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    res[counter, j] = arr[i, j];
                }
                counter++;
            }
            arr = res;
            return true;
        }
        private bool delColumn(ref int[,] arr)
        {
            if (arr == null) { ShowError("Массив пуст"); return false; }
            if (pos1_tb.Text == "") { ShowError("Неверная позиция"); return false; }
            if (GetSize(pos1_tb) < 1 || GetSize(pos1_tb) > arr.GetLength(0)) { ShowError("Неверная позиция"); return false; }
            UnShowError();
            int n = GetSize(pos1_tb) - 1;
            int counter = 0;
            int[,] res = new int[arr.GetLength(0), arr.GetLength(1) - 1];

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (j == n) continue;
                    res[i, counter] = arr[i, j];
                    counter++;
                }
                counter = 0;
            }
            arr = res;
            return true;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')
            {
                FormInput(sender, e);
                e.Handled = true;
            }
        }
        private void delRow(ref int[][] arr)
        {
            if (arr == null) return;
            if (arr.Length == 0) return;
            int[][] res = new int[arr.Length - 1][];
            for (int i = 0; i < arr.Length - 1; i++)
                res[i] = arr[i];
            arr = res;
        }
        private void AddRow(ref int[][] arr)
        {
            // Random rand = new Random();
            if (arr == null) arr = new int[0][];
            int[][] res = new int[arr.Length + 1][];
            for (int i = 0; i < arr.Length; i++)
                res[i + 1] = arr[i];
            res[0] = new int[rand.Next(5, 15)];
            for (int i = 0; i < res[0].Length; i++)
                res[0][i] = rand.Next(10, 99);
            arr = res;
        }
        private bool addNumRow(ref int[][] arr)
        {
            if (arr == null) { arr = new int[1][]; }
            if (torn_pos.Text == "") { ShowError("Неверная позиция"); return false; }
            int n = GetSize(torn_pos) - 1;
            if (n < 0 || n >= arr.GetLength(0) + 1) { ShowError("Неверная позиция"); return false; }
            UnShowError();

            // if (GetSize(torn_pos) > 0) n = GetSize(torn_pos); else n = GetSize(torn_pos);

            int[][] res = new int[arr.Length + 1][];
            res[n] = new int[rand.Next(5, 15)];

            for (int i = 0; i < res[n].Length; i++)
                res[n][i] = rand.Next(10, 99);

            for (int i = 0; i < n; i++)
                res[i] = arr[i];

            for (int i = n; i < arr.Length; i++)
                res[i + 1] = arr[i];
            arr = res;
            return true;
        }

        private void torn_add_row_Click(object sender, EventArgs e)
        {
            AddRow(ref arr3);
            output_tb.Text = PrintArray(arr3);
        }

        private void torn_del_row_Click(object sender, EventArgs e)
        {
            delRow(ref arr3);
            output_tb.Text = PrintArray(arr3);
        }

        private void torn_add_num_Click(object sender, EventArgs e)
        {
            bool s = addNumRow(ref arr3);

            if (s) output_tb.Text = PrintArray(arr3);
        }
        private void saveArr()
        {
            // FileStream file = File.Open("file.txt", FileMode.Truncate);
            // file.Close();
            bool s = true;
            switch (arrayType.SelectedIndex)
            {
                case 0:
                    s = saveArr(arr1);
                    break;
                case 1:
                    s = saveArr(arr2);
                    break;
                case 2:
                    s = saveArr(arr3);
                    break;
            }
            if (s) ShowError("Массив сохранен");
        }
        private bool saveArr(int[] arr)
        {

            //System.IO.StreamWriter file = new System.IO.StreamWriter("file.txt", false);
            if (isEmpty(arr)) { ShowError("Нечего сохранять"); return false; }
            using (StreamWriter fout = new StreamWriter("file1.txt", false))
            {
                if (isEmpty(arr))
                {
                    fout.WriteLine(0);
                    fout.WriteLine();
                }
                else
                {
                    fout.WriteLine(arr.Length);
                    foreach (int i in arr)
                    {
                        fout.Write(i);
                        fout.Write(" ");
                    }
                    fout.WriteLine();
                }
            }
            return true;
        }
        private bool saveArr(int[,] arr)
        {
            if (isEmpty(arr)) { ShowError("Нечего сохранять"); return false; }
            using (StreamWriter fout = new StreamWriter("file2.txt", false))
            {
                if (isEmpty(arr))
                {
                    fout.WriteLine(0);
                }
                else
                {
                    fout.Write(arr.GetLength(0));
                    fout.Write(" ");
                    fout.Write(arr.GetLength(1));
                    fout.WriteLine();
                    for (int i = 0; i < arr.GetLength(0); i++)
                    {
                        for (int j = 0; j < arr.GetLength(1); j++)
                        {
                            fout.Write(arr[i, j]);
                            fout.Write(" ");
                        }
                        fout.WriteLine();
                    }
                }
            }
            return true;
        }
        private bool saveArr(int[][] arr)
        {
            if (isEmpty(arr)) { ShowError("Нечего сохранять"); return false; }
            using (StreamWriter fout = new StreamWriter("file3.txt", false))
            {
                if (isEmpty(arr))
                {
                    fout.WriteLine(0);
                }
                else
                {
                    fout.WriteLine(arr.Length);

                    for (int i = 0; i < arr.Length; i++)
                    {
                        for (int j = 0; j < arr[i].Length; j++)
                        {
                            fout.Write(arr[i][j]);
                            fout.Write(" ");
                        }
                        fout.WriteLine();
                    }
                }
            }
            return true;
        }
        private void loadArr()
        {
            switch (arrayType.SelectedIndex)
            {
                case 0:
                    loadArr(ref arr1);
                    break;
                case 1:
                    loadArr(ref arr2);
                    break;
                case 2:
                    loadArr(ref arr3);
                    break;
            }
            UpdateOutput();
            ShowError("Массив загружен");
        }
        private void UpdateOutput()
        {
            switch (arrayType.SelectedIndex)
            {
                case 0:
                    output_tb.Text = PrintArray(arr1);
                    if (!isEmpty(arr1))
                        size1_tb.Text = arr1.Length.ToString();
                    break;
                case 1:
                    output_tb.Text = PrintArray(arr2);
                    //output_tb.Text = PrintArray(arr2);
                    if (!isEmpty(arr2))
                    {
                        size1_tb.Text = arr2.GetLength(0).ToString();
                        size2_tb.Text = arr2.GetLength(1).ToString();
                    }
                    break;
                case 2:
                    output_tb.Text = PrintArray(arr3);
                    if (!isEmpty(arr3))
                        size1_tb.Text = arr3.Length.ToString();
                    break;
            }
        }
        private void loadArr(ref int[] arr)
        {
            string str = "";
            using (StreamReader fin = new StreamReader("file1.txt"))
            {
                str = fin.ReadLine();
                if (str == "0")
                {
                    arr = new int[0];
                }
                else
                {
                    arr = new int[Int32.Parse(str)];
                    str = fin.ReadLine();
                    string[] nums = str.Split(' ');
                    for (int i = 0; i < nums.Length - 1; i++)
                        arr[i] = Int32.Parse(nums[i]);
                }
            }
        }
        private void loadArr(ref int[,] arr)
        {
            string str = "";
            //int tmp = 0;
            using (StreamReader fin = new StreamReader("file2.txt"))
            {
                // for (int i = 0; i < 3; i++)
                str = fin.ReadLine();
                string[] sizes = str.Split(' ');
                arr = new int[Int32.Parse(sizes[0]), Int32.Parse(sizes[1])];
                for (int i = 0; i < Int32.Parse(sizes[0]); i++)
                {
                    str = fin.ReadLine();
                    string[] nums = str.Split(' ');
                    for (int j = 0; j < nums.Length - 1; j++)
                        arr[i, j] = Int32.Parse(nums[j]);
                }
            }
        }
        private void loadArr(ref int[][] arr)
        {
            string str = "";
            int tmp = 0;
            using (StreamReader fin = new StreamReader("file3.txt"))
            {
                #region
                //  for (int i = 0; i < 3; i++)
                //     str = fin.ReadLine();
                //   if (str != "0")
                //   {
                //       string[] nums = str.Split(' ');
                //       tmp = Int32.Parse(nums[0]);
                //  }
                //  for (int i = 0; i < tmp+1; i++)
                #endregion
                str = fin.ReadLine();
                tmp = Int32.Parse(str);
                arr = new int[tmp][];
                for (int i = 0; i < tmp; i++)
                {
                    str = fin.ReadLine();
                    string[] nums = str.Split(' ');
                    arr[i] = new int[nums.Length - 1];
                    for (int j = 0; j < nums.Length - 1; j++)
                        arr[i][j] = Int32.Parse(nums[j]);
                }
            }
        }
        private bool isEmpty(int[] arr)
        {
            if (arr == null) return true;
            else if (arr.Length == 0) return true;
            else return false;
        }
        private bool isEmpty(int[,] arr)
        {
            if (arr == null) return true;
            else if (arr.Length == 0) return true;
            else return false;
        }
        private bool isEmpty(int[][] arr)
        {
            if (arr == null) return true;
            else if (arr.Length == 0) return true;
            else return false;
        }
        private void Save_Click(object sender, EventArgs e)
        {
            saveArr();
        }

        private void Load_Click(object sender, EventArgs e)
        {
            loadArr();
        }
    }
}
