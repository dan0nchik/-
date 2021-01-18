using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Многоугольники
{
    
    public partial class Form1 : Form
    {
        
        List<Shape> shapes;
        private int shapeFlag, algoFlag;
        private Color lineColor, pointColor;
        private bool cursorInHull, showPlayIcon;
        private string projectPath, saveFilePath;
        Timer timer;
        BinaryFormatter formatter;
        FileStream fileStream;
        Random random;

        public Form1()
        {
            projectPath = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
            shapes = new List<Shape>
            {
                new Circle(50, 50)
            };
            InitializeComponent();
            DoubleBuffered = true;
            timer = new Timer();
            random = new Random();
            lineColor = Color.Black;
            pointColor = Color.Black;
            timer.Tick += timer_Tick;
            showPlayIcon = false;
            formatter = new BinaryFormatter();
            saveFilePath = "";
            KeyDown += Form1_KeyDown;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            foreach (Shape i in shapes.ToList())
            {
                i.dragged = false;
                if (shapes.Count > 2)
                    if (!i.inShell) { shapes.Remove(i); Refresh(); }
            }
            cursorInHull = false;
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
                        ByDefinitionAlgorithm(e, lineColor);
                    else
                        JarvisAlgorithm(e, lineColor);
                }
                foreach (Shape i in shapes.ToList()) i.Draw(e.Graphics, pointColor);
            
        }

        private void ByDefinitionAlgorithm(PaintEventArgs e, Color lineColor)
        {
            double k, b;
            int topCount, bottomCount, rightCount, leftCount;

            foreach (Shape first in shapes)
            {
                foreach (Shape second in shapes)
                {

                    if (second != first)
                    {
                        if ((second.X - first.X) == 0)
                        {
                            rightCount = 0;
                            leftCount = 0;
                            foreach (Shape third in shapes)
                            {
                                if (third != first && third != second)
                                {
                                    if (first.X >= third.X) rightCount++;
                                    else leftCount++;
                                }
                            }
                            if (rightCount == 0 || leftCount == 0)
                            {
                                second.inShell = true;
                                first.inShell = true;
                                e.Graphics.DrawLine(new Pen(new SolidBrush(lineColor)), new Point(first.X, first.Y), new Point(second.X, second.Y));
                            }
                        }
                        else
                        {
                            k = ((double)first.Y - (double)second.Y) / ((double)first.X - (double)second.X);
                            b = first.Y - (k * first.X);
                            topCount = 0;
                            bottomCount = 0;
                            foreach (Shape third in shapes)
                            {
                                if (third != first && third != second)
                                {
                                    if (third.Y >= k * third.X + b) topCount++;
                                    else bottomCount++;
                                }
                            }
                            if (bottomCount == 0 || topCount == 0)
                            {
                                second.inShell = true;
                                first.inShell = true;
                                e.Graphics.DrawLine(new Pen(new SolidBrush(lineColor)), new Point(first.X, first.Y), new Point(second.X, second.Y));
                            }
                        }

                    }
                }

            }
        }   

        private void JarvisAlgorithm(PaintEventArgs e, Color lineColor)
        {
            int indexA = 0, indexP = 0, nextIndex = 0;
            for (int i = 0; i < shapes.Count; ++i)
            {
                if (shapes[indexA].Y < shapes[i].Y)
                {
                    indexA = i;
                }
            }
            double minCos = double.MaxValue;
            Point M = new Point(shapes[indexA].X - 1000, shapes[indexA].Y);

            for (int i = 0; i < shapes.Count; i++)
            {
                if (i != indexA)
                {
                    if (Cos(shapes[i], shapes[indexA], M) < minCos)
                    {   
                        indexP = i;
                        minCos = Cos(shapes[i], shapes[indexA], M);
                    }
                }
            }
            e.Graphics.DrawLine(new Pen(new SolidBrush(lineColor)), new Point(shapes[indexA].X, shapes[indexA].Y), new Point(shapes[indexP].X, shapes[indexP].Y));
            shapes[indexA].inShell = true;
            shapes[indexP].inShell = true;
            int endPointIndex = indexA;
            do
            {
                minCos = double.MaxValue;
                for (int j = 0; j < shapes.Count; j++)
                {
                    if (j != indexA)
                    {
                        if (Cos(shapes[indexA], shapes[indexP], new Point(shapes[j].X, shapes[j].Y)) < minCos)
                        {
                            minCos = Cos(shapes[indexA], shapes[indexP], new Point(shapes[j].X, shapes[j].Y));
                            nextIndex = j;
                        }
                    }
                }

                e.Graphics.DrawLine(new Pen(new SolidBrush(lineColor)), new Point(shapes[indexP].X, shapes[indexP].Y), new Point(shapes[nextIndex].X, shapes[nextIndex].Y));
                shapes[nextIndex].inShell = true;
                indexA = indexP;
                indexP = nextIndex;
            } while (indexP != endPointIndex);
            
        }
        double Cos(Shape one, Shape two, Point three)
        {
                Point v1 = new Point(two.X - one.X, two.Y - one.Y);
                Point v2 = new Point(two.X - three.X, two.Y - three.Y);
                return ((v1.X * v2.X) + (v1.Y * v2.Y)) / (Math.Sqrt(v1.X * v1.X + v1.Y * v1.Y) * Math.Sqrt(v2.X * v2.X + v2.Y * v2.Y));
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
                if (shapes.Count > 3)
                    if (!CheckIfInHull(shapes))
                    {
                        Console.WriteLine("IN");
                        shapes.RemoveAt(shapes.Count - 1);
                        cursorInHull = true;
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
                        Refresh();
                    }
                }
            }

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
                foreach (Shape i in shapes.ToList())
                {
                    if (i.dragged == true)
                    {
                        i.X = e.X + i.ChosenX;
                        i.Y = e.Y + i.ChosenY;
                        Refresh();
                    }
                }
            
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
            for (int i = 10; i < 1000; i += 100)
            {
                for (int j = 0; j < i; ++j)
                {
                    shapesToPlot.Add(new Circle(rand.Next(10), rand.Next(10)));
                }
                if (algoName == "Jarvis")
                {
                    watch.Start();
                    JarvisAlgorithm(shapesToPlot);
                    watch.Stop();
                }
                if (algoName == "By definition")
                {
                    watch.Start();
                    ByDefinitionAlgorithm(shapesToPlot);
                    watch.Stop();
                }
                if (algoName == "Both")
                {
                    watch.Start();
                    JarvisAlgorithm(shapesToPlot);
                    watch.Stop();

                    watch1.Start();
                    ByDefinitionAlgorithm(shapesToPlot);
                    watch1.Stop();
                }
                if (algoName == "Both")
                {
                    seconds1.Add(Convert.ToInt32(watch1.Elapsed.TotalSeconds));
                }
                seconds.Add(Convert.ToInt32(watch.Elapsed.TotalSeconds));
                pointsRange.Add(i);
            }
            if (algoName == "Both")
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
        private void JarvisAlgorithm(List<Shape> shapes) 
        {

            {
                int indexA = 0, indexP = 0, nextIndex = 0;
                for (int i = 0; i < shapes.Count; ++i)
                {
                    if (shapes[indexA].Y < shapes[i].Y)
                    {
                        indexA = i;
                    }
                }
                double minCos = double.MaxValue;
                Point M = new Point(shapes[indexA].X - 1000, shapes[indexA].Y);

                for (int i = 0; i < shapes.Count; i++)
                {
                    if (i != indexA)
                    {
                        if (Cos(shapes[i], shapes[indexA], M) < minCos)
                        {
                            indexP = i;
                            minCos = Cos(shapes[i], shapes[indexA], M);
                        }
                    }
                }
                shapes[indexA].inShell = true;
                shapes[indexP].inShell = true;
                int endPointIndex = indexA;
                do
                {
                    minCos = double.MaxValue;
                    for (int j = 0; j < shapes.Count; j++)
                    {
                        if (j != indexA)
                        {
                            if (Cos(shapes[indexA], shapes[indexP], new Point(shapes[j].X, shapes[j].Y)) < minCos)
                            {
                                minCos = Cos(shapes[indexA], shapes[indexP], new Point(shapes[j].X, shapes[j].Y));
                                nextIndex = j;
                            }
                        }
                    }

                    shapes[nextIndex].inShell = true;
                    indexA = indexP;
                    indexP = nextIndex;
                } while (indexP != endPointIndex);
            }
        }
        private bool CheckIfInHull(List<Shape> shapes)
        {

            
                int indexA = 0, indexP = 0, nextIndex = 0;
                for (int i = 0; i < shapes.Count; ++i)
                {
                    if (shapes[indexA].Y < shapes[i].Y)
                    {
                        indexA = i;
                    }
                }
                double minCos = double.MaxValue;
                Point M = new Point(shapes[indexA].X - 1000, shapes[indexA].Y);

                for (int i = 0; i < shapes.Count; i++)
                {
                    if (i != indexA)
                    {
                        if (Cos(shapes[i], shapes[indexA], M) < minCos)
                        {
                            indexP = i;
                            minCos = Cos(shapes[i], shapes[indexA], M);
                        }
                    }
                }
                shapes[indexA].inShell = true;
                shapes[indexP].inShell = true;
                int endPointIndex = indexA;
                do
                {
                    minCos = double.MaxValue;
                    for (int j = 0; j < shapes.Count; j++)
                    {
                        if (j != indexA)
                        {
                            if (Cos(shapes[indexA], shapes[indexP], new Point(shapes[j].X, shapes[j].Y)) < minCos)
                            {
                                minCos = Cos(shapes[indexA], shapes[indexP], new Point(shapes[j].X, shapes[j].Y));
                                nextIndex = j;
                            }
                        }
                    }

                    shapes[nextIndex].inShell = true;
                    indexA = indexP;
                    indexP = nextIndex;
                } while (indexP != endPointIndex);
            if (!shapes.Last().inShell) return false;
            return true;
        }
        private void ByDefinitionAlgorithm(List<Shape> shapes)
        {
            double k, b;
            int topCount, bottomCount, rightCount, leftCount;

            foreach (Shape first in shapes)
            {
                foreach (Shape second in shapes)
                {

                    if (second != first)
                    {
                        if ((second.X - first.X) == 0)
                        {
                            rightCount = 0;
                            leftCount = 0;
                            foreach (Shape third in shapes)
                            {
                                if (third != first && third != second)
                                {
                                    if (first.X >= third.X) rightCount++;
                                    else leftCount++;
                                }
                            }
                            if (rightCount == 0 || leftCount == 0)
                            {
                                second.inShell = true;
                                first.inShell = true;
                            }
                        }
                        else
                        {
                            k = ((double)first.Y - (double)second.Y) / ((double)first.X - (double)second.X);
                            b = first.Y - (k * first.X);
                            topCount = 0;
                            bottomCount = 0;
                            foreach (Shape third in shapes)
                            {
                                if (third != first && third != second)
                                {
                                    if (third.Y >= k * third.X + b) topCount++;
                                    else bottomCount++;
                                }
                            }
                            if (bottomCount == 0 || topCount == 0)
                            {
                                second.inShell = true;
                                first.inShell = true;
                            }
                        }

                    }
                }

            }
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
            Refresh();
        }
        private RadiusForm radfrm = new RadiusForm();
        private void radiusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (radfrm.IsAccessible == false)
                radfrm.Activate();
            if (radfrm.IsDisposed)    
                radfrm = new  RadiusForm();     
            if (radfrm.WindowState == FormWindowState.Maximized)      
                radfrm.WindowState = FormWindowState.Normal;
            if (radfrm.WindowState == FormWindowState.Minimized)
                radfrm.WindowState = FormWindowState.Normal;
            
            radfrm.Show();
            radfrm.RC += OnRadiusChanged;
        }

        private void playStopButton_Click(object sender, EventArgs e)
        {
            if (!showPlayIcon)
            {
                timer.Start();
                playStopButton.BackgroundImage = Image.FromFile(projectPath + @"\Resources\pause.png");
                showPlayIcon = true;
            }
            else
            {
                timer.Stop();
                playStopButton.BackgroundImage = Image.FromFile(projectPath + @"\Resources\play.png");
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
            if(timer.Interval > 10)
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
            if (saveFilePath != "")
                Save(saveFilePath);
            else
                SaveAs();
        }
        private void Save(string path)
        {
            if (path != "")
            {
                fileStream = new FileStream(path, FileMode.OpenOrCreate);
                List<object> settings = new List<object>{
                    shapes,
                    Shape.Radius,
                    pointColor,
                    lineColor
                };
                formatter.Serialize(fileStream, settings);
                fileStream.Close();
            }
        }
        private void Open()
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

                    saveFilePath = openFileDialog.FileName;
                    Refresh();
                    fileStream.Close();
                }
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
                Save(saveFileDialog1.FileName);
            }
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.S)
            {
                if (saveFilePath != "")
                    Save(saveFilePath);
                else
                    SaveAs();
            }
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.O)
            {
                Open();
            }
        }
        private void ShakeHull()
        {
            foreach(var shape in shapes.ToList())
            {
                shape.X += random.Next(-2, 3);
                shape.Y += random.Next(-2, 3);
                if (!shape.inShell) shapes.Remove(shape);
            }
            
        }

        private void lineColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MyDialog.ShowDialog() == DialogResult.OK) { lineColor = MyDialog.Color; Refresh(); }
        }

        private void pontColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MyDialog.ShowDialog() == DialogResult.OK) { pointColor = MyDialog.Color; Refresh(); }
        }

    }
}

