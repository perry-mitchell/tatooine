using System;
using System.Security;
using System.Collections;
using Tatooine.IO;

namespace Tatooine {

	public class PasswordArchive {

		public const string SUPPORTED_ARCHIVE_FORMAT = "Tatooine-archive-A";

		protected Hashtable _archive;

		protected PasswordArchive (Hashtable archive) {
			_archive = archive;
		}

		public static PasswordArchive createFromFileStorage(PasswordStorageAbstract storage) {
			Hashtable data = storage.readArchiveData ();
			return new PasswordArchive (data);
		}

		public static PasswordArchive createFromFileUsingPlainText(string filename) {
			PasswordTextStorage textStorage = new PasswordTextStorage (filename);
			return createFromFileStorage (textStorage);
		}

		public static PasswordArchive createFromFileUsingPassword(string filename, SecureString password) {
			return createFromFileUsingPlainText(filename);
		}

		public string getArchiveFormat() {
			return (_archive.ContainsKey("format")) ? (string)_archive["format"] : "";
		}

		public string getArchiveTitle() {
			return (_archive.ContainsKey("title")) ? (string)_archive["title"] : "";
		}

		public bool isSupported() {
			return getArchiveFormat().Equals(SUPPORTED_ARCHIVE_FORMAT);
		}

	}

}

