namespace Knv.MGEN230109
{
    using NAudio.CoreAudioApi;
    using System;
    using System.Runtime.InteropServices;
    using NAudio.Wave;
    using NUnit.Framework;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Threading;
    using System.Collections.Generic;

    [TestFixture]
    internal class NAudio_UnitTest
    {
        [Test]
        public void ChangeEndpointSampleRate() 
        {
            var deviceEnumerator = new MMDeviceEnumerator();

            foreach (var dev in deviceEnumerator.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active))
            {
                Console.WriteLine(dev.FriendlyName);
            }

            string targetEndpoint = "ESI MAYA44 Ch34 SPDIF (ESI MAYA44 Audio)";

            MMDevice device = deviceEnumerator.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active).FirstOrDefault(n => n.FriendlyName == targetEndpoint);

            AudioClient audioClient = device.AudioClient;
    
            var format = device.AudioClient.MixFormat;


            audioClient.Initialize(

                    AudioClientShareMode.Exclusive,
                    AudioClientStreamFlags.RateAdjust,
                    100000,
                    0,
                    new WaveFormat(192000, 24, 2),
                    Guid.Empty
                );
            audioClient.Dispose();

            Thread.Sleep(500);

            AudioClient audioClient2 = device.AudioClient;

            Console.WriteLine(format.SampleRate.ToString());

        }

        [Test]
        public void WaveFileExistsFromConstatns()
        {
            FileAssert.Exists(AppConstants.SampleWaveFilePath);
        }

        [Test]
        public void WaveFileExists()
        {
            string filePath = AppDomain.CurrentDomain.BaseDirectory + "Resources\\Lana_Del_Ray-Love_48000_16bit_Stereo.wav";
            FileAssert.Exists(filePath);
        }

        [Test]
        public void WasapiWavePlayr()
        {

            /*
             * You can't change the shared mode sample rate using WASAPI.
             */

            string epName = "ESI MAYA44 Ch34 SPDIF (ESI MAYA44 Audio)";
            //string epName = "Headphones (MDR-XB650BT Stereo)";
            string filePath = AppDomain.CurrentDomain.BaseDirectory + "Resources\\Lana_Del_Ray-Love_48000_16bit_Stereo.wav";

            WaveStream waveStream = new WaveFileReader(filePath);
            waveStream = new WaveFormatConversionStream(new WaveFormat(48000, waveStream.WaveFormat.Channels), waveStream);
            WaveOut waveOut = new WaveOut();

            bool found = false;
            for (int i = 0; i < WaveOut.DeviceCount; i++)
            {
                var caps = WaveOut.GetCapabilities(i);
                Console.WriteLine(caps.ProductName);

                

                if (caps.ProductName == epName.Substring(0, 31))
                {
                    waveOut.DeviceNumber = i;
                    found = true;
                    break;
                }
            }

            if (!found)
                throw new ApplicationException($"Endopoint {epName} not found");
            else
            {
                waveOut.Init(waveStream);

                int sr = waveOut.OutputWaveFormat.SampleRate;

                waveOut.Play();

                Thread.Sleep(3000);
            }
        }


        [Test]
        public void GetAsioDrivers()
        {
            // Just fill the comboBox AsioDriver with available driver names
            var asioDriverNames = AsioOut.GetDriverNames();
            foreach (string driverName in asioDriverNames)
                Console.WriteLine(driverName);

            Assert.IsTrue(asioDriverNames.Contains("ASIO 2.0 - ESI MAYA44"));
            Assert.IsTrue(asioDriverNames.Contains("ASIO4ALL v2"));
        }


        [Test]
        [Apartment(ApartmentState.STA)]
        public void GetAsioChannels()
        {
            string asioDriverName = "ASIO4ALL v2";
            AsioOut asioOut = new AsioOut(asioDriverName);
            List<string> asioChannels = new List<string>();

            for (int ch = 0; ch < asioOut.NumberOfOutputChannels; ch++)
            {
                string channelName = asioOut.AsioOutputChannelName(ch);
                Console.WriteLine(channelName);
                asioChannels.Add(channelName);
            }

            Assert.IsTrue(asioChannels.Contains("ESI MAYA44 Speaker 2"));
        }


        [Test]   
        [Apartment(ApartmentState.STA)]
        public void AsioPlayer() 
        {
            //string asioDriverName = "ASIO 2.0 - ESI MAYA44";
            string asioDriverName = "ASIO4ALL v2";
            string filePath = AppDomain.CurrentDomain.BaseDirectory + "Resources\\Lana_Del_Ray-Love_48000_16bit_Stereo.wav";
            WaveStream waveStream = new WaveFileReader(filePath);
            waveStream = new WaveFormatConversionStream(new WaveFormat(96000, waveStream.WaveFormat.Channels), waveStream);

            AsioOut asioOut = new AsioOut(asioDriverName);    
            asioOut.ChannelOffset = 2;
            asioOut.Init(waveStream);
            asioOut.Play();

            Thread.Sleep(3000);

            if (asioOut != null)
                asioOut.Dispose();
        }
    }
}
