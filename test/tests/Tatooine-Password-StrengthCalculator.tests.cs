using System;
using System.Collections.Generic;

using NUnit.Framework;
using Tatooine.Password;

namespace TatooineTests {

	[TestFixture]
	class PasswordStrengthTests {

		private const string PASSWORD_STRONG = "aG4.$d8,1X?z0*w_mI+";

		[SetUp] public void init() {
			
		}

		[Test] public void testCalculateStrengthWeakPasswords() {
			// PasswordStrength ps = StrengthCalculator.calculateStrength("AkMuEvPSM-x");
			// int strength = StrengthCalculator.calculateStrengthIndex("AkMuEvPSM-x");
			// Console.WriteLine(Enum.GetName(typeof(PasswordStrength), ps) + " - " + strength);
			List<string> weakPasswords = new List<string> {
				"AkMuEvPSM",
				"a1a1a1a1",
				"bottle54"
			};
			foreach (string password in weakPasswords) {
				PasswordStrength ps = StrengthCalculator.calculateStrength(password);
				Assert.AreEqual(PasswordStrength.WEAK, ps, "Expected 'WEAK' strength for password: " + password);

				int strength = StrengthCalculator.calculateStrengthIndex(password);
				Console.WriteLine(":: " + password + " => " + strength);
			}
		}

		[Test] public void testStrengthAlwaysReturnsAValue() {
			int strength = StrengthCalculator.calculateStrengthIndex(PASSWORD_STRONG);
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