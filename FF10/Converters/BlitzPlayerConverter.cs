using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace FF10.Converters
{
	class BlitzPlayerConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			for (int i = 0; i < Info.Instance().Blitz_Player.Count; i++)
			{
				if (Info.Instance().Blitz_Player[i].Value == (uint)value) return i;
			}

			return -1;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return Info.Instance().Blitz_Player[(int)value].Value;
		}
	}
}
