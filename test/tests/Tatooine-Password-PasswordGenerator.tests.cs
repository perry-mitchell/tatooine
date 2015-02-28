using System;

using NUnit.Framework;
using Tatooine.Password;

namespace TatooineTests {

	[TestFixture]
	class PasswordGeneratorTests {

		[SetUp] public void init() {
			
		}

		[Test] public void testGeneratesPasswordDefaultSettings() {
			string newPassword = PasswordGenerator.generateNewPassword(new PasswordGeneratorOptions());
			Assert.Greater(newPassword.Length, 0);
		}

	}

}