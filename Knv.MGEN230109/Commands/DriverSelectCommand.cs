
namespace Knv.MGEN230109.Commands
{
    using System;
    using System.Diagnostics;
    using System.Windows.Forms;
    using Properties;
    using Events;
    using NAudio.CoreAudioApi;



    class DriverSelectCommand : ToolStripComboBox
    {
        string selectFromListText = "Válassz...";

        public DriverSelectCommand()
        {
            Text = selectFromListText;
            Enabled = true;
            BackColor = System.Drawing.SystemColors.Control;
            DropDownStyle = ComboBoxStyle.DropDownList;
            Size = new System.Drawing.Size(50, 25);

            Items.AddRange(new string[] { "ASIO", "WASAPI" });


            DropDownClosed += (o, e) =>{
                Control p;
                p = ((ToolStripComboBox)o).Control;
                p.Parent.Focus();
                Settings.Default.AudioDriver = Text;
            };

            EventAggregator.Instance.Subscribe((Action<ShowAppEvent>)(e =>
            {
                Items.Clear();
                Items.AddRange(new string[] { "ASIO", "WASAPI" });

                if (!string.IsNullOrWhiteSpace(Settings.Default.AudioDriver))
                {
                    Text = Settings.Default.AudioDriver;
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
