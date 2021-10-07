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
            catch
            {
                MessageBox.Show("Неверные значения", "Ошибка");
            }

          
        }

        private void label6_Click(object sender, EventArgs e)
        {

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
            while (Second > 59)
            {
                time.Minutes += 1;
                Second -= 60;
                if (time.Minutes > 59)
                {
                    time.Hours += 1;
                    time.Minutes -= 60;
                    if (time.Hours > 23)
                    {
                        time.Hours = 0;
                    }
                }
            }
            if (time.Seconds + Second >=60)
            {
                time.Minutes += 1;
                time.Seconds += Second;
                time.Seconds -= 60;
                if (time.Minutes > 59)
                {
                    time.Hours += 1;
                    time.Minutes -= 60;
                    if (time.Hours > 23)
                    {
                        time.Hours = 0;
                    }
                }
            }
            else
            {
                time.Seconds += Second;
            }
            return time;
        }
        public static MyTime operator +(MyTime time, MyTime time2)
        {
            time.Seconds += time2.Seconds;
            time.Minutes += time2.Minutes;
            time.Hours += time2.Hours;
            while (time.Seconds > 59)
            {
                time.Minutes += 1;
                time.Seconds -= 60;
            }
            while (time.Minutes > 59)
            {
                time.Hours += 1;
                time.Minutes -= 60;
                
            }
            while (time.Hours > 23)
            {
                time.Hours -= 24;
            }
            
            return time;
        }
        public static MyTime operator -(MyTime time, int Second)
        {
            time.Seconds -= Second;
            while (time.Seconds < 0)
            {
                time.Minutes -= 1;
                time.Seconds += 60;
            }
            while (time.Minutes < 0)
            {
                time.Hours -= 1;
                time.Minutes += 60;
            }
            while (time.Hours < 0)
            {
                time.Hours += 24;
            }
            return time;
        }
        public static MyTime operator -(MyTime time, MyTime time2)
        {
            time.Seconds -= time2.Seconds;
            time.Minutes -= time2.Minutes;
            time.Hours -= time2.Hours;
            while (time.Seconds < 0)
            {
                time.Minutes -= 1;
                time.Seconds += 60;
            }
            while (time.Minutes < 0)
            {
                time.Hours -= 1;
                time.Minutes += 60;
            }
            while (time.Hours < 0)
            {
                time.Hours += 24;
            }

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
    }
}
