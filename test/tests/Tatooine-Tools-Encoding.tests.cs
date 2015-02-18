using System;
using NUnit.Framework;
using Tatooine;

namespace TatooineTests {

	[TestFixture]
	class EncodingTests {

		[SetUp] public void init() {

		}

		[Test] public void testSha256BasicChars() {
			string sha = Tatooine.Tools.Encoding.sha256("some awesome text");
			Assert.AreEqual(sha, "3839ea58a97a993dcd5c86c824bb8f2eb88eecdcf5431f5b1964aff1e4c9b3f3");
		}

	}

}