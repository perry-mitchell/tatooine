using System;
using System.Security;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Tatooine.IO;

namespace Tatooine {

	public class PasswordArchive {

		public const int		PASSWORD_MIN_LENGTH =			8;
		public const string 	SUPPORTED_ARCHIVE_FORMAT = 		"Tatooine-archive-A";

		protected Hashtable _archive;

		protected PasswordArchive (Hashtable archive) {
			_archive = archive;
		}

		public string createGroup(string groupName) {
			if (groupName.Length > 0) {
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
			}
			return "";
		}

		public static PasswordArchive createFromFileStorage(PasswordStorageAbstract storage) {
			Hashtable data = storage.readArchiveData();
			return new PasswordArchive(data);
		}

		public static PasswordArchive createFromFileUsingPlainText(string filename) {
			PasswordTextStorage textStorage = new PasswordTextStorage(filename);
			return createFromFileStorage(textStorage);
		}

		public static PasswordArchive createFromFileUsingPassword(string filename, SecureString password) {
			PasswordEncryptedStorage encryptedStorage = new PasswordEncryptedStorage(filename, password);
			return createFromFileStorage(encryptedStorage);
		}

		public static PasswordArchive createNew() {
			return new PasswordArchive(new Hashtable());
		}

		public string getArchiveFormat() {
			return (_archive.ContainsKey("format")) ? (string)_archive["format"] : "";
		}

		public string getArchiveTitle() {
			return (_archive.ContainsKey("title")) ? (string)_archive["title"] : "";
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

		public bool isSupported() {
			return getArchiveFormat().Equals(SUPPORTED_ARCHIVE_FORMAT);
		}

		public void setArchiveFormat(string format) {
			_archive["format"] = format;
		}

		public void setArchiveTitle(string title) {
			_archive["title"] = title;
		}

		public bool writeToStorage(PasswordStorageAbstract storage) {
			bool wrote = false;
			try {
				storage.saveArchiveData(_archive);
				wrote = true;
			} catch (Exception e)  {
				Console.WriteLine("Failed saving archive data to file: {0}", e);
			}
			return wrote;
		}

	}

}

