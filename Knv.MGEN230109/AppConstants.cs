using System;
using System.CodeDom;

namespace Knv.MGEN230109
{
    internal class AppConstants
    {
        public const string ValueNotAvailable2 = "n/a";
        public const string InvalidFlieNameChar = "A file name can't contain any of flowing characters:";
        public const string SoftwareCustomer = "Konvolúció Bt.";
        public const string SoftwareTitle = "MGEN230109 - GENERATOR";
        public const string GenericTimestampFormat = "yyyy.MM.dd HH:mm:ss";
        public const string FileNameTimestampFormat = "yyMMdd_HHmmss";
        public const string FileFilter = "Binary File(*.bin)|*.bin";
        public const string NewLine = "\r\n";
        public const string CsvFileSeparator = ",";
        public static string SampleWaveFilePath = AppDomain.CurrentDomain.BaseDirectory + "Resources\\Lana_Del_Ray-Love_48000_16bit_Stereo.wav";

        public static int[] SampleRates => new int[] {
            32000,
            44100,
            48000,
            88200,
            96000,
            176400,
            219200
        };
    }
}
