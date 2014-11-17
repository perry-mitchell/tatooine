using System;
using System.Security;
using System.IO;
using Tatooine;
using Tatooine.Utilities;
using System.Collections.Generic;

namespace Tatooine.CLI {

	class Interactive {

		protected PasswordArchive archive;
		protected string archiveFilename;
		protected SecureString currentPassword;

		public Interactive(string filename = "") {
			archiveFilename = filename;
			currentPassword = new SecureString();
			if ((filename.Length > 0) && File.Exists(filename)) {
				start();
			} else {
				startNew();
			}
		}

		private SecureString getPassword() {
			SecureString pwd = new SecureString();
			Console.Write("Password: ");
			int length = 0;
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
                    length += 1;
                }
            }
            Console.WriteLine("");
            if (length < PasswordArchive.PASSWORD_MIN_LENGTH) {
            	Console.WriteLine("Password too short - must be a minimum of " + PasswordArchive.PASSWORD_MIN_LENGTH + "characters.");
            	Console.WriteLine("Please try again...");
            	return getPassword();
            }
            return pwd;
		}

		protected bool passwordHasBeenSet() {
			int length = 0;
			using(SecureStringToStringMarshaler sm = new SecureStringToStringMarshaler(currentPassword)) {
				length = sm.String.Length;
			}
			return (length > 0);
		}

		protected void runMenu() {
			Console.Write("=> ");
			string userInput = Console.ReadLine();
			string[] parts = userInput.Split(' ');
			string major = (parts.Length > 0) ? parts[0].ToLower() : "";

			if (major.Equals("title")) {
				Console.WriteLine(archive.getArchiveTitle());
			} else if (major.Equals("format")) {
				Console.WriteLine(archive.getArchiveFormat());
			} else if (major.Equals("set")) {
				if (parts.Length >= 3) {
					List<string> args = new List<string>(parts);
					// Remove first 2 items
					args.RemoveAt(0);
					args.RemoveAt(0);
					setArchiveParameter(parts[1], string.Join(" ", args.ToArray()));
				} else {
					Console.WriteLine("Error: format expected to be 'set <key> <value>'");
				}
			} else if (major.Equals("save")) {
				if (!passwordHasBeenSet()) {
					currentPassword = getPassword();
				}

			} else if (major.Equals("exit") || major.Equals("quit")) {
				return;
			} else {
				Console.WriteLine("Unknown command.");
			}

			runMenu();
		}

		protected void setArchiveParameter(string key, string value) {
			if (key.Equals("title")) {
				archive.setArchiveTitle(value);
			} else {
				Console.WriteLine("Error: unknown property '" + key + "'");
			}
		}

		protected void start() {
			currentPassword = getPassword();
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

		protected void startNew() {
			Console.WriteLine("Starting new archive...");
			archive = PasswordArchive.createNew();
			archive.setArchiveFormat(PasswordArchive.SUPPORTED_ARCHIVE_FORMAT);
			runMenu();
		}

	}

}