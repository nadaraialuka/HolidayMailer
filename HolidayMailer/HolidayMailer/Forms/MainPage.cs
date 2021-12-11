using HolidayMailer.Auth;
using HolidayMailer.Models;
using HolidayMailer.Repository;
using System.Net.Mail;

namespace HolidayMailer.Forms
{
    public partial class MainPage : Form
    {
        private string EventName { get; set; }
        private string TargetEmail { get; set; }
        private string TargetName { get; set; }
        private DateTime Date { get; set; }
        private EventModel currentEvent;

        private FlowLayoutPanel flowLayoutPanel; // define this in the designer

        private readonly EventRepository _repo;
        private readonly UserRepository _userRepo;

        public MainPage()
        {
            _userRepo = new UserRepository();
            _repo = new EventRepository();            
            InitializeComponent();
            flowLayoutPanel = flowLayoutPanel1;
            DisplayList();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void mainPage_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            flowLayoutPanel.VerticalScroll.Visible = true;
        }
        private void DisplayList() 
        {           
            var items = _repo.GetEventsByUserId(LoggedInUser.LoggedInUserId);
            
            foreach (var ev in items)
            {
                currentEvent = ev;
                FlowLayoutPanel flowLayoutPanel = flowLayoutPanel1;
                GroupBox gb = new GroupBox();
                gb.Height = 300;
                gb.Width = 300;
                gb.Text = ev.Name;

                Label label = new Label();
                label.Text = ev.Name;

                Label label1 = new Label();
                label1.Text = ev.TargetEmail;
                label1.Location = new Point(1, 40);

                Label label2 = new Label();
                label2.Location = new Point(1, 50);
                label2.Text = ev.TargetName;

                Label label3 = new Label();
                label3.Location = new Point(1, 60);
                label3.Text = ev.Date.ToString("MM:dd");

                gb.Controls.Add(label);
                gb.Controls.Add(label1);
                gb.Controls.Add(label2);
                gb.Controls.Add(label3);

                Button dynamicButton = new Button();

                dynamicButton.Height = 30;

                dynamicButton.Width = 70;

                dynamicButton.BackColor = Color.Red;

                dynamicButton.Location = new Point(20, 80);

                dynamicButton.Text = "Send";

                dynamicButton.Name = "DynamicButton";

                dynamicButton.Font = new Font("Georgia", 10);                
                
                dynamicButton.Click += new EventHandler(OnButtonClick);
                
                Controls.Add(dynamicButton);
                gb.Controls.Add(dynamicButton);

                flowLayoutPanel.Controls.Add(gb);
            }
        }

        private void OnButtonClick(object sender, EventArgs e)
        {
            
            var user = _userRepo.GetUserById(LoggedInUser.LoggedInUserId);
            SmtpClient client = new SmtpClient("aspmx.l.google.com");

            client.EnableSsl = true;

            MailAddress from = new MailAddress($"{user.Email}", $"{user.Name}");

            MailAddress to = new MailAddress(currentEvent.TargetEmail);

            MailMessage message = new MailMessage(from, to);
            message.Body = $"{currentEvent.TargetName} gilocav {currentEvent.Name}obas";
            message.Body += Environment.NewLine;
            message.Subject = $"{currentEvent.Name}";
            client.Send(message);
            
        }
       
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            EventName=textBox1.Text;           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            TargetEmail=textBox2.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            TargetName=textBox3.Text;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Date = dateTimePicker1.Value;
            var ev = new EventModel()
            {
                Date = this.Date,
                Name = EventName,
                UserId = LoggedInUser.LoggedInUserId,
                TargetEmail= this.TargetEmail,
                TargetName = this.TargetName,
            };

            if (_repo.AddEvent(ev))
            {
                FlowLayoutPanel flowLayoutPanel = flowLayoutPanel1;
                GroupBox gb = new GroupBox();
                gb.Text = ev.Name;

                Label label = new Label();
                label.Text = ev.Name;
                gb.Controls.Add(label);

                Button btn = new Button();
                btn.Text = "Send";
                btn.Height = 60;
                btn.Width = 60;
                btn.Location = new Point(30, 40);
                flowLayoutPanel.Controls.Add(btn);
                gb.Controls.Add(btn);

                flowLayoutPanel.Controls.Add(gb);
            }
            else
            {
                MessageBox.Show("Could Not Add an Event", "Event Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
