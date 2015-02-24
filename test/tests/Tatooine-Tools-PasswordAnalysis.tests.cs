using System;

using NUnit.Framework;
using Tatooine.Tools;

namespace TatooineTests {

	[TestFixture]
	class PasswordAnalysisTests {

		[SetUp] public void init() {
			
		}

		[Test] public void testCountsFullLengthLetters() {
			int count = PasswordAnalysis.countSequentialCharacters("abcdef");
			Assert.AreEqual(6, count);
		}

		[Test] public void testCountsFullLengthLettersReverse() {
			int count = PasswordAnalysis.countSequentialCharacters("jihgfed");
			Assert.AreEqual(7, count);
		}

		[Test] public void testCountsHalfUpperHalfLower() {
			int count = PasswordAnalysis.countSequentialCharacters("mnoPQRST");
			Assert.AreEqual(8, count);
		}

		[Test] public void testCountsLettersInSitu() {
			int count = PasswordAnalysis.countSequentialCharacters("36cw9.s9cde30-1");
			Assert.AreEqual(3, count);
		}

		[Test] public void testCountsLettersWithBreak() {
			int count = PasswordAnalysis.countSequentialCharacters("bcde.:?KLMNO");
			Assert.AreEqual(9, count);
		}

		[Test] public void testCountsNumbers() {
			int count = PasswordAnalysis.countSequentialCharacters("0123456789");
			Assert.AreEqual(10, count);
		}

		[Test] public void testCountsNumbersAtPeak() {
			// skips 1 as the change in direction loses a character
			int count = PasswordAnalysis.countSequentialCharacters("6543456");
			Assert.AreEqual(6, count);
		}

	}

}