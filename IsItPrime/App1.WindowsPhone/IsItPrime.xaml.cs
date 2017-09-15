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
using App1.Is_It_Prime;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class IsItPrime : Page
    {
        public IsItPrime()
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
        }

        private void Button_StartOver_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
        private void TextBox_primeInput_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox_primeInput.Text = string.Empty;
            TextBlock_AnswerPrime.Text = string.Empty;
            TextBlock_divisibleBy.Text = string.Empty;
            Yes.IsChecked = false;
            No.IsChecked = false;


        }

        private void button_Submit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool prime = IsItprime.Primebility(TextBox_primeInput.Text);
                if (prime)
                    TextBlock_AnswerPrime.Text = "It is Prime";
                else
                    TextBlock_AnswerPrime.Text = "It is Composite.";
                if ((bool.Parse(Yes.IsChecked.ToString())))
                {
                    if(prime)
                     TextBlock_AnswerPrime.Text+=" Lucky Guess";

                    else
                    {
                        TextBlock_AnswerPrime.Text += " Your Math teacher has denied your existense";
                    }
                }
                else if (bool.Parse(No.IsChecked.ToString()))
                {
                    if(prime)
                     TextBlock_AnswerPrime.Text+=" Don't worry it wasn't that easy";

                    else
                    {
                        TextBlock_AnswerPrime.Text += " You got it right. You should be a space monkey";
                    }
                }
                
              if(!prime)
              {
                  TextBlock_divisibleBy.Text = TextBox_primeInput.Text + " is actually divisible by";
                  List<int>A=IsItprime.divisibleby(TextBox_primeInput.Text);
                 
                  foreach( int factor in A)
                  {
                      TextBlock_divisibleBy.Text += " " + factor;
                      
                  }
                  TextBlock_divisibleBy.Text += ".";
              }

            }
          catch
            {
                TextBlock_AnswerPrime.Text = "This number broke your phone. Nice Going there";
            }
            
            
        }

        private void TextBox_primeInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBlock_AnswerPrime.Text = "";
            TextBlock_divisibleBy.Text = string.Empty;
            Yes.IsChecked = false;
            No.IsChecked = false;

        }
    }
}
