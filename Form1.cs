using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vasilev3
{
    public partial class Form1 : Form
    {
        private string TimeMask = "00:00:00";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.MaxLength = 2;
            textBox2.MaxLength = 2;
            textBox3.MaxLength = 2;
            try
            {
                button2.BackgroundImage = Image.FromFile("icon.png");

                
            }
            catch
            {
                MessageBox.Show("Картинка");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MyTime Test = new MyTime();
            try
            {
                Test.Hours = Convert.ToInt32(textBox1.Text);
                Test.Minutes = Convert.ToInt32(textBox2.Text);
                Test.Seconds = Convert.ToInt32(textBox3.Text);
                if (Test.Hours<0 || Test.Minutes<0 || Test.Seconds<0)
                {
                    MessageBox.Show("Неверные значения времени", "Ошибка");
                }
                else
                {
                    if (radioButton1.Checked)
                    {
                        int plusSeconds;
                        bool numCheck = int.TryParse(textBox4.Text, out plusSeconds);
                        if (numCheck)
                        {
                            Test = Test + plusSeconds;
                        }
                        else
                        {
                            string[] times = textBox4.Text.Split(":");
                            MyTime Test2 = new MyTime();
                            Test2.Hours = Convert.ToInt32(times[0]);
                            Test2.Minutes = Convert.ToInt32(times[1]);
                            Test2.Seconds = Convert.ToInt32(times[2]);
                            Test = Test + Test2;
                        }

                        string resHours = Test.Hours.ToString();
                        string resMinutes = Test.Minutes.ToString();
                        string resSeconds = Test.Seconds.ToString();

                        if (resSeconds.Length == 1)
                        {
                            resSeconds = "0" + resSeconds;
                        }
                        if (resMinutes.Length == 1)
                        {
                            resMinutes = "0" + resMinutes;
                        }
                        if (resHours.Length == 1)
                        {
                            resHours = "0" + resHours;
                        }

                        maskedTextBox3.Text = $"{resHours}:{resMinutes}:{resSeconds}";
                    }
                    if (radioButton2.Checked)
                    {
                        int plusSeconds;
                        bool numCheck = int.TryParse(textBox4.Text, out plusSeconds);
                        if (numCheck)
                        {
                            Test = Test - plusSeconds;
                        }
                        else
                        {
                            string[] times = textBox4.Text.Split(":");
                            MyTime Test2 = new MyTime();
                            Test2.Hours = Convert.ToInt32(times[0]);
                            Test2.Minutes = Convert.ToInt32(times[1]);
                            Test2.Seconds = Convert.ToInt32(times[2]);
                            Test = Test - Test2;
                        }

                        string resHours = Test.Hours.ToString();
                        string resMinutes = Test.Minutes.ToString();
                        string resSeconds = Test.Seconds.ToString();

                        if (resSeconds.Length == 1)
                        {
                            resSeconds = "0" + resSeconds;
                        }
                        if (resMinutes.Length == 1)
                        {
                            resMinutes = "0" + resMinutes;
                        }
                        if (resHours.Length == 1)
                        {
                            resHours = "0" + resHours;
                        }

                        maskedTextBox3.Text = $"{resHours}:{resMinutes}:{resSeconds}";
                    }
                    if (radioButton3.Checked)
                    {
                        string[] times = textBox4.Text.Split(":");
                        MyTime Test2 = new MyTime();
                        Test2.Hours = Convert.ToInt32(times[0]);
                        Test2.Minutes = Convert.ToInt32(times[1]);
                        Test2.Seconds = Convert.ToInt32(times[2]);
                        bool check = false;
                        if (Test == Test2)
                            check = true;
                        maskedTextBox3.Text = check.ToString();
                    }
                    if (radioButton4.Checked)
                    {
                        string[] times = textBox4.Text.Split(":");
                        MyTime Test2 = new MyTime();
                        Test2.Hours = Convert.ToInt32(times[0]);
                        Test2.Minutes = Convert.ToInt32(times[1]);
                        Test2.Seconds = Convert.ToInt32(times[2]);
                        bool check = false;
                        if (Test != Test2)
                            check = true;
                        maskedTextBox3.Text = check.ToString();
                    }
                }
                

            }
            catch
            {
                MessageBox.Show("Неверные значения", "Ошибка");
            }

          
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Введите время в формате:\n\n  1) Секунды (Пример: 60)\n\n  2) Время (Пример: 12:30:00)", "Информация");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Разработать класс, инкапсулирующий время (часы, минуты, секунды). Перегрузить операторы + (количество секунд), +(объект время), -(количество дней), -(объект время), " +
                "== (объект время), != (объект время). Реализовать методы вывода времени в разных форматах.");
        }
    }

    public class MyTime
    {
        internal int Seconds;
        internal int Minutes;
        internal int Hours;

        public MyTime() { }

        public static MyTime operator +(MyTime time, int Second)
        {
            time.Seconds += Second;

            time.WhatHappened();

            return time;
        }
        public static MyTime operator +(MyTime time, MyTime time2)
        {
            time.Seconds += time2.Seconds;
            time.Minutes += time2.Minutes;
            time.Hours += time2.Hours;

            time.WhatHappened();

            return time;
        }
        public static MyTime operator -(MyTime time, int Second)
        {
            time.Seconds -= Second;
            time.WhatHappened();
            return time;
        }
        public static MyTime operator -(MyTime time, MyTime time2)
        {
            time.Seconds -= time2.Seconds;
            time.Minutes -= time2.Minutes;
            time.Hours -= time2.Hours;

            time.WhatHappened();

            return time;
        }
        public static bool operator ==(MyTime time, MyTime time2)
        {
            if (time.Seconds == time2.Seconds && time.Minutes == time2.Minutes && time.Hours == time2.Hours)
                return true;
            else
                return false;
        }
        public static bool operator !=(MyTime time, MyTime time2)
        {
            if (time.Seconds != time2.Seconds || time.Minutes != time2.Minutes || time.Hours != time2.Hours)
                return true;
            else
                return false;
        }

        public void WhatHappened()
        {
            while (this.Seconds < 0)
            {
                this.Minutes -= 1;
                this.Seconds += 60;
            }
            while (this.Minutes < 0)
            {
                this.Hours -= 1;
                this.Minutes += 60;
            }
            while (this.Hours < 0)
            {
                this.Hours += 24;
            }
            while (this.Seconds > 59)
            {
                this.Minutes += 1;
                this.Seconds -= 60;
            }
            while (this.Minutes > 59)
            {
                this.Hours += 1;
                this.Minutes -= 60;

            }
            while (this.Hours > 23)
            {
                this.Hours -= 24;
            }
            
        }
    }
}
