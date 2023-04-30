
namespace Knv.MGEN230109
{
    using Knv.MGEN230109.Events;
    using NAudio.Wave;
    using System;

    internal class AsioPlayer : IDisposable
    {

        bool _disposed;

        WaveStream waveStream;
        AsioOut asioOut;


        public AsioPlayer(string filePath, string sampleRateHz, string asioDriverName, string chName)
        {
            int sr = int.Parse(sampleRateHz);
            waveStream = new WaveFileReader(filePath);
            waveStream = new WaveFormatConversionStream(new WaveFormat(sr, waveStream.WaveFormat.Channels), waveStream);

            asioOut = new AsioOut(asioDriverName);
            asioOut.PlaybackStopped += (sender, arg) =>
            {
                EventAggregator.Instance.Publish(new PlayerStatusAppEvent(asioOut.PlaybackState.ToString()));
            };

            for (int ch = 0; ch < asioOut.DriverOutputChannelCount; ch++)
            {
                if (asioOut.AsioOutputChannelName(ch) == chName)
                {
                    asioOut.ChannelOffset = ch;
                    break;
                }
            }

            asioOut.Init(waveStream);
            try
            {
                asioOut.Play();
                EventAggregator.Instance.Publish(new PlayerStatusAppEvent(asioOut.PlaybackState.ToString()));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Stop()
        {
            asioOut.Stop();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                if (asioOut != null)
                    asioOut.Dispose();
            }
            _disposed = true;
        }
    }
}
