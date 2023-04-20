
namespace Knv.MGEN230109
{
    using System;
    using System.Linq;
    using NAudio.CoreAudioApi;
    using NAudio.Wave;

    internal static class AudioTools
    {

        public static void ChangeSampleRate(int sampleRate, string epFriendlyName)
        {
            var mDeviceEnumerator = new MMDeviceEnumerator();
            MMDevice device = mDeviceEnumerator.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active).FirstOrDefault(n => n.FriendlyName == epFriendlyName);
            AudioClient audioClient = device.AudioClient;

            int bits = 24;
            int channels = 2;

            try
            {
                audioClient.Initialize(

                        AudioClientShareMode.Exclusive,
                        AudioClientStreamFlags.RateAdjust,
                        100000,
                        0,
                        new WaveFormat(sampleRate, bits, channels),
                        Guid.Empty
                    );
                audioClient.Dispose();
            }
            catch (Exception ex)
            {

                if ((uint)ex.HResult == (uint)0x8889000F)
                {
                    throw new Exception($"The {epFriendlyName} does't support SampleRate:{sampleRate} Bits: {bits} Channels:{2} - HRESULT:0x{ex.HResult:X8}");
                }
                else if ((uint)ex.HResult == (uint)0x88890008)
                {
                    throw new Exception($"The {epFriendlyName} does't support SampleRate:{sampleRate} Bits: {bits} Channels:{2} - HRESULT:0x{ex.HResult:X8}");
                }
                else
                {
                    throw ex;
                }
            }
        }
    }
}
