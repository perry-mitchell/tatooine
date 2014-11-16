using System;
using System.Collections;

namespace Tatooine.IO {

	public abstract class PasswordStorageAbstract {
		
		protected string _filename;

		public PasswordStorageAbstract(string filename) {
			_filename = filename;
		}

		public abstract Hashtable decodeArchiveData(string data);
		public abstract string encodeArchiveData(Hashtable data);
		public abstract Hashtable readArchiveData();
		public abstract void saveArchiveData(Hashtable data);

	}

}

