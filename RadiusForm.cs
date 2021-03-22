using System;
using System.Windows.Forms;

namespace Многоугольники
{
    public class RadiusEventArgs : EventArgs
    {
        private int r = 10;
        public RadiusEventArgs(int Radius)
        {
            r += Radius;
        }
        public int Radius
        {
            get => r;
            set
            {
                r += value;
            }

        }
    }
    public delegate void RadiusChanged(object sender, RadiusEventArgs e);
    public partial class RadiusForm : Form
    {
        public int radiusFromFile = 0;
        public event RadiusChanged RC;

        public RadiusForm()
        {
            InitializeComponent();
        }

        private void RadiusForm_Load(object sender, EventArgs e)
        {
            
            trackBar1.Value = radiusFromFile - 10;
        
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            Console.WriteLine("trackbar " + trackBar1.Value);
            
            RadiusEventArgs radiusEvent = new RadiusEventArgs(trackBar1.Value);
            RC(this, radiusEvent);
        }
    }
}
