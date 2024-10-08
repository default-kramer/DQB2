﻿namespace CMNDAT
{
	internal class Party
	{
		private readonly uint mAddress;

		public Party(uint address)
		{
			mAddress = address;
		}

		public uint ID
		{
			get { return SaveData.Instance().ReadNumber(mAddress, 2); }
			set { SaveData.Instance().WriteNumber(mAddress, 2, value); }
		}

		public uint Type
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 2, 1); }
			set { SaveData.Instance().WriteNumber(mAddress + 2, 1, value); }
		}
	}
}
