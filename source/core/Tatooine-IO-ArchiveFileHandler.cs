using System;
using System.IO;
using System.Security;

namespace Tatooine.IO {

	public class ArchiveFileHandler : IArchiveHander {

		private string _archiveFilename;
		private SecureString _password;

		public ArchiveFileHandler(string filename) {
			_archiveFilename = filename;
		}

		public string getDecryptedContent() {
			string content = File.ReadAllText(_archiveFilename);
			ArchiveContentHandler contentHandler = new ArchiveContentHandler(content, _password);
			return contentHandler.getDecryptedContent();
		}

	}

}