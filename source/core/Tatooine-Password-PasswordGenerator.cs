using System;
using System.Collections.Generic;

namespace Tatooine.Password {

	public class PasswordCharset {

		protected string _name;
		protected string _chars;
		protected bool _enabled;

		public PasswordCharset(string name, string chars, bool enabled) {
			_name = name;
			_chars = chars;
			_enabled = enabled;
		}

		public string getName() {
			return _name;
		}

		public void setStatus(bool enabled) {
			_enabled = enabled;
		}

	}

	public class PasswordGeneratorOptions {

		protected List<PasswordCharset> charsets;
		protected int length;

		public PasswordGeneratorOptions() {
			// Defaults:
			length = 16;

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

		public void setCharsetStatus(string name, bool status) {
			foreach (PasswordCharset charset in charsets) {
				if (charset.getName().Equals(name)) {
					charset.setStatus(status);
				}
			}
		}

	}

	public class PasswordGenerator {

		public PasswordGenerator(PasswordGeneratorOptions options) {

		}

	}

}