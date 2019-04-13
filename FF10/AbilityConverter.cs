using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace FF10
{
	class AbilityConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var abilities = Info.Instance().Abilities;
			for (int i = 0; i < abilities.Count; i++)
			{
				if (abilities[i].Value == (uint)value) return i;
			}

			return -1;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return Info.Instance().Abilities[(int)value].Value;
		}
	}
}
