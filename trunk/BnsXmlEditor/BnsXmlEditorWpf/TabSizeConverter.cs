using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;

namespace BnsXmlEditorWpf.Converters
{
	public class TabSizeConverter : IMultiValueConverter
	{
		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			TabControl tabControl = values[0] as TabControl;
			double width = tabControl.ActualWidth / tabControl.Items.Count;
			return (width <= 1) ? 0 : (width - 3);
		}

		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}