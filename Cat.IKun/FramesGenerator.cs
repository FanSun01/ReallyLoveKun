using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Cat.IKun
{
    internal class FramesGenerator
    {
        public IEnumerable<Bitmap> GetFrames()
        {
            using var archive = new ZipArchive(new MemoryStream(Properties.Resources.frame), ZipArchiveMode.Read);
            int frameNumber = 1;
            while (true)
            {
                var frame = archive.GetEntry($"frame{frameNumber:0000}.jpg");
                ++frameNumber;
                if (frame is not null)
                {
                    using var stream = frame.Open();
                    yield return new Bitmap(stream);
                }
                else
                    break;
            }
        }
    }
}