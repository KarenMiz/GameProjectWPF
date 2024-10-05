﻿using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace GameProjectWPF
{
    public class ReadOnlyToSaveVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool isReadOnly)
            {
                return isReadOnly ? Visibility.Collapsed : Visibility.Visible;
            }
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
