using System;
using System.Windows.Forms;
using static _TestSW_1.TrapezoidIntegral;

namespace _TestSW_1
{
    public partial class App : Form
    {

        double ODZ = 0.8;

        public App()
        {
            InitializeComponent();
            SetCanvas();
        }

        void SetCanvas()
        {
            chart1.Series.Clear();
            chart1.Series.Add("CalcFunc");
            chart1.Series["CalcFunc"].BorderWidth = 5;
            chart1.Series["CalcFunc"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
        }

        void DrawFunction()
        {
            try
            {
                SetCanvas();
                TrapezoidIntegral trapezoidIntegral = new TrapezoidIntegral();
                Answer answer = trapezoidIntegral.Calculate
                    (
                    Convert.ToDouble(textBoxA.Text),
                    Convert.ToDouble(textBoxB.Text),
                    Convert.ToInt32(textBoxN.Text),
                    Convert.ToDouble(textBoxEps.Text)
                    );
                chart1.Series["CalcFunc"].Points.DataBindXY(answer.x, answer.y);
            } 
            catch(Exception e)
            {
                labelStatus.Text = e.Message;
            }
        }

        bool RunValidation()
        {
            try
            {
            double a = Convert.ToDouble(textBoxA.Text);
            double b = Convert.ToDouble(textBoxB.Text);
            bool checkODZ(double lower, double upper)
            {
                for (double i = lower; i <= upper; i += 0.1) 
                {
                    if(i > (ODZ * -1) && i < ODZ)
                    {
                        MessageBox.Show("Диапaзон значений не входит в ОДЗ");
                        return false;
                    }
                }
                return true;
            }
            bool checkBordersIntegrity(double lower, double upper)
            {
                if(lower > upper)
                {
                    MessageBox.Show("Нижний предел больше верхнего");
                }
                return lower <= upper;
            }
            return checkODZ(a, b) && checkBordersIntegrity(a, b);
            } 
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(RunValidation())
            {
                DrawFunction();
            }
        }
    }
}
