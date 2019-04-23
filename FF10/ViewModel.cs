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
		public ObservableCollection<Character> Party { get; set; } = new ObservableCollection<Character>();
		public ObservableCollection<Item> Items { get; set; } = new ObservableCollection<Item>();
		public ObservableCollection<BitValue> KeyItems { get; set; } = new ObservableCollection<BitValue>();
		public ObservableCollection<Equipment> Equipments { get; set; } = new ObservableCollection<Equipment>();
		public ObservableCollection<BlitzBall> Blitz { get; set; } = new ObservableCollection<BlitzBall>();
		public ObservableCollection<IntValue> Blitz_Term { get; set; } = new ObservableCollection<IntValue>();
		public ObservableCollection<IntValue> Monsters { get; set; } = new ObservableCollection<IntValue>();
		public ObservableCollection<IntValue> FavorabilityRatings { get; set; } = new ObservableCollection<IntValue>();
		public Info Info { get; set; } = Info.Instance();

		public ViewModel()
		{
			foreach(var info in Info.Instance().Party)
			{
				Party.Add(new Character(0x5616 + info.Value * 148) { Info = info });
			}

			for(uint i = 0; i < 256; i++)
			{
				Items.Add(new Item(0x3F14 + i * 2, 0x4114 + i));
			}

			foreach(var info in Info.Instance().KeyItems)
			{
				KeyItems.Add(new BitValue(0x44D4, info));
			}

			for (uint i = 0; i < 200; i++)
			{
				Equipments.Add(new Equipment(0x44EA + i * 22));
			}

			foreach (var info in Info.Instance().Blitz_Player)
			{
				if (info.Value >= 60) continue;
				Blitz.Add(new BlitzBall(0x1234, info));
			}
			for (uint i = 0; i < 8; i++)
			{
				Blitz_Term.Add(new IntValue(0x1676 + i, 1));
			}

			foreach (var info in Info.Instance().Monsters)
			{
				Monsters.Add(new IntValue(0x4254 + info.Value, 1) { Info = info });
			}

			for (uint i = 0; i < 6; i++)
			{
				FavorabilityRatings.Add(new IntValue(0x78 + i * 4, 4));
			}
		}

		public uint BlitzTermCount
		{
			get { return SaveData.Instance().ReadNumber(0xCC1, 1); }
			set { Util.WriteNumber(0xCC1, 1, value, 0, 8); }
		}

		public uint GIL
		{
			get { return SaveData.Instance().ReadNumber(0x3D90, 4); }
			set { Util.WriteNumber(0x3D90, 4, value, 0, 9999999); }
		}

		public uint ThunderFall
		{
			get { return SaveData.Instance().ReadNumber(0x444, 2); }
			set { Util.WriteNumber(0x444, 2, value, 0, 0xFFFF); }
		}

		public uint ThunderAvoidance
		{
			get { return SaveData.Instance().ReadNumber(0x446, 2); }
			set { Util.WriteNumber(0x446, 2, value, 0, 0xFFFF); }
		}

		public uint ThunderContinuousAvoidance
		{
			get { return SaveData.Instance().ReadNumber(0x448, 2); }
			set { Util.WriteNumber(0x448, 2, value, 0, 0xFFFF); }
		}
	}
}
