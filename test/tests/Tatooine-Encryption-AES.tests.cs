using System;

using NUnit.Framework;
using Tatooine.Encryption;
using System.Text;

namespace TatooineTests {

	[TestFixture]
	class EncryptionAESTests {

		[SetUp] public void init() {
			
		}

		[Test] public void testEncryptAndDecrypt() {
			string password = "some special password";
			byte[] passw = Encoding.UTF8.GetBytes(password);
			string text = "this is some text, it should be secure!";

			string encrypted = AES.Encrypt(text, passw);
			StringAssert.AreNotEqualIgnoringCase(encrypted, text);
			string decrypted = AES.Decrypt(encrypted, passw);
			StringAssert.AreEqualIgnoringCase(text, decrypted);
		}

	}

}