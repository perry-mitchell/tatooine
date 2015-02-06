using System;
using System.IO;
using System.Security;
using Tatooine.Encryption;
using Tatooine.Utilities;
using System.Collections;

namespace Tatooine.IO {

	public class ArchiveFileHandler : IArchiveHander {

		private string _archiveFilename;
		private SecureString _password;

		public ArchiveFileHandler(string filename, SecureString password) {
			_archiveFilename = filename;
			_password = password;
		}

		public ArchiveContentHandler getContentHandler() {
			string content = File.ReadAllText(_archiveFilename);
			ArchiveContentHandler contentHandler = new ArchiveContentHandler(content, _password);
			return contentHandler;
		}

		public string getDecryptedContent() {
			string content = File.ReadAllText(_archiveFilename);
			ArchiveContentHandler contentHandler = new ArchiveContentHandler(content, _password);
			return contentHandler.getDecryptedContent();
		}

		public static void writeEncryptedContent(string filename, string unencryptedContent, SecureString password) {
			string encrypted = ArchiveContentHandler.encryptContent(unencryptedContent, password);
			File.WriteAllText(filename, encrypted);
		}

		public static void writeEncryptedContent(string filename, Hashtable unencryptedContent, SecureString password) {
			string encrypted = ArchiveContentHandler.encryptRawContent(unencryptedContent, password);
			File.WriteAllText(filename, encrypted);
		}

	}

}