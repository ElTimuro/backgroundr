using System;
using System.IO;

namespace backgroundr
{
    class Program
    {
        private static int _updateIntervall = 60000;
        private static string imageFolder = "";
        static void Main(string[] args)
        {
            while (true)
            {
                checkBackground();
                System.Threading.Thread.Sleep(_updateIntervall);
            }
        }

        private static void checkBackground()
        {
            var now = DateTime.Now;
            var backgroundImage = "";

            if (IsNight())
            {
                backgroundImage = "1.jpg";
            }

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

            setBackground(backgroundImage);
        }

        private static bool IsNight()
        {
            return DateTime.Now.Hour < 6;
        }

        private static bool IsMorning()
        {
            return DateTime.Now.Hour > 6 && DateTime.Now.Hour < 9;
        }

        private static bool IsDay()
        {
            return DateTime.Now.Hour > 9 && DateTime.Now.Hour < 18;
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
