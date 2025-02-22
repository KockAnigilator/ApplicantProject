using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdmissionCommitteeBackend;

namespace ApplicantForm
{
    public partial class LoginForm : Form
    {
        private AdmissionCommitteeService _service;

        public LoginForm()
        {
            InitializeComponent();
            _service = new AdmissionCommitteeService();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (_service.LoginUser(username, password))
            {
                MessageBox.Show("Авторизация успешна!");
                this.Hide();
                var mainForm = new MainForm();
                mainForm.Show();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль.");
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (_service.RegisterUser(username, password))
            {
                MessageBox.Show("Регистрация успешна!");
            }
            else
            {
                MessageBox.Show("Пользователь с таким именем уже существует.");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (_service.LoginUser(username, password))
            {
                MessageBox.Show("Авторизация успешна!");
                this.Hide();
                var mainForm = new MainForm();
                mainForm.Show();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль.");
            }
        }

        private void btnRegister_Click_1(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (_service.RegisterUser(username, password))
            {
                MessageBox.Show("Регистрация успешна!");
            }
            else
            {
                MessageBox.Show("Пользователь с таким именем уже существует.");
            }
        }
    }
}
