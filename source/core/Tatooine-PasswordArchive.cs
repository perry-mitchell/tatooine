using System;
using System.Collections;
using System.Collections.Generic;
using System.Security;
using System.Linq;

using Tatooine.IO;

namespace Tatooine {

	public class PasswordArchive {

		public const int		PASSWORD_MIN_LENGTH =			8;
		public const string 	SUPPORTED_ARCHIVE_FORMAT = 		"Tatooine-archive-A";

		protected Hashtable _archive;
		private SecureString _password;

		protected PasswordArchive(Hashtable archive, SecureString password) {
			_archive = archive;
			_password = password;
		}

		public PasswordEntry createEntry(string title, string groupHash) {
			title = title.Trim();
			if (!groupExists(groupHash)) {
				throw new Exception("Group for hash does not exist: " + groupHash);
			}
			if (title.Length <= 0) {
				throw new Exception("Title must be set and not empty");
			}
			if (getEntry(title, groupHash) != null) {
				throw new Exception("Title must be unique");
			}
			Hashtable newEntry = new Hashtable();
			newEntry.Add("title", title);
			newEntry.Add("group", groupHash);
			if (!_archive.ContainsKey("items")) {
				_archive.Add("items", new ArrayList());
			}
			ArrayList items = (ArrayList)_archive["items"];
			items.Add(newEntry);
			PasswordEntry pe = new PasswordEntry(newEntry);
			pe.setProperty("username", "");
			pe.setProperty("password", "");
			return pe;
		}

		public string createGroup(string groupName) {
			if (groupName.Length > 0) {
				if (groupNameExists(groupName)) {
					throw new Exception("Group already exists: " + groupName);
				}
				string existingGroup = "";
				string newHash = "";
				Random rnd = new Random();
				do {
					newHash = Tools.Encoding.sha256(groupName + rnd.Next(1, 9999).ToString());
					existingGroup = getGroupName(newHash);
				} while (existingGroup.Length > 0);
				if (newHash.Length <= 0) {
					throw new Exception("Failed generating a new group hash");
				}
				if (!_archive.ContainsKey("groups")) {
					_archive.Add("groups", new Hashtable());
				}
				Hashtable groups = (Hashtable)_archive["groups"];
				groups.Add(newHash, groupName);
				return newHash;
			} else {
				throw new Exception("Group name must not be empty");
			}
		}

		public static PasswordArchive createNew(SecureString password) {
			Hashtable newTable = new Hashtable();
			newTable["format"] = SUPPORTED_ARCHIVE_FORMAT;
			return new PasswordArchive(newTable, password);
		}

		public static PasswordArchive createWithFile(string filename, SecureString password) {
			ArchiveFileHandler fileHandler = new ArchiveFileHandler(filename, password);
			Hashtable props = fileHandler.getContentHandler().getDecryptedTable();

			// TODO: check props are valid

			PasswordArchive archive = new PasswordArchive(props, password);
			if (!archive.isSupported()) {
				Console.WriteLine("Archives must be in format: " + SUPPORTED_ARCHIVE_FORMAT);
				throw new Exception("Invalid archive format: " + archive.getArchiveFormat());
			}
			return archive;
		}

		public string getArchiveFormat() {
			return (_archive.ContainsKey("format")) ? (string)_archive["format"] : "";
		}

		public string getArchiveTitle() {
			return (_archive.ContainsKey("title")) ? (string)_archive["title"] : "";
		}

		public List<PasswordEntry> getEntriesForGroup(string groupHash) {
			List<PasswordEntry> entries = new List<PasswordEntry>();
			if (_archive.ContainsKey("items")) {
				ArrayList items = (ArrayList)_archive["items"];
				for (int i = 0; i < items.Count; i += 1) {
					Hashtable currentItem = (Hashtable)items[i];
					string currentHash = (currentItem.ContainsKey("group")) ? (string)currentItem["group"] : "";
					if (currentHash.Equals(groupHash) && (groupHash.Length > 0)) {
						PasswordEntry pe = new PasswordEntry(currentItem);
						entries.Add(pe);
					}
				}
			}
			return entries;
		}

		public PasswordEntry getEntry(string entryName, string groupHash) {
			List<PasswordEntry> entries = getEntriesForGroup(groupHash);
			foreach (PasswordEntry pe in entries) {
				if (pe.getTitle().Equals(entryName)) {
					return pe;
				}
			}
			return null;
		}

		public string getGroupHashForName(string groupName) {
			Dictionary<string, string> groups = getGroups();
			foreach (KeyValuePair<string, string> group in groups) {
				if (group.Value.Equals(groupName)) {
					return group.Key;
				}
			}
			return "";
		}

		public string getGroupName(string hash) {
			Dictionary<string, string> groups = getGroups();
			return (groups.ContainsKey(hash)) ? groups[hash] : "";
		}

		public Dictionary<string, string> getGroups() {
			if (_archive.ContainsKey("groups")) {
				Hashtable groupsHashtable = (Hashtable)_archive["groups"];
				return Tools.Encoding.hashtableToDictionary<string, string>(groupsHashtable);
			}
			return new Dictionary<string, string>();
		}

		public bool groupExists(string hash) {
			return (getGroupName(hash).Length > 0);
		}

		public bool groupNameExists(string name) {
			return getGroups().ContainsValue(name);
		}

		public bool isSupported() {
			return getArchiveFormat().Equals(SUPPORTED_ARCHIVE_FORMAT);
		}

		public void setArchiveFormat(string format) {
			_archive["format"] = format;
		}

		public void setArchiveTitle(string title) {
			_archive["title"] = title;
		}

		public void writeToFile(string filename) {
			ArchiveFileHandler.writeEncryptedContent(filename, _archive, _password);
		}

	}

}