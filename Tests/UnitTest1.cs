namespace Tests
{
	[TestClass]
	public class UnitTest1
	{
		private static void MirrorX(Span<byte> bytes) => CMNDAT.BluePrint.MirrorX(bytes);

		[TestMethod]
		public void blueprint0()
		{
			var a = ReadBlueprint("0/bp0.bin");
			var b = ReadBlueprint("0/bp1.bin");
			Assert.IsFalse(a.SequenceEqual(b));
			MirrorX(a);
			Assert.IsTrue(a.SequenceEqual(b));

			var c = ReadBlueprint("0/bp2.bin");
			var d = ReadBlueprint("0/bp3.bin");
			Assert.IsFalse(c.SequenceEqual(d));
			MirrorX(c);
			Assert.IsTrue(c.SequenceEqual(d));
		}

		[TestMethod]
		public void blueprint1()
		{
			var orig = ReadBlueprint("1/orig.bin");
			var flipLR = ReadBlueprint("1/flipLR.bin");
			Assert.IsFalse(orig.SequenceEqual(flipLR));
			CMNDAT.BluePrint.MirrorX(orig);

			for (int i = 0; i < orig.Length; i++)
			{
				// OOPS You need to know the SIZE of each item in order to flip it!
				// (But not to rotate it, I think)
				if (i >= 954 && i <= 1054) { continue; }

				Assert.AreEqual(orig[i], flipLR[i], $"Differed at {i}");
			}
			Assert.Fail("TODO need size of each item!");
		}

		private static byte[] ReadBlueprint(string relativePath)
		{
			var root = FindBlueprintsTestData();
			var fullName = Path.Combine(root.FullName, relativePath);
			return System.IO.File.ReadAllBytes(fullName);
		}

		private static DirectoryInfo FindBlueprintsTestData()
		{
			var start = Directory.GetCurrentDirectory();
			var dir = new DirectoryInfo(start);
			do
			{
				var found = dir.GetDirectories("TestData").FirstOrDefault()
					?.GetDirectories("Blueprints")?.FirstOrDefault();
				if (found != null)
				{
					return found;
				}

				dir = dir.Parent;
			} while (dir != null);

			throw new Exception($"Could not find blueprint test data, started from {start}");
		}
	}
}
