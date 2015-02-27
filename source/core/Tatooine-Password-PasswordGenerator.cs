using System;
using System.Collections.Generic;

namespace Tatooine.Password {

	public class PasswordCharset {

		protected string _name;
		protected string _chars;
		protected bool _enabled;

		protected int uses;

		public PasswordCharset(string name, string chars, bool enabled) {
			_name = name;
			_chars = chars;
			_enabled = enabled;

			uses = 0;
		}

		public string getCharString() {
			return _chars;
		}

		public string getName() {
			return _name;
		}

		public bool isEnabled() {
			return _enabled;
		}

		public void setStatus(bool enabled) {
			_enabled = enabled;
		}

	}

	public class PasswordGeneratorOptions {

		protected List<PasswordCharset> charsets;
		protected int _length;

		public PasswordGeneratorOptions() {
			// Defaults:
			_length = 16;

			// Characters:
			charsets = new List<PasswordCharset> {
				new PasswordCharset("alpha-low", "abcdefghijklmnopqrstuvwxyz", true),
				new PasswordCharset("alpha-up", "ABCDEFGHIJKLMNOPQRSTUVWXYZ", true),
				new PasswordCharset("numeric", "0123456789", true),
				new PasswordCharset("dash", "-", false),
				new PasswordCharset("underline", "_", false),
				new PasswordCharset("space", " ", false),
				new PasswordCharset("special", "~!@#$%^&*+=;:,./?|", true),
				new PasswordCharset("brackets", "[]{}()<>", false)
			};
		}

		public List<PasswordCharset> getEnabledCharsets() {
			List<PasswordCharset> enabledSets = new List<PasswordCharset>();
			foreach (PasswordCharset charset in charsets) {
				if (charset.isEnabled()) {
					enabledSets.Add(charset);
				}
			}
			return enabledSets;
		}

		public int getLength() {
			return _length;
		}

		public void setCharsetStatus(string name, bool status) {
			foreach (PasswordCharset charset in charsets) {
				if (charset.getName().Equals(name)) {
					charset.setStatus(status);
				}
			}
		}

		public void setLength(int length) {
			_length = length;
		}

	}

	public class PasswordGenerator {

		protected List<PasswordCharset> charsets;
		protected PasswordGeneratorOptions _options;

		private PasswordGenerator(PasswordGeneratorOptions options) {
			_options = options;
			charsets = options.getEnabledCharsets();
		}

		public static string generateNewPassword(PasswordGeneratorOptions options) {
			PasswordGenerator generator = new PasswordGenerator(options);
			string password = "";
			for (int i = 0; i < generator.getOptions().getLength(); i += 1) {

			}
			return password;
		}

		// protected PasswordCharset getNextCharset() {
			
		// }

		protected PasswordGeneratorOptions getOptions() {
			return _options;
		}

	}

}