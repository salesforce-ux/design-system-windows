/// Copyright (c) 2015-present, salesforce.com, inc. All rights reserved 
/// Licensed under BSD 3-Clause - see LICENSE.txt or git.io/sfdc-license

using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

namespace Salesforce.DesignSystem
{
    public static class IconHelpers
    {
        private static readonly FontFamily Font = (FontFamily)Application.Current.Resources["SalesforceDesignSystemIcons"];

        public static FrameworkElement GetIconTextBlock_WithSize(string icon, Double size)
        {
            var iconBlock = new TextBlock()
            {
                Text = icon,
                FontFamily = Font,
            };

            return iconBlock;
        }

        public static FrameworkElement GetIconTextBlock_WithColor_AndSize(string icon, Brush color, Double size)
        {
            var iconBlock = new TextBlock()
            {
                Text = icon,
                FontFamily = Font,
                Foreground = color,
                FontSize = size
            };

            return iconBlock;
        }

        public static FrameworkElement GetIconTextBlock_WithColor_AndBgColor_AndSize(string icon, Type iconType, Brush color, Brush bgcolor, Double size)
        {

            var grid = new Grid()
            {
                Height = size,
                Width = size,
            };

            var iconBlock = new TextBlock()
            {
                Text = icon,
                FontFamily = Font,
                Foreground = color,
                FontSize = size,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };

            if (iconType == typeof(IconConstants.IconAction))
            {
                var ellipse = new Ellipse()
                {
                    Height = size * 0.8,
                    Width = size * 0.8,
                    Fill = bgcolor,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                };
                grid.Children.Add(ellipse);
            }
            else if (iconType == typeof(IconConstants.IconUtility))
            {
                iconBlock.Foreground = bgcolor;
            }
            else
            {
                var border = new Border()
                {
                    Height = size * 0.9,
                    Width = size * 0.9,
                    Background = bgcolor,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    CornerRadius = new CornerRadius(10)
                };
                grid.Children.Add(border);
            }

            grid.Children.Add(iconBlock);

            return grid;
        }

    }
}
