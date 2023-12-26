using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Math;

namespace WindowsFormsApplication2
{
    public partial class horizon : Form
    {
        public double _angle, _speed, _speed0, _time, _height, _length,
            _t, _dt, _x, _y, _speed0x, _speed0y, _h0;



        public horizon()
        {
            InitializeComponent();
        }
        

        public void Timer1_Tick(object sender, EventArgs e)
        {
            Drow();
            _t += 0.1;
            _x = Round(_speed0x * _t);
            _y = Round(_h0 + (_speed0y * _t) - (9.81 * _t * _t) / 2);
        }
        public void Drow()
        {
            timer1.Enabled = true;
            Graphics bmp = pictureBox1.CreateGraphics();
            Pen pen = new Pen(Color.Black);
            pen.Width = 2;
            bmp.DrawLine(pen, Convert.ToInt32(_x - 1), Convert.ToInt32(300 - _y - 1), Convert.ToInt32(_x + 1), Convert.ToInt32(300 - _y + 1));
        }

        private void GetData()
        {
            try
            {
                _speed0 = Convert.ToDouble(textBox2.Text);
                _angle = Convert.ToDouble(textBox1.Text);
                _h0 = Convert.ToDouble(textBox6.Text);
            }
            catch
            {

            }
            finally
            {
                button1.Enabled = true;
            }

        }
        private void Calc()
        {
            _speed0x = _speed0 * Math.Cos(_angle * 3.14 / 180);
            _speed0y = _speed0 * Math.Sin(_angle * 3.14 / 180);

            _height = _h0 + (_speed0y * _speed0y) / (2 * 9.81);
            _time = (_speed0y + Math.Sqrt(_speed0y * _speed0y + 2 * 9.81 * _h0)) / 9.81;
            _length = _speed0x * _time;
        }
        private void ShowResult()
        {
            textBox3.Text = _time.ToString();
            textBox4.Text = _height.ToString();
            textBox5.Text = _length.ToString();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetData();
            Calc();
            ShowResult();
            timer1.Enabled = true;
            Clear();
            Drow();
        }


        public void Clear()
        {  timer1.Enabled = false;
            _x = 0;
            _y = 0;
            _t = 0;
            Graphics bmp = pictureBox1.CreateGraphics();
            bmp.Clear(SystemColors.Control);
          

        }
    }
}
