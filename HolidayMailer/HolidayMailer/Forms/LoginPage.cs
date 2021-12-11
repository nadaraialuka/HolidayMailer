using HolidayMailer.Auth;
using HolidayMailer.Models;
using HolidayMailer.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HolidayMailer.Forms
{
    public partial class LoginPage : Form
    {
        private readonly UserRepository _repo;
        private string UserName { get; set; }
        private string Password { get; set; }        

        public LoginPage()
        {
            _repo = new UserRepository();
            InitializeComponent();
        }

        private void splitter1_SplitterMoved(object sender, SplitterEventArgs e)
        {
   
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            UserName = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Password = textBox2.Text;
        }

         private void button2_Click(object sender, EventArgs e)
        {
            var user = _repo.GetUserByUserName(UserName);
            if (user == null)
            {
                MessageBox.Show("Client with this email does not exist", "Client Not Found Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var passCorrect = user.Password == Password;
                if (passCorrect)
                {
                    LoggedInUser.LoggedInUserId = user.Id;
                    var frm = new MainPage();
                    frm.Location = Location;
                    Hide();
                    frm.StartPosition = FormStartPosition.Manual;
                    frm.ShowDialog();
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {          
           
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {            
            
        }

        private void LoginPage_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var frm = new RegisterPage();
            frm.Location = Location;
            Hide();
            frm.StartPosition = FormStartPosition.Manual;
            frm.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}

