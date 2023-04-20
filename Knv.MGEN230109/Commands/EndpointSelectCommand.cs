
namespace Knv.MGEN230109.Commands
{
    using System;
    using System.Diagnostics;
    using System.Windows.Forms;
    using Properties;
    using Events;
    using NAudio.CoreAudioApi;
    using NAudio.Wave;

    class EndpointSelectCommand : ToolStripComboBox
    {
        string selectFromListText = "Válassz...";

        public EndpointSelectCommand()
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
                    var devs = new MMDeviceEnumerator();
                    foreach (var dev in devs.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active))
                        Items.Add(dev.FriendlyName);
                }
                else if(Settings.Default.AudioDriver == "ASIO")
                {
                    var asioDriverNames = AsioOut.GetDriverNames();
                    foreach (string driverName in asioDriverNames)
                        Items.Add(driverName); //ASIO 2.0 - ESI MAYA44
                }
            };

            DropDownClosed += (o, e) =>{
                Control p;
                p = ((ToolStripComboBox)o).Control;
                p.Parent.Focus();
                Settings.Default.AuidoEndpointName = Text;
            };

            EventAggregator.Instance.Subscribe((Action<ShowAppEvent>)(e =>
            {               
                Items.Clear();
                if (!string.IsNullOrWhiteSpace(Settings.Default.AuidoEndpointName))
                {
                    if (!Items.Contains(Settings.Default.AuidoEndpointName))
                        Items.Add(Settings.Default.AuidoEndpointName);
                    Text = Settings.Default.AuidoEndpointName;
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
