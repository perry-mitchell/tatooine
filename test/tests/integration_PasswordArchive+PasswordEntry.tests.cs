using System;
using System.IO;
using System.Security;
using System.Security.Cryptography;
using System.Collections;
using System.Collections.Generic;

using NUnit.Framework;
using Tatooine;

namespace TatooineTests {

	[TestFixture]
	class PasswordArchiveAndEntryIntTests {

		private string passwordRaw;
		private SecureString passwordSecure;

		[SetUp] public void init() {
			passwordRaw = "4n07h3r3 secure .p.a.s.s.word/";
			passwordSecure = Tatooine.Tools.Encoding.stringToSecureString(passwordRaw);
		}

		// ---

		[Test] public void testPasswordEntryPersists() {
			PasswordArchive archive = PasswordArchive.createNew(passwordSecure);
			string groupHash = archive.createGroup("some group");
			Assert.AreEqual(groupHash.Length, 64);
			PasswordEntry entry = archive.createEntry("some entry", groupHash);
			entry.setProperty("password", "some password");

			archive.writeToFile("test.tat");
			Assert.True(File.Exists("test.tat"));

			PasswordArchive archive2 = PasswordArchive.createWithFile("test.tat", passwordSecure);
			Assert.True(archive.groupExists(groupHash));
			PasswordEntry entry2 = archive2.getEntry("some entry", groupHash);
			StringAssert.IsMatch(entry2.getProperty("password"), "some password");

			File.Delete("test.tat");
		}

	}

}