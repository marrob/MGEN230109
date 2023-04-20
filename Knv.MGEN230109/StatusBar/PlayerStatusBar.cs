namespace Knv.MGEN230109.StatusBar
{
    using System;
    using System.Windows.Forms;
    using Properties;
    using Events;
    using IO;

    class PlayerStatus : ToolStripStatusLabel
    { 
        public PlayerStatus()
        {
            BorderSides = ToolStripStatusLabelBorderSides.Left;
            BorderStyle = Border3DStyle.Etched;
            Size = new System.Drawing.Size(58, 19);
            Text =  AppConstants.ValueNotAvailable2;
            
            EventAggregator.Instance.Subscribe((Action<PlayerStatusAppEvent>)(e =>
            {
                    Text = e.Status;
            }));
        }
    }
}
