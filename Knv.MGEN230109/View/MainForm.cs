
namespace Knv.MGEN230109.View
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using Controls;
    using IO;
    using Events;
    using System.Resources;
    using Knv.MGEN230109.Properties;
    using System.Runtime.Remoting.Channels;

    public interface IMainForm
    {

        event EventHandler Shown;
        event FormClosedEventHandler FormClosed;
        event FormClosingEventHandler FormClosing;
        event EventHandler<int> SampleRateChanged;
        event EventHandler Play;
        event EventHandler Stop;

        string AuidoFilePath { get; set; }
        string SampleRate { get; set; }
        string Text { get; set; }
        ToolStripItem[] MenuBar { set; }
        KnvRichTextBox RichTextBoxTrace { get; }
        ToolStripItem[] StatusBar { set; }
    }

    public partial class MainForm : Form, IMainForm
    {
        public event EventHandler<int> SampleRateChanged;
        public event EventHandler Play;
        public event EventHandler Stop;
        public string AuidoFilePath { get; set; }
        public string SampleRate { get; set; }

        public ToolStripItem[] MenuBar
        {
            set { menuStrip1.Items.AddRange(value); }
        }

        public KnvRichTextBox RichTextBoxTrace
        {
            get { return knvRichTextBox1; }
        }
      
        public ToolStripItem[] StatusBar
        {
            set { statusStrip1.Items.AddRange(value); }
        }

        public MainForm()
        {
            InitializeComponent();
            EventAggregator.Instance.Subscribe((Action<ConnectionChangedAppEvent>)(e =>
            {
                splitContainer1.Panel1.Enabled = true;
              
            }));


            sampleRateSelectUserControl1.SelectSr(Settings.Default.SampleRate);  


            timer1.Start();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void sampleRateSelectUserControl1_SampleRateChanged(object sender, string e)
        {
            SampleRate = e;
            Settings.Default.SampleRate = e;
        }

        private void buttonDacHelp_Click(object sender, EventArgs e)
        {
            new DacHelpForm().Show();
        }

        private void buttonSR_44100_Click(object sender, EventArgs e)
        {
            SampleRateChanged?.Invoke(this, int.Parse((sender as Button).Text));
        }

        private void buttonSR_48000_Click(object sender, EventArgs e)
        {
            SampleRateChanged?.Invoke(this, int.Parse((sender as Button).Text));
        }

        private void buttonSR_32000_Click(object sender, EventArgs e)
        {
            SampleRateChanged?.Invoke(this, int.Parse((sender as Button).Text));
        }

        private void buttonSR_96000_Click(object sender, EventArgs e)
        {
            SampleRateChanged?.Invoke(this, int.Parse((sender as Button).Text));
        }

        private void buttonSR_88200_Click(object sender, EventArgs e)
        {
            SampleRateChanged?.Invoke(this, int.Parse((sender as Button).Text));
        }

        private void buttonSR_192000_Click(object sender, EventArgs e)
        {
            SampleRateChanged?.Invoke(this, int.Parse((sender as Button).Text));
        }

        private void buttonSR_176400_Click(object sender, EventArgs e)
        {
            SampleRateChanged?.Invoke(this, int.Parse((sender as Button).Text));
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            AuidoFilePath = AppConstants.SampleWaveFilePath;
            Play.Invoke(this, EventArgs.Empty);
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            Stop?.Invoke(this, EventArgs.Empty);
        }


    }
}
