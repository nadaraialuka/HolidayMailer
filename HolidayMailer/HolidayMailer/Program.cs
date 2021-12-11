using HolidayMailer.DataBase;
using HolidayMailer.Forms;

namespace HolidayMailer
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //var ss = new HolidayDBContext();
            //var tt = ss.Events.ToList();
            //ss.Events.RemoveRange(tt);
            //ss.SaveChanges();
            //var rr = ss.Events.ToList();
            ApplicationConfiguration.Initialize();
            Application.Run(new LoginPage());
        }
    }
}