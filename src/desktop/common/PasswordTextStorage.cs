using System;
using System.Collections;
using System.IO;
using Procurios.Public;

namespace Tatooine.IO {

	public class PasswordTextStorage : PasswordStorageAbstract {

		public PasswordTextStorage (string filename) : base(filename) {
		}

		public override Hashtable decodeArchiveData(string data) {
			Hashtable props = (Hashtable)JSON.JsonDecode (data);
			return props;
		}

		public override string encodeArchiveData (Hashtable data) {
			string json = JSON.JsonEncode(data);
			return json;
		}

		public override Hashtable readArchiveData() {
			string contents = File.ReadAllText (_filename);
			return decodeArchiveData (contents);
		}

		public override void saveArchiveData(Hashtable data) {
			string contents = encodeArchiveData (data);
			File.WriteAllText (_filename, contents);
		}

	}

}

