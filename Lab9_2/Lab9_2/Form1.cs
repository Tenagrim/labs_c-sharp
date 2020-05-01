using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lab9_2
{
    public partial class Form1 : Form
    {
        public MoneyArray mArray = new MoneyArray();
        public Form1()
        {
            InitializeComponent();
        }
        #region staticFunctions
        public static Money Sum(Money a, Money b)
        {
            int nR = a.Rubles + b.Rubles;
            int nK = a.Kopeks + b.Kopeks;
            if (nK > 100) { nR += nK / 100; nK = nK % 100; }
            return new Money(nR, nK);
        }
        public Money Sub(Money a, Money b)
        {
            if (a < b) { ShowError("Не хватает денег"); return new Money(0, 0); }
            int nR = a.Rubles - b.Rubles;
            int nK = a.Kopeks - b.Kopeks;
            if (nK < 0) { nR -= nK / 100 + 1; nK += 100; }
            return new Money(nR, nK);
        }
        #endregion
        public void ShowError(string msg)
        {
            error_label.Text = msg;
            error_label.Visible = true;
        }
        public void UnShowError()
        {
            error_label.Text = "";
            error_label.Visible = false;
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
        private void CountObjects()
        {
            countLabel.Text = $"Использовано объектов: {Money.moneyCount}";
        }

        private void ShowRes(Money r, TextBox t1, TextBox t2)
        {
            t1.Text = r.Rubles.ToString();
            t2.Text = r.Kopeks.ToString();
        }
        private void _KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')
            {
                FormInput(sender, e);
                // e.Handled = true;
            }
        }
        private void IfEmpty()
        {
            if (inp1_kop_tb.Text == "") inp1_kop_tb.Text += "0";
            if (inp2_kop_tb.Text == "") inp2_kop_tb.Text += "0";
            if (inp1_rub_tb.Text == "") inp1_rub_tb.Text += "0";
            if (inp2_rub_tb.Text == "") inp2_rub_tb.Text += "0";
        }
        //private Money MakeMoney() 
        //{

        //}
        private void Sum()
        {
            Money a = null, b = null;
            CollectInputs(ref a, ref b);
            ShowRes(a, inp1_rub_tb, inp1_kop_tb);
            ShowRes(b, inp2_rub_tb, inp2_kop_tb);
            SwitcnSum(a, b);
            CountObjects();
        }
        private void SwitcnSum(Money a, Money b)
        {
            if (radioButton1.Checked)
            {
                ShowRes(a + b, res_rub_tb, res_kop_tb);
            }
            else if (radioButton2.Checked)
            {
                ShowRes(a.Sum(b), res_rub_tb, res_kop_tb);
            }
            else
            {
                ShowRes(Sum(a, b), res_rub_tb, res_kop_tb);
            }
        }
        private void SwitcnSub(Money a, Money b)
        {
            if (radioButton1.Checked)
            {
                ShowRes(a - b, res_rub_tb, res_kop_tb);
            }
            else if (radioButton2.Checked)
            {
                ShowRes(a.Sub(b), res_rub_tb, res_kop_tb);
            }
            else
            {
                ShowRes(Sub(a, b), res_rub_tb, res_kop_tb);
            }
        }
        private void Sub()
        {
            Money a = null, b = null;
            CollectInputs(ref a, ref b);
            // if (a < b) { ShowError("Не хватает денег"); return; }
            UnShowError();

            ShowRes(a, inp1_rub_tb, inp1_kop_tb);
            ShowRes(b, inp2_rub_tb, inp2_kop_tb);
            //ShowRes(a - b, res_rub_tb, res_kop_tb);
            try
            {
                SwitcnSub(a, b);
            }
            catch (NegativeValueException)
            {
                ShowError("Не хватает денег");
            }
            CountObjects();
        }
        private void CollectInputs(ref Money a, ref Money b)
        {
            IfEmpty();
            a = new Money(Int32.Parse(inp1_rub_tb.Text), Int32.Parse(inp1_kop_tb.Text));
            b = new Money(Int32.Parse(inp2_rub_tb.Text), Int32.Parse(inp2_kop_tb.Text));
        }
        private void CollectInputs(ref Money a)
        {
            if (inp21_kop_tb.Text == "") inp21_kop_tb.Text += "0";
            if (inp21_rub_tb.Text == "") inp21_rub_tb.Text += "0";
            a = new Money(Int32.Parse(inp21_rub_tb.Text), Int32.Parse(inp21_kop_tb.Text));
        }
        private void Incr()
        {
            Money a = null;
            CollectInputs(ref a);

            ShowRes(++a, inp21_rub_tb, inp21_kop_tb);

            CountObjects();
        }
        private void Decr()
        {
            Money a = null;
            CollectInputs(ref a);

            ShowRes(--a, inp21_rub_tb, inp21_kop_tb);

            CountObjects();
        }
        private void ToInt()
        {
            Money a = null;
            CollectInputs(ref a);
            ShowRes(a, inp21_rub_tb, inp21_kop_tb);
            CountObjects();

            to_int_tb.Text = ((int)a).ToString();
        }
        private void ToBool()
        {
            Money a = null;
            CollectInputs(ref a);
            ShowRes(a, inp21_rub_tb, inp21_kop_tb);
            CountObjects();

            bool b = a;
            to_bool_tb.Text = b.ToString();
        }
        private void IfEmpty(TextBox tb)
        {
            if (tb.Text == "") tb.Text += "0";
        }
        private int GetNumber(TextBox tb)
        {
            return Int32.Parse(tb.Text);
        }
        private void LeftPlus()
        {
            Money a = null;
            CollectInputs(ref a);
            IfEmpty(textBox1);
            int n = GetNumber(textBox1);

            ShowRes(a + n, inp21_rub_tb, inp21_kop_tb);
            CountObjects();
        }
        private void LeftMinus()
        {
            Money a = null;
            CollectInputs(ref a);
            IfEmpty(textBox2);
            int n = GetNumber(textBox2);
            try
            {
                ShowRes(a - n, inp21_rub_tb, inp21_kop_tb);
            }
            catch (NegativeValueException)
            {
                ShowError("Не хватает денег");
            }
            CountObjects();
        }
        private void RightPlus()
        {
            Money a = null;
            CollectInputs(ref a);
            IfEmpty(textBox4);
            int n = GetNumber(textBox4);

            ShowRes(n + a, inp21_rub_tb, inp21_kop_tb);
            CountObjects();
        }
        private void RightMinus()
        {
            Money a = null;
            CollectInputs(ref a);
            IfEmpty(textBox3);
            int n = GetNumber(textBox3);
            try
            {
                ShowRes(n - a, inp21_rub_tb, inp21_kop_tb);
            }
            catch (NegativeValueException)
            {
                ShowError("Не хватает денег");
            }
            CountObjects();
        }
        public void PushOne()
        {
            Money a = null;
            if (inp3_kop_tb.Text == "") inp3_kop_tb.Text += "0";
            if (inp3_rub_tb.Text == "") inp3_rub_tb.Text += "0";
            a = new Money(Int32.Parse(inp3_rub_tb.Text), Int32.Parse(inp3_kop_tb.Text));
            mArray.Add(a);

            listBox1.Items.Add($"{a.Rubles} руб. {a.Kopeks} коп.");
            ShowRes(a, inp3_rub_tb, inp3_kop_tb);

            CountObjects();
        }
        private void UpdateList() 
        {
            listBox1.Items.Clear();
            foreach (Money a in mArray) 
            {
                listBox1.Items.Add($"{a.Rubles} руб. {a.Kopeks} коп.");
            }
        }
        public void CreateNewRandom()
        {
            if (textBox5.Text != "")
            {
                int size = GetNumber(textBox5);
                if (size >= 0)
                {
                    mArray = new MoneyArray(size);
                    UpdateList();
                    CountObjects();
                }
                else ShowError("Неверная размерность");
            }
            else ShowError("Введите количество элементов");
        }
        private void CalcAver() 
        {
            Money a = mArray.Average();
            textBox6.Text = $"{a.Rubles} руб. {a.Kopeks} коп.";
        }
        private void inp1_rub_tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            _KeyPress(sender, e);
        }

        private void inp1_cop_tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            _KeyPress(sender, e);
        }

        private void inp2_rub_tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            _KeyPress(sender, e);
        }

        private void inp2_kop_tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            _KeyPress(sender, e);
        }

        private void plus_Click(object sender, EventArgs e)
        {
            Sum();
        }
        private void Minus_Click(object sender, EventArgs e)
        {
            Sub();
        }
        private void incr_button_Click(object sender, EventArgs e)
        {
            Incr();
        }

        private void decr_button_Click(object sender, EventArgs e)
        {
            Decr();
        }

        private void to_int_button_Click(object sender, EventArgs e)
        {
            ToInt();
        }

        private void to_bool_button_Click(object sender, EventArgs e)
        {
            ToBool();
        }

        private void inp21_rub_tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            _KeyPress(sender, e);
        }

        private void inp21_kop_tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            _KeyPress(sender, e);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            _KeyPress(sender, e);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            _KeyPress(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LeftPlus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LeftMinus();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RightPlus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RightMinus();
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            UnShowError();
        }

        private void push_button_Click(object sender, EventArgs e)
        {
            PushOne();
        }

        private void inp3_rub_tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            _KeyPress(sender, e);
        }

        private void inp3_kop_tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            _KeyPress(sender, e);
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            _KeyPress(sender, e);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CreateNewRandom();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
                ShowRes(mArray[listBox1.SelectedIndex], inp3_rub_tb, inp3_kop_tb);
        }

        private void calc_aver_button_Click(object sender, EventArgs e)
        {
            CalcAver();
        }
    }

}
