using System;
using System.Collections.Generic;

using NUnit.Framework;
using Tatooine.Password;

namespace TatooineTests {

	[TestFixture]
	class PasswordStrengthTests {

		private const string PASSWORD_VERY_STRONG = "aG4.$d81X?z0*w_mI+";

		[SetUp] public void init() {
			
		}

		[Test] public void testStrengthAlwaysReturnsAValue() {
			int strength = StrengthCalculator.calculateStrength(PASSWORD_VERY_STRONG);
			Assert.Greater(strength, 0);
		}

		/*[Test] public void testStrengthAccurateForVeryStrongPasswords() {
			List<string> strongPasswords = new List<string> {
				"some long strong passw0rd!",
				"th!5 i5_4_5strONG pass.word",
				"asd4FASF45%$"
			};
			foreach (string password in strongPasswords) {
				Assert.AreEqual(PasswordScore.VeryStrong, StrengthCalculator.calculateStrength(password),
					"Expected 'VeryStrong' strength for password: " + password);
			}
		}*/
	}

}