
namespace Knv.MGEN230109.Commands
{
    using System;
    using System.Diagnostics;
    using System.Windows.Forms;
    using Properties;
    using Events;
    using NAudio.CoreAudioApi;
    using NAudio.Wave;
    using System.Collections.Generic;

    class ChannelSelectCommand : ToolStripComboBox
    {
        string selectFromListText = "Válassz...";

        public ChannelSelectCommand()
        {
            Text = selectFromListText;
            Enabled = true;
            BackColor = System.Drawing.SystemColors.Control;

            DropDownStyle = ComboBoxStyle.DropDownList;
            Size = new System.Drawing.Size(300, 25);

            DropDown += (o, e) =>{
                Items.Clear();

                if (Settings.Default.AudioDriver == "WASAPI")
                {

                }
                else if(Settings.Default.AudioDriver == "ASIO")
                {
                    AsioOut asioOut = new AsioOut(Settings.Default.AuidoEndpointName);
                    for (int ch = 0; ch < asioOut.DriverOutputChannelCount; ch++)
                    {
                        string channelName = asioOut.AsioOutputChannelName(ch);
                        Items.Add(channelName);
                    }
                }
            };

            DropDownClosed += (o, e) =>{
                Control p;
                p = ((ToolStripComboBox)o).Control;
                p.Parent.Focus();
                Settings.Default.ChannelName = Text;
            };

            EventAggregator.Instance.Subscribe((Action<ShowAppEvent>)(e =>
            {
                Items.Clear();
                if (!string.IsNullOrWhiteSpace(Settings.Default.ChannelName))
                { 
                    if(!Items.Contains(Settings.Default.ChannelName))
                        Items.Add(Settings.Default.ChannelName);
                    Text = Settings.Default.ChannelName;
                }
                else
                {
                    if (!Items.Contains(selectFromListText))
                        Items.Add(selectFromListText);
                    Text = selectFromListText;
                }
            }));

            EventAggregator.Instance.Subscribe((Action<ConnectionChangedAppEvent>)(e =>
            {
                Enabled = !e.IsOpen;       
            }));
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            Debug.WriteLine(this.GetType().Namespace + "." + this.GetType().Name + "." + System.Reflection.MethodBase.GetCurrentMethod().Name + "()");
        }
    }
}
