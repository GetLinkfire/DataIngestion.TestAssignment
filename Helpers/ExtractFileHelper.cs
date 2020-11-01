using ICSharpCode.SharpZipLib.BZip2;
using System;
using System.IO;
using System.Threading.Tasks;

namespace DataIngestion.TestAssignment.Helpers
{
    public class ExtractFileHelper
    {

        public Task Extract(byte[] message)
        {
            using var stream = new MemoryStream(message);
            using var inStream = new BZip2InputStream(stream);
            using var outStream = File.Create("fileCollection");

            var buffer = new byte[65536];
            int bytesRead;

            Console.WriteLine("Extracting...");

            while ((bytesRead = inStream.Read(buffer, 0, 65536)) != 0)
            {
                outStream.Write(buffer, 0, bytesRead);
            }

            return Task.FromResult(0);
        }
    }
}
