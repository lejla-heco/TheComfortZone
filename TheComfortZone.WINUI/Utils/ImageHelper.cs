using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheComfortZone.WINUI.Utils
{
    internal class ImageHelper
    {
        public static byte[] FromImageToByte(Image image)
        {
            var ms = new MemoryStream();
            image.Save(ms, ImageFormat.Jpeg);
            return ms.ToArray();
        }

        public static Image FromByteToImage(byte[] image)
        {
            var ms = new MemoryStream(image);
            return Image.FromStream(ms);
        }

        public static bool ValidateImageUpload(string path)
        {
            try
            {
                if (!File.Exists(path))
                {
                    MessageBox.Show("File not found.\nCheck the file name and try again.", "Open", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                string ext = Path.GetExtension(path);
                if (ext != ".jpg" && ext != ".png") {
                    MessageBox.Show("Incorrect file format! Try again!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

            }
            catch
            {
                return false;
            }

            return true;
        }

        public static bool ValidateImage(PictureBox pictureBox, ErrorProvider errorProvider)
        {
            if (pictureBox.Image == null)
            {
                errorProvider.SetError(pictureBox, "Upload image!");
                return false;
            }
            errorProvider.Clear();
            return true;
        }
    }
}
