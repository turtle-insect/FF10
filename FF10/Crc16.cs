using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF10
{
	class Crc16
	{
		private readonly ushort[] mTable = new ushort[256];

		public Crc16()
		{
			for (ushort i = 0; i < mTable.Length - 1; i++)
			{
				ushort x = (ushort)(i << 8);
				for (ushort j = 0; j < 8; j++)
				{
					x = (ushort)((x & 0x8000) == 0 ? x << 1 : 0x1021 ^ (x << 1));
				}
				mTable[i] = x;
			}
		}

		public ushort Calc(ref Byte[] buf, int start, int end)
		{
			uint crc = 0xFFFF;
			for (int i = start; i < end; i++)
			{
				crc = mTable[(crc >> 8) ^ buf[i]] ^ (crc << 8);
				crc &= 0xFFFF;
			}

			return (ushort)((crc ^ 0xFFFF) & 0xFFFF);
		}
	}
}
