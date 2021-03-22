using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using PolygonsLib;

namespace Многоугольники
{
    public partial class Form1 : Form
    {
        List<Shape> shapes;
        private int shapeFlag, algoFlag;
        private Color lineColor, pointColor;
        private bool changed, showPlayIcon;
        System.Windows.Forms.Timer timer;
        Random random;
        FileStream fileStream;
        BinaryFormatter formatter;
        private string savedFile;
        Algorithm algorithm;

        public Form1()
        {
            shapes = new List<Shape>();
            InitializeComponent();
            DoubleBuffered = true;
            timer = new System.Windows.Forms.Timer();
            random = new Random();
            lineColor = Color.Black;
            pointColor = Color.Black;
            timer.Tick += timer_Tick;
            showPlayIcon = false;
            savedFile = "";
            changed = false;
            algorithm = new Algorithm();
            formatter = new BinaryFormatter();
            KeyDown += Form1_KeyDown;
            FormClosing += Form1_Closing;
        }

        private DialogResult showMsgBox()
        {
            return MessageBox.Show("Attention",
                                                    "You have unsaved changes. Save them?",
                                                    MessageBoxButtons.YesNoCancel);
        }

        private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (changed)
            {
                DialogResult result = showMsgBox();
                if(result == DialogResult.Yes)
                {
                    Save();
                    Console.WriteLine("YES");
                }
                if(result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            foreach (Shape i in shapes.ToList())
            {
                i.dragged = false;
                if (shapes.Count > 3)
                    if (!i.inShell) { shapes.Remove(i); Refresh(); }
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            if (shapes.Count > 2)
            {
                foreach (Shape shape in shapes)
                    shape.inShell = false;
                if (algoFlag == 0)
                {
                    algorithm.JarvisAlgorithm(e, lineColor, shapes);
                }
                else
                    algorithm.ByDefinitionAlgorithm(e, lineColor, shapes);
            }
            foreach (Shape i in shapes.ToList()) i.Draw(e.Graphics, pointColor);

        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            bool shifted = false;
            foreach (Shape i in shapes.ToList())
            {
                if (i.IsInside(e.X, e.Y))
                {
                    i.dragged = true;
                    shifted = true;
                    i.ChosenX = i.X - e.X;
                    i.ChosenY = i.Y - e.Y;
                }
            }
            if (shifted == false)
            {
                switch (shapeFlag)
                {
                    case 0:
                        shapes.Add(new Circle(e.X, e.Y));
                        break;
                    case 1:
                        shapes.Add(new Square(e.X, e.Y));
                        break;
                    case 2:
                        shapes.Add(new Triangle(e.X, e.Y));
                        break;

                }
                changed = true;
                if (shapes.Count > 3)
                    if (!algorithm.CheckIfInHull(shapes))
                    {
                        shapes.RemoveAt(shapes.Count - 1);
                        foreach (Shape i in shapes.ToList())
                        {
                            i.dragged = true;
                            shifted = true;
                            i.ChosenX = i.X - e.X;
                            i.ChosenY = i.Y - e.Y;
                        }
                    }
                Refresh();
            }
            if (e.Button == MouseButtons.Right)
            {
                foreach (Shape i in shapes.ToList())
                {
                    if (i.IsInside(e.X, e.Y) == true)
                    {
                        shapes.RemoveAt(shapes.IndexOf(i));
                        changed = true;
                        Refresh();
                    }
                }
            }

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            bool refreshed = false;
            foreach (Shape i in shapes.ToList())
            {
                if (i.dragged == true)
                {
                    i.X = e.X + i.ChosenX;
                    i.Y = e.Y + i.ChosenY;
                    refreshed = true;
                    changed = true;
                }
            }
            if (refreshed)
                Refresh();

        }

        private void circleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shapeFlag = 0;
        }

        private void squareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shapeFlag = 1;
        }

        private void triangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shapeFlag = 2;
        }

