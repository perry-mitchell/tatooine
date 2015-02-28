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
			List<string> weakPasswords = new List<string> {
				"AkMuEvPSM",
				"a1a1a1a1",
				"aaaaaaa1",
				"bottle54"
			};
			foreach (string password in weakPasswords) {
				//int strength = StrengthCalculator.calculateStrengthIndex(password);
				//Console.WriteLine(":: " + password + " => " + strength);

				PasswordStrength ps = StrengthCalculator.calculateStrength(password);
				Assert.AreEqual(PasswordStrength.WEAK, ps, "Expected 'WEAK' strength for password: " + password);
			}
		}

		[Test] public void testCalculateStrengthAveragePasswords() {
			List<string> averagePasswords = new List<string> {
				"i Am 4 horse",
				"t0keN freely.",
				"ia!mBar8b?",
				"zD7.C95.vK"
			};
			foreach (string password in averagePasswords) {
				//int strength = StrengthCalculator.calculateStrengthIndex(password);
				//Console.WriteLine(":: " + password + " => " + strength);

				PasswordStrength ps = StrengthCalculator.calculateStrength(password);
				Assert.AreEqual(PasswordStrength.AVERAGE, ps, "Expected 'AVERAGE' strength for password: " + password);
			}
		}

		[Test] public void testCalculateStrengthStrongPasswords() {
			List<string> strongPasswords = new List<string> {
				PASSWORD_STRONG,
				"%d.@ a5N+kC-",
				"4$ld9.7@zT5",
				"a@#!B$%9---",
				"correct horse battery staple"
			};
			foreach (string password in strongPasswords) {
				//int strength = StrengthCalculator.calculateStrengthIndex(password);
				//Console.WriteLine(":: " + password + " => " + strength);

				PasswordStrength ps = StrengthCalculator.calculateStrength(password);
				Assert.AreEqual(PasswordStrength.STRONG, ps, "Expected 'STRONG' strength for password: " + password);
			}
		}

		[Test] public void testStrengthAlwaysReturnsAValue() {
			int strength = StrengthCalculator.calculateStrengthIndex(PASSWORD_STRONG);
			Assert.Greater(strength, 0);
		}

	}

}