using App1.How_Close;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HowClose : Page
    {
        public HowClose()
        {
            this.InitializeComponent();
        }

        private void Button_Home_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Textblock_thprime.Text = (Howclose.closestPrime(TextBox_userinput.Text)).ToString();
            }
            catch
            {
                Textblock_thprime.Text = "Sadly the number you put was too big. So figure it out yourself";
            }
        }

        private void TextBox_userinput_GotFocus(object sender, RoutedEventArgs e)
        {
            Textblock_thprime.Text = "";
            TextBox_userinput.Text = "";
            
        }
    }
    
}
