using System;

using NUnit.Framework;
using Tatooine.Password;

namespace TatooineTests {

	[TestFixture]
	class PasswordGeneratorAndStrengthCalculatorIntTests {

		[SetUp] public void init() {

		}

		// ---

		[Test] public void testGeneratorCreatesStrongPasswordsByDefault() {
			string newPassword = PasswordGenerator.generateNewPassword(new PasswordGeneratorOptions());
			PasswordStrength ps = StrengthCalculator.calculateStrength(newPassword);
			Assert.AreEqual(PasswordStrength.STRONG, ps, "Expected 'STRONG' strength for generated password: " + newPassword);
		}

	}

}