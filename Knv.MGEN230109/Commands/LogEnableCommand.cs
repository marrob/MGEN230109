
namespace Knv.MGEN230109.Commands
{
    using System;
    using System.Diagnostics;
    using System.Windows.Forms;
    using System.Drawing;
    using Properties;
    using Events;
    using IO;


    class LogEnableCommand : ToolStripMenuItem
    {
        public LogEnableCommand()
        {
            Text = "Log";
            ShortcutKeys = Keys.F7;
            DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            Enabled = true;

        }
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);

        }
    }
}
