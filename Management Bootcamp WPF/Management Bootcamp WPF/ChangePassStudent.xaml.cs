﻿using Management_Bootcamp_WPF.Properties;
using Microservice.BussinessLogic.Services;
using Microservice.BussinessLogic.Services.Master;
using Microservice.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Management_Bootcamp_WPF
{
    /// <summary>
    /// Interaction logic for ChangePassStudent.xaml
    /// </summary>
    public partial class ChangePassStudent : Window
    {
        IStudentService _studentService = new StudentService();
        StudentParam studentParam = new StudentParam();
        public ChangePassStudent()
        {
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(passwordBoxOldPassword.Password) == true)
            {
                MessageBox.Show("Please insert old password!");
            }
            else if (string.IsNullOrWhiteSpace(passwordBoxOldPassword.Password) == true)
            {
                MessageBox.Show("Don't insert white space");
            }
            else
            {
                if (string.IsNullOrEmpty(passwordBoxNewPassword1.Password) == true)
                {
                    MessageBox.Show("Please insert new password!");
                }
                else if (string.IsNullOrWhiteSpace(passwordBoxNewPassword1.Password) == true)
                {
                    MessageBox.Show("Don't insert white space");
                }
                else
                {
                    if (string.IsNullOrEmpty(passwordBoxNewPassword2.Password) == true)
                    {
                        MessageBox.Show("Please insert confirm new password!");
                    }
                    else if (string.IsNullOrWhiteSpace(passwordBoxNewPassword2.Password) == true)
                    {
                        MessageBox.Show("Don't insert white space");
                    }
                    else
                    {
                        if (Settings.Default.password == passwordBoxOldPassword.Password)
                        {
                            if (passwordBoxNewPassword1.Password == passwordBoxNewPassword2.Password)
                            {
                                studentParam.Password = passwordBoxNewPassword2.Password;
                                _studentService.UpdateP(Settings.Default.Id, studentParam);
                                MessageBox.Show("Congratulations password has been changed");
                                new MainWindow().Show();
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Confirm new password is not same");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Old Password Wrong!");
                        }
                    }
                }
            }            
        }
    }
}
