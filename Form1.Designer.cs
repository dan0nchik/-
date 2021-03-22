namespace Многоугольники
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.typeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.circleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.squareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.triangleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lineColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pontColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.radiusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.algorithmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jarvisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.byDefinitionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.plotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jarvisToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.byDefinitionToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.bothToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jarvisVsParallelJarvisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parallelJarvisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playStopButton = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.skipForwardButton = new System.Windows.Forms.Button();
            this.skipBackwardButton = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.typeToolStripMenuItem,
            this.algorithmToolStripMenuItem,
            this.plotToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(880, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // typeToolStripMenuItem
            // 
            this.typeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.circleToolStripMenuItem,
            this.squareToolStripMenuItem,
            this.triangleToolStripMenuItem,
            this.lineColorToolStripMenuItem,
            this.pontColorToolStripMenuItem,
            this.radiusToolStripMenuItem});
            this.typeToolStripMenuItem.Name = "typeToolStripMenuItem";
            this.typeToolStripMenuItem.Size = new System.Drawing.Size(65, 29);
            this.typeToolStripMenuItem.Text = "View";
            // 
            // circleToolStripMenuItem
            // 
            this.circleToolStripMenuItem.Name = "circleToolStripMenuItem";
            this.circleToolStripMenuItem.Size = new System.Drawing.Size(226, 34);
            this.circleToolStripMenuItem.Text = "Circle (default)";
            this.circleToolStripMenuItem.Click += new System.EventHandler(this.circleToolStripMenuItem_Click);
            // 
            // squareToolStripMenuItem
            // 
            this.squareToolStripMenuItem.Name = "squareToolStripMenuItem";
            this.squareToolStripMenuItem.Size = new System.Drawing.Size(226, 34);
            this.squareToolStripMenuItem.Text = "Square";
            this.squareToolStripMenuItem.Click += new System.EventHandler(this.squareToolStripMenuItem_Click);
            // 
            // triangleToolStripMenuItem
            // 
            this.triangleToolStripMenuItem.Name = "triangleToolStripMenuItem";
            this.triangleToolStripMenuItem.Size = new System.Drawing.Size(226, 34);
            this.triangleToolStripMenuItem.Text = "Triangle";
            this.triangleToolStripMenuItem.Click += new System.EventHandler(this.triangleToolStripMenuItem_Click);
            // 
            // lineColorToolStripMenuItem
            // 
            this.lineColorToolStripMenuItem.Name = "lineColorToolStripMenuItem";
            this.lineColorToolStripMenuItem.Size = new System.Drawing.Size(226, 34);
            this.lineColorToolStripMenuItem.Text = "Line color";
            this.lineColorToolStripMenuItem.Click += new System.EventHandler(this.lineColorToolStripMenuItem_Click);
            // 
            // pontColorToolStripMenuItem
            // 
            this.pontColorToolStripMenuItem.Name = "pontColorToolStripMenuItem";
            this.pontColorToolStripMenuItem.Size = new System.Drawing.Size(226, 34);
            this.pontColorToolStripMenuItem.Text = "Pont color";
            this.pontColorToolStripMenuItem.Click += new System.EventHandler(this.pontColorToolStripMenuItem_Click);
            // 
            // radiusToolStripMenuItem
            // 
            this.radiusToolStripMenuItem.Name = "radiusToolStripMenuItem";
            this.radiusToolStripMenuItem.Size = new System.Drawing.Size(226, 34);
            this.radiusToolStripMenuItem.Text = "Radius";
            this.radiusToolStripMenuItem.Click += new System.EventHandler(this.radiusToolStripMenuItem_Click);
            // 
            // algorithmToolStripMenuItem
            // 
            this.algorithmToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.jarvisToolStripMenuItem,
            this.byDefinitionToolStripMenuItem});
            this.algorithmToolStripMenuItem.Name = "algorithmToolStripMenuItem";
            this.algorithmToolStripMenuItem.Size = new System.Drawing.Size(113, 29);
            this.algorithmToolStripMenuItem.Text = " Algorithm";
            this.algorithmToolStripMenuItem.Click += new System.EventHandler(this.algorithmToolStripMenuItem_Click);
            // 
            // jarvisToolStripMenuItem
            // 
            this.jarvisToolStripMenuItem.Name = "jarvisToolStripMenuItem";
            this.jarvisToolStripMenuItem.Size = new System.Drawing.Size(213, 34);
            this.jarvisToolStripMenuItem.Text = "Jarvis";
            this.jarvisToolStripMenuItem.Click += new System.EventHandler(this.jarvisToolStripMenuItem_Click);
            // 
            // byDefinitionToolStripMenuItem
            // 
            this.byDefinitionToolStripMenuItem.Name = "byDefinitionToolStripMenuItem";
            this.byDefinitionToolStripMenuItem.Size = new System.Drawing.Size(213, 34);
            this.byDefinitionToolStripMenuItem.Text = "By definition";
            this.byDefinitionToolStripMenuItem.Click += new System.EventHandler(this.byDefinitionToolStripMenuItem_Click);
            // 
            // plotToolStripMenuItem
            // 
            this.plotToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.jarvisToolStripMenuItem1,
            this.byDefinitionToolStripMenuItem1,
            this.bothToolStripMenuItem,
            this.jarvisVsParallelJarvisToolStripMenuItem,
            this.parallelJarvisToolStripMenuItem});
            this.plotToolStripMenuItem.Name = "plotToolStripMenuItem";
            this.plotToolStripMenuItem.Size = new System.Drawing.Size(59, 29);
            this.plotToolStripMenuItem.Text = "Plot";
            // 
            // jarvisToolStripMenuItem1
            // 
            this.jarvisToolStripMenuItem1.Name = "jarvisToolStripMenuItem1";
            this.jarvisToolStripMenuItem1.Size = new System.Drawing.Size(284, 34);
            this.jarvisToolStripMenuItem1.Text = "Jarvis";
            this.jarvisToolStripMenuItem1.Click += new System.EventHandler(this.jarvisToolStripMenuItem1_Click);
            // 
            // byDefinitionToolStripMenuItem1
            // 
            this.byDefinitionToolStripMenuItem1.Name = "byDefinitionToolStripMenuItem1";
            this.byDefinitionToolStripMenuItem1.Size = new System.Drawing.Size(284, 34);
            this.byDefinitionToolStripMenuItem1.Text = "By definition";
            this.byDefinitionToolStripMenuItem1.Click += new System.EventHandler(this.byDefinitionToolStripMenuItem1_Click);
            // 
            // bothToolStripMenuItem
            // 
            this.bothToolStripMenuItem.Name = "bothToolStripMenuItem";
            this.bothToolStripMenuItem.Size = new System.Drawing.Size(284, 34);
            this.bothToolStripMenuItem.Text = "Both";
            this.bothToolStripMenuItem.Click += new System.EventHandler(this.bothToolStripMenuItem_Click);
            // 
            // jarvisVsParallelJarvisToolStripMenuItem
            // 
            this.jarvisVsParallelJarvisToolStripMenuItem.Name = "jarvisVsParallelJarvisToolStripMenuItem";
            this.jarvisVsParallelJarvisToolStripMenuItem.Size = new System.Drawing.Size(284, 34);
            this.jarvisVsParallelJarvisToolStripMenuItem.Text = "Jarvis vs Parallel Jarvis";
            this.jarvisVsParallelJarvisToolStripMenuItem.Click += new System.EventHandler(this.jarvisVsParallelJarvisToolStripMenuItem_Click);
            // 
            // parallelJarvisToolStripMenuItem
            // 
            this.parallelJarvisToolStripMenuItem.Name = "parallelJarvisToolStripMenuItem";
            this.parallelJarvisToolStripMenuItem.Size = new System.Drawing.Size(284, 34);
            this.parallelJarvisToolStripMenuItem.Text = "Parallel Jarvis";
            this.parallelJarvisToolStripMenuItem.Click += new System.EventHandler(this.parallelJarvisToolStripMenuItem_Click);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.newToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(54, 29);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.saveToolStripMenuItem.Text = "Save (Ctrl+S)";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.openToolStripMenuItem.Text = "Open (Ctrl+O)";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // playStopButton
            // 
            this.playStopButton.BackgroundImage = global::Многоугольники.Properties.Resources.play_button_arrowhead;
            this.playStopButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.playStopButton.Location = new System.Drawing.Point(350, 0);
            this.playStopButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.playStopButton.Name = "playStopButton";
            this.playStopButton.Size = new System.Drawing.Size(30, 32);
            this.playStopButton.TabIndex = 1;
            this.playStopButton.UseVisualStyleBackColor = true;
            this.playStopButton.Click += new System.EventHandler(this.playStopButton_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // skipForwardButton
            // 
            this.skipForwardButton.BackgroundImage = global::Многоугольники.Properties.Resources.next;
            this.skipForwardButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.skipForwardButton.Location = new System.Drawing.Point(384, 0);
            this.skipForwardButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.skipForwardButton.Name = "skipForwardButton";
            this.skipForwardButton.Size = new System.Drawing.Size(31, 32);
            this.skipForwardButton.TabIndex = 2;
            this.skipForwardButton.UseVisualStyleBackColor = true;
            this.skipForwardButton.Click += new System.EventHandler(this.skipForwardButton_Click);
            // 
            // skipBackwardButton
            // 
            this.skipBackwardButton.BackgroundImage = global::Многоугольники.Properties.Resources.next__1_;
            this.skipBackwardButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.skipBackwardButton.Location = new System.Drawing.Point(315, 0);
            this.skipBackwardButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.skipBackwardButton.Name = "skipBackwardButton";
            this.skipBackwardButton.Size = new System.Drawing.Size(30, 32);
            this.skipBackwardButton.TabIndex = 3;
            this.skipBackwardButton.UseVisualStyleBackColor = true;
            this.skipBackwardButton.Click += new System.EventHandler(this.skipBackwardButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 583);
            this.Controls.Add(this.skipBackwardButton);
            this.Controls.Add(this.skipForwardButton);
            this.Controls.Add(this.playStopButton);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Polygons";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem typeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem circleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem squareToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem triangleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem algorithmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jarvisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem byDefinitionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem plotToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jarvisToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem byDefinitionToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem bothToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lineColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pontColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem radiusToolStripMenuItem;
        private System.Windows.Forms.Button playStopButton;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button skipForwardButton;
        private System.Windows.Forms.Button skipBackwardButton;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jarvisVsParallelJarvisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem parallelJarvisToolStripMenuItem;
    }
}

