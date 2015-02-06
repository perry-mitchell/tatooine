using System;
using System.IO;
using System.Security;
using Tatooine.Encryption;
using Tatooine.Utilities;

namespace Tatooine.IO {

	public class ArchiveContentHandler : IArchiveHander {

		private string _encryptedContent;
		private SecureString _password;

		public ArchiveFileHandler(string content, SecureString password) {
			_encryptedContent = content;
			_password = password;
		}

		public string getDecryptedContent() {
			string decoded = "";
			try {
				using(SecureStringToStringMarshaler sm = new SecureStringToStringMarshaler(_password)) {
					byte[] passw = Encoding.UTF8.GetBytes(sm.String);
					decoded = AES.Decrypt(data, passw);
				}
			} catch (Exception e) {
				throw new Exception("Failed decoding archive (wrong password?)");
			}
			return decoded;
		}

	}

}