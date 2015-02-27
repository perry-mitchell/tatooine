using System;
using NUnit.Framework;

using Tatooine;

namespace TatooineTests {

	[TestFixture]
	class RandomTests {

		[SetUp] public void init() {

		}

		[Test] public void testRandomNumbersStayBetweenBounds() {
			for (int i = 0; i < 1000; i += 1) {
				int random = Tatooine.Tools.Random.getRandomNumber(1, 1000);
				Assert.Greater(random, 0);
				Assert.Less(random, 1001);
			}
		}

	}

}