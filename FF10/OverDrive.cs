using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF10
{
	class OverDrive
	{
		public NameValueInfo Info { get; private set; }

		private readonly uint mCountAddress;
		private readonly uint mEnableAddress;

		public OverDrive(uint count, uint enable, NameValueInfo info)
		{
			mCountAddress = count;
			mEnableAddress = enable;
			Info = info;
		}

		public uint Count
		{
			get { return SaveData.Instance().ReadNumber(mCountAddress, 2); }
			set { Util.WriteNumber(mCountAddress, 2, value, 0, 0xFFFF); }
		}

		public bool Enable
		{
			get { return SaveData.Instance().ReadBit(mEnableAddress + Info.Value / 8, Info.Value % 8); }
			set { SaveData.Instance().WriteBit(mEnableAddress + Info.Value / 8, Info.Value % 8, value); }
		}
	}
}
