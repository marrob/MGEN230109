namespace Knv.MGEN230109
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using System.Threading;
    using Properties;
    using System.Diagnostics;
    using Common;
    using IO;
    using System.ComponentModel;
    using System.Drawing;
    using Events;
    using View;
    using Controls;



    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

//#if !DEBUG
            Application.SetCompatibleTextRenderingDefault(false);
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += ApplicationOnThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;
//#endif
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            new App();
        }

        private static void CurrentDomainOnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            AppLog.Instance.WriteLine("");
        }
        private static void ApplicationOnThreadException(object sender, ThreadExceptionEventArgs e)
        {
            AppLog.Instance.WriteLine("");
        }
    }


    public class App
    {
        public static SynchronizationContext SyncContext = null;
        internal IMainForm _mainForm { get; set; }
        internal AsioPlayer _player;
        

        public App()
        {
            _mainForm = new MainForm();
            _mainForm.Text = AppConstants.SoftwareTitle;

            /*** Main Menu ***/
            _mainForm.MenuBar = new ToolStripItem[]
            {
                new Commands.DriverSelectCommand(),
                new Commands.EndpointSelectCommand(),
                new Commands.ChannelSelectCommand(),
                new Commands.HowIsWorkingCommand(),
                new Commands.LogEnableCommand(),
            };

            /*** StatusBar ***/
            #region StatusBar
            _mainForm.StatusBar = new ToolStripItem[]
            {
                new StatusBar.PlayerStatus(),
                new StatusBar.UpTimeCounterStatusBar(),
                new StatusBar.FwVersion(),
                new StatusBar.EmptyStatusBar(),
                new StatusBar.VersionStatus(),
                new StatusBar.LogoStatusBar(),
            };

            _mainForm.FormClosed += MainForm_FormClosed;
            _mainForm.Shown += MainForm_Shown;


            if (string.IsNullOrEmpty(Settings.Default.SampleRate))
            {
                Settings.Default.SampleRate = "44100";
            }



            _mainForm.SampleRateChanged += (s, sr) =>
            {
                AudioTools.ChangeSampleRate(sr, Settings.Default.AuidoEndpointName);
            };

            _mainForm.Play += (s, path) =>
            {
                if(Settings.Default.AudioDriver == "ASIO")
                    _player = new AsioPlayer(   _mainForm.AuidoFilePath,
                                                Settings.Default.SampleRate,
                                                Settings.Default.AuidoEndpointName,                   
                                                Settings.Default.ChannelName);
            };
            _mainForm.Stop += (s, e) =>
            {
                _player?.Stop();
                _player?.Dispose();
                _player = null;
            };
            
            var timer = new System.Windows.Forms.Timer() { Interval = 200 };
            timer.Start();

            object obj = new object();
            int currentLines = 5;
            timer.Tick += (o, e) =>
            {
                lock (obj)
                {
                    /*
                    while (DacIo.Instance.TraceQueue.Count != 0)
                    {
                        string str = DacIo.Instance.TraceQueue.Dequeue();

                        Log.Instance.WirteLine(str);

                        if (str.Contains("Rx:"))
                            _mainForm.RichTextBoxTrace.AppendText(str + "\r\n", Color.DarkGreen, false);
                        else if (str.Contains("Tx:"))
                            _mainForm.RichTextBoxTrace.AppendText(str + "\r\n", Color.Blue);
                        else if (str.Contains("ERROR"))
                            _mainForm.RichTextBoxTrace.AppendText(str + "\r\n", Color.Red);
                        else
                            _mainForm.RichTextBoxTrace.AppendText(str + "\r\n", Color.Black);

                        //Auto Scroll
                        _mainForm.RichTextBoxTrace.SelectionStart = _mainForm.RichTextBoxTrace.Text.Length;
                        _mainForm.RichTextBoxTrace.ScrollToCaret();

                        if (currentLines++ > 5)
                        {
                            currentLines = 0;
                            break;
                        }
                    }
                    */
                }
            };
            #endregion

            /*** Run ***/
            Application.Run((MainForm)_mainForm);
        }



        private void MainForm_Shown(object sender, EventArgs e)
        {
            SyncContext = SynchronizationContext.Current;
            EventAggregator.Instance.Publish(new ShowAppEvent());
        }

        void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Settings.Default.Save();
            EventAggregator.Instance.Dispose();
            if(_player != null)
                _player.Dispose();
        }

    }
}
