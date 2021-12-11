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
    public partial class RegisterPage : Form
    {
        private readonly UserRepository _repo;
        private string Email { get; set; }
        private string Password { get; set; }
        private string FullName { get; set; }
        public RegisterPage()
        {
            _repo = new UserRepository();
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var lp = new LoginPage();
            lp.Location = Location;
            Hide();
            lp.StartPosition = FormStartPosition.Manual;
            lp.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var result = _repo.RegisterUser(Email.ToLower(), FullName, Password);
            if (!result)
            {
                MessageBox.Show("User with this email already exists!", "Register Error",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            var frm = new LoginPage();
            frm.Location = Location;
            Hide();
            frm.StartPosition = FormStartPosition.Manual;
            frm.ShowDialog();
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Email = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            FullName = textBox2.Text; 
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            Password = textBox3.Text;
        }

        private void RegisterPage_Load(object sender, EventArgs e)
        {

        }
    }
}
