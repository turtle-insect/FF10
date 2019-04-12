using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace FF10
{
	class ViewModel
	{
		public ObservableCollection<Charactor> Party { get; set; } = new ObservableCollection<Charactor>();

		public ViewModel()
		{
			for(uint i = 0; i < 7; i++)
			{
				Party.Add(new Charactor(0x5616 + i * 148));
			}
		}

		public uint GIL
		{
			get { return SaveData.Instance().ReadNumber(0x3D90, 4); }
			set { Util.WriteNumber(0x3D90, 4, value, 0, 9999999); }
		}
	}
}
