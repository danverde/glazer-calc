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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Clazer_Calc
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            /* Clear any previous error message */
            Message.Text = "";

            try
            {
                /* Ensure inputs are not empty */
                if (WidthInput.Text == "")
                {
                    Message.Text = "Width must not be empty";
                    return;
                }
                else if (HeightInput.Text == "")
                {
                    Message.Text = "Height must not be empty";
                    return;
                }
                else if (TintColorInput.SelectedIndex == -1)
                {
                    Message.Text = "Must select a Tint Color";
                    return;
                }

                /* Parse inputs */
                double width = Double.Parse(WidthInput.Text);
                double height = Double.Parse(HeightInput.Text);

                double quantity = QuantitySlider.Value;
               
                /* Show labels */
                WoodLabel.Visibility = (Visibility)0;
                GlassLabel.Visibility = (Visibility)0;
                OrderDateLabel.Visibility = (Visibility)0;

                /* Calculate & Display results */
                WoodOutput.Text = (2 * (width + height) * 3.25).ToString();
                GlassOutput.Text = (2 * (width * height)).ToString();
                OrderDateOutput.Text = DateTime.Now.ToString();

            } catch (Exception Error)
            {
                Message.Text = $"Error: {Error.Message}";
            }            
        }

        /* stops the user from entering a non-numeric character */
        private void ValidateKey(KeyRoutedEventArgs e)
        {
            List<Windows.System.VirtualKey> numbers = new List<Windows.System.VirtualKey>()
                {
                (Windows.System.VirtualKey)9,
                (Windows.System.VirtualKey)48,
                (Windows.System.VirtualKey)49,
                (Windows.System.VirtualKey)50,
                (Windows.System.VirtualKey)51,
                (Windows.System.VirtualKey)52,
                (Windows.System.VirtualKey)53,
                (Windows.System.VirtualKey)54,
                (Windows.System.VirtualKey)55,
                (Windows.System.VirtualKey)56,
                (Windows.System.VirtualKey)57,
                (Windows.System.VirtualKey)96,
                (Windows.System.VirtualKey)97,
                (Windows.System.VirtualKey)98,
                (Windows.System.VirtualKey)99,
                (Windows.System.VirtualKey)100,
                (Windows.System.VirtualKey)101,
                (Windows.System.VirtualKey)102,
                (Windows.System.VirtualKey)103,
                (Windows.System.VirtualKey)104,
                (Windows.System.VirtualKey)105,
                (Windows.System.VirtualKey)110
                };

            if (numbers.Contains(e.Key) == false)
            {
                e.Handled = true;
            }
        }

        private void WidthInput_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            ValidateKey(e);
        }

        private void HeightInput_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            ValidateKey(e);
        }
    }
}
