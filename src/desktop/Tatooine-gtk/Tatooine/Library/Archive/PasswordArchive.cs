using System;
using System.Collections;
using Tatooine.IO;

namespace Tatooine {

	public class PasswordArchive {

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


	}

}

