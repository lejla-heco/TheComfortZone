using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheComfortZone.WINUI.Properties;

namespace TheComfortZone.WINUI.Utils
{
    public static class PasswordChar
    {
        static Bitmap openEye = Resources.open_eye;
        static Bitmap closedEye = Resources.closed_eye;

        public static void ShowHidePassword(TextBox passwordField, PictureBox pictureBox)
        {
            if (passwordField.PasswordChar == '●')
            {
                passwordField.PasswordChar = new char();
                pictureBox.Image = openEye;
            }
            else
            {
                passwordField.PasswordChar = '●';
                pictureBox.Image = closedEye;
            }
        }
    }
}
