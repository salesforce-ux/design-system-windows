using System;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Salesforce.SfdcCore.Helpers;

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
            Type targetType = null;

            switch (iconsButton)
            {
                case "SLDSIconAction":
                    targetType = typeof(SLDSIconConstants.SLDSIconAction);
                    break;
                case "SLDSIconCustom":
                    targetType = typeof(SLDSIconConstants.SLDSIconCustom);
                    break;
                case "SLDSIconStandard":
                    targetType = typeof(SLDSIconConstants.SLDSIconStandard);
                    break;
                case "SLDSIconUtility":
                    targetType = typeof(SLDSIconConstants.SLDSIconUtility);
                    break;
                case "Icons":
                default:
                    MoreIcons.Visibility = Visibility.Visible;
                    return;
            }

            foreach (var icon in targetType.GetTypeInfo().DeclaredFields)
            {
                var panel = new StackPanel()
                {
                    Height = 50,
                    Orientation = Orientation.Horizontal
                };

                var code = (icon.GetValue(targetType) as string) ?? string.Empty;
                var iconBlock = new TextBlock()
                {
                    Text = code,
                    FontFamily = new FontFamily("/Assets/Fonts/SalesforceDesignSystemIcons.ttf#SalesforceDesignSystemIcons"),
                    FontSize = 34
                };

                var descriptionBlock = new TextBlock()
                {
                    Text = $"   {icon.Name} = ({Regex.Replace(code, @"[^\x00-\x7F]", c => string.Format(@"\u{0:x4}", (int)c.Value[0]))})"
                };

                panel.Children.Add(iconBlock);
                panel.Children.Add(descriptionBlock);

                DisplayList.Items.Add(panel);
            }
        }

        private void Icons_Color_OnClick(object sender, RoutedEventArgs e)
        {
            DisplayList.Items.Clear();

            var fontSizes =
                Application.Current.Resources.MergedDictionaries.Where(
                   (x) => x.Source.ToString().Contains("SLDSTokens.ms.xaml")).ToArray()[0].Where(
                    (token) => token.Key.ToString().Contains("_FONT_SIZE_"));

            var textColorBrushes =
                Application.Current.Resources.MergedDictionaries.Where(
                    (x) => x.Source.ToString().Contains("SLDSBrushes.ms.xaml")).ToArray()[0].Where(
                    (token) => token.Key.ToString().Contains("_TEXT_"));

            foreach (var textColorBrush  in textColorBrushes)
            {
                var panel = new StackPanel()
                {
                    Height = 50,
                    Orientation = Orientation.Horizontal
                };

                var colorBrush = (Brush)Application.Current.Resources[textColorBrush.Key];

                foreach (var fontSize in fontSizes)
                {
                    var realFontResource = (Double)Application.Current.Resources[fontSize.Key];
                    panel.Children.Add(SLDSIconHelpers.GetIconTextBlock_WithColor_AndSize(
                        SLDSIconConstants.SLDSIconAction.ActionAddContact, colorBrush, realFontResource));
                }

                DisplayList.Items.Add(panel);
            }

        }
    }
}
