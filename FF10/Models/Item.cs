using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace FF10.Models
{
	class Item : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		public Item(uint id, uint count)
		{
			mIDAddress = id;
			mCountAddress = count;
		}

		public uint ID
		{
			get { return SaveData.Instance().ReadNumber(mIDAddress, 2); }
			set
			{
				SaveData.Instance().WriteNumber(mIDAddress, 2, value);
				PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(ID)));
			}
		}

		public uint Count
		{
			get { return SaveData.Instance().ReadNumber(mCountAddress, 1); }
			set
			{
				Util.WriteNumber(mCountAddress, 1, value, 0, 99);
				PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(Count)));
			}
		}

		private readonly uint mIDAddress;
		private readonly uint mCountAddress;
	}
}
