﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using zVirtualScenes;

namespace zVirtualScenesGUI
{
    /// <summary>
    /// Interaction logic for FatalErrorWindow.xaml
    /// </summary>
    public partial class FatalErrorWindow : Window
    {
        private string Error = string.Empty;

        public FatalErrorWindow(string Error)
        {
            this.Error = Error;
            InitializeComponent();
        }

        private void FatalErrorWindow_Loaded_1(object sender, RoutedEventArgs e)
        {
            Title = string.Format("{0} has crashed",Utils.ApplicationNameAndVersion);
            TitleTxtBl.Text = string.Format("Woops! {0} has encountered a problem and needs to close. We are sorry for the inconvenience.", Utils.ApplicationName);
            ErrorTxtBx.Text = Error;
        }

        private void SendErrorBtn_Click(object sender, RoutedEventArgs e)
        {
            string targetURL = string.Format(@"mailto:{0}?Subject={1}&Body={2}", 
                HttpUtility.UrlEncode("zvsErrors@aarondrabeck.com"), 
                HttpUtility.UrlEncode(Utils.ApplicationNameAndVersion + " HttpUtility.UrlEncode(Fatal Exception Error Report"), 
                HttpUtility.UrlEncode(Error));
            
            try
            {
                System.Diagnostics.Process.Start(targetURL);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error opening e-mail client");
            }
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        
    }
}