using HolidayMailer.DataBase;
using HolidayMailer.Models;
using System.Net;
using System.Net.Mail;

namespace HolidayMailer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //var dbName = "HolidayMailer.db";
            //if (File.Exists(dbName))
            //{
            //    File.Delete(dbName);
            //}
            using var dbContext = new HolidayDBContext();
            dbContext.Database.EnsureCreated();
            //dbContext.Users.Add(new User() { Name = "Luka Nadaraia", Email = "lukaNadaraia2001@gmail.com", Password = "luka1234" });
            //dbContext.SaveChanges();
            //dbContext.Events.AddRange(new List<EventModel>
            //{
            //    new EventModel(){ Date = DateTime.Now, Name = "Dagdaganoba", TargetEmail = "lnadaraia3330@sdsu.edu", TargetName = "Luka Nadaraia", UserId = 1 },
            //    new EventModel(){ Date = DateTime.Now, Name = "Erti", TargetEmail = "lnadaraia3330@sdsu.edu", TargetName = "Ager is", UserId = 1 },
            //    new EventModel(){ Date = DateTime.Now, Name = "Ori", TargetEmail = "lnadaraia3330@sdsu.edu", TargetName = "Me ara", UserId = 1 }
            //});
            //dbContext.SaveChanges();

            //var email = new MailMessage("lukanadaraia@gmail.com", "lnadaraia3330@sdsu.edu");
            //email.Subject = "Holiday";
            //email.Body = "Me gilocav axal wels";
            //SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            //smtp.UseDefaultCredentials = false;
            //NetworkCredential nc = new NetworkCredential("lukanadaraia2001@gmail.com", "#MagariParoli2001");
            //smtp.Credentials = nc;
            
            //smtp.Send(email);


            SmtpClient client = new SmtpClient("aspmx.l.google.com");

            //client.EnableSsl = true;

            MailAddress from = new MailAddress("Lukanadaraia2001@gmail.com", "Luka  Nadaraia");
            
            MailAddress to = new MailAddress("kristesiashvilinino@gmail.com");
            
            MailMessage message = new MailMessage(from, to);
            message.Body = "Gilocav axal wels simon"; 
            message.Body += Environment.NewLine;            
            message.Subject = "New Year";
            
            
            
            
            
            client.Send(message);

            Console.WriteLine();
            



        }
    }
}