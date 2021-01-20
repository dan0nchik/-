using System;
using System.Windows.Forms;

namespace Многоугольники
{
    public partial class PlotForm : Form
    {
        private string algo;
        private double[] time, points, time4second;
        public PlotForm(string algorithm, double[] time, double[] points)
        {
            InitializeComponent();
            this.algo = algorithm;
            this.time = time;
            this.points = points;
        }
        public PlotForm(string algorithm, double[] time, double[] time4second, double[] points)
        {
            InitializeComponent();
            this.algo = algorithm;
            this.time = time;
            this.points = points;
            this.time4second = time4second;
        }

        private void PlotForm_Load(object sender, EventArgs e)
        {

        }

        private void formsPlot1_Load(object sender, EventArgs e)
        {
            if (algo == "Jarvis")
            {
                formsPlot1.plt.PlotScatter(points, time);
                formsPlot1.plt.Title(algo);
                formsPlot1.plt.XLabel("Shapes");
                formsPlot1.plt.YLabel("Seconds");
                formsPlot1.Render();

            }
            if (algo == "By definition")
            {
                formsPlot1.plt.PlotScatter(points, time);
                formsPlot1.plt.Title(algo);
                formsPlot1.plt.XLabel("Shapes");
                formsPlot1.plt.YLabel("Seconds");
                formsPlot1.Render();

            }
            if (algo == "Both")
            {
                formsPlot1.plt.PlotScatter(points, time, label: "Jarvis");
                formsPlot1.plt.PlotScatter(points, time4second, label: "By definition");
                formsPlot1.plt.Title(algo);
                formsPlot1.plt.Legend(true);
                formsPlot1.plt.XLabel("Shapes");
                formsPlot1.plt.YLabel("Seconds");
                formsPlot1.Render();
            }
            if (algo == "Jarvis vs Parallel Jarvis")
            {
                formsPlot1.plt.PlotScatter(points, time, label: "Jarvis");
                formsPlot1.plt.PlotScatter(points, time4second, label: "Parallel Jarvis");
                formsPlot1.plt.Title(algo);
                formsPlot1.plt.Legend(true);
                formsPlot1.plt.XLabel("Shapes");
                formsPlot1.plt.YLabel("Seconds");
                formsPlot1.Render();
            }
        }
    }
}
