namespace CalcMeToo
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
            this.MainDraw = new System.Windows.Forms.PictureBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnNewRoom = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.MainDraw)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainDraw
            // 
            this.MainDraw.BackColor = System.Drawing.Color.White;
            this.MainDraw.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MainDraw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainDraw.Location = new System.Drawing.Point(0, 0);
            this.MainDraw.Name = "MainDraw";
            this.MainDraw.Size = new System.Drawing.Size(1000, 700);
            this.MainDraw.TabIndex = 0;
            this.MainDraw.TabStop = false;
            this.MainDraw.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MainDraw_MouseClick);
            this.MainDraw.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainDraw_MouseDown);
            this.MainDraw.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainDraw_MouseMove);
            this.MainDraw.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainDraw_MouseUp);
            // 
            // splitter1
            // 
            this.splitter1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Location = new System.Drawing.Point(994, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(6, 700);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnNewRoom);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(1000, 0);
            this.panel1.Name = "panel1";
            this.panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panel1.Size = new System.Drawing.Size(200, 700);
            this.panel1.TabIndex = 3;
            // 
            // btnNewRoom
            // 
            this.btnNewRoom.ForeColor = System.Drawing.Color.Black;
            this.btnNewRoom.Location = new System.Drawing.Point(15, 12);
            this.btnNewRoom.Name = "btnNewRoom";
            this.btnNewRoom.Size = new System.Drawing.Size(96, 23);
            this.btnNewRoom.TabIndex = 0;
            this.btnNewRoom.Text = "Новая комната";
            this.btnNewRoom.UseVisualStyleBackColor = true;
            this.btnNewRoom.Click += new System.EventHandler(this.btnNewRoom_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.MainDraw);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MainDraw)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox MainDraw;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnNewRoom;
    }
}

