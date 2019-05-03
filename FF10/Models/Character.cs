using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using FF10.Helpers;

namespace FF10.Models
{
	class Character
	{
		private readonly uint mAddress;
		public NameValueInfo Info { get; set; }
		public ObservableCollection<BitValue> Skills { get; set; } = new ObservableCollection<BitValue>();
		public ObservableCollection<OverDrive> OverDrives { get; set; } = new ObservableCollection<OverDrive>();

		public Character(uint address)
		{
			mAddress = address;

			foreach (var info in FF10.Info.Instance().Skills)
			{
				Skills.Add(new BitValue(address + 60, info));
			}

			foreach (var info in FF10.Info.Instance().OverDrives)
			{
				OverDrives.Add(new OverDrive(address + 94 + info.Value * 2, address + 134, info));
			}
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

		public uint OverDriveGauge
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 55, 1); }
			set { Util.WriteNumber(mAddress + 55, 1, value, 0, 100); }
		}
	}
}
