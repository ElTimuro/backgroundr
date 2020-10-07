using System;
using System.IO;

namespace backgroundr
{
    class Program
    {
        private static int _updateIntervall = 60000;
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    checkBackground();
                    System.Threading.Thread.Sleep(_updateIntervall);
                }
                catch (Exception)
                {
                }
            }
        }

        private static void checkBackground()
        {
            var now = DateTime.Now;
            var backgroundImage = "";

            if (IsMorning())
            {
                backgroundImage = "2.jpg";
            }

            if (IsDay())
            {
                backgroundImage = "3.jpg";
            }

            if (IsEvening())
            {
                backgroundImage = "4.jpg";
            }

            if (IsNight())
            {
                backgroundImage = "1.jpg";
            }

            setBackground(backgroundImage);
        }

        private static bool IsNight()
        {
            return DateTime.Now.Hour >= 21 || DateTime.Now.Hour < 6;
        }

        private static bool IsMorning()
        {
            return DateTime.Now.Hour >= 6 && DateTime.Now.Hour < 11;
        }

        private static bool IsDay()
        {
            return DateTime.Now.Hour >= 11 && DateTime.Now.Hour < 18;
        }

        private static bool IsEvening()
        {
            return DateTime.Now.Hour >= 18;
        }

        private static void setBackground(string backgroundImage)
        {
            Wallpaper.Set(new Uri(Directory.GetCurrentDirectory() + "\\" + backgroundImage), Wallpaper.Style.Stretched);
        }
    }
}
