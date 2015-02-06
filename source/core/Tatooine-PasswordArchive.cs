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
			if (!isSupported()) {
				Console.WriteLine("Archives must be in format: " + SUPPORTED_ARCHIVE_FORMAT);
				throw new Exception("Invalid archive format: " + getArchiveFormat());
			}
		}

		public static PasswordArchive createWithFile(string filename, SecureString password) {
			ArchiveFileHandler fileHandler = new ArchiveFileHandler(filename, password);
			string decryptedContent = fileHandler.getDecryptedContent();
			Hashtable props = (Hashtable)JSON.JsonDecode(decoded);

			// TODO: check props are valid

			return new PasswordArchive(props, password);
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
			
		}

	}

}