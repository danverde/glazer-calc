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

        private void WidthInput_CharacterReceived(UIElement sender, CharacterReceivedRoutedEventArgs args)
        {
            if (Char.IsDigit(args.Character) == false)
            {

            }
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            /* Validate Inputs */
            bool validInputs = true;

            try
            {
                double width = Double.Parse(WidthInput.Text);
                double height = Double.Parse(HeightInput.Text);

                double quantity = QuantitySlider.Value;

                if (validInputs == true)
                {
                    /* Show labels */
                    WoodLabel.Visibility = (Visibility)0;
                    GlassLabel.Visibility = (Visibility)0;
                    OrderDateLabel.Visibility = (Visibility)0;

                    /* Calculate & Display results */
                    WoodOutput.Text = (2 * (width + height) * 3.25).ToString();
                    GlassOutput.Text = (2 * (width * height)).ToString();
                    OrderDateOutput.Text = DateTime.Now.ToString();
                }

            } catch (Exception Error)
            {
                Message.Text = Error.Message;
            }            
        }

        private bool ValidateInput(String input)
        {
            return false;
        }
    }
}
