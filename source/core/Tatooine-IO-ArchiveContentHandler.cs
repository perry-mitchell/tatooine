using System;
using System.IO;
using System.Security;
using Tatooine.Encryption;
using Tatooine.Utilities;
using System.Collections;
using System.Text;
using Procurios.Public;

namespace Tatooine.IO {

	public class ArchiveContentHandler : IArchiveHander {

		private string _encryptedContent;
		private SecureString _password;

		public ArchiveContentHandler(string content, SecureString password) {
			_encryptedContent = content;
			_password = password;
		}

		public static string encryptContent(string content, SecureString password) {
			string enc;
			using(SecureStringToStringMarshaler sm = new SecureStringToStringMarshaler(password)) {
				byte[] passw = Encoding.UTF8.GetBytes(sm.String);
				enc = AES.Encrypt(content, passw);
			}
			return enc;
		}

		public static string encryptRawContent(Hashtable rawContent, SecureString password) {
			string json = JSON.JsonEncode(rawContent);
			return encryptContent(json, password);
		}

		public string getDecryptedContent() {
			string decoded = "";
			try {
				using(SecureStringToStringMarshaler sm = new SecureStringToStringMarshaler(_password)) {
					byte[] passw = Encoding.UTF8.GetBytes(sm.String);
					decoded = AES.Decrypt(_encryptedContent, passw);
				}
			} catch (Exception e) {
				throw new Exception("Failed decoding archive (wrong password?): " + e.Message);
			}
			return decoded;
		}

		public Hashtable getDecryptedTable() {
			return (Hashtable)JSON.JsonDecode(getDecryptedContent());
		}

	}

}