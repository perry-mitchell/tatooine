using System;
using System.Security;

using NUnit.Framework;
using Tatooine.Utilities;

namespace TatooineTests {

	[TestFixture]
	class SecureStringToStringMarshalerTests {

		private string passwordRaw;
		private SecureString passwordSecure;

		[SetUp] public void init() {
			passwordRaw = "some password";
			passwordSecure = Tatooine.Tools.Encoding.stringToSecureString(passwordRaw);
		}

		[Test] public void testCreateNewArchiveMakesFile() {
			using (SecureStringToStringMarshaler sm = new SecureStringToStringMarshaler(passwordSecure)) {
			    StringAssert.IsMatch(passwordRaw, sm.String);
			}
		}

	}

}