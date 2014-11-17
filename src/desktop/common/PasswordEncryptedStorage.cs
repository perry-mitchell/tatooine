using System;
using System.Collections;
using System.IO;
using Procurios.Public;
using System.Security;
using System.Text;
using Tatooine.Encryption;
using Tatooine.Utilities;

namespace Tatooine.IO {

	public class PasswordEncryptedStorage : PasswordStorageAbstract {

		protected SecureString _password;

		public PasswordEncryptedStorage (string filename, SecureString password) : base(filename) {
			_password = password;
		}

		public override Hashtable decodeArchiveData(string data) {
			Hashtable props = new Hashtable();
			try {
				string decoded = "";
				using(SecureStringToStringMarshaler sm = new SecureStringToStringMarshaler(_password)) {
					byte[] passw = Encoding.UTF8.GetBytes(sm.String);
					decoded = AES.Decrypt(data, passw);
				}
				props = (Hashtable)JSON.JsonDecode(decoded);
			} catch (Exception e) {
				Console.WriteLine("Failed decoding file: {0}", _filename);
				throw new Exception("Failed decoding archive (wrong password?)");
			}
			return props;
		}

		public override string encodeArchiveData (Hashtable data) {
			string json = JSON.JsonEncode(data);
			string enc;
			using(SecureStringToStringMarshaler sm = new SecureStringToStringMarshaler(_password)) {
				byte[] passw = Encoding.UTF8.GetBytes(sm.String);
				enc = AES.Encrypt(json, passw);
			}
			return enc;
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

