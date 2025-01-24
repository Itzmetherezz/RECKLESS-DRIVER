namespace T_Rex
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lblScore = new Label();
            pictureBox1 = new PictureBox();
            trex = new PictureBox();
            obstacle1 = new PictureBox();
            obstacle2 = new PictureBox();
            obstacle3 = new PictureBox();
            GameTimer = new System.Windows.Forms.Timer(components);
            gameend = new Panel();
            lblendscore = new Label();
            label1 = new Label();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trex).BeginInit();
            ((System.ComponentModel.ISupportInitialize)obstacle1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)obstacle2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)obstacle3).BeginInit();
            gameend.SuspendLayout();
            SuspendLayout();
            // 
            // lblScore
            // 
            lblScore.AutoSize = true;
            lblScore.Location = new Point(12, 9);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(50, 20);
            lblScore.TabIndex = 0;
            lblScore.Text = "label1";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Location = new Point(-6, 403);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(864, 50);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // trex
            // 
            trex.BackColor = Color.Transparent;
            trex.Image = Properties.Resources.dino_run;
            trex.Location = new Point(217, 312);
            trex.Name = "trex";
            trex.Size = new Size(88, 92);
            trex.SizeMode = PictureBoxSizeMode.AutoSize;
            trex.TabIndex = 2;
            trex.TabStop = false;
            // 
            // obstacle1
            // 
            obstacle1.BackColor = Color.Transparent;
            obstacle1.Image = Properties.Resources.cactus1;
            obstacle1.Location = new Point(436, 353);
            obstacle1.Name = "obstacle1";
            obstacle1.Size = new Size(33, 51);
            obstacle1.SizeMode = PictureBoxSizeMode.StretchImage;
            obstacle1.TabIndex = 3;
            obstacle1.TabStop = false;
            obstacle1.Tag = "obstacle";
            // 
            // obstacle2
            // 
            obstacle2.BackColor = Color.Transparent;
            obstacle2.Image = Properties.Resources.cactus2;
            obstacle2.Location = new Point(542, 353);
            obstacle2.Name = "obstacle2";
            obstacle2.Size = new Size(57, 51);
            obstacle2.SizeMode = PictureBoxSizeMode.StretchImage;
            obstacle2.TabIndex = 4;
            obstacle2.TabStop = false;
            obstacle2.Tag = "obstacle";
            // 
            // obstacle3
            // 
            obstacle3.BackColor = Color.Transparent;
            obstacle3.Image = Properties.Resources.flying;
            obstacle3.Location = new Point(669, 365);
            obstacle3.Name = "obstacle3";
            obstacle3.Size = new Size(64, 39);
            obstacle3.SizeMode = PictureBoxSizeMode.StretchImage;
            obstacle3.TabIndex = 5;
            obstacle3.TabStop = false;
            obstacle3.Tag = "obstacle";
            // 
            // GameTimer
            // 
            GameTimer.Enabled = true;
            GameTimer.Interval = 20;
            GameTimer.Tick += GameTimerEvent;
            // 
            // gameend
            // 
            gameend.BackColor = Color.Transparent;
            gameend.Controls.Add(lblendscore);
            gameend.Controls.Add(label1);
            gameend.Controls.Add(button1);
            gameend.Location = new Point(392, -1);
            gameend.Name = "gameend";
            gameend.Size = new Size(458, 154);
            gameend.TabIndex = 6;
            gameend.Visible = false;
            // 
            // lblendscore
            // 
            lblendscore.AutoSize = true;
            lblendscore.Font = new Font("Jokerman", 28.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblendscore.ForeColor = Color.DeepPink;
            lblendscore.Location = new Point(301, 180);
            lblendscore.Name = "lblendscore";
            lblendscore.Size = new Size(0, 68);
            lblendscore.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Jokerman", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Maroon;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(475, 88);
            label1.TabIndex = 0;
            label1.Text = "GAME  OVER!!";
            // 
            // button1
            // 
            button1.BackColor = Color.Transparent;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Jokerman", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.Maroon;
            button1.Location = new Point(150, 91);
            button1.Name = "button1";
            button1.Size = new Size(145, 60);
            button1.TabIndex = 1;
            button1.Text = "Restart";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(862, 433);
            Controls.Add(gameend);
            Controls.Add(obstacle3);
            Controls.Add(obstacle2);
            Controls.Add(obstacle1);
            Controls.Add(pictureBox1);
            Controls.Add(lblScore);
            Controls.Add(trex);
            DoubleBuffered = true;
            Name = "Form1";
            Tag = "T-Rex Runner  ";
            Text = "Form1";
            Load += Form1_Load;
            Paint += FormPaintEvent;
            KeyDown += KeyIsDown;
            KeyUp += KeyIsUp;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)trex).EndInit();
            ((System.ComponentModel.ISupportInitialize)obstacle1).EndInit();
            ((System.ComponentModel.ISupportInitialize)obstacle2).EndInit();
            ((System.ComponentModel.ISupportInitialize)obstacle3).EndInit();
            gameend.ResumeLayout(false);
            gameend.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblScore;
        private PictureBox pictureBox1;
        private PictureBox trex;
        private PictureBox obstacle1;
        private PictureBox obstacle2;
        private PictureBox obstacle3;
        private System.Windows.Forms.Timer GameTimer;
        private Panel gameend;
        private Label label1;
        private Button button1;
        private Label lblendscore;
    }
}
