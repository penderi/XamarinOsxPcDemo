using System;
using System.IO;
using System.Threading;
using NUnit.Framework;

namespace CoreCode
{
    [TestFixture]
    public class TestClass
    {
        private bool fired;

        [Test]
        public void ShouldNoticeFileChange()
        {
            DateTime start = DateTime.Now;
   
            var fsw = new FileSystemWatcher(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            fsw.Changed += FswOnChanged;
            fsw.EnableRaisingEvents = true;

            while (!fired && (DateTime.Now - start).Seconds < 5)
            {
                Thread.Sleep(500);                
            }

            Assert.That(fired, Is.True);
        }

        private void FswOnChanged(object sender, FileSystemEventArgs fileSystemEventArgs)
        {
            fired = true;
        }
    }

    //new class lib 
    //added to location
    //nuget nunit

}
