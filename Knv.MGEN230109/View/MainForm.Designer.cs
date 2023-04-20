namespace Knv.MGEN230109.View
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonSR_32000 = new System.Windows.Forms.Button();
            this.buttonSR_192000 = new System.Windows.Forms.Button();
            this.buttonSR_176400 = new System.Windows.Forms.Button();
            this.buttonSR_96000 = new System.Windows.Forms.Button();
            this.buttonSR_88200 = new System.Windows.Forms.Button();
            this.buttonSR_48000 = new System.Windows.Forms.Button();
            this.buttonSR_44100 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.sampleRateSelectUserControl1 = new Knv.MGEN230109.Controls.SampleRateSelectUserControl();
            this.knvRichTextBox1 = new Knv.MGEN230109.Controls.KnvRichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 357);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(780, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(780, 24);
            this.menuStrip1.TabIndex = 21;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.sampleRateSelectUserControl1);
            this.splitContainer1.Panel1.Controls.Add(this.buttonStop);
            this.splitContainer1.Panel1.Controls.Add(this.buttonPlay);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.knvRichTextBox1);
            this.splitContainer1.Size = new System.Drawing.Size(780, 333);
            this.splitContainer1.SplitterDistance = 299;
            this.splitContainer1.TabIndex = 22;
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(619, 87);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(75, 23);
            this.buttonStop.TabIndex = 6;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonPlay
            // 
            this.buttonPlay.Location = new System.Drawing.Point(619, 58);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(75, 23);
            this.buttonPlay.TabIndex = 5;
            this.buttonPlay.Text = "Play";
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonSR_32000);
            this.groupBox1.Controls.Add(this.buttonSR_192000);
            this.groupBox1.Controls.Add(this.buttonSR_176400);
            this.groupBox1.Controls.Add(this.buttonSR_96000);
            this.groupBox1.Controls.Add(this.buttonSR_88200);
            this.groupBox1.Controls.Add(this.buttonSR_48000);
            this.groupBox1.Controls.Add(this.buttonSR_44100);
            this.groupBox1.Location = new System.Drawing.Point(12, 147);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(171, 139);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sample Rate";
            // 
            // buttonSR_32000
            // 
            this.buttonSR_32000.Location = new System.Drawing.Point(6, 106);
            this.buttonSR_32000.Name = "buttonSR_32000";
            this.buttonSR_32000.Size = new System.Drawing.Size(75, 23);
            this.buttonSR_32000.TabIndex = 6;
            this.buttonSR_32000.Text = "32000";
            this.buttonSR_32000.UseVisualStyleBackColor = true;
            this.buttonSR_32000.Click += new System.EventHandler(this.buttonSR_32000_Click);
            // 
            // buttonSR_192000
            // 
            this.buttonSR_192000.Location = new System.Drawing.Point(87, 19);
            this.buttonSR_192000.Name = "buttonSR_192000";
            this.buttonSR_192000.Size = new System.Drawing.Size(75, 23);
            this.buttonSR_192000.TabIndex = 2;
            this.buttonSR_192000.Text = "192000";
            this.buttonSR_192000.UseVisualStyleBackColor = true;
            this.buttonSR_192000.Click += new System.EventHandler(this.buttonSR_192000_Click);
            // 
            // buttonSR_176400
            // 
            this.buttonSR_176400.Location = new System.Drawing.Point(6, 19);
            this.buttonSR_176400.Name = "buttonSR_176400";
            this.buttonSR_176400.Size = new System.Drawing.Size(75, 23);
            this.buttonSR_176400.TabIndex = 4;
            this.buttonSR_176400.Text = "176400";
            this.buttonSR_176400.UseVisualStyleBackColor = true;
            this.buttonSR_176400.Click += new System.EventHandler(this.buttonSR_176400_Click);
            // 
            // buttonSR_96000
            // 
            this.buttonSR_96000.Location = new System.Drawing.Point(87, 48);
            this.buttonSR_96000.Name = "buttonSR_96000";
            this.buttonSR_96000.Size = new System.Drawing.Size(75, 23);
            this.buttonSR_96000.TabIndex = 3;
            this.buttonSR_96000.Text = "96000";
            this.buttonSR_96000.UseVisualStyleBackColor = true;
            this.buttonSR_96000.Click += new System.EventHandler(this.buttonSR_96000_Click);
            // 
            // buttonSR_88200
            // 
            this.buttonSR_88200.Location = new System.Drawing.Point(6, 48);
            this.buttonSR_88200.Name = "buttonSR_88200";
            this.buttonSR_88200.Size = new System.Drawing.Size(75, 23);
            this.buttonSR_88200.TabIndex = 2;
            this.buttonSR_88200.Text = "88200";
            this.buttonSR_88200.UseVisualStyleBackColor = true;
            this.buttonSR_88200.Click += new System.EventHandler(this.buttonSR_88200_Click);
            // 
            // buttonSR_48000
            // 
            this.buttonSR_48000.Location = new System.Drawing.Point(87, 77);
            this.buttonSR_48000.Name = "buttonSR_48000";
            this.buttonSR_48000.Size = new System.Drawing.Size(75, 23);
            this.buttonSR_48000.TabIndex = 1;
            this.buttonSR_48000.Text = "48000";
            this.buttonSR_48000.UseVisualStyleBackColor = true;
            this.buttonSR_48000.Click += new System.EventHandler(this.buttonSR_48000_Click);
            // 
            // buttonSR_44100
            // 
            this.buttonSR_44100.Location = new System.Drawing.Point(6, 77);
            this.buttonSR_44100.Name = "buttonSR_44100";
            this.buttonSR_44100.Size = new System.Drawing.Size(75, 23);
            this.buttonSR_44100.TabIndex = 0;
            this.buttonSR_44100.Text = "44100";
            this.buttonSR_44100.UseVisualStyleBackColor = true;
            this.buttonSR_44100.Click += new System.EventHandler(this.buttonSR_44100_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // sampleRateSelectUserControl1
            // 
            this.sampleRateSelectUserControl1.Location = new System.Drawing.Point(468, 58);
            this.sampleRateSelectUserControl1.Name = "sampleRateSelectUserControl1";
            this.sampleRateSelectUserControl1.Size = new System.Drawing.Size(129, 94);
            this.sampleRateSelectUserControl1.TabIndex = 7;
            this.sampleRateSelectUserControl1.SampleRateChanged += new System.EventHandler<string>(this.sampleRateSelectUserControl1_SampleRateChanged);
            // 
            // knvRichTextBox1
            // 
            this.knvRichTextBox1.BackgroundText = "Backgorund Text";
            this.knvRichTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.knvRichTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.knvRichTextBox1.Location = new System.Drawing.Point(0, 0);
            this.knvRichTextBox1.Name = "knvRichTextBox1";
            this.knvRichTextBox1.Size = new System.Drawing.Size(780, 30);
            this.knvRichTextBox1.TabIndex = 0;
            this.knvRichTextBox1.Text = "";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 379);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Controls.KnvRichTextBox knvRichTextBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonSR_48000;
        private System.Windows.Forms.Button buttonSR_44100;
        private System.Windows.Forms.Button buttonSR_32000;
        private System.Windows.Forms.Button buttonSR_192000;
        private System.Windows.Forms.Button buttonSR_176400;
        private System.Windows.Forms.Button buttonSR_96000;
        private System.Windows.Forms.Button buttonSR_88200;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonPlay;
        private Controls.SampleRateSelectUserControl sampleRateSelectUserControl1;
    }
}

