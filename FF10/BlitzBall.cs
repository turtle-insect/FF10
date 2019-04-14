using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace FF10
{
	class BlitzBall
	{
		private readonly uint mAddress;
		public NameValueInfo Info { get; }
		public ObservableCollection<BitValue> Skills { get; set; } = new ObservableCollection<BitValue>();

		public BlitzBall(uint address, NameValueInfo info)
		{
			mAddress = address + 1384 + info.Value * 2;
			Info = info;

			foreach (var item in FF10.Info.Instance().Blitz_Skill)
			{
				Skills.Add(new BitValue(address + info.Value * 4, item));
			}
		}

		public uint Exp
		{
			get { return SaveData.Instance().ReadNumber(mAddress, 2); }
			set { Util.WriteNumber(mAddress, 2, value, 0, 9999); }
		}
	}
}
