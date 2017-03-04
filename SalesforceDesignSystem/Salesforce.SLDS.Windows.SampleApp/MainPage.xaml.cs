using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;
using Salesforce.SfdcCore.Helpers;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Salesforce.SLDS.Windows.SampleApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private const string SampleText = "The quick fox jumped over the lazy dog";

        public MainPage()
        {
            this.InitializeComponent();
        }


        private void Brushes_OnClick(object sender, RoutedEventArgs e)
        {
            DisplayList.Items.Clear();
            MoreIcons.Visibility = Visibility.Collapsed;

            var brushes =
                Application.Current.Resources.MergedDictionaries.Where(
                    (x) => x.Source.ToString().Contains("SLDSBrushes.ms.xaml")).ToArray()[0];

            foreach (var brush in brushes)
            {
                var grid = new Grid()
                {
                    Height = 100,
                    Width = 500,
                    Background = (Brush)Application.Current.Resources[brush.Key],
                };
                grid.Children.Add(new TextBlock() { Text = brush.Key.ToString(), Width = 500 });

                DisplayList.Items.Add(grid);
            }
        }

        private void Borders_OnClick(object sender, RoutedEventArgs e)
        {
            DisplayList.Items.Clear();
            MoreIcons.Visibility = Visibility.Collapsed;

            var tokenDictionary =
                 Application.Current.Resources.MergedDictionaries.Where(
                    (x) => x.Source.ToString().Contains("SLDSTokens.ms.xaml")).ToArray()[0];

           throw new NotImplementedException();
        }

        private void Fonts_OnClick(object sender, RoutedEventArgs e)
        {
            DisplayList.Items.Clear();
            MoreIcons.Visibility = Visibility.Collapsed;

            throw new NotImplementedException();
        }

        private void Icons_OnClick(object sender, RoutedEventArgs e)
        {
            DisplayList.Items.Clear();
            var iconsButton = (sender as Button).Name;
            IEnumerable<FieldInfo> icons = null;
            Type targetType = null;

            switch (iconsButton)
            {
                case "SalesforceDesignSystemIconsAction":
                    targetType = typeof(SLDSIconConstants.SLDSIconAction);
                    break;
                case "SalesforceDesignSystemIconsCustom":
                    targetType = typeof(SLDSIconConstants.SLDSIconCustom);
                    break;
                case "SalesforceDesignSystemIconsStandard":
                    targetType = typeof(SLDSIconConstants.SLDSIconStandard);
                    break;
                case "SalesforceDesignSystemIconsUtility":
                    targetType = typeof(SLDSIconConstants.SLDSIconUtility);
                    break;
                case "Icons":
                default:
                    MoreIcons.Visibility = Visibility.Visible;
                    return;
            }

            foreach (var icon in targetType.GetTypeInfo().DeclaredFields)
            {
                var grid = new Grid()
                {
                    Height = 80,
                };

                var text = (icon.GetValue(targetType) as string) ?? string.Empty;
                var fontFamily = (FontFamily) Application.Current.Resources[iconsButton];

                var textblock = new TextBlock()
                {
                    Text = text,
                    FontFamily = fontFamily
                };

                grid.Children.Add(textblock);

                DisplayList.Items.Add(grid);
            }
        }
    }
}
