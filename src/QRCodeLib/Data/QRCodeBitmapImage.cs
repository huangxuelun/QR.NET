using System.Drawing;

namespace ThoughtWorks.QRCode.Codec.Data
{
    public class QRCodeBitmapImage : QRCodeImage
    {
         Bitmap image;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="image">Bitmap image/param>
        public QRCodeBitmapImage(Bitmap image)
        {
            this.image = image;
        }

        public virtual int Width
        {
            get
            {
                return image.Width;
            }

        }
        public virtual int Height
        {
            get
            {
                return image.Height;
            }

        }
     

        public virtual int getPixel(int x, int y)
        {
            return image.GetPixel(x, y).ToArgb();
        }
    }
}
