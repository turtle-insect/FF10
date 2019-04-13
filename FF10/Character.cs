using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF10
{
	class Character
	{
		private readonly uint mAddress;

		public Character(uint address)
		{
			mAddress = address;
		}

		public uint HP
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 2, 4); }
			set
			{
				Util.WriteNumber(mAddress + 2, 4, value, 0, 99999);
				Util.WriteNumber(mAddress + 26, 4, value, 0, 99999);
				Util.WriteNumber(mAddress + 34, 4, value, 0, 99999);
			}
		}

		public uint MP
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 6, 4); }
			set
			{
				Util.WriteNumber(mAddress + 6, 4, value, 0, 9999);
				Util.WriteNumber(mAddress + 30, 4, value, 0, 9999);
				Util.WriteNumber(mAddress + 38, 4, value, 0, 9999);
			}
		}

		public uint Lv
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 57, 1); }
			set { Util.WriteNumber(mAddress + 57, 1, value, 0, 99); }
		}

		public uint Attack
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 10, 1); }
			set { Util.WriteNumber(mAddress + 10, 1, value, 0, 255); }
		}

		public uint Defense
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 11, 1); }
			set { Util.WriteNumber(mAddress + 11, 1, value, 0, 255); }
		}

		public uint Magic
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 12, 1); }
			set { Util.WriteNumber(mAddress + 12, 1, value, 0, 255); }
		}

		public uint MagicGuard
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 13, 1); }
			set { Util.WriteNumber(mAddress + 13, 1, value, 0, 255); }
		}

		public uint Speed
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 14, 1); }
			set { Util.WriteNumber(mAddress + 14, 1, value, 0, 255); }
		}

		public uint Luck
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 15, 1); }
			set { Util.WriteNumber(mAddress + 15, 1, value, 0, 255); }
		}

		public uint Avoidance
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 16, 1); }
			set { Util.WriteNumber(mAddress + 16, 1, value, 0, 255); }
		}

		public uint Hit
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 17, 1); }
			set { Util.WriteNumber(mAddress + 17, 1, value, 0, 255); }
		}
	}
}
