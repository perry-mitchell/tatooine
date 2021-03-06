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
	class PasswordEntryTests {

		private PasswordEntry entry;
		private string groupHash;

		[SetUp] public void init() {
			Hashtable entryData = new Hashtable();
			groupHash = Tatooine.Tools.Encoding.sha256("some group");
			entryData["group"] = groupHash;
			entryData["title"] = "Group Title";
			entry = new PasswordEntry(entryData);
		}

		[Test] public void testEntryHasTitle() {
			StringAssert.IsMatch(entry.getTitle(), "Group Title");
		}

		[Test] public void testGetGroup() {
			StringAssert.IsMatch(entry.getGroup(), groupHash);
		}

		[Test] public void testGetProperty() {
			entry.setProperty("someKey", "someValue");
			StringAssert.IsMatch(entry.getProperty("someKey"), "someValue");
		}

		[Test] public void testGetPropertyNamesEmptyByDefault() {
			List<string> propNames = entry.getPropertyNames();
			Assert.IsEmpty(propNames);
		}

		[Test] public void testSetsProperties() {
			entry.setProperty("some", "thing");
			entry.setProperty("another", "item");
			List<string> propNames = entry.getPropertyNames();
			CollectionAssert.Contains(propNames, "some");
			CollectionAssert.Contains(propNames, "another");
		}

		[Test] public void testSetTitle() {
			entry.setTitle("test title");
			StringAssert.IsMatch(entry.getTitle(), "test title");
		}

	}

}