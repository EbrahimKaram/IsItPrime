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
using App1.Whats_Next;
using App1.Is_It_Prime;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class WhatsNext : Page
    {
        //public variable
        int random;
        int[] A = App1.Whats_Next.Whatsnext.ListofPrimes();
        public WhatsNext()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            int k = Whatsnext.difficulty(ComboBox_Difficulty.SelectedIndex);
            random = Whatsnext.Randomnumber(k);
            TextBlock_randomPrime.Text = A[random].ToString();

        }

        private void Button_StartOver_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int input=Convert.ToInt32(TextBox_usersInput.Text);
                if(input==A[random+1])
                {
                    TextBlock_WhatsnextAnswer.Text="WOW you got it right. You should propbably refresh the difficulty";
                }
                else 
                    TextBlock_WhatsnextAnswer.Text="Nice try, but the answer is "+A[random+1];

                if (!IsItprime.Primebility(TextBox_usersInput.Text))
                {
                    List<int> Divisbles = IsItprime.divisibleby(TextBox_usersInput.Text);
                    TextBlock_Divisibleby.Text = TextBox_usersInput.Text+ " is actually divisible by";
                    foreach (int number in Divisbles)
                    {
                        TextBlock_Divisibleby.Text += " " + number;

                    }
                    TextBlock_Divisibleby.Text += ".";
                }
            }

            catch
            {
                TextBlock_WhatsnextAnswer.Text = "I think Your Number was just a nudge too Big or you didn't put anything, but what do I know I'm just a phone";
            }
        }

        private void ComboBox_Difficulty_GotFocus(object sender, RoutedEventArgs e)
        {
            //Could use a function for this
            int k = Whatsnext.difficulty(ComboBox_Difficulty.SelectedIndex);
            random = Whatsnext.Randomnumber(k);
            TextBlock_randomPrime.Text = A[random].ToString();
            TextBox_usersInput.Text = String.Empty;
            TextBlock_WhatsnextAnswer.Text = string.Empty;

        }

        private void refresh_Click(object sender, RoutedEventArgs e)
        {
            int k = Whatsnext.difficulty(ComboBox_Difficulty.SelectedIndex);
            random = Whatsnext.Randomnumber(k);
            TextBlock_randomPrime.Text = A[random].ToString();
            TextBlock_WhatsnextAnswer.Text = "";
            TextBlock_Divisibleby.Text = "";
            TextBox_usersInput.Text = "";
        }
    }
}
