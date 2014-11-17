using System;
using System.Security;
using System.IO;
using Tatooine;

namespace Tatooine.CLI {

	class Interactive {

		protected PasswordArchive archive;
		protected string archiveFilename;

		public Interactive(string filename) {
			archiveFilename = filename;
			start();
		}

		private SecureString getPassword() {
			SecureString pwd = new SecureString();
			Console.Write("Password: ");
            while (true) {
                ConsoleKeyInfo i = Console.ReadKey(true);
                if (i.Key == ConsoleKey.Enter) {
                    break;
                } else if (i.Key == ConsoleKey.Backspace) {
                    if (pwd.Length > 0) {
                        pwd.RemoveAt(pwd.Length - 1);
                        Console.Write("\b \b");
                    }
                } else {
                    pwd.AppendChar(i.KeyChar);
                    Console.Write("×");
                }
            }
            Console.WriteLine("");
            return pwd;
		}

		protected void start() {
			SecureString password = getPassword();
			try {
				archive = PasswordArchive.createFromFileUsingPlainText(archiveFilename);
			} catch (IOException ie) {
				Console.WriteLine("Failed loading file: ", archiveFilename);
			}
			if (archive != null) {
				Console.WriteLine("Loaded: " + archive.getArchiveTitle());
			} else {
				throw new Exception("Failed opening archive: " + archiveFilename);
			}
		}

	}

}