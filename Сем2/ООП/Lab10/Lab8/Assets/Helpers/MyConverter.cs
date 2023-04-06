using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Lab8.Assets.Helpers
{
    public static class MyConverter
    {
        private static readonly object locker = new object();
        public static BitmapImage ToImageSource(byte[] buffer)
        {
            lock (locker)
            {
                BitmapImage bitmapImage = new BitmapImage();
                using (MemoryStream ms = new MemoryStream(buffer))
                {
                    bitmapImage.BeginInit();
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.StreamSource = ms;
                    bitmapImage.EndInit();

                    return bitmapImage;
                }
            }
        }

        public static byte[] ImageToBytes(BitmapImage bitmapImage)
        {
            lock (locker)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    PngBitmapEncoder encoder = new PngBitmapEncoder();
                    encoder.Frames.Add(BitmapFrame.Create(bitmapImage));
                    encoder.Save(ms);
                    return ms.ToArray();
                }
            }
        }
    }
}
