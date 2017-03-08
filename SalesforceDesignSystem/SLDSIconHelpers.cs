/// Copyright (c) 2015-present, salesforce.com, inc. All rights reserved 
/// Licensed under BSD 3-Clause - see LICENSE.txt or git.io/sfdc-license

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Salesforce.SfdcCore.Helpers;

namespace Salesforce.SfdcCore.Helpers
{
    public static class SLDSIconHelpers
    {
        private static FontFamily Font = new FontFamily("/Assets/Fonts/SalesforceDesignSystemIcons.ttf#SalesforceDesignSystemIcons");

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

        public static FrameworkElement GetIconTextBlock_WithColor_AndBgColor_AndSize(string icon, Brush color, Brush bgcolor, Double size)
        {
            var iconBlock = new TextBlock()
            {
                Text = icon,
                FontFamily = Font,
                Foreground = color,
                FontSize = size
            };

            var grid = new Grid()
            {
                Height = iconBlock.Height,
                Width = iconBlock.Width,
                Background = bgcolor
            };

            grid.Children.Add(iconBlock);

            return grid;
        }

    }
}
