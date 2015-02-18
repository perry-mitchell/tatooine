using System;
using System.IO;
using System.Security;
using System.Security.Cryptography;
using System.Collections.Generic;

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

		// ---

		[Test] public void testCreateGroupReturnsHash() {
			PasswordArchive archive = PasswordArchive.createNew(passwordSecure);
			string hash = archive.createGroup("Amazing Group");
			Assert.AreEqual(hash.Length, 64);
		}

		[Test] public void testCreateGroupStoresGroup() {
			PasswordArchive archive = PasswordArchive.createNew(passwordSecure);
			string hash = archive.createGroup("Amazing Group");
			StringAssert.IsMatch(archive.getGroupName(hash), "Amazing Group");
			StringAssert.IsMatch(archive.getGroupName(hash + "2"), "");
		}

		[Test] public void testGroupExists() {
			PasswordArchive archive = PasswordArchive.createNew(passwordSecure);
			string hash = archive.createGroup("some-group");
			Assert.True(archive.groupExists(hash));
		}

		[Test] public void testGroupsPersistLoading() {
			PasswordArchive archive = PasswordArchive.createNew(passwordSecure);
			string hash = archive.createGroup("Amazing Group");
			archive.writeToFile("test.tat");
			Assert.True(File.Exists("test.tat"));

			PasswordArchive archive2 = PasswordArchive.createWithFile("test.tat", passwordSecure);
			Assert.True(archive2.groupExists(hash));
			StringAssert.IsMatch(archive2.getGroupName(hash), "Amazing Group");
			File.Delete("test.tat");
		}

		[Test] public void testGetGroupHashForName() {
			PasswordArchive archive = PasswordArchive.createNew(passwordSecure);
			string hash = archive.createGroup("Amazing Group");
			string testHash = archive.getGroupHashForName("Amazing Group");
			StringAssert.IsMatch(hash, testHash);
		}

		[Test] public void testGetGroupsGetsAllGroups() {
			PasswordArchive archive = PasswordArchive.createNew(passwordSecure);
			string hash1 = archive.createGroup("Group 1");
			string hash2 = archive.createGroup("Group 2");
			Dictionary<string, string> groups = archive.getGroups();
			Assert.True(groups.ContainsValue("Group 1"));
			Assert.True(groups.ContainsValue("Group 2"));
		}

		[Test] public void testGroupNameExists() {
			PasswordArchive archive = PasswordArchive.createNew(passwordSecure);
			string hash = archive.createGroup("Amazing Group");
			Assert.True(archive.groupNameExists("Amazing Group"));
		}

		[Test] public void testSetArchiveTitlePersists() {
			PasswordArchive archive = PasswordArchive.createNew(passwordSecure);
			archive.setArchiveTitle("my passwords");
			archive.writeToFile("test.tat");
			Assert.True(File.Exists("test.tat"));

			PasswordArchive archive2 = PasswordArchive.createWithFile("test.tat", passwordSecure);
			StringAssert.IsMatch(archive2.getArchiveTitle(), "my passwords");
			File.Delete("test.tat");
		}

	}

}