        private void algorithmToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void byDefinitionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            algoFlag = 1;
        }
        private void GenerateShapes(string algoName)
        {
            List<double> pointsRange = new List<double>();
            List<Shape> shapesToPlot = new List<Shape>();
            List<double> seconds = new List<double>();
            List<double> seconds1 = new List<double>();
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var watch1 = System.Diagnostics.Stopwatch.StartNew();
            Random rand = new Random();
            PlotForm frm;
            for (int i = 10; i < 300000; i += 500)
            {
                for (int j = 0; j < i; ++j)
                {
                    shapesToPlot.Add(new Circle(rand.Next(10), rand.Next(10)));
                }
                if (algoName == "Jarvis")
                {
                    watch.Start();
                    algorithm.JarvisAlgorithm(shapesToPlot);
                    watch.Stop();
                }
                if (algoName == "By definition")
                {
                    watch.Start();
                    algorithm.ByDefinitionAlgorithm(shapesToPlot);
                    watch.Stop();
                }
                if (algoName == "Parallel Jarvis")
                {
                    watch.Start();
                    algorithm.ParallelJarvis(shapesToPlot);
                    watch.Stop();
                }
                if (algoName == "Both")
                {
                    watch.Start();
                    algorithm.JarvisAlgorithm(shapesToPlot);
                    watch.Stop();

                    watch1.Start();
                    algorithm.ByDefinitionAlgorithm(shapesToPlot);
                    watch1.Stop();
                }
                if (algoName == "Jarvis vs Parallel Jarvis")
                {
                    watch.Start();
                    algorithm.JarvisAlgorithm(shapesToPlot);
                    watch.Stop();

                    watch1.Start();
                    algorithm.ParallelJarvis(shapesToPlot);
                    watch1.Stop();
                }
                if (algoName == "Both" || algoName == "Jarvis vs Parallel Jarvis")
                {
                    seconds1.Add(Convert.ToDouble(watch1.Elapsed.TotalSeconds));
                }
                Console.WriteLine(string.Format("{0}, {1}", i, watch.Elapsed.TotalSeconds));
                seconds.Add(Convert.ToDouble(watch.Elapsed.TotalSeconds));
                pointsRange.Add(i);
            }
            if (algoName == "Both" || algoName == "Jarvis vs Parallel Jarvis")
            {
                frm = new PlotForm(algoName, seconds.ToArray(), seconds1.ToArray(), pointsRange.ToArray());
            }
            else
            {

                frm = new PlotForm(algoName, seconds.ToArray(), pointsRange.ToArray());
            }
            frm.Show();
        }
        private void jarvisToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GenerateShapes("Jarvis");
        }

        private void byDefinitionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GenerateShapes("By definition");
        }

        private void bothToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenerateShapes("Both");
        }

        private void jarvisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            algoFlag = 0;
        }

        private ColorDialog MyDialog = new ColorDialog();

        public void OnRadiusChanged(object sender, RadiusEventArgs e)
        {
            Shape.Radius = e.Radius;
            changed = true;
            Refresh();
        }
        private RadiusForm radfrm = new RadiusForm();
        private void radiusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (radfrm.IsAccessible == false)
                radfrm.Activate();
            if (radfrm.IsDisposed)
                radfrm = new RadiusForm();
            if (radfrm.WindowState == FormWindowState.Maximized)
                radfrm.WindowState = FormWindowState.Normal;
            if (radfrm.WindowState == FormWindowState.Minimized)
                radfrm.WindowState = FormWindowState.Normal;

            radfrm.radiusFromFile = Shape.Radius;
            radfrm.RC += OnRadiusChanged;
            radfrm.Show();

        }

        private void playStopButton_Click(object sender, EventArgs e)
        {
            string imagePath = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
            if (!showPlayIcon)
            {
                timer.Start();
                playStopButton.BackgroundImage = Image.FromFile(imagePath + @"\Resources\pause.png");
                showPlayIcon = true;
            }
            else
            {
                timer.Stop();
                playStopButton.BackgroundImage = Image.FromFile(imagePath + @"\Resources\play.png");
                showPlayIcon = false;
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            ShakeHull();
            Refresh();
        }

        private void skipForwardButton_Click(object sender, EventArgs e)
        {
            if (timer.Interval > 10)
                timer.Interval -= 10;
        }

        private void skipBackwardButton_Click(object sender, EventArgs e)
        {
            timer.Interval += 10;
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAs();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Open();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save();
        }
        private void Save()
        {
            Console.WriteLine("Changed:", changed);
            Console.WriteLine("File", savedFile);
                if (savedFile != "")
                {
                    fileStream = new FileStream(savedFile, FileMode.OpenOrCreate);
                    List<object> settings = new List<object>{
                        shapes,
                        Shape.Radius,
                        pointColor,
                        lineColor
                    };
                    formatter.Serialize(fileStream, settings);
                    fileStream.Close();
                    changed = false;
                }
            else
            {
                SaveAs();
            }
            }

        private void SaveAs()
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog
            {
                Filter = "Text file|*.txt",
                Title = "Save current session",
                FileName = "session"
            };
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                savedFile = saveFileDialog1.FileName;
                Save();
            }
        }
        private void Open()
        {
            
            if (changed)
            {
                DialogResult result = showMsgBox();
                if(result == DialogResult.Yes)
                {
                    Save();
                    Open();
                }
                if (result == DialogResult.No)
                {
                    changed = false;
                    Open();
                }
            }
            else
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = "c:\\";
                    openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                    openFileDialog.FilterIndex = 2;
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        fileStream = (FileStream)openFileDialog.OpenFile();
                        List<object> settings = (List<object>)formatter.Deserialize(fileStream);

                        shapes = (List<Shape>)settings[0];
                        Shape.Radius = (int)settings[1];

                        pointColor = (Color)settings[2];
                        lineColor = (Color)settings[3];

                        savedFile = openFileDialog.FileName;
                        Refresh();
                        fileStream.Close();
                    }
                }
            }
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.S)
            {
                Save();
            }
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.O)
            {
                Open();
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!changed)
            {
                shapes.Clear();
                changed = false;
                Refresh();
            }
            else
            {
                DialogResult result = showMsgBox(); 
                if (result == DialogResult.Yes)
                {
                    Save();
                    shapes.Clear();
                    
                }
                if(result == DialogResult.No)
                {
                    shapes.Clear();
                    changed = false;
                }
                Refresh();
            }


        }

        private void jarvisVsParallelJarvisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenerateShapes("Jarvis vs Parallel Jarvis");
        }

        private void parallelJarvisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenerateShapes("Parallel Jarvis");
        }

        private void ShakeHull()
        {
            foreach (var shape in shapes.ToList())
            {
                shape.X += random.Next(-2, 3);
                shape.Y += random.Next(-2, 3);
                if (!shape.inShell) shapes.Remove(shape);
            }

        }

        private void lineColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MyDialog.ShowDialog() == DialogResult.OK) { lineColor = MyDialog.Color; changed = true; Refresh(); }
        }

        private void pontColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MyDialog.ShowDialog() == DialogResult.OK) { pointColor = MyDialog.Color; changed = true; Refresh(); }
        }

    }
}