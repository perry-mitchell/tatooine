using System;
using System.IO;
using System.Security;
using System.Security.Cryptography;

using NUnit.Framework;
using Tatooine;

namespace TatooineTests {

	[TestFixture]
	class PasswordArchiveTests {

		private string passwordRaw;
		private SecureString passwordSecure;

		[SetUp] public void init() {
			passwordRaw = "this is a 53<uR3 pass.worD!";
			passwordSecure = Tatooine.Tools.Encoding.stringToSecureString(passwordRaw);
		}

		[Test] public void testCreateNewArchiveMakesFile() {
			PasswordArchive archive = PasswordArchive.createNew(passwordSecure);
			archive.writeToFile("test.tat");
			Assert.True(File.Exists("test.tat"));
			File.Delete("test.tat");
		}

	}

}