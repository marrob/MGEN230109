

namespace Knv.MGEN230109.IO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using NUnit.Framework;
    using Common;

    [TestFixture]
    internal class IoUnitTest
    {



        [SetUp]
        public void TestSetup()
        {

        }

        [Test]
        public void DeviceName()
        {

        }


        [TearDown]
        public void TestCleanUp()
        {  
            

            Log.Instance.FilePath = "D:\\tog.txt";


            Tools.RunNotepadOrNpp(Log.Instance.FilePath);  
        }

    }
}
