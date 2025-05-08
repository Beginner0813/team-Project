﻿using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 미니_프로젝트
{
    public partial class Form1 : Form
    {

        double firstNumber = 0;
        string operation = "";
        bool newInput = false;
        private string calculationHistory = "";


        private enum Operator
        {
            None,
            Add,
            Subtract,
            Multiply,
            Divide,
            Percent,
            Root,
            Dooble,
            Divide2,
            Dot

        }

        private double number1 = 0;
        private double number2 = 0;
        private Operator operator_type = Operator.None;
        private bool isNewNumber = true;
        public Form1()
        {
            InitializeComponent();
            textBox_Normal_Print.Text = "0";

            //공학용 계산기 버튼에 텍스트 입력
            #region
            button1.Text = "2\u207F\u1D48";
            button2.Text = "\u03C0";
            button3.Text = "e";
            button4.Text = "C";
            button5.Text = "<-";

            button6.Text = "x\u00B2";
            button7.Text = "1/x";
            button8.Text = "|x|";
            button9.Text = "exp";
            button10.Text = "mod";

            button11.Text = "²\u221A x";
            button12.Text = "(";
            button13.Text = ")";
            button14.Text = "n!";
            button15.Text = "\u00F7";

            button16.Text = "x\u1D6E";
            button17.Text = "7";
            button18.Text = "8";
            button19.Text = "9";
            button20.Text = "\u00D7";

            button21.Text = "10\u1D65";
            button22.Text = "4";
            button23.Text = "5";
            button24.Text = "6";
            button25.Text = "-";

            button26.Text = "log";
            button27.Text = "1";
            button28.Text = "2";
            button29.Text = "3";
            button30.Text = "+";

            button31.Text = "ln";
            button32.Text = "+/-";
            button33.Text = "0";
            button34.Text = ".";
            button35.Text = "=";
            #endregion

            //날짜 계산기 버튼에 텍스트 입력
            #region
            button_Angle_1.Text = "+/-";
            button_Angle_2.Text = "0";
            button_Angle_3.Text = ".";

            button_Angle_4.Text = "1";
            button_Angle_5.Text = "2";
            button_Angle_6.Text = "3";

            button_Angle_7.Text = "4";
            button_Angle_8.Text = "5";
            button_Angle_9.Text = "6";

            button_Angle_10.Text = "7";
            button_Angle_11.Text = "8";
            button_Angle_12.Text = "9";

            button_Angle_13.Text = "CE";
            button_Angle_14.Text = "<-";

            #endregion

            //길이 계산기 버튼에 텍스트 입력
            #region

            button_Length_1.Text = "+/-";
            button_Length_2.Text = "0";
            button_Length_3.Text = ".";

            button_Length_4.Text = "1";
            button_Length_5.Text = "2";
            button_Length_6.Text = "3";

            button_Length_7.Text = "4";
            button_Length_8.Text = "5";
            button_Length_9.Text = "6";

            button_Length_10.Text = "7";
            button_Length_11.Text = "8";
            button_Length_12.Text = "9";

            button_Length_13.Text = "CE";
            button_Length_14.Text = "<-";

            #endregion

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox_Normal_Print_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_Normal_Name_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_Normal_History_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_Normal_a_Click(object sender, EventArgs e)
        {
            if (operator_type != Operator.None)
            {

                double value = Convert.ToDouble(textBox_Normal_Print.Text);
                double percentValue = 0;
                switch (operator_type)
                {
                    case Operator.Add:
                        percentValue = number1 + (value/100);
                        break;
                    case Operator.Subtract:
                        percentValue = number1 - (value/100);
                        break;
                    case Operator.Multiply:
                        percentValue = number1 * (value / 100);
                        break;
                    case Operator.Divide:
                        if (number2 != 0)
                        percentValue = number1 / (value / 100);
                        else
                            MessageBox.Show("0으로 나눌 수 없습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        
                        return;
                        break;




                }
                textBox_Normal_Print.Text = percentValue.ToString();
                number2 = percentValue;

                calculationHistory += value.ToString() + "% = " + percentValue.ToString();
                textBox_Normal_History.Text += "\r\n" + calculationHistory;

                newInput = true;
            }
            else
            {
                double value = Convert.ToDouble(textBox_Normal_Print.Text);
                double percentValue = value / 100;
                textBox_Normal_Print.Text = percentValue.ToString();
                number1 = percentValue;

                calculationHistory = value.ToString() + "% = " + percentValue.ToString();
                textBox_Normal_History.Text += "\r\n" + calculationHistory;

                newInput = true;
            }
        }

        private void button_Normal_b_Click(object sender, EventArgs e)
        {
            textBox_Normal_Print.Text = "0";
            textBox_Normal_History.Text = "";
            calculationHistory = "";
            number1 = 0;
            number2 = 0;
            operator_type = Operator.None;
            newInput = false;
        }

        private void button_Normal_c_Click(object sender, EventArgs e)
        {
            textBox_Normal_Print.Text = "0";
            calculationHistory = "";
            number1 = 0;
            number2 = 0;
            operator_type = Operator.None;
            newInput = false;
        }
        private void button_Normal_Trash_Click(object sender, EventArgs e)
        {
            calculationHistory = "";
            textBox_Normal_History.Text = "";
            operator_type = Operator.None;
            newInput = false;
        }
        private void button_Normal_d_Click(object sender, EventArgs e)
        {
             
            if (textBox_Normal_Print.Text.Length > 0)  // 문자열이 비어 있지 않으면
            {
                textBox_Normal_Print.Text = textBox_Normal_Print.Text.Substring(0, textBox_Normal_Print.Text.Length - 1);  // 마지막 문자 제거
            }
        }

        private void button_Normal_e_Click(object sender, EventArgs e)
        {
            if (operator_type != Operator.None)
            {

                double value = Convert.ToDouble(textBox_Normal_Print.Text);
                double percentValue = 0;
                switch (operator_type)
                {
                    case Operator.Add:
                        percentValue = number1 + (1/value);
                        break;
                    case Operator.Subtract:
                        percentValue = number1 - (1/value);
                        break;
                    case Operator.Multiply:
                        percentValue = number1 * (1/value);
                        break;
                    case Operator.Divide:
                        if (number2 != 0)
                            percentValue = number1 / (1/value);
                        else
                            MessageBox.Show("0으로 나눌 수 없습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return;
                        break;




                }
                textBox_Normal_Print.Text = percentValue.ToString();
                number2 = percentValue;

                calculationHistory +=  "1/" + value.ToString() + " = " + percentValue.ToString();
                textBox_Normal_History.Text += "\r\n" + calculationHistory;

                newInput = true;
            }
            else
            {
                double value = Convert.ToDouble(textBox_Normal_Print.Text);
                double percentValue = 1 / value;
                textBox_Normal_Print.Text = percentValue.ToString();
                number1 = percentValue;

                calculationHistory = "1/" + value.ToString() + " = " + percentValue.ToString();
                textBox_Normal_History.Text += "\r\n" + calculationHistory;

                newInput = true;
            }
        }

        private void button_Normal_f_Click(object sender, EventArgs e)
        {
            if (operator_type != Operator.None)
            {

                double value = Convert.ToDouble(textBox_Normal_Print.Text);
                double percentValue = 0;
                switch (operator_type)
                {
                    case Operator.Add:
                        percentValue = number1 + (value * value);
                        break;
                    case Operator.Subtract:
                        percentValue = number1 - (value * value);
                        break;
                    case Operator.Multiply:
                        percentValue = number1 * (value * value);
                        break;
                    case Operator.Divide:
                        if (number2 != 0)
                            percentValue = number1 / (value * value);
                        else
                            MessageBox.Show("0으로 나눌 수 없습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return;
                        break;




                }
                textBox_Normal_Print.Text = percentValue.ToString();
                number2 = percentValue;

                calculationHistory += value.ToString() + "² = " + percentValue.ToString();
                textBox_Normal_History.Text += "\r\n" + calculationHistory;

                newInput = true;
            }
            else
            {
                double value = Convert.ToDouble(textBox_Normal_Print.Text);
                double percentValue = value * value;
                textBox_Normal_Print.Text = percentValue.ToString();
                number1 = percentValue;

                calculationHistory = value.ToString() + "² = " + percentValue.ToString();
                textBox_Normal_History.Text += "\r\n" + calculationHistory;

                newInput = true;
            }
        }

        private void button_Normal_g_Click(object sender, EventArgs e)
        {
            if (operator_type != Operator.None)
            {

                double value = Convert.ToDouble(textBox_Normal_Print.Text);
                double percentValue = 0;
                switch (operator_type)
                {
                    case Operator.Add:
                        percentValue = number1 + (Math.Sqrt(value));
                        break;
                    case Operator.Subtract:
                        percentValue = number1 - (Math.Sqrt(value));
                        break;
                    case Operator.Multiply:
                        percentValue = number1 * (Math.Sqrt(value));
                        break;
                    case Operator.Divide:
                        if (number2 != 0)
                            percentValue = number1 / (Math.Sqrt(value));
                        else
                            MessageBox.Show("0으로 나눌 수 없습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return;
                        break;




                }
                textBox_Normal_Print.Text = percentValue.ToString();
                number2 = percentValue;

                calculationHistory += "√" + value.ToString() + " = " + percentValue.ToString();
                textBox_Normal_History.Text += "\r\n" + calculationHistory;

                newInput = true;
            }
            else
            {
                double value = Convert.ToDouble(textBox_Normal_Print.Text);
                double percentValue = Math.Sqrt(value);
                textBox_Normal_Print.Text = percentValue.ToString();
                number1 = percentValue;

                calculationHistory = "√" + value.ToString() + " = " + percentValue.ToString();
                textBox_Normal_History.Text += "\r\n" + calculationHistory;

                newInput = true;
            }
        }

        private void button_Normal_h_Click(object sender, EventArgs e)
        {
            newInput = true;

            if (!string.IsNullOrEmpty(textBox_Normal_Print.Text))
            {
                number1 = Convert.ToDouble(textBox_Normal_Print.Text);
            }

            Button button = (Button)sender;
            string buttonText = button.Text;

            calculationHistory = number1.ToString() + " " + buttonText + " ";
            textBox_Normal_Print.Text += buttonText;

            switch (buttonText)
            {
                case "➕":
                    operator_type = Operator.Add;
                    break;
                case "➖":
                    operator_type = Operator.Subtract;
                    break;
                case "✖️":
                    operator_type = Operator.Multiply;
                    break;
                case "➗":
                    operator_type = Operator.Divide;
                    break;
                case "x²":
                    operator_type = Operator.Dooble;
                    break;
                case "√x":
                    operator_type = Operator.Root;
                    break;
                case "%":
                    operator_type = Operator.Percent;
                    break;
                case "1/x":
                    operator_type = Operator.Divide2;
                    break;
                
                    
            }
        }

        private void button_Normal_7_Click(object sender, EventArgs e)
        {
            if (textBox_Normal_Print.Text == "0" || newInput)
            {
                textBox_Normal_Print.Text = "7";
                newInput = false;
            }
            else
            {
                textBox_Normal_Print.Text = textBox_Normal_Print.Text + "7";
            }
        }

        private void button_Normal_8_Click(object sender, EventArgs e)
        {
            if (textBox_Normal_Print.Text == "0" || newInput)
            {
                textBox_Normal_Print.Text = "8";
                newInput = false;
            }
            else
            {
                textBox_Normal_Print.Text = textBox_Normal_Print.Text + "8";
            }
        }

        private void button_Normal_9_Click(object sender, EventArgs e)
        {
            if (textBox_Normal_Print.Text == "0" || newInput)
            {
                textBox_Normal_Print.Text = "9";
                newInput = false;
            }
            else
            {
                textBox_Normal_Print.Text = textBox_Normal_Print.Text + "9";
            }
        }

        private void button_Normal_i_Click(object sender, EventArgs e)
        {
            newInput = true;

            if (!string.IsNullOrEmpty(textBox_Normal_Print.Text))
            {
                number1 = Convert.ToDouble(textBox_Normal_Print.Text);
            }

            Button button = (Button)sender;
            string buttonText = button.Text;

            calculationHistory = number1.ToString() + " " + buttonText + " ";
            textBox_Normal_Print.Text += buttonText;


            switch (buttonText)
            {
                case "➕":
                    operator_type = Operator.Add;
                    break;
                case "➖":
                    operator_type = Operator.Subtract;
                    break;
                case "✖️":
                    operator_type = Operator.Multiply;
                    break;
                case "➗":
                    operator_type = Operator.Divide;
                    break;
                case "x²":
                    operator_type = Operator.Dooble;
                    break;
                case "√x":
                    operator_type = Operator.Root;
                    break;
                case "%":
                    operator_type = Operator.Percent;
                    break;
                case "1/x":
                    operator_type = Operator.Divide2;
                    break;


            }
        }

        private void button_Normal_4_Click(object sender, EventArgs e)
        {
            if (textBox_Normal_Print.Text == "0" || newInput)
            {
                textBox_Normal_Print.Text = "4";
                newInput = false;
            }
            else
            {
                textBox_Normal_Print.Text = textBox_Normal_Print.Text + "4";
            }
        }

        private void button_Normal_5_Click(object sender, EventArgs e)
        {
            if (textBox_Normal_Print.Text == "0" || newInput)
            {
                textBox_Normal_Print.Text = "5";
                newInput = false;
            }
            else
            {
                textBox_Normal_Print.Text = textBox_Normal_Print.Text + "5";
            }
        }

        private void button_Normal_6_Click(object sender, EventArgs e)
        {
            if (textBox_Normal_Print.Text == "0" || newInput)
            {
                textBox_Normal_Print.Text = "6";
                newInput = false;
            }
            else
            {
                textBox_Normal_Print.Text = textBox_Normal_Print.Text + "6";
            }
        }

        private void button_Normal_j_Click(object sender, EventArgs e)
        {
            newInput = true;

            if (!string.IsNullOrEmpty(textBox_Normal_Print.Text))
            {
                number1 = Convert.ToDouble(textBox_Normal_Print.Text);
            }

            Button button = (Button)sender;
            string buttonText = button.Text;

            calculationHistory = number1.ToString() + " " + buttonText + " ";
            textBox_Normal_Print.Text += buttonText;


            switch (buttonText)
            {
                case "➕":
                    operator_type = Operator.Add;
                    break;
                case "➖":
                    operator_type = Operator.Subtract;
                    break;
                case "✖️":
                    operator_type = Operator.Multiply;
                    break;
                case "➗":
                    operator_type = Operator.Divide;
                    break;
                case "x²":
                    operator_type = Operator.Dooble;
                    break;
                case "√x":
                    operator_type = Operator.Root;
                    break;
                case "%":
                    operator_type = Operator.Percent;
                    break;
                case "1/x":
                    operator_type = Operator.Divide2;
                    break;



            }
        }

        private void button_Normal_1_Click(object sender, EventArgs e)
        {
            if (textBox_Normal_Print.Text == "0" || newInput)
            {
                textBox_Normal_Print.Text = "1";
                newInput = false;
            }
            else
            {
                textBox_Normal_Print.Text = textBox_Normal_Print.Text + "1";
            }
        }

        private void button_Normal_2_Click(object sender, EventArgs e)
        {
            if (textBox_Normal_Print.Text == "0" || newInput)
            {
                textBox_Normal_Print.Text = "2";
                newInput = false;
            }
            else
            {
                textBox_Normal_Print.Text = textBox_Normal_Print.Text + "2";
            }
        }

        private void button_Normal_3_Click(object sender, EventArgs e)
        {
            if (textBox_Normal_Print.Text == "0" || newInput)
            {
                textBox_Normal_Print.Text = "3";
                newInput = false;
            }
            else
            {
                textBox_Normal_Print.Text = textBox_Normal_Print.Text + "3";
            }
        }

        private void button_Normal_k_Click(object sender, EventArgs e)
        {
            newInput = true;

            if (!string.IsNullOrEmpty(textBox_Normal_Print.Text))
            {
                number1 = Convert.ToDouble(textBox_Normal_Print.Text);
            }

            Button button = (Button)sender;
            string buttonText = button.Text;

            calculationHistory = number1.ToString() + " " + buttonText + " ";
            textBox_Normal_Print.Text += buttonText;


            switch (buttonText)
            {
                case "➕":
                    operator_type = Operator.Add;
                    break;
                case "➖":
                    operator_type = Operator.Subtract;
                    break;
                case "✖️":
                    operator_type = Operator.Multiply;
                    break;
                case "➗":
                    operator_type = Operator.Divide;
                    break;
                case "x²":
                    operator_type = Operator.Dooble;
                    break;
                case "√x":
                    operator_type = Operator.Root;
                    break;
                case "%":
                    operator_type = Operator.Percent;
                    break;
                case "1/x":
                    operator_type = Operator.Divide2;
                    break;


            }
        }

        private void button_Normal_m_Click(object sender, EventArgs e)
        {
            if (operator_type != Operator.None)
            {

                double value = Convert.ToDouble(textBox_Normal_Print.Text);
                double percentValue = 0;
                switch (operator_type)
                {
                    case Operator.Add:
                        percentValue = number1 + (- value);
                        break;
                    case Operator.Subtract:
                        percentValue = number1 - (-value);
                        break;
                    case Operator.Multiply:
                        percentValue = number1 * (-value);
                        break;
                    case Operator.Divide:
                        if (number2 != 0)
                            percentValue = number1 / (-value);
                        else
                            MessageBox.Show("0으로 나눌 수 없습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return;
                        break;




                }
                textBox_Normal_Print.Text = percentValue.ToString();
                number2 = percentValue;

                calculationHistory += "-" + value.ToString() + " = " + percentValue.ToString();
                textBox_Normal_History.Text += "\r\n" + calculationHistory;

                newInput = true;
            }
            else
            {
                double value = Convert.ToDouble(textBox_Normal_Print.Text);
                double percentValue = -value;
                textBox_Normal_Print.Text = percentValue.ToString();
                number1 = percentValue;

                calculationHistory = "-" + value.ToString() + " = " + percentValue.ToString();
                textBox_Normal_History.Text += "\r\n" + calculationHistory;

                newInput = true;
            }
        }

        private void button_Normal_n_Click(object sender, EventArgs e)
        {
            if (textBox_Normal_Print.Text == "0" || newInput)
            {
                textBox_Normal_Print.Text = "0";
                newInput = false;
            }
            else
            {
                textBox_Normal_Print.Text = textBox_Normal_Print.Text + "0";
            }
        }

        private void button_Normal_o_Click(object sender, EventArgs e)
        {
            if (textBox_Normal_Print.Text == "0" || newInput)
            {
                textBox_Normal_Print.Text = ".";
                newInput = false;
            }
            else
            {
                textBox_Normal_Print.Text = textBox_Normal_Print.Text + ".";
            }
        }

        private void button_Normal_p_Click(object sender, EventArgs e)
        {
            if (!newInput)
            {
                number2 = Convert.ToDouble(textBox_Normal_Print.Text);
                calculationHistory += number2.ToString();

                double result = 0;

                switch (operator_type)
                {
                    case Operator.Add:
                        result = number1 + number2;
                        break;
                    case Operator.Subtract:
                        result = number1 - number2;
                        break;
                    case Operator.Multiply:
                        result = number1 * number2;
                        break;
                    case Operator.Divide:
                        if (number2 != 0)
                            result = number1 / number2;
                        else
                            MessageBox.Show("0으로 나눌 수 없습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                   
                        
                
                
                
                }

                textBox_Normal_Print.Text = result.ToString();
                string newHistoryEntry = calculationHistory + " = " + result.ToString();
                textBox_Normal_History.Text = newHistoryEntry + Environment.NewLine + textBox_Normal_History.Text;

                // 계산 후 초기화
                operator_type = Operator.None;
                newInput = true;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox_Date_Diff_TextChanged(object sender, EventArgs e)
        {
            DateTime start = dateTimePicker1.Value.Date;
            DateTime end = dateTimePicker2.Value.Date;

            TimeSpan diff = end - start;

            // 일 수만 표시
            textBox_Date_Diff.Text = Math.Abs(diff.Days).ToString() + "일 차이";
        }

        private void button_Date_Result_Click(object sender, EventArgs e)
        {
            DateTime start = dateTimePicker1.Value.Date;
            DateTime end = dateTimePicker2.Value.Date;

            TimeSpan diff = end - start;

            // 일 수만 표시
            textBox_Date_Diff.Text = Math.Abs(diff.Days).ToString() + "일 차이";
        }



        //공학용 계산기 버튼
        #region
        private async void button1_Click(object sender, EventArgs e)
        {
            textBox_Engine_Print.Text = "이 기능은 구현되지 못했습니다. \r\n 문구가 없어지면 숫자를 입력해주세요";

            //Thread.Sleep(5000);
            await Task.Delay(1500);

            textBox_Engine_Print.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox_Engine_Print.Text = Math.PI.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox_Engine_Print.Text = Math.Exp(1).ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox_Engine_Print.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox_Engine_Print.Text.Length > 0)  // 문자열이 비어 있지 않으면
            {
                textBox_Engine_Print.Text = textBox_Engine_Print.Text.Substring(0, textBox_Engine_Print.Text.Length - 1);  // 마지막 문자 제거
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            double result = 0;
            if (double.TryParse(textBox_Engine_Print.Text, out double num))
            {
                firstNumber = num;
                operation = "x²";
                result = Math.Pow(firstNumber, 2);
                textBox_Engine_Print.Text = result.ToString();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBox_Engine_Print.Text, out double num))
            {
                firstNumber = num;
                operation = "1/x";
                if (num != 0)
                {
                    num = 1 / num;
                    textBox_Engine_Print.Text = num.ToString();
                }
                else
                {
                    textBox_Engine_Print.Text = "0으로 나눌 수 없습니다";
                }
            }
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            if (double.TryParse(textBox_Engine_Print.Text, out double num))
            {
                firstNumber = num;
                num = Math.Abs(firstNumber);
                textBox_Engine_Print.Text = num.ToString();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBox_Engine_Print.Text, out double num))
            {
                firstNumber = num;
                operation = "exp";
                textBox_Engine_Print.Clear();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBox_Engine_Print.Text, out double num))
            {
                firstNumber = num;
                operation = "mod";
                textBox_Engine_Print.Clear();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            double result = 0;
            if (double.TryParse(textBox_Engine_Print.Text, out double num))
            {
                firstNumber = num;
                operation = "xᵮ";
                result = Math.Sqrt(firstNumber);
                textBox_Engine_Print.Text = result.ToString();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox_Engine_Print.Text = button12.Text;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox_Engine_Print.Text += button13.Text;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBox_Engine_Print.Text, out double num))
            {
                firstNumber = num;
                int result = 1;
                if (int.TryParse(textBox_Engine_Print.Text, out int process))
                {
                    for (int i = 1; i <= num; i++)
                    {
                        result *= i;
                    }
                    textBox_Engine_Print.Text = result.ToString();
                }
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBox_Engine_Print.Text, out double num))
            {
                firstNumber = num;
                operation = "÷";
                textBox_Engine_Print.Clear();
            }
        }

        private async void button16_Click(object sender, EventArgs e)
        {
            textBox_Engine_Print.Text = "이 기능은 구현되지 못했습니다. \r\n 문구가 없어지면 숫자를 입력해주세요";

            //Thread.Sleep(5000);
            await Task.Delay(3000);

            textBox_Engine_Print.Clear();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            textBox_Engine_Print.Text += button17.Text;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            textBox_Engine_Print.Text += button18.Text;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            textBox_Engine_Print.Text += button19.Text;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBox_Engine_Print.Text, out double num))
            {
                firstNumber = num;
                operation = "×";
                textBox_Engine_Print.Clear();

            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBox_Engine_Print.Text, out double num))
            {
                firstNumber = num;
                num = Math.Pow(10, num);
                textBox_Engine_Print.Text = num.ToString();
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            textBox_Engine_Print.Text += button22.Text;
        }

        private void button23_Click(object sender, EventArgs e)
        {
            textBox_Engine_Print.Text += button23.Text;
        }

        private void button24_Click(object sender, EventArgs e)
        {
            textBox_Engine_Print.Text += button24.Text;
        }

        private void button25_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBox_Engine_Print.Text, out double num))
            {
                firstNumber = num;
                operation = "-";
                textBox_Engine_Print.Clear();
            }
        }

        private async void button26_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBox_Engine_Print.Text, out double num))
            {
                firstNumber = num;
                if (num > 0)
                {
                    num = Math.Log10(num);
                    textBox_Engine_Print.Text = num.ToString();
                }
                else
                {
                    textBox_Engine_Print.Text = "값을 잘못 입력하셨습니다";

                    await Task.Delay(1000);

                    textBox_Engine_Print.Clear();
                }
            }
        }

        private void button27_Click(object sender, EventArgs e)
        {
            textBox_Engine_Print.Text += button27.Text;
        }

        private void button28_Click(object sender, EventArgs e)
        {
            textBox_Engine_Print.Text += button28.Text;
        }

        private void button29_Click(object sender, EventArgs e)
        {
            textBox_Engine_Print.Text += button29.Text;
        }

        private void button30_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBox_Engine_Print.Text, out double num))
            {
                firstNumber = num;  // 연산자가 클릭되면 firstNumber에 입력값 저장
                operation = "+";    // 연산자 설정
                textBox_Engine_Print.Clear();  // 새로운 숫자 입력 준비
            }
        }

        private async void button31_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBox_Engine_Print.Text, out double num))
            {
                firstNumber = num;
                if (num > 0)
                {
                    num = Math.Log(num);
                    textBox_Engine_Print.Text = num.ToString();
                }
                else
                {
                    textBox_Engine_Print.Text = "값을 잘못 입력하셨습니다";

                    await Task.Delay(1000);

                    textBox_Engine_Print.Clear();
                }
            }
        }

        private void button32_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBox_Engine_Print.Text, out double num))
            {
                firstNumber = num;
                num = -num;
                textBox_Engine_Print.Text = num.ToString();
            }
        }

        private void button33_Click(object sender, EventArgs e)
        {
            textBox_Engine_Print.Text += button33.Text;
        }

        private void button34_Click(object sender, EventArgs e)
        {
            textBox_Engine_Print.Text += button34.Text;
        }

        private void button35_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(textBox_Engine_Print.Text, out double secondNumber)) return;

            double result = 0;
            
            switch (operation)
            {
                case "+":
                    result = firstNumber + secondNumber;
                    calculationHistory = firstNumber.ToString() + "+" + secondNumber.ToString();
                    break;
                case "-":
                    result = firstNumber - secondNumber;
                    calculationHistory = firstNumber.ToString() + "-" + secondNumber.ToString();
                    break;
                case "×":
                    result = firstNumber * secondNumber;
                    calculationHistory = firstNumber.ToString() + "×" + secondNumber.ToString();
                    break;
                case "÷":
                    result = firstNumber / secondNumber;
                    calculationHistory = firstNumber.ToString() + "÷" + secondNumber.ToString();
                    break;
                case "mod":
                    result = firstNumber % secondNumber;
                    calculationHistory = firstNumber.ToString() + "Mod" + secondNumber.ToString();
                    break;
                case "exp":
                    result = firstNumber * Math.Pow(10, secondNumber);
                    calculationHistory = firstNumber.ToString() + "exp" + secondNumber.ToString();
                    break;
                case "1/x":
                    result = 1 / firstNumber;
                    calculationHistory = "1 / " + firstNumber.ToString();
                    break;


            }

            textBox_Engine_Print.Text = result.ToString();
            
            string newHistoryEntry = calculationHistory + " = " + result.ToString();
            textBox_Engine_History.Text = newHistoryEntry + Environment.NewLine + textBox_Engine_History.Text;
        }


        #endregion

        private void button_Delete_Click(object sender, EventArgs e)
        {
            textBox_Engine_History.Clear();
        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        #region

        private void button_Angle_1_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBox_Angle_Input.Text, out double num))
            {
                firstNumber = num;
                num = -num;
                textBox_Angle_Input.Text = num.ToString();
            }
        }

        private void button_Angle_2_Click(object sender, EventArgs e)
        {
            textBox_Angle_Input.Text += button_Angle_2.Text;
        }

        private void button_Angle_3_Click(object sender, EventArgs e)
        {
            textBox_Angle_Input.Text += button_Angle_3.Text;
        }

        private void button_Angle_4_Click(object sender, EventArgs e)
        {
            textBox_Angle_Input.Text += button_Angle_4.Text;
        }

        private void button_Angle_5_Click(object sender, EventArgs e)
        {
            textBox_Angle_Input.Text += button_Angle_5.Text;
        }

        private void button_Angle_6_Click(object sender, EventArgs e)
        {
            textBox_Angle_Input.Text += button_Angle_6.Text;
        }

        private void button_Angle_7_Click(object sender, EventArgs e)
        {
            textBox_Angle_Input.Text += button_Angle_7.Text;
        }

        private void button_Angle_8_Click(object sender, EventArgs e)
        {
            textBox_Angle_Input.Text += button_Angle_8.Text;
        }

        private void button_Angle_9_Click(object sender, EventArgs e)
        {
            textBox_Angle_Input.Text += button_Angle_9.Text;
        }

        private void button_Angle_10_Click(object sender, EventArgs e)
        {
            textBox_Angle_Input.Text += button_Angle_10.Text;
        }

        private void button_Angle_11_Click(object sender, EventArgs e)
        {
            textBox_Angle_Input.Text += button_Angle_11.Text;
        }

        private void button_Angle_12_Click(object sender, EventArgs e)
        {
            textBox_Angle_Input.Text += button_Angle_12.Text;
        }

        private void button_Angle_13_Click(object sender, EventArgs e)
        {
            textBox_Angle_Input.Clear();
        }

        private void button_Angle_14_Click(object sender, EventArgs e)
        {
            if (textBox_Angle_Input.Text.Length > 0)  // 문자열이 비어 있지 않으면
            {
                textBox_Angle_Input.Text = textBox_Angle_Input.Text.Substring(0, textBox_Angle_Input.Text.Length - 1);  // 마지막 문자 제거
            }
        }
        private void button_Angle_Convert_Click(object sender, EventArgs e)
        {

        }


        #endregion
        //각도 변환기

        #region
        //길이 변환기
        private void button_Length_1_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBox_Length_Input.Text, out double num))
            {
                firstNumber = num;
                num = -num;
                textBox_Length_Input.Text = num.ToString();
            }
        }

        private void button_Length_2_Click(object sender, EventArgs e)
        {
            textBox_Length_Input.Text += button_Length_2.Text;
        }

        private void button_Length_3_Click(object sender, EventArgs e)
        {
            textBox_Length_Input.Text += button_Length_3.Text;
        }

        private void button_Length_4_Click(object sender, EventArgs e)
        {
            textBox_Length_Input.Text += button_Length_4.Text;
        }

        private void button_Length_5_Click(object sender, EventArgs e)
        {
            textBox_Length_Input.Text += button_Length_5.Text;
        }

        private void button_Length_6_Click(object sender, EventArgs e)
        {
            textBox_Length_Input.Text += button_Length_6.Text;
        }

        private void button_Length_7_Click(object sender, EventArgs e)
        {
            textBox_Length_Input.Text += button_Length_7.Text;
        }

        private void button_Length_8_Click(object sender, EventArgs e)
        {
            textBox_Length_Input.Text += button_Length_8.Text;
        }

        private void button_Length_9_Click(object sender, EventArgs e)
        {
            textBox_Length_Input.Text += button_Length_9.Text;
        }

        private void button_Length_10_Click(object sender, EventArgs e)
        {
            textBox_Length_Input.Text += button_Length_10.Text;
        }

        private void button_Length_11_Click(object sender, EventArgs e)
        {
            textBox_Length_Input.Text += button_Length_11.Text;
        }

        private void button_Length_12_Click(object sender, EventArgs e)
        {
            textBox_Length_Input.Text += button_Length_12.Text;
        }

        private void button_Length_13_Click(object sender, EventArgs e)
        {
            textBox_Length_Input.Clear();
        }

        private void button_Length_14_Click(object sender, EventArgs e)
        {
            if (textBox_Length_Input.Text.Length > 0)  // 문자열이 비어 있지 않으면
            {
                textBox_Length_Input.Text = textBox_Length_Input.Text.Substring(0, textBox_Length_Input.Text.Length - 1);  // 마지막 문자 제거
            }
        }

        private void button_Length_Convert_Click(object sender, EventArgs e)
        {

        }

        #endregion


         
        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox_Time_From.Text = "0";
            textBox_Time_To.Text = "0";


            calculationHistory = "";
            number1 = 0;
            number2 = 0;
            operator_type = Operator.None;
            newInput = false;
        }

        private void textBox_Time_Second_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_Time_Minute_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_Time_Hours_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_Time_c_Click(object sender, EventArgs e)
        {

            textBox_Time_From.Text = "0";
            textBox_Time_To.Text = "0";
           
           
            calculationHistory = "";
            number1 = 0;
            number2 = 0;
            operator_type = Operator.None;
            newInput = false;
        }

        private void button_Time_7_Click(object sender, EventArgs e)
        {
            if (textBox_Time_From.Text == "0" || newInput)
            {
                textBox_Time_From.Text = "7";
                newInput = false;
            }
            else
            {
                textBox_Time_From.Text = textBox_Time_From.Text + "7";
            }
        }

        private void button_Time_8_Click(object sender, EventArgs e)
        {
            if (textBox_Time_From.Text == "0" || newInput)
            {
                textBox_Time_From.Text = "8";
                newInput = false;
            }
            else
            {
                textBox_Time_From.Text = textBox_Time_From.Text + "8";
            }
        }

        private void button_Time_9_Click(object sender, EventArgs e)
        {
            if (textBox_Time_From.Text == "0" || newInput)
            {
                textBox_Time_From.Text = "9";
                newInput = false;
            }
            else
            {
                textBox_Time_From.Text = textBox_Time_From.Text + "9";
            }
        }

        private void button_Time_4_Click(object sender, EventArgs e)
        {
            if (textBox_Time_From.Text == "0" || newInput)
            {
                textBox_Time_From.Text = "4";
                newInput = false;
            }
            else
            {
                textBox_Time_From.Text = textBox_Time_From.Text + "4";
            }
        }

        private void button_Time_5_Click(object sender, EventArgs e)
        {
            if (textBox_Time_From.Text == "0" || newInput)
            {
                textBox_Time_From.Text = "5";
                newInput = false;
            }
            else
            {
                textBox_Time_From.Text = textBox_Time_From.Text + "5";
            }
        }

        private void button_Time_6_Click(object sender, EventArgs e)
        {
            if (textBox_Time_From.Text == "0" || newInput)
            {
                textBox_Time_From.Text = "6";
                newInput = false;
            }
            else
            {
                textBox_Time_From.Text = textBox_Time_From.Text + "6";
            }
        }

        private void button_Time_1_Click(object sender, EventArgs e)
        {
            if (textBox_Time_From.Text == "0" || newInput)
            {
                textBox_Time_From.Text = "1";
                newInput = false;
            }
            else
            {
                textBox_Time_From.Text = textBox_Time_From.Text + "1";
            }
        }

        private void button_Time_2_Click(object sender, EventArgs e)
        {
            if (textBox_Time_From.Text == "0" || newInput)
            {
                textBox_Time_From.Text = "2";
                newInput = false;
            }
            else
            {
                textBox_Time_From.Text = textBox_Time_From.Text + "2";
            }
        }

        private void button_Time_3_Click(object sender, EventArgs e)
        {
            if (textBox_Time_From.Text == "0" || newInput)
            {
                textBox_Time_From.Text = "3";
                newInput = false;
            }
            else
            {
                textBox_Time_From.Text = textBox_Time_From.Text + "3";
            }
        }

        private void button_Time_0_Click(object sender, EventArgs e)
        {
            if (textBox_Time_From.Text == "0" || newInput)
            {
                textBox_Time_From.Text = "0";
                newInput = false;
            }
            else
            {
                textBox_Time_From.Text = textBox_Time_From.Text + "0";
            }
        }

        private void button_Time_a_Click(object sender, EventArgs e)
        {
            if (textBox_Time_From.Text == "0" || newInput)
            {
                textBox_Time_From.Text = ".";
                newInput = false;
            }
            else
            {
                textBox_Time_From.Text = textBox_Time_From.Text + ".";
            }
        }

        private void button_Time_b_Click(object sender, EventArgs e)
        {
            string fromUnit = comboBox1.SelectedItem.ToString();
            string toUnit = comboBox2.SelectedItem.ToString();

            double inputTime;
            double convertedTime = 0;
            inputTime = double.Parse(textBox_Time_From.Text);

            if (fromUnit == "년")
            {
                if (toUnit == "월")
                {
                    convertedTime = inputTime * 12;
                    textBox_Time_From.Text = $"{inputTime} 년";
                    textBox_Time_To.Text = $"{convertedTime} 개월";
                }
                else if (toUnit == "일")
                {
                    convertedTime = inputTime * 365;
                    textBox_Time_From.Text = $"{inputTime} 년";
                    textBox_Time_To.Text = $"{convertedTime} 일";
                }
                else if (toUnit == "시간")
                {
                    convertedTime = inputTime * 365 * 24;
                    textBox_Time_From.Text = $"{inputTime} 년";
                    textBox_Time_To.Text = $"{convertedTime} 시간";
                }
                else if (toUnit == "분")
                {
                    convertedTime = inputTime * 365 * 24 * 60;
                    textBox_Time_From.Text = $"{inputTime} 년";
                    textBox_Time_To.Text = $"{convertedTime} 분";
                }
                else if (toUnit == "초")
                {
                    convertedTime = inputTime * 365 * 24 * 60 * 60;
                    textBox_Time_From.Text = $"{inputTime} 년";
                    textBox_Time_To.Text = $"{convertedTime} 초";
                }
            }
            else if (fromUnit == "월")
            {
                if (toUnit == "년")
                {
                    convertedTime = inputTime / 12;
                    textBox_Time_From.Text = $"{inputTime} 개월";
                    textBox_Time_To.Text = $"{convertedTime} 년";
                }
                else if (toUnit == "일")
                {
                    convertedTime = inputTime * 30;  // 대략 30일 기준
                    textBox_Time_From.Text = $"{inputTime} 개월";
                    textBox_Time_To.Text = $"{convertedTime} 일";
                }
                else if (toUnit == "시간")
                {
                    convertedTime = inputTime * 30 * 24;  // 30일 기준
                    textBox_Time_From.Text = $"{inputTime} 개월";
                    textBox_Time_To.Text = $"{convertedTime} 시간";
                }
                else if (toUnit == "분")
                {
                    convertedTime = inputTime * 30 * 24 * 60;  // 30일 기준
                    textBox_Time_From.Text = $"{inputTime} 개월";
                    textBox_Time_To.Text = $"{convertedTime} 분";
                }
                else if (toUnit == "초")
                {
                    convertedTime = inputTime * 30 * 24 * 60 * 60;  // 30일 기준
                    textBox_Time_From.Text = $"{inputTime} 개월";
                    textBox_Time_To.Text = $"{convertedTime} 초";
                }
            }
            else if (fromUnit == "일")
            {
                if (toUnit == "년")
                {
                    convertedTime = inputTime / 365;
                    textBox_Time_From.Text = $"{inputTime} 일";
                    textBox_Time_To.Text = $"{convertedTime} 년";
                }
                else if (toUnit == "월")
                {
                    convertedTime = inputTime / 30;  // 대략 30일 기준
                    textBox_Time_From.Text = $"{inputTime} 일";
                    textBox_Time_To.Text = $"{convertedTime} 개월";
                }
                else if (toUnit == "시간")
                {
                    convertedTime = inputTime * 24;
                    textBox_Time_From.Text = $"{inputTime} 일";
                    textBox_Time_To.Text = $"{convertedTime} 시간";
                }
                else if (toUnit == "분")
                {
                    convertedTime = inputTime * 24 * 60;
                    textBox_Time_From.Text = $"{inputTime} 일";
                    textBox_Time_To.Text = $"{convertedTime} 분";
                }
                else if (toUnit == "초")
                {
                    convertedTime = inputTime * 24 * 60 * 60;
                    textBox_Time_From.Text = $"{inputTime} 일";
                    textBox_Time_To.Text = $"{convertedTime} 초";
                }
            }
            else if (fromUnit == "시간")
            {
                if (toUnit == "년")
                {
                    convertedTime = inputTime / (365 * 24);
                    textBox_Time_From.Text = $"{inputTime} 시간";
                    textBox_Time_To.Text = $"{convertedTime} 년";
                }
                else if (toUnit == "월")
                {
                    convertedTime = inputTime / (30 * 24);  // 대략 30일 기준
                    textBox_Time_From.Text = $"{inputTime} 시간";
                    textBox_Time_To.Text = $"{convertedTime} 개월";
                }
                else if (toUnit == "일")
                {
                    convertedTime = inputTime / 24;
                    textBox_Time_From.Text = $"{inputTime} 시간";
                    textBox_Time_To.Text = $"{convertedTime} 일";
                }
                else if (toUnit == "분")
                {
                    convertedTime = inputTime * 60;
                    textBox_Time_From.Text = $"{inputTime} 시간";
                    textBox_Time_To.Text = $"{convertedTime} 분";
                }
                else if (toUnit == "초")
                {
                    convertedTime = inputTime * 60 * 60;
                    textBox_Time_From.Text = $"{inputTime} 시간";
                    textBox_Time_To.Text = $"{convertedTime} 초";
                }
            }
            else if (fromUnit == "분")
            {
                if (toUnit == "년")
                {
                    convertedTime = inputTime / (365 * 24 * 60);
                    textBox_Time_From.Text = $"{inputTime} 분";
                    textBox_Time_To.Text = $"{convertedTime} 년";
                }
                else if (toUnit == "월")
                {
                    convertedTime = inputTime / (30 * 24 * 60);  // 대략 30일 기준
                    textBox_Time_From.Text = $"{inputTime} 분";
                    textBox_Time_To.Text = $"{convertedTime} 개월";
                }
                else if (toUnit == "일")
                {
                    convertedTime = inputTime / (24 * 60);
                    textBox_Time_From.Text = $"{inputTime} 분";
                    textBox_Time_To.Text = $"{convertedTime} 일";
                }
                else if (toUnit == "시간")
                {
                    convertedTime = inputTime / 60;
                    textBox_Time_From.Text = $"{inputTime} 분";
                    textBox_Time_To.Text = $"{convertedTime} 시간";
                }
                else if (toUnit == "초")
                {
                    convertedTime = inputTime * 60;
                    textBox_Time_From.Text = $"{inputTime} 분";
                    textBox_Time_To.Text = $"{convertedTime} 초";
                }
            }
            else if (fromUnit == "초")
            {
                if (toUnit == "년")
                {
                    convertedTime = inputTime / (365 * 24 * 60 * 60);
                    textBox_Time_From.Text = $"{inputTime} 초";
                    textBox_Time_To.Text = $"{convertedTime} 년";
                }
                else if (toUnit == "월")
                {
                    convertedTime = inputTime / (30 * 24 * 60 * 60);
                    textBox_Time_From.Text = $"{inputTime} 초";
                    textBox_Time_To.Text = $"{convertedTime} 개월";
                }
                else if (toUnit == "일")
                {
                    convertedTime = inputTime / (24 * 60 * 60);
                    textBox_Time_From.Text = $"{inputTime} 초";
                    textBox_Time_To.Text = $"{convertedTime} 일";
                }
                else if (toUnit == "시간")
                {
                    convertedTime = inputTime / (60 * 60);
                    textBox_Time_From.Text = $"{inputTime} 초";
                    textBox_Time_To.Text = $"{convertedTime} 시간";
                }
                else if (toUnit == "분")
                {
                    convertedTime = inputTime / 60;
                    textBox_Time_From.Text = $"{inputTime} 초";
                    textBox_Time_To.Text = $"{convertedTime} 분";
                }


                textBox_Time_From.Text = "0";
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox_Time_From.Text = "0";
            textBox_Time_To.Text = "0";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox_Time_From.Text = "0";
            textBox_Time_To.Text = "0";
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

            textBox_Temp_From.Text = "0";
            textBox_Temp_To.Text = "0";
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox_Temp_From.Text = "0";
            textBox_Temp_To.Text = "0";
        }

        private void textBox_Temp_From_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_Temp_To_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_Temp_ce_Click(object sender, EventArgs e)
        {
            textBox_Temp_From.Text = "0";
            textBox_Temp_To.Text = "0";


            calculationHistory = "";
            number1 = 0;
            number2 = 0;
            operator_type = Operator.None;
            newInput = false;
        }

        private void button_Temp_c_Click(object sender, EventArgs e)
        {

            textBox_Temp_From.Text = "0";
            textBox_Temp_To.Text = "0";


            calculationHistory = "";
            number1 = 0;
            number2 = 0;
            operator_type = Operator.None;
            newInput = false;
        }

        private void button_Temp_7_Click(object sender, EventArgs e)
        {
            if (textBox_Temp_From.Text == "0" || newInput)
            {
                textBox_Temp_From.Text = "7";
                newInput = false;
            }
            else
            {
                textBox_Temp_From.Text = textBox_Temp_From.Text + "7";
            }
        }

        private void button_Temp_8_Click(object sender, EventArgs e)
        {
            if (textBox_Temp_From.Text == "0" || newInput)
            {
                textBox_Temp_From.Text = "8";
                newInput = false;
            }
            else
            {
                textBox_Temp_From.Text = textBox_Temp_From.Text + "8";
            }
        }

        private void button_Temp_9_Click(object sender, EventArgs e)
        {
            if (textBox_Temp_From.Text == "0" || newInput)
            {
                textBox_Temp_From.Text = "9";
                newInput = false;
            }
            else
            {
                textBox_Temp_From.Text = textBox_Temp_From.Text + "9";
            }
        }

        private void button_Temp_4_Click(object sender, EventArgs e)
        {
            if (textBox_Temp_From.Text == "0" || newInput)
            {
                textBox_Temp_From.Text = "4";
                newInput = false;
            }
            else
            {
                textBox_Temp_From.Text = textBox_Temp_From.Text + "4";
            }
        }

        private void button_Temp_5_Click(object sender, EventArgs e)
        {
            if (textBox_Temp_From.Text == "0" || newInput)
            {
                textBox_Temp_From.Text = "5";
                newInput = false;
            }
            else
            {
                textBox_Temp_From.Text = textBox_Temp_From.Text + "5";
            }
        }

        private void button_Temp_6_Click(object sender, EventArgs e)
        {
            if (textBox_Temp_From.Text == "0" || newInput)
            {
                textBox_Temp_From.Text = "6";
                newInput = false;
            }
            else
            {
                textBox_Temp_From.Text = textBox_Temp_From.Text + "6";
            }
        }

        private void button_Temp_1_Click(object sender, EventArgs e)
        {
            if (textBox_Temp_From.Text == "0" || newInput)
            {
                textBox_Temp_From.Text = "1";
                newInput = false;
            }
            else
            {
                textBox_Temp_From.Text = textBox_Temp_From.Text + "1";
            }
        }

        private void button_Temp_2_Click(object sender, EventArgs e)
        {
            if (textBox_Temp_From.Text == "0" || newInput)
            {
                textBox_Temp_From.Text = "2";
                newInput = false;
            }
            else
            {
                textBox_Temp_From.Text = textBox_Temp_From.Text + "2";
            }
        }

        private void button_Temp_3_Click(object sender, EventArgs e)
        {
            if (textBox_Temp_From.Text == "0" || newInput)
            {
                textBox_Temp_From.Text = "3";
                newInput = false;
            }
            else
            {
                textBox_Temp_From.Text = textBox_Temp_From.Text + "3";
            }
        }

        private void button_Temp_0_Click(object sender, EventArgs e)
        {
            if (textBox_Temp_From.Text == "0" || newInput)
            {
                textBox_Temp_From.Text = "0";
                newInput = false;
            }
            else
            {
                textBox_Temp_From.Text = textBox_Temp_From.Text + "0";
            }
        }

        private void button_Temp_a_Click(object sender, EventArgs e)
        {
            if (textBox_Temp_From.Text == "0" || newInput)
            {
                textBox_Temp_From.Text = ".";
                newInput = false;
            }
            else
            {
                textBox_Temp_From.Text = textBox_Temp_From.Text + ".";
            }
        }

        private void button_Temp_trans_Click(object sender, EventArgs e)
        {
            string fromUnit = comboBox4.SelectedItem.ToString(); // 예: "섭씨", "화씨", "절대온도"
            string toUnit = comboBox3.SelectedItem.ToString();

            double inputTemp;
            double convertedTemp = 0;

           
            inputTemp = double.Parse(textBox_Temp_From.Text);
         

            if (fromUnit == "섭씨온도")
            {
                if (toUnit == "화씨온도")
                {
                    convertedTemp = inputTemp * 9 / 5 + 32;
                }
                else if (toUnit == "절대온도")
                {
                    convertedTemp = inputTemp + 273.15;
                }
                else
                {
                    convertedTemp = inputTemp;
                }
            }
            else if (fromUnit == "화씨온도")
            {
                if (toUnit == "섭씨온도")
                {
                    convertedTemp = (inputTemp - 32) * 5 / 9;
                }
                else if (toUnit == "절대온도")
                {
                    convertedTemp = (inputTemp - 32) * 5 / 9 + 273.15;
                }
                else
                {
                    convertedTemp = inputTemp;
                }
            }
            else if (fromUnit == "절대온도")
            {
                if (toUnit == "섭씨온도")
                {
                    convertedTemp = inputTemp - 273.15;
                }
                else if (toUnit == "화씨온도")
                {
                    convertedTemp = (inputTemp - 273.15) * 9 / 5 + 32;
                }
                else
                {
                    convertedTemp = inputTemp;
                }
            }

            
            textBox_Temp_From.Text = $"{inputTemp} {fromUnit}";
            textBox_Temp_To.Text = $"{convertedTemp} {toUnit}";

            
        }
    }
}

    

