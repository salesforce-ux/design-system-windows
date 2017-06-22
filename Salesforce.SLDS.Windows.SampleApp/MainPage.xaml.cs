using System;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Salesforce.DesignSystem;

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
                    (x) => x.Source.ToString().Contains("Brushes.ms.xaml")).ToArray()[0];

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
                    (x) => x.Source.ToString().Contains("Tokens.ms.xaml")).ToArray()[0];

           throw new NotImplementedException();
        }

        private void Icons_OnClick(object sender, RoutedEventArgs e)
        {
            DisplayList.Items.Clear();
            var iconsButton = (sender as Button).Name;
            Type targetType = null;

            switch (iconsButton)
            {
                case "IconAction":
                    targetType = typeof(IconConstants.IconAction);
                    break;
                case "IconCustom":
                    targetType = typeof(IconConstants.IconCustom);
                    break;
                case "IconStandard":
                    targetType = typeof(IconConstants.IconStandard);
                    break;
                case "IconUtility":
                    targetType = typeof(IconConstants.IconUtility);
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
                    Height = 100,
                    Orientation = Orientation.Horizontal
                };

                var code = (icon.GetValue(targetType) as string) ?? string.Empty;

                var iconBlock = IconHelpers.GetIconTextBlock_WithColor_AndBgColor_AndSize(code, targetType, (Brush) Application.Current.Resources["SLDS_COLOR_TEXT_INVERSE_BRUSH"], (Brush) Application.Current.Resources["SLDS_COLOR_BACKGROUND_TOGGLE_ACTIVE_HOVER_BRUSH"], (Double)Application.Current.Resources["SLDS_FONT_SIZE_LARGE"]);

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
                    panel.Children.Add(IconHelpers.GetIconTextBlock_WithColor_AndSize(
                        IconConstants.IconAction.ActionAddContact, colorBrush, realFontResource));
                }

                DisplayList.Items.Add(panel);
            }

        }

        private void Font_OnClick(object sender, RoutedEventArgs e)
        {
            DisplayList.Items.Clear();
            MoreIcons.Visibility = Visibility.Collapsed;

            var fontsButton = (sender as Button).Name;

            if (fontsButton.Equals("Fonts"))
            {
                MoreFonts.Visibility = Visibility.Visible;
            }
            else
            {
                var fontSizes =
                    Application.Current.Resources.MergedDictionaries.Where(
                        (x) => x.Source.ToString().Contains("SLDSTokens.ms.xaml")).ToArray()[0].Where(
                        (token) => token.Key.ToString().Contains("_FONT_SIZE_"));

                var panel = new StackPanel()
                {
                    Height = 50,
                    Orientation = Orientation.Horizontal
                };

                foreach (var fontSize in fontSizes)
                {
                    var size = (Double) Application.Current.Resources[fontSize.Key];
                    var sampleTextBlock = new TextBlock()
                    {
                        Text = SampleText,
                        FontFamily = new FontFamily($"/Assets/Fonts/SalesforceSans-{fontsButton.Replace("_","")}.ttf#Salesforce Sans {fontsButton.Replace("_"," ")}"),
                        FontSize = size
                    };

                    var descriptionBlock = new TextBlock()
                    {
                        Text = $" - ({fontSize.Key} = {size})"
                    };

                    panel.Children.Add(sampleTextBlock);
                    panel.Children.Add(descriptionBlock);
                    DisplayList.Items.Add(panel);
                }
            }
        }

        private void Sizing_OnClick(object sender, RoutedEventArgs e)
        {
            DisplayList.Items.Clear();


            DisplayList.Items.Add(IconHelpers.GetIconTextBlock_WithColor_AndBgColor_AndSize(IconConstants.IconUtility.UtilityRows, null, (Brush)Application.Current.Resources["SLDS_COLOR_TEXT_INVERSE_BRUSH"], (Brush)Application.Current.Resources["SLDS_COLOR_BACKGROUND_TOGGLE_ACTIVE_HOVER_BRUSH"], (Double)Application.Current.Resources["SLDS_FONT_SIZE_LARGE"]));
            DisplayList.Items.Add(IconHelpers.GetIconTextBlock_WithColor_AndBgColor_AndSize(IconConstants.IconUtility.UtilityRows, null, (Brush)Application.Current.Resources["SLDS_COLOR_TEXT_INVERSE_BRUSH"], (Brush)Application.Current.Resources["SLDS_COLOR_BACKGROUND_TOGGLE_ACTIVE_HOVER_BRUSH"], (Double)Application.Current.Resources["SLDS_FONT_SIZE_LARGE"]));
            DisplayList.Items.Add(IconHelpers.GetIconTextBlock_WithColor_AndBgColor_AndSize(IconConstants.IconUtility.UtilityUser, null, (Brush)Application.Current.Resources["SLDS_COLOR_TEXT_INVERSE_BRUSH"], (Brush)Application.Current.Resources["SLDS_COLOR_BACKGROUND_TOGGLE_ACTIVE_HOVER_BRUSH"], (Double)Application.Current.Resources["SLDS_FONT_SIZE_LARGE"]));
            DisplayList.Items.Add(IconHelpers.GetIconTextBlock_WithColor_AndBgColor_AndSize(IconConstants.IconUtility.UtilityBookmark, null, (Brush)Application.Current.Resources["SLDS_COLOR_TEXT_INVERSE_BRUSH"], (Brush)Application.Current.Resources["SLDS_COLOR_BACKGROUND_TOGGLE_ACTIVE_HOVER_BRUSH"], (Double)Application.Current.Resources["SLDS_FONT_SIZE_LARGE"]));
            DisplayList.Items.Add(IconHelpers.GetIconTextBlock_WithColor_AndBgColor_AndSize(IconConstants.IconUtility.UtilityCompany, null, (Brush)Application.Current.Resources["SLDS_COLOR_TEXT_INVERSE_BRUSH"], (Brush)Application.Current.Resources["SLDS_COLOR_BACKGROUND_TOGGLE_ACTIVE_HOVER_BRUSH"], (Double)Application.Current.Resources["SLDS_FONT_SIZE_LARGE"]));
            DisplayList.Items.Add(IconHelpers.GetIconTextBlock_WithColor_AndBgColor_AndSize(IconConstants.IconUtility.UtilityOpen, null, (Brush)Application.Current.Resources["SLDS_COLOR_TEXT_INVERSE_BRUSH"], (Brush)Application.Current.Resources["SLDS_COLOR_BACKGROUND_TOGGLE_ACTIVE_HOVER_BRUSH"], (Double)Application.Current.Resources["SLDS_FONT_SIZE_LARGE"]));
            DisplayList.Items.Add(IconHelpers.GetIconTextBlock_WithColor_AndBgColor_AndSize(IconConstants.IconUtility.UtilityRefresh, null, (Brush)Application.Current.Resources["SLDS_COLOR_TEXT_INVERSE_BRUSH"], (Brush)Application.Current.Resources["SLDS_COLOR_BACKGROUND_TOGGLE_ACTIVE_HOVER_BRUSH"], (Double)Application.Current.Resources["SLDS_FONT_SIZE_LARGE"]));
            DisplayList.Items.Add(IconHelpers.GetIconTextBlock_WithColor_AndBgColor_AndSize(IconConstants.IconUtility.UtilitySettings, null, (Brush)Application.Current.Resources["SLDS_COLOR_TEXT_INVERSE_BRUSH"], (Brush)Application.Current.Resources["SLDS_COLOR_BACKGROUND_TOGGLE_ACTIVE_HOVER_BRUSH"], (Double)Application.Current.Resources["SLDS_FONT_SIZE_LARGE"]));
            DisplayList.Items.Add(IconHelpers.GetIconTextBlock_WithColor_AndBgColor_AndSize(IconConstants.IconUtility.UtilityLike, null, (Brush)Application.Current.Resources["SLDS_COLOR_TEXT_INVERSE_BRUSH"], (Brush)Application.Current.Resources["SLDS_COLOR_BACKGROUND_TOGGLE_ACTIVE_HOVER_BRUSH"], (Double)Application.Current.Resources["SLDS_FONT_SIZE_MEDIUM"]));
            DisplayList.Items.Add(IconHelpers.GetIconTextBlock_WithColor_AndBgColor_AndSize(IconConstants.IconUtility.UtilityComments, null, (Brush)Application.Current.Resources["SLDS_COLOR_TEXT_INVERSE_BRUSH"], (Brush)Application.Current.Resources["SLDS_COLOR_BACKGROUND_TOGGLE_ACTIVE_HOVER_BRUSH"], (Double)Application.Current.Resources["SLDS_FONT_SIZE_MEDIUM"]));

        }
    }
}
