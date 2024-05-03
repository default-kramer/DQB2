using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Media;

namespace CMNDAT
{
	public class BluePrint : INotifyPropertyChanged
	{
		public uint Address { get; private set; }
		public Brush Brush { get; private set; }

		public BluePrint(uint address, Brush brush)
		{
			Address = address;
			Brush = brush;
		}

		const int TrailerStart = OffsetX;
		const int OffsetX = 0x30000;
		const int OffsetY = 0x30002;
		const int OffsetZ = 0x30004;
		const int BytesPerBlock = 6;

		public uint X
		{
			get { return SaveData.Instance().ReadNumber(Address + OffsetX, 2); }
			set
			{
				SaveData.Instance().WriteNumber(Address + OffsetX, 2, value);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(X)));
			}
		}

		public uint Y
		{
			get { return SaveData.Instance().ReadNumber(Address + OffsetY, 2); }
			set
			{
				SaveData.Instance().WriteNumber(Address + OffsetY, 2, value);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Y)));
			}
		}

		public uint Z
		{
			get { return SaveData.Instance().ReadNumber(Address + OffsetZ, 2); }
			set
			{
				SaveData.Instance().WriteNumber(Address + OffsetZ, 2, value);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Z)));
			}
		}

		public void Reload()
		{
			X = X;
			Y = Y;
			Z = Z;
		}

		public event PropertyChangedEventHandler? PropertyChanged;

		/// <summary>
		/// Mirrors the blueprint such that left becomes right and right becomes left.
		/// </summary>
		public static void MirrorX(Span<byte> mBuffer)
		{
			if (mBuffer.Length != Util.BluePrintSize)
			{
				throw new ArgumentException("Not correct size", nameof(mBuffer));
			}

			var swap = new byte[BytesPerBlock];

			int width = (int)SaveData.ReadNumber(OffsetX, 2, mBuffer);
			int height = (int)SaveData.ReadNumber(OffsetY, 2, mBuffer);
			int depth = (int)SaveData.ReadNumber(OffsetZ, 2, mBuffer);

			Func<int, int, int, int> GetAddress = (int x, int y, int z) => 0
				+ z * width * height * BytesPerBlock
				+ x * height * BytesPerBlock
				+ y * BytesPerBlock;

			if (GetAddress(width - 1, height - 1, depth - 1) >= TrailerStart)
			{
				throw new ArgumentException($"Trailer contains bad dimensions? {width}x{height}x{depth}", nameof(mBuffer));
			}

			for (int z = 0; z < depth; z++)
			{
				for (int x = 0; x < width / 2; x++)
				{
					for (int y = 0; y < height; y++)
					{
						var slice1 = mBuffer.Slice(GetAddress(x, y, z), BytesPerBlock);
						var slice2 = mBuffer.Slice(GetAddress(width - (1 + x), y, z), BytesPerBlock);
						slice1.CopyTo(swap);
						slice2.CopyTo(slice1);
						swap.CopyTo(slice2);

						FlipOrientation(slice1);
						FlipOrientation(slice2);
					}
				}
			}
		}

		private static void FlipOrientation(Span<byte> block)
		{
			if (block.Length != BytesPerBlock)
			{
				throw new ArgumentException(nameof(block));
			}

			var category = SaveData.ReadNumber(0, 2, block);
			if (category == 0)
			{
				// Category 0 blocks have no orientation and always use 0
				return;
			}

			// The lowest two bits control orientation.
			// (And all other bits are always zero?)
			byte orientation = block[4];
			byte temp = (orientation % 4) switch
			{
				0 => 2,
				1 => 3,
				2 => 0,
				3 => 1,
				_ => throw new Exception("impossible")
			};

			orientation &= 0xFC;
			orientation |= temp;
			block[4] = orientation;
		}

		/// <param name="rotation">
		/// 0 -> 0 degrees
		/// 1 -> 90 degrees
		/// 2 -> 180 degrees
		/// 3 -> 270 degrees
		/// </param>
		public static void RotateClockwise(int rotation, Span<byte> mBuffer)
		{
			if (mBuffer.Length != Util.BluePrintSize)
			{
				throw new ArgumentException("Not correct size", nameof(mBuffer));
			}

			rotation = rotation % 4;
			if (rotation == 0)
			{
				return;
			}

			uint width = SaveData.ReadNumber(OffsetX, 2, mBuffer);
			uint height = SaveData.ReadNumber(OffsetY, 2, mBuffer);
			uint depth = SaveData.ReadNumber(OffsetZ, 2, mBuffer);

			for (int y = 0; y < height; y++)
			{
				for (int x = 0; x < width; x++)
				{
					for (int z = 0; z < depth; z++)
					{

					}
				}
			}

			if (rotation == 1 || rotation == 3)
			{
				(width, depth) = (depth, width);
				SaveData.WriteNumber(OffsetX, 2, width, mBuffer);
				SaveData.WriteNumber(OffsetZ, 2, depth, mBuffer);
			}
		}
	}
}
