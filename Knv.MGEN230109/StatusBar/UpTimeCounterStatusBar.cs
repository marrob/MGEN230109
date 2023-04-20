

namespace Knv.MGEN230109.StatusBar
{
    using System;
    using System.Windows.Forms;
    using Properties;
    using IO;

    class UpTimeCounterStatusBar : ToolStripStatusLabel
    { 
        public UpTimeCounterStatusBar()
        {
            BorderSides = ToolStripStatusLabelBorderSides.Left;
            BorderStyle = Border3DStyle.Etched;
            Size = new System.Drawing.Size(58, 19);
            Text = $"{AppConstants.ValueNotAvailable2}";
            var timer = new Timer();
            timer.Start();
            timer.Interval = 1000;

            timer.Tick += (o, e) =>
            {
                /*
                if (DacIo.Instance.IsOpen)
                    Text = $"{DacIo.Instance.GetUpTime()}";
                */
            };
        }
    }
}
