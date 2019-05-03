using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace FF10.Models
{
	class BlitzBall
	{
		private readonly uint mExpAddress;
		private readonly uint mSlotAddress;
		private readonly uint mLvAddress;
		private readonly uint mAgreementAddress;
		public NameValueInfo Info { get; }
		public ObservableCollection<BitValue> Skills { get; set; } = new ObservableCollection<BitValue>();

		public BlitzBall(uint address, NameValueInfo info)
		{
			mExpAddress = address + 1384 + info.Value * 2;
			mSlotAddress = address + 914 + info.Value;
			mLvAddress = address + 974 + info.Value;
			mAgreementAddress = address + 1322 + info.Value;
			Info = info;

			foreach (var item in FF10.Info.Instance().Blitz_Skill)
			{
				Skills.Add(new BitValue(address + info.Value * 4, item));
			}
		}

		public uint Lv
		{
			get { return SaveData.Instance().ReadNumber(mLvAddress, 1); }
			set { Util.WriteNumber(mLvAddress, 1, value, 1, 99); }
		}

		public uint Agreement
		{
			get { return SaveData.Instance().ReadNumber(mAgreementAddress, 1); }
			set { Util.WriteNumber(mAgreementAddress, 1, value, 0, 255); }
		}

		public uint Exp
		{
			get { return SaveData.Instance().ReadNumber(mExpAddress, 2); }
			set { Util.WriteNumber(mExpAddress, 2, value, 0, 9999); }
		}

		public uint Slot
		{
			get { return SaveData.Instance().ReadNumber(mSlotAddress, 1); }
			set { Util.WriteNumber(mSlotAddress, 1, value, 0, 5); }
		}
	}
}
