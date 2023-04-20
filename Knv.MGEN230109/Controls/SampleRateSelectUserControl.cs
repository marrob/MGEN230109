using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Knv.MGEN230109.Controls
{
    public partial class SampleRateSelectUserControl : UserControl
    {

        public event EventHandler<string> SampleRateChanged ;

        public SampleRateSelectUserControl()
        {
            InitializeComponent();


            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is RadioButton)
                {
                    var radio = ctrl as RadioButton;
                    radio.CheckedChanged += (s, arg) => {
                        SampleRateChanged?.Invoke(this, radio.Text);
                    };
                }
            }
        }


        public string GetSelectedSr()
        { 
            foreach(Control ctrl in this.Controls)
            {
                if (ctrl is RadioButton)
                {
                    var radio = ctrl as RadioButton;
                    if(radio.Checked )
                    {
                        return radio.Text;
                    }
                }

            }
            return string.Empty;
        }

        public void SelectSr(string sr)
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is RadioButton)
                {
                    var radio = ctrl as RadioButton;

                    if (radio.Text == sr)
                    {
                        radio.Checked = true;
                    }
                }
            }
        }

    }
}
