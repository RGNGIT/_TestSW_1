using System;
using System.Windows.Forms;
using static _TestSW_1.TrapezoidIntegral;

namespace _TestSW_1
{
    public partial class App : Form
    {

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
            } catch(Exception e)
            {
                labelStatus.Text = e.Message;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DrawFunction();
        }
    }
}
